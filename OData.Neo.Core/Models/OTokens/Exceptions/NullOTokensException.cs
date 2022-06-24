//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.OTokens.Exceptions
{
    public class NullOTokensException : Xeption
    {
        public NullOTokensException()
            : base(message: "OTokens are null.")
        { }
    }
}
