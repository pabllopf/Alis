// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolyAndEdgeContact.cs
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

using Alis.Aspect.Logging;
using Alis.Aspect.Math;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shape;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The poly and edge contact class
    /// </summary>
    /// <seealso cref="Contact" />
    public class PolyAndEdgeContact : Contact
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PolyAndEdgeContact" /> class
        /// </summary>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="fixtureB">The fixture</param>
        public PolyAndEdgeContact(Fixture fixtureA, Fixture fixtureB)
            : base(fixtureA, fixtureB)
        {
            Box2DxDebug.Assert(fixtureA.ShapeType == ShapeType.PolygonShape);
            Box2DxDebug.Assert(fixtureB.ShapeType == ShapeType.EdgeShape);
            CollideShapeFunction = CollidePolyAndEdgeContact;
        }

        /// <summary>
        ///     Collides the poly and edge contact using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="shape1">The shape</param>
        /// <param name="xf1">The xf</param>
        /// <param name="shape2">The shape</param>
        /// <param name="xf2">The xf</param>
        private static void CollidePolyAndEdgeContact(ref Manifold manifold, IShape shape1, XForm xf1, IShape shape2,
            XForm xf2)
        {
            Collision.CollidePolyAndEdge(ref manifold, (PolygonShape) shape1, xf1, (EdgeShape) shape2, xf2);
        }

        /// <summary>
        ///     Creates the fixture a
        /// </summary>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="fixtureB">The fixture</param>
        /// <returns>The contact</returns>
        public new static Contact Create(Fixture fixtureA, Fixture fixtureB) => new PolyAndEdgeContact(fixtureA, fixtureB);

        /// <summary>
        ///     Destroys the contact
        /// </summary>
        /// <param name="contact">The contact</param>
        public new static void Destroy(ref Contact contact)
        {
            contact = null;
        }
    }
}