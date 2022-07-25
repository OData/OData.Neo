//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using OData.Neo.Core.Models.Tokens;
using OData.Neo.Core.Models.Tokens.Exceptions;

namespace OData.Neo.Core.Services.Foundations.Tokenizations
{
    public partial class TokenizationService
    {
        private delegate Token[] ReturningTokensFunction();
        private delegate void ReturningNothingFunction();

        private Token[] TryCatch(ReturningTokensFunction returningTokensFunction)
        {
            try
            {
                return returningTokensFunction();
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
