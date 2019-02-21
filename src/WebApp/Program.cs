using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using System;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                //.MinimumLevel.Override("Microsoft", LogEventLevel.Warning) // To add strict filtering rules uncomment. 
                //.MinimumLevel.Override("System", LogEventLevel.Warning)
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();
            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                                         WebHost.CreateDefaultBuilder(args)
                                         .UseSerilog() //Using serilog logging framwork
                                         .UseStartup<Startup>();
    }
}
