// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ContactSolverDef.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Physics2D.World;

namespace Alis.Core.Physics2D.Contacts
{
    /// <summary>
    ///     The contact solver def
    /// </summary>
    internal struct ContactSolverDef
    {
        /// <summary>
        ///     The step
        /// </summary>
        internal TimeStep step;

        /// <summary>
        ///     The contacts
        /// </summary>
        internal Contact[] contacts;

        /// <summary>
        ///     The count
        /// </summary>
        internal int count;

        /// <summary>
        ///     The positions
        /// </summary>
        internal Position[] positions;

        /// <summary>
        ///     The velocities
        /// </summary>
        internal Velocity[] velocities;
    }
}