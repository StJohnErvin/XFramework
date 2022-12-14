using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RBS.Core.DataAccess.Commands.Entity.Identity.Authorization;
using RBS.Core.Interfaces;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using RBS.Domain.BusinessObjects;

namespace RBS.Core.DataAccess.Commands.Handlers.Identity.Authorization
{
    public class UpdateAuthorizeIdentityHandler : CommandBaseHandler, IRequestHandler<UpdateAuthorizeIdentityCmd, CmdResponseBO<UpdateAuthorizeIdentityCmd>>
    {
        public UpdateAuthorizeIdentityHandler(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }
        public async Task<CmdResponseBO<UpdateAuthorizeIdentityCmd>> Handle(UpdateAuthorizeIdentityCmd request, CancellationToken cancellationToken)
        {
            var entity = await _dataLayer.TblIdentityCredentials.FirstOrDefaultAsync(i => i.IdentityInfo.Uuid == request.Uid.ToString() & i.UserName == request.Username, cancellationToken);

            if (entity == null)
            {
                return new CmdResponseBO<UpdateAuthorizeIdentityCmd>
                {
                    Message = $"Identity with data [UID: {request.Uid}, Username: {request.Username}] does not exist",
                    HttpStatusCode = HttpStatusCode.NotFound
                };
            }

            entity = request.Adapt(entity);
            _dataLayer.Update(entity);
            await _dataLayer.SaveChangesAsync(cancellationToken);

            return new();
        }
    }
}