using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SkuskaApp.DTOs;

public class DataConfiguration : IEntityTypeConfiguration<DataDTO>
{
    public void Configure(EntityTypeBuilder<DataDTO> builder)
    {
        builder.ToTable("MainTableProject");
        builder.HasKey(o => o.ID);
        builder.Property(o => o.hum).IsRequired();
        builder.Property(o => o.temp).IsRequired();
    }
}