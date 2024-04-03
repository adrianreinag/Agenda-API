using System.ComponentModel.DataAnnotations;
using System.Net;

namespace AgendaAPI.Models
{
    public record AppointmentRequest
    {
        public AppointmentRequest(DateTime dateTime, string description, int contactId)
        {
            DateTime = dateTime;
            Description = description;
            ContactId = contactId;
        }

        [Required(ErrorMessage = "La fecha y la hora son obligatorias.")]
        public DateTime DateTime { get; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Description { get; }

        [Required(ErrorMessage = "El id del contacto asociado es obligatorio.")]
        public int ContactId { get; }
    }
}
