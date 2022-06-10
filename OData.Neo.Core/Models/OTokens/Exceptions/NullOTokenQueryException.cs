//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.Tokens.Exceptions
{
    public class NullOTokenQueryException : Xeption
    {
        public NullOTokenQueryException()
            : base(message: "OToken query is null.")
        { }
    }
}
