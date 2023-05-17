using System;
using System.Data.Entity;
using System.Linq;
using System.Xml;

namespace CodeFirst_OneToMany
{
    public class CompanyDB : DbContext
    {

        public CompanyDB()
            : base("name=CompanyDB")
        {
            
        }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }

}