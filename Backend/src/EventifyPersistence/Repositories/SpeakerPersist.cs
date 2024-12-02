using System.Linq;
using System.Threading.Tasks;
using EventifyDomain;
using EventifyPersistence.Contexts;
using EventifyPersistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EventifyPersistence
{
    public class SpeakerPersist : ISpeakerPersist
    {
        private readonly EventifyContext _context;

        public SpeakerPersist(EventifyContext context)
        {
            _context = context;
        }

        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
            .Include(s => s.SocialMedia);

            if (includeEvents)
            {
                query = query
                .Include(s => s.SpeakerEvents)
                .ThenInclude(se => se.Event)
                .AsNoTracking();
            }

            query = query.AsNoTracking().OrderBy(s => s.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
            .Include(s => s.SocialMedia);

            if (includeEvents)
            {
                query = query
                .Include(s => s.SpeakerEvents)
                .ThenInclude(se => se.Event)
                .AsNoTracking();
            }

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(s => s.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Speaker> GetSpeakerByIdAsync(int speakerId, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
            .Include(s => s.SocialMedia);

            if (includeEvents)
            {
                query = query
                .Include(s => s.SpeakerEvents)
                .ThenInclude(se => se.Event)
                .AsNoTracking();
            }

            query = query.AsNoTracking().OrderBy(s => s.Id).Where(s => s.Id == speakerId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
