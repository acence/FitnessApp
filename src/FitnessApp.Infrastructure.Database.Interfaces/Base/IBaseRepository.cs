namespace FitnessApp.Infrastructure.Database.Interfaces.Base
{
	public interface IBaseRepository<T>
	{
		IQueryable<T> Select();
		Task<Int32> Insert(T entity);
		Task<Int32> Update(T entity);
		Task<Int32> Delete(T entity);
	}
}
