//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using OData.Neo.Core.Ast;
using OData.Neo.Core.Parser;
using OData.Neo.Core.Services;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services
{
    public class FilterBinderTests
    {
        [Fact]
        public void BindFilter_ShouldReturnExpression()
        {
            string filter = "Name eq 'abc'";

            FilterBinder binder = new FilterBinder(new MyQueryOptionParser(), new QueryNodeBinder());

            Expression exp = binder.BindFilter(filter, new BinderContext(typeof(Customer)));

            Assert.Equal(ExpressionType.Lambda, exp.NodeType);

            string expLiteral = exp.ToString();

            Assert.Equal("$it => ($it.Name == \"abc\")", expLiteral);
        }
    }

    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class MyQueryOptionParser : IQueryOptionParser
    {
        public FilterClause ParseFilter(string filter, ParserContext context)
        {
            RangeVariableReferenceNode range = new RangeVariableReferenceNode
            {
                Name = "$it"
            };

            SingleValueNode left = new SingleValuePropertyAccessNode
            {
                Name = "Name",
                Source = range
            };

            SingleValueNode right = new ConstantNode("abc", "'abc'");

            return new FilterClause
            {
                Expression = new BinaryOperatorNode(BinaryOperatorKind.Equal, left, right),
                Variable = new RangeVariable
                {
                    Name = "$it",
                    Type = typeof(Customer)
                }
            };
        }
    }
}
