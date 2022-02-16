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

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Tokenizations
{
    public partial class TokenizationServiceTests
    {
        private readonly ITokenizationService tokenizationService;

        public TokenizationServiceTests() => tokenizationService = new TokenizationService();

        public static (string Parameter, string Operand, string Property) GetRandomQueryParameters()
        {
            string randomParameter = $"${new MnemonicString().GetValue()}";
            string randomProperty = new MnemonicString().GetValue();
            return (randomParameter, "=", randomProperty);
        }

        public static (string Parameter, string Operand, string[] Property) GetRandomQueryWithMultipleProperties()
        {
            string randomParameter = $"${new MnemonicString().GetValue()}";

            string[] randomProperties = Enumerable.Range(start: 0, count: GetRandomNumber())
                    .Select(item => new MnemonicString().GetValue())
                    .ToArray();

            return (randomParameter, "=", randomProperties);
        }

        public static (
            (string Parameter, string Operand, string[] Property) Inner,
            (string Parameter, string Operand, string[] Property) Outer
        )
            GetRandomQueryWithMultipleNestedProperties() => (
                GetRandomQueryWithMultipleProperties(),
                GetRandomQueryWithMultipleProperties()
            );

        public static ONode GetRandomQueryModel() => new()
        {
            Type = ONodeType.Root,
            Children = GetRandomONodeArray()
        };

        public static ONode[] GetRandomONodeArray()
        {
            var rootChildren = BuildChildrenForQueryPart(GetRandomQueryWithMultipleProperties());
            rootChildren
                .Skip(1)
                .Take(GetRandomNumber())
                .Last()
                .Children = GetRandomNumber() > 3
                    ? GetRandomONodeArray()
                    : null;

            return rootChildren.ToArray();
        }

        public static ONode[] BuildChildrenForQueryPart((string Parameter, string Operand, string[] Property) part) 
            => new List<ONode> { new ONode { Type = ONodeType.Parameter, Value = part.Parameter } }
                .Union(part.Property
                    .Select(property => new ONode { Type = ONodeType.Property, Value = property }))
                    .ToArray();

        private static int GetRandomNumber() => new IntRange(min: 2, max: 10).GetValue();

        public string ToJson(ONode source)
        {
            var children = source.Children != null
                ? $"[{string.Join(",", source.Children.Select(c => c.ToJson()))}]"
                : null;

            return children != null
                ? $"{{ \"Type\": \"{source.Type}\", \"Value\": \"{source.Value}\" \"Children\": {children} }}"
                : $"{{ \"Type\": \"{source.Type}\", \"Value\": \"{source.Value}\" }}";
        }

        public string ToQueryString(ONode source)
        {
            throw new NotImplementedException();
        }
    }
}
