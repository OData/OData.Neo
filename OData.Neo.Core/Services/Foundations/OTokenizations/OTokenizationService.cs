//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Models.ProjectedTokens;

namespace OData.Neo.Core.Services.Foundations.OTokenizations
{
    public partial class OTokenizationService : IOTokenizationService
    {
        private readonly IOTokenizationValidationService oTokenizationValidationService;

        public OTokenizationService(IOTokenizationValidationService oTokenizationValidationService)
        {
            this.oTokenizationValidationService = oTokenizationValidationService;
        }

        public OToken OTokenize(OToken[] oTokens) =>
            TryCatch(() =>
            {
                oTokenizationValidationService.ValidateOTokens(oTokens);

                OToken root = new()
                {
                    Type = OTokenType.Root,
                    Children = new List<OToken>()
                };

                return oTokens.Any()
                    ? ProcessTokens(root, oTokens)
                    : root;
            });

        OToken ProcessTokens(OToken root, OToken[] oTokens)
        {
            var selectToken = oTokens[0];
            selectToken.Type = OTokenType.Select;

            root.Children.Add(selectToken);
            selectToken.Children ??= new();
            var tokens = oTokens
                .Skip(1)
                .Where(token => token.ProjectedType != ProjectedTokenType.Equals)
                .Select(token =>
                {
                    token.Type = OTokenType.Property;
                    return token;
                });

            selectToken.Children.AddRange(tokens);

            return root;
        }
    }
}
