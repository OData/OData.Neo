//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using KellermanSoftware.CompareNetObjects;
using Moq;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Services.Coordinations.OQueries;
using OData.Neo.Core.Services.Orchestrations.OQueries;
using OData.Neo.Core.Services.Orchestrations.OTokenizations;
using Tynamix.ObjectFiller;

namespace OData.Neo.Core.Tests.Unit.Services.Coordinations.OQueries
{
    public partial class OQueryCoordinationServiceTests
    {
        private readonly Mock<IOTokenizationOrchestrationService> oTokenizationOrchestrationServiceMock;
        private readonly Mock<IOQueryOrchestrationService> oQueryOrchestrationServiceMock;
        private readonly ICompareLogic compareLogic;
        private readonly IOQueryCoordinationService oQueryCoordinationService;

        public OQueryCoordinationServiceTests()
        {
            this.oTokenizationOrchestrationServiceMock =
                new Mock<IOTokenizationOrchestrationService>();
            
            this.oQueryOrchestrationServiceMock =
                new Mock<IOQueryOrchestrationService>();

            this.compareLogic = new CompareLogic();

            this.oQueryCoordinationService = new OQueryCoordinationService(
                oTokenizationOrchestrationService: this.oTokenizationOrchestrationServiceMock.Object,
                oQueryOrchestrationService: this.oQueryOrchestrationServiceMock.Object);
        }

        private string GetRandomODataQuery() =>
            new MnemonicString().GetValue();

        private OToken CreateRandomOToken() =>
            CreateOTokenFiller().Create();

        private Expression<Func<OExpression, bool>> SameOExpressionAs(
            OExpression expectedOExpression)
        {
            return actualOExpression => this.compareLogic.Compare(
                expectedOExpression,
                actualOExpression)
                    .AreEqual;
        }

        private static Expression CreateMockedExpression() =>
            Mock.Of<Expression>();

        private static Filler<OToken> CreateOTokenFiller() =>
           new Filler<OToken>();
    }
}
