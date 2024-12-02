using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EventifyDomain;
using Microsoft.AspNetCore.Mvc;
using EventifyPersistence.Contexts;

namespace EventifyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventifyContext _context;

        public EventsController(EventifyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _context.Events;
        }

        [HttpGet("{id}")]
        public Event GetById(int id)
        {
            return _context.Events.FirstOrDefault(e => e.Id == id);
        }
        [HttpPost]
        public string Post()
        {
            return "Exemplo de post";
        }
        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete com id = {id}";
        }
    }
}
