using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Sidebar.Controllers;
using Sidebar.Data;
using Sidebar.Data.Repositories;
using Sidebar.Models;
using Sidebar.Models.IdentityUsers;
using Sidebar.Services;

namespace Sidebar {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'OnLineServerAve' not found.");
            builder.Services.AddDbContext<WebAppDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<WebAppDbContext>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IdentityDbContext<AppUser>, WebAppDbContext>();
            builder.Services.AddScoped<UnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<CandidateService, CandidateService>();
            builder.Services.AddScoped<CertificateService, CertificateService>();
            builder.Services.AddScoped<TopicService, TopicService>();
            builder.Services.AddScoped<StemService, StemService>();
            builder.Services.AddScoped<ExamService, ExamService>();
            builder.Services.AddAutoMapper(typeof(Program));
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseMigrationsEndPoint();
            } else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}