using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RespositoryConstract;
using eCommerce.Core.Helpers;
using eCommerce.Core.ServiceContracts.KhachHang;
using eCommerce.Core.Services;
using eCommerce.Insfrastructure.Respositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using UI.StartupExtension;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<IKhachHangRespository, KhachHangRespository>();
builder.Services.AddScoped<IKhachHangAdder, KhachHangAdderService>();
builder.Services.AddScoped<IKhachHangGetter, KhachHangGetterService>();


builder.Services.ConfigureServices(builder.Configuration);
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".AdventureWorks.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(30);
    options.Cookie.IsEssential = true;
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/KhachHang/DangNhap";
    options.AccessDeniedPath = "/AcessDenied";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
