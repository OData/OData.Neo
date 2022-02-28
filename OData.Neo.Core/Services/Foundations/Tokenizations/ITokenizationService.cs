//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models;

namespace OData.Neo.Core.Services.Foundations.Tokenizations
{
    public interface ITokenizationService
    {
        OToken[] Tokenize(string rawQuery);
    }
}
