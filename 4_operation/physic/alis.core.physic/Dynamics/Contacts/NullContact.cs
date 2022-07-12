// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   NullContact.cs
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

using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The null contact class
    /// </summary>
    /// <seealso cref="Contact" />
    public class NullContact : Contact
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NullContact" /> class
        /// </summary>
        public NullContact()
        {
            CollideShapeFunction = Collide;
        }

        /// <summary>
        ///     Collides the manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="shape1">The shape</param>
        /// <param name="xf1">The xf</param>
        /// <param name="shape2">The shape</param>
        /// <param name="xf2">The xf</param>
        private static void Collide(ref Manifold manifold, Shape shape1, XForm xf1, Shape shape2, XForm xf2)
        {
        }
    }
}