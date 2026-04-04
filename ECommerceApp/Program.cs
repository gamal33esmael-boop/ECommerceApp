using ECommerceApp.DbCotext;
using ECommerceApp.Interfaces;
using ECommerceApp.Models;
using ECommerceApp.Repository; // ??? ???? ????????????? ?????
using ECommerceApp.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Database
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // 2. Identity (???? ?? ??????? ???)
            builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options => {
                options.SignIn.RequireConfirmedAccount = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            // 3. Register Repositories (?????? ?? ???? ????)
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages(); // ???? ?????? ??? Identity

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();// edit from Gamal

            // 4. ???? ?? ??????? ??? ??????
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
            //My dear friend, I hope this code helps you understand how to set up an e-commerce application using ASP.NET Core with Identity and a generic repository pattern. If you have any questions or need further assistance, feel free to ask!

            //123




            // my commmentnlkfklsg 2323435
            //2
            // Gamal branch 
        }
    }
}