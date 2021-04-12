﻿using MediatR;
using StreamFlow.Domain.BusinessObjects;
using XFramework.Domain.Generic.BusinessObjects;

namespace StreamFlow.Stream.Services.Entity.Events
{
    public class DequeueMessagesCmd : CommandBaseEntity, IRequest<CmdResponseBO<DequeueMessagesCmd>>
    {
        public StreamFlowClientBO Client { get; set; }
    }
}