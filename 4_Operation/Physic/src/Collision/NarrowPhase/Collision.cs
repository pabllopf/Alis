// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Collision.cs
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

using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Distance;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Config;

namespace Alis.Core.Physic.Collision.NarrowPhase
{
    /// <summary>Collision methods</summary>
    public static class Collision
    {
        /// <summary>Test overlap between the two shapes.</summary>
        /// <param name="shapeA">The first shape.</param>
        /// <param name="indexA">The index for the first shape.</param>
        /// <param name="shapeB">The second shape.</param>
        /// <param name="indexB">The index for the second shape.</param>
        /// <param name="xfA">The transform for the first shape.</param>
        /// <param name="xfB">The transform for the seconds shape.</param>
        [ExcludeFromCodeCoverage]
        public static bool TestOverlap(AShape shapeA, int indexA, AShape shapeB, int indexB, ref Transform xfA,
            ref Transform xfB)
        {
            DistanceInput input = new DistanceInput
            {
                ProxyA = new DistanceProxy(shapeA, indexA),
                ProxyB = new DistanceProxy(shapeB, indexB),
                TransformA = xfA,
                TransformB = xfB,
                UseRadii = true
            };
            
            DistanceGjk.ComputeDistance(ref input, out DistanceOutput output, out _);
            
            return output.Distance < 10.0f * Constant.Epsilon;
        }
        
        /// <summary>
        ///     Gets the point states using the specified state 1
        /// </summary>
        /// <param name="state1">The state</param>
        /// <param name="state2">The state</param>
        /// <param name="manifold1">The manifold</param>
        /// <param name="manifold2">The manifold</param>
        [ExcludeFromCodeCoverage]
        public static void GetPointStates(out PointState[] state1, out PointState[] state2,
            ref Manifold manifold1, ref Manifold manifold2)
        {
            state1 = new PointState[2];
            state2 = new PointState[2];
            
            for (int i = 0; i < Settings.ManifoldPoints; ++i)
            {
                state1[i] = PointState.Null;
                state2[i] = PointState.Null;
            }
            
            // Detect persists and removes.
            for (int i = 0; i < manifold1.PointCount; ++i)
            {
                ContactId id = manifold1.Points[i].Id;
                
                state1[i] = PointState.Remove;
                
                for (int j = 0; j < manifold2.PointCount; ++j)
                {
                    if (manifold2.Points[j].Id.Key == id.Key)
                    {
                        state1[i] = PointState.Persist;
                        break;
                    }
                }
            }
            
            // Detect persists and adds.
            for (int i = 0; i < manifold2.PointCount; ++i)
            {
                ContactId id = manifold2.Points[i].Id;
                
                state2[i] = PointState.Add;
                
                for (int j = 0; j < manifold1.PointCount; ++j)
                {
                    if (manifold1.Points[j].Id.Key == id.Key)
                    {
                        state2[i] = PointState.Persist;
                        break;
                    }
                }
            }
        }
        
        /// <summary>Clipping for contact manifolds.</summary>
        /// <param name="vOut">The v out.</param>
        /// <param name="vIn">The v in.</param>
        /// <param name="normal">The normal.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="vertexIndexA">The vertex index A.</param>
        /// <returns></returns>
        [ExcludeFromCodeCoverage]
        internal static int ClipSegmentToLine(out ClipVertex[] vOut, ref ClipVertex[] vIn,
            Vector2 normal, float offset, int vertexIndexA)
        {
            vOut = new ClipVertex[2];
            
            // Start with no output points
            int count = 0;
            
            // Calculate the distance of end points to the line
            float distance0 = Vector2.Dot(normal, vIn[0].V) - offset;
            float distance1 = Vector2.Dot(normal, vIn[1].V) - offset;
            
            // If the points are behind the plane
            if (distance0 <= 0.0f)
            {
                vOut[count++] = vIn[0];
            }
            
            if (distance1 <= 0.0f)
            {
                vOut[count++] = vIn[1];
            }
            
            // If the points are on different sides of the plane
            if (distance0 * distance1 < 0.0f)
            {
                // Find intersection point of edge and plane
                float interp = distance0 / (distance0 - distance1);
                
                ClipVertex cv = vOut[count];
                cv.V = vIn[0].V + interp * (vIn[1].V - vIn[0].V);
                
                // VertexA is hitting edgeB.
                cv.Id.ContactFeature.IndexA = (byte) vertexIndexA;
                cv.Id.ContactFeature.IndexB = vIn[0].Id.ContactFeature.IndexB;
                cv.Id.ContactFeature.TypeA = ContactFeatureType.Vertex;
                cv.Id.ContactFeature.TypeB = ContactFeatureType.Face;
                vOut[count] = cv;
                
                ++count;
            }
            
            return count;
        }
    }
}