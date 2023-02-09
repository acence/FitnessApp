using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Database.Interfaces
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> Select();
        Task<Int32> Insert(T entity);
        Task<Int32> Update(T entity);
        Task<Int32> Delete(T entity);
    }
}
