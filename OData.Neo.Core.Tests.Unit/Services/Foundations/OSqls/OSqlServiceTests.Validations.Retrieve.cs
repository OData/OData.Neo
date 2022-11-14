//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using OData.Neo.Core.Models.OSqls.Exceptions;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.OSqls
{
    public partial class OSqlServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnRetrieveIfExpressionIsNull()
        {
            // given
            Expression nullExpression = null;

            var nullExpressionOSqlException =
                new NullExpressionOSqlException();

            var expectedOSqlValidationException =
                new OSqlValidationException(
                    nullExpressionOSqlException);

            // when
            Action retrieveSqlQueryAction = () =>
                this.oSqlService.RetrieveOSqlQuery(
                    nullExpression);

            OSqlValidationException actualOSqlValidationException =
                Assert.Throws<OSqlValidationException>(
                    retrieveSqlQueryAction);

            // then
            actualOSqlValidationException.Should().BeEquivalentTo(
                expectedOSqlValidationException);

            this.sqlQueryBrokerMock.Verify(broker =>
                broker.GetSqlQuery(It.IsAny<Expression>()),
                    Times.Never);

            this.sqlQueryBrokerMock.VerifyNoOtherCalls();
        }
    }
}
