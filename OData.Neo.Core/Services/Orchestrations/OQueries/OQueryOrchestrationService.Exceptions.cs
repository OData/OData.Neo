//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Threading.Tasks;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.Orchestrations.OQueries.Exceptions;

namespace OData.Neo.Core.Services.Orchestrations.OQueries
{
    public partial class OQueryOrchestrationService : IOQueryOrchestrationService
    {
        private delegate ValueTask<OExpression> ReturningOExpressionFunction();

        private async ValueTask<OExpression> TryCatch(
            ReturningOExpressionFunction returningOExpressionFunction)
        {
            try
            {
                return await returningOExpressionFunction();
            }
            catch (NullQueryOQueryOrchestrationException nullQueryOQueryOrchestrationException)
            {
                throw new OQueryOrchestrationValidationException(
                    nullQueryOQueryOrchestrationException); ;
            }
        }
    }
}
