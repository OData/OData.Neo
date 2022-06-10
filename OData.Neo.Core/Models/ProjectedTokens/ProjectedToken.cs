//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models.Tokens;

namespace OData.Neo.Core.Models.ProjectedTokens
{
    public class ProjectedToken
    {
        public string RawValue { get; set; }
        public TokenType TokenType { get; set; }
        public ProjectedType ProjectedType { get; set; }
    }
}
