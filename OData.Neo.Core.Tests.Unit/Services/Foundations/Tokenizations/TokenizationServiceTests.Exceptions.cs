//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models.Tokens.Exceptions;
using System;
using Xunit;


namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Tokenizations
{
    public partial class TokenizationServiceTests
    {
        [Fact]
        public void ShouldThrowServiceExceptionOnTokenizeIfExceptionOccurs()
        {
            // given
            string someQuery = GetRandomWordValue();
            var exception = new Exception();

            tokenizationValidationServiceMock.Setup(tokenizationValidationServiceMock =>
                tokenizationValidationServiceMock.ValidateOTokenQuery(someQuery))
                .Throws(exception);

            // when
            Action tokenizationAction = () =>
                this.tokenizationService.Tokenize(someQuery);

            // then
            TokenServiceException otokenServiceException =
                Assert.Throws<TokenServiceException>(tokenizationAction);

            Assert.True(otokenServiceException.InnerException
                is FailedOTokenServiceException);
        }
    }
}