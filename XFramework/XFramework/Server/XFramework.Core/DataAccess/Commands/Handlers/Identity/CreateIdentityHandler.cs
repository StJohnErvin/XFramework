﻿using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer.Domain.Generic.Contracts.Requests;
using Mapster;
using MediatR;
using XFramework.Core.DataAccess.Commands.Entity.Identity;
using XFramework.Domain.Generic.BusinessObjects;
using XFramework.Domain.Generic.Enums;
using XFramework.Integration.Interfaces.Wrappers;

namespace XFramework.Core.DataAccess.Commands.Handlers.Identity
{
    public class CreateIdentityHandler : CommandBaseHandler, IRequestHandler<CreateIdentityCmd, CmdResponseBO<CreateIdentityCmd>>
    {
        public CreateIdentityHandler(IIdentityServiceWrapper identityServiceWrapper)
        {
            IdentityServiceWrapper = identityServiceWrapper;
        }

        public async Task<CmdResponseBO<CreateIdentityCmd>> Handle(CreateIdentityCmd request, CancellationToken cancellationToken)
        {
                 
            var uuid = Guid.NewGuid();
            var cuid = Guid.NewGuid();
            var req = request.Adapt<CreateIdentityRequest>();
            req.Uuid = uuid;
            
            var phoneContact = new CreateContactRequest()
            {
                RequestServer = request.RequestServer,
                ContactType = GenericContactType.Phone,
                Cuid = cuid,
                Value = request.PhoneNumber
            };

            var emailContact = new CreateContactRequest()
            {
                RequestServer = request.RequestServer,
                ContactType = GenericContactType.Email,
                Cuid = cuid,
                Value = request.Email
            };
            
            
            var checkIdentityExistence = await IdentityServiceWrapper.CheckIdentityExistence(request.Adapt<CheckIdentityExistenceRequest>());
            if (checkIdentityExistence.HttpStatusCode == HttpStatusCode.Conflict)
            {
                return new()
                {
                    HttpStatusCode = HttpStatusCode.Conflict,
                    Message = checkIdentityExistence.Message
                };
            }
            
            var checkCredentialExistence = await IdentityServiceWrapper.CheckCredentialExistence(request.Adapt<CheckCredentialExistenceRequest>());
            if (checkCredentialExistence.HttpStatusCode == HttpStatusCode.Conflict)
            {
                return new()
                {
                    HttpStatusCode = HttpStatusCode.Conflict,
                    Message = checkCredentialExistence.Message
                };
            }

            var checkPhoneContactExistence = await IdentityServiceWrapper.CheckContactExistence(phoneContact.Adapt<CheckContactExistenceRequest>());
            if (checkPhoneContactExistence.HttpStatusCode == HttpStatusCode.Conflict)
            {
                return new()
                {
                    HttpStatusCode = HttpStatusCode.Conflict,
                    Message = checkPhoneContactExistence.Message
                };
            }
            
            var checkEmailContactExistence = await IdentityServiceWrapper.CheckContactExistence(emailContact.Adapt<CheckContactExistenceRequest>());
            if (checkEmailContactExistence.HttpStatusCode == HttpStatusCode.Conflict)
            {
                return new()
                {
                    HttpStatusCode = HttpStatusCode.Conflict,
                    Message = checkEmailContactExistence.Message
                };
            }

            var response = await IdentityServiceWrapper.CreateIdentity(req);
            if (response.HttpStatusCode != HttpStatusCode.Accepted)
            {
                return response.Adapt<CmdResponseBO<CreateIdentityCmd>>();
            }

            var req2 = request.Adapt<CreateCredentialRequest>();
            req2.Uid = uuid;
            req2.Cuid = cuid;
            
            var response2 = await IdentityServiceWrapper.CreateCredential(req2);
            if (response2.HttpStatusCode != HttpStatusCode.Accepted)
            {
                return response2.Adapt<CmdResponseBO<CreateIdentityCmd>>();
            }

            var response3 = await IdentityServiceWrapper.CreateContact(phoneContact);
            if (response3.HttpStatusCode != HttpStatusCode.Accepted)
            {
                return response3.Adapt<CmdResponseBO<CreateIdentityCmd>>();
            }
            
            var response4 = await IdentityServiceWrapper.CreateContact(emailContact);
            if (response3.HttpStatusCode != HttpStatusCode.Accepted)
            {
                return response4.Adapt<CmdResponseBO<CreateIdentityCmd>>();
            }
            
            return new()
            {
                HttpStatusCode = HttpStatusCode.Accepted
            };
        }
    }
}