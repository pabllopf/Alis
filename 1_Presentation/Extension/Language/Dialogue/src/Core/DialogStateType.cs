// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogStateType.cs
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

namespace Alis.Extension.Language.Dialogue.Core
{
    /// <summary>
    ///     Enumeration representing different dialog states
    /// </summary>
    public enum DialogStateType
    {
        /// <summary>
        ///     Idle state - dialog is not running
        /// </summary>
        Idle = 0,

        /// <summary>
        ///     Running state - dialog is currently active
        /// </summary>
        Running = 1,

        /// <summary>
        ///     Paused state - dialog is paused but not finished
        /// </summary>
        Paused = 2,

        /// <summary>
        ///     Completed state - dialog has finished
        /// </summary>
        Completed = 3
    }
}

