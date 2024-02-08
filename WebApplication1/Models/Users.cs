using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Users
    {
        [Key]
        public string Username {  get; set; }
        public byte[] Password { get; set; }
        public string Role { get; set; }
        public byte[] Key { get; set; }

        public ICollection<Event>? Events { get; set; }

    }
}
