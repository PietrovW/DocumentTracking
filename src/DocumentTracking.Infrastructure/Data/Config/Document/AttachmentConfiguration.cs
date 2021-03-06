using DocumentTracking.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DocumentTracking.Infrastructure.Data.Config
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.ToTable("Attachments", schema: "Document");
            builder.HasKey(x=>x.Id);
            builder.Property<DateTimeOffset>("LastUpdated").ValueGeneratedOnAddOrUpdate();
            builder.Property<bool>("Available").HasDefaultValue(true);
            builder.Property<long>("User").IsRequired();
            builder.Property<int>("Ver").ValueGeneratedOnAddOrUpdate().IsRequired();
        }
    }
}
