//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.OQueries.Exceptions
{
    public class OQueryServiceException : Xeption
    {
        public OQueryServiceException(Xeption innerException)
            : base(message: "OQuery service error occurred, contact support.",
                  innerException)
        { }
    }
}
