//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.OExpressions.Exceptions
{
    public class OExpressionValidationException : Xeption
    {
        public OExpressionValidationException(Xeption innerException)
            : base(message: "OExpression validation error occurred, fix the errros and try again.",
                  innerException)
        { }
    }
}
