//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using Xeptions;

namespace OData.Neo.Core.Models.OQueries.Exceptions
{
    public class FailedOQueryDependencyException : Xeption
    {
        public FailedOQueryDependencyException(Exception innerException)
            : base(message: "Failed oquery dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
