using System.Linq.Expressions;

namespace Repository.IRepository
{
    public interface IBaseRepository<T> where T : class, new()
    {
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool isAsc);

        Task<bool> AddEntityAsync(T entity);
        Task<bool> UpdateEntityAsync(T entity);

        Task<bool> DeleteEntityAsync(T entity);
    }
}
