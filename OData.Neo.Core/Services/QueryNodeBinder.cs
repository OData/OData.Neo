//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;
using OData.Neo.Core.Ast;

namespace OData.Neo.Core.Services
{
    /// <summary>
    /// Default implementation for QueryNode binder.
    /// </summary>
    public class QueryNodeBinder : IQueryNodeBinder
    {
        public virtual Expression Bind(QueryNode node, BinderContext context)
        {
            if (node is CollectionNode collectionNode)
            {
                return BindCollectionNode(collectionNode, context);
            }
            else if (node is SingleValueNode singleValueNode)
            {
                return BindSingleValueNode(singleValueNode, context);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public virtual Expression BindCollectionNode(CollectionNode node, BinderContext context)
        {
            throw new NotSupportedException();
        }

        public virtual Expression BindSingleValueNode(SingleValueNode node, BinderContext context)
        {
            switch (node)
            {
                case BinaryOperatorNode binNode:
                    return BindBinaryOperatorNode(binNode, context);

                case SingleValuePropertyAccessNode san:
                    return BindPropertyAccessQueryNode(san, context);

                case ConstantNode constantNode:
                    return BindConstantNode(constantNode, context);

                case RangeVariableReferenceNode rangeValue:
                    return BindRangeVariable(rangeValue, context);

                default:
                    throw new NotSupportedException();
            }
        }

        public virtual Expression BindRangeVariable(RangeVariableReferenceNode rangeVariable, BinderContext context)
        {
            if (rangeVariable.Name == "$it")
            {
                return context.CurrentParameter;
            }

            throw new NotSupportedException();

        }

        public virtual Expression BindBinaryOperatorNode(BinaryOperatorNode binaryOperatorNode, BinderContext context)
        {
            Expression left = Bind(binaryOperatorNode.Left, context);

            Expression right = Bind(binaryOperatorNode.Right, context);

            // just for sample;
            return Expression.MakeBinary(ExpressionType.Equal, left, right);
        }

        public virtual Expression BindPropertyAccessQueryNode(SingleValuePropertyAccessNode propertyAccessNode, BinderContext context)
        {
            Expression source = Bind(propertyAccessNode.Source, context);

            return Expression.Property(source, propertyAccessNode.Name);
        }

        public virtual Expression BindConstantNode(ConstantNode constantNode, BinderContext context)
        {
            return Expression.Constant(constantNode.Value);
        }
    }
}
