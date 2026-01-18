using System.Runtime.InteropServices;

namespace MemoryManagement
{
    class NativeBuffer : IDisposable
    {
        private IntPtr _buffer;
        private bool _disposed;

        public NativeBuffer(int size)
        {
            _buffer = Marshal.AllocHGlobal(size);
            Console.WriteLine("Allocated unmanaged memory");
        }

        ~NativeBuffer()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (_buffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_buffer);
                Console.WriteLine("Freed unmanaged memory");
                _buffer = IntPtr.Zero;
            }

            if (disposing)
            {
                // cleanup managed resources (none here)
            }

            _disposed = true;
        }
    }
}
