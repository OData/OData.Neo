﻿//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using Xeptions;

namespace OData.Neo.Core.Models.Orchestrations.OToknizations.Exceptions
{
    public class FailedTokenizationOrchestrationServiceException : Xeption
    {
        public FailedTokenizationOrchestrationServiceException(Exception innerException)
            : base(message: "Failed tokenization service error occurred, contact support.",
                  innerException)
        { }
    }
}
