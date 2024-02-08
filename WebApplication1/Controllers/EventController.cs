using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models.DTOS;

namespace EventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventDTO>> GetEvents()
        {
            var events = _eventService.GetEvents();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public ActionResult<EventDTO> GetEventById(int id)
        {
            var eventDto = _eventService.GetEventById(id);

            if (eventDto == null)
            {
                return NotFound();
            }

            return Ok(eventDto);
        }

        [HttpPost]
        public ActionResult<EventDTO> AddEvent(EventDTO eventDTO)
        {
            var isSuccess = _eventService.Add(eventDTO);

            if (isSuccess)
            {
                return CreatedAtAction(nameof(GetEventById), new { id = eventDTO.Id }, eventDTO);
            }

            return BadRequest("Failed to add the event");
        }

        [HttpPut("{id}")]
        public ActionResult<EventDTO> UpdateEvent(int id, EventDTO eventDTO)
        {
            if (id != eventDTO.Id)
            {
                return BadRequest("Mismatched IDs");
            }

            var updatedEvent = _eventService.Update(eventDTO);

            if (updatedEvent == null)
            {
                return NotFound();
            }

            return Ok(updatedEvent);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEvent(int id)
        {
            var isDeleted = _eventService.Remove(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
