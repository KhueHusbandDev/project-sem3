using Faker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Online_sms.Interfaces;
using Online_sms.Models;

namespace Online_sms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepo _contactRepository;

        public ContactController(IContactRepo contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAllContacts()
        {
            return Ok(await _contactRepository.GetAllContactsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _contactRepository.GetContactByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(ContactRequest contact)
        {
            var userId = int.Parse(User.FindFirst("User_id")?.Value);
            contact.User_id = userId;
            var newContact = await _contactRepository.AddContactAsync(contact);
            return Ok(newContact.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, Contact contact)
        {
            var updatedContact = await _contactRepository.UpdateContactAsync(id,contact);

            if (updatedContact == null)
            {
                return NotFound();
            }
            return Ok(updatedContact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactRepository.DeleteContactAsync(id);
            return NoContent();
        }
    }
}
