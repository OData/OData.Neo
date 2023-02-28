//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using OData.Neo.Core.Models.Coordinations.OQueries.Exceptions;

namespace OData.Neo.Core.Services.Coordinations.OQueries
{
    public partial class OQueryCoordinationService : IOQueryCoordinationService
    {
        private static void ValidateOQueryExpression(string odataQuery)
        {
            if (odataQuery is null)
            {
                throw new NullOQueryExpressionCoordinationException();
            }
        }
    }
}
