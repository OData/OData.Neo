using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Services.Foundations.OTokenizations;
using System.Collections.Generic;
using System.Linq;
using Tynamix.ObjectFiller;
using Randomizer = System.Random;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.OTokenizations
{
    public partial class OTokenizationValidationServiceTests
    {
        private readonly IOTokenizationValidationService tokenizationValidationService;

        public OTokenizationValidationServiceTests()
        {
            tokenizationValidationService = new OTokenizationValidationService();
        }

        private static OToken[] CreateRandomOTokens(OToken addedOToken)
        {
            List<OToken> randomOTokens =
                CreateOTokenFiller()
                    .Create(count: GetRandomNumber())
                        .ToList();

            randomOTokens.Add(addedOToken);

            return ShuffleOTokens(randomOTokens).ToArray();
        }

        private static OToken[] CreateRandomOTokens() =>
            CreateOTokenFiller().Create(count: GetRandomNumber()).ToArray();

        private static List<OToken> ShuffleOTokens(List<OToken> projectedTokens)
        {
            var randomizer = new Randomizer();

            return projectedTokens
                .OrderBy(token => randomizer.Next())
                    .ToList(); ;
        }

        private static int GetRandomNumber() =>
           new IntRange(min: 2, max: 10).GetValue();

        private static Filler<OToken> CreateOTokenFiller() =>
            new Filler<OToken>();
    }
}
