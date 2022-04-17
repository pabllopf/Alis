// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   VertexArray.cs
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
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Graphics2D.Systems;

namespace Alis.Core.Graphics2D.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Define a set of one or more 2D primitives
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class VertexArray : ObjectBase, Drawable
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Default constructor
        /// </summary>
        ////////////////////////////////////////////////////////////
        public VertexArray() :
            base(sfVertexArray_create())
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the vertex array with a type
        /// </summary>
        /// <param name="type">Type of primitives</param>
        ////////////////////////////////////////////////////////////
        public VertexArray(PrimitiveType type) :
            base(sfVertexArray_create()) =>
            PrimitiveType = type;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the vertex array with a type and an initial number of vertices
        /// </summary>
        /// <param name="type">Type of primitives</param>
        /// <param name="vertexCount">Initial number of vertices in the array</param>
        ////////////////////////////////////////////////////////////
        public VertexArray(PrimitiveType type, uint vertexCount) :
            base(sfVertexArray_create())
        {
            PrimitiveType = type;
            Resize(vertexCount);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the vertex array from another vertex array
        /// </summary>
        /// <param name="copy">Transformable to copy</param>
        ////////////////////////////////////////////////////////////
        public VertexArray(VertexArray copy) :
            base(sfVertexArray_copy(copy.CPointer))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Total vertex count
        /// </summary>
        ////////////////////////////////////////////////////////////
        public uint VertexCount => sfVertexArray_getVertexCount(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Read-write access to vertices by their index.
        ///     This function doesn't check index, it must be in range
        ///     [0, VertexCount - 1]. The behaviour is undefined
        ///     otherwise.
        /// </summary>
        /// <param name="index">Index of the vertex to get</param>
        /// <returns>Reference to the index-th vertex</returns>
        ////////////////////////////////////////////////////////////
        public Vertex this[uint index]
        {
            get
            {
                unsafe
                {
                    return *sfVertexArray_getVertex(CPointer, index);
                }
            }
            set
            {
                unsafe
                {
                    *sfVertexArray_getVertex(CPointer, index) = value;
                }
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Type of primitives to draw
        /// </summary>
        ////////////////////////////////////////////////////////////
        public PrimitiveType PrimitiveType
        {
            get => sfVertexArray_getPrimitiveType(CPointer);
            set => sfVertexArray_setPrimitiveType(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Compute the bounding rectangle of the vertex array.
        ///     This function returns the axis-aligned rectangle that
        ///     contains all the vertices of the array.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public FloatRect Bounds => sfVertexArray_getBounds(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Draw the vertex array to a render target
        /// </summary>
        /// <param name="target">Render target to draw to</param>
        /// <param name="states">Current render states</param>
        ////////////////////////////////////////////////////////////
        public void Draw(RenderTarget target, RenderStates states)
        {
            RenderStates.MarshalData marshaledStates = states.Marshal();

            if (target is RenderWindow)
            {
                sfRenderWindow_drawVertexArray(((RenderWindow) target).CPointer, CPointer, ref marshaledStates);
            }
            else if (target is RenderTexture)
            {
                sfRenderTexture_drawVertexArray(((RenderTexture) target).CPointer, CPointer, ref marshaledStates);
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Clear the vertex array
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void Clear()
        {
            sfVertexArray_clear(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Resize the vertex array
        ///     If \a vertexCount is greater than the current size, the previous
        ///     vertices are kept and new (default-constructed) vertices are
        ///     added.
        ///     If \a vertexCount is less than the current size, existing vertices
        ///     are removed from the array.
        /// </summary>
        /// <param name="vertexCount">New size of the array (number of vertices)</param>
        ////////////////////////////////////////////////////////////
        public void Resize(uint vertexCount)
        {
            sfVertexArray_resize(CPointer, vertexCount);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Add a vertex to the array
        /// </summary>
        /// <param name="vertex">Vertex to add</param>
        ////////////////////////////////////////////////////////////
        public void Append(Vertex vertex)
        {
            sfVertexArray_append(CPointer, vertex);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            sfVertexArray_destroy(CPointer);
        }

        /// <summary>
        ///     Sfs the vertex array create
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfVertexArray_create();

        /// <summary>
        ///     Sfs the vertex array copy using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfVertexArray_copy(IntPtr CPointer);

        /// <summary>
        ///     Sfs the vertex array destroy using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfVertexArray_destroy(IntPtr CPointer);

        /// <summary>
        ///     Sfs the vertex array get vertex count using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The uint</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint sfVertexArray_getVertexCount(IntPtr CPointer);

        /// <summary>
        ///     Sfs the vertex array get vertex using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="index">The index</param>
        /// <returns>The vertex</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern unsafe Vertex* sfVertexArray_getVertex(IntPtr CPointer, uint index);

        /// <summary>
        ///     Sfs the vertex array clear using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfVertexArray_clear(IntPtr CPointer);

        /// <summary>
        ///     Sfs the vertex array resize using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="vertexCount">The vertex count</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfVertexArray_resize(IntPtr CPointer, uint vertexCount);

        /// <summary>
        ///     Sfs the vertex array append using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="vertex">The vertex</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfVertexArray_append(IntPtr CPointer, Vertex vertex);

        /// <summary>
        ///     Sfs the vertex array set primitive type using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="type">The type</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfVertexArray_setPrimitiveType(IntPtr CPointer, PrimitiveType type);

        /// <summary>
        ///     Sfs the vertex array get primitive type using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The primitive type</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern PrimitiveType sfVertexArray_getPrimitiveType(IntPtr CPointer);

        /// <summary>
        ///     Sfs the vertex array get bounds using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The float rect</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern FloatRect sfVertexArray_getBounds(IntPtr CPointer);

        /// <summary>
        ///     Sfs the render window draw vertex array using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="VertexArray">The vertex array</param>
        /// <param name="states">The states</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_drawVertexArray(IntPtr CPointer, IntPtr VertexArray,
            ref RenderStates.MarshalData states);

        /// <summary>
        ///     Sfs the render texture draw vertex array using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="VertexArray">The vertex array</param>
        /// <param name="states">The states</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderTexture_drawVertexArray(IntPtr CPointer, IntPtr VertexArray,
            ref RenderStates.MarshalData states);
    }
}