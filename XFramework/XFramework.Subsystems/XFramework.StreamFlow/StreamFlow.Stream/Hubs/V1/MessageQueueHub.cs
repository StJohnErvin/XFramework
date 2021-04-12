﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using StreamFlow.Core.Interfaces;
using StreamFlow.Domain.BusinessObjects;
using StreamFlow.Stream.Services.Entity.Events;
using XFramework.Domain.Generic.BusinessObjects;
using XFramework.Domain.Generic.Enums;

namespace StreamFlow.Stream.Hubs.V1
{
    public class MessageQueueHub : HubBase
    {
        public MessageQueueHub(IMediator mediator, ICachingService cachingService)
        {
            _cachingService = cachingService;
            _mediator = mediator;
        }
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"New Connection Detected with ID {Context.ConnectionId}");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var client = _cachingService.Clients.FirstOrDefault(i => i.StreamId == Context.ConnectionId);
            _cachingService.Clients.Remove(client);
            await base.OnDisconnectedAsync(exception);
            Console.WriteLine($"Connection Lost and Unregistered with ID {Context.ConnectionId} : {client?.Guid} : {client?.Name}");
        }

        public async Task<HttpStatusCode> Push(StreamFlowMessageBO request)
        {
            var entity = new PushMessageCmd()
            {
                Context = Context,
                MessageQueue = request
            };
            var response = await _mediator.Send(entity).ConfigureAwait(false);
            return response.HttpStatusCode;
        }
        public async Task<HttpStatusCode> Subscribe(StreamFlowClientBO request)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, request.Queue.Guid.ToString());
            return HttpStatusCode.Accepted;
        }
        public async Task<HttpStatusCode> Register(StreamFlowClientBO request)
        {
            var entity = new RegisterClientCmd()
            {
                Context = Context,
                Client = request
            };
            var response = await _mediator.Send(entity).ConfigureAwait(false);
            _mediator.Send(new DequeueMessagesCmd(){Client = request, Context = Context}).ConfigureAwait(false);
            
            return response.HttpStatusCode;
        }
        public async Task<HttpStatusCode> Unsubscribe(StreamFlowClientBO request)
        {
            await Groups.RemoveFromGroupAsync(request.StreamId, request.Queue.Guid.ToString());
            return HttpStatusCode.Accepted;
        }
    }
}