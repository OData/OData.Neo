//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using InternalMock.Extensions;
using OData.Neo.Core.Models.Tokens.Exceptions;
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

            this.tokenizationService.Mock(
                methodName: "ValidateOTokenQuery")
                    .Throws(exception);

            // when
            Action tokenizationAction = () =>
                this.tokenizationService.Tokenize(someQuery);

            // then
            TokenServiceException otokenServiceException =
                Assert.Throws<TokenServiceException>(tokenizationAction);

            Assert.True(otokenServiceException.InnerException
                is FailedOTokenServiceException);

            this.tokenizationService.ClearAllOtherCalls();
        }
    }
}