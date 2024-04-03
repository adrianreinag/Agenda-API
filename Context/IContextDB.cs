using AgendaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AgendaAPI.Context
{
    public interface IContextDB
    {
        public DbSet<Appointment> AppointmentEntity { get; set; }
        public DbSet<Contact> ContactEntity { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync (bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        EntityEntry Entry(object entity);
    }
}
