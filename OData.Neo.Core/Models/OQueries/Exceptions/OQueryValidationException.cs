//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.OQueries.Exceptions
{
    public class OQueryValidationException : Xeption
    {
        public OQueryValidationException(Xeption innerException)
            : base(message: "OQuery validation error ocurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
