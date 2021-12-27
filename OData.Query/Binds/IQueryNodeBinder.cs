using System.Linq.Expressions;
using OData.Query.Ast;

namespace OData.Query
{
    public interface IQueryNodeBinder
    {
        Expression Bind(QueryNode node, QueryBinderContext context);
    }
}
