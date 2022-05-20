//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using FluentAssertions;
using OData.Neo.Core.Models;
using OData.Neo.Core.Models.ProjectedTokens;
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
                    TokenType = OTokenType.Word,
                    ProjectedType = ProjectedType.Unidentified
                }
            };

            var expectedProjectedTokens = new ProjectedToken[]
            {
                new ProjectedToken
                {
                    RawValue = "$filter",
                    TokenType = OTokenType.Word,
                    ProjectedType = ProjectedType.Keyword
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
        [MemberData(nameof(GetProjectedTokens))]
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
