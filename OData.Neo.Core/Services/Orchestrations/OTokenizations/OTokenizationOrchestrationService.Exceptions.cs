//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models.Orchestrations.OToknizations.Exceptions;
using OData.Neo.Core.Models.OTokens;

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
        }
    }
}
