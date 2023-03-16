//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Scripting;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.OExpressions.Exceptions;

namespace OData.Neo.Core.Services.Foundations.OExpressions
{
    public partial class OExpressionService : IOExpressionService
    {
        private delegate ValueTask<OExpression> ReturningOExpressionFunction();
        private delegate IQueryable ReturningQueryableFunction();

        private async ValueTask<OExpression> TryCatch(
            ReturningOExpressionFunction returningOExpressionFunction)
        {
            try
            {
                return await returningOExpressionFunction();
            }
            catch (NullOExpressionException nullOExpressionException)
            {
                throw new OExpressionValidationException(nullOExpressionException);
            }
            catch (InvalidOExpressionException invalidOExpressionException)
            {
                throw new OExpressionValidationException(invalidOExpressionException);
            }
            catch (ArgumentNullException argumentNullException)
            {
                var failedOExpressionDependencyException =
                    new FailedOExpressionDependencyException(argumentNullException);

                throw new OExpressionDependencyException(failedOExpressionDependencyException);
            }
            catch (ArgumentException argumentException)
            {
                var failedOExpressionDependencyException =
                    new FailedOExpressionDependencyException(argumentException);

                throw new OExpressionDependencyException(new FailedOExpressionDependencyException(argumentException));
            }
            catch (CompilationErrorException compilcationErrorException)
            {
                var failedOExpressionDependencyException =
                    new FailedOExpressionDependencyException(compilcationErrorException);

                throw new OExpressionDependencyException(failedOExpressionDependencyException);
            }
            catch (Exception exception)
            {
                var failedOExpressionServiceException =
                    new FailedOExpressionServiceException(exception);

                throw new OExpressionServiceException(failedOExpressionServiceException);
            }
        }

        private IQueryable TryCatch(ReturningQueryableFunction returningQueryableFunction)
        {
            try
            {
                return returningQueryableFunction();
            }
            catch (NullSourceOExpressionException nullSourceOExpressionException)
            {
                throw new OExpressionValidationException(nullSourceOExpressionException);
            }
            catch (NullOExpressionException nullOExpressionException)
            {
                throw new OExpressionValidationException(nullOExpressionException);
            }
            catch (InvalidOExpressionException invalidOExpressionException)
            {
                throw new OExpressionValidationException(invalidOExpressionException);
            }
        }
    }
}
