using FitnessApp.Infrastructure.Database.Interfaces.Base;
using FitnessApp.Domain.Base;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace FitnessApp.Infrastructure.Database.Base
{
	public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
	{
		public readonly IDatabaseContext _context;
		private readonly ILogger<BaseRepository<T>> _logger;
		private DbSet<T>? _entities;

		public BaseRepository(IDatabaseContext context, ILogger<BaseRepository<T>> logger)
		{
			_context = context;
			_logger = logger;
		}

		protected virtual DbSet<T> Entities
		{
			get
			{
				if (_entities == null)
					_entities = _context.Set<T>();
				return _entities;
			}
		}

		public virtual IQueryable<T> Select()
		{
			return Entities;
		}

		public virtual async Task<Int32> Insert(T entity)
		{
			if (entity == null)
				throw new ArgumentNullException();

			(_context as DbContext)!.Entry(entity).State = EntityState.Added;

			return await _context.SaveChangesAsync();
		}

		public virtual async Task<Int32> Update(T entity)
		{
			if (entity == null)
				throw new ArgumentNullException();
			(_context as DbContext)!.Entry(entity).State = EntityState.Modified;

			return await _context.SaveChangesAsync();
		}

		public virtual async Task<Int32> InsertOrUpdate(Expression<Func<T, bool>> comparer, T entity)
		{
			if (!Entities.Any(comparer))
			{
				return await Insert(entity);
			}
			else
			{
				return await Update(entity);
			}
		}

		public virtual async Task<Int32> Delete(T entity)
		{
			if (entity == null)
				throw new ArgumentNullException();

			Entities.Remove(entity);
			return await _context.SaveChangesAsync();
		}
	}
}
