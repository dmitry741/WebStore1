using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore1.Code
{
    public class Company
    {
        static private IEnumerable<Models.MyPerson> s_persons;

        static public IEnumerable<Models.MyPerson> Persons
        {
            get
            {
                if (s_persons == null)
                    s_persons = GetPersons();

                return s_persons;
            }
        }

        static public void Add(Models.MyPerson person)
        {
            var newId = (Persons.Count() > 0) ? Persons.Max(x => x.id) + 1 : 0;
            person.id = newId;
            s_persons = Persons.Concat(new[] { person });
        }

        static public void Delete(int id)
        {
            Models.MyPerson person = Persons.FirstOrDefault(x => x.id == id);
            s_persons = Persons.Except(new[] { person });
        }

        static private IEnumerable<Models.MyPerson> GetPersons()
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
                    hobbies = "Books, airplanes"
                },
                new Models.MyPerson
                {
                    id = personalId++,
                    FirstName = "Petr",
                    LastName = "Ivanov",
                    age = 30,
                    position = "Web designer",
                    hobbies = "Running, birds"
                },
                new Models.MyPerson
                {
                    id = personalId++,
                    FirstName = "Lubov",
                    LastName = "Sergeeva",
                    age = 31,
                    position = "Front-end developer",
                    hobbies = "Travelling, cinema"
                }
            };

            return persons;
        }
    }
}