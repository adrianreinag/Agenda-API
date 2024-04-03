using AgendaAPI.Models;

namespace AgendaAPI.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<Appointment> CreateAppointment(AppointmentRequest request);
        Task DeleteAppointment(int id);
        Task<List<Appointment>> GetAllAppointments();
        Task<List<Appointment>> GetAppointmentsByContact(int contactId);
        Task<List<Appointment>> GetAppointmentsByDate(DateTime date);
        Task<Appointment?> UpdateAppointment(int id, AppointmentRequest request);
    }
}
