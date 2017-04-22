using System.Data.Entity.ModelConfiguration;
using DataLayer.Models;

namespace DataLayer.Mappings
{
    internal class CompanyMapping : EntityTypeConfiguration<Company>
    {
        public CompanyMapping()
        {
            HasKey(m => m.Id);

            Property(m => m.Description);
            Property(m => m.Email);
            Property(m => m.FoundationDate);
            Property(m => m.Name);
        }
    }
}
