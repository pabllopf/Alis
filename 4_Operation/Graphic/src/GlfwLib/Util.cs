﻿using System;
using System.Runtime.InteropServices;
using System.Text;


namespace Alis.Core.Graphic.GlfwLib
{
    internal static class Util
    {
        #region Methods

        /// <summary>
        ///     Reads memory from the pointer until the first null byte is encountered and decodes the bytes from UTF-8 into a
        ///     managed <see cref="string" />.
        /// </summary>
        /// <param name="ptr">Pointer to the start of the string.</param>
        /// <returns>Managed string created from read UTF-8 bytes.</returns>
        
        // ReSharper disable once InconsistentNaming
        public static string PtrToStringUTF8(IntPtr ptr)
        {
            if (ptr != IntPtr.Zero)
            {
                int length = 0;
                while (Marshal.ReadByte(ptr, length) != 0)
                    length++;
                byte[] buffer = new byte[length];
                Marshal.Copy(ptr, buffer, 0, length);
                return Encoding.UTF8.GetString(buffer);
            }

            return "";
        }

        #endregion
    }
}