// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ManifoldPoint.cs
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

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Represents a single contact point within a contact manifold.
    /// </summary>
    /// <remarks>
    ///     <para>A manifold point stores the geometric and dynamic information about one contact
    ///     point between two colliding shapes. The contact manifold can contain multiple points
    ///     for complex collision geometries.</para>
    ///     <para>The <see cref="LocalPoint"/> interpretation depends on the manifold type:</para>
    ///     <list type="table">
    ///         <listheader>
    ///             <term>Manifold Type</term>
    ///             <term>LocalPoint Meaning</term>
    ///         </listheader>
    ///         <item>
    ///             <term><see cref="ManifoldType.Circles"/></term>
    ///             <description>Local center of circle B</description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="ManifoldType.FaceA"/></term>
    ///             <description>Local center of circle B or clip point of polygon B</description>
    ///         </item>
    ///         <item>
    ///             <term><see cref="ManifoldType.FaceB"/></term>
    ///             <description>Clip point of polygon A</description>
    ///         </item>
    ///     </list>
    ///     <para><strong>Important:</strong> Impulse values are used for internal caching and may not
    ///     provide reliable contact force estimates, particularly for high-velocity impacts.</para>
    ///     <para>This structure is persisted across simulation steps to maintain stable contact
    ///     behavior, so it remains lightweight.</para>
    /// </remarks>
    public struct ManifoldPoint
    {
        /// <summary>
        ///     Gets or sets the unique identifier for this contact point.
        /// </summary>
        /// <remarks>
        ///     This ID is used to correlate contact points across time steps, allowing the solver
        ///     to apply consistent impulses to the same geometric features between frames.
        /// </remarks>
        public ContactId Id;

        /// <summary>
        ///     Gets or sets the local position of this contact point on body B.
        /// </summary>
        /// <value>The contact point in body B's local coordinate space.</value>
        /// <remarks>
        ///     The exact interpretation of this point varies based on the manifold type
        ///     (circles vs. face A vs. face B). See class remarks for details.
        /// </remarks>
        public Vector2F LocalPoint;

        /// <summary>
        ///     Gets or sets the accumulated normal impulse at this contact point.
        /// </summary>
        /// <value>The impulse magnitude in the normal direction (separating impulse).</value>
        /// <remarks>
        ///     This value represents the cumulative impulse applied to resolve penetration
        ///     along the contact normal. Positive values indicate separation force.
        /// </remarks>
        public float NormalImpulse;

        /// <summary>
        ///     Gets or sets the accumulated tangent impulse at this contact point.
        /// </summary>
        /// <value>The impulse magnitude in the tangent direction (friction impulse).</value>
        /// <remarks>
        ///     This value represents the cumulative impulse applied along the contact tangent
        ///     to resolve friction. The sign indicates direction relative to the tangent vector.
        /// </remarks>
        public float TangentImpulse;
    }
}