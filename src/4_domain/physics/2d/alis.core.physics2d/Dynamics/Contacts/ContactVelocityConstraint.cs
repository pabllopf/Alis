// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ContactVelocityConstraint.cs
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
    ///     The contact velocity constraint class
    /// </summary>
    public class ContactVelocityConstraint
    {
        /// <summary>
        ///     The contact index
        /// </summary>
        internal int contactIndex;

        /// <summary>
        ///     The friction
        /// </summary>
        internal float friction;

        /// <summary>
        ///     The index
        /// </summary>
        internal int indexA;

        /// <summary>
        ///     The index
        /// </summary>
        internal int indexB;

        /// <summary>
        ///     The inv ia
        /// </summary>
        internal float invIA;

        /// <summary>
        ///     The inv ib
        /// </summary>
        internal float invIB;

        /// <summary>
        ///     The inv mass
        /// </summary>
        internal float invMassA;

        /// <summary>
        ///     The inv mass
        /// </summary>
        internal float invMassB;

        /// <summary>
        ///     The
        /// </summary>
        internal Matrix3x2 K;

        /// <summary>
        ///     The normal
        /// </summary>
        internal Vector2 normal;

        /// <summary>
        ///     The normal mass
        /// </summary>
        internal Matrix3x2 normalMass;

        /// <summary>
        ///     The point count
        /// </summary>
        internal int pointCount;

        /// <summary>
        ///     The max manifold points
        /// </summary>
        internal VelocityConstraintPoint[] points = new VelocityConstraintPoint[Settings.MaxManifoldPoints];

        /// <summary>
        ///     The restitution
        /// </summary>
        internal float restitution;

        /// <summary>
        ///     The tangent speed
        /// </summary>
        internal float tangentSpeed;
    }
}