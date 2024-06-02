using Microsoft.EntityFrameworkCore;
using TheBookShelf.Data.Contexts;

namespace TheBookShelf.Api.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TheBookShelfDatabase"))
            );
        }
    }
}
