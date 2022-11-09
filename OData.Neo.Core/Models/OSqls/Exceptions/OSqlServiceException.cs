//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.OSqls.Exceptions
{
    public class OSqlServiceException : Xeption
    {
        public OSqlServiceException(Xeption innerException)
            : base(message: "OSql service error occurred, contact support.",
                  innerException)
        { }
    }
}
