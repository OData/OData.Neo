//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

namespace OData.Neo.Core.Ast
{
    public class SingleValuePropertyAccessNode : SingleValueNode
    {
        public SingleValueNode Source { get; set; }

        public string Name { get; set; }
    }
}
