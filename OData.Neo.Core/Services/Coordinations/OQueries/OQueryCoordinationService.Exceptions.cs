//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using System.Threading.Tasks;
using OData.Neo.Core.Models.Coordinations.OQueries.Exceptions;
using OData.Neo.Core.Models.Orchestrations.OQueries.Exceptions;
using OData.Neo.Core.Models.Orchestrations.OToknizations.Exceptions;
using Xeptions;

namespace OData.Neo.Core.Services.Coordinations.OQueries
{
    public partial class OQueryCoordinationService : IOQueryCoordinationService
    {
        private delegate ValueTask<Expression> ReturningOQueryFunction();

        private async ValueTask<Expression> TryCatch(ReturningOQueryFunction returningOQueryFunction)
        {
            try
            {
                return await returningOQueryFunction();
            }
            catch (NullOQueryExpressionCoordinationException nullOQueryExpressionCoordinationException)
            {
                throw new OQueryCoordinationValidationException(nullOQueryExpressionCoordinationException);
            }
            catch (OTokenizationOrchestrationValidationException oTokenizationOrchestrationValidationException)
            { 
                throw new OQueryCoordinationDependencyValidationException(
                    oTokenizationOrchestrationValidationException.InnerException as Xeption);
            }
            catch (OTokenizationOrchestrationDependencyValidationException oTokenizationOrchestrationDependencyValidationException)
            { 
                throw new OQueryCoordinationDependencyValidationException(
                    oTokenizationOrchestrationDependencyValidationException.InnerException as Xeption);
            }
            catch (OQueryOrchestrationValidationException oQueryOrchestrationValidationException)
            { 
                throw new OQueryCoordinationDependencyValidationException(
                    oQueryOrchestrationValidationException.InnerException as Xeption);
            }
            catch (OQueryOrchestrationDependencyValidationException oQueryOrchestrationDependencyValidationException)
            {
                throw new OQueryCoordinationDependencyValidationException(
                    oQueryOrchestrationDependencyValidationException.InnerException as Xeption);
            }
        }
    }
}
