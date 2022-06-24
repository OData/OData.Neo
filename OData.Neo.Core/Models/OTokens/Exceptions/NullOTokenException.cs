//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.OTokens.Exceptions
{
    public class NullOTokenException : Xeption
    {
        public NullOTokenException()
            : base(message: "Token is null")
        { }
    }
}
