using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventifyDomain;

namespace EventifyApplication.Contracts
{
    public interface IEventService
    {
        Task<Event> AddEventAsync(Event model);
        Task<Event> UpdateEventAsync(int eventId, Event model);
        Task<bool> DeleteEventAsync(int eventId);

        Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false);
        Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false);
    }
}