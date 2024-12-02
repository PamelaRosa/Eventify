using System.Collections.Generic;
using System.Linq;
using EventifyDomain;
using Microsoft.AspNetCore.Mvc;
using EventifyApplication.Contracts;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EventifyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var events = await _eventService.GetAllEventsAsync(true);
                if (events == null) return NotFound("Nenhum evento encontrado");

                return Ok(events);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            {
                try
                {
                    var _event = await _eventService.GetEventByIdAsync(id, true);
                    if (_event == null) return NotFound("Evento não encontrado.");

                    return Ok(_event);
                }
                catch (Exception ex)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
                }
            }
        }

        [HttpGet("theme/{theme}")]
        public async Task<IActionResult> GetByTheme(string theme)
        {
            {
                try
                {
                    var _event = await _eventService.GetAllEventsByThemeAsync(theme, true);
                    if (_event == null) return NotFound("Nenhum evento por tema encontrado.");

                    return Ok(_event);
                }
                catch (Exception ex)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Event model)
        {
            {
                try
                {
                    var _event = await _eventService.AddEventAsync(model);
                    if (_event == null) return BadRequest("Erro ao tentar adicionar evento.");

                    return Ok(_event);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar evento. Erro: {ex.Message}");
                }
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Event model)
        {
            {
                try
                {
                    var _event = await _eventService.UpdateEventAsync(id, model);
                    if (_event == null) return BadRequest("Erro ao tentar atualizar evento.");

                    return Ok(_event);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar evento. Erro: {ex.Message}");
                }
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _eventService.DeleteEventAsync(id))
                    return Ok("Deletado.");
                else
                    return BadRequest("Evento não deletado.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar evento. Erro: {ex.Message}");
            }
        }
    }
}
