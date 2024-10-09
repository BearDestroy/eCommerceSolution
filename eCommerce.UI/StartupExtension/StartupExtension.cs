using Core.Domain;

using Microsoft.EntityFrameworkCore;
using Infrastructure.Respositories;
using Core.Services;
using Entities;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Helpers;
using eCommerce.Insfrastructure.Respositories;
using Core.DTO;
using eCommerce.Core.Services;
using Core.Domain.RespositoryConstract;
using eCommerce.Core.Domain.RespositoryConstract;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.UI.StartupExtension
{
    public static class StartupExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration, IServiceProvider serviceProvider)
        {

            services.AddControllersWithViews();



            IServiceCollection serviceCollection = services.AddDbContext<ShopQuanAoContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ShopQuanAo"));
            });

           /* services.AddScoped<IKhachHangRespository, KhachHangRespository>();
            services.AddScoped<IKhachHangAdder, KhachHangAdderService>();*/


            services.AddScoped<ILoaiHangHoaRespository, LoaiHangHoaRespository>();
            services.AddScoped<ILoaiHangHoaGetter, LoaiHangHoaGetterService>();

            services.AddScoped<IHangHoaRespository, HangHoaRespository>();
            services.AddScoped<IHangHoaGetter, HangHoaGetterService>();
            services.AddScoped<IHangHoaSearch, HangHoaSearchService>();




            return services;

            
        }
    }
}
