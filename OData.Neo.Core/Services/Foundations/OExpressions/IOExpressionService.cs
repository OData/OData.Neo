//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Threading.Tasks;
using OData.Neo.Core.Models.OExpressions;

namespace OData.Neo.Core.Services.Foundations.OExpressions
{
    public interface IOExpressionService
    {
        ValueTask<OExpression> GenerateOExpressionAsync<T>(OExpression oExpression);
    }
}
