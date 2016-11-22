using CodeFirstEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CodeFirstEntityFramework.DAL
{
    public class CarContext : DbContext
    {

        public CarContext() : base("CarContext")
        {
            Database.SetInitializer<CarContext>(new DropCreateDatabaseIfModelChanges<CarContext>());

        }


        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brand { get; set; }

        public DbSet<Person> Person { get; set; }

        //public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}