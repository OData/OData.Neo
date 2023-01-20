//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.Orchestrations.OQueries.Exceptions;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Orchestrations.OQueries
{
    public partial class OQueryOrchestrationServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnOQueryIfExpressionIsNullAsync()
        {
            // given
            OExpression nullExpression = null;

            var nullQueryOQueryOrchestrationException =
                new NullOExpressionOQueryOrchestrationException();

            var expectedOQueryOrchestrationValidationException =
                new OQueryOrchestrationValidationException(
                    nullQueryOQueryOrchestrationException);

            // when
            ValueTask<OExpression> processOQueryTask =
                this.oQueryOrchestrationService.ProcessOQueryAsync<object>(
                    nullExpression);

            OQueryOrchestrationValidationException
                actualOQueryOrchestrationValidationException =
                    await Assert.ThrowsAsync<OQueryOrchestrationValidationException>(
                        processOQueryTask.AsTask);

            // then
            actualOQueryOrchestrationValidationException.Should()
                .BeEquivalentTo(expectedOQueryOrchestrationValidationException);

            this.oExpressionServiceMock.Verify(service =>
                service.GenerateOExpressionAsync<object>(nullExpression),
                    Times.Never);

            this.oExpressionServiceMock.VerifyNoOtherCalls();
            this.oQueryServiceMock.VerifyNoOtherCalls();
            this.oSqlServiceMock.VerifyNoOtherCalls();
        }
    }
}
