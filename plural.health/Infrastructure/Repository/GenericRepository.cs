using Microsoft.EntityFrameworkCore;
using plural.health.Contracts;
using plural.health.Data;
using System.Linq.Expressions;

namespace plural.health.Infractures.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;
        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            dbSet = _context.Set<T>();
            _logger = logger;
        }

        public bool Modify(T t)
        {
            _context.Entry(t).State = EntityState.Modified;
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public async Task<bool> AddAsync(T t)
        {
            await _context.AddAsync(t);
            await dbSet.AddAsync(t);
            return true;
        }

        public async Task<bool> Remove(T t)
        {
            _context.Remove(t);
            Save();
            return true;
        }
        public T Update(T t)
        {
            _context.Entry(t).State = EntityState.Modified;
            return t;
        }
        public T FindById(object t)
        {
            var res = dbSet.FindAsync(t);
            if (res != null)
                return res.Result;
            return null;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IQueryable<T> Put(T t)
        {
            dbSet.Update(t);
            return (IQueryable<T>)t;
        }

        public IQueryable<T> FindByTerm(Expression<Func<T, bool>>? expression)
        {
            return dbSet.Where(expression);
        }

        public IQueryable<T> FindByPage(Expression<Func<T, bool>> expression)
        {
            var res = dbSet.TakeWhile(expression);

            if (res.Any())
                return res;
            return null;
        }

        public IQueryable<T> Records(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression);
        }

        public async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }

    }
}
