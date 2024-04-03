using System.ComponentModel.DataAnnotations;

namespace AgendaAPI.Models
{
    public record ContactRequest
    {
        public ContactRequest(string name, string lastName, string phoneNumber, string address)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string LastName { get; }

        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        public string PhoneNumber { get; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string Address { get; }
    }
}
