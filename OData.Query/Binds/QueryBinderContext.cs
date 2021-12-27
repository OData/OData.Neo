using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OData.Query
{
    public class QueryBinderContext
    {
        public QueryBinderContext(Type elementType)
        {
            ElementClrType = elementType;
        }

        /// <summary>
        /// Gets the current type.
        /// </summary>
        public Type ElementClrType { get; }
    }
}
