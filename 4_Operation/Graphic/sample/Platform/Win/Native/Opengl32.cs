#if WIN

using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Sample.Platform.Win.Native
{
    internal static class Opengl32
    {
        private const string DllName = "opengl32.dll";

        [DllImport(DllName, SetLastError = true, EntryPoint = "wglCreateContext")]
        public static extern IntPtr wglCreateContext(IntPtr hdc);

        [DllImport(DllName, SetLastError = true, EntryPoint = "wglMakeCurrent")]
        public static extern bool wglMakeCurrent(IntPtr hdc, IntPtr hglrc);

        [DllImport(DllName, SetLastError = true, EntryPoint = "wglDeleteContext")]
        public static extern bool wglDeleteContext(IntPtr hglrc);

        [DllImport("opengl32.dll", SetLastError = true, EntryPoint = "wglGetProcAddress")]
        public static extern IntPtr wglGetProcAddress(string lpszProc);
    }
}

#endif