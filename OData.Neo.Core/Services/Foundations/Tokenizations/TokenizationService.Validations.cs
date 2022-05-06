//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models.OTokens.Exceptions;

namespace OData.Neo.Core.Services.Foundations.Tokenizations
{
    public partial class TokenizationService
    {
        private static void ValidateOTokenQuery(string query)
        {
            if (query is null)
            {
                throw new NullOTokenQueryException();
            }
        }
    }
}
