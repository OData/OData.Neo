//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.OExpressions.Exceptions
{
    public class NullOExpressionException : Xeption
    {
        public NullOExpressionException()
            : base(message: "OExpression is null")
        {
        }
    }
}
