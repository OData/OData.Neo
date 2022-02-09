//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Collections.Generic;
using OData.Neo.Core.Models;

namespace OData.Neo.Core.Services.Foundations.Tokenizations
{
    public class TokenizationService : ITokenizationService
    {
        public ONode Tokenize(string rawQuery)
        {
            var items = rawQuery.Split('=');
            var parameter = items[0];
            var property = items[1];

            return new ONode
            {
                Type = ONodeType.Root,
                Value = rawQuery,

                Children = new List<ONode>
                {
                    new ONode
                    {
                        Type = ONodeType.Operator,
                        Value = parameter,

                        Children = new List<ONode>
                        {
                            new ONode
                            {
                                Type = ONodeType.Property,
                                Value = property
                            }
                        }
                    }
                }
            };
        }
    }
}
