//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

namespace OData.Neo.Core.Ast
{
    public class FilterClause
    {
        public SingleValueNode Expression { get; set; }

        /// <summary>
        /// Gets the parameter for the expression which represents a single value from the collection.
        /// </summary>
        public RangeVariable Variable { get; set; }
    }
}