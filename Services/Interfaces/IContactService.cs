using AgendaAPI.Models;

namespace AgendaAPI.Services.Interfaces
{
    public interface IContactService
    {
        Task<Contact> CreateContact(ContactRequest request);
        Task DeleteContact(int id);
        Task<List<Contact>> GetAllContacts();
        Task<List<Contact>> GetContactsByName(string name);
        Task<Contact?> UpdateContact(int id, ContactRequest request);
    }
}