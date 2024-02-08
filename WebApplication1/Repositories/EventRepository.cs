using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class EventRepository : IRepository<int, Event>
    {
        private readonly EventContext _context;
        public EventRepository(EventContext context)
        {
            _context = context;
        }

        public Event Add(Event entity)
        {
            _context.events.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Event Delete(int Key)
        {
            var eventa = GetById(Key);
            if (eventa != null)
            {
                _context.events.Remove(eventa);
                _context.SaveChanges();
                return eventa;
            }
            return null;
        }

        public IList<Event> GetAll()
        {
            if (_context.events.Count() == 0)
                return null;
            return _context.events.ToList();
        }

        public Event GetById(int Key)
        {
            var eventa = _context.events.SingleOrDefault(u => u.Id == Key);
            return eventa;
        }

        public Event Update(Event eventa)
        {
            
                _context.events.Update(eventa);
                _context.SaveChanges();
                return eventa;
        }
    }
}
