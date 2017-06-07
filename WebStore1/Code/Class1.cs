using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore1.Code
{
    public class Company
    {
        static public IEnumerable<Models.MyPerson> GetPersons()
        {
            var persons = new List<Models.MyPerson>
            {
                new Models.MyPerson
                {
                    FirstName = "Dmitry",
                    LastName = "Pavlov",
                    age = 43,
                    position = "Software developer",
                    hobbies = "Cars"
                },
                new Models.MyPerson
                {
                    FirstName = "Petr",
                    LastName = "Ivanov",
                    age = 30,
                    position = "Web designer",
                    hobbies = "Running"
                },
                new Models.MyPerson
                {
                    FirstName = "Lubov",
                    LastName = "Petrova",
                    age = 31,
                    position = "Front-end developer",
                    hobbies = "Travelling"
                }
            };

            return persons;
        }
    }
}