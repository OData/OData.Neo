//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models.OTokens;

namespace OData.Neo.Core.Services.Foundations.OTokenizations
{
    public interface IOTokenizationService
    {
        OToken OTokenize(OToken[] oTokens);
    }
}