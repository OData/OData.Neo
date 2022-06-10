//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OData.Neo.Core.Models.ProjectedTokens
{
    public class ProjectedToken
    {
        public string RawValue { get; set; }
        public TokenType TokenType { get; set; }
        public ProjectedType ProjectedType { get; set; }
    }
}
