using System.Linq.Expressions;
using OData.Query.Ast;

namespace OData.Query
{
    /// <summary>
    /// Default implementation for QueryNode binder.
    /// </summary>
    public class QueryNodeBinder : IQueryNodeBinder
    {
        public virtual Expression Bind(QueryNode node, QueryBinderContext context)
        {
            throw new NotImplementedException();
        }
    }
}
