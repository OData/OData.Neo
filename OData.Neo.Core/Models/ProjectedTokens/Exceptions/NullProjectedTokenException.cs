//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.ProjectedTokens.Exceptions
{
    public class NullProjectedTokenException : Xeption
    {
        public NullProjectedTokenException()
            : base(message: "Projected token is null.")
        { }
    }
}
