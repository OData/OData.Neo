//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Services.Orchestrations.OQueries;
using OData.Neo.Core.Services.Orchestrations.OTokenizations;

namespace OData.Neo.Core.Services.Coordinations.OQueries
{
    public partial class OQueryCoordinationService : IOQueryCoordinationService
    {
        private readonly IOTokenizationOrchestrationService oTokenizationOrchestrationService;
        private readonly IOQueryOrchestrationService oQueryOrchestrationService;

        public OQueryCoordinationService(
            IOTokenizationOrchestrationService oTokenizationOrchestrationService,
            IOQueryOrchestrationService oQueryOrchestrationService)
        {
            this.oTokenizationOrchestrationService = oTokenizationOrchestrationService;
            this.oQueryOrchestrationService = oQueryOrchestrationService;
        }

        public ValueTask<Expression> ProcessOQueryAsync<T>(string odataQuery) => TryCatch(async () =>
        {
            ValidateOQueryExpression(odataQuery);
            OToken oToken = this.oTokenizationOrchestrationService.OTokenizeQuery(odataQuery);

            OExpression oExpression = new OExpression
            {
                OToken = oToken,
                RawQuery = odataQuery
            };

            OExpression processedOExpression = await this.oQueryOrchestrationService.ProcessOQueryAsync<T>(oExpression);

            return processedOExpression.Expression;
        });
    }
}
