//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.Orchestrations.OToknizations.Exceptions
{
    public class OTokenizationOrchestrationDependencyValidationException : Xeption
    {
        public OTokenizationOrchestrationDependencyValidationException(Xeption innerException)
            : base(message: "OTokenization dependency validation error occured, please fix the errors and try again.",
                  innerException)
        { }
    }
}
