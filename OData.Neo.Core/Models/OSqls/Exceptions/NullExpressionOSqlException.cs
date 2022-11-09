//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.OSqls.Exceptions
{
    public class NullExpressionOSqlException : Xeption
    {
        public NullExpressionOSqlException()
            : base(message: "Null expression OSQL error ocurred, fix the erros and try again.")
        { }
    }
}
