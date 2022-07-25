//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.Tokens.Exceptions
{
    public class TokenValidationException : Xeption
    {
        public TokenValidationException(Xeption innerException)
            : base(message: "OToken validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
