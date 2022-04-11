//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models;
using OData.Neo.Core.Services.Foundations.Tokenizations;
using System;
using System.Collections.Generic;
using System.Linq;
using Tynamix.ObjectFiller;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Tokenizations
{
    public partial class TokenizationServiceTests
    {
        private static readonly string[] separators;
        private readonly ITokenizationService tokenizationService;

        static TokenizationServiceTests() =>
            separators = new string[] { "\'", " ", "=", "\\" };

        public TokenizationServiceTests() =>
            tokenizationService = new TokenizationService();

        public static (string Query, OToken[] Tokens) GetRandomQuery(int numberOfTokens = 25)
        {
            int numberOfTokensToReturn = 1;
            if (numberOfTokens > 1)
            {
                IntRange intRange = new IntRange(1, numberOfTokens);
                numberOfTokensToReturn = intRange.GetValue();
            }

            List<OToken> results = new List<OToken>();
            while (results.Count < numberOfTokensToReturn)
            {
                OTokenType nextTokenType = GetRandomTokenType();
                if (IsNotWordType(nextTokenType) || LastIsNotWordType(results))
                {
                    OToken nextToken = GetNextRandomToken(nextTokenType);
                    results.Add(nextToken);
                }
            }

            string query = GetQueryFromTokens(results);
            OToken[] tokens = results.ToArray();
            return new(query, tokens);
        }

        private static bool LastIsNotWordType(in List<OToken> tokens)
        {
            if (tokens.Count == 0)
            {
                return true;
            }

            return IsNotWordType(tokens.Last());
        }

        private static bool IsNotWordType(in OToken token)
        {
            return token.Type != OTokenType.Word;
        }

        private static bool IsNotWordType(in OTokenType tokenType)
        {
            return tokenType != OTokenType.Word;
        }

        private static string GetQueryFromTokens(IEnumerable<OToken> tokens)
        {
            IEnumerable<string> tokenValues = tokens.Select(token => token.Value);
            string result = string.Join(separator: null, values: tokenValues);
            return result;
        }

        private static OTokenType GetRandomTokenType()
        {
            OTokenType[] knownTokenTypes = Enum.GetValues<OTokenType>();
            IntRange intRange = new IntRange(0, knownTokenTypes.Length);
            int resultIndex = intRange.GetValue();
            return knownTokenTypes[resultIndex];
        }

        private static OToken GetNextRandomToken(OTokenType tokenType)
        {
            string value = tokenType switch
            {
                OTokenType.Word => GetRandomWordValue(),
                _ => GetRandomSeperatorValue(),
            };
            return new OToken(tokenType, value);
        }

        private static string GetRandomWordValue()
            => new MnemonicString().GetValue();

        private static string GetRandomSeperatorValue()
        {
            IntRange intRange = new IntRange(min: 0, max: separators.Length);
            int selector = intRange.GetValue();
            return separators[selector];
        }
    }
}