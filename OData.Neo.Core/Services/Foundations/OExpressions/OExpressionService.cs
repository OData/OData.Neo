//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OData.Neo.Core.Brokers.Expressions;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.OExpressions.Exceptions;
using OData.Neo.Core.Models.OTokens;

namespace OData.Neo.Core.Services.Foundations.OExpressions
{
    public partial class OExpressionService : IOExpressionService
    {
        private readonly IExpressionBroker expressionBroker;

        public OExpressionService(IExpressionBroker expressionBroker) =>
            this.expressionBroker = expressionBroker;

        public async ValueTask<OExpression> GenerateOExpressionAsync<T>(OExpression oExpression)
        {
            try
            {
                if (oExpression is null)
                {
                    throw new NullOExpressionException();
                }

                string linqExp = CovertToLinqExp(oExpression.OToken);

                Expression expression =
                    await expressionBroker.GenerateExpressionAsync<T>(linqExp);

                oExpression.Expression = expression;

                return oExpression;
            }
            catch (NullOExpressionException nullException)
            {
                throw new OExpressionValidationException(nullException);
            }
        }

        private string CovertToLinqExp(OToken token)
        {
            StringBuilder sb = new StringBuilder();

            foreach (OToken child in token.Children)
            {
                if (child.Type == OTokenType.Select)
                {
                    string properties = string.Join(",", child.Children.Select(x => $"obj.{x.RawValue}"));
                    sb.Append($"Select(obj => new {{{properties}}})");
                }
            }

            return sb.ToString();
        }
    }
}
