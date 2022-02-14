//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models;
using System.Linq;

namespace OData.Neo.Core.Services.Foundations.Tokenizations
{
    public class TokenizationService : ITokenizationService
    {
        public ONode Tokenize(string rawQuery) => new ONode
            {
                Type = ONodeType.Root,
                Children = ParseParameter(rawQuery)
            };

        ONode[] ParseParameter(string query)
        {
            var items = query.Split('=')[0];
            var parameter = query.Split('=')[0];
            var properties = query.Split('=')[1].Split('(')[0].Split(',');

            var children = query.Split('(').Length > 1
                ? ParseParameter(query.Split('(')[1].TrimEnd(')'))
                : null;
            
            var result = new[] {
                new ONode
                {
                    Type = ONodeType.Parameter,
                    Value = parameter
                }
            }.Union(properties.Select(p => new ONode
                    {
                        Type = ONodeType.Property,
                        Value = p
                    })
                ).ToArray();

            result.Last().Children = children;
            return result;
        }
    }
}