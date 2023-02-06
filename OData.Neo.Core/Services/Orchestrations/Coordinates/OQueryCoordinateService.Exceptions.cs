//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OData.Neo.Core.Models.Orchestrations.Coordinates.Exceptions;

namespace OData.Neo.Core.Services.Orchestrations.Coordinates
{
    public partial class OQueryCoordinateService : IOQueryCoordinateService
    {
        private delegate ValueTask<Expression> ReturningOExpressionFunction();

        private async ValueTask<Expression> TryCatch(
            ReturningOExpressionFunction returningOExpressionFunction)
        {
            try
            {
                return await returningOExpressionFunction();
            }
            catch (Exception exception)
            {
                var failedOQueryCoordinateServiceException =
                    new FailedOQueryCoordinateServiceException(exception);

                throw new OQueryCoordinateServiceException(
                    failedOQueryCoordinateServiceException);
            }
        }
    }
}
