using AddressBook.Domain.Entities;
using PeanutButter.RandomGenerators;

namespace AddressBook.Tests.Common.Builders.Domain
{
    public class ContactBuilder : GenericBuilder<ContactBuilder, Contact>
    {
        public ContactBuilder WithId(int id)
        {            
            return WithProp(x => x.ContactId = id);
        }
    }
}
