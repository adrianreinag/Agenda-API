namespace AgendaAPI.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public required DateTime DateTime { get; set; }
        public required string Description { get; set; }
        public required int ContactId { get; set; }
        public Contact? Contact { get; set; }
    }
}
