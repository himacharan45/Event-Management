using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Contexts
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions options) : base(options)
        { 
        
        }
        public DbSet<Users> users { get; set; }
        public object Users { get; internal set; }
        public DbSet<Event> events { get; set; }

    }
}
