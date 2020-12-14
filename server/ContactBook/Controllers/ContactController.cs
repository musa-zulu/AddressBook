using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace AddressBook.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Contact")]
    [ApiVersion("1.0")]
    public class ContactController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        
    }
}
