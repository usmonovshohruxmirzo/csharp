/* INFO:
 * Asynchronous programming allows your program to:
 * Start a long-running operation
 * Continue doing other work
 * Resume when the operation finishes 
 * It prevents blocking threads.
*/

namespace Program
{
  class Program
  {
    static async Task Main(string[] args)
    {
      // await BasicAsyncExample();
      // await TaskCoordinationExample();
      // await CancellationExample();
      // await ProgressExample();
      // await HttpExample();
      await ParallelExample();
    }

    static async Task BasicAsyncExample()
    {
      Console.WriteLine("\n[Basic Async] Starting...");
      await Task.Delay(1000);
      Console.WriteLine("[Basic Async] Completed");
    }

    static async Task TaskCoordinationExample()
    {
      Console.WriteLine("\n[Task Coordination] Starting...");
      Task t1 = Task.Delay(1000);
      Task t2 = Task.Delay(1500);
      await Task.WhenAll(t1, t2);
      Console.WriteLine("[Task Coordination] Both tasks finished");
    }

    static async Task CancellationExample()
    {
      Console.WriteLine("\n [Cancellation] Starting...");
      using CancellationTokenSource cts = new();
      Task longTask = Task.Run(async () =>
      {
        for (int i = 0; i < 10; i++)
        {
          cts.Token.ThrowIfCancellationRequested();
          Console.WriteLine($"Working... {i}");
          await Task.Delay(300);
        }
      });

      cts.CancelAfter(TimeSpan.FromSeconds(1));

      try
      {
        await longTask;
      }
      catch (OperationCanceledException)
      {
        Console.WriteLine("[Cancellation] Task cancelled");
      }
    }

    static async Task ProgressExample()
    {
      Console.WriteLine("\n[Progress Bar]");
      int spinnerIndex = 0;
      string[] spinner = { "|", "/", "-", "\\" };

      var progress = new Progress<int>(percent =>
      {
        int totalBlocks = 50;
        int filledBlocks = percent * totalBlocks / 100;
        string bar = new string('#', filledBlocks) + new string('-', totalBlocks - filledBlocks);
        string loader = spinner[spinnerIndex % spinner.Length];
        spinnerIndex++;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"\r[{bar}] {percent}% {loader}    "); //  INFO: `\r` = carriage return, It moves the cursor to the beginning of the same line.
        Console.ResetColor();
      });

      await DownloadSimulation(progress);

      Console.WriteLine("\nDone!");
    }

    static async Task DownloadSimulation(IProgress<int> progress)
    {
      for (int i = 0; i <= 100; i += 5)
      {
        await Task.Delay(300);
        progress.Report(i);
      }
    }

    static async Task HttpExample()
    {
      Console.WriteLine("\n[HTTP Async] Starting...");
      string URL = "https://jsonplaceholder.typicode.com/todos/1";

      using HttpClient client = new();
      var response = await client.GetStringAsync(URL);
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine(response);
      Console.ResetColor();
    }

    static async Task ParallelExample()
    {
      Console.WriteLine("\n[Parallel CPU Work] Starting...");
      var env = Environment.CurrentManagedThreadId;
      Parallel.For(0, 5, i =>
      {
        Console.WriteLine($"Parallel Work {i} Thread {env}");
      });
      Console.WriteLine("[Parallel CPU Work] Finished");
    }
  }
}
