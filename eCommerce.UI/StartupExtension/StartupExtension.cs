using Core.Domain;
using Core.Domain.RespositoryConstract;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Respositories;
using Core.Services;
using Entities;
using eCommerce.Core.Domain.Entities;
namespace eCommerce.UI.StartupExtension
{
    public static class StartupExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddControllersWithViews();


            


            IServiceCollection serviceCollection = services.AddDbContext<ShopQuanAoContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ShopQuanAo"));
            });

            services.AddScoped<ILoaiHangHoaRespository, LoaiHangHoaRespository>();
            services.AddScoped<ILoaiHangHoaGetter, LoaiHangHoaGetterService>();

            services.AddScoped<IHangHoaRespository, HangHoaRespository>();
            services.AddScoped<IHangHoaGetter, HangHoaGetterService>();
            services.AddScoped<IHangHoaSearch, HangHoaSearchService>();


            return services;

            
        }
    }
}
