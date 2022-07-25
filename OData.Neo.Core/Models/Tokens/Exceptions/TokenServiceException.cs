//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.Tokens.Exceptions
{
    public class TokenServiceException : Xeption
    {
        public TokenServiceException(Xeption innerException)
            : base(message: "OToken service error occurred, contact support",
                  innerException)
        { }
    }
}
