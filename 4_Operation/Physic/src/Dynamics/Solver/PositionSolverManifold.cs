// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PositionSolverManifold.cs
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

using System.Diagnostics;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.NarrowPhase;

namespace Alis.Core.Physic.Dynamics.Solver
{
    /// <summary>
    ///     The position solver manifold class
    /// </summary>
    public static class PositionSolverManifold
    {
        /// <summary>
        ///     Initializes the pc
        /// </summary>
        /// <param name="pc">The pc</param>
        /// <param name="xfA">The xf</param>
        /// <param name="xfB">The xf</param>
        /// <param name="index">The index</param>
        /// <param name="normal">The normal</param>
        /// <param name="point">The point</param>
        /// <param name="separation">The separation</param>
        public static void Initialize(ContactPositionConstraint pc, ref Transform xfA, ref Transform xfB, int index,
            out Vector2 normal, out Vector2 point, out float separation)
        {
            Debug.Assert(pc.PointCount > 0);

            switch (pc.Type)
            {
                case ManifoldType.Circles:
                {
                    Vector2 pointA = MathUtils.Mul(ref xfA, pc.LocalPoint);
                    Vector2 pointB = MathUtils.Mul(ref xfB, pc.LocalPoints[0]);
                    normal = pointB - pointA;

                    //Velcro: Fix to handle zero normalization
                    if (normal != Vector2.Zero)
                    {
                        normal = Vector2.Normalize(normal);
                    }

                    point = 0.5f * (pointA + pointB);
                    separation = Vector2.Dot(pointB - pointA, normal) - pc.RadiusA - pc.RadiusB;
                }
                    break;

                case ManifoldType.FaceA:
                {
                    normal = MathUtils.Mul(xfA.Rotation, pc.LocalNormal);
                    Vector2 planePoint = MathUtils.Mul(ref xfA, pc.LocalPoint);

                    Vector2 clipPoint = MathUtils.Mul(ref xfB, pc.LocalPoints[index]);
                    separation = Vector2.Dot(clipPoint - planePoint, normal) - pc.RadiusA - pc.RadiusB;
                    point = clipPoint;
                }
                    break;

                case ManifoldType.FaceB:
                {
                    normal = MathUtils.Mul(xfB.Rotation, pc.LocalNormal);
                    Vector2 planePoint = MathUtils.Mul(ref xfB, pc.LocalPoint);

                    Vector2 clipPoint = MathUtils.Mul(ref xfA, pc.LocalPoints[index]);
                    separation = Vector2.Dot(clipPoint - planePoint, normal) - pc.RadiusA - pc.RadiusB;
                    point = clipPoint;

                    // Ensure normal points from A to B
                    normal = -normal;
                }
                    break;
                default:
                    normal = Vector2.Zero;
                    point = Vector2.Zero;
                    separation = 0;
                    break;
            }
        }
    }
}