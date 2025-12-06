using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [ApiController]
    public abstract class BaseApiController: ControllerBase
    {
        protected readonly ISender _sender;
        protected BaseApiController(ISender mediator)
        {
            _sender = mediator;
        }
    }
}
