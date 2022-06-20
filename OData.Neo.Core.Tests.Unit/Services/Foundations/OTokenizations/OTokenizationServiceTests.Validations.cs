//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using FluentAssertions;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Models.OTokens.Exceptions;
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
    }
}
