using System;
using System.Collections.Generic;
using AddressBook.Domain.Entities;

namespace AddressBook.Infrastructure.ViewModel
{
    public class ContactModel
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<ContactDetail> ContactDetails { get; set; }
    }
}
