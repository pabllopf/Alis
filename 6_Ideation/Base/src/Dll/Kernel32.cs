using System;
using System.Runtime.InteropServices;

namespace NativeLibraryLoader
{
    /// <summary>
    /// The kernel 32 class
    /// </summary>
    internal static class Kernel32
    {
        /// <summary>
        /// Loads the library using the specified file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <returns>The int ptr</returns>
        [DllImport("kernel32")]
        public static extern IntPtr LoadLibrary(string fileName);

        /// <summary>
        /// Gets the proc address using the specified module
        /// </summary>
        /// <param name="module">The module</param>
        /// <param name="procName">The proc name</param>
        /// <returns>The int ptr</returns>
        [DllImport("kernel32")]
        public static extern IntPtr GetProcAddress(IntPtr module, string procName);

        /// <summary>
        /// Frees the library using the specified module
        /// </summary>
        /// <param name="module">The module</param>
        /// <returns>The int</returns>
        [DllImport("kernel32")]
        public static extern int FreeLibrary(IntPtr module);
    }
}
