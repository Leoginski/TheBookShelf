using Microsoft.EntityFrameworkCore;
using TheBookShelf.Data.Contexts;
using TheBookShelf.Data.Repositories;
using TheBookShelf.Domain.Interfaces.Repositories;
using TheBookShelf.Domain.Interfaces.Services;
using TheBookShelf.Domain.Services;

namespace TheBookShelf.Api.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DataContext")));

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookService, BookService>();
        }
    }
}
