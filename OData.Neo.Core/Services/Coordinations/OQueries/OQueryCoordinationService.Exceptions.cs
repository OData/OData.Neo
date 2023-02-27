//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using System.Threading.Tasks;
using OData.Neo.Core.Models.Coordinations.OQueries.Exceptions;

namespace OData.Neo.Core.Services.Coordinations.OQueries
{
    public partial class OQueryCoordinationService : IOQueryCoordinationService
    {
        private delegate ValueTask<Expression> ReturningOQueryFunction();

        private async ValueTask<Expression> TryCatch(ReturningOQueryFunction returningOQueryFunction)
        {
            try
            {
                return await returningOQueryFunction();
            }
            catch (NullOQueryExpressionCoordinationException nullOQueryExpressionCoordinationException)
            {
                throw new OQueryCoordinationValidationException(nullOQueryExpressionCoordinationException);
            }
        }
    }
}
