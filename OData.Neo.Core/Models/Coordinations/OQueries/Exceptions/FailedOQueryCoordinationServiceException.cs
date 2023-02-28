//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using Xeptions;

namespace OData.Neo.Core.Models.Coordinations.OQueries.Exceptions
{
    public class FailedOQueryCoordinationServiceException : Xeption
    {
        public FailedOQueryCoordinationServiceException(Exception innerException)
            : base(message: "Failed oquery service error occurred, contact support.",
                  innerException)
        { }
    }
}
