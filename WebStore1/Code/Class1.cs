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
            int personalId = 0;

            var persons = new List<Models.MyPerson>
            {
                new Models.MyPerson
                {
                    id = personalId++,
                    FirstName = "Dmitry",
                    LastName = "Pavlov",
                    age = 43,
                    position = "Software developer",
                    hobbies = "Cars"
                },
                new Models.MyPerson
                {
                    id = personalId++,
                    FirstName = "Petr",
                    LastName = "Ivanov",
                    age = 30,
                    position = "Web designer",
                    hobbies = "Running"
                },
                new Models.MyPerson
                {
                    id = personalId++,
                    FirstName = "Lubov",
                    LastName = "Sergeeva",
                    age = 31,
                    position = "Front-end developer",
                    hobbies = "Travelling"
                }
            };

            return persons;
        }
    }
}