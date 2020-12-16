using AddressBook.Domain.Entities;
using AddressBook.Service.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Service.Features.ContactFeatures.Queries
{
    public class GetContactByIdQuery : IRequest<Contact>
    {
        public int ContactId { get; set; }
        public class GetFinderByIdQueryHandler : IRequestHandler<GetContactByIdQuery, Contact>
        {
            private readonly IContactService _contactService;
            public GetFinderByIdQueryHandler(IContactService contactService)
            {
                _contactService = contactService;
            }
            public async Task<Contact> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
            {
                var person = _contactService.GetByIdAsync(request.ContactId);
                if (person == null) return null;
                return await person;
            }
        }
    }
}
