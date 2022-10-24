//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.OQueries
{
    public partial class OQueryServiceTests
    {
        [Fact]
        public void ShouldGetOQueryFromExpression()
        {
            // given
            Expression randomExpression =
                CreateMockedExpression();

            string randomSqlVariable =
                GetRandomString();

            string randomPropertyName =
                GetRandomString();
            
            string randomTableName =
                GetRandomString();

            string returnedSqlQuery =
                $"SELECT [{randomSqlVariable}].[{randomPropertyName}]" +
                $"FROM [{randomTableName}]";

            string expectedOQuery =
                $"$select={randomPropertyName}";

            this.sqlQueryBrokerMock.Setup(broker =>
                broker.GetSqlQuery(randomExpression))
                    .Returns(returnedSqlQuery);

            // when
            string actualOQuery =
                this.oqueryService.GetOQuery(
                    randomExpression);

            // then
            actualOQuery.Should().BeEquivalentTo(
                expectedOQuery);

            this.sqlQueryBrokerMock.Verify(broker =>
                broker.GetSqlQuery(randomExpression),
                    Times.Once);

            this.sqlQueryBrokerMock.VerifyNoOtherCalls();
        }
    }
}
