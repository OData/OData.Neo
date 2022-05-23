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
                (string rawValue, ProjectedType projectedType, OTokenType tokenType) =
                    GetRandomProjectedTokenProperties();

                inputProjectedTokens.Add(item: new ProjectedToken
                {
                    ProjectedType = ProjectedType.Unidentified,
                    RawValue = rawValue,
                    TokenType = tokenType
                });

                expectedProjectedTokens.Add(item: new ProjectedToken
                {
                    ProjectedType = projectedType,
                    RawValue = rawValue,
                    TokenType = tokenType
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

        static (string rawValue, ProjectedType projectedType, OTokenType tokenType)
            GetRandomProjectedTokenProperties()
        {
            var listOfProjectedTokenProperties =
                new List<(string rawValue, ProjectedType projectedType, OTokenType tokenType)>()
                {
                    (GetRandomKeyword(), ProjectedType.Keyword, OTokenType.Word),
                    ("=", ProjectedType.Assignment, OTokenType.Separator),
                    (GetRandomWord(), ProjectedType.Property, OTokenType.Word),
                    (" ", ProjectedType.Space, OTokenType.Separator)
                };

            int randomIndex =
                new IntRange(min: 0, max: listOfProjectedTokenProperties.Count).GetValue();

            return listOfProjectedTokenProperties[randomIndex];
        }

        private static string GetRandomWord() =>
            new MnemonicString().GetValue();

        private static string GetRandomKeyword() =>
            $"${GetRandomWord()}";

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();
    }
}
