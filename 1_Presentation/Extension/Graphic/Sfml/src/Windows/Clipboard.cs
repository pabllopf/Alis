using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    /// The clipboard class
    /// </summary>
    public class Clipboard
    {
        /// <summary>
        /// The contents of the Clipboard as a UTF-32 string
        /// </summary>
       public static string Contents
        {
            get
            {
                IntPtr source = sfClipboard_getUnicodeString();
        
                // Buscar la longitud (terminador 0)
                uint length = 0;
                while (Marshal.ReadInt32(source, (int)(length * 4)) != 0)
                {
                    length++;
                }
        
                // Copiar a un array de bytes
                byte[] sourceBytes = new byte[length * 4];
                Marshal.Copy(source, sourceBytes, 0, sourceBytes.Length);
        
                // Convertir a string C#
                return Encoding.UTF32.GetString(sourceBytes);
            }
            set
            {
                // Convertir a UTF-32 null-terminated
                byte[] utf32 = Encoding.UTF32.GetBytes(value + '\0');
        
                // Fijar el array y pasar el puntero
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
        /// Sfs the clipboard get unicode string
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfClipboard_getUnicodeString();

        /// <summary>
        /// Sfs the clipboard set unicode string using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfClipboard_setUnicodeString(IntPtr ptr);
    }
}
