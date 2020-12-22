using System;
using System.Collections.Generic;
using System.Text;

namespace XFramework.Domain.Enums
{
    [Flags]
    public enum EmailType : int
    {
        EmailConfirmation = 0,
        AccountRegistration = 1,
        PackagePurchaseConfirmation = 2
    }
}