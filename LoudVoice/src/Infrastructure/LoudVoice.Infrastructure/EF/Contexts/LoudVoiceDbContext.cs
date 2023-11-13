using LoudVoice.Domain.Users.Entity;
using LoudVoice.Infrastructure.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LoudVoice.Infrastructure.EF.Contexts
{
    public class LoudVoiceDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public LoudVoiceDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userConfiguration = new UserDbConfiguration();

            modelBuilder.ApplyConfiguration(userConfiguration);

            base.OnModelCreating(modelBuilder);
        }
    }
}
