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
    public class RoleMap : EntityTypeConfigurator<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));

            builder.HasKey(nameof(Role.Id));

            builder.Property(nameof(Role.Name)).HasMaxLength(250).IsRequired();
            builder.Property(nameof(Role.SystemName)).HasMaxLength(250).IsRequired();

            

            base.Configure(builder);
        }
    }
}
