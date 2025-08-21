#if WIN

using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    internal static class Kernel32
    {
        private const string DllName = "kernel32.dll";

        [DllImport(DllName, SetLastError = true, EntryPoint = "LoadLibrary")]
        public static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport(DllName, SetLastError = true, EntryPoint = "GetProcAddress")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
    }
}

#endif
