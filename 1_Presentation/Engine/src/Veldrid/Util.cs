using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Veldrid
{
    /// <summary>
    /// The util class
    /// </summary>
    internal static class Util
    {
        /// <summary>
        /// Asserts the subtype using the specified value
        /// </summary>
        /// <typeparam name="TBase">The base</typeparam>
        /// <typeparam name="TDerived">The derived</typeparam>
        /// <param name="value">The value</param>
        /// <returns>The derived</returns>
        [DebuggerNonUserCode]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TDerived AssertSubtype<TBase, TDerived>(TBase value) where TDerived : class, TBase where TBase : class
        {
#if DEBUG
            if (value == null)
            {
                throw new VeldridException($"Expected object of type {typeof(TDerived).FullName} but received null instead.");
            }

            if (!(value is TDerived derived))
            {
                throw new VeldridException($"object {value} must be derived type {typeof(TDerived).FullName} to be used in this context.");
            }

            return derived;

#else
            return (TDerived)value;
#endif
        }

        /// <summary>
        /// Ensures the array minimum size using the specified array
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="array">The array</param>
        /// <param name="size">The size</param>
        internal static void EnsureArrayMinimumSize<T>(ref T[] array, uint size)
        {
            if (array == null)
            {
                array = new T[size];
            }
            else if (array.Length < size)
            {
                Array.Resize(ref array, (int)size);
            }
        }

        /// <summary>
        /// Us the size of
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The uint</returns>
        internal static uint USizeOf<T>() where T : struct
        {
            return (uint)Unsafe.SizeOf<T>();
        }

        /// <summary>
        /// Gets the string using the specified string start
        /// </summary>
        /// <param name="stringStart">The string start</param>
        /// <returns>The string</returns>
        internal static unsafe string GetString(byte* stringStart)
        {
            int characters = 0;
            while (stringStart[characters] != 0)
            {
                characters++;
            }

            return Encoding.UTF8.GetString(stringStart, characters);
        }

        /// <summary>
        /// Describes whether nullable equals
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The bool</returns>
        internal static bool NullableEquals<T>(T? left, T? right) where T : struct, IEquatable<T>
        {
            if (left.HasValue && right.HasValue)
            {
                return left.Value.Equals(right.Value);
            }

            return left.HasValue == right.HasValue;
        }

        /// <summary>
        /// Describes whether array equals
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The bool</returns>
        internal static bool ArrayEquals<T>(T[] left, T[] right) where T : class
        {
            if (left == null || right == null)
            {
                return left == right;
            }

            if (left.Length != right.Length)
            {
                return false;
            }

            for (int i = 0; i < left.Length; i++)
            {
                if (!ReferenceEquals(left[i], right[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Describes whether array equals equatable
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The bool</returns>
        internal static bool ArrayEqualsEquatable<T>(T[] left, T[] right) where T : struct, IEquatable<T>
        {
            if (left == null || right == null)
            {
                return left == right;
            }

            if (left.Length != right.Length)
            {
                return false;
            }

            for (int i = 0; i < left.Length; i++)
            {
                if (!left[i].Equals(right[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Clears the array using the specified array
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="array">The array</param>
        internal static void ClearArray<T>(T[] array)
        {
            if (array != null)
            {
                Array.Clear(array, 0, array.Length);
            }
        }

        /// <summary>
        /// Clamps the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        /// <returns>The uint</returns>
        public static uint Clamp(uint value, uint min, uint max)
        {
            if (value <= min)
            {
                return min;
            }
            else if (value >= max)
            {
                return max;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Gets the mip level and array layer using the specified tex
        /// </summary>
        /// <param name="tex">The tex</param>
        /// <param name="subresource">The subresource</param>
        /// <param name="mipLevel">The mip level</param>
        /// <param name="arrayLayer">The array layer</param>
        internal static void GetMipLevelAndArrayLayer(Texture tex, uint subresource, out uint mipLevel, out uint arrayLayer)
        {
            arrayLayer = subresource / tex.MipLevels;
            mipLevel = subresource - (arrayLayer * tex.MipLevels);
        }

        /// <summary>
        /// Gets the mip dimensions using the specified tex
        /// </summary>
        /// <param name="tex">The tex</param>
        /// <param name="mipLevel">The mip level</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        internal static void GetMipDimensions(Texture tex, uint mipLevel, out uint width, out uint height, out uint depth)
        {
            width = GetDimension(tex.Width, mipLevel);
            height = GetDimension(tex.Height, mipLevel);
            depth = GetDimension(tex.Depth, mipLevel);
        }

        /// <summary>
        /// Gets the dimension using the specified largest level dimension
        /// </summary>
        /// <param name="largestLevelDimension">The largest level dimension</param>
        /// <param name="mipLevel">The mip level</param>
        /// <returns>The uint</returns>
        internal static uint GetDimension(uint largestLevelDimension, uint mipLevel)
        {
            uint ret = largestLevelDimension;
            for (uint i = 0; i < mipLevel; i++)
            {
                ret /= 2;
            }

            return Math.Max(1, ret);
        }

        /// <summary>
        /// Computes the subresource offset using the specified tex
        /// </summary>
        /// <param name="tex">The tex</param>
        /// <param name="mipLevel">The mip level</param>
        /// <param name="arrayLayer">The array layer</param>
        /// <returns>The ulong</returns>
        internal static ulong ComputeSubresourceOffset(Texture tex, uint mipLevel, uint arrayLayer)
        {
            Debug.Assert((tex.Usage & TextureUsage.Staging) == TextureUsage.Staging);
            return ComputeArrayLayerOffset(tex, arrayLayer) + ComputeMipOffset(tex, mipLevel);
        }

        /// <summary>
        /// Computes the mip offset using the specified tex
        /// </summary>
        /// <param name="tex">The tex</param>
        /// <param name="mipLevel">The mip level</param>
        /// <returns>The offset</returns>
        internal static uint ComputeMipOffset(Texture tex, uint mipLevel)
        {
            uint blockSize = FormatHelpers.IsCompressedFormat(tex.Format) ? 4u : 1u;
            uint offset = 0;
            for (uint level = 0; level < mipLevel; level++)
            {
                GetMipDimensions(tex, level, out uint mipWidth, out uint mipHeight, out uint mipDepth);
                uint storageWidth = Math.Max(mipWidth, blockSize);
                uint storageHeight = Math.Max(mipHeight, blockSize);
                offset += FormatHelpers.GetRegionSize(storageWidth, storageHeight, mipDepth, tex.Format);
            }

            return offset;
        }

        /// <summary>
        /// Computes the array layer offset using the specified tex
        /// </summary>
        /// <param name="tex">The tex</param>
        /// <param name="arrayLayer">The array layer</param>
        /// <returns>The uint</returns>
        internal static uint ComputeArrayLayerOffset(Texture tex, uint arrayLayer)
        {
            if (arrayLayer == 0)
            {
                return 0;
            }

            uint blockSize = FormatHelpers.IsCompressedFormat(tex.Format) ? 4u : 1u;
            uint layerPitch = 0;
            for (uint level = 0; level < tex.MipLevels; level++)
            {
                GetMipDimensions(tex, level, out uint mipWidth, out uint mipHeight, out uint mipDepth);
                uint storageWidth = Math.Max(mipWidth, blockSize);
                uint storageHeight = Math.Max(mipHeight, blockSize);
                layerPitch += FormatHelpers.GetRegionSize(storageWidth, storageHeight, mipDepth, tex.Format);
            }

            return layerPitch * arrayLayer;
        }

        /// <summary>
        /// Copies the texture region using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcX">The src</param>
        /// <param name="srcY">The src</param>
        /// <param name="srcZ">The src</param>
        /// <param name="srcRowPitch">The src row pitch</param>
        /// <param name="srcDepthPitch">The src depth pitch</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstX">The dst</param>
        /// <param name="dstY">The dst</param>
        /// <param name="dstZ">The dst</param>
        /// <param name="dstRowPitch">The dst row pitch</param>
        /// <param name="dstDepthPitch">The dst depth pitch</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="format">The format</param>
        public static unsafe void CopyTextureRegion(
            void* src,
            uint srcX, uint srcY, uint srcZ,
            uint srcRowPitch,
            uint srcDepthPitch,
            void* dst,
            uint dstX, uint dstY, uint dstZ,
            uint dstRowPitch,
            uint dstDepthPitch,
            uint width,
            uint height,
            uint depth,
            PixelFormat format)
        {
            uint blockSize = FormatHelpers.IsCompressedFormat(format) ? 4u : 1u;
            uint blockSizeInBytes = blockSize > 1 ? FormatHelpers.GetBlockSizeInBytes(format) : FormatSizeHelpers.GetSizeInBytes(format);
            uint compressedSrcX = srcX / blockSize;
            uint compressedSrcY = srcY / blockSize;
            uint compressedDstX = dstX / blockSize;
            uint compressedDstY = dstY / blockSize;
            uint numRows = FormatHelpers.GetNumRows(height, format);
            uint rowSize = width / blockSize * blockSizeInBytes;

            if (srcRowPitch == dstRowPitch && srcDepthPitch == dstDepthPitch)
            {
                uint totalCopySize = depth * srcDepthPitch;
                Buffer.MemoryCopy(
                    src,
                    dst,
                    totalCopySize,
                    totalCopySize);
            }
            else
            {
                for (uint zz = 0; zz < depth; zz++)
                    for (uint yy = 0; yy < numRows; yy++)
                    {
                        byte* rowCopyDst = (byte*)dst
                            + dstDepthPitch * (zz + dstZ)
                            + dstRowPitch * (yy + compressedDstY)
                            + blockSizeInBytes * compressedDstX;

                        byte* rowCopySrc = (byte*)src
                            + srcDepthPitch * (zz + srcZ)
                            + srcRowPitch * (yy + compressedSrcY)
                            + blockSizeInBytes * compressedSrcX;

                        Unsafe.CopyBlock(rowCopyDst, rowCopySrc, rowSize);
                    }
            }
        }

        /// <summary>
        /// Shallows the clone using the specified array
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="array">The array</param>
        /// <returns>The array</returns>
        internal static T[] ShallowClone<T>(T[] array)
        {
            return (T[])array.Clone();
        }

        /// <summary>
        /// Gets the buffer range using the specified resource
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <param name="additionalOffset">The additional offset</param>
        /// <returns>The device buffer range</returns>
        public static DeviceBufferRange GetBufferRange(BindableResource resource, uint additionalOffset)
        {
            if (resource is DeviceBufferRange range)
            {
                return new DeviceBufferRange(range.Buffer, range.Offset + additionalOffset, range.SizeInBytes);
            }
            else
            {
                DeviceBuffer buffer = (DeviceBuffer)resource;
                return new DeviceBufferRange(buffer, additionalOffset, buffer.SizeInBytes);
            }
        }

        /// <summary>
        /// Describes whether get device buffer
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <param name="buffer">The buffer</param>
        /// <returns>The bool</returns>
        public static bool GetDeviceBuffer(BindableResource resource, out DeviceBuffer buffer)
        {
            if (resource is DeviceBuffer db)
            {
                buffer = db;
                return true;
            }
            else if (resource is DeviceBufferRange range)
            {
                buffer = range.Buffer;
                return true;
            }

            buffer = null;
            return false;
        }

        /// <summary>
        /// Gets the texture view using the specified gd
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="resource">The resource</param>
        /// <exception cref="VeldridException">Unexpected resource type. Expected Texture or TextureView but found {resource.GetType().Name}</exception>
        /// <returns>The texture view</returns>
        internal static TextureView GetTextureView(GraphicsDevice gd, BindableResource resource)
        {
            if (resource is TextureView view)
            {
                return view;
            }
            else if (resource is Texture tex)
            {
                return tex.GetFullTextureView(gd);
            }
            else
            {
                throw new VeldridException(
                    $"Unexpected resource type. Expected Texture or TextureView but found {resource.GetType().Name}");
            }
        }

        /// <summary>
        /// Packs the int ptr using the specified source ptr
        /// </summary>
        /// <param name="sourcePtr">The source ptr</param>
        /// <param name="low">The low</param>
        /// <param name="high">The high</param>
        internal static void PackIntPtr(IntPtr sourcePtr, out uint low, out uint high)
        {
            ulong src64 = (ulong)sourcePtr;
            low = (uint)(src64 & 0x00000000FFFFFFFF);
            high = (uint)((src64 & 0xFFFFFFFF00000000u) >> 32);
        }

        /// <summary>
        /// Unpacks the int ptr using the specified low
        /// </summary>
        /// <param name="low">The low</param>
        /// <param name="high">The high</param>
        /// <returns>The int ptr</returns>
        internal static IntPtr UnpackIntPtr(uint low, uint high)
        {
            ulong src64 = low | ((ulong)high << 32);
            return (IntPtr)src64;
        }
    }
}
