using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedDating.Web.Core;
using SpeedDating.Web.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedDating.Web.Data
{
    public class UserMap : EntityTypeConfigurator<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Password).HasMaxLength(400);
            builder.Property(user => user.Salt).HasMaxLength(400);
            builder.Property(user => user.Active);
            builder.Property(user => user.CreatedOnCet);
            

            base.Configure(builder);
        }
    }
}
