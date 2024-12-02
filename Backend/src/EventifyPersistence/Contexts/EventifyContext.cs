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
        }
    }
}