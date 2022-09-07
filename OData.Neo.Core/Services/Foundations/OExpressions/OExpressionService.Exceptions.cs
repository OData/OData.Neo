//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Threading.Tasks;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.OExpressions.Exceptions;

namespace OData.Neo.Core.Services.Foundations.OExpressions
{
    public partial class OExpressionService : IOExpressionService
    {
        private delegate ValueTask<OExpression> ReturningOExpressionFunction();

        private async ValueTask<OExpression> TryCatch(
            ReturningOExpressionFunction returningOExpressionFunction)
        {
            try
            {
                return await returningOExpressionFunction();
            }
            catch (NullOExpressionException nullOExpressionException)
            {
                throw new OExpressionValidationException(nullOExpressionException);
            }
            catch (InvalidOExpressionException invalidOExpressionException)
            {
                throw new OExpressionValidationException(invalidOExpressionException);
            }
        }
    }
}
