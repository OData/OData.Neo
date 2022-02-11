//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq;
using OData.Neo.Core.Services.Foundations.Tokenizations;
using Tynamix.ObjectFiller;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Tokenizations
{
    public partial class TokenizationServiceTests
    {
        private readonly ITokenizationService tokenizationService;

        public TokenizationServiceTests() =>
            this.tokenizationService = new TokenizationService();

        public static (string Parameter, string Operand, string Property)
            GetRandomQueryParameters()
        {
            string randomParameter =
                $"${new MnemonicString().GetValue()}";

            string randomProperty =
                new MnemonicString().GetValue();

            return (randomParameter, "=", randomProperty);
        }

        public static (string Parameter, string Operand, string[] Property)
            GetRandomQueryWithMultipleProperties()
        {
            string randomParameter =
                $"${new MnemonicString().GetValue()}";

            string[] randomProperties =
                Enumerable.Range(start: 0, count: GetRandomNumber())
                    .Select(item => new MnemonicString().GetValue()).ToArray();

            return (randomParameter, "=", randomProperties);
        }

        public static (
            (string Parameter, string Operand, string[] Property) Inner,
            (string Parameter, string Operand, string[] Property) Outer
        )
            GetRandomQueryWithMultipleNestedProperties() => (
                GetRandomQueryWithMultipleProperties(),
                GetRandomQueryWithMultipleProperties()
            );

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();
    }
}
