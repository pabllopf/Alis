using System;
using System.Runtime.InteropServices;

namespace Veldrid.Android
{
    /// <summary>
    /// Function imports from the Android runtime library (android.so).
    /// </summary>
    internal static class AndroidRuntime
    {
        /// <summary>
        /// The lib name
        /// </summary>
        private const string LibName = "android.so";

        /// <summary>
        /// As the native window from surface using the specified jni env
        /// </summary>
        /// <param name="jniEnv">The jni env</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(LibName)]
        public static extern IntPtr ANativeWindow_fromSurface(IntPtr jniEnv, IntPtr surface);
        /// <summary>
        /// As the native window set buffers geometry using the specified a native window
        /// </summary>
        /// <param name="aNativeWindow">The native window</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="format">The format</param>
        /// <returns>The int</returns>
        [DllImport(LibName)]
        public static extern int ANativeWindow_setBuffersGeometry(IntPtr aNativeWindow, int width, int height, int format);
        /// <summary>
        /// As the native window release using the specified a native window
        /// </summary>
        /// <param name="aNativeWindow">The native window</param>
        [DllImport(LibName)]
        public static extern void ANativeWindow_release(IntPtr aNativeWindow);
    }
}
