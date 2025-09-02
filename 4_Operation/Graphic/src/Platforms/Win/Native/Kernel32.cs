#if WIN

using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    /// 
    /// </summary>
    internal static class Kernel32
    {
        /// <summary>
        /// 
        /// </summary>
        private const string DllName = "kernel32.dll";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "LoadLibrary")]
        public static extern IntPtr LoadLibrary(string lpFileName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hModule"></param>
        /// <param name="lpProcName"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "GetProcAddress")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
    }
}

#endif
