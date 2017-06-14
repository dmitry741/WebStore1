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
    }

    public class User : SimpleUser
    {
        public override string ToString()
        {
            return Login;
        }
    }
}