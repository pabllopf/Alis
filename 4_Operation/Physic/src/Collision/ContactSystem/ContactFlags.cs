// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactFlags.cs
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

namespace Alis.Core.Physic.Collision.ContactSystem
{
    /// <summary>
    ///     The contact flags enum
    /// </summary>
    [Flags]
    internal enum ContactFlags : byte
    {
        /// <summary>
        ///     The unknown contact flags
        /// </summary>
        None = 0,

        /// <summary>Used when crawling contact graph when forming islands.</summary>
        IslandFlag = 1,

        /// <summary>Set when the shapes are touching.</summary>
        TouchingFlag = 2,

        /// <summary>This contact can be disabled (by user)</summary>
        EnabledFlag = 4,

        /// <summary>This contact needs filtering because a fixture filter was changed.</summary>
        FilterFlag = 8,

        /// <summary>This bullet contact had a TOI event</summary>
        BulletHitFlag = 16,

        /// <summary>This contact has a valid TOI in m_toi</summary>
        ToiFlag = 32
    }
}