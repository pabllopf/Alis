using System;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl blit command encoder
    /// </summary>
    public struct MTLBlitCommandEncoder
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
        /// Copies the source buffer
        /// </summary>
        /// <param name="sourceBuffer">The source buffer</param>
        /// <param name="sourceOffset">The source offset</param>
        /// <param name="destinationBuffer">The destination buffer</param>
        /// <param name="destinationOffset">The destination offset</param>
        /// <param name="size">The size</param>
        public void copy(
            MTLBuffer sourceBuffer,
            UIntPtr sourceOffset,
            MTLBuffer destinationBuffer,
            UIntPtr destinationOffset,
            UIntPtr size)
            => objc_msgSend(
                NativePtr,
                sel_copyFromBuffer0,
                sourceBuffer, sourceOffset, destinationBuffer, destinationOffset, size);

        /// <summary>
        /// Copies the from buffer using the specified source buffer
        /// </summary>
        /// <param name="sourceBuffer">The source buffer</param>
        /// <param name="sourceOffset">The source offset</param>
        /// <param name="sourceBytesPerRow">The source bytes per row</param>
        /// <param name="sourceBytesPerImage">The source bytes per image</param>
        /// <param name="sourceSize">The source size</param>
        /// <param name="destinationTexture">The destination texture</param>
        /// <param name="destinationSlice">The destination slice</param>
        /// <param name="destinationLevel">The destination level</param>
        /// <param name="destinationOrigin">The destination origin</param>
        public void copyFromBuffer(
            MTLBuffer sourceBuffer,
            UIntPtr sourceOffset,
            UIntPtr sourceBytesPerRow,
            UIntPtr sourceBytesPerImage,
            MTLSize sourceSize,
            MTLTexture destinationTexture,
            UIntPtr destinationSlice,
            UIntPtr destinationLevel,
            MTLOrigin destinationOrigin)
            => objc_msgSend(
                NativePtr,
                sel_copyFromBuffer1,
                sourceBuffer.NativePtr,
                sourceOffset,
                sourceBytesPerRow,
                sourceBytesPerImage,
                sourceSize,
                destinationTexture.NativePtr,
                destinationSlice,
                destinationLevel,
                destinationOrigin);

        /// <summary>
        /// Copies the texture to buffer using the specified source texture
        /// </summary>
        /// <param name="sourceTexture">The source texture</param>
        /// <param name="sourceSlice">The source slice</param>
        /// <param name="sourceLevel">The source level</param>
        /// <param name="sourceOrigin">The source origin</param>
        /// <param name="sourceSize">The source size</param>
        /// <param name="destinationBuffer">The destination buffer</param>
        /// <param name="destinationOffset">The destination offset</param>
        /// <param name="destinationBytesPerRow">The destination bytes per row</param>
        /// <param name="destinationBytesPerImage">The destination bytes per image</param>
        public void copyTextureToBuffer(
            MTLTexture sourceTexture,
            UIntPtr sourceSlice,
            UIntPtr sourceLevel,
            MTLOrigin sourceOrigin,
            MTLSize sourceSize,
            MTLBuffer destinationBuffer,
            UIntPtr destinationOffset,
            UIntPtr destinationBytesPerRow,
            UIntPtr destinationBytesPerImage)
            => objc_msgSend(NativePtr, sel_copyFromTexture0,
                sourceTexture,
                sourceSlice,
                sourceLevel,
                sourceOrigin,
                sourceSize,
                destinationBuffer,
                destinationOffset,
                destinationBytesPerRow,
                destinationBytesPerImage);

        /// <summary>
        /// Generates the mipmaps for texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        public void generateMipmapsForTexture(MTLTexture texture)
            => objc_msgSend(NativePtr, sel_generateMipmapsForTexture, texture.NativePtr);

        /// <summary>
        /// Synchronizes the resource using the specified resource
        /// </summary>
        /// <param name="resource">The resource</param>
        public void synchronizeResource(IntPtr resource) => objc_msgSend(NativePtr, sel_synchronizeResource, resource);

        /// <summary>
        /// Ends the encoding
        /// </summary>
        public void endEncoding() => objc_msgSend(NativePtr, sel_endEncoding);

        /// <summary>
        /// Pushes the debug group using the specified string
        /// </summary>
        /// <param name="@string">The string</param>
        public void pushDebugGroup(NSString @string) => objc_msgSend(NativePtr, Selectors.pushDebugGroup, @string.NativePtr);

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

        /// <summary>
        /// Copies the from texture using the specified source texture
        /// </summary>
        /// <param name="sourceTexture">The source texture</param>
        /// <param name="sourceSlice">The source slice</param>
        /// <param name="sourceLevel">The source level</param>
        /// <param name="sourceOrigin">The source origin</param>
        /// <param name="sourceSize">The source size</param>
        /// <param name="destinationTexture">The destination texture</param>
        /// <param name="destinationSlice">The destination slice</param>
        /// <param name="destinationLevel">The destination level</param>
        /// <param name="destinationOrigin">The destination origin</param>
        public void copyFromTexture(
            MTLTexture sourceTexture,
            UIntPtr sourceSlice,
            UIntPtr sourceLevel,
            MTLOrigin sourceOrigin,
            MTLSize sourceSize,
            MTLTexture destinationTexture,
            UIntPtr destinationSlice,
            UIntPtr destinationLevel,
            MTLOrigin destinationOrigin)
            => objc_msgSend(NativePtr, sel_copyFromTexture1,
                sourceTexture,
                sourceSlice,
                sourceLevel,
                sourceOrigin,
                sourceSize,
                destinationTexture,
                destinationSlice,
                destinationLevel,
                destinationOrigin);

        /// <summary>
        /// The sel copyfrombuffer0
        /// </summary>
        private static readonly Selector sel_copyFromBuffer0 = "copyFromBuffer:sourceOffset:toBuffer:destinationOffset:size:";
        /// <summary>
        /// The sel copyfrombuffer1
        /// </summary>
        private static readonly Selector sel_copyFromBuffer1 = "copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";
        /// <summary>
        /// The sel copyfromtexture0
        /// </summary>
        private static readonly Selector sel_copyFromTexture0 = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:";
        /// <summary>
        /// The sel copyfromtexture1
        /// </summary>
        private static readonly Selector sel_copyFromTexture1 = "copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";
        /// <summary>
        /// The sel generatemipmapsfortexture
        /// </summary>
        private static readonly Selector sel_generateMipmapsForTexture = "generateMipmapsForTexture:";
        /// <summary>
        /// The sel synchronizeresource
        /// </summary>
        private static readonly Selector sel_synchronizeResource = "synchronizeResource:";
        /// <summary>
        /// The sel endencoding
        /// </summary>
        private static readonly Selector sel_endEncoding = "endEncoding";
    }
}