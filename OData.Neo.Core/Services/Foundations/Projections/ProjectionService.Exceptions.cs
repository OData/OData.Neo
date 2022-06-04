//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models.ProjectedTokens;
using OData.Neo.Core.Models.ProjectedTokens.Exceptions;
using System;

namespace OData.Neo.Core.Services.Foundations.Projections
{
    public partial class ProjectionService
    {
        private delegate ProjectedToken[] ReturningProjectedTokensFunction();

        private ProjectedToken[] TryCatch(ReturningProjectedTokensFunction returningProjectedTokensFunction)
        {
            try
            {
                return returningProjectedTokensFunction();
            }
            catch (NullProjectedTokenException nullProjectedTokenException)
            {
                throw new ProjectedTokenValidationException(nullProjectedTokenException);
            }
            catch (InvalidProjectedTokenRawValueException invalidProjectedTokenRawValueException)
            {
                throw new ProjectedTokenValidationException(invalidProjectedTokenRawValueException);
            }
            catch (Exception exception)
            {
                var failedProjectedTokenServiceException =
                    new FailedProjectedTokenServiceException(exception);

                throw new ProjectedTokenServiceException(failedProjectedTokenServiceException);
            }
        }
    }
}
