using System.Data.Entity.ModelConfiguration;
using DataLayer.Models;

namespace DataLayer.Mappings
{
    internal class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            HasKey(m => m.Id);

            Property(m => m.BirthDate);
            Property(m => m.Email);
            Property(m => m.Middlename);
            Property(m => m.Name);
            Property(m => m.Surname);
            Property(m => m.CreatedOn);
        }
    }
}
