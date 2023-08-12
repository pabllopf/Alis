using System;
using System.Runtime.InteropServices;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl render command encoder
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRenderCommandEncoder
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="MTLRenderCommandEncoder"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public MTLRenderCommandEncoder(IntPtr ptr) => NativePtr = ptr;
        /// <summary>
        /// Gets the value of the is null
        /// </summary>
        public bool IsNull => NativePtr == IntPtr.Zero;

        /// <summary>
        /// Sets the render pipeline state using the specified pipeline state
        /// </summary>
        /// <param name="pipelineState">The pipeline state</param>
        public void setRenderPipelineState(MTLRenderPipelineState pipelineState)
            => objc_msgSend(NativePtr, sel_setRenderPipelineState, pipelineState.NativePtr);

        /// <summary>
        /// Sets the vertex buffer using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="index">The index</param>
        public void setVertexBuffer(MTLBuffer buffer, UIntPtr offset, UIntPtr index)
            => objc_msgSend(NativePtr, sel_setVertexBuffer,
                buffer.NativePtr,
                offset,
                index);

        /// <summary>
        /// Sets the fragment buffer using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="index">The index</param>
        public void setFragmentBuffer(MTLBuffer buffer, UIntPtr offset, UIntPtr index)
            => objc_msgSend(NativePtr, sel_setFragmentBuffer,
                buffer.NativePtr,
                offset,
                index);

        /// <summary>
        /// Sets the vertex texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="index">The index</param>
        public void setVertexTexture(MTLTexture texture, UIntPtr index)
            => objc_msgSend(NativePtr, sel_setVertexTexture, texture.NativePtr, index);
        /// <summary>
        /// Sets the fragment texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="index">The index</param>
        public void setFragmentTexture(MTLTexture texture, UIntPtr index)
            => objc_msgSend(NativePtr, sel_setFragmentTexture, texture.NativePtr, index);

        /// <summary>
        /// Sets the vertex sampler state using the specified sampler
        /// </summary>
        /// <param name="sampler">The sampler</param>
        /// <param name="index">The index</param>
        public void setVertexSamplerState(MTLSamplerState sampler, UIntPtr index)
            => objc_msgSend(NativePtr, sel_setVertexSamplerState, sampler.NativePtr, index);

        /// <summary>
        /// Sets the fragment sampler state using the specified sampler
        /// </summary>
        /// <param name="sampler">The sampler</param>
        /// <param name="index">The index</param>
        public void setFragmentSamplerState(MTLSamplerState sampler, UIntPtr index)
            => objc_msgSend(NativePtr, sel_setFragmentSamplerState, sampler.NativePtr, index);

        /// <summary>
        /// Draws the primitives using the specified primitive type
        /// </summary>
        /// <param name="primitiveType">The primitive type</param>
        /// <param name="vertexStart">The vertex start</param>
        /// <param name="vertexCount">The vertex count</param>
        /// <param name="instanceCount">The instance count</param>
        /// <param name="baseInstance">The base instance</param>
        public void drawPrimitives(
            MTLPrimitiveType primitiveType,
            UIntPtr vertexStart,
            UIntPtr vertexCount,
            UIntPtr instanceCount,
            UIntPtr baseInstance)
            => objc_msgSend(NativePtr, sel_drawPrimitives0,
                primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);

        /// <summary>
        /// Draws the primitives using the specified primitive type
        /// </summary>
        /// <param name="primitiveType">The primitive type</param>
        /// <param name="vertexStart">The vertex start</param>
        /// <param name="vertexCount">The vertex count</param>
        /// <param name="instanceCount">The instance count</param>
        public void drawPrimitives(
            MTLPrimitiveType primitiveType,
            UIntPtr vertexStart,
            UIntPtr vertexCount,
            UIntPtr instanceCount)
            => objc_msgSend(NativePtr, sel_drawPrimitives2,
                primitiveType, vertexStart, vertexCount, instanceCount);

        /// <summary>
        /// Draws the primitives using the specified primitive type
        /// </summary>
        /// <param name="primitiveType">The primitive type</param>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="indirectBufferOffset">The indirect buffer offset</param>
        public void drawPrimitives(MTLPrimitiveType primitiveType, MTLBuffer indirectBuffer, UIntPtr indirectBufferOffset)
            => objc_msgSend(NativePtr, sel_drawPrimitives1,
                primitiveType, indirectBuffer, indirectBufferOffset);

        /// <summary>
        /// Draws the indexed primitives using the specified primitive type
        /// </summary>
        /// <param name="primitiveType">The primitive type</param>
        /// <param name="indexCount">The index count</param>
        /// <param name="indexType">The index type</param>
        /// <param name="indexBuffer">The index buffer</param>
        /// <param name="indexBufferOffset">The index buffer offset</param>
        /// <param name="instanceCount">The instance count</param>
        public void drawIndexedPrimitives(
            MTLPrimitiveType primitiveType,
            UIntPtr indexCount,
            MTLIndexType indexType,
            MTLBuffer indexBuffer,
            UIntPtr indexBufferOffset,
            UIntPtr instanceCount)
            => objc_msgSend(NativePtr, sel_drawIndexedPrimitives0,
                primitiveType, indexCount, indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount);

        /// <summary>
        /// Draws the indexed primitives using the specified primitive type
        /// </summary>
        /// <param name="primitiveType">The primitive type</param>
        /// <param name="indexCount">The index count</param>
        /// <param name="indexType">The index type</param>
        /// <param name="indexBuffer">The index buffer</param>
        /// <param name="indexBufferOffset">The index buffer offset</param>
        /// <param name="instanceCount">The instance count</param>
        /// <param name="baseVertex">The base vertex</param>
        /// <param name="baseInstance">The base instance</param>
        public void drawIndexedPrimitives(
            MTLPrimitiveType primitiveType,
            UIntPtr indexCount,
            MTLIndexType indexType,
            MTLBuffer indexBuffer,
            UIntPtr indexBufferOffset,
            UIntPtr instanceCount,
            IntPtr baseVertex,
            UIntPtr baseInstance)
            => objc_msgSend(
                NativePtr,
                sel_drawIndexedPrimitives1,
                primitiveType, indexCount, indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount, baseVertex, baseInstance);

        /// <summary>
        /// Draws the indexed primitives using the specified primitive type
        /// </summary>
        /// <param name="primitiveType">The primitive type</param>
        /// <param name="indexType">The index type</param>
        /// <param name="indexBuffer">The index buffer</param>
        /// <param name="indexBufferOffset">The index buffer offset</param>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="indirectBufferOffset">The indirect buffer offset</param>
        public void drawIndexedPrimitives(
            MTLPrimitiveType primitiveType,
            MTLIndexType indexType,
            MTLBuffer indexBuffer,
            UIntPtr indexBufferOffset,
            MTLBuffer indirectBuffer,
            UIntPtr indirectBufferOffset)
            => objc_msgSend(NativePtr, sel_drawIndexedPrimitives2,
                primitiveType,
                indexType,
                indexBuffer,
                indexBufferOffset,
                indirectBuffer,
                indirectBufferOffset);

        /// <summary>
        /// Sets the viewport using the specified viewport
        /// </summary>
        /// <param name="viewport">The viewport</param>
        public unsafe void setViewport(MTLViewport viewport)
            => objc_msgSend(NativePtr, sel_setViewport, viewport);

        /// <summary>
        /// Sets the viewports using the specified viewports
        /// </summary>
        /// <param name="viewports">The viewports</param>
        /// <param name="count">The count</param>
        public unsafe void setViewports(MTLViewport* viewports, UIntPtr count)
            => objc_msgSend(NativePtr, sel_setViewports, viewports, count);

        /// <summary>
        /// Sets the scissor rect using the specified scissor rect
        /// </summary>
        /// <param name="scissorRect">The scissor rect</param>
        public unsafe void setScissorRect(MTLScissorRect scissorRect)
            => objc_msgSend(NativePtr, sel_setScissorRect, scissorRect);

        /// <summary>
        /// Sets the scissor rects using the specified scissor rects
        /// </summary>
        /// <param name="scissorRects">The scissor rects</param>
        /// <param name="count">The count</param>
        public unsafe void setScissorRects(MTLScissorRect* scissorRects, UIntPtr count)
            => objc_msgSend(NativePtr, sel_setScissorRects, scissorRects, count);

        /// <summary>
        /// Sets the cull mode using the specified cull mode
        /// </summary>
        /// <param name="cullMode">The cull mode</param>
        public void setCullMode(MTLCullMode cullMode)
            => objc_msgSend(NativePtr, sel_setCullMode, (uint)cullMode);

        /// <summary>
        /// Sets the front facing using the specified front face winding
        /// </summary>
        /// <param name="frontFaceWinding">The front face winding</param>
        public void setFrontFacing(MTLWinding frontFaceWinding)
            => objc_msgSend(NativePtr, sel_setFrontFacingWinding, (uint)frontFaceWinding);

        /// <summary>
        /// Sets the depth stencil state using the specified depth stencil state
        /// </summary>
        /// <param name="depthStencilState">The depth stencil state</param>
        public void setDepthStencilState(MTLDepthStencilState depthStencilState)
            => objc_msgSend(NativePtr, sel_setDepthStencilState, depthStencilState.NativePtr);

        /// <summary>
        /// Sets the depth clip mode using the specified depth clip mode
        /// </summary>
        /// <param name="depthClipMode">The depth clip mode</param>
        public void setDepthClipMode(MTLDepthClipMode depthClipMode)
            => objc_msgSend(NativePtr, sel_setDepthClipMode, (uint)depthClipMode);

        /// <summary>
        /// Ends the encoding
        /// </summary>
        public void endEncoding() => objc_msgSend(NativePtr, sel_endEncoding);

        /// <summary>
        /// Sets the stencil reference value using the specified stencil reference
        /// </summary>
        /// <param name="stencilReference">The stencil reference</param>
        public void setStencilReferenceValue(uint stencilReference)
            => objc_msgSend(NativePtr, sel_setStencilReferenceValue, stencilReference);

        /// <summary>
        /// Sets the blend color using the specified red
        /// </summary>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <param name="alpha">The alpha</param>
        public void setBlendColor(float red, float green, float blue, float alpha)
            => objc_msgSend(NativePtr, sel_setBlendColor, red, green, blue, alpha);

        /// <summary>
        /// Sets the triangle fill mode using the specified fill mode
        /// </summary>
        /// <param name="fillMode">The fill mode</param>
        public void setTriangleFillMode(MTLTriangleFillMode fillMode)
            => objc_msgSend(NativePtr, sel_setTriangleFillMode, (uint)fillMode);

        /// <summary>
        /// Pushes the debug group using the specified string
        /// </summary>
        /// <param name="string">The string</param>
        public void pushDebugGroup(NSString @string)
            => objc_msgSend(NativePtr, Selectors.pushDebugGroup, @string.NativePtr);

        /// <summary>
        /// Pops the debug group
        /// </summary>
        public void popDebugGroup() => objc_msgSend(NativePtr, Selectors.popDebugGroup);

        /// <summary>
        /// Inserts the debug signpost using the specified string
        /// </summary>
        /// <param name="string">The string</param>
        public void insertDebugSignpost(NSString @string)
            => objc_msgSend(NativePtr, Selectors.insertDebugSignpost, @string.NativePtr);

        /// <summary>
        /// The sel setrenderpipelinestate
        /// </summary>
        private static readonly Selector sel_setRenderPipelineState = "setRenderPipelineState:";
        /// <summary>
        /// The sel setvertexbuffer
        /// </summary>
        private static readonly Selector sel_setVertexBuffer = "setVertexBuffer:offset:atIndex:";
        /// <summary>
        /// The sel setfragmentbuffer
        /// </summary>
        private static readonly Selector sel_setFragmentBuffer = "setFragmentBuffer:offset:atIndex:";
        /// <summary>
        /// The sel setvertextexture
        /// </summary>
        private static readonly Selector sel_setVertexTexture = "setVertexTexture:atIndex:";
        /// <summary>
        /// The sel setfragmenttexture
        /// </summary>
        private static readonly Selector sel_setFragmentTexture = "setFragmentTexture:atIndex:";
        /// <summary>
        /// The sel setvertexsamplerstate
        /// </summary>
        private static readonly Selector sel_setVertexSamplerState = "setVertexSamplerState:atIndex:";
        /// <summary>
        /// The sel setfragmentsamplerstate
        /// </summary>
        private static readonly Selector sel_setFragmentSamplerState = "setFragmentSamplerState:atIndex:";
        /// <summary>
        /// The sel drawprimitives0
        /// </summary>
        private static readonly Selector sel_drawPrimitives0 = "drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:";
        /// <summary>
        /// The sel drawprimitives1
        /// </summary>
        private static readonly Selector sel_drawPrimitives1 = "drawPrimitives:indirectBuffer:indirectBufferOffset:";
        /// <summary>
        /// The sel drawprimitives2
        /// </summary>
        private static readonly Selector sel_drawPrimitives2 = "drawPrimitives:vertexStart:vertexCount:instanceCount:";
        /// <summary>
        /// The sel drawindexedprimitives0
        /// </summary>
        private static readonly Selector sel_drawIndexedPrimitives0 = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:";
        /// <summary>
        /// The sel drawindexedprimitives1
        /// </summary>
        private static readonly Selector sel_drawIndexedPrimitives1 = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:";
        /// <summary>
        /// The sel drawindexedprimitives2
        /// </summary>
        private static readonly Selector sel_drawIndexedPrimitives2 = "drawIndexedPrimitives:indexType:indexBuffer:indexBufferOffset:indirectBuffer:indirectBufferOffset:";
        /// <summary>
        /// The sel setviewport
        /// </summary>
        private static readonly Selector sel_setViewport = "setViewport:";
        /// <summary>
        /// The sel setviewports
        /// </summary>
        private static readonly Selector sel_setViewports = "setViewports:count:";
        /// <summary>
        /// The sel setscissorrect
        /// </summary>
        private static readonly Selector sel_setScissorRect = "setScissorRect:";
        /// <summary>
        /// The sel setscissorrects
        /// </summary>
        private static readonly Selector sel_setScissorRects = "setScissorRects:count:";
        /// <summary>
        /// The sel setcullmode
        /// </summary>
        private static readonly Selector sel_setCullMode = "setCullMode:";
        /// <summary>
        /// The sel setfrontfacingwinding
        /// </summary>
        private static readonly Selector sel_setFrontFacingWinding = "setFrontFacingWinding:";
        /// <summary>
        /// The sel setdepthstencilstate
        /// </summary>
        private static readonly Selector sel_setDepthStencilState = "setDepthStencilState:";
        /// <summary>
        /// The sel setdepthclipmode
        /// </summary>
        private static readonly Selector sel_setDepthClipMode = "setDepthClipMode:";
        /// <summary>
        /// The sel endencoding
        /// </summary>
        private static readonly Selector sel_endEncoding = "endEncoding";
        /// <summary>
        /// The sel setstencilreferencevalue
        /// </summary>
        private static readonly Selector sel_setStencilReferenceValue = "setStencilReferenceValue:";
        /// <summary>
        /// The sel setblendcolor
        /// </summary>
        private static readonly Selector sel_setBlendColor = "setBlendColorRed:green:blue:alpha:";
        /// <summary>
        /// The sel settrianglefillmode
        /// </summary>
        private static readonly Selector sel_setTriangleFillMode = "setTriangleFillMode:";
    }
}
