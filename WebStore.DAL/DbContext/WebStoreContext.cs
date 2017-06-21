using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore1.Domain.Entities;

namespace WebStore.DAL.DbContext
{
    public class WebStoreContext : System.Data.Entity.DbContext
    {
        public WebStoreContext() : base("DbContext") { }

        public DbSet<User> Users { get; set; }
        public DbSet<MyPerson> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MyPersonConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}
