using AddressBook.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressBook.Service.Contract
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int contactId);
        Task<bool> AddAsync(Contact contact);
        Task<bool> UpdateAsync(Contact contact);
        Task<bool> DeleteAsync(int contactId);

        Task<bool> AddContactDetailsAsync(ContactDetail contactDetail, int contactId);
    }
}
