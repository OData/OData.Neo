//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private static (List<OToken>, string) CreateRandomPropertyOTokens()
        {
            var randomOTokens = new List<OToken>();
            var rawValues = new List<string>();

            Enumerable.Range(start: 0, count: GetRandomNumber()).ToList()
                .ForEach(item =>
                {
                    string rawStringValue = GetRandomString();

                    randomOTokens.Add(new OToken
                    {
                        Type = OTokenType.Property,
                        ProjectedType = ProjectedTokenType.Property,
                        RawValue = rawStringValue
                    });

                    rawValues.Add($"obj.{rawStringValue}");
                });

            string allRawValues = string.Join(",", rawValues);

            return (randomOTokens, allRawValues);
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();
    }
}
