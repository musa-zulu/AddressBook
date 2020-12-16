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
    public class UpdateContactCommand : IRequest<bool>
    {
        public ContactDto ContactDto { get; set; }

        public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, bool>
        {
            private readonly IContactService _contactService;
            private readonly IMapper _mapper;
            public UpdateContactCommandHandler(IContactService contactService, IMapper mapper)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
            }
            public async Task<bool> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
            {
                var contact = _mapper.Map<Contact>(request.ContactDto);
                var contactUpdated = false;
                if (contact != null)
                {
                    contactUpdated = await _contactService.UpdateAsync(contact);
                }
                return contactUpdated;
            }
        }
    }
}