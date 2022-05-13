//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Services.Foundations.Projections;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Projections
{
    public partial class ProjectionServiceTests
    {
        private readonly IProjectionService projectionService;

        public ProjectionServiceTests() =>
            projectionService = new ProjectionService();
    }
}
