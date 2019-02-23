using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace TaskBoardBuddy.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();


            // Might need to do something like this if i cant self host

            //var host = new WebHostBuilder().UseContentRoot(Directory.GetCurrentDirectory())
            //                   .UseKestrel()
            //                   .UseIISIntegration()
            //                   .UseStartup<Startup>()
            //                   .ConfigureKestrel((context, options) =>
            //                   {
            //                                   // Set properties and call methods on options
            //                               })
            //                   .Build();

            //host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}