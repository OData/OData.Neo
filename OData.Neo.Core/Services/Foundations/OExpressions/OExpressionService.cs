//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OData.Neo.Core.Brokers.Expressions;
using OData.Neo.Core.Models.OExpressions;

namespace OData.Neo.Core.Services.Foundations.OExpressions
{
    public partial class OExpressionService : IOExpressionService
    {
        private readonly IExpressionBroker expressionBroker;

        public OExpressionService(IExpressionBroker expressionBroker) =>
            this.expressionBroker = expressionBroker;

        public ValueTask<OExpression> GenerateOExpressionAsync<T>(OExpression oExpression) =>
            throw new NotImplementedException();
    }
}
