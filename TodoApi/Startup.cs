using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using TodoApi.Service;
using Microsoft.AspNetCore.Http;
using Hangfire.MySql.Core;
using Hangfire;
using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Filters;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApi.Helpers;

namespace TodoApi
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
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                    .AllowAnyMethod()
                                                                     .AllowAnyHeader())); 
            string sConnectionString = Configuration.GetConnectionString("HangfireConnection");
            var storage = new MySqlStorage(sConnectionString, new MySqlStorageOptions
            {
            TransactionIsolationLevel = System.Data.IsolationLevel.ReadCommitted,
            QueuePollInterval = TimeSpan.FromSeconds(15),
            JobExpirationCheckInterval = TimeSpan.FromHours(1),
            CountersAggregateInterval = TimeSpan.FromMinutes(5),
            PrepareSchemaIfNecessary = true,
            DashboardJobListLimit = 50000,
            TransactionTimeout = TimeSpan.FromMinutes(1),
            });
            services.AddHangfire(x => x.UseStorage(storage));   
            services.AddScoped<IUserManager, UserManager>();                                                   
            services.AddScoped<IDayLogManager, DayLogManager>();
            services.AddScoped<ITargetItemManager, TargetItemManager>();
            services.AddScoped<ITodoLogManager, TodoLogManager>();
            services.AddScoped<ITodoItemManager, TodoItemManager>();
            services.AddDbContext<TodoContext>(options => 
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        { 
            app.UseCors("AllowAll");
            // var options = new DashboardOptions
            // {
            //      Authorization = new[] { new CustomAuthorizeFilter() }
            // };
            // app.UseHangfireDashboard("/hangfire", options);
            app.UseHangfireDashboard("/hangfire");
            app.UseHangfireServer();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
