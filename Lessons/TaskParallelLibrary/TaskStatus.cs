class TaskStatus
{
  public static async Task Run()
  {
    Task task = new Task(() =>
    {
      Console.WriteLine($"Inside Task -> Status: {Task.CurrentId} Running");
      Thread.Sleep(1000);
    });
    Console.WriteLine($"1. Created Status: {task.Status}");

    task.Start();
    Console.WriteLine($"2. After Start -> {task.Status}");
    
    await task;

    Console.WriteLine($"3. After Completion -> {task.Status}\n");


    // ===============================
    // 4️⃣ Faulted Example
    // ===============================

    Task faultTask = Task.Run(() =>
    {
      throw new Exception("Test Exception");
    });

    try
    {
      await faultTask;
    }
    catch { }

    Console.WriteLine($"4. Faulted Status -> {faultTask.Status}\n");


    // ===============================
    // 5️⃣ Canceled Example
    // ===============================

    CancellationTokenSource cts = new();

    Task cancelTask = Task.Run(() =>
    {
      while (true)
      {
        cts.Token.ThrowIfCancellationRequested();
      }
    }, cts.Token);

    cts.Cancel();

    try
    {
      await cancelTask;
    }
    catch { }

    Console.WriteLine($"5. Canceled Status -> {cancelTask.Status}");
  }
}
