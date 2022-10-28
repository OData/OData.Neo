//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var sql = sqlQueryBroker.GetSqlQuery(expression);
            var parts = sql
                .Split("FROM")[0]
                .Split(' ');

            var result = new List<string>();

            foreach (var part in parts)
                result.Add(ConvertKeyword(part));

            return string.Join("", result);
        }

        static Dictionary<string, string> keywords = 
            new Dictionary<string, string>()
            {
                { "SELECT", "$select=" }
            };

        string ConvertKeyword(string keyword)
        {
            return keywords.ContainsKey(keyword)
                ? keywords[keyword]
                : CleanProperty(keyword);
        }

        string CleanProperty(string propertyReference)
        {
            return propertyReference
                .Split('.')
                .Last()
                .Trim("[]".ToCharArray())
                .Replace("]", "");
        }
    }
}
