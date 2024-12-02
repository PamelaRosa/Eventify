using System.Linq;
using System.Threading.Tasks;
using EventifyDomain;
using EventifyPersistence.Contexts;
using EventifyPersistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EventifyPersistence
{
    public class EventPersist : IEventPersist
    {
        private readonly EventifyContext _context;

        public EventPersist(EventifyContext context)
        {
            _context = context;
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
            .Include(e => e.Batches)
            .Include(e => e.SocialMedia);

            if (includeSpeakers)
            {
                query = query
                .Include(e => e.SpeakerEvents)
                .ThenInclude(se => se.Speaker)
                .AsNoTracking();
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
            .Include(e => e.Batches)
            .Include(e => e.SocialMedia);

            if (includeSpeakers)
            {
                query = query
                .Include(e => e.SpeakerEvents)
                .ThenInclude(se => se.Speaker)
                .AsNoTracking();
            }

            query = query.OrderBy(e => e.Id)
                        .Where(e => e.Theme.ToLower().Contains(theme.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
            .Include(e => e.Batches)
            .Include(e => e.SocialMedia);

            if (includeSpeakers)
            {
                query = query
                .Include(e => e.SpeakerEvents)
                .ThenInclude(se => se.Speaker)
                .AsNoTracking();
            }

            query = query.OrderBy(e => e.Id)
                        .Where(e => e.Id == eventId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
