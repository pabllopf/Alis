// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConnectionStatus.cs
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
    ///     Strongly-typed values indicating connection status of joysticks, monitors, etc.
    /// </summary>
    public enum ConnectionStatus
    {
        /// <summary>
        ///     Unknown connection status.
        /// </summary>
        Unknown = 0x00000000,

        /// <summary>
        ///     Device is currently connected and visible to GLFW.
        /// </summary>
        Connected = 0x00040001,

        /// <summary>
        ///     Device is disconnected and/or not visible to GLFW.
        /// </summary>
        Disconnected = 0x00040002
    }
}