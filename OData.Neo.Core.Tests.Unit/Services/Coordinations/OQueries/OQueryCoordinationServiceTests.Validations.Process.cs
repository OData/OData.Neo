//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using OData.Neo.Core.Models.Coordinations.OQueries.Exceptions;
using OData.Neo.Core.Models.OExpressions;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Coordinations.OQueries
{
    public partial class OQueryCoordinationServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnProcessIfExpressionIsNullAsync()
        {
            // given
            string nullExpression = null;

            var nullOQueryExpressionCoordinationException =
                new NullOQueryExpressionCoordinationException();

            var expectedOQueryCoordinationValidationException =
                new OQueryCoordinationValidationException(
                    nullOQueryExpressionCoordinationException);

            // when
            ValueTask<Expression> processOQueryTask =
                this.oQueryCoordinationService.ProcessOQueryAsync<object>(
                    nullExpression);

            OQueryCoordinationValidationException actualOQueryCoordinationValidationException =
                await Assert.ThrowsAsync<OQueryCoordinationValidationException>(
                    processOQueryTask.AsTask);

            // then
            actualOQueryCoordinationValidationException.Should().BeEquivalentTo(
                expectedOQueryCoordinationValidationException);

            this.oQueryOrchestrationServiceMock.Verify(broker =>
                broker.ProcessOQueryAsync<object>(It.IsAny<OExpression>()),
                    Times.Never);

            this.oQueryOrchestrationServiceMock.VerifyNoOtherCalls();
        }
    }
}
