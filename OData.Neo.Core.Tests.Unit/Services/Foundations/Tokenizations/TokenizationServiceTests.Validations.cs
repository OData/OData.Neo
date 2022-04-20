//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using OData.Neo.Core.Models.OTokens.Exceptions;
using Xunit;


namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Tokenizations
{
    public partial class TokenizationServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnTokenizeIfQueryIsNull()
        {
            // given
            string nullQuery = null;

            // when
            Action toknizeAction = () =>
                this.tokenizationService.Tokenize(nullQuery);

            // then
            Assert.Throws<OTokenValidationException>(toknizeAction);
        }
    }
}