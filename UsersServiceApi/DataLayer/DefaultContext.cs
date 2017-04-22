using System.Data.Entity;
using DataLayer.Mappings;
using DataLayer.Models;

namespace DataLayer
{
    public class DefaultContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CompanyMapping());
            modelBuilder.Configurations.Add(new UserMapping());
        }
    }
}
