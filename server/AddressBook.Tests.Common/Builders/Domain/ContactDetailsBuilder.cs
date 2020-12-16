using AddressBook.Domain.Entities;
using PeanutButter.RandomGenerators;
using System;

namespace AddressBook.Tests.Common.Builders.Domain
{
    public class ContactDetailsBuilder : GenericBuilder<ContactDetailsBuilder, ContactDetail>
    {
        public ContactDetailsBuilder WithContactId(int id)
        {
            Random rd = new Random();
            return WithProp(x => x.ContactId = id);                
        }
    }
}
