//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models;
using OData.Neo.Core.Models.OTokens.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OData.Neo.Core.Services.Foundations.Tokenizations
{
    public class TokenizationService : ITokenizationService
    {
        readonly char[] SeparatorChars = new char[] { '\'', ' ', '=', '\\' };

        public OToken[] Tokenize(string rawQuery)
        {
            if (string.IsNullOrEmpty(rawQuery))
            {
                throw new OTokenValidationException(null);
            }

            var result = new List<OToken>();
            var wordBuilder = new StringBuilder();

            foreach (var @char in rawQuery)
            {
                if (GetTokenType(@char) == OTokenType.Separator)
                {
                    AddWordTokenToResult(ref result, ref wordBuilder);
                    result.Add(new OToken(OTokenType.Separator, @char.ToString()));
                }
                else
                {
                    wordBuilder.Append(@char);
                }
            }

            AddWordTokenToResult(ref result, ref wordBuilder);

            return result.ToArray();
        }

        private static void AddWordTokenToResult(ref List<OToken> tokens, ref StringBuilder wordBuilder)
        {
            if (wordBuilder.Length > 0)
            {
                tokens.Add(new OToken(OTokenType.Word, wordBuilder.ToString()));
                wordBuilder.Clear();
            }
        }

        private OTokenType GetTokenType(char tokenValue)
            => SeparatorChars.Contains(tokenValue) ? OTokenType.Separator : OTokenType.Word;
    }
}