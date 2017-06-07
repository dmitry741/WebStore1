using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore1.Models
{
    public class MyPerson
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int age { get; set; }
        public string position { get; set; }
        public string hobbies { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", LastName, FirstName);
        }
    }
}