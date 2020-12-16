using AddressBook.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AddressBook.Domain.Dtos
{
    public class ContactDto
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<ContactDetail> ContactDetails { get; set; }
    }
}