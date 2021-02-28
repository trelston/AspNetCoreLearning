using System;
using System.Dynamic;
using System.Net.Http;
using Elsa.Activities;
using Elsa.Activities.Email.Activities;
using Elsa.Activities.Http.Activities;
using Elsa.Expressions;
using Elsa.Scripting.JavaScript;
using Elsa.Services;
using Elsa.Services.Models;

namespace ElsaProjectPractice
{
    public class DocumentApprovalWorkflow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder
                .StartWith<ReceiveHttpRequest>(
                    x =>
                    {
                        x.Method = HttpMethod.Post.Method;
                        x.Path = new Uri("/documents", UriKind.Relative);
                        x.ReadContent = true;
                    })
                .Then<SetVariable>(
                    x =>
                    {
                        x.VariableName = "Document";
                        x.ValueExpression = new JavaScriptExpression<ExpandoObject>("lastResult().Body");
                    })
                .Then<SendEmail>();
            
            
        }
    }
}