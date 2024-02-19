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
using Alis.Core.Physic.Shared.Optimization;

namespace Alis.Core.Physic.Collision.NarrowPhase
{
    /// <summary>
    ///     A manifold for two touching convex Shapes.
    ///     Supports multiple types of contact:
    ///     - Clip point versus plane with radius
    ///     - Point versus point with radius (circles)
    ///     The local point usage depends on the manifold type:
    ///     - ShapeType.Circles: the local center of circleA
    ///     - SeparationFunction.FaceA: the center of faceA
    ///     - SeparationFunction.FaceB: the center of faceB
    ///     Similarly the local normal usage:
    ///     - ShapeType.Circles: not used
    ///     - SeparationFunction.FaceA: the normal on polygonA
    ///     - SeparationFunction.FaceB: the normal on polygonB
    ///     We store contacts in this way so that position correction can
    ///     account for movement, which is critical for continuous physics.
    ///     All contact scenarios must be expressed in one of these types.
    ///     This structure is stored across time steps, so we keep it small.
    /// </summary>
    public struct Manifold
    {
        /// <summary>Not use for Type.SeparationFunction.Points</summary>
        public Vector2 LocalNormal { get; set; }

        /// <summary>Usage depends on manifold type</summary>
        public Vector2 LocalPoint { get; set; }

        /// <summary>The number of manifold points</summary>
        public int PointCount { get; set; }

        /// <summary>The points of contact</summary>
        public FixedArray2<ManifoldPoint> Points;

        /// <summary>
        ///     The type
        /// </summary>
        public ManifoldType Type { get; set; }
    }
}