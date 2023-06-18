// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiMouseSource.cs
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

namespace Alis.Core.Graphic.ImGui.Enums
{
    /// <summary>
    ///     The im gui mouse source enum
    /// </summary>
    public enum ImGuiMouseSource
    {
        /// <summary>
        ///     The mouse im gui mouse source
        /// </summary>
        Mouse = 0,

        /// <summary>
        ///     The touch screen im gui mouse source
        /// </summary>
        TouchScreen = 1,

        /// <summary>
        ///     The pen im gui mouse source
        /// </summary>
        Pen = 2,

        /// <summary>
        ///     The count im gui mouse source
        /// </summary>
        Count = 3
    }
}