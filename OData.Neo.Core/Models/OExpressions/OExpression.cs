//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using OData.Neo.Core.Models.OTokens;

namespace OData.Neo.Core.Models.OExpressions
{
    public class OExpression
    {
        public OToken OToken { get; set; }
        public Expression Expression { get; set; }
        public string RawQuery { get; set; }
    }
}