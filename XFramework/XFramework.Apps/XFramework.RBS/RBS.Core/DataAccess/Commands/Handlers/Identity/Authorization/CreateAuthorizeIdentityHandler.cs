using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RBS.Core.DataAccess.Commands.Entity.Identity.Authorization;
using RBS.Core.Interfaces;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RBS.Domain.BusinessObjects;
using RBS.Domain.DataTransferObjects;

namespace RBS.Core.DataAccess.Commands.Handlers.Identity.Authorization
{
    public class CreateAuthorizeIdentityHandler : CommandBaseHandler, IRequestHandler<CreateAuthorizeIdentityCmd, CmdResponseBO<CreateAuthorizeIdentityCmd>>
    {

        public CreateAuthorizeIdentityHandler(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }
        public async Task<CmdResponseBO<CreateAuthorizeIdentityCmd>> Handle(CreateAuthorizeIdentityCmd request, CancellationToken cancellationToken)
        {
            var identityInfo = await _dataLayer.TblIdentityInformations.FirstOrDefaultAsync(i => i.Uuid == request.Uid.ToString(), cancellationToken: cancellationToken);
            var entity = request.Adapt<TblIdentityCredential>();

            if (identityInfo == null)
            {
                return new CmdResponseBO<CreateAuthorizeIdentityCmd>
                {
                    Message = $"Identity with UID {request.Uid} does not exist",
                    HttpStatusCode = HttpStatusCode.NotFound
                };
            }

            SHA512 shaM = new SHA512Managed();
            var passwordByte = Encoding.ASCII.GetBytes(request.PasswordString);
            var hashPasswordByte = shaM.ComputeHash(passwordByte);

            entity.Cuid = Guid.NewGuid().ToString();
            entity.PasswordByte = hashPasswordByte;
            entity.IdentityInfoId = identityInfo.Id;
            entity.ApplicationId = request.RequestServer.ApplicationId;

            await _dataLayer.TblIdentityCredentials.AddAsync(entity, cancellationToken);
            await _dataLayer.SaveChangesAsync(cancellationToken);
            
            // Initialize wallets
            var walletEntities = await _dataLayer.TblWalletEntities.ToListAsync(cancellationToken: cancellationToken);
            foreach (var tblWalletEntity in walletEntities)
            {
                _dataLayer.TblUserWallets.Add(new()
                {
                    UserAuthId = entity.Id,
                    WalletTypeId = tblWalletEntity.Id,
                    Balance = 0m
                });
            }
            await _dataLayer.SaveChangesAsync(cancellationToken);
            return new();
        }
    }
}