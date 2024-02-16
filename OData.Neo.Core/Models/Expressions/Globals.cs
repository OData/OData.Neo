//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq;

namespace OData.Neo.Core.Models.Expressions
{
    public class Globals<T>
    {
        public IQueryable<T> DataSource { get; set; }
    }
}
