using OData.Neo.Core.Models.ProjectedTokens.Exceptions;
using System;

namespace OData.Neo.Core.Services.Foundations.Projections
{
    public partial class ProjectionValidationService
    {
        private static void TryCatch(Action action)
        {
            try
            {
                action();
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
