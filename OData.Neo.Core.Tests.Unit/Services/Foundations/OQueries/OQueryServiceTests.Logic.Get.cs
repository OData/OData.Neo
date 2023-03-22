//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Collections.Generic;
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
            Expression randomExpression = CreateMockedExpression();
            string randomTableName = CreateRandomString();

            (List<string> properites, string sqlProperties) =
                 GenerateRandomSqlQueryProperties();

            string returnedSqlQuery =
                $"SELECT {sqlProperties} " +
                $"FROM [{randomTableName}]";

            string expectedOQuery =
                $"$select={string.Join(",", properites)}";

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
