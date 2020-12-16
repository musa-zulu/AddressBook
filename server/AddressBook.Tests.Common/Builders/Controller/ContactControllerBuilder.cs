using AddressBook.Controllers;
using MediatR;
using NSubstitute;

namespace AddressBook.Tests.Common.Builders.Controller
{
    public class ContactControllerBuilder
    {
        public ContactControllerBuilder()
        {
            Mediator = Substitute.For<IMediator>();
        }

        public IMediator Mediator { get; private set; }

        public ContactControllerBuilder WithMediator(IMediator mediator)
        {
            Mediator = mediator;
            return this;
        }

        public ContactController Build()
        {
            return new ContactController
            {
                Mediator = Mediator
            };
        }
    }
}
