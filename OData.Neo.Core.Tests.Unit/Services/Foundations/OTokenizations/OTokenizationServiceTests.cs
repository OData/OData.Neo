//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Services.Foundations.OTokenizations;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.OTokenizations
{
    public partial class OTokenizationServiceTests
    {
        private readonly IOTokenizationService tokenizationService;

        public OTokenizationServiceTests() =>
            this.tokenizationService = new OTokenizationService();
    }
}
