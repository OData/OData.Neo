//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.ProjectedTokens.Exceptions
{
    public class ProjectedTokenValidationException : Xeption
    {
        public ProjectedTokenValidationException(Xeption innerException)
            : base(message: "Projected token validation error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
