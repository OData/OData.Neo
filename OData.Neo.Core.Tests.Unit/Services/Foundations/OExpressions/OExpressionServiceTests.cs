//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Moq;
using OData.Neo.Core.Brokers.Expressions;
using OData.Neo.Core.Services.Foundations.OExpressions;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.OExpressions
{
    public partial class OExpressionServiceTests
    {
        private readonly Mock<IExpressionBroker> expressionBrokerMock;
        private readonly IOExpressionService oExpressionService;

        public OExpressionServiceTests()
        {
            this.expressionBrokerMock = new Mock<IExpressionBroker>();

            this.oExpressionService = new OExpressionService(
                expressionBroker: this.expressionBrokerMock.Object);
        }
    }
}
