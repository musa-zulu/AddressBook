using AddressBook.Domain.Entities;
using NUnit.Framework;
using PeanutButter.TestUtils.Generic;
using System;

namespace AddressBook.Test.Unit.Domain
{
    [TestFixture]
    public class TestContactDetail
    {
        [Test]
        public void Construct()
        {
            //---------------Set up test pack-------------------

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            Assert.DoesNotThrow(() => new ContactDetail());
            //---------------Test Result -----------------------
        }

        [TestCase("ContactDetailId", typeof(int))]
        [TestCase("Description", typeof(string))]
        [TestCase("ContactTypeId", typeof(ContactType))]
        [TestCase("ContactId", typeof(int))]
        public void ContactDetail_ShouldHaveProperty(string propertyName, Type propertyType)
        {
            //---------------Set up test pack-------------------
            var sut = typeof(ContactDetail);

            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            sut.ShouldHaveProperty(propertyName, propertyType);

            //---------------Test Result -----------------------
        }
    }
}
