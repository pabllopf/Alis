// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   DistanceProxy.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Physics2D.Collision.Shapes;

namespace Alis.Core.Physics2D.Collision
{
    /// <summary>
    /// The distance proxy
    /// </summary>
    public struct DistanceProxy
    {
        /// <summary>
        /// The buffer
        /// </summary>
        internal Vector2[] _buffer; // = new Vector2[2];
        /// <summary>
        /// The vertices
        /// </summary>
        internal Vector2[] _vertices;
        /// <summary>
        /// The count
        /// </summary>
        internal int _count;
        /// <summary>
        /// The radius
        /// </summary>
        internal float _radius;

        /// <summary>
        /// Sets the vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="count">The count</param>
        /// <param name="radius">The radius</param>
        private void Set(in Vector2[] vertices, int count, float radius)
        {
            _vertices = vertices;
            _count = count;
            _radius = radius;
        }

        /// <summary>
        /// Sets the shape
        /// </summary>
        /// <param name="shape">The shape</param>
        /// <param name="index">The index</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal void Set(in Shape shape, in int index)
        {
            switch (shape)
            {
                case CircleShape circle:
                    _vertices = new[] {circle.m_p};
                    _count = 1;
                    _radius = circle.m_radius;
                    break;
                case PolygonShape polygon:
                    _vertices = polygon.m_vertices;
                    _count = polygon.m_count;
                    _radius = polygon.m_radius;
                    break;
                case ChainShape chain:
                    _buffer = new Vector2[2];
                    _buffer[0] = chain.m_vertices[index];
                    if (index + 1 < chain.m_count)
                    {
                        _buffer[1] = chain.m_vertices[index + 1];
                    }
                    else
                    {
                        _buffer[1] = chain.m_vertices[0];
                    }

                    _vertices = _buffer;
                    _count = 2;
                    _radius = chain.m_radius;

                    break;
                case EdgeShape edge:
                    _vertices = new[] {edge.m_vertex1, edge.m_vertex2};
                    _count = 2;
                    _radius = edge.m_radius;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Gets the support using the specified d
        /// </summary>
        /// <param name="d">The </param>
        /// <returns>The best index</returns>
        public int GetSupport(Vector2 d)
        {
            int bestIndex = 0;
            float bestValue = Vector2.Dot(_vertices[0], d);

            for (int i = 1; i < _count; ++i)
            {
                float value = Vector2.Dot(_vertices[i], d);
                if (value > bestValue)
                {
                    bestIndex = i;
                    bestValue = value;
                }
            }

            return bestIndex;
        }

        /// <summary>
        /// Gets the vertex count
        /// </summary>
        /// <returns>The int</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetVertexCount() => _count;

        /// <summary>
        /// Gets the value of the vertex count
        /// </summary>
        public int VertexCount
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _count;
        }

        /// <summary>
        /// Gets the vertex using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 GetVertex(int index) => _vertices[index];

        /// <summary>
        /// Gets the support using the specified d
        /// </summary>
        /// <param name="d">The </param>
        /// <returns>The best index</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetSupport(in Vector2 d)
        {
            int bestIndex = 0;
            float bestValue = Vector2.Dot(_vertices[0], d);

            for (int i = 1; i < _count; ++i)
            {
                float value = Vector2.Dot(_vertices[i], d);
                if (value > bestValue)
                {
                    bestIndex = i;
                    bestValue = value;
                }
            }

            return bestIndex;
        }

        /// <summary>
        /// Gets the support vertex using the specified d
        /// </summary>
        /// <param name="d">The </param>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 GetSupportVertex(in Vector2 d)
        {
            int bestIndex = 0;
            float bestValue = Vector2.Dot(_vertices[0], d);

            for (int i = 1; i < _count; ++i)
            {
                float value = Vector2.Dot(_vertices[i], d);
                if (value > bestValue)
                {
                    bestIndex = i;
                    bestValue = value;
                }
            }

            return _vertices[bestIndex];
        }
    }
}