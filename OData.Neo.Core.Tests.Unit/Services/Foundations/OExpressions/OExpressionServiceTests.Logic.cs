//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Models.ProjectedTokens;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.OExpressions
{
    public partial class OExpressionServiceTests
    {
        [Fact]
        public async Task ShouldGenerateOExpressionAsync()
        {
            // given
            (List<OToken> randomPropertyOTokens, string allRawValues) =
                CreateRandomPropertyOTokens();

            (List<OToken> randomNonPropertyOTokens, _) =
                CreateRandomNonPropertyOTokens();

            var inputOExpression = new OExpression
            {
                OToken = new OToken
                {
                    Type = OTokenType.Root,

                    Children = new List<OToken>
                    {
                        new OToken
                        {
                            RawValue = "$select",
                            Type = OTokenType.Select,
                            ProjectedType = ProjectedTokenType.Keyword,

                            Children =
                                randomPropertyOTokens.Concat(randomNonPropertyOTokens)
                                    .ToList()
                        }
                    }
                }
            };

            string expectedLinqQuery = $"Select(obj => new {{{allRawValues}}})";
            Expression generatedExpression = Expression.Constant(value: default);

            var expectedOExpression = new OExpression
            {
                Expression = generatedExpression,
                OToken = inputOExpression.OToken
            };

            this.expressionBrokerMock.Setup(broker =>
                broker.GenerateExpressionAsync<object>(expectedLinqQuery))
                    .ReturnsAsync(generatedExpression);

            // when
            OExpression actualOExpression =
                await this.oExpressionService.GenerateOExpressionAsync<object>(
                    inputOExpression);

            // then
            actualOExpression.Should().BeEquivalentTo(expectedOExpression);

            this.expressionBrokerMock.Verify(broker =>
                broker.GenerateExpressionAsync<object>(expectedLinqQuery),
                    Times.Once);

            this.expressionBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldApplyExpressionToSource()
        {
            // given
            var randomSource = CreateRandomSource();
            var randomExpression = Expression.Constant(value: default);
            IQueryable<object> inputSource = CreateRandomSource();
            Expression inputExpression = randomExpression;
            IQueryable randomSourceAfterExpression = CreateRandomSource();
            IQueryable expectedSource = randomSourceAfterExpression;
            var inputOExpression = new OExpression();
            inputOExpression.Expression = inputExpression;

            this.expressionBrokerMock.Setup(broker =>
                broker.ApplyExpression(inputSource, inputExpression))
                    .Returns(expectedSource);

            // when
            IQueryable actualSource =
                this.oExpressionService.ApplyExpression(
                    inputSource,
                    inputOExpression);

            // then
            actualSource.Should().BeEquivalentTo(expectedSource);

            this.expressionBrokerMock.Verify(broker =>
                broker.ApplyExpression(inputSource, inputExpression),
                    Times.Once);

            this.expressionBrokerMock.VerifyNoOtherCalls();
        }
    }
}