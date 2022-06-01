//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models.ProjectedTokens;

namespace OData.Neo.Core.Services.Foundations.Projections
{
    public class ProjectionService : IProjectionService
    {
        public ProjectedToken[] ProjectTokens(ProjectedToken[] projectedTokens)
        {
            foreach (var projectedToken in projectedTokens)
            {
                projectedToken.ProjectedType = projectedToken.RawValue switch
                {
                    "=" => ProjectedType.Assignment,
                    " " => ProjectedType.Space,
                    "eq" => ProjectedType.Equals,
                    "," => ProjectedType.Comma,
                    _ when projectedToken.RawValue.StartsWith("$") => ProjectedType.Keyword,
                    _ => ProjectedType.Property
                };
            }

            return projectedTokens;
        }
    }
}
