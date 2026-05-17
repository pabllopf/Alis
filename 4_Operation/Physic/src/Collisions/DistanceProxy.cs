// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceProxy.cs
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
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     A distance proxy that wraps any shape for use by the GJK distance algorithm.
    /// </summary>
    /// <remarks>
    ///     This struct provides a uniform interface for accessing shape vertices and radius
    ///     regardless of the underlying shape type (circle, polygon, chain, or edge).
    ///     It is used by the GJK algorithm to perform support queries and distance computations.
    /// </remarks>
    public struct DistanceProxy
    {
        /// <summary>
        ///     Gets the radius of the encapsulated shape.
        /// </summary>
        /// <value>
        ///     A <see cref="float"/> representing the shape's radius for padding in distance calculations.
        /// </value>
        internal readonly float Radius;

        /// <summary>
        ///     Gets the vertices of the encapsulated shape.
        /// </summary>
        /// <value>
        ///     A <see cref="Vertices"/> collection containing the shape's corner points.
        /// </value>
        internal readonly Vertices Vertices;

        // GJK using Voronoi regions (Christer Ericson) and Barycentric coordinates.

        /// <summary>
        ///     Initialize the proxy using the given shape. The shape
        ///     must remain in scope while the proxy is in use.
        /// </summary>
        /// <param name="shape">The shape to wrap as a distance proxy.</param>
        /// <param name="index">The vertex index for chain shapes (ignored for other shape types).</param>
        /// <remarks>
        ///     For circle shapes, the proxy contains a single vertex at the circle's center.
        ///     For polygon shapes, all vertices are copied into the proxy.
        ///     For chain shapes, only two adjacent vertices around the given index are used.
        ///     For edge shapes, both edge endpoints are used.
        /// </remarks>
        public DistanceProxy(Shape shape, int index)
        {
            Vertices = new Vertices();

            switch (shape.ShapeType)
            {
                case ShapeType.Circle:
                {
                    CircleShape circle = (CircleShape) shape;
                    if (Vertices.Count > 0)
                    {
                        Vertices.Clear();
                    }

                    Vertices.Add(circle.Position);
                    Radius = circle.GetRadius;
                }
                    break;

                case ShapeType.Polygon:
                {
                    PolygonShape polygon = (PolygonShape) shape;
                    if (Vertices.Count > 0)
                    {
                        Vertices.Clear();
                    }

                    for (int i = 0; i < polygon.Vertices.Count; i++)
                    {
                        Vertices.Add(polygon.Vertices[i]);
                    }

                    Radius = polygon.GetRadius;
                }
                    break;

                case ShapeType.Chain:
                {
                    ChainShape chain = (ChainShape) shape;
                    if (Vertices.Count > 0)
                    {
                        Vertices.Clear();
                    }


                    Vertices.Add(chain.Vertices[index]);
                    Vertices.Add(index + 1 < chain.Vertices.Count ? chain.Vertices[index + 1] : chain.Vertices[0]);

                    Radius = chain.GetRadius;
                }
                    break;

                case ShapeType.Edge:
                {
                    EdgeShape edge = (EdgeShape) shape;
                    if (Vertices.Count > 0)
                    {
                        Vertices.Clear();
                    }

                    Vertices.Add(edge.Vertex1);
                    Vertices.Add(edge.Vertex2);
                    Radius = edge.GetRadius;
                }
                    break;

                default:
                    Radius = 0;
                    break;
            }
        }

        /// <summary>
        ///     Gets the index of the supporting vertex in the given direction.
        /// </summary>
        /// <param name="direction">The direction vector to find the support vertex in.</param>
        /// <returns>
        ///     The zero-based index of the vertex that maximizes the dot product with the direction.
        /// </returns>
        /// <remarks>
        ///     The support vertex is the vertex farthest in the given direction,
        ///     found by maximizing the dot product with all vertices.
        /// </remarks>
        public int GetSupport(Vector2F direction)
        {
            int bestIndex = 0;
            float bestValue = Vector2F.Dot(Vertices[0], direction);
            for (int i = 1; i < Vertices.Count; ++i)
            {
                float value = Vector2F.Dot(Vertices[i], direction);
                if (value > bestValue)
                {
                    bestIndex = i;
                    bestValue = value;
                }
            }

            return bestIndex;
        }

        /// <summary>
        ///     Gets the supporting vertex position in the given direction.
        /// </summary>
        /// <param name="direction">The direction vector to find the support vertex in.</param>
        /// <returns>
        ///     A <see cref="Vector2F"/> representing the position of the vertex farthest in the given direction.
        /// </returns>
        /// <remarks>
        ///     The support vertex is the vertex farthest in the given direction,
        ///     found by maximizing the dot product with all vertices.
        /// </remarks>
        public Vector2F GetSupportVertex(Vector2F direction)
        {
            int bestIndex = 0;
            float bestValue = Vector2F.Dot(Vertices[0], direction);
            for (int i = 1; i < Vertices.Count; ++i)
            {
                float value = Vector2F.Dot(Vertices[i], direction);
                if (value > bestValue)
                {
                    bestIndex = i;
                    bestValue = value;
                }
            }

            return Vertices[bestIndex];
        }
    }
}