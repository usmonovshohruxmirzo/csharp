using System.Diagnostics;

public class ConcurrentDownloadManager
{
  private static readonly Random _random = new();

  private static int _success;
  private static int _failed;
  private static int _cancelled;

  public static async Task Run()
  {
    var stopwatch = Stopwatch.StartNew();

    using CancellationTokenSource cts = new();
    using SemaphoreSlim semaphore = new(3);

    var files = Enumerable.Range(1, 20)
        .Select(i => new FileItem
        {
          Id = i,
          Name = $"File_{i}",
          SizeMb = _random.Next(1, 50)
        })
        .ToList();

    Console.WriteLine("Starting downloads...\n");

    var tasks = files.Select(file => ProcessFileAsync(file, semaphore, cts)).ToList();

    try
    {
      await Task.WhenAll(tasks);
    }
    catch (OperationCanceledException)
    {
      Console.WriteLine("Global cancellation triggered\n");
    }

    stopwatch.Stop();

    Console.BackgroundColor = ConsoleColor.Green;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("\n===== SUMMARY =====");
    Console.WriteLine($"Success:   {_success}");
    Console.WriteLine($"Failed:    {_failed}");
    Console.WriteLine($"Cancelled: {_cancelled}");
    Console.WriteLine($"Time:      {stopwatch.ElapsedMilliseconds} ms");
    Console.ResetColor();
  }

  private static async Task ProcessFileAsync(
      FileItem file,
      SemaphoreSlim semaphore,
      CancellationTokenSource cts)
  {
    try
    {
      Console.WriteLine($"▶ Starting {file.Name}");

      await semaphore.WaitAsync(cts.Token);

      await ExecuteWithRetryAsync(file, cts);

      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"Finished {file.Name}");
      Console.ResetColor();
    }
    catch (OperationCanceledException)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine($"Cancelled {file.Name}");
      Console.ResetColor();

      Interlocked.Increment(ref _cancelled);
    }
    catch (Exception ex)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine($"Error {file.Name} -> {ex.Message}");
      Console.ResetColor();
    }
    finally
    {
      semaphore.Release();
    }
  }

  private static async Task ExecuteWithRetryAsync(
      FileItem file,
      CancellationTokenSource cts)
  {
    int retry = 0;
    int maxRetries = 2;

    while (true)
    {
      try
      {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Downloading {file.Name} (Retry {retry})");
        Console.ResetColor();

        await DownloadFileAsync(file, cts.Token);

        Interlocked.Increment(ref _success);

        return;
      }
      catch (OperationCanceledException)
      {
        throw;
      }
      catch (Exception ex)
      {
        retry++;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{file.Name} failed: {ex.Message}");
        Console.ResetColor();

        if (retry > maxRetries)
        {
          int totalFailed = Interlocked.Increment(ref _failed);

          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine($"Permanent failure: {file.Name}");
          Console.ResetColor();

          if (totalFailed >= 5)
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Too many failures — Cancelling system!");
            Console.ResetColor();

            cts.Cancel();
          }

          return;
        }

        int delay = retry == 1 ? 500 : 1000;
        await Task.Delay(delay, cts.Token);
      }
    }
  }

  private static async Task<FileResult> DownloadFileAsync(
      FileItem file,
      CancellationToken token)
  {
    // Simulate network latency
    int delay = _random.Next(200, 1500);
    await Task.Delay(delay, token);

    // 80% failure simulation (hard test mode)
    if (_random.NextDouble() < 0.2)
      throw new Exception("Network error");

    return new FileResult
    {
      FileId = file.Id,
      Success = true
    };
  }
}

