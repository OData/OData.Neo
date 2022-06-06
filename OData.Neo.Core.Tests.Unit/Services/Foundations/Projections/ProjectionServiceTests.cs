//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models;
using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Services.Foundations.Projections;
using System.Collections.Generic;
using System.Linq;
using Tynamix.ObjectFiller;
using Xunit;
using Randomizer = System.Random;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Projections
{
    public partial class ProjectionServiceTests
    {
        private readonly IProjectionService projectionService;

        public ProjectionServiceTests() =>
            projectionService = new ProjectionService();

        public static TheoryData<ProjectedToken[], ProjectedToken[]> ProjectedTokens()
        {
            int randomNumber = GetRandomNumber();
            var inputProjectedTokens = new List<ProjectedToken>();
            var expectedProjectedTokens = new List<ProjectedToken>();

            for (int i = 0; i < randomNumber; i++)
            {
                (string rawValue, ProjectedType projectedType, TokenType tokenType) =
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

        private static ProjectedToken[] CreateRandomProjectedTokens(ProjectedToken addedProjectedToken)
        {
            List<ProjectedToken> randomProjectedTokens = 
                CreateProjectedTokenFiller()
                    .Create(count: GetRandomNumber())
                        .ToList();
            
            randomProjectedTokens.Add(addedProjectedToken);

            return ShuffleProjectedTokens(randomProjectedTokens).ToArray();
        }

        private static ProjectedToken[] CreateRandomProjectedTokens() =>
            CreateProjectedTokenFiller().Create(count: GetRandomNumber()).ToArray();

        private static List<ProjectedToken> ShuffleProjectedTokens(List<ProjectedToken> projectedTokens)
        {
            var randomizer = new Randomizer();

            return projectedTokens
                .OrderBy(token => randomizer.Next())
                    .ToList(); ;
        }

        private static (string rawValue, ProjectedType projectedType, TokenType tokenType)
            GetRandomProjectedTokenProperties()
        {
            var listOfProjectedTokenProperties =
                new List<(string rawValue, ProjectedType projectedType, TokenType tokenType)>()
                {
                    (GetRandomKeyword(), ProjectedType.Keyword, TokenType.Word),
                    ("=", ProjectedType.Assignment, TokenType.Separator),
                    (GetRandomWord(), ProjectedType.Property, TokenType.Word),
                    (" ", ProjectedType.Space, TokenType.Separator),
                    ("eq", ProjectedType.Equals, TokenType.Word),
                    (",", ProjectedType.Comma, TokenType.Separator)
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

        private static Filler<ProjectedToken> CreateProjectedTokenFiller() =>
            new Filler<ProjectedToken>();
    }
}
