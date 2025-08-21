// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Robustness.cs
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

namespace Alis.Extension.Graphic.Glfw.Enums
{
    /// <summary>
    ///     Describes the robustness strategy to be used by the context.
    /// </summary>
    public enum Robustness
    {
        /// <summary>
        ///     Disabled/no strategy (default)
        /// </summary>
        None = 0,

        /// <summary>
        ///     No notification.
        /// </summary>
        NoResetNotification = 0x00031001,

        /// <summary>
        ///     The context is lost on reset, use glGetGraphicsResetStatus for more information.
        /// </summary>
        LoseContextOnReset = 0x00031002
    }
}