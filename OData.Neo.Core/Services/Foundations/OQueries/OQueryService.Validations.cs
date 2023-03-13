//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using OData.Neo.Core.Models.OQueries.Exceptions;

namespace OData.Neo.Core.Services.Foundations.OQueries
{
    public partial class OQueryService : IOQueryService
    {
        private static void ValidateExpression(Expression expression)
        {
            if (expression is null)
            {
                throw new NullOQueryExpressionException();
            }
        }
    }
}
