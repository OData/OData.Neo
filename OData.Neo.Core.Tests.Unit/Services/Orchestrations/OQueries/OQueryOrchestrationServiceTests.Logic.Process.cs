//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using OData.Neo.Core.Models.OExpressions;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Orchestrations.OQueries
{
    public partial class OQueryOrchestrationServiceTests
    {
        [Fact]
        public async Task ShouldProcessOExpressionAsync()
        {
            // given
            OExpression randomOExpression = CreateRandomOExpression();
            OExpression inputOExpression = randomOExpression;
            OExpression generatedOExpression = inputOExpression.DeepClone();
            OExpression expectedOExpression = generatedOExpression;

            this.oExpressionServiceMock.Setup(service =>
                service.GenerateOExpressionAsync<object>(inputOExpression))
                    .ReturnsAsync(generatedOExpression);

            // when
            OExpression actualOExpression =
                await this.oQueryOrchestrationService.ProcessOQueryAsync<object>(
                    inputOExpression);

            // then
            actualOExpression.Should().BeEquivalentTo(expectedOExpression);

            this.oExpressionServiceMock.Verify(service =>
                service.GenerateOExpressionAsync<object>(inputOExpression),
                    Times.Once);

            this.oExpressionServiceMock.VerifyNoOtherCalls();
            this.oQueryServiceMock.VerifyNoOtherCalls();
            this.oSqlServiceMock.VerifyNoOtherCalls();
        }
    }
}
