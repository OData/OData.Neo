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

            var expectedTokens = new Token[]
            {
                new Token(OTokenType.Word, "$filter"),
                new Token(OTokenType.Separator, "="),
                new Token(OTokenType.Word, "Name"),
                new Token(OTokenType.Separator, " "),
                new Token(OTokenType.Word,"eq"),
                new Token(OTokenType.Separator," "),
                new Token(OTokenType.Separator, "'"),
                new Token(OTokenType.Word, "Sam"),
                new Token(OTokenType.Separator, "\\"),
                new Token(OTokenType.Separator, "'"),
                new Token(OTokenType.Word, "s"),
                new Token(OTokenType.Separator, " "),
                new Token(OTokenType.Separator, " "),
                new Token(OTokenType.Separator, " ")
            };

            // when
            Token[] actualTokens =
                this.tokenizationService.Tokenize(query);

            // then
            actualTokens.Should().BeEquivalentTo(expectedTokens);
        }

        [Fact]
        public void ShouldTokenizeRandomQuery()
        {
            // given
            (string queryToTest, Token[] expectedTokens) = GetRandomQuery();

            // when
            Token[] actualTokens =
                this.tokenizationService.Tokenize(queryToTest);

            // then
            actualTokens.Should().BeEquivalentTo(expectedTokens);
        }
    }
}