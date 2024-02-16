//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Linq;
using System.Linq.Expressions;
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
        public void ShouldThrowValidationExceptionOnApplyIfSourceIsNull()
        {
            // given
            OExpression someOExpression = CreateRandomOExpression();
            IQueryable<object> nullSource = null;

            var nullSourceOExpressionException =
                new NullSourceOExpressionException();

            var expectedOExpressionValidationException =
                new OExpressionValidationException(
                    nullSourceOExpressionException);

            // when
            Action applyExpressionAction = () =>
                this.oExpressionService.ApplyExpression(
                    nullSource,
                    someOExpression);

            OExpressionValidationException actualOExpressionValidationException =
                Assert.Throws<OExpressionValidationException>(
                    applyExpressionAction);

            // then
            actualOExpressionValidationException.Should().BeEquivalentTo(
                expectedOExpressionValidationException);

            this.expressionBrokerMock.Verify(broker =>
                broker.ApplyExpression<object>(
                    It.IsAny<IQueryable<object>>(),
                    It.IsAny<Expression>()),
                        Times.Never);

            this.expressionBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowValidationExceptionOnApplyIfOexpressionIsNull()
        {
            // given
            OExpression nullOExpression = null;
            IQueryable<object> someSource = CreateRandomSource();

            var nullOExpressionException =
                new NullOExpressionException();

            var expectedOExpressionValidationException =
                new OExpressionValidationException(
                    nullOExpressionException);

            // when
            Action applyExpressionAction = () =>
                this.oExpressionService.ApplyExpression(
                    someSource,
                    nullOExpression);

            OExpressionValidationException actualOExpressionValidationException =
                Assert.Throws<OExpressionValidationException>(
                    applyExpressionAction);

            // then
            actualOExpressionValidationException.Should().BeEquivalentTo(
                expectedOExpressionValidationException);

            this.expressionBrokerMock.Verify(broker =>
                broker.ApplyExpression<object>(
                    It.IsAny<IQueryable<object>>(),
                    It.IsAny<Expression>()),
                        Times.Never);

            this.expressionBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowValidationExceptionOnApplyIfExpressionIsNull()
        {
            // given
            OExpression randomOExpression = CreateRandomOExpression();
            IQueryable<object> someSource = CreateRandomSource();
            OExpression invalidOExpression = randomOExpression;
            invalidOExpression.Expression = null;

            var invalidOExpressionException =
                new InvalidOExpressionException();

            invalidOExpressionException.AddData(
                key: nameof(OExpression.Expression),
                values: "Value is required");

            var expectedOExpressionValidationException =
                new OExpressionValidationException(
                    invalidOExpressionException);

            // when
            Action applyExpressionAction = () =>
                this.oExpressionService.ApplyExpression(
                    someSource,
                    invalidOExpression);

            OExpressionValidationException actualOExpressionValidationException =
                Assert.Throws<OExpressionValidationException>(
                    applyExpressionAction);

            // then
            actualOExpressionValidationException.Should().BeEquivalentTo(
                expectedOExpressionValidationException);

            this.expressionBrokerMock.Verify(broker =>
                broker.ApplyExpression<object>(
                    It.IsAny<IQueryable<object>>(),
                    It.IsAny<Expression>()),
                        Times.Never);

            this.expressionBrokerMock.VerifyNoOtherCalls();
        }
    }
}
