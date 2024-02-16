using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Models.ProjectedTokens.Exceptions;
using System;
using System.Linq;

namespace OData.Neo.Core.Services.Foundations.Projections
{
    public partial class ProjectionValidationService : IProjectionValidationService
    {
        public void ValidateProjectedTokens(ProjectedToken[] projectedTokens)
            => TryCatch(() =>
            {
                ValidateProjectedTokensIsNotNull(projectedTokens);
                ValidateProjectedTokensContainsNotNullTokens(projectedTokens);
                ValidateProjectedTokenRawValuesIsNullNull(projectedTokens);
            });

        private static void ValidateProjectedTokensIsNotNull(
            ProjectedToken[] projectedTokens)
        {
            if (projectedTokens is null)
            {
                throw new NullProjectedTokenException();
            }
        }

        private static void ValidateProjectedTokensContainsNotNullTokens(
            ProjectedToken[] projectedTokens)
        {
            if (projectedTokens.Contains(null))
            {
                throw new NullProjectedTokenException();
            }
        }

        private static void ValidateProjectedTokenRawValuesIsNullNull(
            ProjectedToken[] projectedTokens)
        {
            Func<ProjectedToken, bool> hasRawValueNullOrEmpty =
                token => token.RawValue is null or "";

            if (projectedTokens.Any(hasRawValueNullOrEmpty))
            {
                throw new InvalidProjectedTokenRawValueException();
            }
        }
    }
}
