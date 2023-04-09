using FitnessApp.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Interfaces
{
	public interface IDatabaseContext
	{
		DbSet<T> Set<T>() where T : BaseModel;
		Int32 SaveChanges();
		Task<Int32> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
