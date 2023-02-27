//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using OData.Neo.Core.Models.Coordinations.OQueries.Exceptions;
using Xeptions;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Coordinations.OQueries
{
    public partial class OQueryCoordinationServiceTests
    {
        [Theory]
        [MemberData(nameof(DependencyValidationExceptions))]
        public async Task ShouldThrowDependencyValidationExceptionOnProcessIfDependencyValidationOccursAsync(
            Xeption dependencyValidationException)
        {
            // given
            string someOQueryExpression = GetRandomODataQuery();

            var expectedOQueryCoordinationDependencyValidationException =
                new OQueryCoordinationDependencyValidationException(
                    dependencyValidationException.InnerException as Xeption);

            this.oTokenizationOrchestrationServiceMock.Setup(service =>
                service.OTokenizeQuery(It.IsAny<string>()))
                    .Throws(dependencyValidationException);

            // when
            ValueTask<Expression> processOQueryTask =
                this.oQueryCoordinationService.ProcessOQueryAsync<object>(
                    someOQueryExpression);

            OQueryCoordinationDependencyValidationException 
                actualOQueryCoordinationDependencyValidationException =
                    await Assert.ThrowsAsync<OQueryCoordinationDependencyValidationException>(
                        processOQueryTask.AsTask);

            // then
            actualOQueryCoordinationDependencyValidationException.Should().BeEquivalentTo(
                expectedOQueryCoordinationDependencyValidationException);

            this.oTokenizationOrchestrationServiceMock.Verify(service =>
                service.OTokenizeQuery(It.IsAny<string>()),
                    Times.Once);

            this.oTokenizationOrchestrationServiceMock.VerifyNoOtherCalls();
            this.oQueryOrchestrationServiceMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(DependencyExceptions))]
        public async Task ShouldThrowDependencyExceptionOnProcessIfDependencyOccursAsync(
            Xeption dependencyException)
        {
            // given
            string someOQueryExpression = GetRandomODataQuery();

            var expectedOQueryCoordinationDependencyException =
                new OQueryCoordinationDependencyException(
                    dependencyException.InnerException as Xeption);

            this.oTokenizationOrchestrationServiceMock.Setup(service =>
                service.OTokenizeQuery(It.IsAny<string>()))
                    .Throws(dependencyException);

            // when
            ValueTask<Expression> processOQueryTask =
                this.oQueryCoordinationService.ProcessOQueryAsync<object>(
                    someOQueryExpression);

            OQueryCoordinationDependencyException
                actualOQueryCoordinationDependencyException =
                    await Assert.ThrowsAsync<OQueryCoordinationDependencyException>(
                        processOQueryTask.AsTask);

            // then
            actualOQueryCoordinationDependencyException.Should().BeEquivalentTo(
                expectedOQueryCoordinationDependencyException);

            this.oTokenizationOrchestrationServiceMock.Verify(service =>
                service.OTokenizeQuery(It.IsAny<string>()),
                    Times.Once);

            this.oTokenizationOrchestrationServiceMock.VerifyNoOtherCalls();
            this.oQueryOrchestrationServiceMock.VerifyNoOtherCalls();
        }
    }
}