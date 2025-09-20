// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ErrorCode.cs
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

namespace Alis.Extension.Graphic.Glfw.Enums
{
    /// <summary>
    ///     Strongly-typed error codes for error handling.
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        ///     An unknown or undefined error.
        /// </summary>
         Unknown = 0x00000000,

        /// <summary>
        ///     No error has occurred.
        /// </summary>
        None = 0x00000000,

        /// <summary>
        ///     This occurs if a GLFW function was called that must not be called unless the library is initialized.
        /// </summary>
        NotInitialized = 0x00010001,

        /// <summary>
        ///     This occurs if a GLFW function was called that needs and operates on the current OpenGL or OpenGL ES context but no
        ///     context is current on the calling thread.
        /// </summary>
        NoCurrentContext = 0x00010002,

        /// <summary>
        ///     One of the arguments to the function was an invalid enum value.
        /// </summary>
        InvalidEnum = 0x00010003,

        /// <summary>
        ///     One of the arguments to the function was an invalid value, for example requesting a non-existent OpenGL or OpenGL
        ///     ES version like 2.7.
        /// </summary>
        InvalidValue = 0x00010004,

        /// <summary>
        ///     A memory allocation failed.
        /// </summary>
        OutOfMemory = 0x00010005,

        /// <summary>
        ///     GLFW could not find support for the requested API on the system.
        /// </summary>
        ApiUnavailable = 0x00010006,

        /// <summary>
        ///     The requested OpenGL or OpenGL ES version (including any requested context or framebuffer hints) is not available
        ///     on this machine.
        /// </summary>
        VersionUnavailable = 0x00010007,

        /// <summary>
        ///     A platform-specific error occurred that does not match any of the more specific categories.
        /// </summary>
        PlatformError = 0x00010008,

        /// <summary>
        ///     If emitted during window creation, the requested pixel format is not supported, else if emitted when querying the
        ///     clipboard, the contents of the clipboard could not be converted to the requested format.
        /// </summary>
        FormatUnavailable = 0x00010009,

        /// <summary>
        ///     A window that does not have an OpenGL or OpenGL ES context was passed to a function that requires it to have one.
        /// </summary>
        NoWindowContext = 0x0001000A
    }
}