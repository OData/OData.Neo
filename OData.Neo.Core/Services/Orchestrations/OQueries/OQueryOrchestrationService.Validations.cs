//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.Orchestrations.OQueries.Exceptions;

namespace OData.Neo.Core.Services.Orchestrations.OQueries
{
    public partial class OQueryOrchestrationService : IOQueryOrchestrationService
    {
        public void ValidateOExpression(OExpression oExpression)
        {
            if (oExpression is null)
            {
                throw new NullOExpressionOQueryOrchestrationException();
            }
        }
    }
}
