using System.Linq.Expressions;
using Repository.IRepository;

namespace Service
{
    public class BaseService<T> where T : class,new()
    {
       
        protected IBaseRepository<T> repository { get; set; }
        public Task<bool> AddEntityAsync(T entity)
        {
            return repository.AddEntityAsync(entity);
        }

        public Task<bool> DeleteEntityAsync(T entity)
        {
            return repository.DeleteEntityAsync(entity);
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return repository.LoadEntities(whereLambda);
        }

        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool isAsc)
        {
            return repository.LoadPageEntities<S>(pageIndex, pageSize,  out totalCount, whereLambda, orderbyLambda, isAsc);
        }

        public Task<bool> UpdateEntityAsync(T entity)
        {
           return repository.UpdateEntityAsync(entity);
        }
    }
}
