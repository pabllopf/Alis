// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   CircleContact.cs
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
using Alis.Core.Physics2D.Collision;
using Alis.Core.Physics2D.Collision.Shapes;
using Alis.Core.Physics2D.Common;
using Alis.Core.Physics2D.Dynamics.Fixtures;

namespace Alis.Core.Physics2D.Dynamics.Contacts
{
    /// <summary>
    /// The circle contact class
    /// </summary>
    /// <seealso cref="Contact"/>
    public class CircleContact : Contact
    {
        /// <summary>
        /// The circle
        /// </summary>
        private readonly CircleShape circleA;

        /// <summary>
        /// The circle
        /// </summary>
        private readonly CircleShape circleB;

        /// <summary>
        /// Initializes a new instance of the <see cref="CircleContact"/> class
        /// </summary>
        /// <param name="fA">The </param>
        /// <param name="indexA">The index</param>
        /// <param name="fB">The </param>
        /// <param name="indexB">The index</param>
        public CircleContact(Fixture fA, int indexA, Fixture fB, int indexB) : base(fA, indexA, fB, indexB)
        {
            circleB = (CircleShape) m_fixtureB.Shape;
            circleA = (CircleShape) m_fixtureA.Shape;
        }

        /// <summary>
        /// Evaluates the manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="xfA">The xf</param>
        /// <param name="xfB">The xf</param>
        internal override void Evaluate(out Manifold manifold, in Transform xfA, in Transform xfB)
        {
            manifold = new Manifold();
            //manifold.pointCount = 0;

            Vector2 pA = Math.Mul(xfA, circleA.m_p);
            Vector2 pB = Math.Mul(xfB, circleB.m_p);

            Vector2 d = pB - pA;
            float distSqr = Vector2.Dot(d, d);
            float rA = circleA.m_radius, rB = circleB.m_radius;
            float radius = rA + rB;
            if (distSqr > radius * radius)
            {
                return;
            }

            manifold.type = ManifoldType.Circles;
            manifold.localPoint = circleA.m_p;
            manifold.localNormal = Vector2.Zero;
            manifold.pointCount = 1;

            manifold.points[0] = new ManifoldPoint();
            manifold.points[0].localPoint = circleB.m_p;
            manifold.points[0].id.key = 0;
        }
    }
}