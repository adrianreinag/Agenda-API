using AgendaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AgendaAPI.Context
{
    public class ContextDB(DbContextOptions<ContextDB> options) : DbContext(options), IContextDB
    {
        public DbSet<Appointment> AppointmentEntity { get; set; }
        public DbSet<Contact> ContactEntity { get; set; }
    }
}
