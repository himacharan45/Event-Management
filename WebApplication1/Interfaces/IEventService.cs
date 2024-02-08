using WebApplication1.Models;
using WebApplication1.Models.DTOS;

namespace WebApplication1.Interfaces
{
    public interface IEventService
    {
        bool Add(EventDTO eventDTO);
        bool Remove(int id);
        EventDTO Update(EventDTO eventDTO);
        EventDTO GetEventById(int id);
        IEnumerable<EventDTO> GetEvents();
    }
}
