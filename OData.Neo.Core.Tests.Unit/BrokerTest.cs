using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OData.Neo.Core.Brokers.Expressions;
using Xunit;

namespace OData.Neo.Core.Tests.Unit
{
    public class BrokerTest
    {
        [Fact]
        public async Task ShouldReturnExpression()
        {
            var expressionBroker = new ExpressionBroker();

            Expression actualExpression =
                await expressionBroker.GenerateExpressionAsync<Student>(
                    linqExpression: "Select(s => new {s.Name})");


            Assert.True(actualExpression is not null);
        }
    }

    public class Student
    {
        public string Name { get; set; }
    }
}
