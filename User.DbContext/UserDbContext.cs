using Microsoft.EntityFrameworkCore;
using User.DataModel;
using User.DbContext.EntityTypeConfigurations;

namespace User.DbContext
{
    public class UserDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<user> Users { get; set; }
        public DbSet<user_group> user_Groups { get; set; }
        public DbSet<user_state> user_States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new userConfiguration());
            modelBuilder.ApplyConfiguration(new stateConfiguration());
            modelBuilder.ApplyConfiguration(new groupConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}