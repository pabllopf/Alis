using System;
using System.Runtime.InteropServices;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl texture
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct MTLTexture
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLTexture"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public MTLTexture(IntPtr ptr) => NativePtr = ptr;
        /// <summary>
        /// Gets the value of the is null
        /// </summary>
        public bool IsNull => NativePtr == IntPtr.Zero;

        /// <summary>
        /// Replaces the region using the specified region
        /// </summary>
        /// <param name="region">The region</param>
        /// <param name="mipmapLevel">The mipmap level</param>
        /// <param name="slice">The slice</param>
        /// <param name="pixelBytes">The pixel bytes</param>
        /// <param name="bytesPerRow">The bytes per row</param>
        /// <param name="bytesPerImage">The bytes per image</param>
        public void replaceRegion(
            MTLRegion region,
            UIntPtr mipmapLevel,
            UIntPtr slice,
            void* pixelBytes,
            UIntPtr bytesPerRow,
            UIntPtr bytesPerImage)
        {
            objc_msgSend(NativePtr, sel_replaceRegion,
                region,
                mipmapLevel,
                slice,
                (IntPtr)pixelBytes,
                bytesPerRow,
                bytesPerImage);
        }

        /// <summary>
        /// News the texture view using the specified pixel format
        /// </summary>
        /// <param name="pixelFormat">The pixel format</param>
        /// <param name="textureType">The texture type</param>
        /// <param name="levelRange">The level range</param>
        /// <param name="sliceRange">The slice range</param>
        /// <returns>The mtl texture</returns>
        public MTLTexture newTextureView(
            MTLPixelFormat pixelFormat,
            MTLTextureType textureType,
            NSRange levelRange,
            NSRange sliceRange)
        {
            IntPtr ret = IntPtr_objc_msgSend(NativePtr, sel_newTextureView,
                (uint)pixelFormat, (uint)textureType, levelRange, sliceRange);
            return new MTLTexture(ret);
        }

        /// <summary>
        /// The sel replaceregion
        /// </summary>
        private static readonly Selector sel_replaceRegion = "replaceRegion:mipmapLevel:slice:withBytes:bytesPerRow:bytesPerImage:";
        /// <summary>
        /// The sel newtextureview
        /// </summary>
        private static readonly Selector sel_newTextureView = "newTextureViewWithPixelFormat:textureType:levels:slices:";
    }
}