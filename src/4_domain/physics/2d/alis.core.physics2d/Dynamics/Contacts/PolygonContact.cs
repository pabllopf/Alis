// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PolygonContact.cs
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

using Alis.Core.Physics2D.Colliders;
using Alis.Core.Physics2D.Fixtures;
using Alis.Core.Physics2D.Shapes;

namespace Alis.Core.Physics2D.Contacts
{
    /// <summary>
    ///     The polygon contact class
    /// </summary>
    /// <seealso cref="Contact" />
    public class PolygonContact : Contact
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonContact" /> class
        /// </summary>
        /// <param name="fA">The </param>
        /// <param name="indexA">The index</param>
        /// <param name="fB">The </param>
        /// <param name="indexB">The index</param>
        public PolygonContact(Fixture fA, int indexA, Fixture fB, int indexB) : base(fA, indexA, fB, indexB)
        {
        }

        /// <summary>
        ///     The polygon and polygon collider
        /// </summary>
        private static readonly Collider<PolygonShape, PolygonShape> collider = new PolygonAndPolygonCollider();

        /// <summary>
        ///     Evaluates the manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="xfA">The xf</param>
        /// <param name="xfB">The xf</param>
        internal override void Evaluate(out Manifold manifold, in Transform xfA, in Transform xfB)
        {
            collider.Collide(out manifold, (PolygonShape) m_fixtureA.Shape, in xfA, (PolygonShape) m_fixtureB.Shape,
                in xfB);
        }
    }
}