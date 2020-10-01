﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XFramework.Data.Enums
{
    [Flags]
    public enum SeverityLevel
    {
        None = 0,
        Info = 1,
        Warning = 2,
        Error = 3,
        FatalError = 4,
        SecurityWarning = 5
    }
}
