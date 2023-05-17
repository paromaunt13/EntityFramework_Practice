using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_OneToMany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CompanyDB>());
            CompanyDB companyDB = new CompanyDB();

            Person p1 = new Person { Name = "Roman", Age = 27 };
            Person p2 = new Person { Name = "Alex", Age = 30 };
            Person p3 = new Person { Name = "Dmitriy", Age = 25 };
            Person p4 = new Person { Name = "Ivan", Age = 29 };
            companyDB.Persons.AddRange(new List<Person> { p1, p2, p3, p4 });
            companyDB.SaveChanges();

            var persons = companyDB.Persons.ToList();

            Employee programmer = new Employee { Position = "Programmer", Salary = 25000, Persons = new List<Person> { p1, p2, p3 } };
            Employee salesManager = new Employee { Position = "Sales Manager", Salary = 40000, Persons = new List<Person> { p4 } };
            companyDB.Employees.AddRange(new List<Employee> { programmer, salesManager });
            companyDB.SaveChanges();

            var employees = companyDB.Employees.ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine($"\nДолжность: {employee.Position} \nЗаработная плата: {employee.Salary}");
                foreach (var person in employee.Persons)
                {
                    Console.WriteLine($"ID сотрудника: {person.Id} \nИмя сотрудника: {person.Name} \nВозраст сотрудника: {person.Age} ");
                }
            }
            Console.WriteLine(new string('-', 40));
            #region LINQ-запросы (5 и 6 задание)
            var first = persons.First();
            var firstOrDefault = persons.FirstOrDefault();
            var orderBy = persons.OrderBy(p => p.Name).ToString();
            var count = persons.Count();
            var min = persons.Min(p => p.Age).ToString();
            var max = persons.Max(p => p.Age).ToString();
            var average = persons.Average(p => p.Age);

            Console.WriteLine(first.Name);
            Console.WriteLine(firstOrDefault.Name);
            Console.WriteLine(count);
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine(average);

            Console.WriteLine(new string('-', 40));

            var include = companyDB.Employees.Include(first.Name);
            var select = companyDB.Employees.Select(p => p.Salary);
            var find = companyDB.Employees.Find(25000);

            Console.WriteLine(select.Count());

            #endregion
            Console.ReadKey();

        }
    }
}
