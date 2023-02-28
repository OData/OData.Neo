//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using Xeptions;

namespace OData.Neo.Core.Models.Orchestrations.Coordinates.Exceptions
{
    public class FailedOQueryCoordinateServiceException : Xeption
    {
        public FailedOQueryCoordinateServiceException(Exception innerException)
            : base(message: "Failed oquery coordinate service error occurred, contact support.",
                  innerException)
        { }
    }
}
