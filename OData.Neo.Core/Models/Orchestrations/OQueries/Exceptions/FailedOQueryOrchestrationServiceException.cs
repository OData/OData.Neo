//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using Xeptions;

namespace OData.Neo.Core.Models.Orchestrations.OQueries.Exceptions
{
    public class FailedOQueryOrchestrationServiceException : Xeption
    {
        public FailedOQueryOrchestrationServiceException(Exception innerException)
            : base(message: "Failed oquery service error occurred, contact support.",
                  innerException)
        { }
    }
}
