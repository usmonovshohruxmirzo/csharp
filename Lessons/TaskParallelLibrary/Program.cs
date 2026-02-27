namespace Program
{
  class Program
  {
    static async Task Main(string[] args)
    {
      // Task basicTask = Task.Run(() =>
      // {
      //   Console.WriteLine("Running in background");
      //   Thread.Sleep(500);
      // });
      //
      // Console.WriteLine($"BasicTask Status: {basicTask.Status}");
      // await basicTask;
      // Console.WriteLine($"BasicTask Status After Await: {basicTask.Status}\n");

      // Task<int> resultTask = Task.Run(() =>
      // {
      //   Console.WriteLine("Task with result...");
      //   return 10 * 5;
      // });
      //
      // int result = await resultTask;
      // Console.WriteLine($"Result: {result}\n");

      // INFO: ContinueWith
      //
      // int result = 0;
      // await Task.Run(() =>
      // {
      //   Console.WriteLine("First step...");
      //   Thread.Sleep(1000);
      //   result += 10;
      //   Console.WriteLine("result increased to 10");
      // }).ContinueWith(t =>
      // {
      //   Thread.Sleep(1000);
      //   result += 10;
      //   Console.WriteLine("result increased to 20");
      //   Console.WriteLine("Current result is: {0}", result);
      // });
      // Console.WriteLine();

      // var task = Task.Factory.StartNew<int>(() => 16)
      //   .ContinueWith<double>(antecedent => Math.Sqrt(antecedent.Result))
      //   .ContinueWith<double>(antecedent => antecedent.Result * 2)
      //   .ContinueWith(antecedent => Console.WriteLine(antecedent.Result));
      // task.Wait();

      // INFO: WhenAll
      //
      // Task t1 = Task.Run(() => Work(1));
      // Task t2 = Task.Run(() => Work(1));
      // await Task.WhenAll(t1, t2);
      // Console.WriteLine("All tasks finished");


      // INFO:  Task.WhenAny
      //
      // Task slow = Task.Run(() =>
      // {
      //   Thread.Sleep(1000);
      //   Console.WriteLine("Slow finished");
      // });
      //
      // Task fast = Task.Run(() =>
      // {
      //   Thread.Sleep(300);
      //   Console.WriteLine("Fast finished");
      // });
      //
      // Task first = await Task.WhenAny(slow, fast);
      // Console.WriteLine($"5. First completed task Id: {first.Id}\n");


      // INFO: CancellationToken
      //
      // var cts = new CancellationTokenSource();
      //
      // Task cancelTask = Task.Run(() =>
      // {
      //   for (int i = 0; i < 10; i++)
      //   {
      //     cts.Token.ThrowIfCancellationRequested();
      //     Console.WriteLine($"Working {i}");
      //     Thread.Sleep(200);
      //   }
      // }, cts.Token);
      //
      // cts.CancelAfter(700);
      // try
      // {
      //   await cancelTask;
      // }
      // catch (OperationCanceledException)
      // {
      //   Console.WriteLine("Task Cancelled\n");
      // }

      // INFO: Exception Handling
      //
      // try
      // {
      //   await Task.Run(() =>
      //   {
      //     throw new Exception("Something failed!");
      //   });
      // }
      // catch (Exception ex)
      // {
      //   Console.WriteLine($"Caught Exception: {ex.Message}\n");
      // }


      // INFO: Parallel.For (CPU bound)
      //
      // Console.WriteLine("Parallel.For");
      // Parallel.For(0, 5, i =>
      // {
      //   Console.WriteLine($"Parallel {i} ThreadId: {Thread.CurrentThread.ManagedThreadId}");
      // });
      // Console.WriteLine();
      // Parallel.For(0, 1000000, i =>
      // {
      //   Math.Sqrt(i);
      // });


      // INFO: LongRunning Task
      //
      // Task longTask = Task.Factory.StartNew(() =>
      // {
      //   Console.WriteLine("LongRunning Task executing...");
      //   Thread.Sleep(500);
      // }, TaskCreationOptions.LongRunning);
      //
      // await longTask;
      // Console.WriteLine();


      // INFO: TaskScheduler
      //
      // TaskScheduler scheduler = TaskScheduler.Current;
      // for (int i = 0; i < 5; i++)
      // {
      //   await Task.Factory.StartNew(() =>
      //   {
      //     Console.WriteLine($"Job {Task.CurrentId}");
      //   }, CancellationToken.None,
      //      TaskCreationOptions.LongRunning,
      //      scheduler);
      // }

      // await TaskStatus.Run();

      // INFO: Task Delay
      //
      // for (int i = 1; i <= 3; i++)
      // {
      //   Console.WriteLine($"Attempt {i} to call API...");
      //
      //   bool success = await FakeApiCall();
      //
      //   if (success)
      //   {
      //     Console.WriteLine("API call successful!");
      //     break;
      //   }
      //
      //   Console.WriteLine("Retrying in 2 seconds...");
      //   await Task.Delay(2000);
      // }

      // INFO: Exception
      // var task1 = Task.Run(() => throw new Exception("Error 1"));
      // var task2 = Task.Run(() => throw new Exception("Error 2"));
      //
      // try
      // {
      //   Task.WaitAll(task1, task2);
      // }
      // catch (AggregateException ex)
      // {
      //   Console.WriteLine(ex.GetType().Name);
      //   foreach (var inner in ex.InnerExceptions)
      //   {
      //     Console.WriteLine("- {0}", inner.Message);
      //   }
      // }

      await ConcurrentDownloadManager.Run();
    }

    static async Task<bool> FakeApiCall()
    {
      await Task.Delay(500); // simulate network call
      return false; // simulate failure
    }
    static void Work(int number)
    {
      Console.WriteLine($"Task {number} running...");
      Thread.Sleep(500);
    }
  }
}
