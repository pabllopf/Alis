using System;
    using System.Runtime.InteropServices;
    
    namespace Alis.Core.Graphic.Stb.Hebron.Runtime
    {
        internal static class CRuntime
        {
            public static IntPtr Malloc(long size)
            {
                IntPtr ptr = Marshal.AllocHGlobal((int)size);
                MemoryStats.Allocated();
                return ptr;
            }
    
            public static void Free(IntPtr ptr)
            {
                if (ptr == IntPtr.Zero)
                {
                    return;
                }
    
                Marshal.FreeHGlobal(ptr);
                MemoryStats.Freed();
            }
            
            
            /// <summary>
            ///     Lrotls the x
            /// </summary>
            /// <param name="x">The </param>
            /// <param name="y">The </param>
            /// <returns>The uint</returns>
            public static uint Lrotl(uint x, int y) => (x << y) | (x >> (32 - y));
    
            public static void Memcpy(IntPtr dest, IntPtr src, long size)
            {
                byte[] buffer = new byte[size];
                Marshal.Copy(src, buffer, 0, (int)size);
                Marshal.Copy(buffer, 0, dest, (int)size);
            }
    
            public static void Memmove(IntPtr dest, IntPtr src, long size)
            {
                byte[] buffer = new byte[size];
                Marshal.Copy(src, buffer, 0, (int)size);
                Marshal.Copy(buffer, 0, dest, (int)size);
            }
    
            public static int Memcmp(IntPtr a, IntPtr b, long size)
            {
                byte[] bufferA = new byte[size];
                byte[] bufferB = new byte[size];
                Marshal.Copy(a, bufferA, 0, (int)size);
                Marshal.Copy(b, bufferB, 0, (int)size);
    
                for (int i = 0; i < size; i++)
                {
                    if (bufferA[i] != bufferB[i])
                    {
                        return 1;
                    }
                }
    
                return 0;
            }
    
            public static void Memset(IntPtr ptr, int value, long size)
            {
                byte[] buffer = new byte[size];
                for (int i = 0; i < size; i++)
                {
                    buffer[i] = (byte)value;
                }
                Marshal.Copy(buffer, 0, ptr, (int)size);
            }
    
            public static IntPtr Realloc(IntPtr ptr, long newSize)
            {
                if (ptr == IntPtr.Zero)
                {
                    return Malloc(newSize);
                }
    
                IntPtr newPtr = Marshal.ReAllocHGlobal(ptr, new IntPtr(newSize));
                return newPtr;
            }

            public static IntPtr Alloc(int outputLength)
            {
                IntPtr ptr = Malloc(outputLength);
                if (ptr == IntPtr.Zero)
                {
                    throw new OutOfMemoryException("Failed to allocate memory.");
                }
                return ptr;
            }
        }
    }