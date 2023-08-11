using System;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl compute command encoder
    /// </summary>
    public struct MTLComputeCommandEncoder
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// Gets the value of the is null
        /// </summary>
        public bool IsNull => NativePtr == IntPtr.Zero;

        /// <summary>
        /// The sel setcomputepipelinestate
        /// </summary>
        private static readonly Selector sel_setComputePipelineState = "setComputePipelineState:";
        /// <summary>
        /// The sel setbuffer
        /// </summary>
        private static readonly Selector sel_setBuffer = "setBuffer:offset:atIndex:";
        /// <summary>
        /// The sel dispatchthreadgroups0
        /// </summary>
        private static readonly Selector sel_dispatchThreadgroups0 = "dispatchThreadgroups:threadsPerThreadgroup:";
        /// <summary>
        /// The sel dispatchthreadgroups1
        /// </summary>
        private static readonly Selector sel_dispatchThreadgroups1 = "dispatchThreadgroupsWithIndirectBuffer:indirectBufferOffset:threadsPerThreadgroup:";
        /// <summary>
        /// The sel endencoding
        /// </summary>
        private static readonly Selector sel_endEncoding = "endEncoding";
        /// <summary>
        /// The sel settexture
        /// </summary>
        private static readonly Selector sel_setTexture = "setTexture:atIndex:";
        /// <summary>
        /// The sel setsamplerstate
        /// </summary>
        private static readonly Selector sel_setSamplerState = "setSamplerState:atIndex:";
        /// <summary>
        /// The sel setbytes
        /// </summary>
        private static readonly Selector sel_setBytes = "setBytes:length:atIndex:";

        /// <summary>
        /// Sets the compute pipeline state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        public void setComputePipelineState(MTLComputePipelineState state)
            => objc_msgSend(NativePtr, sel_setComputePipelineState, state.NativePtr);

        /// <summary>
        /// Sets the buffer using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="index">The index</param>
        public void setBuffer(MTLBuffer buffer, UIntPtr offset, UIntPtr index)
            => objc_msgSend(NativePtr, sel_setBuffer,
                buffer.NativePtr,
                offset,
                index);

        /// <summary>
        /// Sets the bytes using the specified bytes
        /// </summary>
        /// <param name="bytes">The bytes</param>
        /// <param name="length">The length</param>
        /// <param name="index">The index</param>
        public unsafe void setBytes(void* bytes, UIntPtr length, UIntPtr index)
            => objc_msgSend(NativePtr, sel_setBytes, bytes, length, index);

        /// <summary>
        /// Dispatches the thread groups using the specified threadgroups per grid
        /// </summary>
        /// <param name="threadgroupsPerGrid">The threadgroups per grid</param>
        /// <param name="threadsPerThreadgroup">The threads per threadgroup</param>
        public void dispatchThreadGroups(MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup)
            => objc_msgSend(NativePtr, sel_dispatchThreadgroups0, threadgroupsPerGrid, threadsPerThreadgroup);

        /// <summary>
        /// Dispatches the threadgroups with indirect buffer using the specified indirect buffer
        /// </summary>
        /// <param name="indirectBuffer">The indirect buffer</param>
        /// <param name="indirectBufferOffset">The indirect buffer offset</param>
        /// <param name="threadsPerThreadgroup">The threads per threadgroup</param>
        public void dispatchThreadgroupsWithIndirectBuffer(
            MTLBuffer indirectBuffer,
            UIntPtr indirectBufferOffset,
            MTLSize threadsPerThreadgroup)
            => objc_msgSend(NativePtr, sel_dispatchThreadgroups1,
                indirectBuffer.NativePtr,
                indirectBufferOffset,
                threadsPerThreadgroup);

        /// <summary>
        /// Ends the encoding
        /// </summary>
        public void endEncoding() => objc_msgSend(NativePtr, sel_endEncoding);

        /// <summary>
        /// Sets the texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="index">The index</param>
        public void setTexture(MTLTexture texture, UIntPtr index)
            => objc_msgSend(NativePtr, sel_setTexture, texture.NativePtr, index);

        /// <summary>
        /// Sets the sampler state using the specified sampler
        /// </summary>
        /// <param name="sampler">The sampler</param>
        /// <param name="index">The index</param>
        public void setSamplerState(MTLSamplerState sampler, UIntPtr index)
            => objc_msgSend(NativePtr, sel_setSamplerState, sampler.NativePtr, index);

        /// <summary>
        /// Pushes the debug group using the specified string
        /// </summary>
        /// <param name="@string">The string</param>
        public void pushDebugGroup(NSString @string)
            => objc_msgSend(NativePtr, Selectors.pushDebugGroup, @string.NativePtr);

        /// <summary>
        /// Pops the debug group
        /// </summary>
        public void popDebugGroup() => objc_msgSend(NativePtr, Selectors.popDebugGroup);

        /// <summary>
        /// Inserts the debug signpost using the specified string
        /// </summary>
        /// <param name="@string">The string</param>
        public void insertDebugSignpost(NSString @string)
            => objc_msgSend(NativePtr, Selectors.insertDebugSignpost, @string.NativePtr);
    }
}
