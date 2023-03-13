//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.OExpressions.Exceptions;

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
