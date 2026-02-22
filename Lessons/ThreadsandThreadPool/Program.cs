namespace Program
{
  class Program
  {
    static int counter = 0;
    static object _lock = new object();
    static Mutex mutex = new Mutex(false, "Global\\MyUniqueMutexName");
    static Semaphore semaphore = new Semaphore(3, 3);

    static void Main(string[] args)
    {
      // Thread mainThread = Thread.CurrentThread;
      // mainThread.Name = "Main Thread";
      // Console.WriteLine(Environment.ProcessorCount);
      //
      // // Basic Thread example
      // Thread t = new Thread(PrintNumbers);
      // t.Start();
      //
      // for (int i = 0; i < 5; i++)
      // {
      //   Console.WriteLine("Main: {0}", i);
      //   Thread.Sleep(500);
      // }
      //
      // // Process vs Thread (Memory Example)
      // int shared = 0;
      //
      // static void Work()
      // {
      //   int local = 0;
      // }
      //
      // // Creating Threads (Parameterized Example)
      // Thread t1 = new Thread((obj) =>
      // {
      //   int number = (int)obj;
      //   Console.WriteLine(number * number);
      // });
      // t1.Start(5);

      /*
      Thread Lifecycle:
          States internally:
          Created
          Runnable
          Running
          Waiting
          Dead
      */
      // Thread t = new Thread(() =>
      // {
      //   Thread.Sleep(2000);
      //   Console.WriteLine("Finished");
      // });
      // t.Start();
      // t.Join();
      // Console.WriteLine("Main continues");

      // lock and Monitor
      // INFO: Race condition = When 2 or more threads access shared data at the same time and produce unpredictable results
      // Thread t1 = new Thread(Increment);
      // Thread t2 = new Thread(Increment);
      //
      // t1.Start();
      // t2.Start();
      //
      // t1.Join();
      // t2.Join();
      //
      // Console.WriteLine($"Counter = {counter}");

      // Thread t1 = new Thread(MonitorOutOfTimeoutExampe);
      // Thread t2 = new Thread(MonitorOutOfTimeoutExampe);
      //
      // t1.Start();
      // t2.Start();
      //
      // t1.Join();
      // t2.Join();

      // INFO: Mutex - Used to protect shared resources across multiple threads OR multiple processes.
      //
      // Console.WriteLine("Trying to acquire mutex...");
      //
      // if (mutex.WaitOne(0)) // INFO: Fast exit if resource is busy (or we can put in ms e.g 5000ms)
      // {
      //   try
      //   {
      //     Console.WriteLine("Mutex acquired!");
      //     Console.WriteLine("Press Enter to release...");
      //     Console.ReadLine();
      //   }
      //   finally
      //   {
      //     mutex.ReleaseMutex();
      //     Console.WriteLine("Mutex released.");
      //   }
      // }
      // else
      // {
      //   Console.WriteLine("Another instance is already running.");
      // }

      // INFO: Semaphore - Limits how many threads can access a resource at the same time.

      // for (int i = 1; i <= 10; i++)
      // {
      //   int id = i;
      //   new Thread(() => SemaphoreExample(id)).Start();
      // }

      // INFO: Thread Pool
      for (int i = 1; i <= 10; i++)
      {
        ThreadPool.QueueUserWorkItem(ThreadPoolExample, i);
      }

      Console.WriteLine("Main thread finished");
      Console.ReadLine();
    }

    static void ThreadPoolExample(object id)
    {
      Console.WriteLine($"Task {id} started on Thread {Thread.CurrentThread.ManagedThreadId}");

      Thread.Sleep(2000); // Simulate work

      Console.WriteLine($"Task {id} finished");
    }

    static void SemaphoreExample(int id)
    {
      Console.WriteLine($"Thread {id} waiting... ⏳");

      semaphore.WaitOne(); // Try to enter

      try
      {
        Console.WriteLine($"Thread {id} entered ✅");
        Thread.Sleep(3000); // Simulate work
      }
      finally
      {
        Console.WriteLine($"Thread {id} leaving ❌");
        semaphore.Release();
      }
    }

    static void Increment()
    {
      for (int i = 0; i < 100000; i++)
      {
        // lock (_lock)
        // {
        //   counter++;
        // }
        if (Monitor.TryEnter(_lock, 1000))
        {
          try
          {
            counter++;
          }
          finally
          {
            Monitor.Exit(_lock);
          }
        }
      }
    }

    static void MonitorOutOfTimeoutExampe()
    {
      if (Monitor.TryEnter(_lock, 1000))
      {
        try
        {
          Console.WriteLine($"Lock acquired by {Thread.CurrentThread.ManagedThreadId}");
          Thread.Sleep(5000);
        }
        finally
        {
          Monitor.Exit(_lock);
        }
      }
      else
      {
        Console.WriteLine($"Failed to acquire lock by {Thread.CurrentThread.ManagedThreadId}");
      }
    }

    static void PrintNumbers()
    {
      for (int i = 0; i < 5; i++)
      {
        Console.WriteLine($"Thread: {i}");
        Thread.Sleep(500);
      }
    }
  }
}
