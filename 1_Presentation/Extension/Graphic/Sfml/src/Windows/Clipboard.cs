

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     The clipboard class
    /// </summary>
    public class Clipboard
    {
        /// <summary>
        ///     The contents of the Clipboard as a UTF-32 string
        /// </summary>
        public static string Contents
        {
            get
            {
                IntPtr source = sfClipboard_getUnicodeString();

                uint length = 0;
                while (Marshal.ReadInt32(source, (int) (length * 4)) != 0)
                {
                    length++;
                }

                byte[] sourceBytes = new byte[length * 4];
                Marshal.Copy(source, sourceBytes, 0, sourceBytes.Length);

                return Encoding.UTF32.GetString(sourceBytes);
            }
            set
            {
                byte[] utf32 = Encoding.UTF32.GetBytes(value + '\0');

                GCHandle handle = GCHandle.Alloc(utf32, GCHandleType.Pinned);
                try
                {
                    sfClipboard_setUnicodeString(handle.AddrOfPinnedObject());
                }
                finally
                {
                    handle.Free();
                }
            }
        }

        /// <summary>
        ///     Sfs the clipboard get unicode string
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity, ExcludeFromCodeCoverage]
        private static extern IntPtr sfClipboard_getUnicodeString();

        /// <summary>
        ///     Sfs the clipboard set unicode string using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity, ExcludeFromCodeCoverage]
        private static extern void sfClipboard_setUnicodeString(IntPtr ptr);
    }
}