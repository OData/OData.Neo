//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using OData.Neo.Core.Models.OExpressions.Exceptions;
using OData.Neo.Core.Models.OQueries.Exceptions;

namespace OData.Neo.Core.Services.Foundations.OQueries
{
    public partial class OQueryService : IOQueryService
    {
        private delegate string ReturningOQueryFunction();

        private string TryCatch(
            ReturningOQueryFunction returningOQueryFunction)
        {
            try
            {
                return returningOQueryFunction();
            }
            catch (NullOQueryExpressionException nullOQueryException)
            {
                throw new OQueryValidationException(nullOQueryException);
            }
            catch (InvalidOperationException invalidOperationException)
            {
                var failedOQueryDependencyException = 
                    new FailedOQueryDependencyException(invalidOperationException);

                throw new OQueryDependencyException(failedOQueryDependencyException);
            }
            catch (InvalidCastException invalidCastException)
            {
                var failedOQueryDependencyException =
                    new FailedOQueryDependencyException(invalidCastException);

                throw new OQueryDependencyException(failedOQueryDependencyException);
            }
            catch (Exception exception)
            {
                var failedOQuryServiceException =
                    new FailedOQueryServiceException(exception);

                throw new OQueryServiceException(failedOQuryServiceException);
            }
        }
    }
}