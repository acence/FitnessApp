using FitnessApp.Domain.Base;
using System.Data.Entity;

namespace FitnessApp.Database.Interfaces
{
    public interface IDatabaseContext
    {
        IDbSet<T> Set<T>() where T : BaseModel;
        Int32 SaveChanges();
        Task<Int32> SaveChangesAsync();
    }
}
