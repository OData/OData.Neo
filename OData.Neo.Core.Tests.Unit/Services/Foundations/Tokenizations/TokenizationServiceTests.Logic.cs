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
        [Fact]
        public void ShouldTokenizeQuery()
        {
            // given
            string query = "$filter=Name eq 'Sam\\'s   ";

            var expectedTokens = new OToken[]
            {
                new OToken(OTokenType.Word, "$filter"),
                new OToken(OTokenType.Separator, "="),
                new OToken(OTokenType.Word, "Name"),
                new OToken(OTokenType.Separator, " "),
                new OToken(OTokenType.Word,"eq"),
                new OToken(OTokenType.Separator," "),
                new OToken(OTokenType.Separator, "'"),
                new OToken(OTokenType.Word, "Sam"),
                new OToken(OTokenType.Separator, "\\"),
                new OToken(OTokenType.Separator, "'"),
                new OToken(OTokenType.Word, "s"),
                new OToken(OTokenType.Separator, " "),
                new OToken(OTokenType.Separator, " "),
                new OToken(OTokenType.Separator, " ")
            };

            // when
            OToken[] actualTokens =
                this.tokenizationService.Tokenize(query);

            // then
            actualTokens.Should().BeEquivalentTo(expectedTokens);
        }

        [Fact]
        public void ShouldTokenizeRandomQuery()
        {
            // given
            (string queryToTest, OToken[] expectedTokens) = GetRandomQuery();

            // when
            OToken[] actualTokens =
                this.tokenizationService.Tokenize(queryToTest);

            // then
            actualTokens.Should().BeEquivalentTo(expectedTokens);
        }
    }
}