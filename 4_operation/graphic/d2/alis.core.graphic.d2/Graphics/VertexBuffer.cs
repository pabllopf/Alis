// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   VertexBuffer.cs
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

namespace Alis.Core.Graphic.D2.Graphics
{
    /// <summary>
    ///     The vertex buffer class
    /// </summary>
    /// <seealso cref="ObjectBase" />
    /// <seealso cref="Drawable" />
    public class VertexBuffer : ObjectBase, Drawable
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Usage specifiers
        ///     If data is going to be updated once or more every frame,
        ///     set the usage to Stream. If data is going
        ///     to be set once and used for a long time without being
        ///     modified, set the usage to Static.
        ///     For everything else Dynamic should
        ///     be a good compromise.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public enum UsageSpecifier
        {
            /// <summary>
            ///     The stream usage specifier
            /// </summary>
            Stream,

            /// <summary>
            ///     The dynamic usage specifier
            /// </summary>
            Dynamic,

            /// <summary>
            ///     The static usage specifier
            /// </summary>
            Static
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Create a new vertex buffer with a specific
        ///     PrimitiveType and usage specifier.
        ///     Creates the vertex buffer, allocating enough graphcis
        ///     memory to hold \p vertexCount vertices, and sets its
        ///     primitive type to \p type and usage to \p usage.
        /// </summary>
        /// <param name="vertexCount">Amount of vertices</param>
        /// <param name="primitiveType">Type of primitives</param>
        /// <param name="usageType">Usage specifier</param>
        ////////////////////////////////////////////////////////////
        public VertexBuffer(uint vertexCount, PrimitiveType primitiveType, UsageSpecifier usageType)
            : base(sfVertexBuffer_create(vertexCount, primitiveType, usageType))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the vertex buffer from another vertex array
        /// </summary>
        /// <param name="copy">VertexBuffer to copy</param>
        ////////////////////////////////////////////////////////////
        public VertexBuffer(VertexBuffer copy)
            : base(sfVertexBuffer_copy(copy.CPointer))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Whether or not the system supports vertex buffers
        ///     This function should always be called before using
        ///     the vertex buffer features. If it returns false, then
        ///     any attempt to use sf::VertexBuffer will fail.
        /// </summary>
        ///////////////////////////////////////////////////////////
        public static bool Available => sfVertexBuffer_isAvailable();

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Total vertex count
        /// </summary>
        ////////////////////////////////////////////////////////////
        public uint VertexCount => sfVertexBuffer_getVertexCount(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     OpenGL handle of the vertex buffer or 0 if not yet created
        ///     You shouldn't need to use this property, unless you have
        ///     very specific stuff to implement that SFML doesn't support,
        ///     or implement a temporary workaround until a bug is fixed.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public uint NativeHandle => sfVertexBuffer_getNativeHandle(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     The type of primitives drawn by the vertex buffer
        /// </summary>
        ////////////////////////////////////////////////////////////
        public PrimitiveType PrimitiveType
        {
            get => sfVertexBuffer_getPrimitiveType(CPointer);
            set => sfVertexBuffer_setPrimitiveType(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     The usage specifier for the vertex buffer
        /// </summary>
        ////////////////////////////////////////////////////////////
        public UsageSpecifier Usage
        {
            get => sfVertexBuffer_getUsage(CPointer);
            set => sfVertexBuffer_setUsage(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Draw the vertex buffer to a render target
        /// </summary>
        /// <param name="target">Render target to draw to</param>
        /// <param name="states">Current render states</param>
        ////////////////////////////////////////////////////////////
        public void Draw(RenderTarget target, RenderStates states)
        {
            RenderStates.MarshalData marshaledStates = states.Marshal();

            if (target is RenderWindow)
            {
                sfRenderWindow_drawVertexBuffer(((RenderWindow) target).CPointer, CPointer, ref marshaledStates);
            }
            else if (target is RenderTexture)
            {
                sfRenderTexture_drawVertexBuffer(((RenderTexture) target).CPointer, CPointer, ref marshaledStates);
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Update a part of the buffer from an array of vertices
        ///     offset is specified as the number of vertices to skip
        ///     from the beginning of the buffer.
        ///     If offset is 0 and vertexCount is equal to the size of
        ///     the currently created buffer, its whole contents are replaced.
        ///     If offset is 0 and vertexCount is greater than the
        ///     size of the currently created buffer, a new buffer is created
        ///     containing the vertex data.
        ///     If offset is 0 and vertexCount is less than the size of
        ///     the currently created buffer, only the corresponding region
        ///     is updated.
        ///     If offset is not 0 and offset + vertexCount is greater
        ///     than the size of the currently created buffer, the update fails.
        ///     No additional check is performed on the size of the vertex
        ///     array, passing invalid arguments will lead to undefined
        ///     behavior.
        /// </summary>
        /// <param name="vertices">Array of vertices to copy to the buffer</param>
        /// <param name="vertexCount">Number of vertices to copy</param>
        /// <param name="offset">Offset in the buffer to copy to</param>
        ////////////////////////////////////////////////////////////
        public bool Update(Vertex[] vertices, uint vertexCount, uint offset)
        {
            unsafe
            {
                fixed (Vertex* verts = vertices)
                {
                    return sfVertexBuffer_update(CPointer, verts, vertexCount, offset);
                }
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Update a part of the buffer from an array of vertices
        ///     assuming an offset of 0 and a vertex count the length of the passed array.
        ///     If offset is 0 and vertexCount is equal to the size of
        ///     the currently created buffer, its whole contents are replaced.
        ///     If offset is 0 and vertexCount is greater than the
        ///     size of the currently created buffer, a new buffer is created
        ///     containing the vertex data.
        ///     If offset is 0 and vertexCount is less than the size of
        ///     the currently created buffer, only the corresponding region
        ///     is updated.
        ///     If offset is not 0 and offset + vertexCount is greater
        ///     than the size of the currently created buffer, the update fails.
        ///     No additional check is performed on the size of the vertex
        ///     array, passing invalid arguments will lead to undefined
        ///     behavior.
        /// </summary>
        /// <param name="vertices">Array of vertices to copy to the buffer</param>
        ////////////////////////////////////////////////////////////
        public bool Update(Vertex[] vertices)
        {
            return Update(vertices, (uint) vertices.Length, 0);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Update a part of the buffer from an array of vertices
        ///     assuming a vertex count the length of the passed array.
        ///     If offset is 0 and vertexCount is equal to the size of
        ///     the currently created buffer, its whole contents are replaced.
        ///     If offset is 0 and vertexCount is greater than the
        ///     size of the currently created buffer, a new buffer is created
        ///     containing the vertex data.
        ///     If offset is 0 and vertexCount is less than the size of
        ///     the currently created buffer, only the corresponding region
        ///     is updated.
        ///     If offset is not 0 and offset + vertexCount is greater
        ///     than the size of the currently created buffer, the update fails.
        ///     No additional check is performed on the size of the vertex
        ///     array, passing invalid arguments will lead to undefined
        ///     behavior.
        /// </summary>
        /// <param name="vertices">Array of vertices to copy to the buffer</param>
        /// <param name="offset">Offset in the buffer to copy to</param>
        ////////////////////////////////////////////////////////////
        public bool Update(Vertex[] vertices, uint offset)
        {
            return Update(vertices, (uint) vertices.Length, offset);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Copy the contents of another buffer into this buffer
        /// </summary>
        /// <param name="other">Vertex buffer whose contents to copy into first vertex buffer</param>
        ////////////////////////////////////////////////////////////
        public bool Update(VertexBuffer other)
        {
            return sfVertexBuffer_updateFromVertexBuffer(CPointer, other.CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Swap the contents of another buffer into this buffer
        /// </summary>
        /// <param name="other">Vertex buffer whose contents to swap with</param>
        ////////////////////////////////////////////////////////////
        public void Swap(VertexBuffer other)
        {
            sfVertexBuffer_swap(CPointer, other.CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            sfVertexBuffer_destroy(CPointer);
        }

        /// <summary>
        ///     Sfs the vertex buffer create using the specified vertex count
        /// </summary>
        /// <param name="vertexCount">The vertex count</param>
        /// <param name="type">The type</param>
        /// <param name="usage">The usage</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfVertexBuffer_create(uint vertexCount, PrimitiveType type, UsageSpecifier usage);

        /// <summary>
        ///     Sfs the vertex buffer copy using the specified copy
        /// </summary>
        /// <param name="copy">The copy</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfVertexBuffer_copy(IntPtr copy);

        /// <summary>
        ///     Sfs the vertex buffer destroy using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern void sfVertexBuffer_destroy(IntPtr CPointer);

        /// <summary>
        ///     Sfs the vertex buffer get vertex count using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The uint</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern uint sfVertexBuffer_getVertexCount(IntPtr CPointer);

        /// <summary>
        ///     Describes whether sf vertex buffer update
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="vertexCount">The vertex count</param>
        /// <param name="offset">The offset</param>
        /// <returns>The bool</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern unsafe bool sfVertexBuffer_update(IntPtr CPointer, Vertex* vertices, uint vertexCount,
            uint offset);

        /// <summary>
        ///     Describes whether sf vertex buffer update from vertex buffer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern bool sfVertexBuffer_updateFromVertexBuffer(IntPtr CPointer, IntPtr other);

        /// <summary>
        ///     Sfs the vertex buffer swap using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="other">The other</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern void sfVertexBuffer_swap(IntPtr CPointer, IntPtr other);

        /// <summary>
        ///     Sfs the vertex buffer get native handle using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The uint</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern uint sfVertexBuffer_getNativeHandle(IntPtr CPointer);

        /// <summary>
        ///     Sfs the vertex buffer set primitive type using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="primitiveType">The primitive type</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern void sfVertexBuffer_setPrimitiveType(IntPtr CPointer, PrimitiveType primitiveType);

        /// <summary>
        ///     Sfs the vertex buffer get primitive type using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The primitive type</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern PrimitiveType sfVertexBuffer_getPrimitiveType(IntPtr CPointer);

        /// <summary>
        ///     Sfs the vertex buffer set usage using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="usageType">The usage type</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern void sfVertexBuffer_setUsage(IntPtr CPointer, UsageSpecifier usageType);

        /// <summary>
        ///     Sfs the vertex buffer get usage using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The usage specifier</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern UsageSpecifier sfVertexBuffer_getUsage(IntPtr CPointer);

        /// <summary>
        ///     Describes whether sf vertex buffer is available
        /// </summary>
        /// <returns>The bool</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern bool sfVertexBuffer_isAvailable();

        /// <summary>
        ///     Sfs the render window draw vertex buffer using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="VertexArray">The vertex array</param>
        /// <param name="states">The states</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_drawVertexBuffer(IntPtr CPointer, IntPtr VertexArray,
            ref RenderStates.MarshalData states);

        /// <summary>
        ///     Sfs the render texture draw vertex buffer using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="VertexBuffer">The vertex buffer</param>
        /// <param name="states">The states</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderTexture_drawVertexBuffer(IntPtr CPointer, IntPtr VertexBuffer,
            ref RenderStates.MarshalData states);
    }
}