using DataLayer.Repositories;
using Core.Services;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace Project.Settings
{
    public static class Dependencies
    {

        public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddControllers();
            applicationBuilder.Services.AddSwaggerGen();

            applicationBuilder.Services.AddDbContext<AppDbContext>();

            AddRepositories(applicationBuilder.Services);
            AddServices(applicationBuilder.Services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<UserService>();
            services.AddScoped<ItemService>();
            services.AddScoped<OrderService>();
            services.AddScoped<MyAuthenticationService>();

        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<UserRepository>();
            services.AddScoped<OrderRepository>();
            services.AddScoped<ItemRepository>();
            services.AddScoped<UnitOfWork>();
        }

    }
}
