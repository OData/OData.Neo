//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.OSqls.Exceptions
{
    public class OSqlDependencyException : Xeption
    {
        public OSqlDependencyException(Xeption innerException)
            : base(message: "OSql dependency error ocurred, contact support.",
                  innerException)
        { }
    }
}
