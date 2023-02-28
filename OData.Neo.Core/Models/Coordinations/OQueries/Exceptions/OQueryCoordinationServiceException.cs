//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.Coordinations.OQueries.Exceptions
{
    public class OQueryCoordinationServiceException : Xeption
    {
        public OQueryCoordinationServiceException(Xeption innerException)
            : base(message: "OQuery service error occurred, contact support.",
                  innerException)
        { }
    }
}
