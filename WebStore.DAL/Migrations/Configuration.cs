namespace WebStore.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebStore1.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<WebStore.DAL.DbContext.WebStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebStore.DAL.DbContext.WebStoreContext context)
        {
            context.Persons.AddOrUpdate(e => e.id,
             new MyPerson
             {
                 id = 1,
                 age = 43,
                 FirstName = "Dmitry",
                 LastName = "Pavlov",
                 position = "head",
                 hobbies = "web-development"
             },

            new MyPerson
            {
                id = 2,
                age = 22,
                FirstName = "Petr",
                LastName = "Ivanov",
                position = "designer",
                hobbies = "cars"
            },

             new MyPerson
             {
                 id = 3,
                 age = 22,
                 FirstName = "Lubov",
                 LastName = "Sergeva",
                 position = "front-end developer",
                 hobbies = "travelling"
             },

             new MyPerson
             {
                 id = 4,
                 age = 11,
                 FirstName = "Timofeus",
                 LastName = "Pavlov",
                 position = "school boy",
                 hobbies = "jets"
             }
             );

            context.Users.AddOrUpdate(u => u.Id,
                new User
                {
                    Id = 1,
                    Login = "admin",
                    Password = "12345",
                },
                new User
                {
                    Id = 2,
                    Login = "user1",
                    Password = "12345",
                });

            context.SaveChanges();
        }
    }
}
