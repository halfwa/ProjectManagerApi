using ProjectManagerApi.Data.UoW;

namespace ProjectManagerApi.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static IServiceCollection AddCustomRepository<TEntity, IRepository>(this IServiceCollection services)
              where TEntity : class
              where IRepository : class, IRepository<TEntity>
        {
            return services.AddScoped<IRepository<TEntity>, IRepository>();
        }
    }
}
