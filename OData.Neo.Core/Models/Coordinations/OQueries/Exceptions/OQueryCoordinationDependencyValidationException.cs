//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.Coordinations.OQueries.Exceptions
{
    public class OQueryCoordinationDependencyValidationException : Xeption
    {
        public OQueryCoordinationDependencyValidationException(Xeption innerException)
            : base(message: "OQuery dependency validation error occurred, fix errors and try again",
                  innerException)
        { }
    }
}
