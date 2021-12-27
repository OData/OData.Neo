using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OData.Query.Ast
{
    public class ConstantNode : SingleValueNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode" /> class.
        /// </summary>
        /// <param name="constantValue"></param>
        /// <param name="literalText"></param>
        public ConstantNode(object constantValue, string literalText)
        {
            Value = constantValue;
            LiteralText = literalText;
        }

        /// <summary>
        /// Gets the primitive constant value.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Get or Set the literal text for this node's value, formatted according to the OData URI literal formatting rules.
        /// May be null if the text was not provided at construction time.
        /// </summary>
        public string LiteralText { get; }
    }
}
