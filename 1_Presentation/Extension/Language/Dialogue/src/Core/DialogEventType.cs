// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogEventType.cs
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
    ///     Enumeration representing different dialog event types
    /// </summary>
    public enum DialogEventType
    {
        /// <summary>
        ///     Event fired when dialog starts
        /// </summary>
        OnDialogStart = 0,

        /// <summary>
        ///     Event fired when dialog ends
        /// </summary>
        OnDialogEnd = 1,

        /// <summary>
        ///     Event fired when an option is selected
        /// </summary>
        OnOptionSelected = 2,

        /// <summary>
        ///     Event fired when an option is validated
        /// </summary>
        OnOptionValidated = 3,

        /// <summary>
        ///     Event fired when dialog state changes
        /// </summary>
        OnStateChanged = 4
    }
}

