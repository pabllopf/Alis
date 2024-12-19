// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactVelocityConstraint.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The contact velocity constraint class
    /// </summary>
    public sealed class ContactVelocityConstraint
    {
        /// <summary>
        ///     The contact index
        /// </summary>
        public int contactIndex;

        /// <summary>
        ///     The friction
        /// </summary>
        public float friction;

        /// <summary>
        ///     The index
        /// </summary>
        public int indexA;

        /// <summary>
        ///     The index
        /// </summary>
        public int indexB;

        /// <summary>
        ///     The inv ib
        /// </summary>
        public float invIA, invIB;

        /// <summary>
        ///     The inv mass
        /// </summary>
        public float invMassA, invMassB;

        /// <summary>
        ///     The
        /// </summary>
        public Mat22 K;

        /// <summary>
        ///     The normal
        /// </summary>
        public Vector2F normal;

        /// <summary>
        ///     The normal mass
        /// </summary>
        public Mat22 normalMass;

        /// <summary>
        ///     The point count
        /// </summary>
        public int pointCount;

        /// <summary>
        ///     The max manifold points
        /// </summary>
        public VelocityConstraintPoint[] points = new VelocityConstraintPoint[SettingEnv.MaxManifoldPoints];

        /// <summary>
        ///     The restitution
        /// </summary>
        public float restitution;

        /// <summary>
        ///     The tangent speed
        /// </summary>
        public float tangentSpeed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactVelocityConstraint" /> class
        /// </summary>
        public ContactVelocityConstraint()
        {
            for (int i = 0; i < SettingEnv.MaxManifoldPoints; i++)
            {
                points[i] = new VelocityConstraintPoint();
            }
        }
    }
}