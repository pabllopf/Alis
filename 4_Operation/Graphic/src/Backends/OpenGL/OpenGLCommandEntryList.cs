using System;

namespace Alis.Core.Graphic.Backends.OpenGL
{
    /// <summary>
    /// The open gl command entry list interface
    /// </summary>
    internal interface OpenGLCommandEntryList
    {
        /// <summary>
        /// Gets the value of the parent
        /// </summary>
        OpenGLCommandList Parent { get; }
        /// <summary>
        /// Begins this instance
        /// </summary>
        void Begin();
        /// <summary>
        /// Clears the color target using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="clearColor">The clear color</param>
        void ClearColorTarget(uint index, RgbaFloat clearColor);
        /// <summary>
        /// Clears the depth target using the specified depth
        /// </summary>
        /// <param name="depth">The depth</param>
        /// <param name="stencil">The stencil</param>
        void ClearDepthTarget(float depth, byte stencil);
        /// <summary>
        /// Draws the vertex count
        /// </summary>
        /// <param name="vertexCount">The vertex count</param>
        /// <param name="instanceCount">The instance count</param>
        /// <param name="vertexStart">The vertex start</param>
        /// <param name="instanceStart">The instance start</param>
        void Draw(uint vertexCount, uint instanceCount, uint vertexStart, uint instanceStart);
        /// <summary>
        /// Draws the indexed using the specified index count
        /// </summary>
        /// <param name="indexCount">The index count</param>
        /// <param name="instanceCount">The instance count</param>
        /// <param name="indexStart">The index start</param>
        /// <param name="vertexOffset">The vertex offset</param>
        /// <param name="instanceStart">The instance start</param>
        void DrawIndexed(uint indexCount, uint instanceCount, uint indexStart, int vertexOffset, uint instanceStart);
        /// <summary>
        /// Draws the indirect using the specified indirect buffer
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="drawCount">The draw count</param>
        /// <param name="stride">The stride</param>
        void DrawIndirect(DeviceBuffer indirectBuffer, uint offset, uint drawCount, uint stride);
        /// <summary>
        /// Draws the indexed indirect using the specified indirect buffer
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="drawCount">The draw count</param>
        /// <param name="stride">The stride</param>
        void DrawIndexedIndirect(DeviceBuffer indirectBuffer, uint offset, uint drawCount, uint stride);
        /// <summary>
        /// Dispatches the group count x
        /// </summary>
        /// <param name="groupCountX">The group count</param>
        /// <param name="groupCountY">The group count</param>
        /// <param name="groupCountZ">The group count</param>
        void Dispatch(uint groupCountX, uint groupCountY, uint groupCountZ);
        /// <summary>
        /// Ends this instance
        /// </summary>
        void End();
        /// <summary>
        /// Sets the framebuffer using the specified fb
        /// </summary>
        /// <param name="fb">The fb</param>
        void SetFramebuffer(Framebuffer fb);
        /// <summary>
        /// Sets the index buffer using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="format">The format</param>
        /// <param name="offset">The offset</param>
        void SetIndexBuffer(DeviceBuffer buffer, IndexFormat format, uint offset);
        /// <summary>
        /// Sets the pipeline using the specified pipeline
        /// </summary>
        /// <param name="pipeline">The pipeline</param>
        void SetPipeline(Pipeline pipeline);
        /// <summary>
        /// Sets the graphics resource set using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="rs">The rs</param>
        /// <param name="dynamicOffsetCount">The dynamic offset count</param>
        /// <param name="dynamicOffsets">The dynamic offsets</param>
        void SetGraphicsResourceSet(uint slot, ResourceSet rs, uint dynamicOffsetCount, ref uint dynamicOffsets);
        /// <summary>
        /// Sets the compute resource set using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="rs">The rs</param>
        /// <param name="dynamicOffsetCount">The dynamic offset count</param>
        /// <param name="dynamicOffsets">The dynamic offsets</param>
        void SetComputeResourceSet(uint slot, ResourceSet rs, uint dynamicOffsetCount, ref uint dynamicOffsets);
        /// <summary>
        /// Sets the scissor rect using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        void SetScissorRect(uint index, uint x, uint y, uint width, uint height);
        /// <summary>
        /// Sets the vertex buffer using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        void SetVertexBuffer(uint index, DeviceBuffer buffer, uint offset);
        /// <summary>
        /// Sets the viewport using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="viewport">The viewport</param>
        void SetViewport(uint index, ref Viewport viewport);
        /// <summary>
        /// Resolves the texture using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="destination">The destination</param>
        void ResolveTexture(Texture source, Texture destination);
        /// <summary>
        /// Updates the buffer using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="bufferOffsetInBytes">The buffer offset in bytes</param>
        /// <param name="source">The source</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        void UpdateBuffer(DeviceBuffer buffer, uint bufferOffsetInBytes, IntPtr source, uint sizeInBytes);
        /// <summary>
        /// Executes the all using the specified executor
        /// </summary>
        /// <param name="executor">The executor</param>
        void ExecuteAll(OpenGLCommandExecutor executor);
        /// <summary>
        /// Dispatches the indirect using the specified indirect buffer
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        void DispatchIndirect(DeviceBuffer indirectBuffer, uint offset);
        /// <summary>
        /// Copies the buffer using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="sourceOffset">The source offset</param>
        /// <param name="destination">The destination</param>
        /// <param name="destinationOffset">The destination offset</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        void CopyBuffer(DeviceBuffer source, uint sourceOffset, DeviceBuffer destination, uint destinationOffset, uint sizeInBytes);
        /// <summary>
        /// Copies the texture using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="srcX">The src</param>
        /// <param name="srcY">The src</param>
        /// <param name="srcZ">The src</param>
        /// <param name="srcMipLevel">The src mip level</param>
        /// <param name="srcBaseArrayLayer">The src base array layer</param>
        /// <param name="destination">The destination</param>
        /// <param name="dstX">The dst</param>
        /// <param name="dstY">The dst</param>
        /// <param name="dstZ">The dst</param>
        /// <param name="dstMipLevel">The dst mip level</param>
        /// <param name="dstBaseArrayLayer">The dst base array layer</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="layerCount">The layer count</param>
        void CopyTexture(
            Texture source,
            uint srcX, uint srcY, uint srcZ,
            uint srcMipLevel,
            uint srcBaseArrayLayer,
            Texture destination,
            uint dstX, uint dstY, uint dstZ,
            uint dstMipLevel,
            uint dstBaseArrayLayer,
            uint width, uint height, uint depth,
            uint layerCount);

        /// <summary>
        /// Generates the mipmaps using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        void GenerateMipmaps(Texture texture);
        /// <summary>
        /// Pushes the debug group using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        void PushDebugGroup(string name);
        /// <summary>
        /// Pops the debug group
        /// </summary>
        void PopDebugGroup();
        /// <summary>
        /// Inserts the debug marker using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        void InsertDebugMarker(string name);

        /// <summary>
        /// Resets this instance
        /// </summary>
        void Reset();
        /// <summary>
        /// Disposes this instance
        /// </summary>
        void Dispose();
    }
}
