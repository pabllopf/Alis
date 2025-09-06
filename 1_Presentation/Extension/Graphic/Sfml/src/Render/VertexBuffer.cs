using System;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    /// The vertex buffer class
    /// </summary>
    /// <seealso cref="ObjectBase"/>
    /// <seealso cref="IDrawable"/>
    public class VertexBuffer : ObjectBase, IDrawable
    {
        
        /// <summary>
        /// Usage specifiers
        ///
        /// If data is going to be updated once or more every frame,
        /// set the usage to Stream. If data is going
        /// to be set once and used for a long time without being
        /// modified, set the usage to Static.
        /// For everything else Dynamic should
        /// be a good compromise.
        /// </summary>
        
        public enum UsageSpecifier
        {
            /// <summary>
            /// The stream usage specifier
            /// </summary>
            Stream,
            /// <summary>
            /// The dynamic usage specifier
            /// </summary>
            Dynamic,
            /// <summary>
            /// The static usage specifier
            /// </summary>
            Static
        }

        
        /// <summary>
        /// Whether or not the system supports vertex buffers
        ///
        /// This function should always be called before using
        /// the vertex buffer features. If it returns false, then
        /// any attempt to use sf::VertexBuffer will fail.
        /// </summary>
        ///////////////////////////////////////////////////////////
        public static bool Available { get { return sfVertexBuffer_isAvailable(); } }

        
        /// <summary>
        /// Create a new vertex buffer with a specific
        /// PrimitiveType and usage specifier.
        ///
        /// Creates the vertex buffer, allocating enough graphcis
        /// memory to hold \p vertexCount vertices, and sets its
        /// primitive type to \p type and usage to \p usage.
        /// </summary>
        /// <param name="vertexCount">Amount of vertices</param>
        /// <param name="primitiveType">Type of primitives</param>
        /// <param name="usageType">Usage specifier</param>
        
        public VertexBuffer(uint vertexCount, PrimitiveType primitiveType, UsageSpecifier usageType)
            : base(sfVertexBuffer_create(vertexCount, primitiveType, usageType))
        {
        }

        
        /// <summary>
        /// Construct the vertex buffer from another vertex array
        /// </summary>
        /// <param name="copy">VertexBuffer to copy</param>
        
        public VertexBuffer(VertexBuffer copy)
            : base(sfVertexBuffer_copy(copy.CPointer))
        {
        }

        
        /// <summary>
        /// Total vertex count
        /// </summary>
        
        public uint VertexCount { get { return sfVertexBuffer_getVertexCount(CPointer); } }

        
        /// <summary>
        /// OpenGL handle of the vertex buffer or 0 if not yet created
        /// 
        /// You shouldn't need to use this property, unless you have
        /// very specific stuff to implement that SFML doesn't support,
        /// or implement a temporary workaround until a bug is fixed.
        /// </summary>
        
        public uint NativeHandle
        {
            get { return sfVertexBuffer_getNativeHandle(CPointer); }
        }

        
        /// <summary>
        /// The type of primitives drawn by the vertex buffer
        /// </summary>
        
        public PrimitiveType PrimitiveType
        {
            get { return sfVertexBuffer_getPrimitiveType(CPointer); }
            set { sfVertexBuffer_setPrimitiveType(CPointer, value); }
        }

        
        /// <summary>
        /// The usage specifier for the vertex buffer
        /// </summary>
        
        public UsageSpecifier Usage
        {
            get { return sfVertexBuffer_getUsage(CPointer); }
            set { sfVertexBuffer_setUsage(CPointer, value); }
        }

        
        /// <summary>
        /// Update a part of the buffer from an array of vertices
        /// offset is specified as the number of vertices to skip
        /// from the beginning of the buffer.
        ///
        /// If offset is 0 and vertexCount is equal to the size of
        /// the currently created buffer, its whole contents are replaced.
        ///
        /// If offset is 0 and vertexCount is greater than the
        /// size of the currently created buffer, a new buffer is created
        /// containing the vertex data.
        ///
        /// If offset is 0 and vertexCount is less than the size of
        /// the currently created buffer, only the corresponding region
        /// is updated.
        ///
        /// If offset is not 0 and offset + vertexCount is greater
        /// than the size of the currently created buffer, the update fails.
        ///
        /// No additional check is performed on the size of the vertex
        /// array, passing invalid arguments will lead to undefined
        /// behavior.
        /// </summary>
        /// <param name="vertices">Array of vertices to copy to the buffer</param>
        /// <param name="vertexCount">Number of vertices to copy</param>
        /// <param name="offset">Offset in the buffer to copy to</param>
       public bool Update(Vertex[] vertices, uint vertexCount, uint offset)
       {
           GCHandle handle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
           try
           {
               IntPtr vertsPtr = handle.AddrOfPinnedObject();
               return sfVertexBuffer_update(CPointer, vertsPtr, vertexCount, offset);
           }
           finally
           {
               handle.Free();
           }
       }

        
        /// <summary>
        /// Update a part of the buffer from an array of vertices
        /// assuming an offset of 0 and a vertex count the length of the passed array.
        ///
        /// If offset is 0 and vertexCount is equal to the size of
        /// the currently created buffer, its whole contents are replaced.
        ///
        /// If offset is 0 and vertexCount is greater than the
        /// size of the currently created buffer, a new buffer is created
        /// containing the vertex data.
        ///
        /// If offset is 0 and vertexCount is less than the size of
        /// the currently created buffer, only the corresponding region
        /// is updated.
        ///
        /// If offset is not 0 and offset + vertexCount is greater
        /// than the size of the currently created buffer, the update fails.
        ///
        /// No additional check is performed on the size of the vertex
        /// array, passing invalid arguments will lead to undefined
        /// behavior.
        /// </summary>
        /// <param name="vertices">Array of vertices to copy to the buffer</param>
        
        public bool Update(Vertex[] vertices)
        {
            return this.Update(vertices, (uint)vertices.Length, 0);
        }

        
        /// <summary>
        /// Update a part of the buffer from an array of vertices
        /// assuming a vertex count the length of the passed array.
        ///
        /// If offset is 0 and vertexCount is equal to the size of
        /// the currently created buffer, its whole contents are replaced.
        ///
        /// If offset is 0 and vertexCount is greater than the
        /// size of the currently created buffer, a new buffer is created
        /// containing the vertex data.
        ///
        /// If offset is 0 and vertexCount is less than the size of
        /// the currently created buffer, only the corresponding region
        /// is updated.
        ///
        /// If offset is not 0 and offset + vertexCount is greater
        /// than the size of the currently created buffer, the update fails.
        ///
        /// No additional check is performed on the size of the vertex
        /// array, passing invalid arguments will lead to undefined
        /// behavior.
        /// </summary>
        /// <param name="vertices">Array of vertices to copy to the buffer</param>
        /// <param name="offset">Offset in the buffer to copy to</param>
        
        public bool Update(Vertex[] vertices, uint offset)
        {
            return this.Update(vertices, (uint)vertices.Length, offset);
        }

        
        /// <summary>
        /// Copy the contents of another buffer into this buffer
        /// </summary>
        /// <param name="other">Vertex buffer whose contents to copy into first vertex buffer</param>
        
        public bool Update(VertexBuffer other)
        {
            return sfVertexBuffer_updateFromVertexBuffer(CPointer, other.CPointer);
        }

        
        /// <summary>
        /// Swap the contents of another buffer into this buffer
        /// </summary>
        /// <param name="other">Vertex buffer whose contents to swap with</param>
        
        public void Swap(VertexBuffer other)
        {
            sfVertexBuffer_swap(CPointer, other.CPointer);
        }

        
        /// <summary>
        /// Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        
        public override void Destroy(bool disposing)
        {
            sfVertexBuffer_destroy(CPointer);
        }

        
        /// <summary>
        /// Draw the vertex buffer to a render target
        /// </summary>
        /// <param name="target">Render target to draw to</param>
        /// <param name="states">Current render states</param>
        
        public void Draw(IRenderTarget target, RenderStates states)
        {
            RenderStates.MarshalData marshaledStates = states.Marshal();

            if(target is RenderWindow)
            {
                sfRenderWindow_drawVertexBuffer(((RenderWindow)target).CPointer, CPointer, ref marshaledStates);
            }
            else if(target is RenderTexture)
            {
                sfRenderTexture_drawVertexBuffer(((RenderTexture)target).CPointer, CPointer, ref marshaledStates);
            }
        }

        #region Imports
        /// <summary>
        /// Sfs the vertex buffer create using the specified vertex count
        /// </summary>
        /// <param name="vertexCount">The vertex count</param>
        /// <param name="type">The type</param>
        /// <param name="usage">The usage</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfVertexBuffer_create(uint vertexCount, PrimitiveType type, UsageSpecifier usage);

        /// <summary>
        /// Sfs the vertex buffer copy using the specified copy
        /// </summary>
        /// <param name="copy">The copy</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfVertexBuffer_copy(IntPtr copy);

        /// <summary>
        /// Sfs the vertex buffer destroy using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfVertexBuffer_destroy(IntPtr cPointer);

        /// <summary>
        /// Sfs the vertex buffer get vertex count using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The uint</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern uint sfVertexBuffer_getVertexCount(IntPtr cPointer);

        /// <summary>
        /// Sfs the vertex buffer update using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="vertexCount">The vertex count</param>
        /// <param name="offset">The offset</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern bool sfVertexBuffer_update(IntPtr cPointer, Vertex[] vertices, uint vertexCount, uint offset);
        
        /// <summary>
        /// Sfs the vertex buffer update using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="vertexCount">The vertex count</param>
        /// <param name="offset">The offset</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern bool sfVertexBuffer_update(IntPtr cPointer, IntPtr vertices, uint vertexCount, uint offset);

        /// <summary>
        /// Sfs the vertex buffer update from vertex buffer using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern bool sfVertexBuffer_updateFromVertexBuffer(IntPtr cPointer, IntPtr other);

        /// <summary>
        /// Sfs the vertex buffer swap using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="other">The other</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfVertexBuffer_swap(IntPtr cPointer, IntPtr other);

        /// <summary>
        /// Sfs the vertex buffer get native handle using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The uint</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern uint sfVertexBuffer_getNativeHandle(IntPtr cPointer);

        /// <summary>
        /// Sfs the vertex buffer set primitive type using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="primitiveType">The primitive type</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfVertexBuffer_setPrimitiveType(IntPtr cPointer, PrimitiveType primitiveType);

        /// <summary>
        /// Sfs the vertex buffer get primitive type using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The primitive type</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern PrimitiveType sfVertexBuffer_getPrimitiveType(IntPtr cPointer);

        /// <summary>
        /// Sfs the vertex buffer set usage using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="usageType">The usage type</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfVertexBuffer_setUsage(IntPtr cPointer, UsageSpecifier usageType);

        /// <summary>
        /// Sfs the vertex buffer get usage using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The usage specifier</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern UsageSpecifier sfVertexBuffer_getUsage(IntPtr cPointer);

        /// <summary>
        /// Sfs the vertex buffer is available
        /// </summary>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern bool sfVertexBuffer_isAvailable();

        /// <summary>
        /// Sfs the render window draw vertex buffer using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="vertexArray">The vertex array</param>
        /// <param name="states">The states</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfRenderWindow_drawVertexBuffer(IntPtr cPointer, IntPtr vertexArray, ref RenderStates.MarshalData states);

        /// <summary>
        /// Sfs the render texture draw vertex buffer using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="vertexBuffer">The vertex buffer</param>
        /// <param name="states">The states</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfRenderTexture_drawVertexBuffer(IntPtr cPointer, IntPtr vertexBuffer, ref RenderStates.MarshalData states);
        #endregion
    }
}
