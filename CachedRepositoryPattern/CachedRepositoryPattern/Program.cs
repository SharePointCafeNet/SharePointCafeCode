using CachedRepositoryPattern.DBRepository;
using CachedRepositoryPattern.ServiceLayer;

namespace CachedRepositoryPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            services.AddDbContext<AppDBContext>();
            services.AddTransient<IHomeService, HomeService>();
            builder.Services.AddTransient<HomeRepository>();
            builder.Services.AddTransient<IHomeRepository, CachedHomeRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
