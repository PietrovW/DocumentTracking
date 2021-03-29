using DocumentTracking.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DocumentTracking.Data.Config
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices", schema: "Document");
            builder.Property(b => b.Name)
                .IsRequired();
            builder.Property(b => b.Type)
                .IsRequired();
            builder.Property<DateTimeOffset>("LastUpdated")
                .ValueGeneratedOnAddOrUpdate()
                .IsRequired();
            builder.Property<bool>("Available")
                .HasDefaultValue(true)
                .IsRequired();
            builder.Property<long>("User")
                .IsRequired();
            builder.Property<int>("Ver")
                .ValueGeneratedOnAddOrUpdate()
                .IsRequired();
        }
    }
}
