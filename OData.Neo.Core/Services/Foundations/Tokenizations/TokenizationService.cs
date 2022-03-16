//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models;
using System;

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
                    "gt" => new OToken
                    {
                        Type = OTokenType.Operand,
                        Value = rawQuery
                    },
                    "lt" => new OToken
                    {
                        Type = OTokenType.Operand,
                        Value = rawQuery
                    },
                    "le" => new OToken
                    {
                        Type = OTokenType.Operand,
                        Value = rawQuery
                    },

                    " " => new OToken
                    {
                        Type = OTokenType.Whitespace,
                        Value = rawQuery
                    },
                    "(" => new OToken
                    {
                        Type = OTokenType.BeginScope,
                        Value = rawQuery
                    },
                    ")" => new OToken
                    {
                        Type = OTokenType.EndScope,
                        Value = rawQuery
                    },
                    "=" => new OToken
                    {
                        Type = OTokenType.Equals,
                        Value = rawQuery
                    },
                    "-" => new OToken
                    {
                        Type = OTokenType.Hyphen,
                        Value = rawQuery
                    },
                    "'" => new OToken
                    {
                        Type = OTokenType.Quote,
                        Value = rawQuery
                    },
                    "*" => new OToken
                    {
                        Type = OTokenType.Star,
                        Value = rawQuery
                    },
                    "[" => new OToken
                    {
                        Type = OTokenType.OpenBracket,
                        Value = rawQuery
                    },
                    "]" => new OToken
                    {
                        Type = OTokenType.CloseBracket,
                        Value = rawQuery
                    },
                    ":" => new OToken
                    {
                        Type = OTokenType.Colon,
                        Value = rawQuery
                    },
                    ";" => new OToken
                    {
                        Type = OTokenType.SemiColon,
                        Value = rawQuery
                    },
                    "_" => new OToken
                    {
                        Type = OTokenType.Underscore,
                        Value = rawQuery
                    },
                    "&" => new OToken
                    {
                        Type = OTokenType.Ampersand,
                        Value = rawQuery
                    },
                    "$" => new OToken
                    {
                        Type = OTokenType.Dollar,
                        Value = rawQuery
                    },
                    "/" => new OToken
                    {
                        Type = OTokenType.Slash,
                        Value = rawQuery
                    },
                    "\\" => new OToken
                    {
                        Type = OTokenType.BackSlash,
                        Value = rawQuery
                    },
                    _ when double.TryParse(rawQuery,out _) =>
                    new OToken
                    {
                        Type = OTokenType.Number,
                        Value = rawQuery
                    },
                    _ when Guid.TryParse(rawQuery, out _) =>
                    new OToken
                    {
                        Type = OTokenType.Guid,
                        Value = rawQuery
                    },
                    _ when DateTimeOffset.TryParse(rawQuery, out _) =>
                    new OToken
                    {
                        Type = OTokenType.DateTimeOffset,
                        Value = rawQuery
                    },
                    _ when bool.TryParse(rawQuery, out _) =>
                    new OToken
                    {
                        Type = OTokenType.Boolean,
                        Value = rawQuery
                    },
                    _ when rawQuery.StartsWith('$')  =>
                        new OToken
                        {
                            Type = OTokenType.ODataParameter,
                            Value = rawQuery
                        },
                    _ =>
                        new OToken
                        {
                            Type = OTokenType.Word,
                            Value = rawQuery
                        }
                }
            };
        }
    }
}