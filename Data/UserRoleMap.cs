using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedDating.Web.Core;
using SpeedDating.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedDating.Web.Data
{
    public class UserRoleMap : EntityTypeConfigurator<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {

            builder.ToTable(nameof(UserRole));

            builder.HasKey(nameof(UserRole.Id));

            builder.HasOne(user => user.User)
                .WithMany(u => u.UserRoles).HasForeignKey(x => x.UserId).IsRequired();

            builder.HasOne(role => role.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(x => x.RoleId).IsRequired();
             


            base.Configure(builder);
        }
    }
}
