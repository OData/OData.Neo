//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using Xeptions;

namespace OData.Neo.Core.Models.ProjectedTokens.Exceptions
{
    public class FailedProjectedTokenServiceException : Xeption
    {
        public FailedProjectedTokenServiceException(Exception innerException)
            : base(message: "Failed projected token service error occurred, contact support.",
                  innerException)
        { }
    }
}
