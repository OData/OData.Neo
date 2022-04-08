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
            string query = "$filter=Name eq 'Sam\'s   ";

            var expectedTokens = new OToken[]
            {
                new OToken
                {
                    Value = "$filter",
                    Type = OTokenType.Word
                },
                new OToken
                {
                    Value = "=",
                    Type = OTokenType.Separator
                },
                new OToken
                {
                    Value = "Name",
                    Type = OTokenType.Word
                },
                new OToken
                {
                    Value = " ",
                    Type = OTokenType.Separator
                },
                new OToken
                {
                    Value = "eq",
                    Type = OTokenType.Word
                },
                new OToken
                {
                    Value = " ",
                    Type = OTokenType.Separator
                },
                new OToken
                {
                    Value = "'",
                    Type = OTokenType.Separator
                },
                new OToken
                {
                    Value = "Sam",
                    Type = OTokenType.Word
                },
                new OToken
                {
                    Value = "\\",
                    Type = OTokenType.Separator
                },
                new OToken
                {
                    Value = "'",
                    Type = OTokenType.Separator
                },
                new OToken
                {
                    Value = "s",
                    Type = OTokenType.Word
                },
                new OToken
                {
                    Value = " ",
                    Type = OTokenType.Separator
                },
                new OToken
                {
                    Value = " ",
                    Type = OTokenType.Separator
                },
                new OToken
                {
                    Value = " ",
                    Type = OTokenType.Separator
                },
            };

            // when
            OToken[] actualTokens =
                this.tokenizationService.Tokenize(query);

            // then
            actualTokens.Should().BeEquivalentTo(expectedTokens);
        }
    }
}