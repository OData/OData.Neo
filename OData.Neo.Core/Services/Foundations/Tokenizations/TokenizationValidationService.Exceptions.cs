using OData.Neo.Core.Models.Tokens.Exceptions;
using System;

namespace OData.Neo.Core.Services.Foundations.Tokenizations
{
    public partial class TokenizationValidationService
    {
        private void TryCatch(Action action)
        {
            try
            {
                action();
            }
            catch (NullOTokenQueryException nullOTokenQueryException)
            {
                throw new TokenValidationException(nullOTokenQueryException);
            }
            catch (Exception ex)
            {
                var failedOTokenServiceException = new FailedOTokenServiceException(ex);
                throw new TokenServiceException(failedOTokenServiceException);
            }
        }
    }
}
