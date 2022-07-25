//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using FluentAssertions;
using OData.Neo.Core.Models.Tokens.Exceptions;
using Xunit;


namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Tokenizations
{
    public partial class TokenizationServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnTokenizeIfQueryIsNull()
        {
            // given
            string nullQuery = null;

            var nullOTokenException =
                new NullOTokenQueryException();

            var expectedOtokenValidationException =
                new TokenValidationException(nullOTokenException);

            // when
            Action toknizeAction = () =>
                this.tokenizationService.Tokenize(nullQuery);

            TokenValidationException actualOTokenValidationException =
                Assert.Throws<TokenValidationException>(toknizeAction);

            // then
            actualOTokenValidationException.Should().BeEquivalentTo(
                expectedOtokenValidationException);
        }
    }
}