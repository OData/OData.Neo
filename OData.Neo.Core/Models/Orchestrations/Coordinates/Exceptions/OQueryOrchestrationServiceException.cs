//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.Orchestrations.Coordinates.Exceptions
{
    public class OQueryCoordinateServiceException : Xeption
    {
        public OQueryCoordinateServiceException(Xeption innerException)
            : base(message: "OQuery coordinate service error occurred, contact support.",
                  innerException)
        { }
    }
}
