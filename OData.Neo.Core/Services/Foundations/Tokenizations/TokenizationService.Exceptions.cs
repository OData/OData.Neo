//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using OData.Neo.Core.Models;
using OData.Neo.Core.Models.OTokens.Exceptions;

namespace OData.Neo.Core.Services.Foundations.Tokenizations
{
    public partial class TokenizationService
    {
        private delegate OToken[] ReturningOTokensFunction();
        private delegate void ReturningNothingFunction();

        private OToken[] TryCatch(ReturningOTokensFunction returningOTokensFunction)
        {
            try
            {
                return returningOTokensFunction();
            }
            catch (NullOTokenQueryException nullOTokenQueryException)
            {
                throw new OTokenValidationException(nullOTokenQueryException);
            }
        }
    }
}
