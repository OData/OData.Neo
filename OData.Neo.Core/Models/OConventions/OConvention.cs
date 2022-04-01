//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

namespace OData.Neo.Core.Models.OConventions
{
    public class OConvention
    {
        public string Token { get; set; }
        public OConventionType Type { get; set; }
        public string EndToken { get; set; }
    }
}
