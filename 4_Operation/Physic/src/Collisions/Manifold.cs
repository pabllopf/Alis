// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Manifold.cs
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

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Represents a contact manifold between two touching convex shapes.
    /// </summary>
    /// <remarks>
    ///     Box2D supports multiple types of contact:
    ///     <list type="bullet">
    ///         <item>Clip point versus plane with radius</item>
    ///         <item>Point versus point with radius (circles)</item>
    ///     </list>
    ///     The local point usage depends on the manifold type:
    ///     <list type="table">
    ///         <listheader>
    ///             <term>ManifoldType</term>
    ///             <description>LocalPoint usage</description>
    ///         </listheader>
    ///         <item>
    ///             <term>Circles</term>
    ///             <description>The local center of circleA</description>
    ///         </item>
    ///         <item>
    ///             <term>FaceA</term>
    ///             <description>The center of faceA</description>
    ///         </item>
    ///         <item>
    ///             <term>FaceB</term>
    ///             <description>The center of faceB</description>
    ///         </item>
    ///     </list>
    ///     Similarly the local normal usage:
    ///     <list type="table">
    ///         <listheader>
    ///             <term>ManifoldType</term>
    ///             <description>LocalNormal usage</description>
    ///         </listheader>
    ///         <item>
    ///             <term>Circles</term>
    ///             <description>Not used</description>
    ///         </item>
    ///         <item>
    ///             <term>FaceA</term>
    ///             <description>The normal on polygonA</description>
    ///         </item>
    ///         <item>
    ///             <term>FaceB</term>
    ///             <description>The normal on polygonB</description>
    ///         </item>
    ///     </list>
    ///     We store contacts in this way so that position correction can account for movement,
    ///     which is critical for continuous physics. All contact scenarios must be expressed in
    ///     one of these types. This structure is stored across time steps, so we keep it small.
    /// </remarks>
    public struct Manifold
    {
        /// <summary>
        ///     Gets or sets the local normal vector in shape A's local space.
        /// </summary>
        /// <value>The collision normal expressed relative to shape A's coordinate frame. Not used for point-type manifolds.</value>
        public Vector2F LocalNormal;

        /// <summary>
        ///     Gets or sets the local contact point in the respective shape's local space.
        /// </summary>
        /// <value>The position of the contact point in local coordinates. Usage varies by manifold type.</value>
        public Vector2F LocalPoint;

        /// <summary>
        ///     Gets or sets the number of valid contact points in this manifold.
        /// </summary>
        /// <value>The count of contact points, between 0 and 2.</value>
        public int PointCount;

        /// <summary>
        ///     Gets or sets the array of contact points.
        /// </summary>
        /// <value>A fixed-size array containing up to two <see cref="ManifoldPoint"/> entries.</value>
        public FixedArray2<ManifoldPoint> Points;

        /// <summary>
        ///     Gets or sets the type of manifold.
        /// </summary>
        /// <value>The <see cref="ManifoldType"/> indicating whether this is a point or face contact.</value>
        public ManifoldType Type;
    }
}