using System;
using System.Runtime.InteropServices;

namespace NativeLibraryLoader
{
    /// <summary>
    /// The libdl class
    /// </summary>
    internal static class Libdl
    {
        /// <summary>
        /// The libdl class
        /// </summary>
        private static class Libdl1
        {
            /// <summary>
            /// The lib name
            /// </summary>
            private const string LibName = "libdl";

            /// <summary>
            /// Dlopens the file name
            /// </summary>
            /// <param name="fileName">The file name</param>
            /// <param name="flags">The flags</param>
            /// <returns>The int ptr</returns>
            [DllImport(LibName)]
            public static extern IntPtr dlopen(string fileName, int flags);

            /// <summary>
            /// Dlsyms the handle
            /// </summary>
            /// <param name="handle">The handle</param>
            /// <param name="name">The name</param>
            /// <returns>The int ptr</returns>
            [DllImport(LibName)]
            public static extern IntPtr dlsym(IntPtr handle, string name);

            /// <summary>
            /// Dlcloses the handle
            /// </summary>
            /// <param name="handle">The handle</param>
            /// <returns>The int</returns>
            [DllImport(LibName)]
            public static extern int dlclose(IntPtr handle);

            /// <summary>
            /// Dlerrors
            /// </summary>
            /// <returns>The string</returns>
            [DllImport(LibName)]
            public static extern string dlerror();
        }

        /// <summary>
        /// The libdl class
        /// </summary>
        private static class Libdl2
        {
            /// <summary>
            /// The lib name
            /// </summary>
            private const string LibName = "libdl.so.2";

            /// <summary>
            /// Dlopens the file name
            /// </summary>
            /// <param name="fileName">The file name</param>
            /// <param name="flags">The flags</param>
            /// <returns>The int ptr</returns>
            [DllImport(LibName)]
            public static extern IntPtr dlopen(string fileName, int flags);

            /// <summary>
            /// Dlsyms the handle
            /// </summary>
            /// <param name="handle">The handle</param>
            /// <param name="name">The name</param>
            /// <returns>The int ptr</returns>
            [DllImport(LibName)]
            public static extern IntPtr dlsym(IntPtr handle, string name);

            /// <summary>
            /// Dlcloses the handle
            /// </summary>
            /// <param name="handle">The handle</param>
            /// <returns>The int</returns>
            [DllImport(LibName)]
            public static extern int dlclose(IntPtr handle);

            /// <summary>
            /// Dlerrors
            /// </summary>
            /// <returns>The string</returns>
            [DllImport(LibName)]
            public static extern string dlerror();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Libdl"/> class
        /// </summary>
        static Libdl()
        {
            try
            {
                Libdl1.dlerror();
                m_useLibdl1 = true;
            }
            catch
            {
            }
        }

        /// <summary>
        /// The uselibdl1
        /// </summary>
        private static bool m_useLibdl1;

        /// <summary>
        /// The rtld now
        /// </summary>
        public const int RTLD_NOW = 0x002;

        /// <summary>
        /// Dlopens the file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        public static IntPtr dlopen(string fileName, int flags) => m_useLibdl1 ? Libdl1.dlopen(fileName, flags) : Libdl2.dlopen(fileName, flags);

        /// <summary>
        /// Dlsyms the handle
        /// </summary>
        /// <param name="handle">The handle</param>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        public static IntPtr dlsym(IntPtr handle, string name) => m_useLibdl1 ? Libdl1.dlsym(handle, name) : Libdl2.dlsym(handle, name);

        /// <summary>
        /// Dlcloses the handle
        /// </summary>
        /// <param name="handle">The handle</param>
        /// <returns>The int</returns>
        public static int dlclose(IntPtr handle) => m_useLibdl1 ? Libdl1.dlclose(handle) : Libdl2.dlclose(handle);

        /// <summary>
        /// Dlerrors
        /// </summary>
        /// <returns>The string</returns>
        public static string dlerror() => m_useLibdl1 ? Libdl1.dlerror() : Libdl2.dlerror();
    }
}
