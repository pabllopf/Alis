using System.Diagnostics;
using Vortice.Direct3D11;
using Vortice.DXGI;

namespace Veldrid.D3D11
{
    /// <summary>
    /// The 11 formats class
    /// </summary>
    internal static class D3D11Formats
    {
        /// <summary>
        /// Returns the dxgi format using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="depthFormat">The depth format</param>
        /// <exception cref="VeldridException">ETC2 formats are not supported on Direct3D 11.</exception>
        /// <returns>The format</returns>
        internal static Format ToDxgiFormat(PixelFormat format, bool depthFormat)
        {
            switch (format)
            {
                case PixelFormat.R8_UNorm:
                    return Format.R8_UNorm;
                case PixelFormat.R8_SNorm:
                    return Format.R8_SNorm;
                case PixelFormat.R8_UInt:
                    return Format.R8_UInt;
                case PixelFormat.R8_SInt:
                    return Format.R8_SInt;

                case PixelFormat.R16_UNorm:
                    return depthFormat ? Format.R16_Typeless : Format.R16_UNorm;
                case PixelFormat.R16_SNorm:
                    return Format.R16_SNorm;
                case PixelFormat.R16_UInt:
                    return Format.R16_UInt;
                case PixelFormat.R16_SInt:
                    return Format.R16_SInt;
                case PixelFormat.R16_Float:
                    return Format.R16_Float;

                case PixelFormat.R32_UInt:
                    return Format.R32_UInt;
                case PixelFormat.R32_SInt:
                    return Format.R32_SInt;
                case PixelFormat.R32_Float:
                    return depthFormat ? Format.R32_Typeless : Format.R32_Float;

                case PixelFormat.R8_G8_UNorm:
                    return Format.R8G8_UNorm;
                case PixelFormat.R8_G8_SNorm:
                    return Format.R8G8_SNorm;
                case PixelFormat.R8_G8_UInt:
                    return Format.R8G8_UInt;
                case PixelFormat.R8_G8_SInt:
                    return Format.R8G8_SInt;

                case PixelFormat.R16_G16_UNorm:
                    return Format.R16G16_UNorm;
                case PixelFormat.R16_G16_SNorm:
                    return Format.R16G16_SNorm;
                case PixelFormat.R16_G16_UInt:
                    return Format.R16G16_UInt;
                case PixelFormat.R16_G16_SInt:
                    return Format.R16G16_SInt;
                case PixelFormat.R16_G16_Float:
                    return Format.R16G16_Float;

                case PixelFormat.R32_G32_UInt:
                    return Format.R32G32_UInt;
                case PixelFormat.R32_G32_SInt:
                    return Format.R32G32_SInt;
                case PixelFormat.R32_G32_Float:
                    return Format.R32G32_Float;

                case PixelFormat.R8_G8_B8_A8_UNorm:
                    return Format.R8G8B8A8_UNorm;
                case PixelFormat.R8_G8_B8_A8_UNorm_SRgb:
                    return Format.R8G8B8A8_UNorm_SRgb;
                case PixelFormat.B8_G8_R8_A8_UNorm:
                    return Format.B8G8R8A8_UNorm;
                case PixelFormat.B8_G8_R8_A8_UNorm_SRgb:
                    return Format.B8G8R8A8_UNorm_SRgb;
                case PixelFormat.R8_G8_B8_A8_SNorm:
                    return Format.R8G8B8A8_SNorm;
                case PixelFormat.R8_G8_B8_A8_UInt:
                    return Format.R8G8B8A8_UInt;
                case PixelFormat.R8_G8_B8_A8_SInt:
                    return Format.R8G8B8A8_SInt;

                case PixelFormat.R16_G16_B16_A16_UNorm:
                    return Format.R16G16B16A16_UNorm;
                case PixelFormat.R16_G16_B16_A16_SNorm:
                    return Format.R16G16B16A16_SNorm;
                case PixelFormat.R16_G16_B16_A16_UInt:
                    return Format.R16G16B16A16_UInt;
                case PixelFormat.R16_G16_B16_A16_SInt:
                    return Format.R16G16B16A16_SInt;
                case PixelFormat.R16_G16_B16_A16_Float:
                    return Format.R16G16B16A16_Float;

                case PixelFormat.R32_G32_B32_A32_UInt:
                    return Format.R32G32B32A32_UInt;
                case PixelFormat.R32_G32_B32_A32_SInt:
                    return Format.R32G32B32A32_SInt;
                case PixelFormat.R32_G32_B32_A32_Float:
                    return Format.R32G32B32A32_Float;

                case PixelFormat.BC1_Rgb_UNorm:
                case PixelFormat.BC1_Rgba_UNorm:
                    return Format.BC1_UNorm;
                case PixelFormat.BC1_Rgb_UNorm_SRgb:
                case PixelFormat.BC1_Rgba_UNorm_SRgb:
                    return Format.BC1_UNorm_SRgb;
                case PixelFormat.BC2_UNorm:
                    return Format.BC2_UNorm;
                case PixelFormat.BC2_UNorm_SRgb:
                    return Format.BC2_UNorm_SRgb;
                case PixelFormat.BC3_UNorm:
                    return Format.BC3_UNorm;
                case PixelFormat.BC3_UNorm_SRgb:
                    return Format.BC3_UNorm_SRgb;
                case PixelFormat.BC4_UNorm:
                    return Format.BC4_UNorm;
                case PixelFormat.BC4_SNorm:
                    return Format.BC4_SNorm;
                case PixelFormat.BC5_UNorm:
                    return Format.BC5_UNorm;
                case PixelFormat.BC5_SNorm:
                    return Format.BC5_SNorm;
                case PixelFormat.BC7_UNorm:
                    return Format.BC7_UNorm;
                case PixelFormat.BC7_UNorm_SRgb:
                    return Format.BC7_UNorm_SRgb;

                case PixelFormat.D24_UNorm_S8_UInt:
                    Debug.Assert(depthFormat);
                    return Format.R24G8_Typeless;
                case PixelFormat.D32_Float_S8_UInt:
                    Debug.Assert(depthFormat);
                    return Format.R32G8X24_Typeless;

                case PixelFormat.R10_G10_B10_A2_UNorm:
                    return Format.R10G10B10A2_UNorm;
                case PixelFormat.R10_G10_B10_A2_UInt:
                    return Format.R10G10B10A2_UInt;
                case PixelFormat.R11_G11_B10_Float:
                    return Format.R11G11B10_Float;

                case PixelFormat.ETC2_R8_G8_B8_UNorm:
                case PixelFormat.ETC2_R8_G8_B8_A1_UNorm:
                case PixelFormat.ETC2_R8_G8_B8_A8_UNorm:
                    throw new VeldridException("ETC2 formats are not supported on Direct3D 11.");

                default:
                    throw Illegal.Value<PixelFormat>();
            }
        }

        /// <summary>
        /// Gets the typeless format using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The format</returns>
        internal static Format GetTypelessFormat(Format format)
        {
            switch (format)
            {
                case Format.R32G32B32A32_Typeless:
                case Format.R32G32B32A32_Float:
                case Format.R32G32B32A32_UInt:
                case Format.R32G32B32A32_SInt:
                    return Format.R32G32B32A32_Typeless;
                case Format.R32G32B32_Typeless:
                case Format.R32G32B32_Float:
                case Format.R32G32B32_UInt:
                case Format.R32G32B32_SInt:
                    return Format.R32G32B32_Typeless;
                case Format.R16G16B16A16_Typeless:
                case Format.R16G16B16A16_Float:
                case Format.R16G16B16A16_UNorm:
                case Format.R16G16B16A16_UInt:
                case Format.R16G16B16A16_SNorm:
                case Format.R16G16B16A16_SInt:
                    return Format.R16G16B16A16_Typeless;
                case Format.R32G32_Typeless:
                case Format.R32G32_Float:
                case Format.R32G32_UInt:
                case Format.R32G32_SInt:
                    return Format.R32G32_Typeless;
                case Format.R10G10B10A2_Typeless:
                case Format.R10G10B10A2_UNorm:
                case Format.R10G10B10A2_UInt:
                    return Format.R10G10B10A2_Typeless;
                case Format.R8G8B8A8_Typeless:
                case Format.R8G8B8A8_UNorm:
                case Format.R8G8B8A8_UNorm_SRgb:
                case Format.R8G8B8A8_UInt:
                case Format.R8G8B8A8_SNorm:
                case Format.R8G8B8A8_SInt:
                    return Format.R8G8B8A8_Typeless;
                case Format.R16G16_Typeless:
                case Format.R16G16_Float:
                case Format.R16G16_UNorm:
                case Format.R16G16_UInt:
                case Format.R16G16_SNorm:
                case Format.R16G16_SInt:
                    return Format.R16G16_Typeless;
                case Format.R32_Typeless:
                case Format.D32_Float:
                case Format.R32_Float:
                case Format.R32_UInt:
                case Format.R32_SInt:
                    return Format.R32_Typeless;
                case Format.R24G8_Typeless:
                case Format.D24_UNorm_S8_UInt:
                case Format.R24_UNorm_X8_Typeless:
                case Format.X24_Typeless_G8_UInt:
                    return Format.R24G8_Typeless;
                case Format.R8G8_Typeless:
                case Format.R8G8_UNorm:
                case Format.R8G8_UInt:
                case Format.R8G8_SNorm:
                case Format.R8G8_SInt:
                    return Format.R8G8_Typeless;
                case Format.R16_Typeless:
                case Format.R16_Float:
                case Format.D16_UNorm:
                case Format.R16_UNorm:
                case Format.R16_UInt:
                case Format.R16_SNorm:
                case Format.R16_SInt:
                    return Format.R16_Typeless;
                case Format.R8_Typeless:
                case Format.R8_UNorm:
                case Format.R8_UInt:
                case Format.R8_SNorm:
                case Format.R8_SInt:
                case Format.A8_UNorm:
                    return Format.R8_Typeless;
                case Format.BC1_Typeless:
                case Format.BC1_UNorm:
                case Format.BC1_UNorm_SRgb:
                    return Format.BC1_Typeless;
                case Format.BC2_Typeless:
                case Format.BC2_UNorm:
                case Format.BC2_UNorm_SRgb:
                    return Format.BC2_Typeless;
                case Format.BC3_Typeless:
                case Format.BC3_UNorm:
                case Format.BC3_UNorm_SRgb:
                    return Format.BC3_Typeless;
                case Format.BC4_Typeless:
                case Format.BC4_UNorm:
                case Format.BC4_SNorm:
                    return Format.BC4_Typeless;
                case Format.BC5_Typeless:
                case Format.BC5_UNorm:
                case Format.BC5_SNorm:
                    return Format.BC5_Typeless;
                case Format.B8G8R8A8_Typeless:
                case Format.B8G8R8A8_UNorm:
                case Format.B8G8R8A8_UNorm_SRgb:
                    return Format.B8G8R8A8_Typeless;
                case Format.BC7_Typeless:
                case Format.BC7_UNorm:
                case Format.BC7_UNorm_SRgb:
                    return Format.BC7_Typeless;
                default:
                    return format;
            }
        }

        /// <summary>
        /// Vds the to d 3 d 11 bind flags using the specified usage
        /// </summary>
        /// <param name="usage">The usage</param>
        /// <returns>The flags</returns>
        internal static BindFlags VdToD3D11BindFlags(BufferUsage usage)
        {
            BindFlags flags = BindFlags.None;
            if ((usage & BufferUsage.VertexBuffer) == BufferUsage.VertexBuffer)
            {
                flags |= BindFlags.VertexBuffer;
            }
            if ((usage & BufferUsage.IndexBuffer) == BufferUsage.IndexBuffer)
            {
                flags |= BindFlags.IndexBuffer;
            }
            if ((usage & BufferUsage.UniformBuffer) == BufferUsage.UniformBuffer)
            {
                flags |= BindFlags.ConstantBuffer;
            }
            if ((usage & BufferUsage.StructuredBufferReadOnly) == BufferUsage.StructuredBufferReadOnly
                || (usage & BufferUsage.StructuredBufferReadWrite) == BufferUsage.StructuredBufferReadWrite)
            {
                flags |= BindFlags.ShaderResource;
            }
            if ((usage & BufferUsage.StructuredBufferReadWrite) == BufferUsage.StructuredBufferReadWrite)
            {
                flags |= BindFlags.UnorderedAccess;
            }

            return flags;
        }

        /// <summary>
        /// Gets the vd usage using the specified bind flags
        /// </summary>
        /// <param name="bindFlags">The bind flags</param>
        /// <param name="cpuFlags">The cpu flags</param>
        /// <param name="optionFlags">The option flags</param>
        /// <returns>The usage</returns>
        internal static TextureUsage GetVdUsage(BindFlags bindFlags, CpuAccessFlags cpuFlags, ResourceOptionFlags optionFlags)
        {
            TextureUsage usage = 0;
            if ((bindFlags & BindFlags.RenderTarget) != 0)
            {
                usage |= TextureUsage.RenderTarget;
            }
            if ((bindFlags & BindFlags.DepthStencil) != 0)
            {
                usage |= TextureUsage.DepthStencil;
            }
            if ((bindFlags & BindFlags.ShaderResource) != 0)
            {
                usage |= TextureUsage.Sampled;
            }
            if ((bindFlags & BindFlags.UnorderedAccess) != 0)
            {
                usage |= TextureUsage.Storage;
            }

            if ((optionFlags & ResourceOptionFlags.TextureCube) != 0)
            {
                usage |= TextureUsage.Cubemap;
            }
            if ((optionFlags & ResourceOptionFlags.GenerateMips) != 0)
            {
                usage |= TextureUsage.GenerateMipmaps;
            }

            return usage;
        }

        /// <summary>
        /// Describes whether is unsupported format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        internal static bool IsUnsupportedFormat(PixelFormat format)
        {
            return format == PixelFormat.ETC2_R8_G8_B8_UNorm
                || format == PixelFormat.ETC2_R8_G8_B8_A1_UNorm
                || format == PixelFormat.ETC2_R8_G8_B8_A8_UNorm;
        }

        /// <summary>
        /// Gets the view format using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The format</returns>
        internal static Format GetViewFormat(Format format)
        {
            switch (format)
            {
                case Format.R16_Typeless:
                    return Format.R16_UNorm;
                case Format.R32_Typeless:
                    return Format.R32_Float;
                case Format.R32G8X24_Typeless:
                    return Format.R32_Float_X8X24_Typeless;
                case Format.R24G8_Typeless:
                    return Format.R24_UNorm_X8_Typeless;
                default:
                    return format;
            }
        }

        /// <summary>
        /// Vds the to d 3 d 11 blend using the specified factor
        /// </summary>
        /// <param name="factor">The factor</param>
        /// <returns>The blend</returns>
        internal static Blend VdToD3D11Blend(BlendFactor factor)
        {
            switch (factor)
            {
                case BlendFactor.Zero:
                    return Blend.Zero;
                case BlendFactor.One:
                    return Blend.One;
                case BlendFactor.SourceAlpha:
                    return Blend.SourceAlpha;
                case BlendFactor.InverseSourceAlpha:
                    return Blend.InverseSourceAlpha;
                case BlendFactor.DestinationAlpha:
                    return Blend.DestinationAlpha;
                case BlendFactor.InverseDestinationAlpha:
                    return Blend.InverseDestinationAlpha;
                case BlendFactor.SourceColor:
                    return Blend.SourceColor;
                case BlendFactor.InverseSourceColor:
                    return Blend.InverseSourceColor;
                case BlendFactor.DestinationColor:
                    return Blend.DestinationColor;
                case BlendFactor.InverseDestinationColor:
                    return Blend.InverseDestinationColor;
                case BlendFactor.BlendFactor:
                    return Blend.BlendFactor;
                case BlendFactor.InverseBlendFactor:
                    return Blend.InverseBlendFactor;
                default:
                    throw Illegal.Value<BlendFactor>();
            }
        }

        /// <summary>
        /// Returns the dxgi format using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The format</returns>
        internal static Format ToDxgiFormat(IndexFormat format)
        {
            switch (format)
            {
                case IndexFormat.UInt16:
                    return Format.R16_UInt;
                case IndexFormat.UInt32:
                    return Format.R32_UInt;
                default:
                    throw Illegal.Value<IndexFormat>();
            }
        }

        /// <summary>
        /// Vds the to d 3 d 11 stencil operation using the specified op
        /// </summary>
        /// <param name="op">The op</param>
        /// <returns>The vortice direct 11 stencil operation</returns>
        internal static Vortice.Direct3D11.StencilOperation VdToD3D11StencilOperation(StencilOperation op)
        {
            switch (op)
            {
                case StencilOperation.Keep:
                    return Vortice.Direct3D11.StencilOperation.Keep;
                case StencilOperation.Zero:
                    return Vortice.Direct3D11.StencilOperation.Zero;
                case StencilOperation.Replace:
                    return Vortice.Direct3D11.StencilOperation.Replace;
                case StencilOperation.IncrementAndClamp:
                    return Vortice.Direct3D11.StencilOperation.IncrementSaturate;
                case StencilOperation.DecrementAndClamp:
                    return Vortice.Direct3D11.StencilOperation.DecrementSaturate;
                case StencilOperation.Invert:
                    return Vortice.Direct3D11.StencilOperation.Invert;
                case StencilOperation.IncrementAndWrap:
                    return Vortice.Direct3D11.StencilOperation.Increment;
                case StencilOperation.DecrementAndWrap:
                    return Vortice.Direct3D11.StencilOperation.Decrement;
                default:
                    throw Illegal.Value<StencilOperation>();
            }
        }

        /// <summary>
        /// Returns the vd format using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The pixel format</returns>
        internal static PixelFormat ToVdFormat(Format format)
        {
            switch (format)
            {
                case Format.R8_UNorm:
                    return PixelFormat.R8_UNorm;
                case Format.R8_SNorm:
                    return PixelFormat.R8_SNorm;
                case Format.R8_UInt:
                    return PixelFormat.R8_UInt;
                case Format.R8_SInt:
                    return PixelFormat.R8_SInt;

                case Format.R16_UNorm:
                case Format.D16_UNorm:
                    return PixelFormat.R16_UNorm;
                case Format.R16_SNorm:
                    return PixelFormat.R16_SNorm;
                case Format.R16_UInt:
                    return PixelFormat.R16_UInt;
                case Format.R16_SInt:
                    return PixelFormat.R16_SInt;
                case Format.R16_Float:
                    return PixelFormat.R16_Float;

                case Format.R32_UInt:
                    return PixelFormat.R32_UInt;
                case Format.R32_SInt:
                    return PixelFormat.R32_SInt;
                case Format.R32_Float:
                case Format.D32_Float:
                    return PixelFormat.R32_Float;

                case Format.R8G8_UNorm:
                    return PixelFormat.R8_G8_UNorm;
                case Format.R8G8_SNorm:
                    return PixelFormat.R8_G8_SNorm;
                case Format.R8G8_UInt:
                    return PixelFormat.R8_G8_UInt;
                case Format.R8G8_SInt:
                    return PixelFormat.R8_G8_SInt;

                case Format.R16G16_UNorm:
                    return PixelFormat.R16_G16_UNorm;
                case Format.R16G16_SNorm:
                    return PixelFormat.R16_G16_SNorm;
                case Format.R16G16_UInt:
                    return PixelFormat.R16_G16_UInt;
                case Format.R16G16_SInt:
                    return PixelFormat.R16_G16_SInt;
                case Format.R16G16_Float:
                    return PixelFormat.R16_G16_Float;

                case Format.R32G32_UInt:
                    return PixelFormat.R32_G32_UInt;
                case Format.R32G32_SInt:
                    return PixelFormat.R32_G32_SInt;
                case Format.R32G32_Float:
                    return PixelFormat.R32_G32_Float;

                case Format.R8G8B8A8_UNorm:
                    return PixelFormat.R8_G8_B8_A8_UNorm;
                case Format.R8G8B8A8_UNorm_SRgb:
                    return PixelFormat.R8_G8_B8_A8_UNorm_SRgb;

                case Format.B8G8R8A8_UNorm:
                    return PixelFormat.B8_G8_R8_A8_UNorm;
                case Format.B8G8R8A8_UNorm_SRgb:
                    return PixelFormat.B8_G8_R8_A8_UNorm_SRgb;
                case Format.R8G8B8A8_SNorm:
                    return PixelFormat.R8_G8_B8_A8_SNorm;
                case Format.R8G8B8A8_UInt:
                    return PixelFormat.R8_G8_B8_A8_UInt;
                case Format.R8G8B8A8_SInt:
                    return PixelFormat.R8_G8_B8_A8_SInt;

                case Format.R16G16B16A16_UNorm:
                    return PixelFormat.R16_G16_B16_A16_UNorm;
                case Format.R16G16B16A16_SNorm:
                    return PixelFormat.R16_G16_B16_A16_SNorm;
                case Format.R16G16B16A16_UInt:
                    return PixelFormat.R16_G16_B16_A16_UInt;
                case Format.R16G16B16A16_SInt:
                    return PixelFormat.R16_G16_B16_A16_SInt;
                case Format.R16G16B16A16_Float:
                    return PixelFormat.R16_G16_B16_A16_Float;

                case Format.R32G32B32A32_UInt:
                    return PixelFormat.R32_G32_B32_A32_UInt;
                case Format.R32G32B32A32_SInt:
                    return PixelFormat.R32_G32_B32_A32_SInt;
                case Format.R32G32B32A32_Float:
                    return PixelFormat.R32_G32_B32_A32_Float;

                case Format.BC1_UNorm:
                case Format.BC1_Typeless:
                    return PixelFormat.BC1_Rgba_UNorm;
                case Format.BC2_UNorm:
                    return PixelFormat.BC2_UNorm;
                case Format.BC3_UNorm:
                    return PixelFormat.BC3_UNorm;
                case Format.BC4_UNorm:
                    return PixelFormat.BC4_UNorm;
                case Format.BC4_SNorm:
                    return PixelFormat.BC4_SNorm;
                case Format.BC5_UNorm:
                    return PixelFormat.BC5_UNorm;
                case Format.BC5_SNorm:
                    return PixelFormat.BC5_SNorm;
                case Format.BC7_UNorm:
                    return PixelFormat.BC7_UNorm;

                case Format.D24_UNorm_S8_UInt:
                    return PixelFormat.D24_UNorm_S8_UInt;
                case Format.D32_Float_S8X24_UInt:
                    return PixelFormat.D32_Float_S8_UInt;

                case Format.R10G10B10A2_UInt:
                    return PixelFormat.R10_G10_B10_A2_UInt;
                case Format.R10G10B10A2_UNorm:
                    return PixelFormat.R10_G10_B10_A2_UNorm;
                case Format.R11G11B10_Float:
                    return PixelFormat.R11_G11_B10_Float;
                default:
                    throw Illegal.Value<PixelFormat>();
            }
        }

        /// <summary>
        /// Vds the to d 3 d 11 blend operation using the specified function
        /// </summary>
        /// <param name="function">The function</param>
        /// <returns>The blend operation</returns>
        internal static BlendOperation VdToD3D11BlendOperation(BlendFunction function)
        {
            switch (function)
            {
                case BlendFunction.Add:
                    return BlendOperation.Add;
                case BlendFunction.Subtract:
                    return BlendOperation.Subtract;
                case BlendFunction.ReverseSubtract:
                    return BlendOperation.ReverseSubtract;
                case BlendFunction.Minimum:
                    return BlendOperation.Min;
                case BlendFunction.Maximum:
                    return BlendOperation.Max;
                default:
                    throw Illegal.Value<BlendFunction>();
            }
        }

        /// <summary>
        /// Vds the to d 3 d 11 color write enable using the specified mask
        /// </summary>
        /// <param name="mask">The mask</param>
        /// <returns>The enable</returns>
        internal static ColorWriteEnable VdToD3D11ColorWriteEnable(ColorWriteMask mask)
        {
            ColorWriteEnable enable = ColorWriteEnable.None;

            if ((mask & ColorWriteMask.Red) == ColorWriteMask.Red)
                enable |= ColorWriteEnable.Red;
            if ((mask & ColorWriteMask.Green) == ColorWriteMask.Green)
                enable |= ColorWriteEnable.Green;
            if ((mask & ColorWriteMask.Blue) == ColorWriteMask.Blue)
                enable |= ColorWriteEnable.Blue;
            if ((mask & ColorWriteMask.Alpha) == ColorWriteMask.Alpha)
                enable |= ColorWriteEnable.Alpha;

            return enable;
        }

        /// <summary>
        /// Returns the d 3 d 11 filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="isComparison">The is comparison</param>
        /// <returns>The filter</returns>
        internal static Filter ToD3D11Filter(SamplerFilter filter, bool isComparison)
        {
            switch (filter)
            {
                case SamplerFilter.MinPoint_MagPoint_MipPoint:
                    return isComparison ? Filter.ComparisonMinMagMipPoint : Filter.MinMagMipPoint;
                case SamplerFilter.MinPoint_MagPoint_MipLinear:
                    return isComparison ? Filter.ComparisonMinMagPointMipLinear : Filter.MinMagPointMipLinear;
                case SamplerFilter.MinPoint_MagLinear_MipPoint:
                    return isComparison ? Filter.ComparisonMinPointMagLinearMipPoint : Filter.MinPointMagLinearMipPoint;
                case SamplerFilter.MinPoint_MagLinear_MipLinear:
                    return isComparison ? Filter.ComparisonMinPointMagMipLinear : Filter.MinPointMagMipLinear;
                case SamplerFilter.MinLinear_MagPoint_MipPoint:
                    return isComparison ? Filter.ComparisonMinLinearMagMipPoint : Filter.MinLinearMagMipPoint;
                case SamplerFilter.MinLinear_MagPoint_MipLinear:
                    return isComparison ? Filter.ComparisonMinLinearMagPointMipLinear : Filter.MinLinearMagPointMipLinear;
                case SamplerFilter.MinLinear_MagLinear_MipPoint:
                    return isComparison ? Filter.ComparisonMinMagLinearMipPoint : Filter.MinMagLinearMipPoint;
                case SamplerFilter.MinLinear_MagLinear_MipLinear:
                    return isComparison ? Filter.ComparisonMinMagMipLinear : Filter.MinMagMipLinear;
                case SamplerFilter.Anisotropic:
                    return isComparison ? Filter.ComparisonAnisotropic : Filter.Anisotropic;
                default:
                    throw Illegal.Value<SamplerFilter>();
            }
        }

        /// <summary>
        /// Vds the to d 3 d 11 map mode using the specified is dynamic
        /// </summary>
        /// <param name="isDynamic">The is dynamic</param>
        /// <param name="mode">The mode</param>
        /// <returns>The vortice direct 11 map mode</returns>
        internal static Vortice.Direct3D11.MapMode VdToD3D11MapMode(bool isDynamic, MapMode mode)
        {
            switch (mode)
            {
                case MapMode.Read:
                    return Vortice.Direct3D11.MapMode.Read;
                case MapMode.Write:
                    return isDynamic ? Vortice.Direct3D11.MapMode.WriteDiscard : Vortice.Direct3D11.MapMode.Write;
                case MapMode.ReadWrite:
                    return Vortice.Direct3D11.MapMode.ReadWrite;
                default:
                    throw Illegal.Value<MapMode>();
            }
        }

        /// <summary>
        /// Vds the to d 3 d 11 primitive topology using the specified primitive topology
        /// </summary>
        /// <param name="primitiveTopology">The primitive topology</param>
        /// <returns>The vortice direct primitive topology</returns>
        internal static Vortice.Direct3D.PrimitiveTopology VdToD3D11PrimitiveTopology(PrimitiveTopology primitiveTopology)
        {
            switch (primitiveTopology)
            {
                case PrimitiveTopology.TriangleList:
                    return Vortice.Direct3D.PrimitiveTopology.TriangleList;
                case PrimitiveTopology.TriangleStrip:
                    return Vortice.Direct3D.PrimitiveTopology.TriangleStrip;
                case PrimitiveTopology.LineList:
                    return Vortice.Direct3D.PrimitiveTopology.LineList;
                case PrimitiveTopology.LineStrip:
                    return Vortice.Direct3D.PrimitiveTopology.LineStrip;
                case PrimitiveTopology.PointList:
                    return Vortice.Direct3D.PrimitiveTopology.PointList;
                default:
                    throw Illegal.Value<PrimitiveTopology>();
            }
        }

        /// <summary>
        /// Vds the to d 3 d 11 fill mode using the specified fill mode
        /// </summary>
        /// <param name="fillMode">The fill mode</param>
        /// <returns>The fill mode</returns>
        internal static FillMode VdToD3D11FillMode(PolygonFillMode fillMode)
        {
            switch (fillMode)
            {
                case PolygonFillMode.Solid:
                    return FillMode.Solid;
                case PolygonFillMode.Wireframe:
                    return FillMode.Wireframe;
                default:
                    throw Illegal.Value<PolygonFillMode>();
            }
        }

        /// <summary>
        /// Vds the to d 3 d 11 cull mode using the specified culling mode
        /// </summary>
        /// <param name="cullingMode">The culling mode</param>
        /// <returns>The cull mode</returns>
        internal static CullMode VdToD3D11CullMode(FaceCullMode cullingMode)
        {
            switch (cullingMode)
            {
                case FaceCullMode.Back:
                    return CullMode.Back;
                case FaceCullMode.Front:
                    return CullMode.Front;
                case FaceCullMode.None:
                    return CullMode.None;
                default:
                    throw Illegal.Value<FaceCullMode>();
            }
        }

        /// <summary>
        /// Returns the dxgi format using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The format</returns>
        internal static Format ToDxgiFormat(VertexElementFormat format)
        {
            switch (format)
            {
                case VertexElementFormat.Float1:
                    return Format.R32_Float;
                case VertexElementFormat.Float2:
                    return Format.R32G32_Float;
                case VertexElementFormat.Float3:
                    return Format.R32G32B32_Float;
                case VertexElementFormat.Float4:
                    return Format.R32G32B32A32_Float;
                case VertexElementFormat.Byte2_Norm:
                    return Format.R8G8_UNorm;
                case VertexElementFormat.Byte2:
                    return Format.R8G8_UInt;
                case VertexElementFormat.Byte4_Norm:
                    return Format.R8G8B8A8_UNorm;
                case VertexElementFormat.Byte4:
                    return Format.R8G8B8A8_UInt;
                case VertexElementFormat.SByte2_Norm:
                    return Format.R8G8_SNorm;
                case VertexElementFormat.SByte2:
                    return Format.R8G8_SInt;
                case VertexElementFormat.SByte4_Norm:
                    return Format.R8G8B8A8_SNorm;
                case VertexElementFormat.SByte4:
                    return Format.R8G8B8A8_SInt;
                case VertexElementFormat.UShort2_Norm:
                    return Format.R16G16_UNorm;
                case VertexElementFormat.UShort2:
                    return Format.R16G16_UInt;
                case VertexElementFormat.UShort4_Norm:
                    return Format.R16G16B16A16_UNorm;
                case VertexElementFormat.UShort4:
                    return Format.R16G16B16A16_UInt;
                case VertexElementFormat.Short2_Norm:
                    return Format.R16G16_SNorm;
                case VertexElementFormat.Short2:
                    return Format.R16G16_SInt;
                case VertexElementFormat.Short4_Norm:
                    return Format.R16G16B16A16_SNorm;
                case VertexElementFormat.Short4:
                    return Format.R16G16B16A16_SInt;
                case VertexElementFormat.UInt1:
                    return Format.R32_UInt;
                case VertexElementFormat.UInt2:
                    return Format.R32G32_UInt;
                case VertexElementFormat.UInt3:
                    return Format.R32G32B32_UInt;
                case VertexElementFormat.UInt4:
                    return Format.R32G32B32A32_UInt;
                case VertexElementFormat.Int1:
                    return Format.R32_SInt;
                case VertexElementFormat.Int2:
                    return Format.R32G32_SInt;
                case VertexElementFormat.Int3:
                    return Format.R32G32B32_SInt;
                case VertexElementFormat.Int4:
                    return Format.R32G32B32A32_SInt;
                case VertexElementFormat.Half1:
                    return Format.R16_Float;
                case VertexElementFormat.Half2:
                    return Format.R16G16_Float;
                case VertexElementFormat.Half4:
                    return Format.R16G16B16A16_Float;

                default:
                    throw Illegal.Value<VertexElementFormat>();
            }
        }

        /// <summary>
        /// Vds the to d 3 d 11 comparison func using the specified comparison kind
        /// </summary>
        /// <param name="comparisonKind">The comparison kind</param>
        /// <returns>The comparison function</returns>
        internal static ComparisonFunction VdToD3D11ComparisonFunc(ComparisonKind comparisonKind)
        {
            switch (comparisonKind)
            {
                case ComparisonKind.Never:
                    return ComparisonFunction.Never;
                case ComparisonKind.Less:
                    return ComparisonFunction.Less;
                case ComparisonKind.Equal:
                    return ComparisonFunction.Equal;
                case ComparisonKind.LessEqual:
                    return ComparisonFunction.LessEqual;
                case ComparisonKind.Greater:
                    return ComparisonFunction.Greater;
                case ComparisonKind.NotEqual:
                    return ComparisonFunction.NotEqual;
                case ComparisonKind.GreaterEqual:
                    return ComparisonFunction.GreaterEqual;
                case ComparisonKind.Always:
                    return ComparisonFunction.Always;
                default:
                    throw Illegal.Value<ComparisonKind>();
            }
        }

        /// <summary>
        /// Vds the to d 3 d 11 address mode using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <returns>The texture address mode</returns>
        internal static TextureAddressMode VdToD3D11AddressMode(SamplerAddressMode mode)
        {
            switch (mode)
            {
                case SamplerAddressMode.Wrap:
                    return TextureAddressMode.Wrap;
                case SamplerAddressMode.Mirror:
                    return TextureAddressMode.Mirror;
                case SamplerAddressMode.Clamp:
                    return TextureAddressMode.Clamp;
                case SamplerAddressMode.Border:
                    return TextureAddressMode.Border;
                default:
                    throw Illegal.Value<SamplerAddressMode>();
            }
        }

        /// <summary>
        /// Gets the depth format using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <exception cref="VeldridException"></exception>
        /// <returns>The format</returns>
        internal static Format GetDepthFormat(PixelFormat format)
        {
            switch (format)
            {
                case PixelFormat.R32_Float:
                    return Format.D32_Float;
                case PixelFormat.R16_UNorm:
                    return Format.D16_UNorm;
                case PixelFormat.D24_UNorm_S8_UInt:
                    return Format.D24_UNorm_S8_UInt;
                case PixelFormat.D32_Float_S8_UInt:
                    return Format.D32_Float_S8X24_UInt;
                default:
                    throw new VeldridException("Invalid depth texture format: " + format);
            }
        }
    }
}
