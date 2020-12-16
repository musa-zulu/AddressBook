using AddressBook.Service.Features.ContactFeatures.Commands;
using AddressBook.Service.Features.ContactFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace AddressBook.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Contact")]
    [ApiVersion("1.0")]
    public class ContactController : ControllerBase
    {
        private IMediator _mediator;
        public IMediator Mediator
        {
            get { return _mediator ??= HttpContext.RequestServices.GetService<IMediator>(); }
            set
            {
                if (_mediator != null) throw new InvalidOperationException("Mediator is already set");
                _mediator = value;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
