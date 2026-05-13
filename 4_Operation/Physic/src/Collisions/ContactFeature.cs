// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactFeature.cs
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

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Represents the geometric features that intersect to form a contact point between two colliding shapes.
    ///     This struct must be 4 bytes or less to ensure efficient storage in contact manifolds.
    ///     Used to uniquely identify contact points for warm starting in iterative solvers.
    /// </summary>
    /// <remarks>
    ///     The features describe which edges, vertices, or faces of each shape are involved in the collision.
    ///     Index refers to the vertex/edge identifier, while Type indicates whether it's a vertex (0) or edge (1).
    /// </remarks>
    public struct ContactFeature
    {
        /// <summary>
        ///     Gets or sets the feature index (vertex/edge identifier) on ShapeA.
        /// </summary>
        /// <value>The zero-based index of the contacting feature on the first shape.</value>
        public byte IndexA;

        /// <summary>
        ///     Gets or sets the feature index (vertex/edge identifier) on ShapeB.
        /// </summary>
        /// <value>The zero-based index of the contacting feature on the second shape.</value>
        public byte IndexB;

        /// <summary>
        ///     Gets or sets the feature type on ShapeA (0 = vertex, 1 = edge).
        /// </summary>
        /// <value>The type of feature: 0 for vertex contact, 1 for edge contact.</value>
        public byte TypeA;

        /// <summary>
        ///     Gets or sets the feature type on ShapeB (0 = vertex, 1 = edge).
        /// </summary>
        /// <value>The type of feature: 0 for vertex contact, 1 for edge contact.</value>
        public byte TypeB;
    }
}