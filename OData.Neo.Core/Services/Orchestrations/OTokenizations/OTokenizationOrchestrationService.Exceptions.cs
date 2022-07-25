//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using OData.Neo.Core.Models.Orchestrations.OToknizations.Exceptions;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Models.OTokens.Exceptions;
using OData.Neo.Core.Models.ProjectedTokens.Exceptions;
using OData.Neo.Core.Models.Tokens.Exceptions;
using Xeptions;

namespace OData.Neo.Core.Services.Orchestrations.OTokenizations
{
    public partial class OTokenizationOrchestrationService : IOTokenizationOrchestrationService
    {
        private delegate OToken ReturningOTokenFunction();

        private OToken TryCatch(ReturningOTokenFunction returningOTokenFunction)
        {
            try
            {
                return returningOTokenFunction();
            }
            catch (NullQueryOTokenizationOrchestrationException nullQueryException)
            {
                throw new OTokenizationOrchestrationValidationException(
                    nullQueryException);
            }
            catch (TokenValidationException tokenValidationException)
            {
                throw new OTokenizationOrchestrationDependencyValidationException(
                    tokenValidationException.InnerException as Xeption);
            }
            catch (ProjectedTokenValidationException projectedTokenValidationException)
            {
                throw new OTokenizationOrchestrationDependencyValidationException(
                    projectedTokenValidationException.InnerException as Xeption);
            }
            catch (OTokenValidationException oTokenValidationException)
            {
                throw new OTokenizationOrchestrationDependencyValidationException(
                    oTokenValidationException.InnerException as Xeption);
            }
            catch (TokenServiceException tokenServiceException)
            {
                throw new OTokenizationOrchestrationDependencyException(
                    tokenServiceException.InnerException as Xeption);
            }
            catch (ProjectedTokenServiceException projectedTokenServiceException)
            {
                throw new OTokenizationOrchestrationDependencyException(
                    projectedTokenServiceException.InnerException as Xeption);
            }
            catch (OTokenServiceException oTokenServiceException)
            {
                throw new OTokenizationOrchestrationDependencyException(
                    oTokenServiceException.InnerException as Xeption);
            }
            catch (Exception exception)
            {
                var failedTokenizationOrchestrationServiceException =
                    new FailedTokenizationOrchestrationServiceException(
                        exception);

                throw new OTokenizationOrchestrationServiceException(
                    failedTokenizationOrchestrationServiceException);
            }
        }
    }
}
