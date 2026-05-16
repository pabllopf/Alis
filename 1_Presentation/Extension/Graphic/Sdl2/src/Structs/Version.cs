// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Version.cs
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

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     Represents an SDL version structure with major, minor, and patch components.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct Version
    {
        /// <summary>
        ///     The major version number.
        /// </summary>
        [FieldOffset(0)] public byte major;


        /// <summary>
        ///     The minor version number.
        /// </summary>
        [FieldOffset(1)] public byte minor;


        /// <summary>
        ///     The patch version number.
        /// </summary>
        [FieldOffset(2)] public byte patch;


        /// <summary>
        ///     Initializes a new instance of the <see cref="Version" /> struct with the specified version components.
        /// </summary>
        /// <param name="sdlTtfMajorVersion">The major version number.</param>
        /// <param name="sdlTtfMinorVersion">The minor version number.</param>
        /// <param name="sdlTtfPatchLevel">The patch level (revision) number.</param>
        public Version(int sdlTtfMajorVersion, int sdlTtfMinorVersion, int sdlTtfPatchLevel)
        {
            major = (byte) sdlTtfMajorVersion;
            minor = (byte) sdlTtfMinorVersion;
            patch = (byte) sdlTtfPatchLevel;
        }
    }
}