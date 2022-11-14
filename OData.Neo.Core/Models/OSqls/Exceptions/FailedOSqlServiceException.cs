//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using Xeptions;

namespace OData.Neo.Core.Models.OSqls.Exceptions
{
    public class FailedOSqlServiceException : Xeption
    {
        public FailedOSqlServiceException(Exception innerException)
            : base(message: "Failed OSQL service error ocurred, contact support.",
                  innerException)
        { }
    }
}
