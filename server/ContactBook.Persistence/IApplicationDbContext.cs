using AddressBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AddressBook.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<ContactDetail> ContactDetail { get; set; }
        Task<int> SaveChangesAsync();
    }
}
