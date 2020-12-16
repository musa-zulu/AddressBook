using AddressBook.Domain.Entities;
using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;
using System.Collections.Generic;

namespace AddressBook.Test.Unit.Domain
{
    [TestFixture]
    public class TestContact
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new Contact());
            //---------------Test Result -----------------------
        }

        [TestCase("ContactId", typeof(int))]
        [TestCase("FirstName", typeof(string))]      
        [TestCase("Surname", typeof(string))]
        [TestCase("BirthDate", typeof(DateTime))]
        [TestCase("UpdatedDate", typeof(DateTime))]
        [TestCase("ContactDetails", typeof(List<ContactDetail>))]
        public void Contact_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var sut = typeof(Contact);

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            sut.ShouldHaveProperty(propertyName, propertyType);

            //---------------Test Result -----------------------
        }
    }
}
