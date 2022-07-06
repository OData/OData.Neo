//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Services.Foundations.OTokenizations;
using OData.Neo.Core.Services.Foundations.Projections;
using OData.Neo.Core.Services.Foundations.Tokenizations;

namespace OData.Neo.Core.Services.Orchestrations.OTokenizations
{
    public partial class OTokenizationOrchestrationService : IOTokenizationOrchestrationService
    {
        private readonly ITokenizationService tokenizationService;
        private readonly IProjectionService projectionService;
        private readonly IOTokenizationService otokenizationService;

        public OTokenizationOrchestrationService(
            ITokenizationService tokenizationService,
            IProjectionService projectionService,
            IOTokenizationService oTokenizationService)
        {
            this.tokenizationService = tokenizationService;
            this.projectionService = projectionService;
            this.otokenizationService = oTokenizationService;
        }

        public OToken OTokenizeQuery(string query)
        {
            throw new NotImplementedException();
        }
    }
}
