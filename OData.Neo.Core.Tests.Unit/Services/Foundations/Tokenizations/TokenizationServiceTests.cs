//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
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

        public static TheoryData AllPossibleTokens()
        {
            return new TheoryData<OToken>
            {
                new OToken
                {
                    Value = "eq",
                    Type = OTokenType.Operand
                },

                new OToken
                {
                    Value = "ge",
                    Type = OTokenType.Operand
                },

                new OToken
                {
                    Value = " ",
                    Type = OTokenType.Whitespace
                }
            };
        }
    }
}
