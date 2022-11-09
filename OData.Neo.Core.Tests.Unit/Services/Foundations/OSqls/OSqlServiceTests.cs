//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using Moq;
using OData.Neo.Core.Brokers.Queries;
using OData.Neo.Core.Services.Foundations.OSqls;
using Tynamix.ObjectFiller;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.OSqls
{
    public partial class OSqlServiceTests
    {
        private readonly Mock<ISqlQueryBroker> sqlQueryBrokerMock;
        private readonly IOSqlService oSqlService;

        public OSqlServiceTests()
        {
            this.sqlQueryBrokerMock =
                new Mock<ISqlQueryBroker>();

            this.oSqlService = new OSqlService(
                this.sqlQueryBrokerMock.Object);
        }

        public static TheoryData DependencyExceptions()
        {
            return new TheoryData<Exception>
            {
                new InvalidOperationException(),
                new InvalidCastException()
            };
        }

        private static string GetRandomSqlQuery() =>
            new MnemonicString().GetValue();

        private static Expression CreateMockedExpression() =>
           Mock.Of<Expression>();
    }
}
