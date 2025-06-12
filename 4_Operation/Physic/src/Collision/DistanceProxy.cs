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

using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     A distance proxy is used by the GJK algorithm.
    ///     It encapsulates any shape.
    /// </summary>
    public struct DistanceProxy
    {
        /// <summary>
        ///     The radius
        /// </summary>
        internal readonly float Radius;

        /// <summary>
        ///     The vertices
        /// </summary>
        internal readonly Vertices Vertices;

        // GJK using Voronoi regions (Christer Ericson) and Barycentric coordinates.

        /// <summary>
        ///     Initialize the proxy using the given shape. The shape
        ///     must remain in scope while the proxy is in use.
        /// </summary>
        /// <param name="shape">The shape.</param>
        /// <param name="index">The index.</param>
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
                    Debug.Assert((0 <= index) && (index < chain.Vertices.Count));
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
                    Debug.Assert(false);
                    break;
            }
        }

        /// <summary>
        ///     Get the supporting vertex index in the given direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
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
        ///     Get the supporting vertex in the given direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
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