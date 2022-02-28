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
            string rawQuery = "eq";

            var expectedTokens = new OToken[]
            {
                new OToken
                {
                    Value = "eq",
                    Type = OTokenType.Operand
                }
            };

            // when
            OToken[] actualTokens =
                this.tokenizationService.Tokenize(rawQuery);

            // then
            actualTokens.Should().BeEquivalentTo(expectedTokens);
        }
    }
}