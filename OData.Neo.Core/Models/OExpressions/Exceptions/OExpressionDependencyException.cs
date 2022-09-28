//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.OExpressions.Exceptions
{
    public class OExpressionDependencyException : Xeption
    {
        public OExpressionDependencyException(Xeption innerException)
            : base(message: "OExpression dependency error ocurred, contact support.",
                  innerException)
        { }
    }
}
