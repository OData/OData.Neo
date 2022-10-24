//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using OData.Neo.Core.Brokers.Queries;

namespace OData.Neo.Core.Services.Foundations.OQueries
{
    public class OQueryService : IOQueryService
    {
        private readonly ISqlQueryBroker sqlQueryBroker;

        public OQueryService(ISqlQueryBroker sqlQueryBroker) =>
            this.sqlQueryBroker = sqlQueryBroker;

        public string GetOQuery(Expression expression)
        {
            throw new System.NotImplementedException();
        }
    }
}
