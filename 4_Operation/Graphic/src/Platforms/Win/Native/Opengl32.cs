#if WIN

using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    
    /// <summary>
    /// 
    /// </summary>
    internal static class Opengl32
    {
        /// <summary>
        /// 
        /// </summary>
        private const string DllName = "opengl32.dll";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdc"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "wglCreateContext")]
        public static extern IntPtr wglCreateContext(IntPtr hdc);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="hglrc"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "wglMakeCurrent")]
        public static extern bool wglMakeCurrent(IntPtr hdc, IntPtr hglrc);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hglrc"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "wglDeleteContext")]
        public static extern bool wglDeleteContext(IntPtr hglrc);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpszProc"></param>
        /// <returns></returns>
        [DllImport("opengl32.dll", SetLastError = true, EntryPoint = "wglGetProcAddress")]
        public static extern IntPtr wglGetProcAddress(string lpszProc);
    }
}

#endif