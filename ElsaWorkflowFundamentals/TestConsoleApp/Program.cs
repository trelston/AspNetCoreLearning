using System;
using System.Threading.Tasks;
using Elsa.Activities.Console.Activities;
using Elsa.Activities.Console.Extensions;
using Elsa.Expressions;
using Elsa.Services;
using Microsoft.Extensions.DependencyInjection;

namespace TestConsoleApp
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            //Setup a service collection
            var services = new ServiceCollection()
                .AddElsaCore()
                .AddConsoleActivities()
                .BuildServiceProvider();

            // Get a workflow builder
            var workflowBuilder = services.GetRequiredService<IWorkflowBuilder>();

            // Define a workflow and add a single activity
            var workflowDefinition = workflowBuilder
                .StartWith<WriteLine>(x => x.TextExpression = new LiteralExpression("hello world"))
                .Build();

            // Get a workflow invoker
            var invoker = services.GetService<IWorkflowInvoker>();

            //Start the workflow
            await invoker.StartAsync(workflowDefinition);

            // Prevent the console from shutting down until user hits the key
            Console.ReadLine();
        }
    }
}