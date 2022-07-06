//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Models.Tokens;
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
            Token[] tokens = this.tokenizationService.Tokenize(query);
            ProjectedToken[] projectedTokens = ProjectTokens(tokens);

            return OTokenize(projectedTokens);
        }

        private ProjectedToken[] ProjectTokens(Token[] tokens)
        {
            ProjectedToken[] projectedTokens =
                tokens.Select(token => new ProjectedToken
                {
                    ProjectedType = ProjectedTokenType.Unidentified,
                    RawValue = token.Value,
                    TokenType = token.Type
                }).ToArray();

            return this.projectionService.ProjectTokens(projectedTokens);
        }

        private OToken OTokenize(ProjectedToken[] projectedTokens)
        {
            OToken[] otokens =
                projectedTokens.Select(projectedToken => new OToken
                {
                    RawValue = projectedToken.RawValue,
                    ProjectedType = projectedToken.ProjectedType,
                    Type = OTokenType.Unidentified
                }).ToArray();

            return this.otokenizationService.OTokenize(otokens);
        }
    }
}
