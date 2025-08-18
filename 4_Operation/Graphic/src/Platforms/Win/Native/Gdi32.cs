#if WIN

using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    internal static class Gdi32
    {
        private const string DllName = "gdi32.dll";

        [DllImport(DllName, SetLastError = true, EntryPoint = "ChoosePixelFormat")]
        public static extern int ChoosePixelFormat(IntPtr hdc, ref Pixelformatdescriptor ppfd);

        [DllImport(DllName, SetLastError = true, EntryPoint = "SetPixelFormat")]
        public static extern bool SetPixelFormat(IntPtr hdc, int format, ref Pixelformatdescriptor ppfd);

        [DllImport(DllName, SetLastError = true, EntryPoint = "SwapBuffers")]
        public static extern bool SwapBuffers(IntPtr hdc);
    }
}

#endif