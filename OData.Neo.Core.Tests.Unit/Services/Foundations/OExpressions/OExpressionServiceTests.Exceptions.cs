//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.OExpressions.Exceptions;
using OData.Neo.Core.Models.OTokens;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.OExpressions
{
    public partial class OExpressionServiceTests
    {
        [Theory]
        [MemberData(nameof(DependencyExceptions))]
        public async Task ShouldThrowDependencyExceptionOnGenerateIfDependencyErrorOccursAsync(
            Exception dependencyException)
        {
            // given
            OExpression someOExpression = CreateRandomOExpression();
            someOExpression.OToken.Children = new List<OToken>();

            var failedOExpressionException =
                new FailedOExpressionDependencyException(
                    dependencyException);

            var expectedOExpressionDependencyException =
                new OExpressionDependencyException(
                    failedOExpressionException);

            this.expressionBrokerMock.Setup(broker =>
                broker.GenerateExpressionAsync<object>(It.IsAny<string>()))
                    .ThrowsAsync(dependencyException);

            // when
            ValueTask<OExpression> generateOExpressionTask =
                this.oExpressionService.GenerateOExpressionAsync<object>(
                    someOExpression);

            OExpressionDependencyException actualOExpressionDependencyException =
                await Assert.ThrowsAsync<OExpressionDependencyException>(
                    generateOExpressionTask.AsTask);

            // then
            actualOExpressionDependencyException.Should().BeEquivalentTo(
                expectedOExpressionDependencyException);

            this.expressionBrokerMock.Verify(broker =>
                broker.GenerateExpressionAsync<object>(It.IsAny<string>()),
                    Times.Once);

            this.expressionBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnGenerateIfServiceErrorOccursAsync()
        {
            // given
            OExpression someOExpression = CreateRandomOExpression();
            someOExpression.OToken.Children = new List<OToken>();

            var serviceException = new Exception();

            var failedOExpressionServiceException =
                new FailedOExpressionServiceException(
                    serviceException);

            var expectedOExpressionServiceException =
                new OExpressionServiceException(
                    failedOExpressionServiceException);

            this.expressionBrokerMock.Setup(broker =>
                broker.GenerateExpressionAsync<object>(It.IsAny<string>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<OExpression> generateOExpressionTask =
                this.oExpressionService.GenerateOExpressionAsync<object>(
                    someOExpression);

            OExpressionServiceException actualOExpressionServiceException =
                await Assert.ThrowsAsync<OExpressionServiceException>(
                    generateOExpressionTask.AsTask);

            // then
            actualOExpressionServiceException.Should().BeEquivalentTo(
                expectedOExpressionServiceException);

            this.expressionBrokerMock.Verify(broker =>
                broker.GenerateExpressionAsync<object>(It.IsAny<string>()),
                    Times.Once);

            this.expressionBrokerMock.VerifyNoOtherCalls();
        }


        [Theory]
        [MemberData(nameof(ApplyDependencyExceptions))]
        public void ShouldThrowDependencyExceptionOnApplyIfDependencyErrorOccurs(
            Exception dependencyException)
        {
            // given
            IQueryable<object> someSource = CreateRandomSource();
            ConstantExpression someExpression = Expression.Constant(value: default);
            var someOExpression = new OExpression();
            someOExpression.Expression = someExpression;

            var failedOExpressionException =
                new FailedOExpressionDependencyException(
                    dependencyException);

            var expectedOExpressionDependencyException =
                new OExpressionDependencyException(
                    failedOExpressionException);

            this.expressionBrokerMock.Setup(broker =>
                broker.ApplyExpression(
                    It.IsAny<IQueryable<object>>(),
                    It.IsAny<Expression>()))
                        .Throws(dependencyException);

            // when
            Action applyExpressionAction = () =>
                this.oExpressionService.ApplyExpression(
                    someSource,
                    someOExpression);

            OExpressionDependencyException actualOExpressionDependencyException =
                Assert.Throws<OExpressionDependencyException>(
                    applyExpressionAction);

            // then
            actualOExpressionDependencyException.Should().BeEquivalentTo(
                expectedOExpressionDependencyException);

            this.expressionBrokerMock.Verify(broker =>
                broker.ApplyExpression(
                    It.IsAny<IQueryable<object>>(),
                    It.IsAny<Expression>()),
                        Times.Once);

            this.expressionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
