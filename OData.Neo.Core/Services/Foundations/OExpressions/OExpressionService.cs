//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using OData.Neo.Core.Brokers.Expressions;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Models.ProjectedTokens;

namespace OData.Neo.Core.Services.Foundations.OExpressions
{
    public partial class OExpressionService : IOExpressionService
    {
        private readonly IExpressionBroker expressionBroker;

        public OExpressionService(IExpressionBroker expressionBroker) =>
            this.expressionBroker = expressionBroker;

        public ValueTask<OExpression> GenerateOExpressionAsync<T>(OExpression oExpression) =>
        TryCatch(async () =>
        {
            ValidateOExpression(oExpression);
            string linqExp = CovertToLinqExp(oExpression.OToken);

            Expression expression =
                await expressionBroker.GenerateExpressionAsync<T>(linqExp);

            oExpression.Expression = expression;

            return oExpression;
        });

        public IQueryable ApplyExpression<T>(IQueryable<T> sources, OExpression expression) =>
        TryCatch(() => 
        {
            ValidateSource(sources);
            ValidateOExpressionOnApply(expression);

            return this.expressionBroker.ApplyExpression(sources, expression.Expression);
        });

        private string CovertToLinqExp(OToken token)
        {
            var stringBuilder = new StringBuilder();

            foreach (OToken child in token.Children)
            {
                if (child.Type == OTokenType.Select)
                {
                    string properties = string.Join(
                        separator: ",",
                        values: child.Children
                        .Where(c => c.ProjectedType == ProjectedTokenType.Property)
                        .Select(child => $"obj.{child.RawValue}"));

                    stringBuilder.Append($"Select(obj => new {{{properties}}})");
                }
            }

            return stringBuilder.ToString();
        }
    }
}
