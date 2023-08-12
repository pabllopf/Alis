using System;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl sampler descriptor
    /// </summary>
    public struct MTLSamplerDescriptor
    {
        /// <summary>
        /// The mtl sampler descriptor
        /// </summary>
        private static readonly ObjCClass s_class = new ObjCClass(nameof(MTLSamplerDescriptor));
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// News
        /// </summary>
        /// <returns>The mtl sampler descriptor</returns>
        public static MTLSamplerDescriptor New() => s_class.AllocInit<MTLSamplerDescriptor>();

        /// <summary>
        /// Gets or sets the value of the r address mode
        /// </summary>
        public MTLSamplerAddressMode rAddressMode
        {
            get => (MTLSamplerAddressMode)uint_objc_msgSend(NativePtr, sel_rAddressMode);
            set => objc_msgSend(NativePtr, sel_setRAddressMode, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the s address mode
        /// </summary>
        public MTLSamplerAddressMode sAddressMode
        {
            get => (MTLSamplerAddressMode)uint_objc_msgSend(NativePtr, sel_sAddressMode);
            set => objc_msgSend(NativePtr, sel_setSAddressMode, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the t address mode
        /// </summary>
        public MTLSamplerAddressMode tAddressMode
        {
            get => (MTLSamplerAddressMode)uint_objc_msgSend(NativePtr, sel_tAddressMode);
            set => objc_msgSend(NativePtr, sel_setTAddressMode, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the min filter
        /// </summary>
        public MTLSamplerMinMagFilter minFilter
        {
            get => (MTLSamplerMinMagFilter)uint_objc_msgSend(NativePtr, sel_minFilter);
            set => objc_msgSend(NativePtr, sel_setMinFilter, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the mag filter
        /// </summary>
        public MTLSamplerMinMagFilter magFilter
        {
            get => (MTLSamplerMinMagFilter)uint_objc_msgSend(NativePtr, sel_magFilter);
            set => objc_msgSend(NativePtr, sel_setMagFilter, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the mip filter
        /// </summary>
        public MTLSamplerMipFilter mipFilter
        {
            get => (MTLSamplerMipFilter)uint_objc_msgSend(NativePtr, sel_mipFilter);
            set => objc_msgSend(NativePtr, sel_setMipFilter, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the lod min clamp
        /// </summary>
        public float lodMinClamp
        {
            get => float_objc_msgSend(NativePtr, sel_lodMinClamp);
            set => objc_msgSend(NativePtr, sel_setLodMinClamp, value);
        }

        /// <summary>
        /// Gets or sets the value of the lod max clamp
        /// </summary>
        public float lodMaxClamp
        {
            get => float_objc_msgSend(NativePtr, sel_lodMaxClamp);
            set => objc_msgSend(NativePtr, sel_setLodMaxClamp, value);
        }

        /// <summary>
        /// Gets or sets the value of the lod average
        /// </summary>
        public Bool8 lodAverage
        {
            get => bool8_objc_msgSend(NativePtr, sel_lodAverage);
            set => objc_msgSend(NativePtr, sel_setLodAverage, value);
        }

        /// <summary>
        /// Gets or sets the value of the max anisotropy
        /// </summary>
        public UIntPtr maxAnisotropy
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_maxAnisotropy);
            set => objc_msgSend(NativePtr, sel_setMaAnisotropy, value);
        }

        /// <summary>
        /// Gets or sets the value of the compare function
        /// </summary>
        public MTLCompareFunction compareFunction
        {
            get => (MTLCompareFunction)uint_objc_msgSend(NativePtr, sel_compareFunction);
            set => objc_msgSend(NativePtr, sel_setCompareFunction, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the border color
        /// </summary>
        public MTLSamplerBorderColor borderColor
        {
            get => (MTLSamplerBorderColor)uint_objc_msgSend(NativePtr, sel_borderColor);
            set => objc_msgSend(NativePtr, sel_setBorderColor, (uint)value);
        }

        /// <summary>
        /// The sel raddressmode
        /// </summary>
        private static readonly Selector sel_rAddressMode = "rAddressMode";
        /// <summary>
        /// The sel setraddressmode
        /// </summary>
        private static readonly Selector sel_setRAddressMode = "setRAddressMode:";
        /// <summary>
        /// The sel saddressmode
        /// </summary>
        private static readonly Selector sel_sAddressMode = "sAddressMode";
        /// <summary>
        /// The sel setsaddressmode
        /// </summary>
        private static readonly Selector sel_setSAddressMode = "setSAddressMode:";
        /// <summary>
        /// The sel taddressmode
        /// </summary>
        private static readonly Selector sel_tAddressMode = "tAddressMode";
        /// <summary>
        /// The sel settaddressmode
        /// </summary>
        private static readonly Selector sel_setTAddressMode = "setTAddressMode:";
        /// <summary>
        /// The sel minfilter
        /// </summary>
        private static readonly Selector sel_minFilter = "minFilter";
        /// <summary>
        /// The sel setminfilter
        /// </summary>
        private static readonly Selector sel_setMinFilter = "setMinFilter:";
        /// <summary>
        /// The sel magfilter
        /// </summary>
        private static readonly Selector sel_magFilter = "magFilter";
        /// <summary>
        /// The sel setmagfilter
        /// </summary>
        private static readonly Selector sel_setMagFilter = "setMagFilter:";
        /// <summary>
        /// The sel mipfilter
        /// </summary>
        private static readonly Selector sel_mipFilter = "mipFilter";
        /// <summary>
        /// The sel setmipfilter
        /// </summary>
        private static readonly Selector sel_setMipFilter = "setMipFilter:";
        /// <summary>
        /// The sel lodminclamp
        /// </summary>
        private static readonly Selector sel_lodMinClamp = "lodMinClamp";
        /// <summary>
        /// The sel setlodminclamp
        /// </summary>
        private static readonly Selector sel_setLodMinClamp = "setLodMinClamp:";
        /// <summary>
        /// The sel lodmaxclamp
        /// </summary>
        private static readonly Selector sel_lodMaxClamp = "lodMaxClamp";
        /// <summary>
        /// The sel setlodmaxclamp
        /// </summary>
        private static readonly Selector sel_setLodMaxClamp = "setLodMaxClamp:";
        /// <summary>
        /// The sel lodaverage
        /// </summary>
        private static readonly Selector sel_lodAverage = "lodAverage";
        /// <summary>
        /// The sel setlodaverage
        /// </summary>
        private static readonly Selector sel_setLodAverage = "setLodAverage:";
        /// <summary>
        /// The sel maxanisotropy
        /// </summary>
        private static readonly Selector sel_maxAnisotropy = "maxAnisotropy";
        /// <summary>
        /// The sel setmaanisotropy
        /// </summary>
        private static readonly Selector sel_setMaAnisotropy = "setMaxAnisotropy:";
        /// <summary>
        /// The sel comparefunction
        /// </summary>
        private static readonly Selector sel_compareFunction = "compareFunction";
        /// <summary>
        /// The sel setcomparefunction
        /// </summary>
        private static readonly Selector sel_setCompareFunction = "setCompareFunction:";
        /// <summary>
        /// The sel bordercolor
        /// </summary>
        private static readonly Selector sel_borderColor = "borderColor";
        /// <summary>
        /// The sel setbordercolor
        /// </summary>
        private static readonly Selector sel_setBorderColor = "setBorderColor:";
    }
}