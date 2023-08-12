using System;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl texture descriptor
    /// </summary>
    public struct MTLTextureDescriptor
    {
        /// <summary>
        /// The mtl texture descriptor
        /// </summary>
        private static readonly ObjCClass s_class = new ObjCClass(nameof(MTLTextureDescriptor));
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// News
        /// </summary>
        /// <returns>The mtl texture descriptor</returns>
        public static MTLTextureDescriptor New() => s_class.AllocInit<MTLTextureDescriptor>();

        /// <summary>
        /// Gets or sets the value of the texture type
        /// </summary>
        public MTLTextureType textureType
        {
            get => (MTLTextureType)uint_objc_msgSend(NativePtr, sel_textureType);
            set => objc_msgSend(NativePtr, sel_setTextureType, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the pixel format
        /// </summary>
        public MTLPixelFormat pixelFormat
        {
            get => (MTLPixelFormat)uint_objc_msgSend(NativePtr, Selectors.pixelFormat);
            set => objc_msgSend(NativePtr, Selectors.setPixelFormat, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the width
        /// </summary>
        public UIntPtr width
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_width);
            set => objc_msgSend(NativePtr, sel_setWidth, value);
        }

        /// <summary>
        /// Gets or sets the value of the height
        /// </summary>
        public UIntPtr height
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_height);
            set => objc_msgSend(NativePtr, sel_setHeight, value);
        }

        /// <summary>
        /// Gets or sets the value of the depth
        /// </summary>
        public UIntPtr depth
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_depth);
            set => objc_msgSend(NativePtr, sel_setDepth, value);
        }

        /// <summary>
        /// Gets or sets the value of the mipmap level count
        /// </summary>
        public UIntPtr mipmapLevelCount
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_mipmapLevelCount);
            set => objc_msgSend(NativePtr, sel_setMipmapLevelCount, value);
        }

        /// <summary>
        /// Gets or sets the value of the sample count
        /// </summary>
        public UIntPtr sampleCount
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_sampleCount);
            set => objc_msgSend(NativePtr, sel_setSampleCount, value);
        }

        /// <summary>
        /// Gets or sets the value of the array length
        /// </summary>
        public UIntPtr arrayLength
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_arrayLength);
            set => objc_msgSend(NativePtr, sel_setArrayLength, value);
        }

        /// <summary>
        /// Gets or sets the value of the resource options
        /// </summary>
        public MTLResourceOptions resourceOptions
        {
            get => (MTLResourceOptions)uint_objc_msgSend(NativePtr, sel_resourceOptions);
            set => objc_msgSend(NativePtr, sel_setResourceOptions, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the cpu cache mode
        /// </summary>
        public MTLCPUCacheMode cpuCacheMode
        {
            get => (MTLCPUCacheMode)uint_objc_msgSend(NativePtr, sel_cpuCacheMode);
            set => objc_msgSend(NativePtr, sel_setCpuCacheMode, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the storage mode
        /// </summary>
        public MTLStorageMode storageMode
        {
            get => (MTLStorageMode)uint_objc_msgSend(NativePtr, sel_storageMode);
            set => objc_msgSend(NativePtr, sel_setStorageMode, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the texture usage
        /// </summary>
        public MTLTextureUsage textureUsage
        {
            get => (MTLTextureUsage)uint_objc_msgSend(NativePtr, sel_textureUsage);
            set => objc_msgSend(NativePtr, sel_setTextureUsage, (uint)value);
        }

        /// <summary>
        /// The sel texturetype
        /// </summary>
        private static readonly Selector sel_textureType = "textureType";
        /// <summary>
        /// The sel settexturetype
        /// </summary>
        private static readonly Selector sel_setTextureType = "setTextureType:";
        /// <summary>
        /// The sel width
        /// </summary>
        private static readonly Selector sel_width = "width";
        /// <summary>
        /// The sel setwidth
        /// </summary>
        private static readonly Selector sel_setWidth = "setWidth:";
        /// <summary>
        /// The sel height
        /// </summary>
        private static readonly Selector sel_height = "height";
        /// <summary>
        /// The sel setheight
        /// </summary>
        private static readonly Selector sel_setHeight = "setHeight:";
        /// <summary>
        /// The sel depth
        /// </summary>
        private static readonly Selector sel_depth = "depth";
        /// <summary>
        /// The sel setdepth
        /// </summary>
        private static readonly Selector sel_setDepth = "setDepth:";
        /// <summary>
        /// The sel mipmaplevelcount
        /// </summary>
        private static readonly Selector sel_mipmapLevelCount = "mipmapLevelCount";
        /// <summary>
        /// The sel setmipmaplevelcount
        /// </summary>
        private static readonly Selector sel_setMipmapLevelCount = "setMipmapLevelCount:";
        /// <summary>
        /// The sel samplecount
        /// </summary>
        private static readonly Selector sel_sampleCount = "sampleCount";
        /// <summary>
        /// The sel setsamplecount
        /// </summary>
        private static readonly Selector sel_setSampleCount = "setSampleCount:";
        /// <summary>
        /// The sel arraylength
        /// </summary>
        private static readonly Selector sel_arrayLength = "arrayLength";
        /// <summary>
        /// The sel setarraylength
        /// </summary>
        private static readonly Selector sel_setArrayLength = "setArrayLength:";
        /// <summary>
        /// The sel resourceoptions
        /// </summary>
        private static readonly Selector sel_resourceOptions = "resourceOptions";
        /// <summary>
        /// The sel setresourceoptions
        /// </summary>
        private static readonly Selector sel_setResourceOptions = "setResourceOptions:";
        /// <summary>
        /// The sel cpucachemode
        /// </summary>
        private static readonly Selector sel_cpuCacheMode = "cpuCacheMode";
        /// <summary>
        /// The sel setcpucachemode
        /// </summary>
        private static readonly Selector sel_setCpuCacheMode = "setCpuCacheMode:";
        /// <summary>
        /// The sel storagemode
        /// </summary>
        private static readonly Selector sel_storageMode = "storageMode";
        /// <summary>
        /// The sel setstoragemode
        /// </summary>
        private static readonly Selector sel_setStorageMode = "setStorageMode:";
        /// <summary>
        /// The sel textureusage
        /// </summary>
        private static readonly Selector sel_textureUsage = "textureUsage";
        /// <summary>
        /// The sel settextureusage
        /// </summary>
        private static readonly Selector sel_setTextureUsage = "setTextureUsage:";
    }
}