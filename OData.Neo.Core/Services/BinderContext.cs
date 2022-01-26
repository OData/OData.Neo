//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;

namespace OData.Neo.Core.Services
{
    /// <summary>
    /// A context wrappers the information for binder.
    /// </summary>
    public class BinderContext
    {
        /// <summary>
        /// All parameters present in current context.
        /// </summary>
        private IDictionary<string, ParameterExpression> _lambdaParameters;

        public BinderContext(Type elementType)
        {
            ElementClrType = elementType;

            ParameterExpression thisParameters = Expression.Parameter(elementType, "$it");
            _lambdaParameters = new Dictionary<string, ParameterExpression>();
            _lambdaParameters["$it"] = thisParameters;
        }

        /// <summary>
        /// Gets the Element Clr type.
        /// </summary>
        public Type ElementClrType { get; }

        /// <summary>
        /// Gets the current parameter. Current parameter is the parameter at root of this context.
        /// </summary>
        public ParameterExpression CurrentParameter => _lambdaParameters["$it"];
    }
}
