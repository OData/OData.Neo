using System.Linq;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Models.OTokens.Exceptions;

namespace OData.Neo.Core.Services.Foundations.OTokenizations
{
    public partial class OTokenizationService
    {
        private static void ValidateOTokens(OToken[] oTokens)
        {
            ValidateOTokensIsNotNull(oTokens);
            ValidateAllOTokensAreNotNull(oTokens);
            ValidateOTokensRawValues(oTokens);
        }

        private static void ValidateOTokensIsNotNull(
            OToken[] oTokens)
        {
            if (oTokens is null)
            {
                throw new NullOTokensException();
            }
        }

        private static void ValidateAllOTokensAreNotNull(
            OToken[] oTokens)
        {
            if (oTokens.Any(oToken => oToken is null))
            {
                throw new NullOTokenException();
            }
        }

        private static void ValidateOTokensRawValues(OToken[] otokens)
        {
            if (otokens.Any(IsNullOrEmpty))
            {
                throw new InvalidOTokenRawValueException();
            }

            static bool IsNullOrEmpty(OToken oToken) =>
                oToken.RawValue is null or "";
        }
    }
}
