//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OData.Neo.Core.Services.Orchestrations.Coordinates
{
    public interface IOQueryCoordinateService
    {
        ValueTask<Expression> ProcessOQueryAsync<T>(string odataQuery);
    }
}
