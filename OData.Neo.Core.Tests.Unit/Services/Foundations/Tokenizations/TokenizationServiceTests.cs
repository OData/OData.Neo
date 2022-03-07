//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using OData.Neo.Core.Models;
using OData.Neo.Core.Services.Foundations.Tokenizations;
using Tynamix.ObjectFiller;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Tokenizations
{
    public partial class TokenizationServiceTests
    {
        private readonly ITokenizationService tokenizationService;

        public TokenizationServiceTests() =>
            this.tokenizationService = new TokenizationService();

        public static TheoryData OperandTokens()
        {
            return new TheoryData<OToken>
            {
                new OToken { Value = "eq", Type = OTokenType.Operand },
                new OToken { Value = "ge", Type = OTokenType.Operand },
                new OToken { Value = "gt", Type = OTokenType.Operand },
                new OToken { Value = "lt", Type = OTokenType.Operand },
                new OToken { Value = "le", Type = OTokenType.Operand },
            };
        }

        public static TheoryData SpecialTokens()
        {
            return new TheoryData<OToken>
            {
                new OToken { Value = " ", Type = OTokenType.Whitespace },
                new OToken { Value = "(", Type = OTokenType.BeginScope },
                new OToken { Value = ")", Type = OTokenType.EndScope },
                new OToken { Value = "=", Type = OTokenType.Equals },
                new OToken { Value = "-", Type = OTokenType.Hyphen },
                new OToken { Value = "'", Type = OTokenType.Quote },
                new OToken { Value = "*", Type = OTokenType.Star },
                new OToken { Value = "[", Type = OTokenType.OpenBracket },
                new OToken { Value = "]", Type = OTokenType.CloseBracket },
                new OToken { Value = ":", Type = OTokenType.Colon },
                new OToken { Value = ";", Type = OTokenType.SemiColon },
                new OToken { Value = "_", Type = OTokenType.Underscore },
                new OToken { Value = "&", Type = OTokenType.Ampersand },
                new OToken { Value = "$", Type = OTokenType.Dollar },
                new OToken { Value = "/", Type = OTokenType.Slash },
                new OToken { Value = "\\", Type = OTokenType.BackSlash }
            };
        }

        public static TheoryData ComplexTokens()
        {
            string randomLiteral = new MnemonicString().GetValue();
            int randomNumber = new IntRange().GetValue();
            Guid randomGuid = Guid.NewGuid();

            return new TheoryData<OToken>
            {
                new OToken { Value = $"${randomLiteral}", Type = OTokenType.ODataParameter },
                new OToken { Value = $"{randomNumber}", Type = OTokenType.Number },
                new OToken { Value = $"{randomGuid}", Type = OTokenType.Guid }
            };
        }
    }
}
