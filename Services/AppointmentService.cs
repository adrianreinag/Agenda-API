using AgendaAPI.Models;
using AgendaAPI.Services.Interfaces;
using AgendaAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Services
{
    public class AppointmentService(ContextDB context) : IAppointmentService
    {
        private readonly ContextDB _context = context;

        public async Task<Appointment> CreateAppointment(AppointmentRequest request)
        {
            var appointment = new Appointment
            {
                DateTime = request.DateTime,
                Description = request.Description,
                ContactId = request.ContactId,
            };

            var createAppointment = await _context.AppointmentEntity.AddAsync(appointment);

            await _context.SaveChangesAsync();

            _context.Entry(createAppointment.Entity).Reference(c => c.Contact).Load();

            return createAppointment.Entity;
        }

        public async Task DeleteAppointment(int id)
        {
            var appointmentToDelete = await _context.AppointmentEntity.FindAsync(id);

            if (appointmentToDelete != null)
            {
                _context.AppointmentEntity.Remove(appointmentToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
            return await _context.AppointmentEntity.Include(c => c.Contact)
                                                   .ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsByContact(int contactId)
        {
            return await _context.AppointmentEntity.Include(c => c.Contact)
                                                   .Where(c => c.ContactId == contactId)
                                                   .ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointmentsByDate(DateTime date)
        {
            return await _context.AppointmentEntity.Include(c => c.Contact)
                                                   .Where(c => c.DateTime.Date == date.Date)
                                                   .ToListAsync();
        }

        public async Task<Appointment?> UpdateAppointment(int id, AppointmentRequest request)
        {
            var appointmentToUpdate = await _context.AppointmentEntity.FindAsync(id);

            if (appointmentToUpdate != null)
            {
                appointmentToUpdate.DateTime = request.DateTime;
                appointmentToUpdate.Description = request.Description;
                appointmentToUpdate.ContactId = request.ContactId;

                await _context.SaveChangesAsync();
                _context.Entry(appointmentToUpdate).Reference(c => c.Contact).Load();

                return appointmentToUpdate;
            }

            return null;
        }
    }
}
