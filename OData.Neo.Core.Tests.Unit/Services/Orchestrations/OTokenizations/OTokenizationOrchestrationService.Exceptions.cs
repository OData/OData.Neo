//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using FluentAssertions;
using Moq;
using OData.Neo.Core.Models.Orchestrations.OToknizations.Exceptions;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Models.ProjectedTokens;
using Xeptions;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Orchestrations.OTokenizations
{
    public partial class OTokenizationOrchestrationServiceTests
    {
        [Theory]
        [MemberData(nameof(DependencyValidationExceptions))]
        public void ShouldThrowDependencyValidationExceptionOnOTokenizeIfDependencyValidationErrorOccurs(
            Xeption dependencyValidationException)
        {
            // given
            string someQuery = GetRandomString();

            var expectedOTokenizeOrchestrationDependencyValidationException =
                new OTokenizationOrchestrationDependencyValidationException(
                    dependencyValidationException.InnerException as Xeption);

            this.tokenizationServiceMock.Setup(service =>
                service.Tokenize(It.IsAny<string>()))
                    .Throws(dependencyValidationException);

            // when
            Action oTokenizeAction = () =>
                this.otokenizationOrchestrationService.OTokenizeQuery(
                    someQuery);

            OTokenizationOrchestrationDependencyValidationException
                actualOTokenizationOrchestrationDependencyValidationException =
                    Assert.Throws<OTokenizationOrchestrationDependencyValidationException>(
                        oTokenizeAction);

            // then
            actualOTokenizationOrchestrationDependencyValidationException.Should()
                .BeEquivalentTo(expectedOTokenizeOrchestrationDependencyValidationException);

            this.tokenizationServiceMock.Verify(service =>
                service.Tokenize(It.IsAny<string>()),
                    Times.Once);

            this.projectionServiceMock.Verify(service =>
                service.ProjectTokens(It.IsAny<ProjectedToken[]>()),
                    Times.Never);

            this.otokenizationServiceMock.Verify(service =>
                service.OTokenize(It.IsAny<OToken[]>()),
                    Times.Never);

            this.tokenizationServiceMock.VerifyNoOtherCalls();
            this.projectionServiceMock.VerifyNoOtherCalls();
            this.otokenizationServiceMock.VerifyNoOtherCalls();
        }
    }
}
