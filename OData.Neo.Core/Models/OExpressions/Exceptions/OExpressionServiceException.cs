//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.OExpressions.Exceptions
{
    public class OExpressionServiceException : Xeption
    {
        public OExpressionServiceException(Xeption innerException)
            : base(message: "OExpression service error ocurred, contact support.",
                  innerException)
        { }
    }
}
