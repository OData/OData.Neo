//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using FluentAssertions;
using OData.Neo.Core.Models;
using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Models.Tokens;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Projections
{
    public partial class ProjectionServiceTests
    {
        [Fact]
        public void ShouldProjectKeywords()
        {
            // given
            var inputProjectedTokens = new ProjectedToken[]
            {
                new ProjectedToken
                {
                    RawValue = "$filter",
                    TokenType = TokenType.Word,
                    ProjectedType = ProjectedTokenType.Unidentified
                }
            };

            var expectedProjectedTokens = new ProjectedToken[]
            {
                new ProjectedToken
                {
                    RawValue = "$filter",
                    TokenType = TokenType.Word,
                    ProjectedType = ProjectedTokenType.Keyword
                }
            };

            // when
            ProjectedToken[] actualProjectedTokens =
                this.projectionService.ProjectTokens(
                    inputProjectedTokens);

            // then
            actualProjectedTokens.Should().BeEquivalentTo(expectedProjectedTokens);
        }

        [Theory]
        [MemberData(nameof(ProjectedTokens))]
        public void ShouldProjectAllTokensKeywords(
            ProjectedToken[] inputProjectedTokens,
            ProjectedToken[] expectedProjectedTokens)
        {
            // given . when
            ProjectedToken[] actualProjectedTokens =
                this.projectionService.ProjectTokens(
                    inputProjectedTokens);

            // then
            actualProjectedTokens.Should().BeEquivalentTo(
                expectedProjectedTokens);
        }
    }
}
