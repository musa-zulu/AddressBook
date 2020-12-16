using AddressBook.Domain.Entities;
using AddressBook.Persistence;
using AddressBook.Service.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Service.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IApplicationDbContext _context;

        public ContactService(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AddAsync(Contact contact)
        {
            if (contact == null) throw new ArgumentNullException(nameof(contact));

            AddContactDetailsFor(contact?.ContactDetails);
            _context.Contacts.Add(contact);
            return await _context.SaveChangesAsync() > 0;
        }

        private void AddContactDetailsFor(List<ContactDetail> contactDetails)
        {
            if (contactDetails != null && contactDetails.Count > 0)
            {
                foreach (var contactDetail in contactDetails)
                {
                    int contactDetailId = GetLastContactDetailId() + 1;
                    var contactId = _context.Contacts.ToListAsync().Result.Count + 1;
                    contactDetail.ContactDetailId = contactDetailId;
                    contactDetail.ContactId = contactId;
                    _context.ContactDetail.Add(contactDetail);
                }
            }
        }

        private int GetLastContactDetailId()
        {
            return _context.ContactDetail.ToListAsync().Result.Count;
        }

        public async Task<bool> AddContactDetailsAsync(ContactDetail contactDetail, int contactId)
        {
            if (contactId <= 0) throw new ArgumentNullException(nameof(contactId));
            if (contactDetail == null) throw new ArgumentNullException(nameof(contactDetail));

            var contactDetailId = GetLastContactDetailId() + 1;
            contactDetail.ContactDetailId = contactDetailId;
            contactDetail.ContactId = contactId;
            await _context.ContactDetail.AddAsync(contactDetail);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _context.Contacts
                .Include(x => x.ContactDetails)
                .ToListAsync() ?? new List<Contact>();
        }

        public async Task<Contact> GetByIdAsync(int contactId)
        {
            return await _context.Contacts
                .Include(x => x.ContactDetails)
                .FirstOrDefaultAsync(x => x.ContactId == contactId);
        }

        public async Task<bool> UpdateAsync(Contact contact)
        {
            var existingContact = await GetByIdAsync(contact.ContactId);

            if (existingContact != null)
            {
                existingContact.BirthDate = contact.BirthDate;
                existingContact.FirstName = contact.FirstName;
                existingContact.Surname = contact.Surname;
                existingContact.UpdatedDate = DateTime.Now;

                if (contact?.ContactDetails != null && contact?.ContactDetails.Count > 0)
                {
                    foreach (var contactDetail in contact.ContactDetails)
                    {
                        var existingContactDetail = existingContact.ContactDetails
                            .FirstOrDefault(x => x.ContactId == contactDetail.ContactId &&
                            x.ContactDetailId == contactDetail.ContactDetailId);

                        if (existingContactDetail != null)
                        {
                            existingContactDetail.ContactTypeId = contactDetail.ContactTypeId;
                            existingContactDetail.Description = contactDetail.Description;
                        }
                    }
                }
                _context.Contacts.Update(existingContact);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int contactId)
        {
            var contact = await GetByIdAsync(contactId);
            if (contact == null) throw new ArgumentNullException(nameof(contact));

            DeleteContactDetailsFrom(contact);
            _context.Contacts.Remove(contact);
            return await _context.SaveChangesAsync() > 0;
        }

        private void DeleteContactDetailsFrom(Contact contact)
        {
            var contactDetails = contact?.ContactDetails;
            if (contactDetails != null && contactDetails.Count > 0)
            {
                foreach (var contactDetail in contactDetails)
                    _context.ContactDetail.Remove(contactDetail);
            }
        }
    }
}
