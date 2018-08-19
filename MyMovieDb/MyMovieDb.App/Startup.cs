using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMovieDb.App.Areas.Identity.Services;
using MyMovieDb.App.Common;
using MyMovieDb.Data;
using MyMovieDb.Models;
using MyMovieDb.Services.Admin;
using MyMovieDb.Services.Admin.Interfaces;
using MyMovieDb.Services.Moderator;
using MyMovieDb.Services.Moderator.Interfaces;
using MyMovieDb.Services.User;
using MyMovieDb.Services.Users.Interfaces;

namespace MyMovieDb.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<MyMovieDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddIdentity<User, IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<MyMovieDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password = new PasswordOptions()
                {
                    RequiredLength = 6,
                    RequiredUniqueChars = 1,
                    RequireLowercase = false,
                    RequireDigit = true,
                    RequireUppercase = false,
                    RequireNonAlphanumeric = true
                };

                options.Lockout = new LockoutOptions()
                {
                    DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5),
                    MaxFailedAccessAttempts = 5,
                    AllowedForNewUsers = true
                };

                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
            });

            services.AddSingleton<IEmailSender, SendGridEmailSender>();
            services.Configure<SendGridOptions>(this.Configuration.GetSection("EmailSettings"));

            services.AddAutoMapper();

            services.AddScoped<IAdminUsersService, AdminUsersService>();
            services.AddScoped<IModeratorMovieService, ModeratorMovieService>();
            services.AddScoped<IModeratorPersonService, ModeratorPersonService>();
            services.AddScoped<IModeratorGenreService, ModeratorGenreService>();
            services.AddScoped<IUserSearchService, UserSearchService>();
            
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddSessionStateTempDataProvider();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.SeedDatabase();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "area",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
