

#if winx64 || winx86 || winarm64 || winarm || win
using System;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    /// </summary>
    internal static class Kernel32
    {
        /// <summary>
        /// </summary>
        private const string DllName = "kernel32.dll";

        /// <summary>
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "LoadLibrary")]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr LoadLibrary(string lpFileName);

        /// <summary>
        /// </summary>
        /// <param name="hModule"></param>
        /// <param name="lpProcName"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "GetProcAddress")]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
    }
}

#endif