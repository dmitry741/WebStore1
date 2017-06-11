using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebStore1.Models
{
    public class MyPerson
    {
        public int id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required")]
        [StringLength(100)]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required")]
        [StringLength(100)]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Age is required")]
        [DisplayName("Age")]
        public int age { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Position is required")]
        [StringLength(250)]
        [DisplayName("Position")]
        public string position { get; set; }

        [DisplayName("Hobbies")]
        public string hobbies { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", LastName, FirstName);
        }
    }
}