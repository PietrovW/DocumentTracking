using DocumentTracking.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DocumentTracking.Infrastructure.Data.Config
{
    public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.ToTable("InvoiceItems", schema: "Document");
            builder.Property<DateTimeOffset>("LastUpdated")
                .ValueGeneratedOnAddOrUpdate();
            builder.Property<bool>("Available")
                .HasDefaultValue(true);
            builder.Property<long>("User")
                .IsRequired();
            builder.Property<int>("Ver")
                .ValueGeneratedOnAddOrUpdate().IsRequired();
        }
    }
}
