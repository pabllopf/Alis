// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   VelocityConstraintPoint.cs
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

using System.Numerics;

namespace Alis.Core.Physics2D.Contacts
{
    /// <summary>
    ///     The velocity constraint point class
    /// </summary>
    internal class VelocityConstraintPoint
    {
        /// <summary>
        ///     The normal impulse
        /// </summary>
        internal float normalImpulse;

        /// <summary>
        ///     The normal mass
        /// </summary>
        internal float normalMass;

        /// <summary>
        ///     The
        /// </summary>
        internal Vector2 rA;

        /// <summary>
        ///     The
        /// </summary>
        internal Vector2 rB;

        /// <summary>
        ///     The tangent impulse
        /// </summary>
        internal float tangentImpulse;

        /// <summary>
        ///     The tangent mass
        /// </summary>
        internal float tangentMass;

        /// <summary>
        ///     The velocity bias
        /// </summary>
        internal float velocityBias;
    }
}