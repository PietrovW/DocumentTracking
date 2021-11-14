using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DocumentTracking.Infrastructure.Data
{
    public class DocumentTrackingContextFactory : IDesignTimeDbContextFactory<DocumentTrackingContext>
    {
        public DocumentTrackingContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DocumentTrackingContext>();
            builder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=datebase;User Id=postgres;Password=postgres;");
            return new DocumentTrackingContext(builder.Options);
        }
    }
}
