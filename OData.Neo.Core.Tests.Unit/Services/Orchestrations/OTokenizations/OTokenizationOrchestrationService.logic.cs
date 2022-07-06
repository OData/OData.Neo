//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using FluentAssertions;
using Moq;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Models.Tokens;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Orchestrations.OTokenizations
{
    public partial class OTokenizationOrchestrationServiceTests
    {
        [Fact]
        public void ShouldOTokenizeODataQuery()
        {
            // given
            string inputQuery = "$select=Name";

            var returnedTokens = new Token[]
            {
                new Token(TokenType.Word, "$select"),
                new Token(TokenType.Separator, "="),
                new Token(TokenType.Word, "Name")
            };

            var expectedInputProjectedTokens = new ProjectedToken[]
            {
                new ProjectedToken
                {
                    RawValue = "$select",
                    TokenType = TokenType.Word,
                    ProjectedType = ProjectedTokenType.Unidentified
                },

                new ProjectedToken
                {
                    RawValue = "=",
                    TokenType = TokenType.Separator,
                    ProjectedType = ProjectedTokenType.Unidentified
                },

                new ProjectedToken
                {
                    RawValue = "Name",
                    TokenType = TokenType.Word,
                    ProjectedType = ProjectedTokenType.Unidentified
                },
            };

            var returnedProjectedTokens = new ProjectedToken[]
            {
                new ProjectedToken
                {
                    RawValue = "$select",
                    TokenType = TokenType.Word,
                    ProjectedType = ProjectedTokenType.Keyword
                },

                new ProjectedToken
                {
                    RawValue = "=",
                    TokenType = TokenType.Separator,
                    ProjectedType = ProjectedTokenType.Assignment
                },

                new ProjectedToken
                {
                    RawValue = "Name",
                    TokenType = TokenType.Word,
                    ProjectedType = ProjectedTokenType.Property
                },
            };

            var expectedInputOTokens = new OToken[]
            {
                new OToken
                {
                    ProjectedType = ProjectedTokenType.Keyword,
                    Type = OTokenType.Unidentified,
                    RawValue = "$select"
                },

                new OToken
                {
                    ProjectedType = ProjectedTokenType.Assignment,
                    Type = OTokenType.Unidentified,
                    RawValue = "="
                },

                new OToken
                {
                    ProjectedType = ProjectedTokenType.Property,
                    Type = OTokenType.Unidentified,
                    RawValue = "Name"
                }
            };

            OToken randomOToken = CreateRandomOToken();
            OToken returnedOToken = randomOToken;
            OToken expectedOToken = returnedOToken;

            this.tokenizationServiceMock.Setup(service =>
                service.Tokenize(inputQuery))
                    .Returns(returnedTokens);

            this.projectionServiceMock.Setup(service =>
                service.ProjectTokens(It.Is(SameProjectedTokensAs(
                    expectedInputProjectedTokens))))
                        .Returns(returnedProjectedTokens);

            this.otokenizationServiceMock.Setup(service =>
                service.OTokenize(It.Is(SameOTokensAs(
                    expectedInputOTokens))))
                        .Returns(returnedOToken);

            // when
            OToken actualOToken =
                this.otokenizationOrchestrationService.OTokenizeQuery(
                    inputQuery);

            // then
            actualOToken.Should().BeEquivalentTo(expectedOToken);

            this.tokenizationServiceMock.Verify(service =>
                service.Tokenize(inputQuery),
                    Times.Once);

            this.projectionServiceMock.Verify(service =>
                service.ProjectTokens(It.Is(SameProjectedTokensAs(
                    expectedInputProjectedTokens))),
                        Times.Once);

            this.otokenizationServiceMock.Verify(service =>
                service.OTokenize(It.Is(SameOTokensAs(
                    expectedInputOTokens))),
                        Times.Once);

            this.tokenizationServiceMock.VerifyNoOtherCalls();
            this.projectionServiceMock.VerifyNoOtherCalls();
            this.otokenizationServiceMock.VerifyNoOtherCalls();
        }
    }
}
