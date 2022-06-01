//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Models.ProjectedTokens.Exceptions;

namespace OData.Neo.Core.Services.Foundations.Projections
{
    public partial class ProjectionService : IProjectionService
    {
        private void ValidateProjectedTokens(ProjectedToken[] projectedTokens)
        {
            if(projectedTokens is null)
            {
                throw new NullProjectedTokenException();
            }
        }
    }
}
