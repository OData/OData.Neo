//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using Moq;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Services.Foundations.OExpressions;
using OData.Neo.Core.Services.Foundations.OQueries;
using OData.Neo.Core.Services.Foundations.OSqls;
using OData.Neo.Core.Services.Orchestrations.OQueries;
using Tynamix.ObjectFiller;

namespace OData.Neo.Core.Tests.Unit.Services.Orchestrations.OQueries
{
    public partial class OQueryOrchestrationServiceTests
    {
        private readonly Mock<IOExpressionService> oExpressionServiceMock;
        private readonly Mock<IOQueryService> oQueryServiceMock;
        private readonly Mock<IOSqlService> oSqlServiceMock;
        private readonly IOQueryOrchestrationService oQueryOrchestrationService;

        public OQueryOrchestrationServiceTests()
        {
            this.oExpressionServiceMock = new Mock<IOExpressionService>();
            this.oQueryServiceMock = new Mock<IOQueryService>();
            this.oSqlServiceMock = new Mock<IOSqlService>();

            this.oQueryOrchestrationService = new OQueryOrchestrationService(
                oExpressionService: this.oExpressionServiceMock.Object,
                oQueryService: this.oQueryServiceMock.Object,
                oSqlService: this.oSqlServiceMock.Object);
        }

        private static OExpression CreateRandomOExpression() =>
           CreateOExpressionFiller().Create();

        private static Filler<OExpression> CreateOExpressionFiller()
        {
            var filler = new Filler<OExpression>();

            filler.Setup()
                .OnType<Expression>().IgnoreIt();

            return filler;
        }
    }
}
