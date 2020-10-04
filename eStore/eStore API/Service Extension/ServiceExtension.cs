using eStore.Repositories;
using eStore.Repositories.Interfaces;
using eStore.Services;
using eStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eStoreAPI.Service_Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureDBContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<eVoucherContext>(o => o.UseSqlServer(connectionString));            
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IEVoucherService, EVoucherSerivce>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IPaymentService, PaymentService>();           
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IEVoucherRepository, EVoucherRepository>();
            services.AddScoped<IVoucherDetailRepository, VoucherDetailRepository>();
        }

    }
}
