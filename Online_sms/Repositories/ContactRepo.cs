using Microsoft.EntityFrameworkCore;
using Online_sms.Interfaces;
using Online_sms.Models;

namespace Online_sms.Repositories
{
    public class ContactRepo : IContactRepo
    {
        private readonly DatabaseContext _context;

        public ContactRepo(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact?> GetContactByIdAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<CustomResult> AddContactAsync(ContactRequest contactRequest)
        {
            var newcontact = new Contact()
            {
                User_id = contactRequest.User_id,
                name = contactRequest.name,
                phone = contactRequest.phone,
            };
            _context.Contacts.Add(newcontact);
            await _context.SaveChangesAsync();
            return new CustomResult(200, "Friend request accepted", newcontact);
        }

        public async Task<CustomResult> UpdateContactAsync(int id, Contact contact)
        {
            var existingContact = await _context.Contacts.FindAsync(id);

            if (existingContact == null)
            {
                return new CustomResult(400, "Contact not found", null);
            }

            existingContact.name = contact.name;
            existingContact.phone = contact.phone;

            _context.Contacts.Update(existingContact);
            await _context.SaveChangesAsync();
            return new CustomResult(200, "Contact updated successfully", existingContact);
        }

        public async Task DeleteContactAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}
