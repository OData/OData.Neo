//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using FluentAssertions;
using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Models.ProjectedTokens.Exceptions;
using System;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Projections
{
    public partial class ProjectionServiceTests
    {
        [Fact]
        public void ShouldThrowServiceExceptionOnProjectIfServiceErrorOccurs()
        {
            // given
            ProjectedToken[] someProjectedTokens =
                CreateRandomProjectedTokens();

            var serviceException = new Exception();

            var failedProjectedTokenServiceException =
                new FailedProjectedTokenServiceException(
                    serviceException);

            var expectedProjectedTokenServiceException =
                new ProjectedTokenServiceException(
                    failedProjectedTokenServiceException);

            projectionValidationServiceMock.Setup(projectionValidationServiceMock =>
                projectionValidationServiceMock.ValidateProjectedTokens(someProjectedTokens))
                .Throws(expectedProjectedTokenServiceException);

            // when
            Action projectTokensAction = () =>
                this.projectionService.ProjectTokens(
                    someProjectedTokens);

            // then
            ProjectedTokenServiceException actualProjectedTokenValidationException =
                Assert.Throws<ProjectedTokenServiceException>(
                    projectTokensAction);

            actualProjectedTokenValidationException.InnerException.Should()
                .BeOfType<FailedProjectedTokenServiceException>();
        }
    }
}
