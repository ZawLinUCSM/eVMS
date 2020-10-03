
using CMS.Repositories;
using CMS.Repositories.Interfaces;
using CMS.Services;
using CMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CMS_API.Service_Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureDBContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<eVoucherContext>(o => o.UseSqlServer(connectionString));
            //services.Configure<DBSetting>(options => config.GetSection("ConnectionStrings").Bind(options));
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IEVoucherServices, EVoucherSerivces>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEVoucherRepository, EVoucherRepository>();

        }

    }
}
