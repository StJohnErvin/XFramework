﻿using IdentityServer.Domain.Generic.Contracts.Responses;
using XFramework.Client.Shared.Entity.Models.Requests.Session;

namespace XFramework.Client.Shared.Core.Features.Session;

public partial class SessionState : State<SessionState>
{
    public override void Initialize()
    {
         NavigationHistoryList = new();
         LoginVm = new();
         RegisterVm = new();
         ForgotPasswordVm = new();
         SmsVerificationVm = new();
    }
    public Domain.Generic.Enums.SessionState State { get; set; }
    public List<ContactResponse> ContactList { get; set; }
    public CredentialResponse Credential { get; set; }
    public IdentityResponse Identity { get; set; }
    public SignInRequest LoginVm { get; set; }
    public SignUpRequest RegisterVm { get; set; }
    public ForgotPasswordRequest ForgotPasswordVm { get; set; }
    public SmsVerificationRequest SmsVerificationVm { get; set; }
    public List<string> NavigationHistoryList { get; set; }

}