using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Models.Tokens;
using OData.Neo.Core.Services.Foundations.Projections;
using System.Collections.Generic;
using System.Linq;
using Tynamix.ObjectFiller;
using Xunit;
using Randomizer = System.Random;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Projections
{
    public partial class ProjectionValidationServiceTests
    {
        private readonly IProjectionValidationService projectionValidationService;
        
        public ProjectionValidationServiceTests()
        {
            projectionValidationService = new ProjectionValidationService();
        }

        public static TheoryData<ProjectedToken[], ProjectedToken[]> ProjectedTokens()
        {
            int randomNumber = GetRandomNumber();
            var inputProjectedTokens = new List<ProjectedToken>();
            var expectedProjectedTokens = new List<ProjectedToken>();

            for (int i = 0; i < randomNumber; i++)
            {
                (string rawValue, ProjectedTokenType projectedType, TokenType tokenType) =
                    GetRandomProjectedTokenProperties();

                inputProjectedTokens.Add(item: new ProjectedToken
                {
                    ProjectedType = ProjectedTokenType.Unidentified,
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

        private static (string rawValue, ProjectedTokenType projectedType, TokenType tokenType)
            GetRandomProjectedTokenProperties()
        {
            var listOfProjectedTokenProperties =
                new List<(string rawValue, ProjectedTokenType projectedType, TokenType tokenType)>()
                {
                    (GetRandomKeyword(), ProjectedTokenType.Keyword, TokenType.Word),
                    ("=", ProjectedTokenType.Assignment, TokenType.Separator),
                    (GetRandomWord(), ProjectedTokenType.Property, TokenType.Word),
                    (" ", ProjectedTokenType.Space, TokenType.Separator),
                    ("eq", ProjectedTokenType.Equals, TokenType.Word),
                    (",", ProjectedTokenType.Comma, TokenType.Separator)
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
