//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using OData.Neo.Core.Models.Expressions;

namespace OData.Neo.Core.Brokers.Expressions
{
    public class ExpressionBroker : IExpressionBroker
    {
        public async ValueTask<Expression> GenerateExpressionAsync<T>(string linqExpression)
        {
            Globals<T> globals = GetGlobalVariables<T>();
            ScriptOptions scriptOptions = GetScriptOptions<T>();
            string script = GetScript(linqExpression);

            ScriptState<Expression> state =
                await CSharpScript.RunAsync<Expression>(
                    code: script,
                    scriptOptions,
                    globals);

            return state.ReturnValue;
        }

        public IQueryable Execute<T>(IQueryable<T> sources, Expression expression)
        {
            var methodCallExpression = expression as MethodCallExpression;
            MethodInfo methodInfo = methodCallExpression.Method;
            var unary = methodCallExpression.Arguments[1] as UnaryExpression;
            var lambda = unary.Operand as LambdaExpression;
            
            return methodInfo.Invoke(
                obj: null, 
                parameters: 
                new object[] { sources, lambda }) as IQueryable;
        }

        private Globals<T> GetGlobalVariables<T>()
        {
            return new Globals<T>
            {
                DataSource = new List<T>().AsQueryable()
            };
        }

        private ScriptOptions GetScriptOptions<T>()
        {
            ScriptOptions scriptOptions = ScriptOptions.Default;
            scriptOptions = scriptOptions.AddReferences("System");
            scriptOptions = scriptOptions.AddReferences("System.Linq");
            scriptOptions = scriptOptions.AddReferences("System.Collections.Generic");
            scriptOptions = scriptOptions.AddReferences(typeof(T).Assembly);

            return scriptOptions;
        }

        private string GetScript(string linqExpression)
        {
            return $@"
                using System;
                using System.Linq;
                using System.Collections.Generic;

                return DataSource.{linqExpression}.Expression;";
        }
    }
}
