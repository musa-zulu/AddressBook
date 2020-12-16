using AddressBook.Service.Contract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Service.Features.ContactFeatures.Commands
{
    public class DeleteContactByIdCommand : IRequest<bool>
    {
        public int ContactId { get; set; }
        public class GetFinderByIdQueryHandler : IRequestHandler<DeleteContactByIdCommand, bool>
        {
            private readonly IContactService _contactService;
            public GetFinderByIdQueryHandler(IContactService contactService)
            {
                _contactService = contactService;
            }
            public async Task<bool> Handle(DeleteContactByIdCommand request, CancellationToken cancellationToken)
            {
                var results = await _contactService.DeleteAsync(request.ContactId);                
                return results;
            }
        }
    }
}
