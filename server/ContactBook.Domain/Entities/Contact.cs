using System;
using System.Collections.Generic;

namespace AddressBook.Domain.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<ContactDetail> ContactDetails { get; set; }
    }
}
