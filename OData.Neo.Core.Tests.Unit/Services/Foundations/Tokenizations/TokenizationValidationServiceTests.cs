using OData.Neo.Core.Models.Tokens;
using OData.Neo.Core.Services.Foundations.Tokenizations;
using System;
using System.Collections.Generic;
using System.Linq;
using Tynamix.ObjectFiller;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Tokenizations
{
    public partial class TokenizationValidationServiceTests
    {
        static readonly string[] separators = new string[] { "\'", " ", "=", "\\" };

        private readonly ITokenizationValidationService tokenizationValidationService;

        public TokenizationValidationServiceTests()
        {
            tokenizationValidationService = new TokenizationValidationService();
        }

        public static (string Query, Token[] Tokens) GetRandomQuery(int numberOfTokens = 25)
        {
            int numberOfTokensToReturn = 1;
            if (numberOfTokens > 1)
            {
                IntRange intRange = new IntRange(1, numberOfTokens);
                numberOfTokensToReturn = intRange.GetValue();
            }

            List<Token> results = new List<Token>();
            while (results.Count < numberOfTokensToReturn)
            {
                TokenType nextTokenType = GetRandomTokenType();
                if (IsNotWordType(nextTokenType) || LastIsNotWordType(results))
                {
                    Token nextToken = GetNextRandomToken(nextTokenType);
                    results.Add(nextToken);
                }
            }

            string query = GetQueryFromTokens(results);
            Token[] tokens = results.ToArray();
            return new(query, tokens);
        }

        private static bool LastIsNotWordType(in List<Token> tokens)
        {
            if (tokens.Count == 0)
            {
                return true;
            }

            return IsNotWordType(tokens.Last());
        }

        private static bool IsNotWordType(in Token token)
        {
            return token.Type != TokenType.Word;
        }

        private static bool IsNotWordType(in TokenType tokenType)
        {
            return tokenType != TokenType.Word;
        }

        private static string GetQueryFromTokens(IEnumerable<Token> tokens)
        {
            IEnumerable<string> tokenValues = tokens.Select(token => token.Value);
            string result = string.Join(separator: null, values: tokenValues);
            return result;
        }

        private static TokenType GetRandomTokenType()
        {
            TokenType[] knownTokenTypes = Enum.GetValues<TokenType>();
            IntRange intRange = new IntRange(0, knownTokenTypes.Length);
            int resultIndex = intRange.GetValue();
            return knownTokenTypes[resultIndex];
        }

        private static Token GetNextRandomToken(TokenType tokenType)
        {
            string value = tokenType switch
            {
                TokenType.Word => GetRandomWordValue(),
                _ => GetRandomSeperatorValue(),
            };
            return new Token(tokenType, value);
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
