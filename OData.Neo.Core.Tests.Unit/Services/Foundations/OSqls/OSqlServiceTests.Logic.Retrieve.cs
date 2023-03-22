//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.OSqls
{
    public partial class OSqlServiceTests
    {
        [Fact]
        public void ShouldRetrieveSqlQueryFromExpression()
        {
            // given
            Expression randomExpression = CreateMockedExpression();
            Expression inputExpression = randomExpression;
            string generatedSqlQuery = CreateRandomSqlQuery();
            string expectedSqlQuery = generatedSqlQuery;

            this.sqlQueryBrokerMock.Setup(broker =>
                broker.GetSqlQuery(inputExpression))
                    .Returns(generatedSqlQuery);

            // when
            string actualSqlQuery =
                this.oSqlService.RetrieveOSqlQuery(
                    inputExpression);

            // then
            actualSqlQuery.Should().BeEquivalentTo(expectedSqlQuery);

            this.sqlQueryBrokerMock.Verify(broker =>
                broker.GetSqlQuery(inputExpression),
                    Times.Once);

            this.sqlQueryBrokerMock.VerifyNoOtherCalls();
        }
    }
}
