using AddressBook.Controllers;
using AddressBook.Service.Features.ContactFeatures.Commands;
using AddressBook.Service.Features.ContactFeatures.Queries;
using AddressBook.Tests.Common.Builders.Command;
using AddressBook.Tests.Common.Builders.Controller;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Reflection;

namespace AddressBook.Test.Unit.Controller
{
    [TestFixture]
    public class TestContactController
    {
        [Test]
        public void Mediator_GivenSetMediator_ShouldSetMediatorOnFirstCall()
        {
            //---------------Set up test pack-------------------
            var controller = new ContactController();
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
            var controller = new ContactController();
            var mediator = Substitute.For<IMediator>();
            var mediator1 = Substitute.For<IMediator>();
            controller.Mediator = mediator;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var ex = Assert.Throws<InvalidOperationException>(() => controller.Mediator = mediator1);
            //---------------Test Result -----------------------
            Assert.AreEqual("Mediator is already set", ex.Message);
        }

        [Test]
        public void Create_ShouldHaveHttpPostAttribute()
        {
            //---------------Set up test pack-------------------
            var methodInfo = typeof(ContactController)
                .GetMethod("Create", new[] { typeof(CreateContactCommand) });
            //---------------Assert Precondition----------------
            Assert.IsNotNull(methodInfo);
            //---------------Execute Test ----------------------
            var httpPostAttribute = methodInfo.GetCustomAttribute<HttpPostAttribute>();
            //---------------Test Result -----------------------
            Assert.NotNull(httpPostAttribute);
        }

        [Test]
        public void Create_ShouldReturnIActionResult()
        {
            //---------------Set up test pack-------------------
            var command = CreateContactCommandBuilder.BuildRandom();
            var controller = CreateContactControllerBuilder().Build();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = controller.Create(command);
            //---------------Test Result -----------------------            
            Assert.IsNotNull(result);
        }

        [Test]
        public void Create_ShouldCallCreateContactCommand()
        {
            //---------------Set up test pack-------------------
            var mediator = Substitute.For<IMediator>();
            var command = CreateContactCommandBuilder.BuildRandom();

            var controller = CreateContactControllerBuilder()
                .WithMediator(mediator)
                .Build();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            _ = controller.Create(command);
            //---------------Test Result -----------------------
            mediator.Received(1).Send(command);
        }

        [Test]
        public void GetAll_ShouldHaveHttpGetAttribute()
        {
            //---------------Set up test pack-------------------
            var methodInfo = typeof(ContactController)
                .GetMethod("GetAll");
            //---------------Assert Precondition----------------
            Assert.IsNotNull(methodInfo);
            //---------------Execute Test ----------------------
            var httpPostAttribute = methodInfo.GetCustomAttribute<HttpGetAttribute>();
            //---------------Test Result -----------------------
            Assert.NotNull(httpPostAttribute);
        }

        [Test]
        public void GetAll_ShouldReturnIActionResult()
        {
            //---------------Set up test pack-------------------            
            var controller = CreateContactControllerBuilder().Build();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = controller.GetAll();
            //---------------Test Result -----------------------            
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetById_ShouldHaveHttpGetAttribute()
        {
            //---------------Set up test pack-------------------
            var methodInfo = typeof(ContactController)
                .GetMethod("GetById", new[] { typeof(int) });
            //---------------Assert Precondition----------------
            Assert.IsNotNull(methodInfo);
            //---------------Execute Test ----------------------
            var httpPostAttribute = methodInfo.GetCustomAttribute<HttpGetAttribute>();
            //---------------Test Result -----------------------
            Assert.NotNull(httpPostAttribute);
        }

        [Test]
        public void GetById_ShouldReturnIActionResult()
        {
            //---------------Set up test pack-------------------            
            var controller = CreateContactControllerBuilder().Build();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = controller.GetById(1);
            //---------------Test Result -----------------------            
            Assert.IsNotNull(result);
        }

        [Test]
        public void Delete_ShouldHaveHttpDeleteAttribute()
        {
            //---------------Set up test pack-------------------
            var methodInfo = typeof(ContactController)
                .GetMethod("Delete", new[] { typeof(int) });
            //---------------Assert Precondition----------------
            Assert.IsNotNull(methodInfo);
            //---------------Execute Test ----------------------
            var httpPostAttribute = methodInfo.GetCustomAttribute<HttpDeleteAttribute>();
            //---------------Test Result -----------------------
            Assert.NotNull(httpPostAttribute);
        }

        [Test]
        public void Delete_ShouldReturnIActionResult()
        {
            //---------------Set up test pack-------------------            
            var controller = CreateContactControllerBuilder().Build();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = controller.Delete(1);
            //---------------Test Result -----------------------            
            Assert.IsNotNull(result);
        }

        [Test]
        public void Update_ShouldHaveHttpPutAttribute()
        {
            //---------------Set up test pack-------------------
            var methodInfo = typeof(ContactController)
                .GetMethod("Update", new[] { typeof(int), typeof(UpdateContactCommand) });
            //---------------Assert Precondition----------------
            Assert.IsNotNull(methodInfo);
            //---------------Execute Test ----------------------
            var httpPostAttribute = methodInfo.GetCustomAttribute<HttpPutAttribute>();
            //---------------Test Result -----------------------
            Assert.NotNull(httpPostAttribute);
        }

        [Test]
        public void Update_ShouldCallCreateContactCommand()
        {  
            //---------------Set up test pack-------------------
            var mediator = Substitute.For<IMediator>();
            var command = CreateContactCommandBuilder.BuildRandom();

            var controller = CreateContactControllerBuilder()
                .WithMediator(mediator)
                .Build();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            _ = controller.Create(command);
            //---------------Test Result -----------------------
            mediator.Received(1).Send(command);
        }

        private ContactControllerBuilder CreateContactControllerBuilder()
        {
            return new ContactControllerBuilder();
        }
    }
}
