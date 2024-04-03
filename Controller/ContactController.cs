using AgendaAPI.Context;
using AgendaAPI.Models;
using AgendaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController(IContactService contactService) : ControllerBase
    {
        private readonly IContactService _contactService = contactService;

        [HttpPost("/contact")]
        public async Task<IActionResult> CreateContact(ContactRequest request)
        {
            var createContact = await _contactService.CreateContact(request);

            return Created($"/contacts/{createContact.Id}", createContact);
        }

        [HttpDelete("/contact/{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactService.DeleteContact(id);

            return Ok();
        }

        [HttpGet("/contacts")]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _contactService.GetAllContacts();

            return Ok(contacts);
        }

        [HttpGet("/contacts/name/{name}")]
        public async Task<IActionResult> GetContactsByName(string name)
        {
            var contacts = await _contactService.GetContactsByName(name);

            return Ok(contacts);
        }

        [HttpPut("/contact/{id}")]
        public async Task<IActionResult> UpdateContact(int id, ContactRequest contactRequest)
        {
            var contact = await _contactService.UpdateContact(id, contactRequest);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }


    }
}
