// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Clipboard.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
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

                // Buscar la longitud (terminador 0)
                uint length = 0;
                while (Marshal.ReadInt32(source, (int) (length * 4)) != 0)
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
        ///     Sfs the clipboard get unicode string
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        [ExcludeFromCodeCoverage]
        private static extern IntPtr sfClipboard_getUnicodeString();

        /// <summary>
        ///     Sfs the clipboard set unicode string using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        [ExcludeFromCodeCoverage]
        private static extern void sfClipboard_setUnicodeString(IntPtr ptr);
    }
}