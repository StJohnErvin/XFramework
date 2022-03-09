﻿namespace XFramework.Client.Shared.Core.Features.Application;

public partial class ApplicationState : State<ApplicationState>
{
    public override void Initialize()
    {
    }

    public bool IsBusy { get; set; }
    public string ProgressTitle { get; set; }
    public string ProgressMessage { get; set; }
       
}