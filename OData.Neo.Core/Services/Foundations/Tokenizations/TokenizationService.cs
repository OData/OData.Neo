//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using OData.Neo.Core.Models;

namespace OData.Neo.Core.Services.Foundations.Tokenizations
{
    public class TokenizationService : ITokenizationService
    {
        public OToken[] Tokenize(string rawQuery)
        {
            return new OToken[]
            {
                new OToken
                {
                    Value = "eq",
                    Type = OTokenType.Operand
                }
            };
        }
    }
}