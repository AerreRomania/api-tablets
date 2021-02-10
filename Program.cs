using System;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog.Web;


namespace SmartB.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
           ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount);
           var host =  CreateWebHostBuilder(args).Build();

           //using (var scope = host.Services.CreateScope())
           //{
           //    try
           //    {
           //        var context = scope.ServiceProvider.GetService<AppDbContext>();
           //        context.Database.Migrate();
           //    }
           //    catch (Exception exception)
           //    {
           //        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
           //        logger.LogError(exception, "An error occured while migrating the database.");
           //    }
           //}
           host.Run();
           
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //  .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>();
                //.UseNLog(); used
    }
}
