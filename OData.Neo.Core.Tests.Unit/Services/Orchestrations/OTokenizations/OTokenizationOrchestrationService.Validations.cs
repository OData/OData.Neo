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
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Orchestrations.OTokenizations
{
    public partial class OTokenizationOrchestrationServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnOTokenizeIfQueryIsNull()
        {
            // given
            string nullQuery = null;

            var nullQueryOTOkenizationOrchestrationException =
                new NullQueryOTokenizationOrchestrationException();

            var expectedOTokenizationOrchestrationValidationException =
                new OTokenizationOrchestrationValidationException(
                    nullQueryOTOkenizationOrchestrationException);

            // when
            Action oTokenizeAction = () =>
                this.otokenizationOrchestrationService.OTokenizeQuery(
                    nullQuery);

            OTokenizationOrchestrationValidationException
                actualOTokenizationOrchestrationValidationException =
                    Assert.Throws<OTokenizationOrchestrationValidationException>(
                        oTokenizeAction);

            // then
            actualOTokenizationOrchestrationValidationException.Should()
                .BeEquivalentTo(expectedOTokenizationOrchestrationValidationException);

            this.tokenizationServiceMock.Verify(service =>
                service.Tokenize(It.IsAny<string>()),
                    Times.Never);

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
