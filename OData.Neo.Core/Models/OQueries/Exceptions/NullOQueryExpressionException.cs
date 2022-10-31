//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.OQueries.Exceptions
{
    public class NullOQueryExpressionException : Xeption
    {
        public NullOQueryExpressionException()
            : base(message: "Expression is null.")
        { }
    }
}
