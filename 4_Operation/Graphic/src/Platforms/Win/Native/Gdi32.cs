#if WIN

using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    /// 
    /// </summary>
    internal static class Gdi32
    {
        /// <summary>
        /// 
        /// </summary>
        private const string DllName = "gdi32.dll";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="ppfd"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "ChoosePixelFormat")]
        public static extern int ChoosePixelFormat(IntPtr hdc, ref Pixelformatdescriptor ppfd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="format"></param>
        /// <param name="ppfd"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "SetPixelFormat")]
        public static extern bool SetPixelFormat(IntPtr hdc, int format, ref Pixelformatdescriptor ppfd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdc"></param>
        /// <returns></returns>
        [DllImport(DllName, SetLastError = true, EntryPoint = "SwapBuffers")]
        public static extern bool SwapBuffers(IntPtr hdc);
    }
}

#endif