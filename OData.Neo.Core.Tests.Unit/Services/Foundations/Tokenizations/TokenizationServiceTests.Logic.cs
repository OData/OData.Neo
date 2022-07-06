//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using FluentAssertions;
using OData.Neo.Core.Models.Tokens;
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
                new Token(TokenType.Word, "$filter"),
                new Token(TokenType.Separator, "="),
                new Token(TokenType.Word, "Name"),
                new Token(TokenType.Separator, " "),
                new Token(TokenType.Word,"eq"),
                new Token(TokenType.Separator," "),
                new Token(TokenType.Separator, "'"),
                new Token(TokenType.Word, "Sam"),
                new Token(TokenType.Separator, "\\"),
                new Token(TokenType.Separator, "'"),
                new Token(TokenType.Word, "s"),
                new Token(TokenType.Separator, " "),
                new Token(TokenType.Separator, " "),
                new Token(TokenType.Separator, " ")
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