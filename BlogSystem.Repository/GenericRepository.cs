using BlogSystem.Repository.Interface;
using System.Collections.Generic;
using System.Linq.Expressions;
using BlogSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Repository
{
    public class GenericRepository<TEntity> : IGenericReposiotry<TEntity> where TEntity : class
    {
        public readonly BlogContext _context;
        public DbSet<TEntity> _dbSet;

        public GenericRepository(BlogContext context)
        {
            this._context = context;
            _dbSet = _context.Set<TEntity>();
            //  印出EF 產生SQL語法監看效能
            //this._context.Database.Log = (log) => Debug.WriteLine(log); 
        }


        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }


        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter).AsQueryable();
        }
        public IEnumerable<TEntity> Get<TKey>(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> sortKeySelector, bool isAsc = true)
        {

            if (isAsc)
            {
                return _dbSet
                    .Where(filter)
                    .OrderBy(sortKeySelector)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize).AsQueryable();
            }
            else
            {
                return _dbSet
                    .Where(filter)
                    .OrderByDescending(sortKeySelector)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize).AsQueryable();
            }
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Deleted)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public int SaveChanges()
        {

            //try
            //{
            return _context.SaveChanges();
            //}

            //catch (DbEntityValidationException ex)
            //{
            //    // Retrieve the error messages as a list of strings.
            //    var errorMessages = ex.EntityValidationErrors
            //            .SelectMany(x => x.ValidationErrors)
            //            .Select(x => x.ErrorMessage);

            //    // Join the list to a single string.
            //    var fullErrorMessage = string.Join("; ", errorMessages);

            //    // Combine the original exception message with the new one.
            //    var exceptionMessage =
            //              string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

            //    // Throw a new DbEntityValidationException with the improved exception message.
            //    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            //}
        }

    }
}