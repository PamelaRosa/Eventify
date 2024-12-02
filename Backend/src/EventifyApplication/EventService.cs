using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventifyApplication.Contracts;
using EventifyDomain;
using EventifyPersistence.Contracts;

namespace EventifyApplication
{
    public class EventService : IEventService
    {
        private readonly IGenericPersist _genericPersist;
        private readonly IEventPersist _eventPersist;
        public EventService(IGenericPersist genericPersist, IEventPersist eventPersist)
        {
            _genericPersist = genericPersist;
            _eventPersist = eventPersist;

        }
        public async Task<Event> AddEventAsync(Event model)
        {
            try
            {
                _genericPersist.Add<Event>(model);
                if (await _genericPersist.SaveChangesAsync())
                {
                    return await _eventPersist.GetEventByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<Event> UpdateEventAsync(int eventId, Event model)
        {
            try
            {
                var _event = await _eventPersist.GetEventByIdAsync(eventId, false);
                if (_event == null) return null;

                model.Id = _event.Id;

                _genericPersist.Update<Event>(model);
                if (await _genericPersist.SaveChangesAsync())
                {
                    return await _eventPersist.GetEventByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            try
            {
                var _event = await _eventPersist.GetEventByIdAsync(eventId, false);
                if (_event == null) throw new Exception("Evento não encontrado.");

                _genericPersist.Delete<Event>(_event);

                return await _genericPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            try
            {
                var events = await _eventPersist.GetAllEventsAsync(includeSpeakers);
                if (events == null) return null;

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            try
            {
                var events = await _eventPersist.GetAllEventsByThemeAsync(theme, includeSpeakers);
                if (events == null) return null;

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false)
        {
            try
            {
                var events = await _eventPersist.GetEventByIdAsync(eventId, includeSpeakers);
                if (events == null) return null;

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}