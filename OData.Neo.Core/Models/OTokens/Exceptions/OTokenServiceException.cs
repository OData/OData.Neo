//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.OTokens.Exceptions
{
    public class OTokenServiceException : Xeption
    {
        public OTokenServiceException(Xeption innerException)
            : base(message: "OToken service error occurred, contact support.",
                  innerException)
        { }
    }
}
