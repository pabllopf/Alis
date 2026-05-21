

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl renderer info
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RendererInfo
    {
        /// <summary>
        ///     The name
        /// </summary>
        public IntPtr Name { get; set; }

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
        public int textureFormats0;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public int textureFormats1;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public int textureFormats2;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public int textureFormats3;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public int textureFormats4;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public int textureFormats5;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public int textureFormats6;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public int textureFormats7;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public int textureFormats8;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public int textureFormats9;

        /// <summary>
        ///     The texture formats 10
        /// </summary>
        public int textureFormats10;

        /// <summary>
        ///     The texture formats 11
        /// </summary>
        public int textureFormats11;

        /// <summary>
        ///     The texture formats 12
        /// </summary>
        public int textureFormats12;

        /// <summary>
        ///     The texture formats 13
        /// </summary>
        public int textureFormats13;

        /// <summary>
        ///     The texture formats 14
        /// </summary>
        public int textureFormats14;

        /// <summary>
        ///     The texture formats 15
        /// </summary>
        public int textureFormats15;

        /// <summary>
        ///     The max texture width
        /// </summary>
        public int maxTextureWidth;

        /// <summary>
        ///     The max texture height
        /// </summary>
        public int maxTextureHeight;

        /// <summary>
        ///     Gets the name
        /// </summary>
        /// <returns>The string</returns>
        public string GetName() => Marshal.PtrToStringAnsi(Name);
    }
}