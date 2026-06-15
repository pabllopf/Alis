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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The position solver manifold class
    /// </summary>
    internal static class PositionSolverManifold
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
        public static void Initialize(ContactPositionConstraint pc, ref ControllerTransform xfA, ref ControllerTransform xfB, int index, out Vector2F normal, out Vector2F point, out float separation)
        {
            switch (pc.Type)
            {
                case ManifoldType.Circles:
                {
                    Vector2F pointA = ControllerTransform.Multiply(ref pc.LocalPoint, ref xfA);
                    Vector2F pointB = ControllerTransform.Multiply(pc.LocalPoints[0], ref xfB);
                    normal = pointB - pointA;

                    // Handle zero normalization
                    if (normal != Vector2F.Zero)
                    {
                        normal.Normalize();
                    }

                    point = 0.5f * (pointA + pointB);
                    separation = Vector2F.Dot(pointB - pointA, normal) - pc.RadiusA - pc.RadiusB;
                }
                    break;

                case ManifoldType.FaceA:
                {
                    Complex.Multiply(ref pc.LocalNormal, ref xfA.Rotation, out normal);
                    Vector2F planePoint = ControllerTransform.Multiply(ref pc.LocalPoint, ref xfA);

                    Vector2F clipPoint = ControllerTransform.Multiply(pc.LocalPoints[index], ref xfB);
                    separation = Vector2F.Dot(clipPoint - planePoint, normal) - pc.RadiusA - pc.RadiusB;
                    point = clipPoint;
                }
                    break;

                case ManifoldType.FaceB:
                {
                    Complex.Multiply(ref pc.LocalNormal, ref xfB.Rotation, out normal);
                    Vector2F planePoint = ControllerTransform.Multiply(ref pc.LocalPoint, ref xfB);

                    Vector2F clipPoint = ControllerTransform.Multiply(pc.LocalPoints[index], ref xfA);
                    separation = Vector2F.Dot(clipPoint - planePoint, normal) - pc.RadiusA - pc.RadiusB;
                    point = clipPoint;

                    // Ensure normal points from A to B
                    normal = -normal;
                }
                    break;
                default:
                    normal = Vector2F.Zero;
                    point = Vector2F.Zero;
                    separation = 0;
                    break;
            }
        }
    }
}