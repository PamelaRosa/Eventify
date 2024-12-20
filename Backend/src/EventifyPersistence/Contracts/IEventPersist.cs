using System;
using System.Threading.Tasks;
using EventifyDomain;

namespace EventifyPersistence.Contracts
{
    public interface IEventPersist
    {
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false);
        Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false);
    }
}
