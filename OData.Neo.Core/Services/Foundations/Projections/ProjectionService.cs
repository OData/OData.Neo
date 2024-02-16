//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models.ProjectedTokens;

namespace OData.Neo.Core.Services.Foundations.Projections
{
    public partial class ProjectionService : IProjectionService
    {
        private readonly IProjectionValidationService projectionValidationService;

        public ProjectionService(IProjectionValidationService projectionValidationService)
        {
            this.projectionValidationService = projectionValidationService;
        }

        public ProjectedToken[] ProjectTokens(ProjectedToken[] projectedTokens) =>
        TryCatch(() =>
        {
            projectionValidationService.ValidateProjectedTokens(projectedTokens);

            foreach (var projectedToken in projectedTokens)
            {
                projectedToken.ProjectedType = projectedToken.RawValue switch
                {
                    "=" => ProjectedTokenType.Assignment,
                    " " => ProjectedTokenType.Space,
                    "eq" => ProjectedTokenType.Equals,
                    "," => ProjectedTokenType.Comma,
                    _ when projectedToken.RawValue.StartsWith("$") => ProjectedTokenType.Keyword,
                    _ => ProjectedTokenType.Property
                };
            }

            return projectedTokens;
        });
    }
}
