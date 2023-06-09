using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl rendererinfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlRendererInfo
    {
        /// <summary>
        ///     The name
        /// </summary>
        public IntPtr name; // const char*

        /// <summary>
        ///     The flags
        /// </summary>
        public uint flags;

        /// <summary>
        ///     The num texture formats
        /// </summary>
        public uint num_texture_formats;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public IntPtr textureFormatsPtr;

        /// <summary>
        ///     The max texture width
        /// </summary>
        public int max_texture_width;

        /// <summary>
        ///     The max texture height
        /// </summary>
        public int max_texture_height;
        
        /// <summary>
        /// Gets or sets the value of the text
        /// </summary>
        public int[] texture_formats
        {
            get
            {
                int[] dataBytes = new int[16];
                Buffer.BlockCopy(texture_formats, 0, dataBytes, 0, 16);
                return dataBytes;
            }
            set => Marshal.Copy(value, 0, textureFormatsPtr, 16);
        }
    }
}