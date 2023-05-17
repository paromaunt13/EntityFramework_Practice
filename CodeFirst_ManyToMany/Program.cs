using CodeFirst_ManyToMany;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_ManyToMany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CompanyDB>());
            
            using (CompanyDB db = new CompanyDB())
            {
                Model car1 = new Model { Name = "X5", Price = 30000};
                Model car2 = new Model { Name = "i3", Price = 40000};
                Model car3 = new Model { Name = "C40", Price = 35000};
                db.Players.AddRange(new List<Model> { car1, car2, car3 });
                db.SaveChanges();

                Brand brand1 = new Brand { Name = "BMW" };
                brand1.Models.Add(car1);
                brand1.Models.Add(car2);
                Brand brand2 = new Brand { Name = "Volvo" };
                brand2.Models.Add(car3);
                db.Brands.Add(brand1);
                db.Brands.Add(brand2);
                db.SaveChanges();
                foreach (Brand brand in db.Brands.Include(t => t.Models))
                {
                    Console.WriteLine($"Бренд авто - {brand.Name}");
                    foreach (Model car in brand.Models)
                    {
                        Console.WriteLine($"Модель - {car.Name} Стоимость: {car.Price}");
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
            }
        }
    }
}
