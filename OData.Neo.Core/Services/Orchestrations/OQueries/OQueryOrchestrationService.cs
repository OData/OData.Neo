//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Services.Foundations.OExpressions;
using OData.Neo.Core.Services.Foundations.OQueries;
using OData.Neo.Core.Services.Foundations.OSqls;

namespace OData.Neo.Core.Services.Orchestrations.OQueries
{
    public partial class OQueryOrchestrationService : IOQueryOrchestrationService
    {
        private readonly IOExpressionService oExpressionService;
        private readonly IOQueryService oQueryService;
        private readonly IOSqlService oSqlService;

        public OQueryOrchestrationService(
            IOExpressionService oExpressionService,
            IOQueryService oQueryService,
            IOSqlService oSqlService)
        {
            this.oExpressionService = oExpressionService;
            this.oQueryService = oQueryService;
            this.oSqlService = oSqlService;
        }

        public ValueTask<OExpression> ProcessOTokenAsync<T>(OExpression oExpression)
        {
            throw new NotImplementedException();
        }
    }
}
