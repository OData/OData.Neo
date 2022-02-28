//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using OData.Neo.Core.Models;
using OData.Neo.Core.Services.Foundations.Tokenizations;
using Tynamix.ObjectFiller;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Tokenizations
{
    public partial class TokenizationServiceTests
    {
        private readonly ITokenizationService tokenizationService;

        public TokenizationServiceTests() => 
            this.tokenizationService = new TokenizationService();
    }
}
