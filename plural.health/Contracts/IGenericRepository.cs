using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace plural.health.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        // TODO refactor igeneric repository pattern
        bool Modify(T t);
        IQueryable<T> Put(T t);
        Task<bool> AddAsync(T t);

        T FindById(object t);
        IQueryable<T> Records(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> All();

        IQueryable<T> FindByTerm(Expression<Func<T, bool>> expression);

        T Update(T t);
        Task<bool> Remove(T t);

    }
}
