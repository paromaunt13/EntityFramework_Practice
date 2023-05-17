using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_ManyToMany
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Model> Models { get; set; }
        public Brand()
        {
            Models = new List<Model>();
        }
    }
}
