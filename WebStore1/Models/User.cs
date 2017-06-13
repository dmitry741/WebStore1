using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore1.Models
{
    public class SimpleUser
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public override string ToString()
        {
            return Login;
        }
    }

    public class User : SimpleUser
    {

    }
}