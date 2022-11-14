//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using Xeptions;

namespace OData.Neo.Core.Models.OSqls.Exceptions
{
    public class FailedOSqlDependencyException : Xeption
    {
        public FailedOSqlDependencyException(Exception innerException)
            : base(message: "Failed OSql dependency error ocurred, contact support.",
                  innerException)
        { }
    }
}
