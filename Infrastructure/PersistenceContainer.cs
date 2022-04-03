using Application.Contracts;
using Infrastructure.Contracts;
using Infrastructure.Identity;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DataContext>(options =>
            {
                options.UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("sqlcon"));
            });



            services.AddScoped(typeof(IAsyncReposiotry<>), typeof(BaseRepository<>));
            services.AddScoped<IAccount, Loging>();
            services.AddScoped<IRegister, Register>();
            services.AddScoped<IRoles,Roles>();
            services.AddScoped<IOfficerReposiotry,OfficerRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IFileRepository, FileRepository>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ReadPolicy",
                    policy => policy.RequireClaim("Read"));

                options.AddPolicy("DetailsPolicy",
                    policy => policy.RequireClaim("Details"));

                options.AddPolicy("CreatePolicy",
                    policy => policy.RequireClaim("Create"));

                options.AddPolicy("EditPolicy",
                    policy => policy.RequireClaim("Edit"));

                options.AddPolicy("DeletePolicy",
                    policy => policy.RequireClaim("Delete"));

                options.AddPolicy("MigratePolicy",
                    policy => policy.RequireClaim("Migrate"));

                options.AddPolicy("UrgentFilesPolicy",
                    policy => policy.RequireClaim("UrgentFiles"));

                options.AddPolicy("SearchPolicy",
                    policy => policy.RequireClaim("Search"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(o=> 
            {
                o.Password.RequiredLength = 5;
                o.Password.RequireNonAlphanumeric=false;
                o.Password.RequireUppercase=false;
                o.Password.RequireLowercase=false;
                o.Password.RequireDigit=false;
                o.Password.RequiredUniqueChars = 0;
            }).AddEntityFrameworkStores<DataContext>();

            services.AddControllersWithViews(o =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                o.Filters.Add(new AuthorizeFilter(policy));
            });

            services.ConfigureApplicationCookie(options => options.LoginPath = "/Login/Loging");
            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Login/AccessDenied");

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.LoginPath = "/Login/Loging";
                options.SlidingExpiration = true;
            });
            return services;
        }
    }
}
