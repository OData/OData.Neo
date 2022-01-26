//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Ast;
using System.Linq.Expressions;

namespace OData.Neo.Core.Services
{
    public interface IQueryNodeBinder
    {
        Expression Bind(QueryNode node, BinderContext context);
    }
}
