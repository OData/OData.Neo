//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using OData.Neo.Core.Ast;
using OData.Neo.Core.Parser;

namespace OData.Neo.Core.Services
{
    public class FilterBinder : IFilterBinder
    {
        public FilterBinder(IQueryOptionParser parser, IQueryNodeBinder nodeBinder)
        {
            Parser = parser;
            NodeBinder = nodeBinder;
        }

        public IQueryOptionParser Parser { get; }

        public IQueryNodeBinder NodeBinder { get; }

        public virtual Expression BindFilter(string filter, BinderContext context)
        {
            // parse $filter=Name eq 'John' to Abstract search tree.
            FilterClause filterClause = Parser.ParseFilter(filter, new ParserContext());

            // Generate the Linq Expression
            Expression body = NodeBinder.Bind(filterClause.Expression, context);

            ParameterExpression filterParameter = context.CurrentParameter;

            // TODO: nullable
            LambdaExpression filterExpr = Expression.Lambda(body, filterParameter);

            return filterExpr;
        }
    }
}
