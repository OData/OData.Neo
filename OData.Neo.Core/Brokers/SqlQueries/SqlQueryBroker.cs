//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OData.Neo.Core.Brokers.Queries;

namespace OData.Neo.Core.Brokers.SqlQueries
{
    public class SqlQueryBroker<T> : DbContext, ISqlQueryBroker where T : class
    {
        public DbSet<T> DataSource { get; set; }

        public string GetSqlQuery(Expression expression)
        {
            IQueryable<T> source = Set<T>().AsQueryable();

            return Apply(source, expression).ToQueryString();
        }

        public IQueryable Apply(IQueryable<T> source, Expression expression)
        {
            var methodCallExpression = (MethodCallExpression)expression;
            var unaryExpression = methodCallExpression.Arguments[1] as UnaryExpression;

            return (IQueryable)methodCallExpression.Method.Invoke(
                obj: null,
                parameters: new object[] { source, unaryExpression.Operand });
        }

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
