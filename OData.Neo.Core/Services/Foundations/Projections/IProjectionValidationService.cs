using OData.Neo.Core.Models.ProjectedTokens;

namespace OData.Neo.Core.Services.Foundations.Projections
{
    public interface IProjectionValidationService
    {
        void ValidateProjectedTokens(ProjectedToken[] projectedTokens);
    }
}