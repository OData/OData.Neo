//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Collections.Generic;
using OData.Neo.Core.Models.ProjectedTokens;

namespace OData.Neo.Core.Models.OTokens
{
    public class OToken
    {
        public string RawValue { get; set; }
        public OTokenType Type { get; set; }
        public ProjectedTokenType ProjectedType { get; set; }
        public List<OToken> Children { get; set; }
    }
}
