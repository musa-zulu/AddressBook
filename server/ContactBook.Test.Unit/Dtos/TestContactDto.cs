using AddressBook.Domain.Dtos;
using AddressBook.Domain.Entities;
using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using System.Collections.Generic;

namespace AddressBook.Test.Unit.Dtos
{
    [TestFixture]
    public class TestContactDto
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new ContactDto());
            //---------------Test Result -----------------------
        }

        [TestCase("ContactId", typeof(int))]
        [TestCase("FirstName", typeof(string))]
        [TestCase("Surname", typeof(string))]
        [TestCase("BirthDate", typeof(DateTime))]
        [TestCase("UpdatedDate", typeof(DateTime))]
        [TestCase("ContactDetails", typeof(List<ContactDetail>))]
        public void ContactDto_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var sut = typeof(ContactDto);

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            sut.ShouldHaveProperty(propertyName, propertyType);

            //---------------Test Result -----------------------
        }
    }
}
