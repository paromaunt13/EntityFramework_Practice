using CodeFirst_ManyToMany;
using System;
using System.Data.Entity;
using System.Linq;

namespace CodeFirst_ManyToMany
{
    public class CompanyDB : DbContext
    {

        public CompanyDB()
            : base("name=CompanyDB")
        {
        }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Model> Players { get; set; }
    }

}