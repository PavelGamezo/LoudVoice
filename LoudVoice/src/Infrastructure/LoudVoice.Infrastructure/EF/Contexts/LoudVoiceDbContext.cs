using LoudVoice.Domain.Performers;
using LoudVoice.Domain.Performers.Entities;
using LoudVoice.Domain.Users;
using LoudVoice.Infrastructure.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LoudVoice.Infrastructure.EF.Contexts
{
    public class LoudVoiceDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Composition> Compositions { get; set; }

        public LoudVoiceDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userConfiguration = new UserDbConfiguration();
            var performerConfiguration = new PerformerDbConfiguration();
            var compositionConfiguration = new CompositionDbConfiguration();

            modelBuilder.ApplyConfiguration(userConfiguration);
            modelBuilder.ApplyConfiguration(performerConfiguration);
            modelBuilder.ApplyConfiguration(compositionConfiguration);

            base.OnModelCreating(modelBuilder);
        }
    }
}
