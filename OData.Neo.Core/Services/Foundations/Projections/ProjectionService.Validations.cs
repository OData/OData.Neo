//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Models.ProjectedTokens.Exceptions;
using System;
using System.Linq;

namespace OData.Neo.Core.Services.Foundations.Projections
{
    public partial class ProjectionService : IProjectionService
    {
        private static void ValidateProjectedTokens(ProjectedToken[] projectedTokens)
        {
            ValidateProjectedTokensIsNotNull(projectedTokens);
            ValidateProjectedTokensContainsNotNullTokens(projectedTokens);
            ValidateProjectedTokenRawValuesIsNullNull(projectedTokens);
        }

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
