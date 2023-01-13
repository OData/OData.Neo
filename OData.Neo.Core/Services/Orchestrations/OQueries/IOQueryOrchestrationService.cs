//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Threading.Tasks;
using OData.Neo.Core.Models.OExpressions;

namespace OData.Neo.Core.Services.Orchestrations.OQueries
{
    public interface IOQueryOrchestrationService
    {
        ValueTask<OExpression> ProcessOTokenAsync<T>(OExpression oExpression);
    }
}
