//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.Orchestrations.OQueries.Exceptions
{
    public class OQueryOrchestrationDependencyException : Xeption
    {
        public OQueryOrchestrationDependencyException(Xeption innerException)
            : base(message: "OQuery dependency error occured, please fix the errors and try again.",
                  innerException)
        { }
    }
}
