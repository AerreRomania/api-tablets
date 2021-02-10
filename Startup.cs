using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SmartB.API.Contexts;
using SmartB.API.Contracts.Services;
using SmartB.API.Services;

namespace SmartB.API
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
           
            services.AddMvc(option=>option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            var connectionString = Configuration["ConnectionStrings:onlyouDBConnectionString"];
            services.AddDbContext<AppDbContext>(o=>o.UseSqlServer(connectionString));
           
            services.AddTransient<IAngajatiRepository, AngajatiRepository>();
            services.AddTransient<IMasiniRepository, MasiniRepository>();
            services.AddTransient<IComenziRepository, ComenziRepository>();
            services.AddTransient<IArticolRepository, ArticolRepository>();
            services.AddTransient<IOperatiArticolRepository, OperatiArticolRepository>();
            services.AddTransient<IRealizariRepository, RealizariRepository>();
            services.AddTransient<ICommessaTimRepository, CommessaTimRepository>();
            services.AddTransient<IButoaneRepository, ButoaneRepository>();
            services.AddTransient<IPauseRepository, PauseRepository>();
            services.AddTransient<IJobEfficiencyRepository, JobEfficiencyRepository>();
            services.AddTransient<IDeviceRepository, DeviceRepository>();
            services.AddTransient<IDeviceInfoRepository, DeviceInfoRepository>();
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole();
            //loggerFactory.AddDebug(LogLevel.Information);

            //loggerFactory.AddNLog(); Used

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else used
            //{

            //    app.UseExceptionHandler(appBuilder =>
            //    {
            //        appBuilder.Run(async context =>
            //        {
            //            var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            //            if (exceptionHandlerFeature != null)
            //            {
            //                var logger = loggerFactory.CreateLogger("Global Exception logger");
            //                logger.LogError(500, exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);
            //            }

            //            context.Response.StatusCode = 500;
            //            await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
            //        });
            //    });
            //}

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
