// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ChainAndPolygonContact.cs
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
    ///     The chain and polygon contact class
    /// </summary>
    /// <seealso cref="Contact" />
    internal class ChainAndPolygonContact : Contact
    {
        /// <summary>
        ///     The edge
        /// </summary>
        private readonly EdgeShape edge;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChainAndPolygonContact" /> class
        /// </summary>
        /// <param name="fA">The </param>
        /// <param name="indexA">The index</param>
        /// <param name="fB">The </param>
        /// <param name="indexB">The index</param>
        public ChainAndPolygonContact(Fixture fA, int indexA, Fixture fB, int indexB) : base(fA, indexA, fB, indexB)
        {
            ChainShape chain = (ChainShape) FixtureA.Shape;
            chain.GetChildEdge(out edge, indexA);
        }

        /// <summary>
        ///     The edge and polygon collider
        /// </summary>
        private static readonly Collider<EdgeShape, PolygonShape> collider = new EdgeAndPolygonCollider();

        /// <summary>
        ///     Evaluates the manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="xfA">The xf</param>
        /// <param name="xfB">The xf</param>
        internal override void Evaluate(out Manifold manifold, in Transform xfA, in Transform xfB)
        {
            collider.Collide(out manifold, edge, xfA, (PolygonShape) FixtureB.Shape, xfB);
        }
    }
}