//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moq;
using OData.Neo.Core.Brokers.Queries;
using OData.Neo.Core.Services.Foundations.OQueries;
using Tynamix.ObjectFiller;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.OQueries
{
    public partial class OQueryServiceTests
    {
        private readonly Mock<ISqlQueryBroker> sqlQueryBrokerMock;
        private readonly IOQueryService oqueryService;

        public OQueryServiceTests()
        {
            this.sqlQueryBrokerMock =
                new Mock<ISqlQueryBroker>();

            this.oqueryService =
                new OQueryService(sqlQueryBrokerMock.Object);
        }

        public static TheoryData DependencyExceptions()
        {
            return new TheoryData<Exception>
            {
                new InvalidOperationException(),
                new InvalidCastException()
            };
        }

        private static string CreateRandomString() =>
            new MnemonicString().GetValue();

        private static (List<string>, string) GenerateRandomSqlQueryProperties()
        {
            int randomNumber = GetRandomNumber();
            string randomSqlVariable = CreateRandomString();
            List<string> properties = new List<string>();

            string[] sqlProperties = Enumerable.Range(start: 0, count: randomNumber)
                .Select(item =>
                {
                    string randomPropertyName =
                        CreateRandomString();

                    properties.Add(randomPropertyName);

                    return $"[{randomSqlVariable}].[{randomPropertyName}]";
                }).ToArray();

            string query =
                String.Join(separator: ", ", sqlProperties);

            return (properties, query);
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static Expression CreateMockedExpression() =>
            Mock.Of<Expression>();
    }
}
