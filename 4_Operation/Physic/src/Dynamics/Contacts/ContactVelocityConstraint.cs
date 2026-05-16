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
        ///     The constraint points for each manifold point.
        /// </summary>
        public readonly VelocityConstraintPoint[] Points = new VelocityConstraintPoint[SettingEnv.MaxManifoldPoints];

        /// <summary>
        ///     Index of the contact in the global contact array.
        /// </summary>
        public int ContactIndex;

        /// <summary>
        ///     The combined friction coefficient for this contact constraint.
        /// </summary>
        public float Friction;

        /// <summary>
        ///     The index of the first body in the solver arrays.
        /// </summary>
        public int IndexA;

        /// <summary>
        ///     The index of the second body in the solver arrays.
        /// </summary>
        public int IndexB;

        /// <summary>
        ///     The inverse inertia of body A and body B.
        /// </summary>
        public float InvIa, InvIb;

        /// <summary>
        ///     The inverse mass of body A and body B.
        /// </summary>
        public float InvMassA, InvMassB;

        /// <summary>
        ///     The effective mass matrix for the contact constraint.
        /// </summary>
        public Mat22 K;

        /// <summary>
        ///     The contact normal in world coordinates.
        /// </summary>
        public Vector2F Normal;

        /// <summary>
        ///     The inverse of the effective mass matrix.
        /// </summary>
        public Mat22 NormalMass;

        /// <summary>
        ///     The number of constraint points.
        /// </summary>
        public int PointCount;

        /// <summary>
        ///     The combined restitution coefficient for this contact constraint.
        /// </summary>
        public float Restitution;

        /// <summary>
        ///     The desired tangent speed for conveyor belt behavior.
        /// </summary>
        public float TangentSpeed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactVelocityConstraint" /> class
        /// </summary>
        public ContactVelocityConstraint()
        {
            for (int i = 0; i < SettingEnv.MaxManifoldPoints; i++)
            {
                Points[i] = new VelocityConstraintPoint();
            }
        }
    }
}