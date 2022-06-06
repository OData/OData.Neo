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
    public partial class TokenizationService : ITokenizationService
    {
        readonly char[] SeparatorChars = new char[] { '\'', ' ', '=', '\\' };

        public Token[] Tokenize(string rawQuery) =>
        TryCatch(() =>
        {
            ValidateOTokenQuery(rawQuery);

            return OTokenize(rawQuery, SeparatorChars).ToArray();
        });

        private static IEnumerable<Token> OTokenize(string rawQuery, char[] separatorChars)
        {
            string remainingRawQuery = rawQuery;
            Func<char, bool> NotSeparatorChar = c => !separatorChars.Contains(c);

            while (remainingRawQuery.Length > 0)
            {
                string returnValue = remainingRawQuery;
                string nextRemainingValue = string.Empty;

                var index = remainingRawQuery.IndexOfAny(separatorChars);
                if (index is not -1)
                {
                    int rangeIndex = GetRangeIndex(index);
                    Range currentRange = Range.EndAt(rangeIndex);
                    Range remainingRange = Range.StartAt(rangeIndex);

                    returnValue = remainingRawQuery[currentRange];
                    nextRemainingValue = remainingRawQuery[remainingRange];
                }

                remainingRawQuery = nextRemainingValue;

                var oTokenType = returnValue.Any(NotSeparatorChar)
                    ? OTokenType.Word
                    : OTokenType.Separator;

                yield return new Token(oTokenType, returnValue);
            }
        }

        private static int GetRangeIndex(in int index)
        {
            if (index > 0)
            {
                return index;
            }

            return 1;
        }

        private static void AddWordTokenToResult(ref List<Token> tokens, ref StringBuilder wordBuilder)
        {
            if (wordBuilder.Length > 0)
            {
                tokens.Add(new Token(OTokenType.Word, wordBuilder.ToString()));
                wordBuilder.Clear();
            }
        }

        private OTokenType GetTokenType(char tokenValue)
            => SeparatorChars.Contains(tokenValue) ? OTokenType.Separator : OTokenType.Word;
    }
}