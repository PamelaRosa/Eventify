using EventifyDomain;
using Microsoft.EntityFrameworkCore;

namespace EventifyPersistence.Contexts
{
    public class EventifyContext : DbContext
    {
        public EventifyContext(DbContextOptions<EventifyContext> options) : base(options) { }
        public DbSet<Event> Events { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpeakerEvent> SpeakerEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeakerEvent>()
                .HasKey(SE => new { SE.EventId, SE.SpeakerId });

            modelBuilder.Entity<Event>()
                .HasMany(e => e.SocialMedia)
                .WithOne(sm => sm.Event)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Speaker>()
                .HasMany(e => e.SocialMedia)
                .WithOne(sm => sm.Speaker)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}