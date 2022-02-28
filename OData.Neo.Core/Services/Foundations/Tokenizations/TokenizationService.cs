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
            // Switch on the query.
            return new OToken[] {
                rawQuery switch {
                    "eq" => new OToken
                    {
                        Type = OTokenType.Operand,
                        Value = rawQuery
                    },
                    "ge" => new OToken
                    {
                        Type = OTokenType.Operand,
                        Value = rawQuery
                    },
                    " " => new OToken
                    {
                        Type = OTokenType.Whitespace,
                        Value = rawQuery
                    },
                }
            };
        }
    }
}