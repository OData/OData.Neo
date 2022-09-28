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
        private static void ValidateOExpression(OExpression oExpression)
        {
            if (oExpression is null)
            {
                throw new NullOExpressionException();
            }

            var invalidOExpressionException = new InvalidOExpressionException();

            if (oExpression.OToken is null)
            {
                invalidOExpressionException.UpsertDataList(key: nameof(OExpression.OToken),
                    value: "Value is required");

                throw invalidOExpressionException;
            }
        }
    }
}
