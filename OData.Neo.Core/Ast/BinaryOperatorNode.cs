//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

namespace OData.Neo.Core.Ast
{
    public enum BinaryOperatorKind
    {
        /// <summary>
        /// The logical or operator.
        /// </summary>
        Or = 0,

        /// <summary>
        /// The logical and operator.
        /// </summary>
        And = 1,

        /// <summary>
        /// The eq operator.
        /// </summary>
        Equal = 2,

        /// <summary>
        /// The ne operator.
        /// </summary>
        NotEqual = 3,

        /// <summary>
        /// The gt operator.
        /// </summary>
        GreaterThan = 4,

        /// <summary>
        /// The ge operator.
        /// </summary>
        GreaterThanOrEqual = 5,

        /// <summary>
        /// The lt operator.
        /// </summary>
        LessThan = 6,

        /// <summary>
        /// The le operator.
        /// </summary>
        LessThanOrEqual = 7,

        /// <summary>
        /// The add operator.
        /// </summary>
        Add = 8,

        /// <summary>
        /// The sub operator.
        /// </summary>
        Subtract = 9,

        /// <summary>
        /// The mul operator.
        /// </summary>
        Multiply = 10,

        /// <summary>
        /// The div operator.
        /// </summary>
        Divide = 11,

        /// <summary>
        /// The mod operator.
        /// </summary>
        Modulo = 12,

        /// <summary>
        /// The has operator.
        /// </summary>
        Has = 13,
    }

    public class BinaryOperatorNode : SingleValueNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryOperatorNode" /> class.
        /// </summary>
        /// <param name="operatorKind"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public BinaryOperatorNode(BinaryOperatorKind operatorKind, SingleValueNode left, SingleValueNode right)
        {
            OperatorKind = operatorKind;
            Left = left;
            Right = right;
        }

        /// <summary>
        /// Gets the operator kind.
        /// </summary>
        public BinaryOperatorKind OperatorKind { get; }

        /// <summary>
        /// Gets the left operand.
        /// </summary>
        public SingleValueNode Left { get; }

        /// <summary>
        /// Gets the right operand.
        /// </summary>
        public SingleValueNode Right { get; }
    }
}
