//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models;
using OData.Neo.Core.Services.Foundations.Tokenizations;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Tokenizations
{
    public partial class TokenizationServiceTests
    {
        private readonly ITokenizationService tokenizationService;

        public TokenizationServiceTests() => 
            this.tokenizationService = new TokenizationService();

        public static TheoryData BasicTokens()
        {
            return new TheoryData<OToken>
            {
                // operands
                new OToken { Value = "eq", Type = OTokenType.Operand },
                new OToken { Value = "ge", Type = OTokenType.Operand },
                new OToken { Value = "gt", Type = OTokenType.Operand },
                new OToken { Value = "lt", Type = OTokenType.Operand },
                new OToken { Value = "le", Type = OTokenType.Operand },

                // special
                new OToken { Value = " ", Type = OTokenType.Whitespace },
                new OToken { Value = "(", Type = OTokenType.BeginScope },
                new OToken { Value = ")", Type = OTokenType.EndScope },
                new OToken { Value = "=", Type = OTokenType.Equals },
                new OToken { Value = "-", Type = OTokenType.Hyphen },
                new OToken { Value = ".", Type = OTokenType.Dot },
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
            return new TheoryData<OToken>
            {
                // These will need randomizing when tested for ...
                new OToken { Value = "$word", Type = OTokenType.ODataParameter },
                new OToken { Value = "$word123", Type = OTokenType.ODataParameter },
                new OToken { Value = "$123word", Type = OTokenType.ODataParameter },
                new OToken { Value = "$w1o2r3d", Type = OTokenType.ODataParameter },
                new OToken { Value = "word", Type = OTokenType.Word },
                new OToken { Value = "123", Type = OTokenType.Number },
                new OToken { Value = "123.456", Type = OTokenType.Number },
                new OToken { Value = "-123", Type = OTokenType.Number },
                new OToken { Value = "-123.456", Type = OTokenType.Number },
                new OToken { Value = "AAAAA-BBBBB-CCCCC-DDDDDDD", Type = OTokenType.Guid },

                // booleans are all these acceptable ? ...
                new OToken { Value = "true", Type = OTokenType.Boolean },
                new OToken { Value = "false", Type = OTokenType.Boolean },
                new OToken { Value = "TRUE", Type = OTokenType.Boolean },
                new OToken { Value = "TRUE", Type = OTokenType.Boolean },
                new OToken { Value = "True", Type = OTokenType.Boolean },
                new OToken { Value = "False", Type = OTokenType.Boolean }
            };
        }
    }
}
