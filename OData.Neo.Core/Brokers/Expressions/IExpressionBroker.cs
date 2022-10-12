//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OData.Neo.Core.Brokers.Expressions
{
    public interface IExpressionBroker
    {
        ValueTask<Expression> GenerateExpressionAsync<T>(string linqExpression);
    }
}
