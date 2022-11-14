//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using OData.Neo.Core.Models.OQueries.Exceptions;
using OData.Neo.Core.Models.OSqls.Exceptions;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.OSqls
{
    public partial class OSqlServiceTests
    {
        [Theory]
        [MemberData(nameof(DependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnRetrieveIfDependencyErrorOccurs(
            Exception dependencyException)
        {
            // given
            Expression someExpression = CreateMockedExpression();

            var failedOSqlDependencyException =
                new FailedOSqlDependencyException(
                    dependencyException);

            var expectedOSqlDependencyException =
                new OSqlDependencyException(
                    failedOSqlDependencyException);

            this.sqlQueryBrokerMock.Setup(broker =>
                broker.GetSqlQuery(It.IsAny<Expression>()))
                    .Throws(dependencyException);

            // when
            Action getOSqlAction = () =>
                this.oSqlService.RetrieveOSqlQuery(
                    someExpression);

            OSqlDependencyException actualOSqlDependencyException =
                Assert.Throws<OSqlDependencyException>(
                    getOSqlAction);

            // then
            actualOSqlDependencyException.Should().BeEquivalentTo(
                expectedOSqlDependencyException);

            this.sqlQueryBrokerMock.Verify(broker =>
                broker.GetSqlQuery(It.IsAny<Expression>()),
                    Times.Once);

            this.sqlQueryBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowServiceExceptionOnReterieveIfServiceErrorOccurs()
        {
            // given
            Expression someExpression = CreateMockedExpression();
            var serviceException = new Exception();

            var failedOSqlServiceException =
                new FailedOSqlServiceException(
                    serviceException);

            var expectedOSqlServiceException =
                new OSqlServiceException(
                    failedOSqlServiceException);

            this.sqlQueryBrokerMock.Setup(broker =>
                broker.GetSqlQuery(It.IsAny<Expression>()))
                    .Throws(serviceException);

            // when
            Action getOSqlAction = () =>
                this.oSqlService.RetrieveOSqlQuery(
                    someExpression);

            OSqlServiceException actualOSqlServiceException =
                Assert.Throws<OSqlServiceException>(
                    getOSqlAction);

            // then
            actualOSqlServiceException.Should().BeEquivalentTo(
                expectedOSqlServiceException);

            this.sqlQueryBrokerMock.Verify(broker =>
                broker.GetSqlQuery(It.IsAny<Expression>()),
                    Times.Once);

            this.sqlQueryBrokerMock.VerifyNoOtherCalls();
        }
    }
}