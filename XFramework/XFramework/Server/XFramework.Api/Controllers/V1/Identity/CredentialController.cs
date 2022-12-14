using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace XFramework.Api.Controllers.V1.Identity
{
    /*[Authorize]*/
    [Route("Api/v{version:apiVersion}/Identity/[controller]")]
    [Route("Api/Identity/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CredentialController : XFrameworkControllerBase
    {
        private readonly IIdentityServiceWrapper _identityServiceWrapper;

        public CredentialController(IMediator mediator, IIdentityServiceWrapper identityServiceWrapper)
        {
            _identityServiceWrapper = identityServiceWrapper;
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<JsonResult> Get(Guid guid)
        {
            var result = await _identityServiceWrapper.GetCredential(new () { Guid = guid });
            return new JsonResult(result);
        }
        
        [HttpPost("List")]
        public async Task<JsonResult> GetList([FromBody] GetCredentialListRequest request)
        {
            var result = await _identityServiceWrapper.LegacyGetCredentialList(request);
            return new JsonResult(result);
        }
        
        [HttpPost("Validate")]
        public async Task<JsonResult> Validate([FromBody] CheckCredentialExistenceRequest request)
        {
            var result = await _identityServiceWrapper.CheckCredentialExistence(request);
            return new JsonResult(result);
        }
        
        [HttpPost("Create")]
        public async Task<JsonResult> Create([FromBody] CreateCredentialRequest request)
        {
            var result = await _identityServiceWrapper.CreateCredential(request);
            return new JsonResult(result);
        }
        
        [HttpPost("Update")]
        public async Task<JsonResult> Update([FromBody] UpdateCredentialRequest request)
        {
            var result = await _identityServiceWrapper.UpdateCredential(request);
            return new JsonResult(result);
        }

        [HttpPost("Delete")]
        public async Task<JsonResult> Delete([FromBody] DeleteCredentialRequest request)
        {
            var result = await _identityServiceWrapper.DeleteCredential(request);
            return new JsonResult(result);
        }
        
        [HttpPost("ChangePassword")]
        public async Task<JsonResult> ForgotPassword([FromBody] UpdatePasswordRequest request)
        {
            var result = await _identityServiceWrapper.ChangePassword(request);
            return new JsonResult(result);
        }
    }
}