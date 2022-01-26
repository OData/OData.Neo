//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Ast;

namespace OData.Neo.Core.Parser
{
    public interface IQueryOptionParser
    {
        FilterClause ParseFilter(string filter, ParserContext context);
    }
}
