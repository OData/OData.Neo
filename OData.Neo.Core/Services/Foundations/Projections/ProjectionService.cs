//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Linq;
using OData.Neo.Core.Models.ProjectedTokens;

namespace OData.Neo.Core.Services.Foundations.Projections
{
    public class ProjectionService : IProjectionService
    {
        public ProjectedToken[] ProjectTokens(ProjectedToken[] projectedTokens)
        {
            projectedTokens[0].ProjectedType = ProjectedType.Keyword;

            return projectedTokens;
        }
    }
}
