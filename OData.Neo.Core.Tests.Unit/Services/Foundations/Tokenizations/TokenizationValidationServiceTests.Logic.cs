using FluentAssertions;
using OData.Neo.Core.Models.Tokens.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OData.Neo.Core.Tests.Unit.Services.Foundations.Tokenizations
{
    public partial class TokenizationValidationServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnTokenizeIfQueryIsNull()
        {
            // given
            string nullQuery = null;

            var nullOTokenException =
                new NullOTokenQueryException();

            var expectedOtokenValidationException =
                new TokenValidationException(nullOTokenException);

            // when
            Action toknizeAction = () =>
                this.tokenizationValidationService.ValidateOTokenQuery(nullQuery);

            TokenValidationException actualOTokenValidationException =
                Assert.Throws<TokenValidationException>(toknizeAction);

            // then
            actualOTokenValidationException.Should().BeEquivalentTo(
                expectedOtokenValidationException);
        }
    }
}
