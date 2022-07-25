//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.Orchestrations.OToknizations.Exceptions
{
    public class OTokenizationOrchestrationServiceException : Xeption
    {
        public OTokenizationOrchestrationServiceException(Xeption innerException)
            : base(message: "OTokenization service error ocurred, contact support.",
                  innerException)
        { }
    }
}
