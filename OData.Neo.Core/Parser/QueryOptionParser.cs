//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Ast;

namespace OData.Neo.Core.Parser
{
    public class QueryOptionParser : IQueryOptionParser
    {
        /// <summary>
        /// Parse the string like "Name eq 'abc'" to a search tree
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public FilterClause ParseFilter(string filter, ParserContext context)
        {
            throw new NotImplementedException();
        }
    }
}
