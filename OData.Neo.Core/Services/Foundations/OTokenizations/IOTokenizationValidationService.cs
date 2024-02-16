using OData.Neo.Core.Models.OTokens;

namespace OData.Neo.Core.Services.Foundations.OTokenizations
{
    public interface IOTokenizationValidationService
    {
        void ValidateOTokens(OToken[] oTokens);
    }
}