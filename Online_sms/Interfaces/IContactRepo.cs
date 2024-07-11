using Online_sms.Models;

namespace Online_sms.Interfaces
{
    public interface IContactRepo
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<Contact?> GetContactByIdAsync(int id);
        Task<CustomResult> AddContactAsync(ContactRequest contactRequest);
        Task<CustomResult> UpdateContactAsync(int id ,Contact contact);
        Task DeleteContactAsync(int id);
    }
}
