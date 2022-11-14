//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Linq.Expressions;

namespace OData.Neo.Core.Services.Foundations.OSqls
{
    public interface IOSqlService
    {
        string RetrieveOSqlQuery(Expression expression);
    }
}
