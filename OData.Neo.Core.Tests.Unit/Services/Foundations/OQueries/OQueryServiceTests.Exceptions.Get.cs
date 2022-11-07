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
        [Theory]
        [MemberData(nameof(DependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnGetIfDependencyErrorOccurs(
            Exception dependencyException)
        {
            // given
            Expression someExpression = CreateMockedExpression();

            var failedOQueryDependencyException =
                new FailedOQueryDependencyException(
                    dependencyException);

            var expectedOQueryDependencyException =
                new OQueryDependencyException(
                    failedOQueryDependencyException);

            this.sqlQueryBrokerMock.Setup(broker =>
                broker.GetSqlQuery(It.IsAny<Expression>()))
                    .Throws(dependencyException);

            // when
            Action getOQueryAction = () =>
                this.oqueryService.GetOQuery(
                    someExpression);

            OQueryDependencyException actualOQueryDependencyException =
                Assert.Throws<OQueryDependencyException>(
                    getOQueryAction);

            // then
            actualOQueryDependencyException.Should().BeEquivalentTo(
                expectedOQueryDependencyException);

            this.sqlQueryBrokerMock.Verify(broker =>
                broker.GetSqlQuery(It.IsAny<Expression>()),
                    Times.Once);

            this.sqlQueryBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowServiceExceptionOnGetIfServiceErrorOccurs()
        {
            // given
            Expression someExpression = CreateMockedExpression();
            var serviceException = new Exception();

            var failedOQueryServiceException =
                new FailedOQueryServiceException(
                    serviceException);

            var expectedOQueryServiceException =
                new OQueryServiceException(
                    failedOQueryServiceException);

            this.sqlQueryBrokerMock.Setup(broker =>
                broker.GetSqlQuery(It.IsAny<Expression>()))
                    .Throws(serviceException);

            // when
            Action getOQueryAction = () =>
                this.oqueryService.GetOQuery(
                    someExpression);

            OQueryServiceException actualOQueryServiceException =
                Assert.Throws<OQueryServiceException>(
                    getOQueryAction);

            // then
            actualOQueryServiceException.Should().BeEquivalentTo(
                expectedOQueryServiceException);

            this.sqlQueryBrokerMock.Verify(broker =>
                broker.GetSqlQuery(It.IsAny<Expression>()),
                    Times.Once);

            this.sqlQueryBrokerMock.VerifyNoOtherCalls();
        }
    }
}
