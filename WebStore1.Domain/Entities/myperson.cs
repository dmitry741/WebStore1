using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebStore1.Domain.Entities
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

    public class MyPersonConfiguration : EntityTypeConfiguration<MyPerson>
    {
        public MyPersonConfiguration()
        {
            HasKey(x => x.id);

            Property(x => x.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.FirstName)
                .HasMaxLength(250)
                .IsRequired();

            Property(x => x.LastName)
                .HasMaxLength(250)
                .IsRequired();

            Property(x => x.position)
                .HasMaxLength(250)
                .IsRequired();

            Property(x => x.hobbies)
               .HasMaxLength(250)
               .IsRequired();

            Property(x => x.age)
                .IsRequired();
        }
    }
}
