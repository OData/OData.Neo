//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

namespace OData.Neo.Core.Models
{
    public enum OTokenType
    {
        Operand,
        Whitespace,
        BeginScope,
        EndScope,
        Equals,
        Hyphen,
        Dot,
        Quote,
        Star,
        OpenBracket,
        CloseBracket,
        Colon,
        SemiColon,
        Underscore,
        Ampersand,
        Dollar,
        ODataParameter,
        Word,
        Number,
        Boolean,
        Slash,
        BackSlash,
        Guid,
        DateTimeOffset,
        Literal
    }
}