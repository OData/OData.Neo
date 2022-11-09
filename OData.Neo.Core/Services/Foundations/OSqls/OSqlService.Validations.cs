//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using OData.Neo.Core.Brokers.Queries;
using OData.Neo.Core.Models.OSqls.Exceptions;

namespace OData.Neo.Core.Services.Foundations.OSqls
{
    public partial class OSqlService
    {
        private void ValidateExpression(Expression expression)
        {
            if (expression is null)
            {
                throw new NullExpressionOSqlException();
            }
        }
    }
}
