using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OData.Neo.Core.Brokers.Expressions;
using OData.Neo.Core.Brokers.SqlQueries;
using OData.Neo.Core.Services.Coordinations.OQueries;
using OData.Neo.Core.Services.Foundations.OExpressions;
using OData.Neo.Core.Services.Foundations.OQueries;
using OData.Neo.Core.Services.Foundations.OSqls;
using OData.Neo.Core.Services.Foundations.OTokenizations;
using OData.Neo.Core.Services.Foundations.Projections;
using OData.Neo.Core.Services.Foundations.Tokenizations;
using OData.Neo.Core.Services.Orchestrations.OQueries;
using OData.Neo.Core.Services.Orchestrations.OTokenizations;

namespace OData.Neo.Core.Clients.Extensions
{
    public static class ODataEnumerableClient
    {
        public static async ValueTask<IQueryable> ApplyODataQueryAsync<T>(
            this IQueryable<T> queryable,
            string odataQuery) where T : class
        {
            var otokenizationService = new OTokenizationService();
            var projectionService = new ProjectionService();
            var tokenizationService = new TokenizationService();

            var oTokenizationOrchestrationService =
                new OTokenizationOrchestrationService(
                    tokenizationService,
                    projectionService,
                    otokenizationService);

            var expressionBroker = new ExpressionBroker();
            var sqlQueryBroker = new SqlQueryBroker<T>();

            var oExpressionService = new OExpressionService(expressionBroker);
            var oQueryService = new OQueryService(sqlQueryBroker);
            var oSqlService = new OSqlService(sqlQueryBroker);

            var oQueryOrchestrationService =
                new OQueryOrchestrationService(
                    oExpressionService,
                    oQueryService,
                    oSqlService);

            var oQueryCoordinationService = new OQueryCoordinationService(
                oTokenizationOrchestrationService,
                oQueryOrchestrationService);

            Expression oQueryExpression =
                await oQueryCoordinationService
                    .ProcessOQueryAsync<T>(odataQuery);

            return Execute(queryable, oQueryExpression);
        }

        public static IQueryable Execute<T>(IQueryable<T> sources, Expression exp)
        {
            MethodCallExpression call = exp as MethodCallExpression;

            //  Select(...)
            MethodInfo methodInfo = call.Method;

            UnaryExpression unary = call.Arguments[1] as UnaryExpression;

            LambdaExpression lambda = unary.Operand as LambdaExpression;

            // Delegate delegateFunc = lambda.Compile();

            return methodInfo.Invoke(null, new object[] { sources, lambda }) as IQueryable;
        }
    }
}
