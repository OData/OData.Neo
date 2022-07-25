//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models.Orchestrations.OToknizations.Exceptions;

namespace OData.Neo.Core.Services.Orchestrations.OTokenizations
{
    public partial class OTokenizationOrchestrationService : IOTokenizationOrchestrationService
    {
        private static void ValidateQuery(string query)
        {
            if (query is null)
            {
                throw new NullQueryOTokenizationOrchestrationException();
            }
        }
    }
}
