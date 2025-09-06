using System;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Render
{
    
    /// <summary>
    /// Define a set of one or more 2D primitives
    /// </summary>
    
    public class VertexArray : ObjectBase, IDrawable
    {
        
        /// <summary>
        /// Default constructor
        /// </summary>
        
        public VertexArray() :
            base(sfVertexArray_create())
        {
        }

        
        /// <summary>
        /// Construct the vertex array with a type
        /// </summary>
        /// <param name="type">Type of primitives</param>
        
        public VertexArray(PrimitiveType type) :
            base(sfVertexArray_create())
        {
            PrimitiveType = type;
        }

        
        /// <summary>
        /// Construct the vertex array with a type and an initial number of vertices
        /// </summary>
        /// <param name="type">Type of primitives</param>
        /// <param name="vertexCount">Initial number of vertices in the array</param>
        
        public VertexArray(PrimitiveType type, uint vertexCount) :
            base(sfVertexArray_create())
        {
            PrimitiveType = type;
            Resize(vertexCount);
        }

        
        /// <summary>
        /// Construct the vertex array from another vertex array
        /// </summary>
        /// <param name="copy">Transformable to copy</param>
        
        public VertexArray(VertexArray copy) :
            base(sfVertexArray_copy(copy.CPointer))
        {
        }

        
        /// <summary>
        /// Total vertex count
        /// </summary>
        
        public uint VertexCount
        {
            get { return sfVertexArray_getVertexCount(CPointer); }
        }

        
        /// <summary>
        /// Read-write access to vertices by their index.
        ///
        /// This function doesn't check index, it must be in range
        /// [0, VertexCount - 1]. The behaviour is undefined
        /// otherwise.
        /// </summary>
        /// <param name="index">Index of the vertex to get</param>
        /// <returns>Reference to the index-th vertex</returns>
        
        public Vertex this[uint index]
        {
            get
            {
                IntPtr vertexPtr = Marshal.AllocHGlobal(Marshal.SizeOf<Vertex>());
                try
                {
                    vertexPtr = sfVertexArray_getVertex_v2(CPointer, index);
                    return Marshal.PtrToStructure<Vertex>(vertexPtr);
                }
                finally
                {
                    // No liberar vertexPtr si lo devuelve la función nativa
                }
            }
            set
            {
                IntPtr vertexPtr = sfVertexArray_getVertex_v2(CPointer, index);
                Marshal.StructureToPtr(value, vertexPtr, false);
            }
        }
        
        /// <summary>
        /// Clear the vertex array
        /// </summary>
        
        public void Clear()
        {
            sfVertexArray_clear(CPointer);
        }

        
        /// <summary>
        /// Resize the vertex array
        /// 
        /// If \a vertexCount is greater than the current size, the previous
        /// vertices are kept and new (default-constructed) vertices are
        /// added.
        /// If \a vertexCount is less than the current size, existing vertices
        /// are removed from the array.
        /// </summary>
        /// <param name="vertexCount">New size of the array (number of vertices)</param>
        
        public void Resize(uint vertexCount)
        {
            sfVertexArray_resize(CPointer, vertexCount);
        }

        
        /// <summary>
        /// Add a vertex to the array
        /// </summary>
        /// <param name="vertex">Vertex to add</param>
        
        public void Append(Vertex vertex)
        {
            sfVertexArray_append(CPointer, vertex);
        }

        
        /// <summary>
        /// Type of primitives to draw
        /// </summary>
        
        public PrimitiveType PrimitiveType
        {
            get { return sfVertexArray_getPrimitiveType(CPointer); }
            set { sfVertexArray_setPrimitiveType(CPointer, value); }
        }

        
        /// <summary>
        /// Compute the bounding rectangle of the vertex array.
        ///
        /// This function returns the axis-aligned rectangle that
        /// contains all the vertices of the array.
        /// </summary>
        
        public FloatRect Bounds
        {
            get { return sfVertexArray_getBounds(CPointer); }
        }

        
        /// <summary>
        /// Draw the vertex array to a render target
        /// </summary>
        /// <param name="target">Render target to draw to</param>
        /// <param name="states">Current render states</param>
        
        public void Draw(IRenderTarget target, RenderStates states)
        {
            RenderStates.MarshalData marshaledStates = states.Marshal();

            if (target is RenderWindow)
            {
                sfRenderWindow_drawVertexArray(( (RenderWindow)target ).CPointer, CPointer, ref marshaledStates);
            }
            else if (target is RenderTexture)
            {
                sfRenderTexture_drawVertexArray(( (RenderTexture)target ).CPointer, CPointer, ref marshaledStates);
            }
        }

        
        /// <summary>
        /// Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        
        public override void Destroy(bool disposing)
        {
            sfVertexArray_destroy(CPointer);
        }

        #region Imports
        /// <summary>
        /// Sfs the vertex array create
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfVertexArray_create();

        /// <summary>
        /// Sfs the vertex array copy using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfVertexArray_copy(IntPtr cPointer);

        /// <summary>
        /// Sfs the vertex array destroy using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfVertexArray_destroy(IntPtr cPointer);

        /// <summary>
        /// Sfs the vertex array get vertex count using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The uint</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern uint sfVertexArray_getVertexCount(IntPtr cPointer);

        /// <summary>
        /// Sfs the vertex array get vertex using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="index">The index</param>
        /// <returns>The vertex</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern Vertex sfVertexArray_getVertex(IntPtr cPointer, uint index);
        
        /// <summary>
        /// Sfs the vertex array get vertex v 2 using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl, EntryPoint = "sfVertexArray_getVertex"), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfVertexArray_getVertex_v2(IntPtr cPointer, uint index);

        /// <summary>
        /// Sfs the vertex array clear using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfVertexArray_clear(IntPtr cPointer);

        /// <summary>
        /// Sfs the vertex array resize using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="vertexCount">The vertex count</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfVertexArray_resize(IntPtr cPointer, uint vertexCount);

        /// <summary>
        /// Sfs the vertex array append using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="vertex">The vertex</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfVertexArray_append(IntPtr cPointer, Vertex vertex);

        /// <summary>
        /// Sfs the vertex array set primitive type using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="type">The type</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfVertexArray_setPrimitiveType(IntPtr cPointer, PrimitiveType type);

        /// <summary>
        /// Sfs the vertex array get primitive type using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The primitive type</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern PrimitiveType sfVertexArray_getPrimitiveType(IntPtr cPointer);

        /// <summary>
        /// Sfs the vertex array get bounds using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The float rect</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern FloatRect sfVertexArray_getBounds(IntPtr cPointer);

        /// <summary>
        /// Sfs the render window draw vertex array using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="vertexArray">The vertex array</param>
        /// <param name="states">The states</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfRenderWindow_drawVertexArray(IntPtr cPointer, IntPtr vertexArray, ref RenderStates.MarshalData states);

        /// <summary>
        /// Sfs the render texture draw vertex array using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="vertexArray">The vertex array</param>
        /// <param name="states">The states</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfRenderTexture_drawVertexArray(IntPtr cPointer, IntPtr vertexArray, ref RenderStates.MarshalData states);
        #endregion
    }
}
