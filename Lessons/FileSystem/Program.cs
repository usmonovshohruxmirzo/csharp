/* INFO:
 * Main namespaces:
 *    System.IO → Core namespace for file and directory operations.
 *    System.IO.Compression → For zip and compression.
 *    System.IO.MemoryMappedFiles → For advanced file memory mapping.
*/

/* INFO:
 * Important Classes:
 * File → Static methods for file operations (create, copy, delete, read/write).
 * FileInfo → Instance methods for file details (size, creation time).
 * Directory → Static methods for directories (create, delete, enumerate).
 * DirectoryInfo → Instance methods for directory details.
 * Path → Static methods for path manipulation.
 * DriveInfo → Provides info about drives (C:, D:, USB).
 * FileStream → Stream for reading/writing bytes.
 * StreamReader / StreamWriter → Work with text files.
 * BinaryReader / BinaryWriter → Work with binary files.
*/

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // INFO: Working with Files
            H("Working with Files");
            string path = "example.txt";

            // Write text to a file (overwrites if exists)
            File.WriteAllText(path, "Hello, C# File System");
            Console.WriteLine("File created and text written.");

            // Reading a File
            string text = File.ReadAllText(path);
            Console.WriteLine("File content: " + text);

            // Appending Text
            File.AppendAllText(path, "\nAppended Text");
            string appendedtext = File.ReadAllText(path);
            Console.WriteLine("File content: " + appendedtext);

            // Copy, Move, Delete
            // File.Copy(path, "example_copy.txt", true); // overwrite = true
            // File.Move("example_copy.txt", "move.txt"); // renaming
            // File.Delete("example_copy.txt");

            // INFO: FileInfo Class
            H("FileInfo Class");
            FileInfo fi = new FileInfo(path);
            Console.WriteLine("Name: {0}", fi.Name);
            Console.WriteLine("Full Path: {0}", fi.FullName);
            Console.WriteLine("Size: {0} bytes", fi.Length);
            Console.WriteLine("Created: {0}", fi.CreationTime);


            // INFO: Directories
            H("Directories");
            Directory.CreateDirectory("TestDir");

            Console.WriteLine("Files\n");
            string[] files = Directory.GetFiles(".");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }

            Console.WriteLine("\nDirs\n");
            string[] dirs = Directory.GetDirectories(".");
            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
            }

            Console.WriteLine("\nDirectoryInfo\n");
            DirectoryInfo di = new DirectoryInfo("TestDir");
            Console.WriteLine("Directory: {0}", di.FullName);
            Console.WriteLine("Created: {0}", di.CreationTime);

            // INFO: Path Class
            H("Path Class");
            string filePath = @"D:\Usmonov Shohruxmirozs Projects\C#\c-sharp\Lessons\FileSystem\example.txt";
            Console.WriteLine(Path.GetDirectoryName(filePath));
            Console.WriteLine(Path.GetFileName(filePath));
            Console.WriteLine(Path.GetExtension(filePath));
            Console.WriteLine(Path.Combine("C:\\Users", "data.txt"));

            // INFO: DriveInfo
            H("DriveInfo");
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo d in drives)
            {
                Console.WriteLine($"Drive {d.Name}");
                if (d.IsReady)
                {
                    Console.WriteLine($"Type: {d.DriveType}");
                    Console.WriteLine($"Free space: {d.AvailableFreeSpace / (1024 * 1024)} MB");
                    Console.WriteLine($"Format: {d.DriveFormat}");
                }
            }

            // INFO: File Streams
            H("File Streams");

            // Writing Bytes with FileStream
            using (FileStream fs = new FileStream("data.bin", FileMode.Create))
            {
                byte[] bytes = { 65, 66, 67, 68 };
                fs.Write(bytes, 0, bytes.Length);
            }

            // Reading Bytes
            using (FileStream fs = new FileStream("data.bin", FileMode.Open))
            {
              int b;
              while ((b = fs.ReadByte()) != -1) // Reads bytes until EOF (end of file) -1.
              {
                Console.WriteLine((char)(b));
              }
            }

           // INFO: StreamReader & StreamWriter 
           H("StreamReader & StreamWriter");

           using (StreamWriter sw = new StreamWriter("log.txt"))
           {
             sw.WriteLine("Log entry 1");
             sw.WriteLine("Log entry 2");
           }

           using (StreamReader sr = new StreamReader("log.txt"))
           {
             string line;
             while ((line = sr.ReadLine()) != null)
             {
               Console.WriteLine(line);
             }
           }

           // INFO: BinaryReader & BinaryWriter
           
           // INFO: File Attributes & Security
           
           // INFO: FileSystemWatcher (Monitor Changes)
           H("FileSystemWatcher (Monitor Changes)");
           FileSystemWatcher watcher = new FileSystemWatcher();
           watcher.Path = ".";
           watcher.Filter = ".txt";
           watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;

           watcher.Changed += (s, e) => Console.WriteLine($"Changed: {e.FullPath}");
           watcher.Changed += (s, e) => Console.WriteLine($"Created: {e.FullPath}");
           watcher.Changed += (s, e) => Console.WriteLine($"Deleted: {e.FullPath}");

           watcher.EnableRaisingEvents = true;

           Console.WriteLine("Watching folder... Press Enter to exit.");

        }

        public static void H(string text) => Console.WriteLine($"\n================= {text} =================\n");
    }
}
