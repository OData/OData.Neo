//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models.OTokens;
using OData.Neo.Core.Models.ProjectedTokens;
using System.Collections.Generic;
using System.Linq;

namespace OData.Neo.Core.Services.Foundations.OTokenizations
{
    public partial class OTokenizationService : IOTokenizationService
    {
        public OToken OTokenize(OToken[] oTokens) =>
            TryCatch(() =>
            {
                ValidateOTokens(oTokens);

                OToken root = new OToken
                {
                    Type = OTokenType.Root,
                    Children = new List<OToken>()
                };

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
            });
    }
}
