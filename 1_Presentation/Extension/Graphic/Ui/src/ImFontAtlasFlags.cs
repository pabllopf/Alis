// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlasFlags.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im font atlas flags enum
    /// </summary>
    [Flags]
    public enum ImFontAtlasFlags
    {
        /// <summary>
        ///     The none im font atlas flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The no power of two height im font atlas flags
        /// </summary>
        NoPowerOfTwoHeight = 1,

        /// <summary>
        ///     The no mouse cursors im font atlas flags
        /// </summary>
        NoMouseCursors = 2,

        /// <summary>
        ///     The no baked lines im font atlas flags
        /// </summary>
        NoBakedLines = 4
    }
}