using Microsoft.EntityFrameworkCore.Infrastructure;
using ProjectManagerApi.Data.Repository;
using System.Collections.Concurrent;

namespace ProjectManagerApi.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {   
        private readonly AppDbContext _appContext;

        private ConcurrentDictionary<Type, object> repositories;

        public UnitOfWork(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository) where TEntity : class
        {
            if(repositories == null)
            {
                repositories = new ConcurrentDictionary<Type, object>();
            }

            if(hasCustomRepository)
            {
                var customRepo = _appContext.GetService<IRepository<TEntity>>();
                if(customRepo != null)
                {
                    return customRepo;
                }
            }

            var type = typeof(TEntity); 
            if(!repositories.ContainsKey(type))
            {
                repositories[type] = new Repository<TEntity>(_appContext);
            }

            return (IRepository<TEntity>)repositories[type];
        }

        public void Dispose() { }
        public int SaveChanges(bool ensureAutoHistory)
        {
            throw new NotImplementedException();
        }
    }
}
