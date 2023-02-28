//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.Coordinations.OQueries.Exceptions
{
    public class OQueryCoordinationDependencyException : Xeption
    {
        public OQueryCoordinationDependencyException(Xeption innerException)
            : base(message: "OQuery dependency error occured, please fix the errors and try again.",
                  innerException)
        { }
    }
}
