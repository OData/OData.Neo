//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Scripting;
using Moq;
using OData.Neo.Core.Brokers.Expressions;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Services.Foundations.OExpressions;
using Tynamix.ObjectFiller;
using Xunit;

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

        public static TheoryData<Exception> DependencyExceptions()
        {
            string randomMessage = GetRandomString();

            return new TheoryData<Exception>
            {
                new ArgumentNullException(),
                new ArgumentException(),

                new CompilationErrorException(
                    message: randomMessage,
                    diagnostics: ImmutableArray.Create<Diagnostic>())
            };
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

        private static (List<OToken>, string) CreateRandomNonPropertyOTokens()
        {
            var randomOTokens = new List<OToken>();
            var rawValues = new List<string>();

            Enumerable.Range(start: 0, count: GetRandomNumber()).ToList()
                .ForEach(item =>
                {
                    string rawStringValue = GetRandomString();

                    randomOTokens.Add(new OToken
                    {
                        Type = GetEnumThatIsNot(OTokenType.Property),
                        ProjectedType = GetEnumThatIsNot(ProjectedTokenType.Property),
                        RawValue = rawStringValue
                    });

                    rawValues.Add($"obj.{rawStringValue}");
                });

            string allRawValues = string.Join(",", rawValues);

            return (randomOTokens, allRawValues);
        }

        private static T GetEnumThatIsNot<T>(T notThisValue) where T : Enum
        {
            T[] allValues = Enum.GetValues(typeof(T)) as T[];
            allValues = allValues.Except(new[] { notThisValue }).ToArray();

            int randomNumber = new Random()
                .Next(
                    minValue: 0,
                    maxValue: allValues.Length);

            return allValues[randomNumber];
        }

        private static OExpression CreateRandomOExpression() =>
            CreateOExpressionFiller().Create();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static IQueryable<object> CreateRandomSource()
        {
            var filler = new Filler<object>();
            
            filler.Setup()
                .OnType<object>().Use(GetRandomString());

            return filler
                .Create(count: GetRandomNumber())
                .AsQueryable<object>();
        }

        private static Filler<OExpression> CreateOExpressionFiller()
        {
            var filler = new Filler<OExpression>();

            filler.Setup()
                .OnType<Expression>().IgnoreIt();

            return filler;
        }
    }
}
