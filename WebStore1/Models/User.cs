using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace WebStore1.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public override string ToString()
        {
            return Login;
        }
    }
}