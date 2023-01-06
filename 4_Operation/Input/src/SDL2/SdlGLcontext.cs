// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl.SdlGLcontext.cs
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

namespace Alis.Core.Input.SDL2
{
    /// <summary>
        ///     The sdl glcontext enum
        /// </summary>
        [Flags]
        public enum SdlGLcontext
        {
            /// <summary>
            ///     The sdl gl context debug flag sdl glcontext
            /// </summary>
            SdlGlContextDebugFlag = 0x0001,

            /// <summary>
            ///     The sdl gl context forward compatible flag sdl glcontext
            /// </summary>
            SdlGlContextForwardCompatibleFlag = 0x0002,

            /// <summary>
            ///     The sdl gl context robust access flag sdl glcontext
            /// </summary>
            SdlGlContextRobustAccessFlag = 0x0004,

            /// <summary>
            ///     The sdl gl context reset isolation flag sdl glcontext
            /// </summary>
            SdlGlContextResetIsolationFlag = 0x0008
        }
    
}