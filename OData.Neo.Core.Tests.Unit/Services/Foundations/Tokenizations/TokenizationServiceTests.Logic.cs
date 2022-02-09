//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
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
                Children = new List<ONode>
                {
                    new ONode
                    {
                        Type = ONodeType.Parameter,
                        Value = parameter,
                    },
                    new ONode
                    {
                        Type = ONodeType.Property,
                        Value = property
                    }
                }
            };

            // when
            ONode actualNode =
                this.tokenizationService.Tokenize(inputQuery);

            // then
            actualNode.Should().BeEquivalentTo(expectedNode);
        }

        [Fact]
        public void ShouldTokenizeMultipleRawQuery()
        {
            // given
            (string parameter, string operand, string[] properties) =
                GetRandomQueryWithMultipleProperties();

            string propertiesArray = string.Join(',', properties);
            string inputQuery = $"{parameter}{operand}{propertiesArray}";

            var rootChildren = new List<ONode> {
                new ONode
                {
                    Type = ONodeType.Parameter,
                    Value = parameter
                }};

            List<ONode> childrenNodes =
                properties.Select(property =>
                    new ONode
                    {
                        Type = ONodeType.Property,
                        Value = property
                    }).ToList();

            rootChildren.AddRange(childrenNodes);

            var expectedNode = new ONode
            {
                Type = ONodeType.Root,
                Children = rootChildren
            };

            // when
            ONode actualNode =
                this.tokenizationService.Tokenize(inputQuery);

            // then
            actualNode.Should().BeEquivalentTo(expectedNode);
        }
    }
}
