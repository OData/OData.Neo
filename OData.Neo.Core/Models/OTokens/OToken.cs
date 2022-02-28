//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace OData.Neo.Core.Models
{
    public class OToken
    {
        public OTokenType Type { get; set; }
        public string Value { get; set; }
    }
}
