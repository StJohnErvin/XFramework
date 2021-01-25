﻿using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer.Core.DataAccess.Commands.Entity.Identity.Authorization;
using IdentityServer.Core.Interfaces;
using IdentityServer.Domain.BusinessObjects;
using IdentityServer.Domain.DataTableObjects;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Core.DataAccess.Commands.Handlers.Identity.Authorization
{
    public class CreateAuthorizeIdentityHandler : CommandBaseHandler, IRequestHandler<CreateAuthorizeIdentityCmd, CmdResponseBO<CreateAuthorizeIdentityCmd>>
    {

        public CreateAuthorizeIdentityHandler(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }
        public async Task<CmdResponseBO<CreateAuthorizeIdentityCmd>> Handle(CreateAuthorizeIdentityCmd request, CancellationToken cancellationToken)
        {
            var identityInfo = await _dataLayer.TblIdentityInfos.FirstOrDefaultAsync(i => i.Uid == request.Uid.ToString(), cancellationToken: cancellationToken);
            var entity = request.Adapt<TblIdentityCredential>();
            
            SHA512 shaM = new SHA512Managed();
            var passwordByte = Encoding.ASCII.GetBytes(request.PasswordString);
            var hashPasswordByte = shaM.ComputeHash(passwordByte);

            entity.PasswordByte = hashPasswordByte;
            entity.IdentityInfoId = identityInfo.Id;
            entity.ApplicationId = request.RequestServer.ApplicationId;
            
            await _dataLayer.TblIdentityCredentials.AddAsync(entity, cancellationToken);
            await _dataLayer.SaveChangesAsync(cancellationToken);

            return new();
        }
    }
}