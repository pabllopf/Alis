using System;
using Veldrid.MetalBindings;

namespace Veldrid.MTL
{
    /// <summary>
    /// The mtl formats class
    /// </summary>
    internal static class MTLFormats
    {
        /// <summary>
        /// Vds the to mtl pixel format using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="depthFormat">The depth format</param>
        /// <returns>The mtl pixel format</returns>
        internal static MTLPixelFormat VdToMTLPixelFormat(PixelFormat format, bool depthFormat)
        {
            switch (format)
            {
                case PixelFormat.R8_UNorm:
                    return MTLPixelFormat.R8Unorm;
                case PixelFormat.R8_SNorm:
                    return MTLPixelFormat.R8Snorm;
                case PixelFormat.R8_UInt:
                    return MTLPixelFormat.R8Uint;
                case PixelFormat.R8_SInt:
                    return MTLPixelFormat.R8Sint;

                case PixelFormat.R16_UNorm:
                    return depthFormat ? MTLPixelFormat.Depth16Unorm : MTLPixelFormat.R16Unorm;
                case PixelFormat.R16_SNorm:
                    return MTLPixelFormat.R16Snorm;
                case PixelFormat.R16_UInt:
                    return MTLPixelFormat.R16Uint;
                case PixelFormat.R16_SInt:
                    return MTLPixelFormat.R16Sint;
                case PixelFormat.R16_Float:
                    return MTLPixelFormat.R16Float;

                case PixelFormat.R32_UInt:
                    return MTLPixelFormat.R32Uint;
                case PixelFormat.R32_SInt:
                    return MTLPixelFormat.R32Sint;
                case PixelFormat.R32_Float:
                    return depthFormat ? MTLPixelFormat.Depth32Float : MTLPixelFormat.R32Float;

                case PixelFormat.R8_G8_UNorm:
                    return MTLPixelFormat.RG8Unorm;
                case PixelFormat.R8_G8_SNorm:
                    return MTLPixelFormat.RG8Snorm;
                case PixelFormat.R8_G8_UInt:
                    return MTLPixelFormat.RG8Uint;
                case PixelFormat.R8_G8_SInt:
                    return MTLPixelFormat.RG8Sint;

                case PixelFormat.R16_G16_UNorm:
                    return MTLPixelFormat.RG16Unorm;
                case PixelFormat.R16_G16_SNorm:
                    return MTLPixelFormat.RG16Snorm;
                case PixelFormat.R16_G16_UInt:
                    return MTLPixelFormat.RG16Uint;
                case PixelFormat.R16_G16_SInt:
                    return MTLPixelFormat.RG16Sint;
                case PixelFormat.R16_G16_Float:
                    return MTLPixelFormat.RG16Float;

                case PixelFormat.R32_G32_UInt:
                    return MTLPixelFormat.RG32Uint;
                case PixelFormat.R32_G32_SInt:
                    return MTLPixelFormat.RG32Sint;
                case PixelFormat.R32_G32_Float:
                    return MTLPixelFormat.RG32Float;

                case PixelFormat.R8_G8_B8_A8_UNorm:
                    return MTLPixelFormat.RGBA8Unorm;
                case PixelFormat.R8_G8_B8_A8_UNorm_SRgb:
                    return MTLPixelFormat.RGBA8Unorm_sRGB;
                case PixelFormat.B8_G8_R8_A8_UNorm:
                    return MTLPixelFormat.BGRA8Unorm;
                case PixelFormat.B8_G8_R8_A8_UNorm_SRgb:
                    return MTLPixelFormat.BGRA8Unorm_sRGB;
                case PixelFormat.R8_G8_B8_A8_SNorm:
                    return MTLPixelFormat.RGBA8Snorm;
                case PixelFormat.R8_G8_B8_A8_UInt:
                    return MTLPixelFormat.RGBA8Uint;
                case PixelFormat.R8_G8_B8_A8_SInt:
                    return MTLPixelFormat.RGBA8Sint;

                case PixelFormat.R16_G16_B16_A16_UNorm:
                    return MTLPixelFormat.RGBA16Unorm;
                case PixelFormat.R16_G16_B16_A16_SNorm:
                    return MTLPixelFormat.RGBA16Snorm;
                case PixelFormat.R16_G16_B16_A16_UInt:
                    return MTLPixelFormat.RGBA16Uint;
                case PixelFormat.R16_G16_B16_A16_SInt:
                    return MTLPixelFormat.RGBA16Sint;
                case PixelFormat.R16_G16_B16_A16_Float:
                    return MTLPixelFormat.RGBA16Float;

                case PixelFormat.R32_G32_B32_A32_UInt:
                    return MTLPixelFormat.RGBA32Uint;
                case PixelFormat.R32_G32_B32_A32_SInt:
                    return MTLPixelFormat.RGBA32Sint;
                case PixelFormat.R32_G32_B32_A32_Float:
                    return MTLPixelFormat.RGBA32Float;

                case PixelFormat.BC1_Rgb_UNorm:
                case PixelFormat.BC1_Rgba_UNorm:
                    return MTLPixelFormat.BC1_RGBA;
                case PixelFormat.BC1_Rgb_UNorm_SRgb:
                case PixelFormat.BC1_Rgba_UNorm_SRgb:
                    return MTLPixelFormat.BC1_RGBA_sRGB;
                case PixelFormat.BC2_UNorm:
                    return MTLPixelFormat.BC2_RGBA;
                case PixelFormat.BC2_UNorm_SRgb:
                    return MTLPixelFormat.BC2_RGBA_sRGB;
                case PixelFormat.BC3_UNorm:
                    return MTLPixelFormat.BC3_RGBA;
                case PixelFormat.BC3_UNorm_SRgb:
                    return MTLPixelFormat.BC3_RGBA_sRGB;
                case PixelFormat.BC4_UNorm:
                    return MTLPixelFormat.BC4_RUnorm;
                case PixelFormat.BC4_SNorm:
                    return MTLPixelFormat.BC4_RSnorm;
                case PixelFormat.BC5_UNorm:
                    return MTLPixelFormat.BC5_RGUnorm;
                case PixelFormat.BC5_SNorm:
                    return MTLPixelFormat.BC5_RGSnorm;
                case PixelFormat.BC7_UNorm:
                    return MTLPixelFormat.BC7_RGBAUnorm;
                case PixelFormat.BC7_UNorm_SRgb:
                    return MTLPixelFormat.BC7_RGBAUnorm_sRGB;

                case PixelFormat.ETC2_R8_G8_B8_UNorm:
                    return MTLPixelFormat.ETC2_RGB8;
                case PixelFormat.ETC2_R8_G8_B8_A1_UNorm:
                    return MTLPixelFormat.ETC2_RGB8A1;
                case PixelFormat.ETC2_R8_G8_B8_A8_UNorm:
                    return MTLPixelFormat.EAC_RGBA8;

                case PixelFormat.D24_UNorm_S8_UInt:
                    return MTLPixelFormat.Depth24Unorm_Stencil8;
                case PixelFormat.D32_Float_S8_UInt:
                    return MTLPixelFormat.Depth32Float_Stencil8;

                case PixelFormat.R10_G10_B10_A2_UNorm:
                    return MTLPixelFormat.RGB10A2Unorm;
                case PixelFormat.R10_G10_B10_A2_UInt:
                    return MTLPixelFormat.RGB10A2Uint;
                case PixelFormat.R11_G11_B10_Float:
                    return MTLPixelFormat.RG11B10Float;

                default:
                    throw Illegal.Value<PixelFormat>();
            }
        }

        /// <summary>
        /// Describes whether is format supported
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="usage">The usage</param>
        /// <param name="metalFeatures">The metal features</param>
        /// <returns>The bool</returns>
        internal static bool IsFormatSupported(PixelFormat format, TextureUsage usage, MTLFeatureSupport metalFeatures)
        {
            switch (format)
            {
                case PixelFormat.BC1_Rgb_UNorm:
                case PixelFormat.BC1_Rgb_UNorm_SRgb:
                case PixelFormat.BC1_Rgba_UNorm:
                case PixelFormat.BC1_Rgba_UNorm_SRgb:
                case PixelFormat.BC2_UNorm:
                case PixelFormat.BC2_UNorm_SRgb:
                case PixelFormat.BC3_UNorm:
                case PixelFormat.BC3_UNorm_SRgb:
                case PixelFormat.BC4_UNorm:
                case PixelFormat.BC4_SNorm:
                case PixelFormat.BC5_UNorm:
                case PixelFormat.BC5_SNorm:
                case PixelFormat.BC7_UNorm:
                case PixelFormat.BC7_UNorm_SRgb:
                    return metalFeatures.IsSupported(MTLFeatureSet.macOS_GPUFamily1_v1)
                        || metalFeatures.IsSupported(MTLFeatureSet.macOS_GPUFamily1_v2)
                        || metalFeatures.IsSupported(MTLFeatureSet.macOS_GPUFamily1_v3);

                case PixelFormat.ETC2_R8_G8_B8_UNorm:
                case PixelFormat.ETC2_R8_G8_B8_A1_UNorm:
                case PixelFormat.ETC2_R8_G8_B8_A8_UNorm:
                    return metalFeatures.IsSupported(MTLFeatureSet.iOS_GPUFamily1_v1)
                        || metalFeatures.IsSupported(MTLFeatureSet.iOS_GPUFamily2_v1)
                        || metalFeatures.IsSupported(MTLFeatureSet.iOS_GPUFamily3_v1)
                        || metalFeatures.IsSupported(MTLFeatureSet.iOS_GPUFamily4_v1);

                case PixelFormat.R16_UNorm:
                    return ((usage & TextureUsage.DepthStencil) == 0)
                        || metalFeatures.IsSupported(MTLFeatureSet.macOS_GPUFamily1_v2)
                        || metalFeatures.IsSupported(MTLFeatureSet.macOS_GPUFamily1_v3);

                default:
                    return true;
            }
        }

        /// <summary>
        /// Vds the to mtl fill mode using the specified fill mode
        /// </summary>
        /// <param name="fillMode">The fill mode</param>
        /// <returns>The mtl triangle fill mode</returns>
        internal static MTLTriangleFillMode VdToMTLFillMode(PolygonFillMode fillMode)
        {
            switch (fillMode)
            {
                case PolygonFillMode.Solid:
                    return MTLTriangleFillMode.Fill;
                case PolygonFillMode.Wireframe:
                    return MTLTriangleFillMode.Lines;
                default:
                    throw Illegal.Value<PolygonFillMode>();
            }
        }

        /// <summary>
        /// Vds the vo mtl front face using the specified front face
        /// </summary>
        /// <param name="frontFace">The front face</param>
        /// <returns>The mtl winding</returns>
        internal static MTLWinding VdVoMTLFrontFace(FrontFace frontFace)
        {
            return frontFace == FrontFace.CounterClockwise ? MTLWinding.CounterClockwise : MTLWinding.Clockwise;
        }

        /// <summary>
        /// Gets the min mag mip filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="min">The min</param>
        /// <param name="mag">The mag</param>
        /// <param name="mip">The mip</param>
        internal static void GetMinMagMipFilter(
            SamplerFilter filter,
            out MTLSamplerMinMagFilter min,
            out MTLSamplerMinMagFilter mag,
            out MTLSamplerMipFilter mip)
        {
            switch (filter)
            {
                case SamplerFilter.Anisotropic:
                    min = mag = MTLSamplerMinMagFilter.Linear;
                    mip = MTLSamplerMipFilter.Linear;
                    break;
                case SamplerFilter.MinLinear_MagLinear_MipLinear:
                    min = MTLSamplerMinMagFilter.Linear;
                    mag = MTLSamplerMinMagFilter.Linear;
                    mip = MTLSamplerMipFilter.Linear;
                    break;
                case SamplerFilter.MinLinear_MagLinear_MipPoint:
                    min = MTLSamplerMinMagFilter.Linear;
                    mag = MTLSamplerMinMagFilter.Linear;
                    mip = MTLSamplerMipFilter.Nearest;
                    break;
                case SamplerFilter.MinLinear_MagPoint_MipLinear:
                    min = MTLSamplerMinMagFilter.Linear;
                    mag = MTLSamplerMinMagFilter.Nearest;
                    mip = MTLSamplerMipFilter.Linear;
                    break;
                case SamplerFilter.MinLinear_MagPoint_MipPoint:
                    min = MTLSamplerMinMagFilter.Linear;
                    mag = MTLSamplerMinMagFilter.Nearest;
                    mip = MTLSamplerMipFilter.Nearest;
                    break;
                case SamplerFilter.MinPoint_MagLinear_MipLinear:
                    min = MTLSamplerMinMagFilter.Nearest;
                    mag = MTLSamplerMinMagFilter.Linear;
                    mip = MTLSamplerMipFilter.Linear;
                    break;
                case SamplerFilter.MinPoint_MagLinear_MipPoint:
                    min = MTLSamplerMinMagFilter.Nearest;
                    mag = MTLSamplerMinMagFilter.Linear;
                    mip = MTLSamplerMipFilter.Nearest;
                    break;
                case SamplerFilter.MinPoint_MagPoint_MipLinear:
                    min = MTLSamplerMinMagFilter.Nearest;
                    mag = MTLSamplerMinMagFilter.Nearest;
                    mip = MTLSamplerMipFilter.Nearest;
                    break;
                case SamplerFilter.MinPoint_MagPoint_MipPoint:
                    min = MTLSamplerMinMagFilter.Nearest;
                    mag = MTLSamplerMinMagFilter.Nearest;
                    mip = MTLSamplerMipFilter.Nearest;
                    break;
                default:
                    throw Illegal.Value<SamplerFilter>();
            }
        }

        /// <summary>
        /// Vds the to mtl texture type using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="arrayLayers">The array layers</param>
        /// <param name="multiSampled">The multi sampled</param>
        /// <param name="cube">The cube</param>
        /// <returns>The mtl texture type</returns>
        internal static MTLTextureType VdToMTLTextureType(
            TextureType type,
            uint arrayLayers,
            bool multiSampled,
            bool cube)
        {
            switch (type)
            {
                case TextureType.Texture1D:
                    return arrayLayers > 1 ? MTLTextureType.Type1DArray : MTLTextureType.Type1D;
                case TextureType.Texture2D:
                    if (cube)
                    {
                        return arrayLayers > 1 ? MTLTextureType.TypeCubeArray : MTLTextureType.TypeCube;
                    }
                    else if (multiSampled)
                    {
                        return MTLTextureType.Type2DMultisample;
                    }
                    else
                    {
                        return arrayLayers > 1 ? MTLTextureType.Type2DArray : MTLTextureType.Type2D;
                    }
                case TextureType.Texture3D:
                    return MTLTextureType.Type3D;
                default:
                    throw Illegal.Value<TextureType>();
            }
        }

        /// <summary>
        /// Vds the to mtl blend factor using the specified vd factor
        /// </summary>
        /// <param name="vdFactor">The vd factor</param>
        /// <returns>The mtl blend factor</returns>
        internal static MTLBlendFactor VdToMTLBlendFactor(BlendFactor vdFactor)
        {
            switch (vdFactor)
            {
                case BlendFactor.Zero:
                    return MTLBlendFactor.Zero;
                case BlendFactor.One:
                    return MTLBlendFactor.One;
                case BlendFactor.SourceAlpha:
                    return MTLBlendFactor.SourceAlpha;
                case BlendFactor.InverseSourceAlpha:
                    return MTLBlendFactor.OneMinusSourceAlpha;
                case BlendFactor.DestinationAlpha:
                    return MTLBlendFactor.DestinationAlpha;
                case BlendFactor.InverseDestinationAlpha:
                    return MTLBlendFactor.OneMinusDestinationAlpha;
                case BlendFactor.SourceColor:
                    return MTLBlendFactor.SourceColor;
                case BlendFactor.InverseSourceColor:
                    return MTLBlendFactor.OneMinusSourceColor;
                case BlendFactor.DestinationColor:
                    return MTLBlendFactor.DestinationColor;
                case BlendFactor.InverseDestinationColor:
                    return MTLBlendFactor.OneMinusDestinationColor;
                case BlendFactor.BlendFactor:
                    return MTLBlendFactor.BlendColor;
                case BlendFactor.InverseBlendFactor:
                    return MTLBlendFactor.OneMinusBlendColor;
                default:
                    throw Illegal.Value<BlendFactor>();
            }
        }

        /// <summary>
        /// Vds the to mtl blend op using the specified vd function
        /// </summary>
        /// <param name="vdFunction">The vd function</param>
        /// <returns>The mtl blend operation</returns>
        internal static MTLBlendOperation VdToMTLBlendOp(BlendFunction vdFunction)
        {
            switch (vdFunction)
            {
                case BlendFunction.Add:
                    return MTLBlendOperation.Add;
                case BlendFunction.Maximum:
                    return MTLBlendOperation.Max;
                case BlendFunction.Minimum:
                    return MTLBlendOperation.Min;
                case BlendFunction.ReverseSubtract:
                    return MTLBlendOperation.ReverseSubtract;
                case BlendFunction.Subtract:
                    return MTLBlendOperation.Subtract;
                default:
                    throw Illegal.Value<BlendFunction>();
            }
        }

        /// <summary>
        /// Vds the to mtl color write mask using the specified vd mask
        /// </summary>
        /// <param name="vdMask">The vd mask</param>
        /// <returns>The mask</returns>
        internal static MTLColorWriteMask VdToMTLColorWriteMask(ColorWriteMask vdMask)
        {
            MTLColorWriteMask mask = MTLColorWriteMask.None;

            if ((vdMask & ColorWriteMask.Red) == ColorWriteMask.Red)
                mask |= MTLColorWriteMask.Red;
            if ((vdMask & ColorWriteMask.Green) == ColorWriteMask.Green)
                mask |= MTLColorWriteMask.Green;
            if ((vdMask & ColorWriteMask.Blue) == ColorWriteMask.Blue)
                mask |= MTLColorWriteMask.Blue;
            if ((vdMask & ColorWriteMask.Alpha) == ColorWriteMask.Alpha)
                mask |= MTLColorWriteMask.Alpha;

            return mask;
        }

        /// <summary>
        /// Vds the vo mtl shader constant type using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <exception cref="VeldridException">Metal does not support 64-bit shader constants.</exception>
        /// <returns>The mtl data type</returns>
        internal static MTLDataType VdVoMTLShaderConstantType(ShaderConstantType type)
        {
            switch (type)
            {
                case ShaderConstantType.Bool:
                    return MTLDataType.Bool;
                case ShaderConstantType.UInt16:
                    return MTLDataType.UShort;
                case ShaderConstantType.Int16:
                    return MTLDataType.Short;
                case ShaderConstantType.UInt32:
                    return MTLDataType.UInt;
                case ShaderConstantType.Int32:
                    return MTLDataType.Int;
                case ShaderConstantType.Float:
                    return MTLDataType.Float;
                case ShaderConstantType.UInt64:
                case ShaderConstantType.Int64:
                case ShaderConstantType.Double:
                    throw new VeldridException($"Metal does not support 64-bit shader constants.");
                default:
                    throw Illegal.Value<ShaderConstantType>();
            }
        }

        /// <summary>
        /// Vds the to mtl compare function using the specified comparison kind
        /// </summary>
        /// <param name="comparisonKind">The comparison kind</param>
        /// <returns>The mtl compare function</returns>
        internal static MTLCompareFunction VdToMTLCompareFunction(ComparisonKind comparisonKind)
        {
            switch (comparisonKind)
            {
                case ComparisonKind.Always:
                    return MTLCompareFunction.Always;
                case ComparisonKind.Equal:
                    return MTLCompareFunction.Equal;
                case ComparisonKind.Greater:
                    return MTLCompareFunction.Greater;
                case ComparisonKind.GreaterEqual:
                    return MTLCompareFunction.GreaterEqual;
                case ComparisonKind.Less:
                    return MTLCompareFunction.Less;
                case ComparisonKind.LessEqual:
                    return MTLCompareFunction.LessEqual;
                case ComparisonKind.Never:
                    return MTLCompareFunction.Never;
                case ComparisonKind.NotEqual:
                    return MTLCompareFunction.NotEqual;
                default:
                    throw Illegal.Value<ComparisonKind>();
            }
        }

        /// <summary>
        /// Vds the to mtl cull mode using the specified cull mode
        /// </summary>
        /// <param name="cullMode">The cull mode</param>
        /// <returns>The mtl cull mode</returns>
        internal static MTLCullMode VdToMTLCullMode(FaceCullMode cullMode)
        {
            switch (cullMode)
            {
                case FaceCullMode.Front:
                    return MTLCullMode.Front;
                case FaceCullMode.Back:
                    return MTLCullMode.Back;
                case FaceCullMode.None:
                    return MTLCullMode.None;
                default:
                    throw Illegal.Value<FaceCullMode>();
            }
        }

        /// <summary>
        /// Vds the to mtl border color using the specified border color
        /// </summary>
        /// <param name="borderColor">The border color</param>
        /// <returns>The mtl sampler border color</returns>
        internal static MTLSamplerBorderColor VdToMTLBorderColor(SamplerBorderColor borderColor)
        {
            switch (borderColor)
            {
                case SamplerBorderColor.TransparentBlack:
                    return MTLSamplerBorderColor.TransparentBlack;
                case SamplerBorderColor.OpaqueBlack:
                    return MTLSamplerBorderColor.OpaqueBlack;
                case SamplerBorderColor.OpaqueWhite:
                    return MTLSamplerBorderColor.OpaqueWhite;
                default:
                    throw Illegal.Value<SamplerBorderColor>();
            }
        }

        /// <summary>
        /// Vds the to mtl address mode using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <returns>The mtl sampler address mode</returns>
        internal static MTLSamplerAddressMode VdToMTLAddressMode(SamplerAddressMode mode)
        {
            switch (mode)
            {
                case SamplerAddressMode.Border:
                    return MTLSamplerAddressMode.ClampToBorderColor;
                case SamplerAddressMode.Clamp:
                    return MTLSamplerAddressMode.ClampToEdge;
                case SamplerAddressMode.Mirror:
                    return MTLSamplerAddressMode.MirrorRepeat;
                case SamplerAddressMode.Wrap:
                    return MTLSamplerAddressMode.Repeat;
                default:
                    throw Illegal.Value<SamplerAddressMode>();
            }
        }

        /// <summary>
        /// Vds the to mtl primitive topology using the specified primitive topology
        /// </summary>
        /// <param name="primitiveTopology">The primitive topology</param>
        /// <returns>The mtl primitive type</returns>
        internal static MTLPrimitiveType VdToMTLPrimitiveTopology(PrimitiveTopology primitiveTopology)
        {
            switch (primitiveTopology)
            {
                case PrimitiveTopology.LineList:
                    return MTLPrimitiveType.Line;
                case PrimitiveTopology.LineStrip:
                    return MTLPrimitiveType.LineStrip;
                case PrimitiveTopology.TriangleList:
                    return MTLPrimitiveType.Triangle;
                case PrimitiveTopology.TriangleStrip:
                    return MTLPrimitiveType.TriangleStrip;
                case PrimitiveTopology.PointList:
                    return MTLPrimitiveType.Point;
                default:
                    throw Illegal.Value<PrimitiveTopology>();
            }
        }

        /// <summary>
        /// Vds the to mtl texture usage using the specified usage
        /// </summary>
        /// <param name="usage">The usage</param>
        /// <returns>The ret</returns>
        internal static MTLTextureUsage VdToMTLTextureUsage(TextureUsage usage)
        {
            MTLTextureUsage ret = MTLTextureUsage.Unknown;

            if ((usage & TextureUsage.Sampled) == TextureUsage.Sampled)
            {
                ret |= MTLTextureUsage.ShaderRead;
            }
            if ((usage & TextureUsage.Storage) == TextureUsage.Storage)
            {
                ret |= MTLTextureUsage.ShaderWrite;
            }
            if ((usage & TextureUsage.DepthStencil) == TextureUsage.DepthStencil
                || (usage & TextureUsage.RenderTarget) == TextureUsage.RenderTarget)
            {
                ret |= MTLTextureUsage.RenderTarget;
            }

            return ret;
        }

        /// <summary>
        /// Vds the to mtl vertex format using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The mtl vertex format</returns>
        internal static MTLVertexFormat VdToMTLVertexFormat(VertexElementFormat format)
        {
            switch (format)
            {
                case VertexElementFormat.Byte2_Norm:
                    return MTLVertexFormat.uchar2Normalized;
                case VertexElementFormat.Byte2:
                    return MTLVertexFormat.uchar2;
                case VertexElementFormat.Byte4_Norm:
                    return MTLVertexFormat.uchar4Normalized;
                case VertexElementFormat.Byte4:
                    return MTLVertexFormat.uchar4;
                case VertexElementFormat.SByte2_Norm:
                    return MTLVertexFormat.char2Normalized;
                case VertexElementFormat.SByte2:
                    return MTLVertexFormat.char2;
                case VertexElementFormat.SByte4_Norm:
                    return MTLVertexFormat.char4Normalized;
                case VertexElementFormat.SByte4:
                    return MTLVertexFormat.char4;
                case VertexElementFormat.UShort2_Norm:
                    return MTLVertexFormat.ushort2Normalized;
                case VertexElementFormat.UShort2:
                    return MTLVertexFormat.ushort2;
                case VertexElementFormat.Short2_Norm:
                    return MTLVertexFormat.short2Normalized;
                case VertexElementFormat.Short2:
                    return MTLVertexFormat.short2;
                case VertexElementFormat.UShort4_Norm:
                    return MTLVertexFormat.ushort4Normalized;
                case VertexElementFormat.UShort4:
                    return MTLVertexFormat.ushort4;
                case VertexElementFormat.Short4_Norm:
                    return MTLVertexFormat.short4Normalized;
                case VertexElementFormat.Short4:
                    return MTLVertexFormat.short4;
                case VertexElementFormat.UInt1:
                    return MTLVertexFormat.@uint;
                case VertexElementFormat.UInt2:
                    return MTLVertexFormat.uint2;
                case VertexElementFormat.UInt3:
                    return MTLVertexFormat.uint3;
                case VertexElementFormat.UInt4:
                    return MTLVertexFormat.uint4;
                case VertexElementFormat.Int1:
                    return MTLVertexFormat.@int;
                case VertexElementFormat.Int2:
                    return MTLVertexFormat.int2;
                case VertexElementFormat.Int3:
                    return MTLVertexFormat.int3;
                case VertexElementFormat.Int4:
                    return MTLVertexFormat.int4;
                case VertexElementFormat.Float1:
                    return MTLVertexFormat.@float;
                case VertexElementFormat.Float2:
                    return MTLVertexFormat.float2;
                case VertexElementFormat.Float3:
                    return MTLVertexFormat.float3;
                case VertexElementFormat.Float4:
                    return MTLVertexFormat.float4;
                case VertexElementFormat.Half1:
                    return MTLVertexFormat.half;
                case VertexElementFormat.Half2:
                    return MTLVertexFormat.half2;
                case VertexElementFormat.Half4:
                    return MTLVertexFormat.half4;
                default:
                    throw Illegal.Value<VertexElementFormat>();
            }
        }

        /// <summary>
        /// Vds the to mtl index format using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The mtl index type</returns>
        internal static MTLIndexType VdToMTLIndexFormat(IndexFormat format)
        {
            return format == IndexFormat.UInt16 ? MTLIndexType.UInt16 : MTLIndexType.UInt32;
        }

        /// <summary>
        /// Vds the to mtl stencil operation using the specified op
        /// </summary>
        /// <param name="op">The op</param>
        /// <returns>The mtl stencil operation</returns>
        internal static MTLStencilOperation VdToMTLStencilOperation(StencilOperation op)
        {
            switch (op)
            {
                case StencilOperation.Keep:
                    return MTLStencilOperation.Keep;
                case StencilOperation.Zero:
                    return MTLStencilOperation.Zero;
                case StencilOperation.Replace:
                    return MTLStencilOperation.Replace;
                case StencilOperation.IncrementAndClamp:
                    return MTLStencilOperation.IncrementClamp;
                case StencilOperation.DecrementAndClamp:
                    return MTLStencilOperation.DecrementClamp;
                case StencilOperation.Invert:
                    return MTLStencilOperation.Invert;
                case StencilOperation.IncrementAndWrap:
                    return MTLStencilOperation.IncrementWrap;
                case StencilOperation.DecrementAndWrap:
                    return MTLStencilOperation.DecrementWrap;
                default:
                    throw Illegal.Value<StencilOperation>();

            }
        }

        /// <summary>
        /// Gets the max texture 1 d width using the specified fs
        /// </summary>
        /// <param name="fs">The fs</param>
        /// <returns>The uint</returns>
        internal static uint GetMaxTexture1DWidth(MTLFeatureSet fs)
        {
            switch (fs)
            {
                case MTLFeatureSet.iOS_GPUFamily1_v1:
                case MTLFeatureSet.iOS_GPUFamily2_v1:
                    return 4096;
                case MTLFeatureSet.iOS_GPUFamily1_v2:
                case MTLFeatureSet.iOS_GPUFamily2_v2:
                case MTLFeatureSet.iOS_GPUFamily1_v3:
                case MTLFeatureSet.iOS_GPUFamily2_v3:
                case MTLFeatureSet.iOS_GPUFamily1_v4:
                case MTLFeatureSet.iOS_GPUFamily2_v4:
                case MTLFeatureSet.tvOS_GPUFamily1_v1:
                case MTLFeatureSet.tvOS_GPUFamily1_v2:
                case MTLFeatureSet.tvOS_GPUFamily1_v3:
                    return 8192;
                case MTLFeatureSet.iOS_GPUFamily3_v1:
                case MTLFeatureSet.iOS_GPUFamily3_v2:
                case MTLFeatureSet.iOS_GPUFamily3_v3:
                case MTLFeatureSet.iOS_GPUFamily4_v1:
                case MTLFeatureSet.tvOS_GPUFamily2_v1:
                case MTLFeatureSet.macOS_GPUFamily1_v1:
                case MTLFeatureSet.macOS_GPUFamily1_v2:
                case MTLFeatureSet.macOS_GPUFamily1_v3:
                    return 16384;
                default:
                    return 4096;
            }
        }

        /// <summary>
        /// Gets the max texture 2 d dimensions using the specified fs
        /// </summary>
        /// <param name="fs">The fs</param>
        /// <returns>The uint</returns>
        internal static uint GetMaxTexture2DDimensions(MTLFeatureSet fs)
        {
            switch (fs)
            {
                case MTLFeatureSet.iOS_GPUFamily1_v1:
                case MTLFeatureSet.iOS_GPUFamily2_v1:
                    return 4096;
                case MTLFeatureSet.iOS_GPUFamily1_v2:
                case MTLFeatureSet.iOS_GPUFamily2_v2:
                case MTLFeatureSet.iOS_GPUFamily1_v3:
                case MTLFeatureSet.iOS_GPUFamily2_v3:
                case MTLFeatureSet.iOS_GPUFamily1_v4:
                case MTLFeatureSet.iOS_GPUFamily2_v4:
                case MTLFeatureSet.tvOS_GPUFamily1_v1:
                case MTLFeatureSet.tvOS_GPUFamily1_v2:
                case MTLFeatureSet.tvOS_GPUFamily1_v3:
                    return 8192;
                case MTLFeatureSet.iOS_GPUFamily3_v1:
                case MTLFeatureSet.iOS_GPUFamily3_v2:
                case MTLFeatureSet.iOS_GPUFamily3_v3:
                case MTLFeatureSet.iOS_GPUFamily4_v1:
                case MTLFeatureSet.tvOS_GPUFamily2_v1:
                case MTLFeatureSet.macOS_GPUFamily1_v1:
                case MTLFeatureSet.macOS_GPUFamily1_v2:
                case MTLFeatureSet.macOS_GPUFamily1_v3:
                    return 16384;
                default:
                    return 4096;
            }
        }

        /// <summary>
        /// Gets the max texture cube dimensions using the specified fs
        /// </summary>
        /// <param name="fs">The fs</param>
        /// <returns>The uint</returns>
        internal static uint GetMaxTextureCubeDimensions(MTLFeatureSet fs)
        {
            switch (fs)
            {
                case MTLFeatureSet.iOS_GPUFamily1_v1:
                case MTLFeatureSet.iOS_GPUFamily2_v1:
                    return 4096;
                case MTLFeatureSet.iOS_GPUFamily1_v2:
                case MTLFeatureSet.iOS_GPUFamily2_v2:
                case MTLFeatureSet.iOS_GPUFamily1_v3:
                case MTLFeatureSet.iOS_GPUFamily2_v3:
                case MTLFeatureSet.iOS_GPUFamily1_v4:
                case MTLFeatureSet.iOS_GPUFamily2_v4:
                case MTLFeatureSet.tvOS_GPUFamily1_v1:
                case MTLFeatureSet.tvOS_GPUFamily1_v2:
                case MTLFeatureSet.tvOS_GPUFamily1_v3:
                    return 8192;
                case MTLFeatureSet.iOS_GPUFamily3_v1:
                case MTLFeatureSet.iOS_GPUFamily3_v2:
                case MTLFeatureSet.iOS_GPUFamily3_v3:
                case MTLFeatureSet.iOS_GPUFamily4_v1:
                case MTLFeatureSet.tvOS_GPUFamily2_v1:
                case MTLFeatureSet.macOS_GPUFamily1_v1:
                case MTLFeatureSet.macOS_GPUFamily1_v2:
                case MTLFeatureSet.macOS_GPUFamily1_v3:
                    return 16384;
                default:
                    return 4096;
            }
        }

        /// <summary>
        /// Gets the max texture volume using the specified fs
        /// </summary>
        /// <param name="fs">The fs</param>
        /// <returns>The uint</returns>
        internal static uint GetMaxTextureVolume(MTLFeatureSet fs)
        {
            return 2048;
        }
    }
}
