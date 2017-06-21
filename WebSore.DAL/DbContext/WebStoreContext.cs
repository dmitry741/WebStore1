﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebStore1.Domain.Entities;

namespace WebSore.DAL.DbContext
{
    public class WebStoreContext : System.Data.Entity.DbContext
    {
        public WebStoreContext() : base("DbContext") { }

        public DbSet<User> Users { get; set; }
        public DbSet<MyPerson> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MyPersonConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }

    //public class DatabaseInitializer
    //    : DropCreateDatabaseIfModelChanges<WebStoreContext>
    //{
    //    public override void InitializeDatabase(WebStoreContext context)
    //    {

    //    }
    //}
}
