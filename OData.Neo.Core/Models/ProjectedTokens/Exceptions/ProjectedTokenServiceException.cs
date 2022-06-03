//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.ProjectedTokens.Exceptions
{
    public class ProjectedTokenServiceException : Xeption
    {
        public ProjectedTokenServiceException(Xeption innerException)
            : base(message: "Project token service error occurred, contact support.",
                  innerException)
        { }
    }
}
