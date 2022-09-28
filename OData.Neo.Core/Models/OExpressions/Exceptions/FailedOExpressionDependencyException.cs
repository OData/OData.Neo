//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using Xeptions;

namespace OData.Neo.Core.Models.OExpressions.Exceptions
{
    public class FailedOExpressionDependencyException : Xeption
    {
        public FailedOExpressionDependencyException(Exception innerException)
            : base(message: "Failed OExpression dependency error ocurred, contact support.",
                  innerException)
        { }
    }
}
