﻿//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Xeptions;

namespace OData.Neo.Core.Models.OExpressions.Exceptions
{
    public class NullSourceOExpressionException : Xeption
    {
        public NullSourceOExpressionException()
            : base(message: "Source is null")
        { }
    }
}
