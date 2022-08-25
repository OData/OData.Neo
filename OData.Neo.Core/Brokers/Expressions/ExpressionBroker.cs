//-----------------------------------------------------------------------
// Copyright (c) .NET Foundation and Contributors. All rights reserved.
// See License.txt in the project root for license information.
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace OData.Neo.Core.Brokers.Expressions
{
    public class ExpressionBroker : IExpressionBroker
    {
        public async ValueTask<Expression> GenerateExpressionAsync<T>(string linqExpression)
        {
            var globals = new Globals<T>
            {
                DataSource = new List<T>().AsQueryable()
            };

            ScriptOptions scriptOptions = ScriptOptions.Default;
            scriptOptions = scriptOptions.AddReferences(typeof(T).Assembly);
            scriptOptions = scriptOptions.AddReferences("System");
            scriptOptions = scriptOptions.AddReferences("System.Linq");
            scriptOptions = scriptOptions.AddReferences("System.Collections.Generic");

            var state = await CSharpScript.RunAsync<Expression>($@"
                using System;
                using System.Linq;
                using System.Collections.Generic;
                
                return DataSource.{linqExpression}.Expression;", scriptOptions, globals);

            return state.ReturnValue;
        }
        public class Globals<T>
        {
            public IQueryable<T> DataSource { get; set; }
        }

        public class Student
        {
            public string Name { get; set; }
            public Guid Id { get; set; }
        }
    }

}
