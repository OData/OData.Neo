//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using Microsoft.CodeAnalysis.CSharp.Syntax;
using OData.Neo.Core.Models.OExpressions;
using OData.Neo.Core.Models.OExpressions.Exceptions;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace OData.Neo.Core.Services.Foundations.OExpressions
{
    public partial class OExpressionService : IOExpressionService
    {
        private void ValidateOExpressionOnGenerate(OExpression oExpression)
        {
            ValidateOExpressionIsNotNull(oExpression);

            Validate(
                (Rule: IsInvalid(oExpression.OToken),
                Parameter: nameof(OExpression.OToken)));
        }

        private void ValidateOExpressionOnApply(OExpression oExpression)
        {
            ValidateOExpressionIsNotNull(oExpression);

            Validate(
                (Rule: IsInvalid(oExpression.Expression),
                Parameter: nameof(OExpression.Expression)));
        }

        private static void ValidateOExpressionIsNotNull(OExpression oExpression)
        {
            if (oExpression is null)
            {
                throw new NullOExpressionException();
            }
        }

        private static void ValidateSource(IQueryable source)
        {
            if (source is null)
            {
                throw new NullSourceOExpressionException();
            }
        }

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };

        private void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidOExpressionException = new InvalidOExpressionException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidOExpressionException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidOExpressionException.ThrowIfContainsErrors();
        }
    }
}
