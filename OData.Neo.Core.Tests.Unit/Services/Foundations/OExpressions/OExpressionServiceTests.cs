//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Moq;
using OData.Neo.Core.Brokers.Expressions;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Services.Foundations.OExpressions;
using Tynamix.ObjectFiller;

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

        private static List<OToken> CreateRandomPropertyOTokens()
        {
            return Enumerable.Range(start: 0, count: GetRandomNumber())
                .Select(item => new OToken
                {
                    Type = OTokenType.Property,
                    ProjectedType = ProjectedTokenType.Property,
                    RawValue = GetRandomString()
                }).ToList();
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();
    }
}
