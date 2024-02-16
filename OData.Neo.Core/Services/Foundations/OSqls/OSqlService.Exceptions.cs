//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using OData.Neo.Core.Models.OSqls.Exceptions;

namespace OData.Neo.Core.Services.Foundations.OSqls
{
    public partial class OSqlService
    {
        private delegate string ReturningOSqlQueryFunction();

        private string TryCatch(ReturningOSqlQueryFunction returningOSqlQueryFunction)
        {
            try
            {
                return returningOSqlQueryFunction();
            }
            catch (NullExpressionOSqlException nullExpressionOSqlException)
            {
                throw new OSqlValidationException(nullExpressionOSqlException);
            }
            catch (InvalidOperationException invalidOExpressionException)
            {
                var failedOSqlDependencyException =
                    new FailedOSqlDependencyException(invalidOExpressionException);

                throw new OSqlDependencyException(failedOSqlDependencyException);
            }
            catch (InvalidCastException invalidCastException)
            {
                var failedOSqlDependencyException =
                    new FailedOSqlDependencyException(invalidCastException);

                throw new OSqlDependencyException(failedOSqlDependencyException);
            }
            catch (Exception exception)
            {
                var failedOSqlServiceException =
                    new FailedOSqlServiceException(exception);

                throw new OSqlServiceException(failedOSqlServiceException);
            }
        }
    }
}