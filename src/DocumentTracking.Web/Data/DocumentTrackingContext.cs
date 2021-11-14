using DocumentTracking.Data.Config;
using DocumentTracking.Entities;
using DocumentTracking.Infrastructure.Data.Config;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentTracking.Data
{
    public class DocumentTrackingContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        public DbSet<Metadane> Metadanes { get; set; }

        public DbSet<Process> Process { get; set; }

        public DocumentTrackingContext(DbContextOptions<DocumentTrackingContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AttachmentConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new MetadaneConfiguration());
            modelBuilder.ApplyConfiguration(new ProcessConfiguration());

            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityRoleConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityUserClaimConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityUserLoginConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityUserTokenConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityRoleClaimConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityUserRoleConfiguration());
        }

        public override int SaveChanges()
        {
            SaveChangeTracker();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SaveChangeTracker();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess:true,cancellationToken);
        }

        private void SaveChangeTracker()
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("LastUpdated").CurrentValue = DateTime.UtcNow;
                }
                if (entry.State == EntityState.Deleted)
                {
                    entry.Property("Available").CurrentValue = false;
                }
            }
        }
    }
}
