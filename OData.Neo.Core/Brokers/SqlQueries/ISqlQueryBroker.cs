//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq;
using System.Linq.Expressions;

namespace OData.Neo.Core.Brokers.Queries
{
    public interface ISqlQueryBroker
    {
        string GetSqlQuery(Expression expression);
        IQueryable ApplyExpression<T>(IQueryable<T> source, Expression expression);
    }
}
