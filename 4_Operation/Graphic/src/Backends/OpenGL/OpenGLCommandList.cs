using System;
using System.Collections.Generic;
using System.Diagnostics;
using Alis.Core.Graphic.Backends.OpenGL.NoAllocEntryList;

namespace Alis.Core.Graphic.Backends.OpenGL
{
    /// <summary>
    /// The open gl command list class
    /// </summary>
    /// <seealso cref="CommandList"/>
    internal class OpenGLCommandList : CommandList
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly OpenGLGraphicsDevice _gd;
        /// <summary>
        /// The current commands
        /// </summary>
        private OpenGLCommandEntryList _currentCommands;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Gets the value of the current commands
        /// </summary>
        internal OpenGLCommandEntryList CurrentCommands => _currentCommands;
        /// <summary>
        /// Gets the value of the device
        /// </summary>
        internal OpenGLGraphicsDevice Device => _gd;

        /// <summary>
        /// The lock
        /// </summary>
        private readonly object _lock = new object();
        /// <summary>
        /// The open gl command entry list
        /// </summary>
        private readonly List<OpenGLCommandEntryList> _availableLists = new List<OpenGLCommandEntryList>();
        /// <summary>
        /// The open gl command entry list
        /// </summary>
        private readonly List<OpenGLCommandEntryList> _submittedLists = new List<OpenGLCommandEntryList>();

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLCommandList"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        public OpenGLCommandList(OpenGLGraphicsDevice gd, ref CommandListDescription description)
            : base(ref description, gd.Features, gd.UniformBufferMinOffsetAlignment, gd.StructuredBufferMinOffsetAlignment)
        {
            _gd = gd;
        }

        /// <summary>
        /// Begins this instance
        /// </summary>
        public override void Begin()
        {
            ClearCachedState();
            if (_currentCommands != null)
            {
                _currentCommands.Dispose();
            }

            _currentCommands = GetFreeCommandList();
            _currentCommands.Begin();
        }

        /// <summary>
        /// Gets the free command list
        /// </summary>
        /// <returns>The open gl command entry list</returns>
        private OpenGLCommandEntryList GetFreeCommandList()
        {
            lock (_lock)
            {
                if (_availableLists.Count > 0)
                {
                    OpenGLCommandEntryList ret = _availableLists[_availableLists.Count - 1];
                    _availableLists.RemoveAt(_availableLists.Count - 1);
                    return ret;
                }
                else
                {
                    return new OpenGLNoAllocCommandEntryList(this);
                }
            }
        }

        /// <summary>
        /// Clears the color target core using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="clearColor">The clear color</param>
        private protected override void ClearColorTargetCore(uint index, RgbaFloat clearColor)
        {
            _currentCommands.ClearColorTarget(index, clearColor);
        }

        /// <summary>
        /// Clears the depth stencil core using the specified depth
        /// </summary>
        /// <param name="depth">The depth</param>
        /// <param name="stencil">The stencil</param>
        private protected override void ClearDepthStencilCore(float depth, byte stencil)
        {
            _currentCommands.ClearDepthTarget(depth, stencil);
        }

        /// <summary>
        /// Draws the core using the specified vertex count
        /// </summary>
        /// <param name="vertexCount">The vertex count</param>
        /// <param name="instanceCount">The instance count</param>
        /// <param name="vertexStart">The vertex start</param>
        /// <param name="instanceStart">The instance start</param>
        private protected override void DrawCore(uint vertexCount, uint instanceCount, uint vertexStart, uint instanceStart)
        {
            _currentCommands.Draw(vertexCount, instanceCount, vertexStart, instanceStart);
        }

        /// <summary>
        /// Draws the indexed core using the specified index count
        /// </summary>
        /// <param name="indexCount">The index count</param>
        /// <param name="instanceCount">The instance count</param>
        /// <param name="indexStart">The index start</param>
        /// <param name="vertexOffset">The vertex offset</param>
        /// <param name="instanceStart">The instance start</param>
        private protected override void DrawIndexedCore(uint indexCount, uint instanceCount, uint indexStart, int vertexOffset, uint instanceStart)
        {
            _currentCommands.DrawIndexed(indexCount, instanceCount, indexStart, vertexOffset, instanceStart);
        }

        /// <summary>
        /// Draws the indirect core using the specified indirect buffer
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="drawCount">The draw count</param>
        /// <param name="stride">The stride</param>
        protected override void DrawIndirectCore(DeviceBuffer indirectBuffer, uint offset, uint drawCount, uint stride)
        {
            _currentCommands.DrawIndirect(indirectBuffer, offset, drawCount, stride);
        }

        /// <summary>
        /// Draws the indexed indirect core using the specified indirect buffer
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="drawCount">The draw count</param>
        /// <param name="stride">The stride</param>
        protected override void DrawIndexedIndirectCore(DeviceBuffer indirectBuffer, uint offset, uint drawCount, uint stride)
        {
            _currentCommands.DrawIndexedIndirect(indirectBuffer, offset, drawCount, stride);
        }

        /// <summary>
        /// Dispatches the group count x
        /// </summary>
        /// <param name="groupCountX">The group count</param>
        /// <param name="groupCountY">The group count</param>
        /// <param name="groupCountZ">The group count</param>
        public override void Dispatch(uint groupCountX, uint groupCountY, uint groupCountZ)
        {
            _currentCommands.Dispatch(groupCountX, groupCountY, groupCountZ);
        }

        /// <summary>
        /// Dispatches the indirect core using the specified indirect buffer
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="offset">The offset</param>
        protected override void DispatchIndirectCore(DeviceBuffer indirectBuffer, uint offset)
        {
            _currentCommands.DispatchIndirect(indirectBuffer, offset);
        }

        /// <summary>
        /// Resolves the texture core using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="destination">The destination</param>
        protected override void ResolveTextureCore(Texture source, Texture destination)
        {
            _currentCommands.ResolveTexture(source, destination);
        }

        /// <summary>
        /// Ends this instance
        /// </summary>
        public override void End()
        {
            _currentCommands.End();
        }

        /// <summary>
        /// Sets the framebuffer core using the specified fb
        /// </summary>
        /// <param name="fb">The fb</param>
        protected override void SetFramebufferCore(Framebuffer fb)
        {
            _currentCommands.SetFramebuffer(fb);
        }

        /// <summary>
        /// Sets the index buffer core using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="format">The format</param>
        /// <param name="offset">The offset</param>
        private protected override void SetIndexBufferCore(DeviceBuffer buffer, IndexFormat format, uint offset)
        {
            _currentCommands.SetIndexBuffer(buffer, format, offset);
        }

        /// <summary>
        /// Sets the pipeline core using the specified pipeline
        /// </summary>
        /// <param name="pipeline">The pipeline</param>
        private protected override void SetPipelineCore(Pipeline pipeline)
        {
            _currentCommands.SetPipeline(pipeline);
        }

        /// <summary>
        /// Sets the graphics resource set core using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="rs">The rs</param>
        /// <param name="dynamicOffsetCount">The dynamic offset count</param>
        /// <param name="dynamicOffsets">The dynamic offsets</param>
        protected override void SetGraphicsResourceSetCore(uint slot, ResourceSet rs, uint dynamicOffsetCount, ref uint dynamicOffsets)
        {
            _currentCommands.SetGraphicsResourceSet(slot, rs, dynamicOffsetCount, ref dynamicOffsets);
        }

        /// <summary>
        /// Sets the compute resource set core using the specified slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="rs">The rs</param>
        /// <param name="dynamicOffsetCount">The dynamic offset count</param>
        /// <param name="dynamicOffsets">The dynamic offsets</param>
        protected override void SetComputeResourceSetCore(uint slot, ResourceSet rs, uint dynamicOffsetCount, ref uint dynamicOffsets)
        {
            _currentCommands.SetComputeResourceSet(slot, rs, dynamicOffsetCount, ref dynamicOffsets);
        }

        /// <summary>
        /// Sets the scissor rect using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public override void SetScissorRect(uint index, uint x, uint y, uint width, uint height)
        {
            _currentCommands.SetScissorRect(index, x, y, width, height);
        }

        /// <summary>
        /// Sets the vertex buffer core using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        private protected override void SetVertexBufferCore(uint index, DeviceBuffer buffer, uint offset)
        {
            _currentCommands.SetVertexBuffer(index, buffer, offset);
        }

        /// <summary>
        /// Sets the viewport using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="viewport">The viewport</param>
        public override void SetViewport(uint index, ref Viewport viewport)
        {
            _currentCommands.SetViewport(index, ref viewport);
        }

        /// <summary>
        /// Resets this instance
        /// </summary>
        internal void Reset()
        {
            _currentCommands.Reset();
        }

        /// <summary>
        /// Updates the buffer core using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="bufferOffsetInBytes">The buffer offset in bytes</param>
        /// <param name="source">The source</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        private protected override void UpdateBufferCore(DeviceBuffer buffer, uint bufferOffsetInBytes, IntPtr source, uint sizeInBytes)
        {
            _currentCommands.UpdateBuffer(buffer, bufferOffsetInBytes, source, sizeInBytes);
        }

        /// <summary>
        /// Copies the buffer core using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="sourceOffset">The source offset</param>
        /// <param name="destination">The destination</param>
        /// <param name="destinationOffset">The destination offset</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        protected override void CopyBufferCore(
            DeviceBuffer source,
            uint sourceOffset,
            DeviceBuffer destination,
            uint destinationOffset,
            uint sizeInBytes)
        {
            _currentCommands.CopyBuffer(source, sourceOffset, destination, destinationOffset, sizeInBytes);
        }

        /// <summary>
        /// Copies the texture core using the specified source
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
        protected override void CopyTextureCore(
            Texture source,
            uint srcX, uint srcY, uint srcZ,
            uint srcMipLevel,
            uint srcBaseArrayLayer,
            Texture destination,
            uint dstX, uint dstY, uint dstZ,
            uint dstMipLevel,
            uint dstBaseArrayLayer,
            uint width, uint height, uint depth,
            uint layerCount)
        {
            _currentCommands.CopyTexture(
                source,
                srcX, srcY, srcZ,
                srcMipLevel,
                srcBaseArrayLayer,
                destination,
                dstX, dstY, dstZ,
                dstMipLevel,
                dstBaseArrayLayer,
                width, height, depth,
                layerCount);
        }

        /// <summary>
        /// Generates the mipmaps core using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        private protected override void GenerateMipmapsCore(Texture texture)
        {
            _currentCommands.GenerateMipmaps(texture);
        }

        /// <summary>
        /// Ons the submitted using the specified entry list
        /// </summary>
        /// <param name="entryList">The entry list</param>
        public void OnSubmitted(OpenGLCommandEntryList entryList)
        {
            _currentCommands = null;
            lock (_lock)
            {
                Debug.Assert(!_submittedLists.Contains(entryList));
                _submittedLists.Add(entryList);

                Debug.Assert(!_availableLists.Contains(entryList));
            }
        }

        /// <summary>
        /// Ons the completed using the specified entry list
        /// </summary>
        /// <param name="entryList">The entry list</param>
        public void OnCompleted(OpenGLCommandEntryList entryList)
        {
            lock (_lock)
            {
                entryList.Reset();

                Debug.Assert(!_availableLists.Contains(entryList));
                _availableLists.Add(entryList);

                Debug.Assert(_submittedLists.Contains(entryList));
                _submittedLists.Remove(entryList);
            }
        }

        /// <summary>
        /// Pushes the debug group core using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        private protected override void PushDebugGroupCore(string name)
        {
            _currentCommands.PushDebugGroup(name);
        }

        /// <summary>
        /// Pops the debug group core
        /// </summary>
        private protected override void PopDebugGroupCore()
        {
            _currentCommands.PopDebugGroup();
        }

        /// <summary>
        /// Inserts the debug marker core using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        private protected override void InsertDebugMarkerCore(string name)
        {
            _currentCommands.InsertDebugMarker(name);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            _gd.EnqueueDisposal(this);
        }

        /// <summary>
        /// Destroys the resources
        /// </summary>
        public void DestroyResources()
        {
            lock (_lock)
            {
                _currentCommands?.Dispose();
                foreach (OpenGLCommandEntryList list in _availableLists)
                {
                    list.Dispose();
                }
                foreach (OpenGLCommandEntryList list in _submittedLists)
                {
                    list.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
