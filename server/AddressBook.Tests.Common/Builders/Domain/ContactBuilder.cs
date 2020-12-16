using AddressBook.Domain.Entities;
using PeanutButter.RandomGenerators;
using System;

namespace AddressBook.Tests.Common.Builders.Domain
{
    public class ContactBuilder : GenericBuilder<ContactBuilder, Contact>
    {
        public ContactBuilder WithRandomId()
        {
            Random rd = new Random();
            return WithProp(x => x.ContactId = rd.Next(100, 200));
        }
    }
}
