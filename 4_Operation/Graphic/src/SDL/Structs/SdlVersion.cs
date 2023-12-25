// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SdlVersion.cs
// 
//  Author: Pablo Perdomo Falcón
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

namespace Alis.Core.Graphic.SDL.Structs
{
    /// <summary>
    ///     The sdl version
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlVersion
    {
        /// <summary>
        ///     The major
        /// </summary>
        public byte major;

        /// <summary>
        ///     The minor
        /// </summary>
        public byte minor;

        /// <summary>
        ///     The patch
        /// </summary>
        public byte patch;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SdlVersion" /> class
        /// </summary>
        /// <param name="sdlTtfMajorVersion">The sdl ttf major version</param>
        /// <param name="sdlTtfMinorVersion">The sdl ttf minor version</param>
        /// <param name="sdlTtfPatchLevel">The sdl ttf patch level</param>
        public SdlVersion(int sdlTtfMajorVersion, int sdlTtfMinorVersion, int sdlTtfPatchLevel)
        {
            major = (byte) sdlTtfMajorVersion;
            minor = (byte) sdlTtfMinorVersion;
            patch = (byte) sdlTtfPatchLevel;
        }
    }
}