//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.OExpressions.Exceptions;
using OData.Neo.Core.Models.Orchestrations.OQueries.Exceptions;
using Xeptions;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Orchestrations.OQueries
{
    public partial class OQueryOrchestrationServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnProcessIfValidationErrorOccursAsync()
        {
            // given
            OExpression someOExpression = CreateRandomOExpression();
            var randomValidationException = new Xeption();

            var oExpressionValidationException =
                new OExpressionValidationException(
                    randomValidationException);

            var expectedOQueryOrchestrationValidationException =
                new OQueryOrchestrationDependencyValidationException(
                    randomValidationException);

            this.oExpressionServiceMock.Setup(service =>
                service.GenerateOExpressionAsync<object>(It.IsAny<OExpression>()))
                    .ThrowsAsync(oExpressionValidationException);

            // when
            ValueTask<OExpression> processOQueryTask =
                this.oQueryOrchestrationService.ProcessOQueryAsync<object>(
                    someOExpression);

            OQueryOrchestrationDependencyValidationException
                actualOQueryOrchestrationDependencyValidationException =
                    await Assert.ThrowsAsync<
                        OQueryOrchestrationDependencyValidationException>(
                            processOQueryTask.AsTask);

            // then
            actualOQueryOrchestrationDependencyValidationException.Should()
                .BeEquivalentTo(expectedOQueryOrchestrationValidationException);

            this.oExpressionServiceMock.Verify(service =>
                service.GenerateOExpressionAsync<object>(someOExpression),
                    Times.Once);

            this.oExpressionServiceMock.VerifyNoOtherCalls();
            this.oQueryServiceMock.VerifyNoOtherCalls();
            this.oSqlServiceMock.VerifyNoOtherCalls();
        }


        [Fact]
        public async Task ShouldThrowDependencyExceptionOnProcessIfDependencyErrorOccursAsync()
        {
            // given
            OExpression someOExpression = CreateRandomOExpression();
            var randomValidationException = new Xeption();

            var oExpressionDependencyException =
                new OExpressionDependencyException(
                    randomValidationException);

            var expectedOQueryOrchestrationDependencyException =
                new OQueryOrchestrationDependencyException(
                    randomValidationException);

            this.oExpressionServiceMock.Setup(service =>
                service.GenerateOExpressionAsync<object>(It.IsAny<OExpression>()))
                    .ThrowsAsync(oExpressionDependencyException);

            // when
            ValueTask<OExpression> processOQueryTask =
                this.oQueryOrchestrationService.ProcessOQueryAsync<object>(
                    someOExpression);

            OQueryOrchestrationDependencyException
                actualOQueryOrchestrationDependencyException =
                    await Assert.ThrowsAsync<
                        OQueryOrchestrationDependencyException>(
                            processOQueryTask.AsTask);

            // then
            actualOQueryOrchestrationDependencyException.Should()
                .BeEquivalentTo(expectedOQueryOrchestrationDependencyException);

            this.oExpressionServiceMock.Verify(service =>
                service.GenerateOExpressionAsync<object>(someOExpression),
                    Times.Once);

            this.oExpressionServiceMock.VerifyNoOtherCalls();
            this.oQueryServiceMock.VerifyNoOtherCalls();
            this.oSqlServiceMock.VerifyNoOtherCalls();
        }
    }
}
