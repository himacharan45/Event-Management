using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public DateTime Date {  get; set; }
        public string Location {  get; set; }
        public int MaxAttendees {  get; set; }
        public float RegistrationFee { get; set; }

        public string Username {  get; set; }
        [ForeignKey("Username")]
        public Users? Users { get; set; }
    }
}
