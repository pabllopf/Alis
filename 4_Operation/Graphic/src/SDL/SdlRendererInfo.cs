// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlRendererInfo.cs
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
        public int textureFormats0;
        
        /// <summary>
        /// The texture formats
        /// </summary>
        public int textureFormats1;
        
        /// <summary>
        /// The texture formats
        /// </summary>
        public int textureFormats2;
        
        /// <summary>
        /// The texture formats
        /// </summary>
        public int textureFormats3;
        
        /// <summary>
        /// The texture formats
        /// </summary>
        public int textureFormats4;
        
        /// <summary>
        /// The texture formats
        /// </summary>
        public int textureFormats5;
        
        /// <summary>
        /// The texture formats
        /// </summary>
        public int textureFormats6;
        
        /// <summary>
        /// The texture formats
        /// </summary>
        public int textureFormats7;
        
        /// <summary>
        /// The texture formats
        /// </summary>
        public int textureFormats8;
        
        /// <summary>
        /// The texture formats
        /// </summary>
        public int textureFormats9;
        
        /// <summary>
        /// The texture formats 10
        /// </summary>
        public int textureFormats10;
        
        /// <summary>
        /// The texture formats 11
        /// </summary>
        public int textureFormats11;
        
        /// <summary>
        /// The texture formats 12
        /// </summary>
        public int textureFormats12;
        
        /// <summary>
        /// The texture formats 13
        /// </summary>
        public int textureFormats13;
        
        /// <summary>
        /// The texture formats 14
        /// </summary>
        public int textureFormats14;
        
        /// <summary>
        /// The texture formats 15
        /// </summary>
        public int textureFormats15;
        
        /// <summary>
        ///     The max texture width
        /// </summary>
        public int max_texture_width;

        /// <summary>
        ///     The max texture height
        /// </summary>
        public int max_texture_height;

        /// <summary>
        ///     Gets or sets the value of the text
        /// </summary>
        public int[] texture_formats
        {
            get
            {
                return new int[16]
                {
                    textureFormats0,
                    textureFormats1,
                    textureFormats2,
                    textureFormats3,
                    textureFormats4,
                    textureFormats5,
                    textureFormats6,
                    textureFormats7,
                    textureFormats8,
                    textureFormats9,
                    textureFormats10,
                    textureFormats11,
                    textureFormats12,
                    textureFormats13,
                    textureFormats14,
                    textureFormats15
                };
            }
        }
    }
}