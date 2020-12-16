using AddressBook.Domain.Entities;
using AddressBook.Persistence;
using AddressBook.Service.Implementation;
using AddressBook.Tests.Common.Builders.Domain;
using AddressBook.Tests.Common.Helpers;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Test.Unit.Service
{
    [TestFixture]
    public class TestContactService
    {
        private FakeContactDbContext _db;
        [SetUp]
        public void SetUp()
        {
            _db = new FakeContactDbContext(Guid.NewGuid().ToString());
        }

        [Test]
        public void Contruct()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new ContactService(Substitute.For<IApplicationDbContext>()));
            //---------------Test Result -----------------------
        }

        [Test]
        public void Construct_GivenApplicationDbContextIsNull_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var ex = Assert.Throws<ArgumentNullException>(() => new ContactService(null));
            //---------------Test Result -----------------------
            Assert.AreEqual("context", ex.ParamName);
        }

        [Test]
        public async Task GetAllAsync_GivenNoContactExist_ShouldReturnEmptyList()
        {
            //---------------Set up test pack-------------------            
            var contactService = new ContactService(_db.DbContext);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var results = await contactService.GetAllAsync();
            //---------------Test Result -----------------------
            Assert.IsEmpty(results);
            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public async Task GetAllAsync_GivenOneContactExist_ShouldReturnListWithThatContact()
        {
            //---------------Set up test pack-------------------
            var contact = CreateRandomContact();
            await _db.Add(contact);

            var contactService = new ContactService(_db.DbContext);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var results = await contactService.GetAllAsync();
            //---------------Test Result -----------------------
            Assert.IsNotNull(results);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(contact.FirstName, results[0].FirstName);
            Assert.AreEqual(contact.Surname, results[0].Surname);
        }

        [Test]
        public async Task GetAllAsync_GivenTwoContactExist_ShouldReturnAListWithTwoContact()
        {
            //---------------Set up test pack-------------------
            var contact = CreateRandomContact();
            var contact2 = CreateRandomContact();

            await _db.Add(contact, contact2);

            var contactService = new ContactService(_db.DbContext);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var results = await contactService.GetAllAsync();
            //---------------Test Result -----------------------
            Assert.IsNotNull(results);
            Assert.AreEqual(2, results.Count);
        }

        [Test]
        public async Task AddAsync_GivenAContact_ShouldAddContactToRepo()
        {
            //---------------Set up test pack-------------------
            var contact = CreateRandomContact();
            var contactService = new ContactService(_db.DbContext);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var results = await contactService.AddAsync(contact);
            //---------------Test Result -----------------------
            var contactFromRepo = await contactService.GetByIdAsync(contact.ContactId);
            Assert.IsTrue(results);
            Assert.AreEqual(contactFromRepo.ContactId, contact.ContactId);
            Assert.AreEqual(contactFromRepo.FirstName, contact.FirstName);
            Assert.AreEqual(contactFromRepo.ContactDetails.Count, contact.ContactDetails.Count);
        }
      
        [Test]
        public async Task AddAsync_GivenAContactWithContactDetail_ShouldAddContactDetail()
        {
            //---------------Set up test pack-------------------
            var contact = CreateRandomContact();
            var contactService = new ContactService(_db.DbContext);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var results = await contactService.AddAsync(contact);
            //---------------Test Result -----------------------
            var contactFromRepo = await contactService.GetByIdAsync(contact.ContactId);
            Assert.IsTrue(results);
            Assert.AreEqual(contactFromRepo.ContactDetails[0].ContactId, contact.ContactDetails[0].ContactId);
            Assert.AreEqual(contactFromRepo.ContactDetails[0].ContactTypeId, contact.ContactDetails[0].ContactTypeId);
            Assert.AreEqual(contactFromRepo.ContactDetails[0].ContactDetailId, contact.ContactDetails[0].ContactDetailId);
            Assert.AreEqual(contactFromRepo.ContactDetails[0].Description, contact.ContactDetails[0].Description);
        }

        [Test]
        public async Task AddAsync_GivenValidContact_ShouldCallSaveChanges()
        {
            //---------------Set up test pack-------------------
            var contact = ContactBuilder.BuildRandom();
            var dbContext = Substitute.For<IApplicationDbContext>();
            var contactService = new ContactService(dbContext);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            _ = await contactService.AddAsync(contact);
            //---------------Test Result -----------------------            
            await dbContext.Received(1).SaveChangesAsync();
        }
      
        [Test]
        public async Task AddContactDetailsAsync_GivenAContactDetail_ShouldAddContactDetailToRepo()
        {
            //---------------Set up test pack-------------------
            var contact = CreateRandomContact();

            var contactService = new ContactService(_db.DbContext);
            await _db.Add(contact);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var results = await contactService.AddContactDetailsAsync(contact.ContactDetails[0], contact.ContactId);
            //---------------Test Result -----------------------
            var contactFromRepo = await contactService.GetByIdAsync(contact.ContactId);
            Assert.IsTrue(results);
            Assert.AreEqual(contactFromRepo.ContactDetails[0].ContactId, contact.ContactId);
            Assert.AreEqual(contactFromRepo.ContactDetails[0].Description, contact.ContactDetails[0].Description);
            Assert.AreEqual(contactFromRepo.ContactDetails[0].ContactTypeId, contact.ContactDetails[0].ContactTypeId);
        }

        [Test]
        public async Task GetByIdAsync_GivenNoContactExist_ShouldReturnNull()
        {
            //---------------Set up test pack-------------------            
            var contactService = new ContactService(_db.DbContext);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var results = await contactService.GetByIdAsync(1);
            //---------------Test Result -----------------------
            Assert.IsNull(results);
        }

        [Test]
        public async Task GetByIdAsync_GivenContactExistInRepo_ShouldReturnThatContact()
        {
            //---------------Set up test pack-------------------
            var contact = CreateRandomContact();
            var contactService = new ContactService(_db.DbContext);
            await _db.Add(contact);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var results = await contactService.GetByIdAsync(contact.ContactId);
            //---------------Test Result -----------------------         
            Assert.AreEqual(results.ContactId, contact.ContactId);
            Assert.AreEqual(results.BirthDate, contact.BirthDate);
            Assert.AreEqual(results.FirstName, contact.FirstName);
            Assert.AreEqual(results.Surname, contact.Surname);
            Assert.AreEqual(results.ContactDetails[0].ContactId, contact.ContactId);
            Assert.AreEqual(results.ContactDetails[0].Description, contact.ContactDetails[0].Description);
            Assert.AreEqual(results.ContactDetails[0].ContactTypeId, contact.ContactDetails[0].ContactTypeId);
        }
        
        private static Contact CreateRandomContact()
        {
            var contact = ContactBuilder.BuildRandom();
            var contactDetailsBuilder = new List<ContactDetail> {
                new ContactDetailsBuilder()
                .WithContactId(contact.ContactId)
                .WithRandomProps()
                .Build()
            };
            contact.ContactDetails = contactDetailsBuilder;

            return contact;
        }
    }
}