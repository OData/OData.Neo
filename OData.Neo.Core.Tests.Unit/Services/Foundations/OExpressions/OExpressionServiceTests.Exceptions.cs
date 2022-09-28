//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
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
        public async Task ShouldThrowDependencyExceptionOnGenerateIfDependencyErrorOcurrsAndLogitAsync(
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
    }
}
