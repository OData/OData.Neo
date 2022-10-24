//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using Moq;
using OData.Neo.Core.Brokers.Queries;
using OData.Neo.Core.Services.Foundations.OQueries;
using Tynamix.ObjectFiller;

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

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static Expression CreateMockedExpression() =>
            Mock.Of<Expression>();
    }
}
