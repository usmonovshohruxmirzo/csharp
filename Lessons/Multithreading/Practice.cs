#pragma warning disable

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class MultiUserChatServerSimulator
{
    // Shared message queue (thread-safe)
    private static ConcurrentQueue<string> MessageQueue = new ConcurrentQueue<string>();

    // Active user count (atomic)
    private static int ActiveUsers = 0;

    // Lock for controlled access
    private static ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();

    public static async Task Run(int totalUsers = 100, int durationSeconds = 5)
    {
        Console.WriteLine("Starting Multi-User Chat Server Simulator...");

        CancellationTokenSource cts = new CancellationTokenSource();

        // Start message delivery task
        var deliveryTask = Task.Run(() => DeliverMessages(cts.Token));

        // Start user tasks
        var userTasks = new List<Task>();
        for (int i = 1; i <= totalUsers; i++)
        {
            int userId = i;
            userTasks.Add(Task.Run(() => UserSimulation(userId, cts.Token)));
        }

        // Run simulation for specified duration
        await Task.Delay(durationSeconds * 1000);
        cts.Cancel(); // Signal cancellation

        // Wait for all tasks to finish
        await Task.WhenAll(userTasks);
        await deliveryTask;

        Console.WriteLine($"Simulation finished. Active users: {ActiveUsers}");
    }

    private static async Task UserSimulation(int userId, CancellationToken token)
    {
        Interlocked.Increment(ref ActiveUsers);
        Random rnd = new Random();

        while (!token.IsCancellationRequested)
        {
            string message = $"User {userId} says hello at {DateTime.Now:T}";

            // Safely enqueue message
            rwLock.EnterWriteLock();
            try
            {
                MessageQueue.Enqueue(message);
            }
            finally
            {
                rwLock.ExitWriteLock();
            }

            // Simulate user typing/network delay
            await Task.Delay(rnd.Next(50, 200));
        }

        Interlocked.Decrement(ref ActiveUsers);
    }

    private static async Task DeliverMessages(CancellationToken token)
    {
        while (!token.IsCancellationRequested || !MessageQueue.IsEmpty)
        {
            if (MessageQueue.TryDequeue(out string message))
            {
                // Simulate I/O-bound work
                await Task.Delay(50);
                Console.WriteLine($"Delivered: {message}");
            }
            else
            {
                await Task.Delay(10); // avoid busy waiting
            }
        }
    }
}
