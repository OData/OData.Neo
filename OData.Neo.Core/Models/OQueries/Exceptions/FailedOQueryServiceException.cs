//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using Xeptions;

namespace OData.Neo.Core.Models.OQueries.Exceptions
{
    public class FailedOQueryServiceException : Xeption
    {
        public FailedOQueryServiceException(Exception innerException)
            : base(message: "Failed OQuery service error occurred, contact support.",
                  innerException)
        { }
    }
}
