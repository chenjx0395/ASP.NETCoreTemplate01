using System.Linq.Expressions;
using Repository.EFCore;

namespace Repository
{
    public class BaseRepository<T> where T : class, new()
    {

        protected readonly MyDbContext myDbContext;
        public BaseRepository(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }
        public Task<bool> AddEntityAsync(T entity)
        {
            myDbContext.Set<T>().Add(entity);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteEntityAsync(T entity)
        {
            myDbContext.Set<T>().Remove(entity);
            //myDbContext.SaveChanges();
            return Task<bool>.FromResult(true);
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return myDbContext.Set<T>().Where(whereLambda);
        }

        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            var temp = myDbContext.Set<T>().Where(whereLambda);
            totalCount = temp.Count();
            if (isAsc)
            {
                // 升序
                temp = temp.OrderBy<T, S>(orderByLambda).Skip<T>((pageIndex-1)*pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, S>(orderByLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }

        public Task<bool> UpdateEntityAsync(T entity)
        {
            myDbContext.Set<T>().Update(entity);
            return Task.FromResult(true);
        }



    }
}
