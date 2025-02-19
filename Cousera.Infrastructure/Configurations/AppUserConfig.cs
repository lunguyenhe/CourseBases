using Cousera.Domain.Entities.Identity;
using Cousera.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cousera.Infrastructure.Configurations;

internal sealed class AppUserConfig : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable(TableNames.AppUsers);

        builder.HasKey(e => e.Id);
        builder.Property(e => e.IsDirector).HasDefaultValue(false);
        builder.Property(e => e.IsHeadOfDepartment).HasDefaultValue(false);
        builder.Property(e => e.ManagerId).HasDefaultValue(null);
        builder.Property(e => e.IsReceipient).HasDefaultValue(-1);

        builder.HasMany(e => e.Claims)
            .WithOne()
            .HasForeignKey(e => e.UserId)
            .IsRequired();
        builder.HasMany(e => e.Logins)
            .WithOne()
            .HasForeignKey(e => e.UserId)
            .IsRequired();
        builder.HasMany(e => e.Tokens).WithOne()
            .HasForeignKey(e => e.UserId)
            .IsRequired();
        builder.HasMany(e => e.UserRoles)
            .WithOne()
            .HasForeignKey(e => e.UserId)
            .IsRequired();

    }
}
