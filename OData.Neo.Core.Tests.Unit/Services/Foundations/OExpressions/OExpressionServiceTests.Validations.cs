//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.OExpressions.Exceptions;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.OExpressions
{
    public partial class OExpressionServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnGenerateIfOExpressionIsNullAsync()
        {
            // given
            OExpression nullOExpression = null;

            var nullOExpressionException =
                new NullOExpressionException();

            var expectedOExpressionValidationException =
                new OExpressionValidationException(
                    nullOExpressionException);

            // when
            ValueTask<OExpression> generateOExpressionTask =
                this.oExpressionService.GenerateOExpressionAsync<object>(
                    nullOExpression);

            OExpressionValidationException actualOExpressionValidationException =
                await Assert.ThrowsAsync<OExpressionValidationException>(
                    generateOExpressionTask.AsTask);

            // then
            actualOExpressionValidationException.Should().BeEquivalentTo(
                expectedOExpressionValidationException);

            this.expressionBrokerMock.Verify(broker =>
                broker.GenerateExpressionAsync<object>(It.IsAny<string>()),
                    Times.Never);

            this.expressionBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnGenerateIfOTokenIsNullAsync()
        {
            // given
            OExpression randomOExpression = CreateRandomOExpression();
            OExpression invalidOExpression = randomOExpression;
            invalidOExpression.OToken = null;

            var invalidOExpressionException =
                new InvalidOExpressionException();

            invalidOExpressionException.AddData(
                key: nameof(OExpression.OToken),
                values: "Value is required");

            var expectedOExpressionValidationException =
                new OExpressionValidationException(
                    invalidOExpressionException);

            // when
            ValueTask<OExpression> generateOExpressionTask =
                this.oExpressionService.GenerateOExpressionAsync<object>(
                    randomOExpression);

            OExpressionValidationException actualOExpressionValidationException =
                await Assert.ThrowsAsync<OExpressionValidationException>(
                    generateOExpressionTask.AsTask);

            // then
            actualOExpressionValidationException.Should().BeEquivalentTo(
                expectedOExpressionValidationException);

            this.expressionBrokerMock.Verify(broker =>
                broker.GenerateExpressionAsync<object>(It.IsAny<string>()),
                    Times.Never);

            this.expressionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
