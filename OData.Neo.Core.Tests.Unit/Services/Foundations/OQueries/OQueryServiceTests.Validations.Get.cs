//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using OData.Neo.Core.Models.OQueries.Exceptions;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.OQueries
{
    public partial class OQueryServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnGetIfExpressionIsNull()
        {
            // given
            Expression nullExpression = null;

            var nullOQueryExpressionException =
                new NullOQueryExpressionException();

            var expectedOQueryValidationException =
                new OQueryValidationException(
                    nullOQueryExpressionException);

            // when
            Action getOQueryAction = () =>
                this.oqueryService.GetOQuery(
                    nullExpression);

            OQueryValidationException actualOQueryValidationException =
                Assert.Throws<OQueryValidationException>(
                    getOQueryAction);

            // then
            actualOQueryValidationException.Should().BeEquivalentTo(
                expectedOQueryValidationException);

            this.sqlQueryBrokerMock.Verify(broker =>
                broker.GetSqlQuery(It.IsAny<Expression>()),
                    Times.Never);

            this.sqlQueryBrokerMock.VerifyNoOtherCalls();
        }
    }
}
