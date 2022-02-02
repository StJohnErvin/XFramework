﻿using System.Threading.Tasks;
using IdentityServer.Domain.Generic.Contracts.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XFramework.Integration.Interfaces.Wrappers;

namespace XFramework.Api.Controllers.V1.Identity
{
    [Authorize]
    [Route("Api/Identity/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ContactsController : XFrameworkControllerBase
    {
        private readonly IIdentityServiceWrapper _identityServiceWrapper;

        public ContactsController(IIdentityServiceWrapper identityServiceWrapper)
        {
            _identityServiceWrapper = identityServiceWrapper;
        }
        [HttpPost("Validate")]
        public async Task<JsonResult> Validate([FromBody] CheckContactExistenceRequest request)
        {
            var result = await _identityServiceWrapper.CheckContactExistence(request);
            return new JsonResult(result);
        }
        
        [HttpPost("Create")]
        public async Task<JsonResult> Create([FromBody] CreateContactRequest request)
        {
            var result = await _identityServiceWrapper.CreateContact(request);
            return new JsonResult(result);
        }
        
        [HttpPost("Update")]
        public async Task<JsonResult> Update([FromBody] UpdateContactRequest request)
        {
            var result = await _identityServiceWrapper.UpdateContact(request);
            return new JsonResult(result);
        }

        [HttpPost("Delete")]
        public async Task<JsonResult> Delete([FromBody] DeleteContactRequest request)
        {
            var result = await _identityServiceWrapper.DeleteContact(request);
            return new JsonResult(result);
        }
        
    }
}