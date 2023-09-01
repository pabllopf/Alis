// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiNavInput.cs
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

namespace Alis.App.Engine.UI
{
    /// <summary>
    ///     The im gui nav input enum
    /// </summary>
    public enum ImGuiNavInput
    {
        /// <summary>
        ///     The activate im gui nav input
        /// </summary>
        Activate = 0,

        /// <summary>
        ///     The cancel im gui nav input
        /// </summary>
        Cancel = 1,

        /// <summary>
        ///     The input im gui nav input
        /// </summary>
        Input = 2,

        /// <summary>
        ///     The menu im gui nav input
        /// </summary>
        Menu = 3,

        /// <summary>
        ///     The dpad left im gui nav input
        /// </summary>
        DpadLeft = 4,

        /// <summary>
        ///     The dpad right im gui nav input
        /// </summary>
        DpadRight = 5,

        /// <summary>
        ///     The dpad up im gui nav input
        /// </summary>
        DpadUp = 6,

        /// <summary>
        ///     The dpad down im gui nav input
        /// </summary>
        DpadDown = 7,

        /// <summary>
        ///     The stick left im gui nav input
        /// </summary>
        LStickLeft = 8,

        /// <summary>
        ///     The stick right im gui nav input
        /// </summary>
        LStickRight = 9,

        /// <summary>
        ///     The stick up im gui nav input
        /// </summary>
        LStickUp = 10,

        /// <summary>
        ///     The stick down im gui nav input
        /// </summary>
        LStickDown = 11,

        /// <summary>
        ///     The focus prev im gui nav input
        /// </summary>
        FocusPrev = 12,

        /// <summary>
        ///     The focus next im gui nav input
        /// </summary>
        FocusNext = 13,

        /// <summary>
        ///     The tweak slow im gui nav input
        /// </summary>
        TweakSlow = 14,

        /// <summary>
        ///     The tweak fast im gui nav input
        /// </summary>
        TweakFast = 15,

        /// <summary>
        ///     The count im gui nav input
        /// </summary>
        Count = 16
    }
}