using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Models.OTokens.Exceptions;
using System.Linq;

namespace OData.Neo.Core.Services.Foundations.OTokenizations
{
    public partial class OTokenizationService
    {
        private static void ValidateOTokens(OToken[] oTokens)
        {
            ValidateOTokensIsNotNull(oTokens);
            ValidateAllOTokensAreNotNull(oTokens);
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
    }
}
