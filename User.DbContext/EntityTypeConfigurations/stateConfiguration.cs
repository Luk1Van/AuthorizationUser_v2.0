using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
    public class stateConfiguration : IEntityTypeConfiguration<user_state>
    {
        public void Configure(EntityTypeBuilder<user_state> builder)
        {
            builder.HasKey(s => s.id);
            builder.HasIndex(s => s.id).IsUnique();

            builder
                .Property(d => d.code)
                .HasConversion(new EnumToStringConverter<EnumsState>());

            builder.HasData(new user_state { id = 1, code = EnumsState.Active, description = "Active user" });
            builder.HasData(new user_state { id = 2, code = EnumsState.Blocked, description = "Blocked user" });
        }
    }
}
