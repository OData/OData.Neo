//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models;
using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Services.Foundations.Projections;
using System.Collections.Generic;
using Tynamix.ObjectFiller;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Projections
{
    public partial class ProjectionServiceTests
    {
        private readonly IProjectionService projectionService;

        public ProjectionServiceTests() =>
            projectionService = new ProjectionService();

        public static TheoryData<ProjectedToken[], ProjectedToken[]> GetProjectedTokens()
        {
            int randomNumber = GetRandomNumber();
            var inputProjectedTokens = new List<ProjectedToken>();
            var expectedProjectedTokens = new List<ProjectedToken>();

            for (int i = 0; i < randomNumber; i++)
            {
                string randomKeyword = GetRandomKeyword();

                inputProjectedTokens.Add(item: new ProjectedToken
                {
                    ProjectedType = ProjectedType.Unidentified,
                    RawValue = randomKeyword,
                    TokenType = OTokenType.Word
                });

                expectedProjectedTokens.Add(item: new ProjectedToken
                {
                    ProjectedType = ProjectedType.Keyword,
                    RawValue = randomKeyword,
                    TokenType = OTokenType.Word
                });
            }

            return new TheoryData<ProjectedToken[], ProjectedToken[]>
            {
                {
                    inputProjectedTokens.ToArray(),
                    expectedProjectedTokens.ToArray()
                }
            };
        }

        private static string GetRandomKeyword() =>
            $"${new MnemonicString().GetValue()}";

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();
    }
}
