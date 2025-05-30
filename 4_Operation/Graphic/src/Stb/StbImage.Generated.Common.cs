// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbImage.Generated.Common.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Stb.Hebron.Runtime;

namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The stb image class
    /// </summary>
    public partial class StbImage
    {
        /// <summary>
        ///     The stbi default
        /// </summary>
        public const int StbiDefault = 0;

        /// <summary>
        ///     The stbi grey
        /// </summary>
        public const int StbiGrey = 1;

        /// <summary>
        ///     The stbi grey alpha
        /// </summary>
        public const int StbiGreyAlpha = 2;

        /// <summary>
        ///     The stbi rgb
        /// </summary>
        public const int StbiRgb = 3;

        /// <summary>
        ///     The stbi rgb alpha
        /// </summary>
        public const int StbiRgbAlpha = 4;

        /// <summary>
        ///     The stbi order rgb
        /// </summary>
        public const int StbiOrderRgb = 0;

        /// <summary>
        ///     The stbi order bgr
        /// </summary>
        public const int StbiOrderBgr = 1;

        /// <summary>
        ///     The stbi scan load
        /// </summary>
        public const int StbiScanLoad = 0;

        /// <summary>
        ///     The stbi scan type
        /// </summary>
        public const int StbiScanType = 1;

        /// <summary>
        ///     The stbi scan header
        /// </summary>
        public const int StbiScanHeader = 2;

        /// <summary>
        ///     The stbi vertically flip on load global
        /// </summary>
        public static int StbiVerticallyFlipOnLoadGlobal;

        /// <summary>
        ///     The stbi vertically flip on load local
        /// </summary>
        public static int StbiVerticallyFlipOnLoadLocal;

        /// <summary>
        ///     The stbi vertically flip on load set
        /// </summary>
        public static int StbiVerticallyFlipOnLoadSet;

        /// <summary>
        ///     The stbi l2h gamma
        /// </summary>
        public static float StbiL2HGamma = 2.2f;

        /// <summary>
        ///     The stbi l2h scale
        /// </summary>
        public static float StbiL2HScale = 1.0f;

        /// <summary>
        ///     The stbi h2l gamma
        /// </summary>
        public static float StbiH2LGammaI = 1.0f / 2.2f;

        /// <summary>
        ///     The stbi h2l scale
        /// </summary>
        public static float StbiH2LScaleI = 1.0f;

        /// <summary>
        ///     The stbi unpremultiply on load global
        /// </summary>
        public static int StbiUnpremultiplyOnLoadGlobal;

        /// <summary>
        ///     The stbi de iphone flag global
        /// </summary>
        public static int StbiDeIphoneFlagGlobal;

        /// <summary>
        ///     The stbi unpremultiply on load local
        /// </summary>
        public static int StbiUnpremultiplyOnLoadLocal;

        /// <summary>
        ///     The stbi unpremultiply on load set
        /// </summary>
        public static int StbiUnpremultiplyOnLoadSet;

        /// <summary>
        ///     The stbi de iphone flag local
        /// </summary>
        public static int StbiDeIphoneFlagLocal;

        /// <summary>
        ///     The stbi de iphone flag set
        /// </summary>
        public static int StbiDeIphoneFlagSet;

        /// <summary>
        ///     The stbi process marker tag
        /// </summary>
        public static byte[] StbiProcessMarkerTag = {65, 100, 111, 98, 101, 0};

        /// <summary>
        ///     The stbi process frame header rgb
        /// </summary>
        public static byte[] StbiProcessFrameHeaderRgb = {82, 71, 66};

        /// <summary>
        ///     The stbi compute huffman codes length dezigzag
        /// </summary>
        public static byte[] StbiComputeHuffmanCodesLengthDezigzag =
            {16, 17, 18, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 14, 1, 15};

        /// <summary>
        ///     The stbi shiftsigned mul table
        /// </summary>
        public static int[] StbiShiftsignedMulTable = {0, 0xff, 0x55, 0x49, 0x11, 0x21, 0x41, 0x81, 0x01};

        /// <summary>
        ///     The stbi shiftsigned shift table
        /// </summary>
        public static int[] StbiShiftsignedShiftTable = {0, 0, 0, 1, 0, 2, 4, 6, 0};

        /// <summary>
        ///     Stbis the hdr to ldr gamma using the specified gamma
        /// </summary>
        /// <param name="gamma">The gamma</param>
        public static void Stbihdrtoldrgamma(float gamma)
        {
            StbiH2LGammaI = 1 / gamma;
        }

        /// <summary>
        ///     Stbis the hdr to ldr scale using the specified scale
        /// </summary>
        /// <param name="scale">The scale</param>
        public static void Stbihdrtoldrscale(float scale)
        {
            StbiH2LScaleI = 1 / scale;
        }

        /// <summary>
        ///     Stbis the ldr to hdr gamma using the specified gamma
        /// </summary>
        /// <param name="gamma">The gamma</param>
        public static void Stbildrtohdrgamma(float gamma)
        {
            StbiL2HGamma = gamma;
        }

        /// <summary>
        ///     Stbis the ldr to hdr scale using the specified scale
        /// </summary>
        /// <param name="scale">The scale</param>
        public static void Stbildrtohdrscale(float scale)
        {
            StbiL2HScale = scale;
        }

        /// <summary>
        ///     Stbis the set unpremultiply on load using the specified flag true if should unpremultiply
        /// </summary>
        /// <param name="flagTrueIfShouldUnpremultiply">The flag true if should unpremultiply</param>
        public static void Stbisetunpremultiplyonload(int flagTrueIfShouldUnpremultiply)
        {
            StbiUnpremultiplyOnLoadGlobal = flagTrueIfShouldUnpremultiply;
        }

        /// <summary>
        ///     Stbis the convert iphone png to rgb using the specified flag true if should convert
        /// </summary>
        /// <param name="flagTrueIfShouldConvert">The flag true if should convert</param>
        public static void Stbiconvertiphonepngtorgb(int flagTrueIfShouldConvert)
        {
            StbiDeIphoneFlagGlobal = flagTrueIfShouldConvert;
        }

        /// <summary>
        ///     Stbis the set flip vertically on load using the specified flag true if should flip
        /// </summary>
        /// <param name="flagTrueIfShouldFlip">The flag true if should flip</param>
        public static void Stbisetflipverticallyonload(int flagTrueIfShouldFlip)
        {
            StbiVerticallyFlipOnLoadGlobal = flagTrueIfShouldFlip;
        }

        /// <summary>
        ///     Stbis the set unpremultiply on load thread using the specified flag true if should unpremultiply
        /// </summary>
        /// <param name="flagTrueIfShouldUnpremultiply">The flag true if should unpremultiply</param>
        public static void Stbisetunpremultiplyonloadthread(int flagTrueIfShouldUnpremultiply)
        {
            StbiUnpremultiplyOnLoadLocal = flagTrueIfShouldUnpremultiply;
            StbiUnpremultiplyOnLoadSet = 1;
        }

        /// <summary>
        ///     Stbis the convert iphone png to rgb thread using the specified flag true if should convert
        /// </summary>
        /// <param name="flagTrueIfShouldConvert">The flag true if should convert</param>
        public static void Stbiconvertiphonepngtorgbthread(int flagTrueIfShouldConvert)
        {
            StbiDeIphoneFlagLocal = flagTrueIfShouldConvert;
            StbiDeIphoneFlagSet = 1;
        }

        /// <summary>
        ///     Stbis the set flip vertically on load thread using the specified flag true if should flip
        /// </summary>
        /// <param name="flagTrueIfShouldFlip">The flag true if should flip</param>
        public static void Stbisetflipverticallyonloadthread(int flagTrueIfShouldFlip)
        {
            StbiVerticallyFlipOnLoadLocal = flagTrueIfShouldFlip;
            StbiVerticallyFlipOnLoadSet = 1;
        }

/// <summary>
///     Stbis the malloc using the specified size
/// </summary>
/// <param name="size">The size</param>
/// <returns>The IntPtr</returns>
public static IntPtr Stbimalloc(ulong size) => CRuntime.Malloc((long)size);

        /// <summary>
        ///     Stbis the addsizes valid using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        public static int Stbiaddsizesvalid(int a, int b)
        {
            if (b < 0)
            {
                return 0;
            }

            return a <= 2147483647 - b ? 1 : 0;
        }

        /// <summary>
        ///     Stbis the mul 2sizes valid using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        public static int Stbimul2Sizesvalid(int a, int b)
        {
            if (a < 0 || b < 0)
            {
                return 0;
            }

            if (b == 0)
            {
                return 1;
            }

            return a <= 2147483647 / b ? 1 : 0;
        }

        /// <summary>
        ///     Stbis the mad 2sizes valid using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="add">The add</param>
        /// <returns>The int</returns>
        public static int Stbimad2Sizesvalid(int a, int b, int add) => (Stbimul2Sizesvalid(a, b) != 0) && (Stbiaddsizesvalid(a * b, add) != 0) ? 1 : 0;

        /// <summary>
        ///     Stbis the mad 3sizes valid using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="add">The add</param>
        /// <returns>The int</returns>
        public static int Stbimad3Sizesvalid(int a, int b, int c, int add) => (Stbimul2Sizesvalid(a, b) != 0) && (Stbimul2Sizesvalid(a * b, c) != 0) &&
                                                                                 (Stbiaddsizesvalid(a * b * c, add) != 0)
            ? 1
            : 0;

        /// <summary>
        ///     Stbis the mad 4sizes valid using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="add">The add</param>
        /// <returns>The int</returns>
        public static int Stbimad4Sizesvalid(int a, int b, int c, int d, int add) => (Stbimul2Sizesvalid(a, b) != 0) && (Stbimul2Sizesvalid(a * b, c) != 0) &&
                                                                                        (Stbimul2Sizesvalid(a * b * c, d) != 0) && (Stbiaddsizesvalid(a * b * c * d, add) != 0)
            ? 1
            : 0;

        /// <summary>
        ///     Stbis the malloc mad 2 using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="add">The add</param>
        /// <returns>The void</returns>
        public static IntPtr StbiMallocMad2(int a, int b, int add)
        {
            if (Stbimad2Sizesvalid(a, b, add) == 0)
            {
                return IntPtr.Zero;
            }
        
            return Stbimalloc((ulong)(a * b + add));
        }

        /// <summary>
        ///     Stbis the malloc mad 3 using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="add">The add</param>
        /// <returns>The void</returns>
       public static IntPtr Stbimallocmad3(int a, int b, int c, int add)
       {
           if (Stbimad3Sizesvalid(a, b, c, add) == 0)
           {
               return IntPtr.Zero;
           }
       
           return Stbimalloc((ulong)(a * b * c + add));
       }

        /// <summary>
        ///     Stbis the malloc mad 4 using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="add">The add</param>
        /// <returns>The void</returns>
        public static IntPtr Stbimallocmad4(int a, int b, int c, int d, int add)
        {
            if (Stbimad4Sizesvalid(a, b, c, d, add) == 0)
            {
                return IntPtr.Zero;
            }
        
            return Stbimalloc((ulong)(a * b * c * d + add));
        }

        /// <summary>
        ///     Stbis the addints valid using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        public static int Stbiaddintsvalid(int a, int b)
        {
            if (a >= 0 != b >= 0)
            {
                return 1;
            }

            if ((a < 0) && (b < 0))
            {
                return a >= -2147483647 - 1 - b ? 1 : 0;
            }

            return a <= 2147483647 - b ? 1 : 0;
        }

        /// <summary>
        ///     Stbis the mul 2shorts valid using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        public static int Stbimul2Shortsvalid(int a, int b)
        {
            if (b == 0 || b == -1)
            {
                return 1;
            }

            if (a >= 0 == b >= 0)
            {
                return a <= 32767 / b ? 1 : 0;
            }

            if (b < 0)
            {
                return a <= -32768 / b ? 1 : 0;
            }

            return a >= -32768 / b ? 1 : 0;
        }

        /// <summary>
        ///     Stbis the ldr to hdr using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <returns>The output</returns>
        public static IntPtr Stbildrtohdr(IntPtr data, int x, int y, int comp)
        {
            if (data == IntPtr.Zero)
            {
                return IntPtr.Zero;
            }
        
            IntPtr output = Stbimallocmad4(x, y, comp, sizeof(float), 0);
            if (output == IntPtr.Zero)
            {
                CRuntime.Free(data);
                throw new OutOfMemoryException("outofmem");
            }
        
            int n = (comp & 1) != 0 ? comp : comp - 1;
        
            for (int i = 0; i < x * y; ++i)
            {
                for (int k = 0; k < n; ++k)
                {
                    float value = (float)(Marshal.ReadByte(data, (i * comp + k)) / 255.0f);
                    Marshal.WriteInt32(output, (i * comp + k) * sizeof(float), 
                        BitConverter.ToInt32(BitConverter.GetBytes(Math.Pow(value, StbiL2HGamma) * StbiL2HScale), 0));
                }
            }
        
            if (n < comp)
            {
                for (int i = 0; i < x * y; ++i)
                {
                    float value = Marshal.ReadByte(data, (i * comp + n)) / 255.0f;
                    Marshal.WriteInt32(output, (i * comp + n) * sizeof(float), 
                        BitConverter.ToInt32(BitConverter.GetBytes(value), 0));
                }
            }
        
            CRuntime.Free(data);
            return output;
        }

        /// <summary>
        ///     Stbis the load main using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <param name="reqComp">The req comp</param>
        /// <param name="ri">The ri</param>
        /// <param name="bpc">The bpc</param>
        /// <returns>The void</returns>
       public static IntPtr Stbiloadmain(StbiContext s, out int x, out int y, out int comp, int reqComp, out StbiResultInfo ri, int bpc)
{
    x = 0;
    y = 0;
    comp = 0;
    ri = new StbiResultInfo
    {
        BitsPerChannel = 8,
        ChanneLorder = StbiOrderRgb,
        NumChannels = 0
    };



    if (Stbibmptest(s) != 0)
    {
        return Stbibmpload(s, out x, out y, out comp, reqComp, out ri);
    }

    throw new InvalidOperationException("unknown image type");
}
        /// <summary>
        ///     Stbis the convert 16 to 8 using the specified orig
        /// </summary>
        /// <param name="orig">The orig</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="channels">The channels</param>
        /// <returns>The reduced</returns>
       public static IntPtr Stbiconvert16To8(IntPtr orig, int w, int h, int channels)
       {
           int imgLen = w * h * channels;
           byte[] reduced = new byte[imgLen];
       
           if (orig == IntPtr.Zero)
           {
               throw new OutOfMemoryException("outofmem");
           }
       
           for (int i = 0; i < imgLen; ++i)
           {
               short value = Marshal.ReadInt16(orig, i * sizeof(ushort));
               reduced[i] = (byte)((value >> 8) & 0xFF);
           }
       
           CRuntime.Free(orig);
           
           
           
           // Asignar memoria no administrada y copiar los datos
           IntPtr unmanagedOutput = Marshal.AllocHGlobal(reduced.Length);
           Marshal.Copy(reduced, 0, unmanagedOutput, reduced.Length);

           return unmanagedOutput;
       }
        /// <summary>
        ///     Stbis the convert 8 to 16 using the specified orig
        /// </summary>
        /// <param name="orig">The orig</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="channels">The channels</param>
        /// <returns>The enlarged</returns>
      public static IntPtr StbiConvert8To16(IntPtr orig, int w, int h, int channels)
      {
          int imgLen = w * h * channels;
          IntPtr enlargedPtr = Marshal.AllocHGlobal(imgLen * sizeof(ushort));
      
          if (orig == IntPtr.Zero)
          {
              throw new OutOfMemoryException("outofmem");
          }
      
          for (int i = 0; i < imgLen; ++i)
          {
            byte value = Marshal.ReadByte(orig, i);
            Marshal.WriteInt16(enlargedPtr, i * sizeof(ushort), (short)((value << 8) + value));
          }
      
          CRuntime.Free(orig);
          return enlargedPtr;
      }
       public static void StbiVerticalFlip(IntPtr image, int w, int h, int bytesPerPixel)
        {
            int bytesPerRow = w * bytesPerPixel;
            byte[] temp = new byte[2048];
            byte[] row0 = new byte[bytesPerRow];
            byte[] row1 = new byte[bytesPerRow];
        
            for (int row = 0; row < h / 2; row++)
            {
                IntPtr row0Ptr = IntPtr.Add(image, row * bytesPerRow);
                IntPtr row1Ptr = IntPtr.Add(image, (h - row - 1) * bytesPerRow);
        
                Marshal.Copy(row0Ptr, row0, 0, bytesPerRow);
                Marshal.Copy(row1Ptr, row1, 0, bytesPerRow);
        
                Array.Copy(row0, temp, bytesPerRow);
                Array.Copy(row1, row0, bytesPerRow);
                Array.Copy(temp, row1, bytesPerRow);
        
                Marshal.Copy(row0, 0, row0Ptr, bytesPerRow);
                Marshal.Copy(row1, 0, row1Ptr, bytesPerRow);
            }
        }

        public static void StbiVerticalFlipSlices(IntPtr image, int w, int h, int z, int bytesPerPixel)
        {
            int sliceSize = w * h * bytesPerPixel;
        
            for (int slice = 0; slice < z; ++slice)
            {
                IntPtr slicePtr = IntPtr.Add(image, slice * sliceSize);
                StbiVerticalFlip(slicePtr, w, h, bytesPerPixel);
            }
        }
        
        public static IntPtr StbiLoadAndPostprocess8Bit(StbiContext s, out int x, out int y, out int comp, int reqComp)
        {
            x = 0;
            y = 0;
            comp = 0;
        
            StbiResultInfo ri = new StbiResultInfo();
            IntPtr result = Stbiloadmain(s, out x, out y, out comp, reqComp, out ri, 8);
            if (result == IntPtr.Zero)
            {
                return IntPtr.Zero;
            }
        
            try
            {
                if (ri.BitsPerChannel != 8)
                {
                    result = Stbiconvert16To8(result, x, y, reqComp == 0 ? comp : reqComp);
                    ri.BitsPerChannel = 8;
                }
        
                if ((StbiVerticallyFlipOnLoadSet != 0
                        ? StbiVerticallyFlipOnLoadLocal
                        : StbiVerticallyFlipOnLoadGlobal) != 0)
                {
                    int channels = reqComp != 0 ? reqComp : comp;
                    StbiVerticalFlip(result, x, y, channels);
                }
        
                int dataSize = x * y * (reqComp != 0 ? reqComp : comp);
                byte[] data = new byte[dataSize];
                Marshal.Copy(result, data, 0, dataSize);
        
                // Asignar memoria no administrada y copiar los datos
                IntPtr unmanagedOutput = Marshal.AllocHGlobal(data.Length);
                Marshal.Copy(data, 0, unmanagedOutput, data.Length);

                return unmanagedOutput;
            }
            finally
            {
                if (result != IntPtr.Zero)
                {
                    CRuntime.Free(result);
                }
            }
        }
        
        public static ushort[] StbiLoadAndPostprocess16Bit(StbiContext s, out int x, out int y, out int comp, int reqComp)
        {
            x = 0;
            y = 0;
            comp = 0;
        
            StbiResultInfo ri = new StbiResultInfo();
            IntPtr result = Stbiloadmain(s, out x, out y, out comp, reqComp, out ri, 16);
            if (result == IntPtr.Zero)
            {
                return null;
            }
        
            try
            {
                if (ri.BitsPerChannel != 16)
                {
                    result = StbiConvert8To16(result, x, y, reqComp == 0 ? comp : reqComp);
                    ri.BitsPerChannel = 16;
                }
        
                if ((StbiVerticallyFlipOnLoadSet != 0
                        ? StbiVerticallyFlipOnLoadLocal
                        : StbiVerticallyFlipOnLoadGlobal) != 0)
                {
                    int channels = reqComp != 0 ? reqComp : comp;
                    StbiVerticalFlip(result, x, y, channels * sizeof(ushort));
                }
        
             int dataSize = x * y * (reqComp != 0 ? reqComp : comp);
             ushort[] data = new ushort[dataSize];
             
             for (int i = 0; i < dataSize; i++)
             {
                 data[i] = (ushort)Marshal.ReadInt16(result, i * sizeof(ushort));
             }
             
             return data;
            }
            finally
            {
                if (result != IntPtr.Zero)
                {
                    CRuntime.Free(result);
                }
            }
        }

        public static void StbiFloatPostprocess(IntPtr result, ref int x, ref int y, ref int comp, int reqComp)
{
    if (((StbiVerticallyFlipOnLoadSet != 0
            ? StbiVerticallyFlipOnLoadLocal
            : StbiVerticallyFlipOnLoadGlobal) != 0) && result != IntPtr.Zero)
    {
        int channels = reqComp != 0 ? reqComp : comp;
        StbiVerticalFlip(result, x, y, channels * sizeof(float));
    }
}

public static IntPtr StbiLoadfMain(StbiContext s, ref int x, ref int y, ref int comp, int reqComp)
{
    IntPtr data = StbiLoadAndPostprocess8Bit(s, out x, out y, out comp, reqComp);
    if (data != IntPtr.Zero)
    {
        return Stbildrtohdr(data, x, y, reqComp != 0 ? reqComp : comp);
    }

    return IntPtr.Zero;
}
        /// <summary>
        ///     Stbis the get 16be using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The int</returns>
        public static int Stbiget16Be(StbiContext s)
        {
            int z = stbi__get8(s);
            return (z << 8) + stbi__get8(s);
        }

        /// <summary>
        ///     Stbis the get 32be using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The uint</returns>
        public static uint Stbiget32Be(StbiContext s)
        {
            uint z = (uint) Stbiget16Be(s);
            return (uint) ((z << 16) + Stbiget16Be(s));
        }

        /// <summary>
        ///     Stbis the get 16le using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The int</returns>
        public static int Stbiget16Le(StbiContext s)
        {
            int z = stbi__get8(s);
            return z + (stbi__get8(s) << 8);
        }

        /// <summary>
        ///     Stbis the get 32le using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The </returns>
        public static uint Stbiget32Le(StbiContext s)
        {
            uint z = (uint) Stbiget16Le(s);
            z += (uint) Stbiget16Le(s) << 16;
            return z;
        }

        /// <summary>
        ///     Stbis the compute y using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The byte</returns>
        public static byte Stbicomputey(int r, int g, int b) => (byte) ((r * 77 + g * 150 + 29 * b) >> 8);

        /// <summary>
        ///     Stbis the convert format using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="imgN">The img</param>
        /// <param name="reqComp">The req comp</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The good</returns>
        public static IntPtr Stbiconvertformat(IntPtr data, int imgN, int reqComp, uint x, uint y)
        {
            if (reqComp == imgN)
            {
                return data;
            }
        
            IntPtr good = Stbimallocmad3(reqComp, (int)x, (int)y, 0);
            if (good == IntPtr.Zero)
            {
                CRuntime.Free(data);
                throw new OutOfMemoryException("outofmem");
            }
        
            for (int j = 0; j < (int)y; ++j)
            {
                for (int i = 0; i < (int)x; ++i)
                {
                    int srcOffset = (j * (int)x + i) * imgN;
                    int destOffset = (j * (int)x + i) * reqComp;
        
                    switch (imgN * 8 + reqComp)
                    {
                        case 1 * 8 + 2:
                            Marshal.WriteByte(good, destOffset, Marshal.ReadByte(data, srcOffset));
                            Marshal.WriteByte(good, destOffset + 1, 255);
                            break;
                        case 1 * 8 + 3:
                            byte value = Marshal.ReadByte(data, srcOffset);
                            Marshal.WriteByte(good, destOffset, value);
                            Marshal.WriteByte(good, destOffset + 1, value);
                            Marshal.WriteByte(good, destOffset + 2, value);
                            break;
                        case 1 * 8 + 4:
                            value = Marshal.ReadByte(data, srcOffset);
                            Marshal.WriteByte(good, destOffset, value);
                            Marshal.WriteByte(good, destOffset + 1, value);
                            Marshal.WriteByte(good, destOffset + 2, value);
                            Marshal.WriteByte(good, destOffset + 3, 255);
                            break;
                        case 2 * 8 + 1:
                            Marshal.WriteByte(good, destOffset, Marshal.ReadByte(data, srcOffset));
                            break;
                        case 2 * 8 + 3:
                            value = Marshal.ReadByte(data, srcOffset);
                            Marshal.WriteByte(good, destOffset, value);
                            Marshal.WriteByte(good, destOffset + 1, value);
                            Marshal.WriteByte(good, destOffset + 2, value);
                            break;
                        case 2 * 8 + 4:
                            Marshal.WriteByte(good, destOffset, Marshal.ReadByte(data, srcOffset));
                            Marshal.WriteByte(good, destOffset + 1, Marshal.ReadByte(data, srcOffset + 1));
                            break;
                        case 3 * 8 + 4:
                            Marshal.WriteByte(good, destOffset, Marshal.ReadByte(data, srcOffset));
                            Marshal.WriteByte(good, destOffset + 1, Marshal.ReadByte(data, srcOffset + 1));
                            Marshal.WriteByte(good, destOffset + 2, Marshal.ReadByte(data, srcOffset + 2));
                            Marshal.WriteByte(good, destOffset + 3, 255);
                            break;
                        case 3 * 8 + 1:
                            Marshal.WriteByte(good, destOffset, Stbicomputey(
                                Marshal.ReadByte(data, srcOffset),
                                Marshal.ReadByte(data, srcOffset + 1),
                                Marshal.ReadByte(data, srcOffset + 2)));
                            break;
                        case 3 * 8 + 2:
                            Marshal.WriteByte(good, destOffset, Stbicomputey(
                                Marshal.ReadByte(data, srcOffset),
                                Marshal.ReadByte(data, srcOffset + 1),
                                Marshal.ReadByte(data, srcOffset + 2)));
                            Marshal.WriteByte(good, destOffset + 1, 255);
                            break;
                        case 4 * 8 + 1:
                            Marshal.WriteByte(good, destOffset, Stbicomputey(
                                Marshal.ReadByte(data, srcOffset),
                                Marshal.ReadByte(data, srcOffset + 1),
                                Marshal.ReadByte(data, srcOffset + 2)));
                            break;
                        case 4 * 8 + 2:
                            Marshal.WriteByte(good, destOffset, Stbicomputey(
                                Marshal.ReadByte(data, srcOffset),
                                Marshal.ReadByte(data, srcOffset + 1),
                                Marshal.ReadByte(data, srcOffset + 2)));
                            Marshal.WriteByte(good, destOffset + 1, Marshal.ReadByte(data, srcOffset + 3));
                            break;
                        case 4 * 8 + 3:
                            Marshal.WriteByte(good, destOffset, Marshal.ReadByte(data, srcOffset));
                            Marshal.WriteByte(good, destOffset + 1, Marshal.ReadByte(data, srcOffset + 1));
                            Marshal.WriteByte(good, destOffset + 2, Marshal.ReadByte(data, srcOffset + 2));
                            break;
                        default:
                            CRuntime.Free(data);
                            CRuntime.Free(good);
                            throw new InvalidOperationException("unsupported");
                    }
                }
            }
        
            CRuntime.Free(data);
            return good;
        }

        /// <summary>
        ///     Stbis the compute y 16 using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The ushort</returns>
        public static ushort Stbicomputey16(int r, int g, int b) => (ushort) ((r * 77 + g * 150 + 29 * b) >> 8);

        /// <summary>
        ///     Stbis the convert format 16 using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="imgN">The img</param>
        /// <param name="reqComp">The req comp</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The good</returns>
        public static IntPtr Stbiconvertformat16(IntPtr data, int imgN, int reqComp, uint x, uint y)
        {
            if (reqComp == imgN)
            {
                return data;
            }
        
            IntPtr good = Stbimalloc((ulong)(reqComp * x * y * 2));
            if (good == IntPtr.Zero)
            {
                CRuntime.Free(data);
                throw new OutOfMemoryException("outofmem");
            }
        
            for (int j = 0; j < (int)y; ++j)
            {
                for (int i = 0; i < (int)x; ++i)
                {
                    int srcOffset = (j * (int)x + i) * imgN * sizeof(ushort);
                    int destOffset = (j * (int)x + i) * reqComp * sizeof(ushort);
        
                    switch (imgN * 8 + reqComp)
                    {
                        case 1 * 8 + 3:
                            short value1 = Marshal.ReadInt16(data, srcOffset);
                            Marshal.WriteInt16(good, destOffset, value1);
                            Marshal.WriteInt16(good, destOffset + sizeof(ushort), value1);
                            Marshal.WriteInt16(good, destOffset + 2 * sizeof(ushort), value1);
                            break;
                        case 2 * 8 + 1:
                            Marshal.WriteInt16(good, destOffset, Marshal.ReadInt16(data, srcOffset));
                            break;
                        case 2 * 8 + 3:
                            value1 = Marshal.ReadInt16(data, srcOffset);
                            Marshal.WriteInt16(good, destOffset, value1);
                            Marshal.WriteInt16(good, destOffset + sizeof(ushort), value1);
                            Marshal.WriteInt16(good, destOffset + 2 * sizeof(ushort), value1);
                            break;
                        case 2 * 8 + 4:
                            Marshal.WriteInt16(good, destOffset, Marshal.ReadInt16(data, srcOffset));
                            Marshal.WriteInt16(good, destOffset + 3 * sizeof(ushort), Marshal.ReadInt16(data, srcOffset + sizeof(ushort)));
                            break;
                        case 4 * 8 + 3:
                            Marshal.WriteInt16(good, destOffset, Marshal.ReadInt16(data, srcOffset));
                            Marshal.WriteInt16(good, destOffset + sizeof(ushort), Marshal.ReadInt16(data, srcOffset + sizeof(ushort)));
                            Marshal.WriteInt16(good, destOffset + 2 * sizeof(ushort), Marshal.ReadInt16(data, srcOffset + 2 * sizeof(ushort)));
                            break;
                        default:
                            CRuntime.Free(data);
                            CRuntime.Free(good);
                            throw new InvalidOperationException("unsupported");
                    }
                }
            }
        
            CRuntime.Free(data);
            return good;
        }

        /// <summary>
        ///     Stbis the clamp using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        public static byte Stbiclamp(int x)
        {
            if ((uint) x > 255)
            {
                if (x < 0)
                {
                    return 0;
                }

                if (x > 255)
                {
                    return 255;
                }
            }

            return (byte) x;
        }

        /// <summary>
        ///     Stbis the blinn 8x 8 using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The byte</returns>
        public static byte Stbiblinn8X8(byte x, byte y)
        {
            uint t = (uint) (x * y + 128);
            return (byte) ((t + (t >> 8)) >> 8);
        }

        /// <summary>
        ///     Stbis the bitreverse 16 using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <returns>The </returns>
        public static int Stbibitreverse16(int n)
        {
            n = ((n & 0xAAAA) >> 1) | ((n & 0x5555) << 1);
            n = ((n & 0xCCCC) >> 2) | ((n & 0x3333) << 2);
            n = ((n & 0xF0F0) >> 4) | ((n & 0x0F0F) << 4);
            n = ((n & 0xFF00) >> 8) | ((n & 0x00FF) << 8);
            return n;
        }

        /// <summary>
        ///     Stbis the bit reverse using the specified v
        /// </summary>
        /// <param name="v">The </param>
        /// <param name="bits">The bits</param>
        /// <returns>The int</returns>
        public static int Stbibitreverse(int v, int bits) => Stbibitreverse16(v) >> (16 - bits);

        /// <summary>
        ///     Stbis the high bit using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <returns>The </returns>
        public static int Stbihighbit(uint z)
        {
            int n = 0;
            if (z == 0)
            {
                return -1;
            }

            if (z >= 0x10000)
            {
                n += 16;
                z >>= 16;
            }

            if (z >= 0x00100)
            {
                n += 8;
                z >>= 8;
            }

            if (z >= 0x00010)
            {
                n += 4;
                z >>= 4;
            }

            if (z >= 0x00004)
            {
                n += 2;
                z >>= 2;
            }

            if (z >= 0x00002)
            {
                n += 1;
            }

            return n;
        }

        /// <summary>
        ///     Stbis the bitcount using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        public static int Stbibitcount(uint a)
        {
            a = (a & 0x55555555) + ((a >> 1) & 0x55555555);
            a = (a & 0x33333333) + ((a >> 2) & 0x33333333);
            a = (a + (a >> 4)) & 0x0f0f0f0f;
            a = a + (a >> 8);
            a = a + (a >> 16);
            return (int) (a & 0xff);
        }

        /// <summary>
        ///     Stbis the shiftsigned using the specified v
        /// </summary>
        /// <param name="v">The </param>
        /// <param name="shift">The shift</param>
        /// <param name="bits">The bits</param>
        /// <returns>The int</returns>
        public static int Stbishiftsigned(uint v, int shift, int bits)
        {
            if (shift < 0)
            {
                v <<= -shift;
            }
            else
            {
                v >>= shift;
            }

            v >>= 8 - bits;
            return (int) (v * StbiShiftsignedMulTable[bits]) >> StbiShiftsignedShiftTable[bits];
        }

        /// <summary>
        ///     Stbis the info main using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <returns>The int</returns>
   public static int Stbiinfomain(StbiContext s, out int x, out int y, out int comp)
   {
       x = 0;
       y = 0;
       comp = 0;
       
       if (Stbibmpinfo(s, out x, out y, out comp) != 0)
       {
           return 1;
       }
   
       return stbi__err("unknown image type");
   }

        /// <summary>
        ///     Stbis the is 16 main using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The int</returns>
        public static int Stbiis16Main(StbiContext s)
        {
            return 0;
        }
    }
}