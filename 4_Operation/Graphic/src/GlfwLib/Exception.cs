// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Exception.cs
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

using Alis.Core.Graphic.GlfwLib.Enums;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     Base exception class for GLFW related errors.
    /// </summary>
    public class Exception : System.Exception
    {
        

        /// <summary>
        ///     Generic error messages if only an error code is supplied as an argument to the constructor.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <returns>Error message.</returns>
        public static string GetErrorMessage(ErrorCode code)
        {
            switch (code)
            {
                case ErrorCode.NotInitialized: return "GLFW has not been initialized.";
                case ErrorCode.NoCurrentContext: return "No context is current for this thread.";
                case ErrorCode.InvalidEnum: return "One of the arguments to the function was an invalid enum value.";
                case ErrorCode.InvalidValue: return "One of the arguments to the function was an invalid value.";
                case ErrorCode.OutOfMemory: return "A memory allocation failed.";
                case ErrorCode.ApiUnavailable: return "GLFW could not find support for the requested API on the system.";
                case ErrorCode.VersionUnavailable: return "The requested OpenGL or OpenGL ES version is not available.";
                case ErrorCode.PlatformError: return "A platform-specific error occurred that does not match any of the more specific categories.";
                case ErrorCode.FormatUnavailable: return "The requested format is not supported or available.";
                case ErrorCode.NoWindowContext: return "The specified window does not have an OpenGL or OpenGL ES context.";
                default: return "Unknown error code.";
            }
        }

        

        

        /// <summary>
        ///     Initializes a new instance of the <see cref="Exception" /> class.
        /// </summary>
        /// <param name="error">The error code to create a generic message from.</param>
        public Exception(ErrorCode error) : base(GetErrorMessage(error))
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Exception" /> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public Exception(string message) : base(message)
        {
        }

        
    }
}