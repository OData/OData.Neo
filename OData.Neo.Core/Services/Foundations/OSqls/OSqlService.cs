//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using OData.Neo.Core.Brokers.Queries;

namespace OData.Neo.Core.Services.Foundations.OSqls
{
    public class OSqlService : IOSqlService
    {
        private readonly ISqlQueryBroker sqlQueryBroker;

        public OSqlService(ISqlQueryBroker sqlQueryBroker) =>
            this.sqlQueryBroker = sqlQueryBroker;

        public string RetrieveOSqlQuery(Expression expression) =>
            this.sqlQueryBroker.GetSqlQuery(expression);
    }
}
