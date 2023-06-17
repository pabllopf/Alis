// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoMode.cs
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

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Base.Attributes;
using Alis.Core.Aspect.Base.Settings;

namespace Alis.Core.Graphic.SFML.Windows
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     VideoMode defines a video mode (width, height, bpp, frequency)
    ///     and provides static functions for getting modes supported
    ///     by the display device
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct VideoMode
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the video mode with its width and height
        /// </summary>
        /// <param name="width">Video mode width</param>
        /// <param name="height">Video mode height</param>
        ////////////////////////////////////////////////////////////
        public VideoMode(uint width, uint height) :
            this(width, height, 32)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the video mode with its width, height and depth
        /// </summary>
        /// <param name="width">Video mode width</param>
        /// <param name="height">Video mode height</param>
        /// <param name="bpp">Video mode depth (bits per pixel)</param>
        ////////////////////////////////////////////////////////////
        public VideoMode(uint width, uint height, uint bpp)
        {
            Width = width;
            Height = height;
            BitsPerPixel = bpp;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Tell whether or not the video mode is supported
        /// </summary>
        /// <returns>True if the video mode is valid, false otherwise</returns>
        ////////////////////////////////////////////////////////////
        public bool IsValid() => sfVideoMode_isValid(this);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the list of all the supported fullscreen video modes
        /// </summary>
        ////////////////////////////////////////////////////////////
        public static VideoMode[] FullscreenModes
        {
            get
            {
                uint count;
                VideoMode[] modesPtr = sfVideoMode_getFullscreenModes(out count);
                VideoMode[] modes = new VideoMode[count];
                for (uint i = 0; i < count; ++i)
                {
                    modes[i] = modesPtr[i];
                }

                return modes;
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the current desktop video mode
        /// </summary>
        ////////////////////////////////////////////////////////////
        public static VideoMode DesktopMode => sfVideoMode_getDesktopMode();

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => "[VideoMode]" +
                                             " Width(" + Width + ")" +
                                             " Height(" + Height + ")" +
                                             " BitsPerPixel(" + BitsPerPixel + ")";

        /// <summary>Video mode width, in pixels</summary>
        public readonly uint Width;

        /// <summary>Video mode height, in pixels</summary>
        public readonly uint Height;

        /// <summary>Video mode depth, in bits per pixel</summary>
        public readonly uint BitsPerPixel;

        /// <summary>
        ///     Sfs the video mode get desktop mode
        /// </summary>
        /// <returns>The video mode</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern VideoMode sfVideoMode_getDesktopMode();

        /// <summary>
        ///     Sfs the video mode get fullscreen modes using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        /// <returns>The video mode</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern VideoMode[] sfVideoMode_getFullscreenModes(out uint count);

        /// <summary>
        ///     Describes whether sf video mode is valid
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfVideoMode_isValid(VideoMode mode);
    }
}