using System;
using System.Threading.Tasks;
using EventifyDomain;

namespace EventifyPersistence.Contracts
{
    public interface IEventPersist
    {
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers);
        Task<Event[]> GetAllEventsByThemeAsync(string Theme, bool includeSpeakers);
        Task<Event> GetEventByIdAsync(int EventId, bool includeSpeakers);
    }
}
