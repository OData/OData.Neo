using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using OData.Neo.Core.Brokers.Expressions;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Services.Foundations.OExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services
{
    public class JustTryingStuff
    {
        OExpression exampleOExpression = new OExpression
        {
            OToken = new OToken
            {
                Type = OTokenType.Root,

                Children = new List<OToken>
                    {
                        new OToken
                        {
                            RawValue = "$select",
                            Type = OTokenType.Select,
                            ProjectedType = ProjectedTokenType.Keyword,
                            Children = new List<OToken>
                            {
                                new OToken
                                {
                                    RawValue = "Name",
                                    Type = OTokenType.Property,
                                    ProjectedType = ProjectedTokenType.Property,
                                },

                                new OToken
                                {
                                    RawValue = "JobTitle",
                                    Type = OTokenType.Property,
                                    ProjectedType = ProjectedTokenType.Property,
                                }
                            }
                        }
                    }
            }
        };





        // OData:
        // $select=Name,JobTitle
        // Services ? => OExpression 
        // OExpression => OExpressionService => oExpression.Expression (populated)
        // EF.Set<T>().Apply(oExpression.Expression) => sql
        // sql => OToken
        // OToken => OData





        [Fact]
        public async ValueTask ExpressionsCanBeConvertedToSQL()
        {
            var service = new OExpressionService(new ExpressionBroker());

            var oExpressionWithComputedExpression = 
                await service.GenerateOExpressionAsync<Person>(exampleOExpression);

            var actualSQL = GetSQLFromExpression<Person>(oExpressionWithComputedExpression);
            var expectedSQL = "SELECT [p].[Name], [p].[JobTitle]\r\nFROM [People] AS [p]";
            actualSQL.Should().BeEquivalentTo(expectedSQL);
        }

        [Fact]
        public async ValueTask ExpressionsCanBeConvertedToOData()
        {
            var service = new OExpressionService(new ExpressionBroker());

            var oExpressionWithComputedExpression =
                await service.GenerateOExpressionAsync<Person>(exampleOExpression);

            var actualSQL = GetSQLFromExpression<Person>(oExpressionWithComputedExpression);
            OToken token = GetTokensFromSQL(actualSQL);
            token.Should().BeEquivalentTo(exampleOExpression.OToken);
        }


        public string GetSQLFromExpression<TSet>(OExpression oExpression)
            where TSet : class
        {
            using var context = new TestDbContext<TSet>();
            var source = context
                .Set<TSet>()
                .AsQueryable();

            return Apply(source, oExpression.Expression)
                .ToQueryString();
        }

        OToken GetTokensFromSQL(string sql)
        {
            var tokenValues = sql
                .Replace("\r\n", " ")
                .Split(' ');


            var sqlKeywords = new[] { "FROM" };

            OToken result = new OToken
            {
                Type = OTokenType.Root,
                Children = new List<OToken>
                    {
                        new OToken
                        {
                            RawValue = $"${tokenValues[0]}",
                            Type = OTokenType.Select,
                            ProjectedType = ProjectedTokenType.Keyword,
                            Children = new List<OToken>()
                        }
                    }
            };

            int i = 1;
            while (!sqlKeywords.Contains(tokenValues[i]))
            {
                result.Children[0].Children.Add(
                    new OToken
                    {
                        RawValue = tokenValues[i].Trim(",".ToCharArray()), // [p].[Name] // [p].[JobTitle]
                        Type = OTokenType.Property,
                        ProjectedType = ProjectedTokenType.Property,
                    });

                i++;
            }

            return result;
        }

        public IQueryable Apply<T>(IQueryable<T> source, Expression expression)
        {
            var theCall = (MethodCallExpression)expression;
            var thing = theCall.Arguments[1] as UnaryExpression;
            return (IQueryable)theCall.Method.Invoke(null, new object[] { source, thing.Operand });
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string JobTitle { get; set; }
    }

    public class TestDbContext<T> : DbContext
        where T : class
    {
        public DbSet<T> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=FakeDb;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<T>().HasNoKey();
        }
    }
}