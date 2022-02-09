//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using OData.Neo.Core.Models;

namespace OData.Neo.Core.Services.Foundations.Tokenizations
{
    public class TokenizationService : ITokenizationService
    {
        public ONode Tokenize(string rawQuery)
        {
            var items = rawQuery.Split('=');
            var parameter = items[0];
            var propertyChildren = items[1]
                .Split(',')
                .Select(s => new ONode {
                    Type = ONodeType.Property,
                    Value = s
                })
                .ToList();

            var rootChildren = new List<ONode> {
                new ONode {
                    Type = ONodeType.Parameter,
                    Value = parameter,
                }
            };

            rootChildren.AddRange(propertyChildren);

            return new ONode { 
                Type = ONodeType.Root,
                Children = rootChildren
            };
        }
    }
}
