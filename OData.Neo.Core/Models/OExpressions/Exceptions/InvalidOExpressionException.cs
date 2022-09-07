//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.OExpressions.Exceptions
{
    public class InvalidOExpressionException : Xeption
    {
        public InvalidOExpressionException()
            : base(message: "Invalid OExpression error occurred, fix the erros and try again.")
        { }
    }
}
