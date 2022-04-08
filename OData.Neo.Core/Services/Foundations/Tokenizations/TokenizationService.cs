//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OData.Neo.Core.Models;

namespace OData.Neo.Core.Services.Foundations.Tokenizations
{
    public class TokenizationService : ITokenizationService
    {
        readonly char[] SeparatorChars = new char[] { '\'', ' ', '=', '\\' };

        public OToken[] Tokenize(string rawQuery)
        {
            var result = new List<OToken>();
            var wordBuilder = new StringBuilder();

            foreach (var @char in rawQuery)
            {
                if (GetTokenType(@char) == OTokenType.Separator)
                {
                    if (wordBuilder.Length > 0)
                    {
                        result.Add(new OToken
                        {
                            Value = wordBuilder.ToString(),
                            Type = OTokenType.Word,
                        });
                        wordBuilder.Clear();
                    }

                    result.Add(new OToken { Value = @char.ToString(), Type = OTokenType.Separator });
                }
                else wordBuilder.Append(@char);
            }

            return result.ToArray();
        }

        private OTokenType GetTokenType(char tokenValue)
            => SeparatorChars.Contains(tokenValue) ? OTokenType.Separator : OTokenType.Word;
    }
}