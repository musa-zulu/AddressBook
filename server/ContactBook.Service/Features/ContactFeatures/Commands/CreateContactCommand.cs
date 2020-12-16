using AddressBook.Domain.Dtos;
using AddressBook.Domain.Entities;
using AddressBook.Service.Contract;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Service.Features.ContactFeatures.Commands
{
    public class CreateContactCommand : IRequest<bool>
    {
       public ContactDto ContactDto { get; set; }

        public class CreateCustomerCommandHandler : IRequestHandler<CreateContactCommand, bool>
        {
            private readonly IContactService _contactService;
            private readonly IMapper _mapper;
            public CreateCustomerCommandHandler(IContactService contactService, IMapper mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
            }
            public async Task<bool> Handle(CreateContactCommand request, CancellationToken cancellationToken)
            {
                var contact = _mapper.Map<Contact>(request.ContactDto);
                var contactSaved = false;
                if (contact != null) 
                {
                    contactSaved = await _contactService.AddAsync(contact);
                }
                return contactSaved;
            }
        }
    }
}