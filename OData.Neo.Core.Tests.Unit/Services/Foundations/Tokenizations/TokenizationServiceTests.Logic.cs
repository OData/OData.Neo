//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using FluentAssertions;
using OData.Neo.Core.Models;
using Xunit;


namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Tokenizations
{
    public partial class TokenizationServiceTests
    {
        [Theory]
        [MemberData(nameof(BasicTokens))]
        public void ShouldTokenizeQuery(OToken possibleToken)
        {
            // given
            string rawQuery = possibleToken.Value;

            var expectedTokens = new OToken[]
            {
                possibleToken
            };

            // when
            OToken[] actualTokens =
                this.tokenizationService.Tokenize(rawQuery);

            // then
            actualTokens.Should().BeEquivalentTo(expectedTokens);
        }
    }
}