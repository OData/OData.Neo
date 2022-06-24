//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using FluentAssertions;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Models.OTokens.Exceptions;
using OData.Neo.Core.Models.ProjectedTokens;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.OTokenizations
{
    public partial class OTokenizationServiceTests
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
                this.tokenizationService.OTokenize(invalidOTokens);

            OTokenValidationException actualOTokenValidationException =
                Assert.Throws<OTokenValidationException>(
                    oTokenizeAction);

            // then
            actualOTokenValidationException.Should().BeEquivalentTo(
                expectedOTokenValidationException);
        }

        [Fact]
        public void ShouldThrowValidationExceptionIfAnyProjectedTokenIsNull()
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
                this.tokenizationService.OTokenize(
                    invalidProjectedTokens);

            OTokenValidationException actualProjectedTokenValidationException =
                Assert.Throws<OTokenValidationException>(
                    tokenizeAction);

            // then
            actualProjectedTokenValidationException.Should()
                .BeEquivalentTo(expectedProjectedTokenValidationException);
        }
    }
}
