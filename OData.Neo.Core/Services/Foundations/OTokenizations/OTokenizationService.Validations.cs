using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Models.OTokens.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OData.Neo.Core.Services.Foundations.OTokenizations
{
    public partial class OTokenizationService
    {
        private static void ValidateOTokens(OToken[] oTokens)
        {
            ValidateOTokensIsNotNull(oTokens);
        }

        private static void ValidateOTokensIsNotNull(
            OToken[] oTokens)
        {
            if (oTokens is null)
            {
                throw new NullOTokensException();
            }
        }
    }
}
