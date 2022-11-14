//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.OSqls.Exceptions
{
    public class OSqlValidationException : Xeption
    {
        public OSqlValidationException(Xeption innerException)
            : base(message: "OSQL validation error ocurred, fix erros and try again.",
                  innerException)
        { }
    }
}
