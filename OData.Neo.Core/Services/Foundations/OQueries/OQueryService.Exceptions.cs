//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Threading.Tasks;
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
        }
    }
}
