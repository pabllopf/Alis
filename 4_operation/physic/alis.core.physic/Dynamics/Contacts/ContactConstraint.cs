// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ContactConstraint.cs
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

using Alis.Aspect.Math;
using Alis.Core.Physic.Collision;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The contact constraint class
    /// </summary>
    public class ContactConstraint
    {
        /// <summary>
        ///     The max manifold points
        /// </summary>
        public readonly ContactConstraintPoint[] Points = new ContactConstraintPoint[Settings.MaxManifoldPoints];

        /// <summary>
        ///     The body
        /// </summary>
        public Body BodyA;

        /// <summary>
        ///     The body
        /// </summary>
        public Body BodyB;

        /// <summary>
        ///     The friction
        /// </summary>
        public float Friction;

        /// <summary>
        ///     The
        /// </summary>
        public Matrix2X2 K;

        /// <summary>
        ///     The local plane normal
        /// </summary>
        public Vector2 LocalPlaneNormal;

        /// <summary>
        ///     The local point
        /// </summary>
        public Vector2 LocalPoint;

        /// <summary>
        ///     The manifold
        /// </summary>
        public Manifold Manifold;

        /// <summary>
        ///     The normal
        /// </summary>
        public Vector2 Normal;

        /// <summary>
        ///     The normal mass
        /// </summary>
        public Matrix2X2 NormalMass;

        /// <summary>
        ///     The point count
        /// </summary>
        public int PointCount;

        /// <summary>
        ///     The radius
        /// </summary>
        public float Radius;

        /// <summary>
        ///     The restitution
        /// </summary>
        public float Restitution;

        /// <summary>
        ///     The type
        /// </summary>
        public ManifoldType Type;

        //public ContactConstraint()
        //{
        //	for (int i = 0; i < Settings.MaxManifoldPoints; i++)
        //		Points[i] = new ContactConstraintPoint();
        //}
    }
}