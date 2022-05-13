//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Linq;
using OData.Neo.Core.Models;
using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Services.Foundations.Projections;
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
            string randomKeyword = GetRandomKeyword();

            ProjectedToken[] inputProjectedTokens =
                Enumerable.Range(start: 0, count: randomNumber)
                    .Select(item => new ProjectedToken
                    {
                        ProjectedType = ProjectedType.Unidentitied,
                        RawValue = randomKeyword,
                        TokenType = OTokenType.Word
                    }).ToArray();

            ProjectedToken[] expectedProjectedTokens =
                Enumerable.Range(start: 0, count: randomNumber)
                    .Select(item => new ProjectedToken
                    {
                        ProjectedType = ProjectedType.Keyword,
                        RawValue = randomKeyword,
                        TokenType = OTokenType.Word
                    }).ToArray();


            return new TheoryData<ProjectedToken[], ProjectedToken[]>
            {
                { inputProjectedTokens, expectedProjectedTokens }
            };
        }

        private static string GetRandomKeyword() =>
            $"${new MnemonicString().GetValue()}";

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();
    }
}
