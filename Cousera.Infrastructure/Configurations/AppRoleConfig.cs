using Cousera.Domain.Entities.Identity;
using Cousera.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cousera.Infrastructure.Configurations;

internal class AppRoleConfig : IEntityTypeConfiguration<AppRole>

{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.ToTable(TableNames.AppRoles);
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Description).HasMaxLength(200).IsRequired(true);
        builder.Property(e => e.RoleCode).HasMaxLength(50).IsRequired(true);

        builder.HasMany(e => e.Claims)
            .WithOne()
            .HasForeignKey(e => e.RoleId)
            .IsRequired();
        builder.HasMany(e => e.UserRoles)
            .WithOne()
            .HasForeignKey(e => e.RoleId)
            .IsRequired();
    }
}
