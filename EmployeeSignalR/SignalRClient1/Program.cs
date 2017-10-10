using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRClient1
{
    class Program
    {
        static Random r = new Random();
        static void Main(string[] args)
        {
            List<Task> listOfTasks = new List<Task>();
            for (int i = 0; i < 2; ++i)
            {
                Task.Factory.StartNew(new Action(TaskCodeForCoolEmployeeGroupAsync), TaskCreationOptions.LongRunning);
                Task.Factory.StartNew(new Action(TaskCodeForWayCoolerEmployeeGroup), TaskCreationOptions.LongRunning);
                Task.Factory.StartNew(new Action(TaskCodeForMonitorGroup), TaskCreationOptions.LongRunning);
            }
                
            while (true) ;
        }

        private static void TaskCodeForCoolEmployeeGroupAsync()
        {
            HubConnection connection = new HubConnectionBuilder()
                             .WithUrl("http://localhost:52846/entryPoint")
                             .WithConsoleLogger()
                             .Build();
            connection.StartAsync().GetAwaiter().GetResult();
            connection.InvokeAsync("RegisterConnectionOnGroup", "CoolEmployees");
            int myNumber = r.Next(0, 1000);
            connection.On<string>("ClientMethod", data => Console.WriteLine($"I'm CoolEmployee with random number = {myNumber} - GOT THIS: {data}"));
            while (true) ;
        }

        private static void TaskCodeForWayCoolerEmployeeGroup()
        {
            HubConnection connection = new HubConnectionBuilder()
                             .WithUrl("http://localhost:52846/entryPoint")
                             .WithConsoleLogger()
                             .Build();
            connection.StartAsync().GetAwaiter().GetResult();
            connection.InvokeAsync("RegisterConnectionOnGroup", "WayCoolerEmployees");
            int myNumber = r.Next(0, 1000);
            connection.On<string>("ClientMethod", data => Console.WriteLine($"I'm WayCoolerEmployee with random number = {myNumber} - GOT THIS: {data}"));
            while (true) ;
        }

        private static void TaskCodeForMonitorGroup()
        {
            HubConnection connection = new HubConnectionBuilder()
                             .WithUrl("http://localhost:52846/entryPoint")
                             .WithConsoleLogger()
                             .Build();
            connection.StartAsync().GetAwaiter().GetResult();
            connection.InvokeAsync("RegisterConnectionOnGroup", "Bosses");
            int myNumber = r.Next(0, 1000);
            connection.On<string>("ClientMethod", data => Console.WriteLine($"I'm Boss with random number = {myNumber} - GOT THIS: {data}"));
            while (true) ;
        }
    }
}
