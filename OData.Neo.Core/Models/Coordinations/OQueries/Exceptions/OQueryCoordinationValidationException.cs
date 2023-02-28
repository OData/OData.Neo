//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.Coordinations.OQueries.Exceptions
{
    public class OQueryCoordinationValidationException : Xeption
    {
        public OQueryCoordinationValidationException(Xeption innerException)
            : base(message: "OQuery validation error occured, fix the errors and try again.",
                  innerException)
        { }
    }
}
