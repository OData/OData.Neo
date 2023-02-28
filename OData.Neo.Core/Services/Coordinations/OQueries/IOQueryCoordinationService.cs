//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OData.Neo.Core.Services.Coordinations.OQueries
{
    public interface IOQueryCoordinationService
    {
        ValueTask<Expression> ProcessOQueryAsync<T>(string oQuery);
    }
}
