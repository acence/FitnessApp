using FitnessApp.Database.Interfaces;
using FitnessApp.Domain.Base;
using Microsoft.Extensions.Logging;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq.Expressions;

namespace FitnessApp.Database.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        public readonly IDatabaseContext _context;
        private readonly ILogger<BaseRepository<T>> _logger;
        private IDbSet<T>? _entities;

        public BaseRepository(IDatabaseContext context, ILogger<BaseRepository<T>> logger)
        {
            _context = context;
            _logger = logger;
        }

        protected virtual IDbSet<T> Entities
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

            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                LogValidationException(e);
                throw;
            }
        }

        public virtual async Task<Int32> Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            (_context as DbContext)!.Entry(entity).State = EntityState.Modified;

            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                LogValidationException(e);
                throw;
            }
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

        private void LogValidationException(DbEntityValidationException e)
        {
            foreach (var eve in e.EntityValidationErrors)
            {
                _logger.LogError("Entity of type {EntityType} in state {State} has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                foreach (var ve in eve.ValidationErrors)
                {
                    _logger.LogError("- Property: {PropertyName}, Error: {ErrorMessage}", ve.PropertyName, ve.ErrorMessage);
                }
            }
        }
    }
}
