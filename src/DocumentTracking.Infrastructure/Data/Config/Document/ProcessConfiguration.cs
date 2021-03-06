using DocumentTracking.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DocumentTracking.Infrastructure.Data.Config
{
    public class ProcessConfiguration : IEntityTypeConfiguration<Process>
    {
        public void Configure(EntityTypeBuilder<Process> builder)
        {
            builder.ToTable("Process", schema: "Document");
            builder.Property(b => b.InvoiceId)
                .IsRequired();
            builder.Property(b => b.Name)
                .IsRequired();
            builder.Property(b => b.Status)
                .IsRequired();
            builder.Property<DateTime>("LastUpdated")
                .ValueGeneratedOnAddOrUpdate();
            builder.Property<bool>("Available")
                .HasDefaultValue(true);
            builder.Property<long>("User")
                .IsRequired();
            builder.Property<int>("Ver")
                .ValueGeneratedOnAddOrUpdate()
                .IsRequired();
        }
    }
}
