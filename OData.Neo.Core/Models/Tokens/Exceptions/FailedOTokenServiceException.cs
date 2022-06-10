//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using Xeptions;

namespace OData.Neo.Core.Models.Tokens.Exceptions
{
    public class FailedOTokenServiceException : Xeption
    {
        public FailedOTokenServiceException(Exception innerException)
            : base(message: "Failed otoken service error occurred, contact support.",
                  innerException)
        {}
    }
}
