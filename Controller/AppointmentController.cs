using AgendaAPI.Context;
using AgendaAPI.Models;
using AgendaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController(IAppointmentService appointmentService) : ControllerBase
    {
        private readonly IAppointmentService _appointmentService = appointmentService;

        [HttpPost("/appointment")]
        public async Task<IActionResult> CreateAppointment(AppointmentRequest request)
        {
            var createAppointment = await _appointmentService.CreateAppointment(request);

            return Created($"{createAppointment.Id}", createAppointment);
        }

        [HttpDelete("/appointment/{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentService.DeleteAppointment(id);

            return Ok();
        }

        [HttpGet("/appointments")]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointments();

            return Ok(appointments);
        }

        [HttpGet("/appointments/contactId/{contactId}")]
        public async Task<IActionResult> GetAppointmentByContact(int contactId)
        {
            var appointments = await _appointmentService.GetAppointmentsByContact(contactId);
            
            return Ok(appointments);
        }

        [HttpGet("/appointments/date/{date}")]
        public async Task<IActionResult> GetAppointmentByDate(DateTime date)
        {
            var appointments = await _appointmentService.GetAppointmentsByDate(date);

            return Ok(appointments);
        }

        [HttpPut("/appointment/{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, AppointmentRequest request)
        {
            var appointment = await _appointmentService.UpdateAppointment(id, request);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }
    }
}
