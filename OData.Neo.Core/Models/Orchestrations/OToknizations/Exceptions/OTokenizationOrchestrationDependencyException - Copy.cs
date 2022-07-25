//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.Orchestrations.OToknizations.Exceptions
{
    public class OTokenizationOrchestrationDependencyException : Xeption
    {
        public OTokenizationOrchestrationDependencyException(Xeption innerException)
            : base(message: "OTokenization dependency error occured, please fix the errors and try again.",
                  innerException)
        { }
    }
}
