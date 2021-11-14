using System.IO;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using DocumentTracking.Api.Extensions;
using System.Threading.Tasks;

namespace DocumentTracking
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
         .ConfigureWebHostDefaults(webHostBuilder =>
         {
             webHostBuilder
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseIISIntegration()
              .UseStartup<Startup>();
         })
         .Build();
          var host2 =  await host.SeedDataAsync();
            await host2.RunAsync();
        }


    }
}
