//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models.ProjectedTokens;

namespace OData.Neo.Core.Services.Foundations.Projections
{
    public interface IProjectionService
    {
        ProjectedToken[] ProjectTokens(ProjectedToken[] projectedTokens);
    }
}
