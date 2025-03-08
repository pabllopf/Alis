// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CursorMode.cs
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

namespace Alis.Core.Graphic.GlfwLib.Enums
{
    /// <summary>
    ///     Indicates the behavior of the mouse cursor.
    /// </summary>
    public enum CursorMode
    {
        /// <summary>
        ///     The cursor is visible and behaves normally.
        /// </summary>
        Normal = 0x00034001,

        /// <summary>
        ///     The cursor is invisible when it is over the client area of the window but does not restrict the cursor from
        ///     leaving.
        /// </summary>
        Hidden = 0x00034002,

        /// <summary>
        ///     Hides and grabs the cursor, providing virtual and unlimited cursor movement. This is useful for implementing for
        ///     example 3D camera controls.
        /// </summary>
        Disabled = 0x00034003
    }
}