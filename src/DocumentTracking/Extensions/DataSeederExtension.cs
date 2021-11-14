using DocumentTracking.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace DocumentTracking.Api.Extensions
{
    public static class DataSeederExtension
    {
        public static async Task<IHost> SeedDataAsync(this IHost host)
        {
            using (var scope = host?.Services.CreateScope())
            {
              await DocumentTrackingContextSeed.InitializeAsync(scope.ServiceProvider);
             // await DocumentTrackingContextSeed.SeedAsync(scope.ServiceProvider);
            }
            return host;
        }
    }
}
