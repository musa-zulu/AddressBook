using AddressBook.Domain.Entities;
using AddressBook.Service.Contract;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Service.Features.ContactFeatures.Queries
{
    public class GetAllContactQuery : IRequest<IEnumerable<Contact>>
    {
        public class GetAllContactQueryHandler : IRequestHandler<GetAllContactQuery, IEnumerable<Contact>>
        {
            private readonly IContactService _contactService;
            public GetAllContactQueryHandler(IContactService contactService)
            {
                _contactService = contactService;
            }
            public async Task<IEnumerable<Contact>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
            {
                var contacts = await _contactService.GetAllAsync();
                if (contacts == null)
                {
                    return null;
                }
                return contacts.AsReadOnly();
            }
        }
    }
}

