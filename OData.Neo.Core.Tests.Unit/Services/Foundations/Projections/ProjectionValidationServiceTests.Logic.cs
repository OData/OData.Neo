﻿using FluentAssertions;
using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Models.ProjectedTokens.Exceptions;
using System;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Projections
{
    public partial class ProjectionValidationServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnProjectIfTokensIsNull()
        {
            // given
            ProjectedToken[] nullProjectedTokens = null;

            var nullProjectedTokenException =
                new NullProjectedTokenException();

            var projectedTokenValidationException =
                new ProjectedTokenValidationException(
                    nullProjectedTokenException);

            // when
            Action projectTokensAction = () =>
                this.projectionValidationService.ValidateProjectedTokens(
                    nullProjectedTokens);

            // then
            ProjectedTokenValidationException actualProjectedTokenValidationException =
                Assert.Throws<ProjectedTokenValidationException>(
                    projectTokensAction);

            actualProjectedTokenValidationException.InnerException.Should()
                .BeOfType<NullProjectedTokenException>();
        }

        [Fact]
        public void ShouldThrowValidationExceptionIfAnyProjectedTokenIsNull()
        {
            // given
            ProjectedToken nullProjectedToken = null;

            ProjectedToken[] randomProjectedTokens =
                CreateRandomProjectedTokens(nullProjectedToken);

            ProjectedToken[] invalidProjectedTokens =
                randomProjectedTokens;

            var nullProjectedTokenException =
                new NullProjectedTokenException();

            var expectedProjectedTokenValidationException =
                new ProjectedTokenValidationException(
                    nullProjectedTokenException);

            // when
            Action projectTokensAction = () =>
                this.projectionValidationService.ValidateProjectedTokens(
                    invalidProjectedTokens);

            // then
            ProjectedTokenValidationException actualProjectedTokenValidationException =
                Assert.Throws<ProjectedTokenValidationException>(
                    projectTokensAction);

            actualProjectedTokenValidationException.InnerException.Should()
                .BeOfType<NullProjectedTokenException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldThrowValidationExceptionIfAnyProjectedTokenRawValuesIsNull(
            string invalidRawData)
        {
            // given
            ProjectedToken invalidProjectedToken = new ProjectedToken
            {
                RawValue = invalidRawData
            };

            ProjectedToken[] randomProjectedTokens =
                CreateRandomProjectedTokens(invalidProjectedToken);

            ProjectedToken[] invalidProjectedTokens =
                randomProjectedTokens;

            var invalidProjectedTokenRawValueException =
                new InvalidProjectedTokenRawValueException();

            var expectedProjectedTokenValidationException =
                new ProjectedTokenValidationException(
                    invalidProjectedTokenRawValueException);

            // when
            Action projectTokensAction = () =>
                this.projectionValidationService.ValidateProjectedTokens(
                    invalidProjectedTokens);

            // then
            ProjectedTokenValidationException actualProjectedTokenValidationException =
                Assert.Throws<ProjectedTokenValidationException>(
                    projectTokensAction);

            actualProjectedTokenValidationException.InnerException.Should()
                .BeOfType<InvalidProjectedTokenRawValueException>();
        }
    }
}
