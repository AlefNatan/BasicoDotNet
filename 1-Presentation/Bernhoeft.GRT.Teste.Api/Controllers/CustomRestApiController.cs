using Bernhoeft.GRT.Core.Interfaces.MediatR;
using Bernhoeft.GRT.Core.Rest.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bernhoeft.GRT.Teste.Api.Controllers
{
    [Authorize]
    [ApiController]
    [RestResult]
    public class CustomRestApiController : ControllerBase
    {
        public IConfiguration Configuration => HttpContext.RequestServices.GetService<IConfiguration>();

        public IMediator Mediator => HttpContext.RequestServices.GetService<IMediator>();

        public ICustomPublisher Publisher => HttpContext.RequestServices.GetService<ICustomPublisher>();
    }
}