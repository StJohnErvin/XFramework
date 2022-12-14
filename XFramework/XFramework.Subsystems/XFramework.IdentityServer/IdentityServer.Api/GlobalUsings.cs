global using System;
global using System.Net;
global using System.Threading;
global using System.Threading.Tasks;
global using IdentityServer.Core.DataAccess.Commands.Entity.Identity;
global using IdentityServer.Core.Interfaces;
global using IdentityServer.Domain.DataTransferObjects;
global using Mapster;
global using MediatR;
global using XFramework.Domain.Generic.BusinessObjects;
global using Microsoft.EntityFrameworkCore;
global using System.Text;
global using IdentityServer.Core.DataAccess.Commands.Entity.Identity.Credential;
global using XFramework.Domain.Generic.Enums;
global using XFramework.Integration.Services.Helpers;
global using Microsoft.AspNetCore.SignalR.Client;
global using IdentityServer.Core.DataAccess.Query.Entity.Roles;
global using IdentityServer.Domain.Generic.Contracts.Requests;
global using IdentityServer.Domain.Generic.Contracts.Requests.Get;
global using IdentityServer.Core.DataAccess.Query.Entity.Identity.Roles;
global using IdentityServer.Core.DataAccess.Query.Entity.Identity.Credentials;
global using IdentityServer.Domain.Generic.Contracts.Requests.Check;
global using IdentityServer.Domain.Generic.Contracts.Responses;
global using XFramework.Domain.Generic.Contracts.Responses;
global using XFramework.Integration.Drivers;