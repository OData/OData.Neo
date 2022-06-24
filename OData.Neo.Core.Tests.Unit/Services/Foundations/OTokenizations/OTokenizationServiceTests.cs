//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Services.Foundations.OTokenizations;
using Tynamix.ObjectFiller;
using Randomizer = System.Random;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.OTokenizations
{
    public partial class OTokenizationServiceTests
    {
        private readonly IOTokenizationService tokenizationService;

        public OTokenizationServiceTests() =>
            this.tokenizationService = new OTokenizationService();

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
