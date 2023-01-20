//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.OExpressions.Exceptions;
using OData.Neo.Core.Models.Orchestrations.OQueries.Exceptions;
using Xeptions;

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
            catch (NullOExpressionOQueryOrchestrationException nullQueryOQueryOrchestrationException)
            {
                throw new OQueryOrchestrationValidationException(
                    nullQueryOQueryOrchestrationException);
            }
            catch (OExpressionValidationException oExpressionValidationException)
            {
                throw new OQueryOrchestrationDependencyValidationException(
                    oExpressionValidationException.InnerException as Xeption);
            }
            catch (OExpressionDependencyException oExpressionDependencyException)
            {
                throw new OQueryOrchestrationDependencyException(
                    oExpressionDependencyException.InnerException as Xeption);
            }
        }
    }
}
