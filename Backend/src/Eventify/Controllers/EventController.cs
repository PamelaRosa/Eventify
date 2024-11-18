using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Eventify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eventify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {

        public IEnumerable<Event> _event = new Event[] {
            new Event() {
                Id = 1,
                Location = "São Paulo, SP",
                Date = DateTime.Now.AddDays(10).ToString(),
                Theme = "Tecnologia e Inovação",
                QtyPeople = 100,
                Batch = "1º Lote",
                ImageURL = "https://example.com/event-image.jpg"
            },
            new Event() {
                Id = 2,
                Location = "Rio de Janeiro, RJ",
                Date = DateTime.Now.AddDays(1).ToString(),
                Theme = "Desenvolvimento de Software",
                QtyPeople = 500,
                Batch = "2º Lote",
                ImageURL = "https://example.com/conference-event-image.jpg"
            }
        };

        public EventController()
        {
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _event;
        }

        [HttpGet("{id}")]
        public IEnumerable<Event> GetById(int id)
        {
            return _event.Where(e => e.Id == id);
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
