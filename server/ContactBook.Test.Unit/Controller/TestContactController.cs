using AddressBook.Controllers;
using MediatR;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Test.Unit.Controller
{
    [TestFixture]
    public class TestContactController
    {
        [Test]
        public void Mediator_GivenSetMediator_ShouldSetMediatorOnFirstCall()
        {
            //---------------Set up test pack-------------------
            var controller = CreateContactController();
            var mediator = Substitute.For<IMediator>();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            controller.Mediator = mediator;
            //---------------Test Result -----------------------
            Assert.AreSame(mediator, controller.Mediator);
        }


        [Test]
        public void Mediator_GivenSetMediatorIsSet_ShouldThrowOnCall()
        {
            //---------------Set up test pack-------------------
            var controller = CreateContactController();
            var mediator = Substitute.For<IMediator>();
            var mediator1 = Substitute.For<IMediator>();
            controller.Mediator = mediator;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var ex = Assert.Throws<InvalidOperationException>(() => controller.Mediator = mediator1);
            //---------------Test Result -----------------------
            Assert.AreEqual("Mediator is already set", ex.Message);
        }

        private ContactController CreateContactController()
        {
            return new ContactController();
        }
    }
}
