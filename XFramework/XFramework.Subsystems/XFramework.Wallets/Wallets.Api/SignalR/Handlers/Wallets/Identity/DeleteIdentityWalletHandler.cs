﻿using System;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.SignalR.Client;
using StreamFlow.Domain.Generic.BusinessObjects;
using Wallets.Core.DataAccess.Commands.Entity.Wallets.Identity;
using Wallets.Domain.Generic.Contracts.Requests;
using Wallets.Domain.Generic.Contracts.Requests.Wallet.Identity;
using XFramework.Domain.Generic.BusinessObjects;
using XFramework.Integration.Services.Helpers;

namespace Wallets.Api.SignalR.Handlers.Wallets.Identity
{
    public class DeleteIdentityWalletHandler : BaseSignalRHandler, ISignalREventHandler
    {
        public void Handle(HubConnection connection, IMediator mediator)
        {
            
            Console.WriteLine($"{GetType().Name} Initialized");
            connection.On<string, string, StreamFlowTelemetryBO>(GetType().Name.Replace("Handler", string.Empty),
                async (data, message, telemetry) =>
                {
                    StopWatch.Start();
                    try
                    {
                        var r = data.AsMediatorCmd<DeleteIdentityWalletRequest, DeleteIdentityWalletCmd>();
                        var result = await mediator.Send(r).ConfigureAwait(false);
                        StopWatch.Stop($"[{DateTime.Now}] Invoked '{GetType().Name}' returned {result.HttpStatusCode.ToString()}");

                        await RespondToInvoke(connection, telemetry, result.Adapt<CmdResponseBO>());
                    }
                    catch (Exception e)
                    {
                        StopWatch.Stop($"[{DateTime.Now}] Invoked '{GetType().Name}' resulted in exception: [{e.Message}]");
                    }

                });
        }
    }
}