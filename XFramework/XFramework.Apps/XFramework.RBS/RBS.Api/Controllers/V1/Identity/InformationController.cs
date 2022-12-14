using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using RBS.Core.DataAccess.Commands.Entity.Identity;
using RBS.Core.DataAccess.Query.Entity.Identity;

namespace RBS.Api.Controllers.V1.Identity
{
    [Route("Api/V1/Identity/[controller]")]
    [ApiController]
    public class InformationController : XFrameworkControllerBase
    {
        public InformationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("All")]
        public async Task<JsonResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllIdentityQuery());
            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<JsonResult> Get(Guid guid)
        {
            var result = await _mediator.Send(new GetIdentityQuery() { Uid = guid });
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody] CreateIdentityCmd request)
        {
            var result = await _mediator.Send(request).ConfigureAwait(false);
            return new JsonResult(result);
        }

        [HttpPut]
        public async Task<JsonResult> Put([FromBody] UpdateIdentityCmd request, Guid uid)
        {
            request.Uuid = uid;
            var result = await _mediator.Send(request).ConfigureAwait(false);
            return new JsonResult(result);
        }

        [HttpDelete]
        public async Task<JsonResult> Delete(Guid uid)
        {
            var request = new DeleteIdentityCmd()
            {
                Uid = uid
            };
            var result = await _mediator.Send(request).ConfigureAwait(false);
            return new JsonResult(result);
        }
    }
}