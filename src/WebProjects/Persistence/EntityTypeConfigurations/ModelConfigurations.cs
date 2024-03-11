using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations;

public class ModelConfigurations : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.BrandId).HasColumnName("BrandId");
        builder.Property(p => p.Name).HasColumnName("name");
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");

        builder.HasOne(p => p.Brand);
        builder.HasMany(p => p.Cars);
    }
}
