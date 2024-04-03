using AgendaAPI.Context;
using AgendaAPI.Models;
using AgendaAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Services
{
    public class ContactService(ContextDB context) : IContactService
    {
        private readonly ContextDB _context = context;

        public async Task<Contact> CreateContact(ContactRequest request)
        {
            var contact = new Contact
            {
                Name = request.Name ?? string.Empty,
                LastName = request.LastName ?? string.Empty,
                PhoneNumber = request.PhoneNumber ?? string.Empty,
                Address = request.Address ?? string.Empty,
            };

            var createContact = await _context.ContactEntity.AddAsync(contact);

            await _context.SaveChangesAsync();

            return createContact.Entity;
        }

        public async Task DeleteContact(int id)
        {
            var contactToDelete = await _context.ContactEntity.FindAsync(id);

            if (contactToDelete != null)
            {
                _context.ContactEntity.Remove(contactToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _context.ContactEntity.ToListAsync();
        }

        public async Task<List<Contact>> GetContactsByName(string name)
        {
            return await _context.ContactEntity.Where(c => c.Name == name)
                                               .ToListAsync();
        }

        public async Task<Contact?> UpdateContact(int id, ContactRequest request)
        {
            var contactToUpdate = await _context.ContactEntity.FindAsync(id);

            if (contactToUpdate != null)
            {
                contactToUpdate.Name = request.Name;
                contactToUpdate.LastName = request.LastName;
                contactToUpdate.PhoneNumber = request.PhoneNumber;
                contactToUpdate.Address = request.Address;

                await _context.SaveChangesAsync();
            
                return contactToUpdate;
            }

            return null;
        }
    }
}
