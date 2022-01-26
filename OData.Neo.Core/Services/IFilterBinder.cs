//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;

namespace OData.Neo.Core.Services
{
    /// <summary>
    /// A interface to process the $filter
    /// </summary>
    public interface IFilterBinder
    {
        Expression BindFilter(string filter, BinderContext context);
    }
}
