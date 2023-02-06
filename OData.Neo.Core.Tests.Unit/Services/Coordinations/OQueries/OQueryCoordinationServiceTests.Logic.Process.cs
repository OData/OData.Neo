//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Services.Coordinations.OQueries;
using OData.Neo.Core.Services.Orchestrations.OQueries;
using OData.Neo.Core.Services.Orchestrations.OTokenizations;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Coordinations.OQueries
{
    public partial class OQueryCoordinationServiceTests
    {
        [Fact]
        public async Task ShouldProcessODataTokenAsync()
        {
            // given
            string randomODataQuery = GetRandomODataQuery();
            string inputODataQuery = randomODataQuery;
            OToken randomOToken = CreateRandomOToken();
            OToken tokenizedQuery = randomOToken;

            var expectedInputOExpression = new OExpression
            {
                OToken = tokenizedQuery,
                RawQuery = inputODataQuery
            };

            Expression randomExpression = CreateMockedExpression();
            Expression expectedExpression = randomExpression;

            var processedOExpression = new OExpression();
            processedOExpression.Expression = randomExpression;

            this.oTokenizationOrchestrationServiceMock.Setup(service =>
                service.OTokenizeQuery(inputODataQuery))
                    .Returns(tokenizedQuery);

            this.oQueryOrchestrationServiceMock.Setup(service =>
                service.ProcessOQueryAsync<object>(It.Is(SameOExpressionAs(
                    expectedInputOExpression))))
                        .ReturnsAsync(processedOExpression);

            // when
            Expression actualExpression =
                await this.oQueryCoordinationService.ProcessOQueryAsync<object>(
                    inputODataQuery);

            // then
            actualExpression.Should().BeEquivalentTo(expectedExpression);

            this.oTokenizationOrchestrationServiceMock.Verify(service =>
                service.OTokenizeQuery(inputODataQuery),
                    Times.Once);

            this.oQueryOrchestrationServiceMock.Verify(service =>
                service.ProcessOQueryAsync<object>(It.Is(SameOExpressionAs(
                    expectedInputOExpression))),
                        Times.Once);

            this.oQueryOrchestrationServiceMock.VerifyNoOtherCalls();
            this.oTokenizationOrchestrationServiceMock.VerifyNoOtherCalls();
        }
    }
}
