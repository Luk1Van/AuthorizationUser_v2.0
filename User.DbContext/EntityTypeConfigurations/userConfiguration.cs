using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using User.DataModel;

namespace User.DbContext.EntityTypeConfigurations
{
    public class userConfiguration : IEntityTypeConfiguration<user>
    {
        public void Configure(EntityTypeBuilder<user> builder)
        {
            builder.HasKey(u => u.id);
            builder.HasIndex(u => u.id).IsUnique();

            builder.HasOne(g => g._Group)
                .WithMany(g => g.userG)
                .HasForeignKey(g => g.user_group_id);

            builder.HasOne(g => g._State)
                .WithMany(g => g.userS)
                .HasForeignKey(g => g.user_state_id);

            builder.HasData(new user
            {
                id = 1,
                login = "Capybara",
                password = "123456",
                created_date = new DateTime(2009, 6, 15, 13, 45, 30,
                                    DateTimeKind.Utc),
                user_group_id = 1,
                user_state_id = 1
            });
            builder.HasData(new user
            {
                id = 2,
                login = "Elephant",
                password = "123456",
                created_date = new DateTime(2009, 6, 15, 13, 45, 30,
                                    DateTimeKind.Utc),
                user_group_id = 1,
                user_state_id = 1
            });
            builder.HasData(new user
            {
                id = 3,
                login = "Monkey",
                password = "123456",
                created_date = new DateTime(2009, 6, 15, 13, 45, 30,
                                    DateTimeKind.Utc),
                user_group_id = 1,
                user_state_id = 1
            });
        }
    }
}
