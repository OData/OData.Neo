//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
using OData.Neo.Core.Models;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Tokenizations
{
    public partial class TokenizationServiceTests
    {
        [Fact]
        public void ShouldTokenizeRawQuery()
        {
            // given
            (string parameter, string operand, string property) =
                GetRandomQueryParameters();

            string inputQuery = $"{parameter}{operand}{property}";

            var expectedNode = new ONode
            {
                Type = ONodeType.Root,
                Value = inputQuery,

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

            // when
            ONode actualNode =
                this.tokenizationService.Tokenize(inputQuery);

            // then
            actualNode.Should().BeEquivalentTo(expectedNode);
        }
    }
}
