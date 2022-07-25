//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models.Tokens;

namespace OData.Neo.Core.Services.Foundations.Tokenizations
{
    public interface ITokenizationService
    {
        Token[] Tokenize(string rawQuery);
    }
}
