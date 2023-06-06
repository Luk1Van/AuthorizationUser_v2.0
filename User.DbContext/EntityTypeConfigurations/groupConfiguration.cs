using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using User.DataModel;

namespace User.DbContext.EntityTypeConfigurations
{
    public class groupConfiguration : IEntityTypeConfiguration<user_group>
    {
        public void Configure(EntityTypeBuilder<user_group> builder)
        {
            builder.HasKey(g => g.id);
            builder.HasIndex(g => g.id).IsUnique();

            builder
                .Property(g => g.code)
                .HasConversion(new EnumToStringConverter<EnumsGroup>());

            builder.HasData(new user_group { id = 1, code = EnumsGroup.User, description = "Regular user" });
            builder.HasData(new user_group { id = 2, code = EnumsGroup.Admin, description = "Admin" });
        }
    }
}
