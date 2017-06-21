using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace WebStore1.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Login)
                .HasMaxLength(250)
                .IsRequired();

            Property(x => x.Password)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
