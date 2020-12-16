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
            //---------------Set up test pack-------------------
            using var context = new ApplicationDbContext();
            var contact = new Contact();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            context.Contacts.Add(contact);
            //---------------Test Result -----------------------
            Assert.AreEqual(EntityState.Added, context.Entry(contact).State);
        }

        [Test]
        public void CanUpdateContactIntoDatabasee()
        {
            //---------------Set up test pack-------------------
            using var context = new ApplicationDbContext();
            var contact = new Contact
            {
                ContactId = 1
            };
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            context.Contacts.Update(contact);
            //---------------Test Result -----------------------
            Assert.AreEqual(EntityState.Modified, context.Entry(contact).State);
        }

        [Test]
        public void CanDeleteContactIntoDatabasee()
        {
            //---------------Set up test pack-------------------
            using var context = new ApplicationDbContext();
            var contact = new Contact
            {
                ContactId = 1
            };
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            context.Contacts.Remove(contact);
            //---------------Test Result -----------------------            
            Assert.AreEqual(EntityState.Deleted, context.Entry(contact).State);
        }
    }
}
