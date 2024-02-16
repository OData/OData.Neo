using OData.Neo.Core.Models.OTokens.Exceptions;
using System;

namespace OData.Neo.Core.Services.Foundations.OTokenizations
{
    public partial class OTokenizationValidationService
    {
        private static void TryCatch(Action action)
        {
            try
            {
                action();
            }
            catch (NullOTokensException nullOTokensException)
            {
                throw new OTokenValidationException(nullOTokensException);
            }
            catch (NullOTokenException nullOTokenException)
            {
                throw new OTokenValidationException(nullOTokenException);
            }
            catch (InvalidOTokenRawValueException invalidOTokenRawValueException)
            {
                throw new OTokenValidationException(invalidOTokenRawValueException);
            }
            catch (Exception exception)
            {
                var failedOTokenServiceException =
                    new FailedOTokenServiceException(exception);

                throw new OTokenServiceException(
                    failedOTokenServiceException);
            }
        }
    }
}
