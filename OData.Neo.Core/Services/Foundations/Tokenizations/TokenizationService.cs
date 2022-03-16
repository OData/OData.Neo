//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OData.Neo.Core.Services.Foundations.Tokenizations
{
    public class TokenizationService : ITokenizationService
    {
        private readonly char[] SeperatorChars = new char[] { ' ', '&', '=' };

        public OToken[] Tokenize(string rawQuery)
        {
            var result = new List<OToken>();

            StringBuilder runningthing = new StringBuilder();
            foreach (var @char in rawQuery)
            {
                if (!SeperatorChars.Any(c => c == @char))
                {
                    runningthing.Append(@char);
                }
                else
                {
                    if (runningthing.Length > 0)
                    {
                        result.Add(BuildOTokenFromValue(runningthing.ToString()));
                        runningthing.Clear();
                    }

                    result.Add(BuildOTokenFromValue(@char.ToString()));
                }
            }

            if (runningthing.Length > 0)
            {
                result.Add(BuildOTokenFromValue(runningthing.ToString()));
            }

            return result.ToArray();
        }

        private OToken BuildOTokenFromValue(string tokenValue)
        {
            return new OToken
            {
                Type = GetTokenType(tokenValue),
                Value = tokenValue
            };
        }

        private OTokenType GetTokenType(string tokenValue)
        {
            return tokenValue switch
            {
                "eq" => OTokenType.Operand,
                "ge" => OTokenType.Operand,
                "gt" => OTokenType.Operand,
                "lt" => OTokenType.Operand,
                "le" => OTokenType.Operand,
                " " => OTokenType.Whitespace,
                "(" => OTokenType.BeginScope,
                ")" => OTokenType.EndScope,
                "=" => OTokenType.Equals,
                "-" => OTokenType.Hyphen,
                "'" => OTokenType.Quote,
                "*" => OTokenType.Star,
                "[" => OTokenType.OpenBracket,
                "]" => OTokenType.CloseBracket,
                ":" => OTokenType.Colon,
                ";" => OTokenType.SemiColon,
                "_" => OTokenType.Underscore,
                "&" => OTokenType.Ampersand,
                "$" => OTokenType.Dollar,
                "/" => OTokenType.Slash,
                "\\" => OTokenType.BackSlash,
                _ when double.TryParse(tokenValue, out _) => OTokenType.Number,
                _ when Guid.TryParse(tokenValue, out _) => OTokenType.Guid,
                _ when DateTimeOffset.TryParse(tokenValue, out _) => OTokenType.DateTimeOffset,
                _ when bool.TryParse(tokenValue, out _) => OTokenType.Boolean,
                _ when tokenValue.StartsWith('$') => OTokenType.ODataParameter,
                _ => OTokenType.Word
            };
        }
    }
}