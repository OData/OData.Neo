//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.OTokens.Exceptions
{
    public class InvalidOTokenRawValueException : Xeption
    {
        public InvalidOTokenRawValueException()
            : base(message: "Invalid OToken raw value error occurred, please fix the error and try again.")
        { }
    }
}
