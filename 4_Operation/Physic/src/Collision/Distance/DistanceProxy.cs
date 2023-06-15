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

using System;
using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Shapes;

namespace Alis.Core.Physic.Collision.Distance
{
    /// <summary>A distance proxy is used by the GJK algorithm. It encapsulates any shape.</summary>
    public struct DistanceProxy
    {
        /// <summary>
        ///     The radius
        /// </summary>
        internal readonly float Radius;

        /// <summary>
        ///     The vertices
        /// </summary>
        internal readonly Vector2[] Vertices;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DistanceProxy" /> class
        /// </summary>
        /// <param name="shape">The shape</param>
        /// <param name="index">The index</param>
        /// <exception cref="NotSupportedException"></exception>
        public DistanceProxy(Shape shape, int index)
        {
            switch (shape.ShapeType)
            {
                case ShapeType.Circle:
                {
                    CircleShape circle = (CircleShape) shape;
                    Vertices = new Vector2[1];
                    Vertices[0] = circle.Positionprivate;
                    Radius = circle.RadiusPrivate;
                }
                    break;

                case ShapeType.Polygon:
                {
                    PolygonShape polygon = (PolygonShape) shape;
                    Vertices = new Vector2[polygon.VerticesPrivate.Count];

                    for (int i = 0; i < polygon.VerticesPrivate.Count; i++)
                    {
                        Vertices[i] = polygon.VerticesPrivate[i];
                    }

                    Radius = polygon.RadiusPrivate;
                }
                    break;

                case ShapeType.Chain:
                {
                    ChainShape chain = (ChainShape) shape;
                    Debug.Assert((0 <= index) && (index < chain.Vertices.Count));

                    Vertices = new Vector2[2];
                    Vertices[0] = chain.Vertices[index];
                    Vertices[1] = index + 1 < chain.Vertices.Count ? chain.Vertices[index + 1] : chain.Vertices[0];

                    Radius = chain.RadiusPrivate;
                }
                    break;

                case ShapeType.Edge:
                {
                    EdgeShape edge = (EdgeShape) shape;
                    Vertices = new Vector2[2];
                    Vertices[0] = edge.Vertex1;
                    Vertices[1] = edge.Vertex2;
                    Radius = edge.RadiusPrivate;
                }
                    break;

                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DistanceProxy" /> class
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="radius">The radius</param>
        public DistanceProxy(Vector2[] vertices, float radius)
        {
            Vertices = vertices;
            Radius = radius;
        }

        /// <summary>Get the supporting vertex index in the given direction.</summary>
        /// <param name="direction">The direction.</param>
        public int GetSupport(Vector2 direction)
        {
            int bestIndex = 0;
            float bestValue = Vector2.Dot(Vertices[0], direction);
            for (int i = 1; i < Vertices.Length; ++i)
            {
                float value = Vector2.Dot(Vertices[i], direction);
                if (value > bestValue)
                {
                    bestIndex = i;
                    bestValue = value;
                }
            }

            return bestIndex;
        }

        /// <summary>
        ///     Gets the vertex using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The vector</returns>
        public Vector2 GetVertex(int index)
        {
            Debug.Assert((0 <= index) && (index < Vertices.Length));
            return Vertices[index];
        }
    }
}