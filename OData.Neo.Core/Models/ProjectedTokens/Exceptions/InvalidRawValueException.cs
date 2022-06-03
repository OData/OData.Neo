//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.ProjectedTokens.Exceptions
{
    public class InvalidProjectedTokenRawValueException : Xeption
    {
        public InvalidProjectedTokenRawValueException()
            : base(message: "Invalid projected token raw value error occurred, please fix the error and try agian.")
        { }
    }
}
