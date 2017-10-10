using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MessageSender
{
    class Program
    {
        static void Main (string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            HubConnection connection = new HubConnectionBuilder()
                             .WithUrl("http://localhost:52846/entryPoint")
                             .WithConsoleLogger()
                             .Build();
            await connection.StartAsync();
            int coolEmployeesMessageNumber = 0, wayCoolerEmployeesMessageNumber = 0, bossesMessageNumber = 0;
            Console.WriteLine("Press B to send to bosses");
            Console.WriteLine("Press C to send to CoolEmployees");
            Console.WriteLine("Press W to send to WayCoolerEmployees");
            while (true)
            {

                if (Console.KeyAvailable)
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.C) //cool employees
                    {
                        await connection.InvokeAsync("BroadcastToGroupName", "CoolEmployees", $"Message number {++coolEmployeesMessageNumber} - Our bosses and other collegues won't find this message");
                        Console.WriteLine("Sent to Cool employees");
                        Console.WriteLine();
                        continue;
                    }

                    if (Console.ReadKey(true).Key == ConsoleKey.W) //way cooler employees
                    {
                        await connection.InvokeAsync("BroadcastToGroupName", "WayCoolerEmployees", $"Message number {++wayCoolerEmployeesMessageNumber} - We are way cooler than the other employees and our bosses");
                        Console.WriteLine("Sent to WayCoolerEmployees");
                        Console.WriteLine();
                        continue;
                    }

                    if (Console.ReadKey(true).Key == ConsoleKey.B) //boss
                    {
                        await connection.InvokeAsync("BroadcastToGroupName", "Bosses", $"Message number {++bossesMessageNumber} - I'm sure our employees are talking on our backs...");
                        Console.WriteLine("Sent to Bosses");
                        Console.WriteLine();
                        continue;
                    }
                }
                //Console.WriteLine("Press any key to send the message to the cool employees");
                //await connection.InvokeAsync("BroadcastToGroupName", "CoolEmployees", $"Message number {++coolEmployeesMessageNumber} - Our bosses and other collegues won't find this message");
                //Console.WriteLine();

                //Console.WriteLine("Press any key to send the message to the way cooler employees");
                //Console.ReadKey();
                //await connection.InvokeAsync("BroadcastToGroupName", "WayCoolerEmployees", $"Message number {++wayCoolerEmployeesMessageNumber} - We are way cooler than the other employees and our bosses");
                //Console.WriteLine();

                //Console.WriteLine("Press any key to send the message to the bosses");
                //Console.ReadKey();
                //await connection.InvokeAsync("BroadcastToGroupName", "Bosses", $"Message number {++bossesMessageNumber} - I'm sure our employees are talking on our backs...");
                //Console.WriteLine();
            }
            
        }
    }
}
