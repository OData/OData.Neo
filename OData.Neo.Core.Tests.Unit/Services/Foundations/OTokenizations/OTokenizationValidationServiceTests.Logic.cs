using OData.Neo.Core.Models.OTokens.Exceptions;
using OData.Neo.Core.Models.OTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.OTokenizations
{
    public partial class OTokenizationValidationServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnTokenizeIfOTokensIsNull()
        {
            // given
            OToken[] invalidOTokens = null;

            var nullOTokensException =
                new NullOTokensException();

            var expectedOTokenValidationException =
                new OTokenValidationException(nullOTokensException);

            // when
            Action oTokenizeAction = () =>
                this.tokenizationValidationService.ValidateOTokens(invalidOTokens);

            OTokenValidationException actualOTokenValidationException =
                Assert.Throws<OTokenValidationException>(
                    oTokenizeAction);

            // then
            actualOTokenValidationException.Should().BeEquivalentTo(
                expectedOTokenValidationException);
        }

        [Fact]
        public void ShouldThrowValidationExceptionIfAnyOTokenIsNull()
        {
            // given
            OToken nullOToken = null;
            OToken[] randomOTokens = CreateRandomOTokens(nullOToken);
            OToken[] invalidProjectedTokens = randomOTokens;
            var nullProjectedTokenException = new NullOTokenException();

            var expectedProjectedTokenValidationException =
                new OTokenValidationException(
                    nullProjectedTokenException);

            // when
            Action tokenizeAction = () =>
                this.tokenizationValidationService.ValidateOTokens(
                    invalidProjectedTokens);

            OTokenValidationException actualProjectedTokenValidationException =
                Assert.Throws<OTokenValidationException>(
                    tokenizeAction);

            // then
            actualProjectedTokenValidationException.Should()
                .BeEquivalentTo(expectedProjectedTokenValidationException);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldThrowValidationExceptionIfAnyOTokenRawValuesIsInvalid(
            string invalidRawData)
        {
            // given
            OToken invalidOToken = new OToken
            {
                RawValue = invalidRawData
            };

            OToken[] randomOTokens =
                CreateRandomOTokens(invalidOToken);

            OToken[] invalidOTokens =
                randomOTokens;

            var invalidOTokenRawValueException =
                new InvalidOTokenRawValueException();

            var expectedOTokenValidationException =
                new OTokenValidationException(
                    invalidOTokenRawValueException);

            // when
            Action tokenizeAction = () =>
                this.tokenizationValidationService.ValidateOTokens(
                    invalidOTokens);

            OTokenValidationException actualOTokenValidationException =
                Assert.Throws<OTokenValidationException>(
                    tokenizeAction);

            // then
            actualOTokenValidationException.Should()
                .BeEquivalentTo(expectedOTokenValidationException);
        }
    }
}
