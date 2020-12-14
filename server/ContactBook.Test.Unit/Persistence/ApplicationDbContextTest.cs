using AddressBook.Domain.Entities;
using AddressBook.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace AddressBook.Test.Unit.Persistence
{
    public class ApplicationDbContextTest
    {
        [Test]
        public void CanInsertContactIntoDatabasee()
        {
            using var context = new ApplicationDbContext();
            var contact = new Contact();
            context.Contacts.Add(contact);
            Assert.AreEqual(EntityState.Added, context.Entry(contact).State);
        }
    }
}
