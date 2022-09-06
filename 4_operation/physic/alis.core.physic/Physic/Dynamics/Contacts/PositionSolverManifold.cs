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

using Alis.Aspect.Logging;
using Alis.Aspect.Math;
using Alis.Core.Physic.Collisions;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The position solver manifold class
    /// </summary>
    internal class PositionSolverManifold
    {
        /// <summary>
        ///     The max manifold points
        /// </summary>
        internal readonly Vector2[] Points = new Vector2[Settings.MaxManifoldPoints];

        /// <summary>
        ///     The max manifold points
        /// </summary>
        internal readonly float[] Separations = new float[Settings.MaxManifoldPoints];

        /// <summary>
        ///     The normal
        /// </summary>
        internal Vector2 Normal;

        /// <summary>
        ///     Initializes the cc
        /// </summary>
        /// <param name="cc">The cc</param>
        internal void Initialize(ContactConstraint cc)
        {
            Box2DxDebug.Assert(cc.PointCount > 0);

            switch (cc.Type)
            {
                case ManifoldType.Circles:
                {
                    Vector2 pointA = cc.BodyA.GetWorldPoint(cc.LocalPoint);
                    Vector2 pointB = cc.BodyB.GetWorldPoint(cc.Points[0].LocalPoint);
                    if (Vector2.DistanceSquared(pointA, pointB) > Settings.FltEpsilonSquared)
                    {
                        Normal = pointB - pointA;
                        Normal.Normalize();
                    }
                    else
                    {
                        Normal.Set(1.0f, 0.0f);
                    }

                    Points[0] = 0.5f * (pointA + pointB);
                    Separations[0] = Vector2.Dot(pointB - pointA, Normal) - cc.Radius;
                }
                    break;

                case ManifoldType.FaceA:
                {
                    Normal = cc.BodyA.GetWorldVector(cc.LocalPlaneNormal);
                    Vector2 planePoint = cc.BodyA.GetWorldPoint(cc.LocalPoint);

                    for (int i = 0; i < cc.PointCount; ++i)
                    {
                        Vector2 clipPoint = cc.BodyB.GetWorldPoint(cc.Points[i].LocalPoint);
                        Separations[i] = Vector2.Dot(clipPoint - planePoint, Normal) - cc.Radius;
                        Points[i] = clipPoint;
                    }
                }
                    break;

                case ManifoldType.FaceB:
                {
                    Normal = cc.BodyB.GetWorldVector(cc.LocalPlaneNormal);
                    Vector2 planePoint = cc.BodyB.GetWorldPoint(cc.LocalPoint);

                    for (int i = 0; i < cc.PointCount; ++i)
                    {
                        Vector2 clipPoint = cc.BodyA.GetWorldPoint(cc.Points[i].LocalPoint);
                        Separations[i] = Vector2.Dot(clipPoint - planePoint, Normal) - cc.Radius;
                        Points[i] = clipPoint;
                    }

                    // Ensure normal points from A to B
                    Normal = -Normal;
                }
                    break;
            }
        }
    }
}