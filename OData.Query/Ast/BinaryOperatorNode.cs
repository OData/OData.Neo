using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OData.Query.Ast
{
    public enum BinaryOperatorKind
    {

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
