//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using KellermanSoftware.CompareNetObjects;
using Moq;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Models.OTokens.Exceptions;
using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Models.ProjectedTokens.Exceptions;
using OData.Neo.Core.Models.Tokens.Exceptions;
using OData.Neo.Core.Services.Foundations.OTokenizations;
using OData.Neo.Core.Services.Foundations.Projections;
using OData.Neo.Core.Services.Foundations.Tokenizations;
using OData.Neo.Core.Services.Orchestrations.OTokenizations;
using Tynamix.ObjectFiller;
using Xeptions;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Orchestrations.OTokenizations
{
    public partial class OTokenizationOrchestrationServiceTests
    {
        private readonly Mock<ITokenizationService> tokenizationServiceMock;
        private readonly Mock<IProjectionService> projectionServiceMock;
        private readonly Mock<IOTokenizationService> otokenizationServiceMock;
        private readonly ICompareLogic compareLogic;
        private readonly IOTokenizationOrchestrationService otokenizationOrchestrationService;

        public OTokenizationOrchestrationServiceTests()
        {
            this.tokenizationServiceMock = new Mock<ITokenizationService>();
            this.projectionServiceMock = new Mock<IProjectionService>();
            this.otokenizationServiceMock = new Mock<IOTokenizationService>();
            this.compareLogic = new CompareLogic();

            this.otokenizationOrchestrationService = new OTokenizationOrchestrationService(
                tokenizationService: this.tokenizationServiceMock.Object,
                projectionService: this.projectionServiceMock.Object,
                oTokenizationService: this.otokenizationServiceMock.Object);
        }

        public static TheoryData DependencyValidationExceptions()
        {
            string randomMessage = GetRandomString();
            var someException = new Xeption(randomMessage);

            return new TheoryData<Xeption>
            {
                new TokenValidationException(someException),
                new ProjectedTokenValidationException(someException),
                new OTokenValidationException(someException),
            };
        }

        private Expression<Func<ProjectedToken[], bool>> SameProjectedTokensAs(
            ProjectedToken[] expectedProjectedTokens)
        {
            return actualProjectedTokens =>
                this.compareLogic.Compare(
                    expectedProjectedTokens,
                    actualProjectedTokens)
                        .AreEqual;
        }

        private Expression<Func<OToken[], bool>> SameOTokensAs(
            OToken[] expectedOTokens)
        {
            return actualOTokens =>
                this.compareLogic.Compare(
                    expectedOTokens,
                    actualOTokens)
                        .AreEqual;
        }
        
        private static OToken CreateRandomOToken() =>
            CreateOTokenFiller().Create();

        private static string GetRandomString() =>
            new MnemonicString(wordCount: GetRandomCount()).GetValue();

        private static int GetRandomCount() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static Filler<OToken> CreateOTokenFiller() =>
            new Filler<OToken>();
    }
}
