using System.Data.Entity;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IRepositoryContext
    {
        DbContext Context { get; set; }
        void SaveChanges();
        Task SaveChangesAsync();
        int ContextHashCode { get; }
    }
}
