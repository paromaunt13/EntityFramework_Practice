using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_ManyToMany
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public ICollection<Brand> Brands { get; set; }
        public Model()
        {
            Brands = new List<Brand>();
        }
    }
}
