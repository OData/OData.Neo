//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.Orchestrations.OToknizations.Exceptions
{
    public class OTokenizationOrchestrationValidationException : Xeption
    {
        public OTokenizationOrchestrationValidationException(Xeption innerException)
            : base(message: "OTokenization validation error occured, please fix the errors and try again.",
                  innerException)
        { }
    }
}
