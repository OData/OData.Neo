//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

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
    }
}
