using OData.Neo.Core.Models.Tokens.Exceptions;

namespace OData.Neo.Core.Services.Foundations.Tokenizations
{
    public partial class TokenizationValidationService : ITokenizationValidationService
    {
        public void ValidateOTokenQuery(string query)
        => TryCatch(() =>
            {
                if (query is null)
                {
                    throw new NullOTokenQueryException();
                }
            });
    }
}
