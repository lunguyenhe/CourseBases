using Cousera.Domain.Entities.Identity;
using Cousera.Domain.Enums;
using Cousera.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cousera.Infrastructure.Configurations;

internal class FunctionConfiguration : IEntityTypeConfiguration<Function>
{
    public void Configure(EntityTypeBuilder<Function> builder)
    {
        builder.ToTable(TableNames.Functions);

        // builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValue(0);
        builder.Property(e => e.Code).HasMaxLength(50).IsRequired(true);
        builder.Property(e => e.Name).HasMaxLength(200).IsRequired(true);
        builder.Property(e => e.Key).HasMaxLength(50).IsRequired(true);
        builder.Property(e => e.ActiveValue).IsRequired(true);
        builder.Property(e => e.ParentId).HasDefaultValue(-1);
        builder.Property(e => e.CssClass).HasMaxLength(10).HasDefaultValue(null);
        builder.Property(e => e.Url).HasMaxLength(50).IsRequired(true);
        builder.Property(e => e.Status).HasDefaultValue(FunctionStatus.Active);
        builder.Property(e => e.SortOrder).HasDefaultValue(-1);
        builder.Property(e => e.CreatedDate).IsRequired(true);
        builder.Property(e => e.ModifiedDate).IsRequired(true);




    }
}
