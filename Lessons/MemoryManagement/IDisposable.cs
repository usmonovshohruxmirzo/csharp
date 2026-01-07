using System;
using System.IO;

class FileHandler : IDisposable
{
    private StreamReader reader;

    public FileHandler(string path)
    {
        reader = new StreamReader(path);
        Console.WriteLine("File Opened.");
    }

    public void ReadFile() {
      Console.WriteLine(reader.ReadLine());
    }

    public void Dispose()
    {
        if (reader != null)
        {
            reader.Close();
            Console.WriteLine("File Closed.");
        }
    }
}
