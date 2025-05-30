// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbImage.Generated.Jpg.cs
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
using Alis.Core.Graphic.Stb.Hebron.Runtime;

namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The stb image class
    /// </summary>
    partial class StbImage
    {
        /// <summary>
        ///     The delegate
        /// </summary>
        public delegate void Delegate0(byte* arg0, int arg1, short* arg2);

        /// <summary>
        ///     The delegate
        /// </summary>
        public delegate void Delegate1(byte* arg0, byte* arg1, byte* arg2, byte* arg3, int arg4, int arg5);

        /// <summary>
        ///     The delegate
        /// </summary>
        public delegate byte* Delegate2(byte* arg0, byte* arg1, byte* arg2, int arg3, int arg4);

        /// <summary>
        ///     The stbi bmask
        /// </summary>
        public static uint[] StbiBmask =
            {0, 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023, 2047, 4095, 8191, 16383, 32767, 65535};

        /// <summary>
        ///     The stbi jbias
        /// </summary>
        public static int[] StbiJbias =
            {0, -1, -3, -7, -15, -31, -63, -127, -255, -511, -1023, -2047, -4095, -8191, -16383, -32767};

        /// <summary>
        ///     The stbi jpeg dezigzag
        /// </summary>
        public static byte[] StbiJpegDezigzag =
        {
            0, 1, 8, 16, 9, 2, 3, 10, 17, 24, 32, 25, 18, 11, 4, 5, 12, 19, 26, 33, 40, 48, 41, 34, 27, 20, 13, 6, 7,
            14, 21, 28, 35, 42, 49, 56, 57, 50, 43, 36, 29, 22, 15, 23, 30, 37, 44, 51, 58, 59, 52, 45, 38, 31, 39, 46,
            53, 60, 61, 54, 47, 55, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63
        };

        /// <summary>
        ///     Stbis the jpeg test using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The </returns>
        public static int stbi__jpeg_test(StbiContext s)
        {
            int r = 0;
            StbiJpeg j = new StbiJpeg();
            if (j == null)
            {
                return stbi__err("outofmem");
            }

            j.S = s;
            Stbisetupjpeg(j);
            r = Stbidecodejpegheader(j, StbiScanType);
            Stbirewind(s);
            return r;
        }
        
public static byte[] Stbijpegload(StbiContext s, out int x, out int y, out int comp, int reqComp)
{
    StbiJpeg j = new StbiJpeg();
    if (j == null)
    {
        throw new InvalidOperationException(StbImage.StbiGFailureReason ?? "outofmem");
    }

    j.S = s;
    Stbisetupjpeg(j);
    return Loadjpegimage(j, out x, out y, out comp, reqComp);
}

        /// <summary>
        ///     Stbis the jpeg info using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <returns>The result</returns>
        public static int Stbijpeginfo(StbiContext s, out int x, out int y, out int comp)
        {
            x = 0;
            y = 0;
            comp = 0;

            StbiJpeg j = new StbiJpeg();
            if (j == null)
            {
                return stbi__err("outofmem");
            }

            j.S = s;
            int result = Stbijpeginforaw(j, out x, out y, out comp);
            return result;
        }

        /// <summary>
        ///     Stbis the build huffman using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        public static int Stbibuildhuffman(StbiHuffman h, int[] count)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            uint code = 0;

            h.Size = new byte[257];
            h.Code = new ushort[257];
            h.Maxcode = new uint[17];
            h.Delta = new int[17];
            h.Fast = new byte[1 << 9];

            for (i = 0; i < 16; ++i)
            {
                for (j = 0; j < count[i]; ++j)
                {
                    h.Size[k++] = (byte) (i + 1);
                    if (k >= 257)
                    {
                        return stbi__err("bad size list");
                    }
                }
            }

            h.Size[k] = 0;
            code = 0;
            k = 0;

            for (j = 1; j <= 16; ++j)
            {
                h.Delta[j] = (int) (k - code);
                if (h.Size[k] == j)
                {
                    while (h.Size[k] == j)
                    {
                        h.Code[k++] = (ushort) code++;
                    }

                    if (code - 1 >= 1u << j)
                    {
                        return stbi__err("bad code lengths");
                    }
                }

                h.Maxcode[j] = code << (16 - j);
                code <<= 1;
            }

            h.Maxcode[j] = 0xffffffff;
            Array.Fill(h.Fast, (byte) 255);

            for (i = 0; i < k; ++i)
            {
                int s = h.Size[i];
                if (s <= 9)
                {
                    int c = h.Code[i] << (9 - s);
                    int m = 1 << (9 - s);
                    for (j = 0; j < m; ++j)
                    {
                        h.Fast[c + j] = (byte) i;
                    }
                }
            }

            return 1;
        }
public static void Stbibuildfastac(short[] fastAc, StbiHuffman h)
{
    for (int i = 0; i < (1 << 9); ++i)
    {
        byte fast = h.Fast[i];
        fastAc[i] = 0;
        if (fast < 255)
        {
            int rs = h.Values[fast];
            int run = (rs >> 4) & 15;
            int magbits = rs & 15;
            int len = h.Size[fast];
            if ((magbits != 0) && (len + magbits <= 9))
            {
                int k = ((i << len) & ((1 << 9) - 1)) >> (9 - magbits);
                int m = 1 << (magbits - 1);
                if (k < m)
                {
                    k += (int)((~0U << magbits) + 1);
                }

                if ((k >= -128) && (k <= 127))
                {
                    fastAc[i] = (short)(k * 256 + run * 16 + len + magbits);
                }
            }
        }
    }
}

        /// <summary>
        ///     Stbis the grow buffer unsafe using the specified j
        /// </summary>
        /// <param name="j">The </param>
        public static void Stbigrowbufferunsafe(StbiJpeg j)
        {
            do
            {
                uint b = (uint) (j.Nomore != 0 ? 0 : stbi__get8(j.S));
                if (b == 0xff)
                {
                    int c = stbi__get8(j.S);
                    while (c == 0xff)
                    {
                        c = stbi__get8(j.S);
                    }

                    if (c != 0)
                    {
                        j.Marker = (byte) c;
                        j.Nomore = 1;
                        return;
                    }
                }

                j.CodeBuffer |= b << (24 - j.CodeBits);
                j.CodeBits += 8;
            } while (j.CodeBits <= 24);
        }

      public static int Stbijpeghuffdecode(StbiJpeg j, StbiHuffman h)
      {
          uint temp = 0;
          int c = 0;
          int k = 0;
      
          if (j.CodeBits < 16)
          {
              Stbigrowbufferunsafe(j);
          }
      
          c = (int)((j.CodeBuffer >> (32 - 9)) & ((1 << 9) - 1));
          k = h.Fast[c];
          if (k < 255)
          {
              int s = h.Size[k];
              if (s > j.CodeBits)
              {
                  return -1;
              }
      
              j.CodeBuffer <<= s;
              j.CodeBits -= s;
              return h.Values[k];
          }
      
          temp = j.CodeBuffer >> 16;
          for (k = 10; k < h.Maxcode.Length; ++k)
          {
              if (temp < h.Maxcode[k])
              {
                  break;
              }
          }
      
          if (k == h.Maxcode.Length)
          {
              j.CodeBits -= 16;
              return -1;
          }
      
          if (k > j.CodeBits)
          {
              return -1;
          }
      
          c = (int)(((j.CodeBuffer >> (32 - k)) & StbiBmask[k]) + h.Delta[k]);
          if (c < 0 || c >= h.Values.Length)
          {
              return -1;
          }
      
          j.CodeBits -= k;
          j.CodeBuffer <<= k;
          return h.Values[c];
      }

        /// <summary>
        ///     Stbis the extend receive using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <param name="n">The </param>
        /// <returns>The int</returns>
        public static int Stbiextendreceive(StbiJpeg j, int n)
        {
            uint k = 0;
            int sgn = 0;
            if (j.CodeBits < n)
            {
                Stbigrowbufferunsafe(j);
            }

            if (j.CodeBits < n)
            {
                return 0;
            }

            sgn = (int) (j.CodeBuffer >> 31);
            k = CRuntime._lrotl(j.CodeBuffer, n);
            j.CodeBuffer = k & ~StbiBmask[n];
            k &= StbiBmask[n];
            j.CodeBits -= n;
            return (int) (k + (StbiJbias[n] & (sgn - 1)));
        }

        /// <summary>
        ///     Stbis the jpeg get bits using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <param name="n">The </param>
        /// <returns>The int</returns>
        public static int Stbijpeggetbits(StbiJpeg j, int n)
        {
            uint k = 0;
            if (j.CodeBits < n)
            {
                Stbigrowbufferunsafe(j);
            }

            if (j.CodeBits < n)
            {
                return 0;
            }

            k = CRuntime._lrotl(j.CodeBuffer, n);
            j.CodeBuffer = k & ~StbiBmask[n];
            k &= StbiBmask[n];
            j.CodeBits -= n;
            return (int) k;
        }

        /// <summary>
        ///     Stbis the jpeg get bit using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <returns>The int</returns>
        public static int Stbijpeggetbit(StbiJpeg j)
        {
            uint k = 0;
            if (j.CodeBits < 1)
            {
                Stbigrowbufferunsafe(j);
            }

            if (j.CodeBits < 1)
            {
                return 0;
            }

            k = j.CodeBuffer;
            j.CodeBuffer <<= 1;
            --j.CodeBits;
            return (int) (k & 0x80000000);
        }

        /// <summary>
        ///     Stbis the jpeg decode block using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <param name="data">The data</param>
        /// <param name="hdc">The hdc</param>
        /// <param name="hac">The hac</param>
        /// <param name="fac">The fac</param>
        /// <param name="b">The </param>
        /// <param name="dequant">The dequant</param>
        /// <returns>The int</returns>
     public static int Stbijpegdecodeblock(StbiJpeg j, short[] data, StbiHuffman hdc, StbiHuffman hac,
         short[] fac, int b, ushort[] dequant)
     {
         int diff = 0;
         int dc = 0;
         int k = 0;
         int t = 0;
     
         if (j.CodeBits < 16)
         {
             Stbigrowbufferunsafe(j);
         }
     
         t = Stbijpeghuffdecode(j, hdc);
         if (t < 0 || t > 15)
         {
             return stbi__err("bad huffman code");
         }
     
         Array.Clear(data, 0, 64);
         diff = t != 0 ? Stbiextendreceive(j, t) : 0;
         if (Stbiaddintsvalid(j.ImgComp[b].dc_pred, diff) == 0)
         {
             return stbi__err("bad delta");
         }
     
         dc = j.ImgComp[b].dc_pred + diff;
         j.ImgComp[b].dc_pred = dc;
         if (Stbimul2Shortsvalid(dc, dequant[0]) == 0)
         {
             return stbi__err("can't merge dc and ac");
         }
     
         data[0] = (short)(dc * dequant[0]);
         k = 1;
     
         do
         {
             uint zig = 0;
             int c = 0;
             int r = 0;
             int s = 0;
     
             if (j.CodeBits < 16)
             {
                 Stbigrowbufferunsafe(j);
             }
     
             c = (int)((j.CodeBuffer >> (32 - 9)) & ((1 << 9) - 1));
             r = fac[c];
             if (r != 0)
             {
                 k += (r >> 4) & 15;
                 s = r & 15;
                 if (s > j.CodeBits)
                 {
                     return stbi__err("bad huffman code");
                 }
     
                 j.CodeBuffer <<= s;
                 j.CodeBits -= s;
                 zig = StbiJpegDezigzag[k++];
                 data[zig] = (short)((r >> 8) * dequant[zig]);
             }
             else
             {
                 int rs = Stbijpeghuffdecode(j, hac);
                 if (rs < 0)
                 {
                     return stbi__err("bad huffman code");
                 }
     
                 s = rs & 15;
                 r = rs >> 4;
                 if (s == 0)
                 {
                     if (rs != 0xf0)
                     {
                         break;
                     }
     
                     k += 16;
                 }
                 else
                 {
                     k += r;
                     zig = StbiJpegDezigzag[k++];
                     data[zig] = (short)(Stbiextendreceive(j, s) * dequant[zig]);
                 }
             }
         } while (k < 64);
     
         return 1;
     }

        /// <summary>
        ///     Stbis the jpeg decode block prog dc using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <param name="data">The data</param>
        /// <param name="hdc">The hdc</param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
       public static int Stbijpegdecodeblockprogdc(StbiJpeg j, short[] data, StbiHuffman hdc, int b)
       {
           int diff = 0;
           int dc = 0;
           int t = 0;
       
           if (j.SpecEnd != 0)
           {
               return stbi__err("can't merge dc and ac");
           }
       
           if (j.CodeBits < 16)
           {
               Stbigrowbufferunsafe(j);
           }
       
           if (j.SuccHigh == 0)
           {
               Array.Clear(data, 0, 64);
               t = Stbijpeghuffdecode(j, hdc);
               if (t < 0 || t > 15)
               {
                   return stbi__err("can't merge dc and ac");
               }
       
               diff = t != 0 ? Stbiextendreceive(j, t) : 0;
               if (Stbiaddintsvalid(j.ImgComp[b].dc_pred, diff) == 0)
               {
                   return stbi__err("bad delta");
               }
       
               dc = j.ImgComp[b].dc_pred + diff;
               j.ImgComp[b].dc_pred = dc;
               if (Stbimul2Shortsvalid(dc, 1 << j.SuccLow) == 0)
               {
                   return stbi__err("can't merge dc and ac");
               }
       
               data[0] = (short)(dc * (1 << j.SuccLow));
           }
           else
           {
               if (Stbijpeggetbit(j) != 0)
               {
                   data[0] += (short)(1 << j.SuccLow);
               }
           }
       
           return 1;
       }

        /// <summary>
        ///     Stbis the jpeg decode block prog ac using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <param name="data">The data</param>
        /// <param name="hac">The hac</param>
        /// <param name="fac">The fac</param>
        /// <returns>The int</returns>
       public static int Stbijpegdecodeblockprogac(StbiJpeg j, short[] data, StbiHuffman hac, short[] fac)
       {
           int k = 0;
           if (j.SpecStart == 0)
           {
               return stbi__err("can't merge dc and ac");
           }
       
           if (j.SuccHigh == 0)
           {
               int shift = j.SuccLow;
               if (j.EobRun != 0)
               {
                   --j.EobRun;
                   return 1;
               }
       
               k = j.SpecStart;
               do
               {
                   uint zig = 0;
                   int c = 0;
                   int r = 0;
                   int s = 0;
                   if (j.CodeBits < 16)
                   {
                       Stbigrowbufferunsafe(j);
                   }
       
                   c = (int)((j.CodeBuffer >> (32 - 9)) & ((1 << 9) - 1));
                   r = fac[c];
                   if (r != 0)
                   {
                       k += (r >> 4) & 15;
                       s = r & 15;
                       if (s > j.CodeBits)
                       {
                           return stbi__err("bad huffman code");
                       }
       
                       j.CodeBuffer <<= s;
                       j.CodeBits -= s;
                       zig = StbiJpegDezigzag[k++];
                       data[zig] = (short)((r >> 8) * (1 << shift));
                   }
                   else
                   {
                       int rs = Stbijpeghuffdecode(j, hac);
                       if (rs < 0)
                       {
                           return stbi__err("bad huffman code");
                       }
       
                       s = rs & 15;
                       r = rs >> 4;
                       if (s == 0)
                       {
                           if (r < 15)
                           {
                               j.EobRun = 1 << r;
                               if (r != 0)
                               {
                                   j.EobRun += Stbijpeggetbits(j, r);
                               }
       
                               --j.EobRun;
                               break;
                           }
       
                           k += 16;
                       }
                       else
                       {
                           k += r;
                           zig = StbiJpegDezigzag[k++];
                           data[zig] = (short)(Stbiextendreceive(j, s) * (1 << shift));
                       }
                   }
               } while (k <= j.SpecEnd);
           }
           else
           {
               short bit = (short)(1 << j.SuccLow);
               if (j.EobRun != 0)
               {
                   --j.EobRun;
                   for (k = j.SpecStart; k <= j.SpecEnd; ++k)
                   {
                       int index = StbiJpegDezigzag[k];
                       if (data[index] != 0)
                       {
                           if (Stbijpeggetbit(j) != 0)
                           {
                               if ((data[index] & bit) == 0)
                               {
                                   if (data[index] > 0)
                                   {
                                       data[index] += bit;
                                   }
                                   else
                                   {
                                       data[index] -= bit;
                                   }
                               }
                           }
                       }
                   }
               }
               else
               {
                   k = j.SpecStart;
                   do
                   {
                       int r = 0;
                       int s = 0;
                       int rs = Stbijpeghuffdecode(j, hac);
                       if (rs < 0)
                       {
                           return stbi__err("bad huffman code");
                       }
       
                       s = rs & 15;
                       r = rs >> 4;
                       if (s == 0)
                       {
                           if (r < 15)
                           {
                               j.EobRun = (1 << r) - 1;
                               if (r != 0)
                               {
                                   j.EobRun += Stbijpeggetbits(j, r);
                               }
       
                               r = 64;
                           }
                       }
                       else
                       {
                           if (s != 1)
                           {
                               return stbi__err("bad huffman code");
                           }
       
                           if (Stbijpeggetbit(j) != 0)
                           {
                               s = bit;
                           }
                           else
                           {
                               s = -bit;
                           }
                       }
       
                       while (k <= j.SpecEnd)
                       {
                           int index = StbiJpegDezigzag[k++];
                           if (data[index] != 0)
                           {
                               if (Stbijpeggetbit(j) != 0)
                               {
                                   if ((data[index] & bit) == 0)
                                   {
                                       if (data[index] > 0)
                                       {
                                           data[index] += bit;
                                       }
                                       else
                                       {
                                           data[index] -= bit;
                                       }
                                   }
                               }
                           }
                           else
                           {
                               if (r == 0)
                               {
                                   data[index] = (short)s;
                                   break;
                               }
       
                               --r;
                           }
                       }
                   } while (k <= j.SpecEnd);
               }
           }
       
           return 1;
       }
        /// <summary>
        ///     Stbis the idct block using the specified  out
        /// </summary>
        /// <param name="out">The out</param>
        /// <param name="outStride">The out stride</param>
        /// <param name="data">The data</param>
        public static void Stbiidctblock(byte[] output, int outStride, short[] data)
{
    int[] val = new int[64];
    for (int i = 0; i < 8; ++i)
    {
        if (data[i + 8] == 0 && data[i + 16] == 0 && data[i + 24] == 0 && data[i + 32] == 0 &&
            data[i + 40] == 0 && data[i + 48] == 0 && data[i + 56] == 0)
        {
            int dcterm = data[i] * 4;
            for (int j = 0; j < 8; ++j)
            {
                val[i + j * 8] = dcterm;
            }
        }
        else
        {
            int t0, t1, t2, t3, p1, p2, p3, p4, p5, x0, x1, x2, x3;
            p2 = data[i + 16];
            p3 = data[i + 48];
            p1 = (p2 + p3) * (int)(0.5411961f * 4096 + 0.5);
            t2 = p1 + p3 * (int)(-1.847759065f * 4096 + 0.5);
            t3 = p1 + p2 * (int)(0.765366865f * 4096 + 0.5);
            p2 = data[i];
            p3 = data[i + 32];
            t0 = (p2 + p3) * 4096;
            t1 = (p2 - p3) * 4096;
            x0 = t0 + t3;
            x3 = t0 - t3;
            x1 = t1 + t2;
            x2 = t1 - t2;
            t0 = data[i + 56];
            t1 = data[i + 40];
            t2 = data[i + 24];
            t3 = data[i + 8];
            p3 = t0 + t2;
            p4 = t1 + t3;
            p1 = t0 + t3;
            p2 = t1 + t2;
            p5 = (p3 + p4) * (int)(1.175875602f * 4096 + 0.5);
            t0 = t0 * (int)(0.298631336f * 4096 + 0.5);
            t1 = t1 * (int)(2.053119869f * 4096 + 0.5);
            t2 = t2 * (int)(3.072711026f * 4096 + 0.5);
            t3 = t3 * (int)(1.501321110f * 4096 + 0.5);
            p1 = p5 + p1 * (int)(-0.899976223f * 4096 + 0.5);
            p2 = p5 + p2 * (int)(-2.562915447f * 4096 + 0.5);
            p3 = p3 * (int)(-1.961570560f * 4096 + 0.5);
            p4 = p4 * (int)(-0.390180644f * 4096 + 0.5);
            t3 += p1 + p4;
            t2 += p2 + p3;
            t1 += p2 + p4;
            t0 += p1 + p3;
            x0 += 512;
            x1 += 512;
            x2 += 512;
            x3 += 512;
            val[i] = (x0 + t3) >> 10;
            val[i + 56] = (x0 - t3) >> 10;
            val[i + 8] = (x1 + t2) >> 10;
            val[i + 48] = (x1 - t2) >> 10;
            val[i + 16] = (x2 + t1) >> 10;
            val[i + 40] = (x2 - t1) >> 10;
            val[i + 24] = (x3 + t0) >> 10;
            val[i + 32] = (x3 - t0) >> 10;
        }
    }

    for (int i = 0; i < 8; ++i)
    {
        int t0, t1, t2, t3, p1, p2, p3, p4, p5, x0, x1, x2, x3;
        p2 = val[i * 8 + 2];
        p3 = val[i * 8 + 6];
        p1 = (p2 + p3) * (int)(0.5411961f * 4096 + 0.5);
        t2 = p1 + p3 * (int)(-1.847759065f * 4096 + 0.5);
        t3 = p1 + p2 * (int)(0.765366865f * 4096 + 0.5);
        p2 = val[i * 8];
        p3 = val[i * 8 + 4];
        t0 = (p2 + p3) * 4096;
        t1 = (p2 - p3) * 4096;
        x0 = t0 + t3;
        x3 = t0 - t3;
        x1 = t1 + t2;
        x2 = t1 - t2;
        t0 = val[i * 8 + 7];
        t1 = val[i * 8 + 5];
        t2 = val[i * 8 + 3];
        t3 = val[i * 8 + 1];
        p3 = t0 + t2;
        p4 = t1 + t3;
        p1 = t0 + t3;
        p2 = t1 + t2;
        p5 = (p3 + p4) * (int)(1.175875602f * 4096 + 0.5);
        t0 = t0 * (int)(0.298631336f * 4096 + 0.5);
        t1 = t1 * (int)(2.053119869f * 4096 + 0.5);
        t2 = t2 * (int)(3.072711026f * 4096 + 0.5);
        t3 = t3 * (int)(1.501321110f * 4096 + 0.5);
        p1 = p5 + p1 * (int)(-0.899976223f * 4096 + 0.5);
        p2 = p5 + p2 * (int)(-2.562915447f * 4096 + 0.5);
        p3 = p3 * (int)(-1.961570560f * 4096 + 0.5);
        p4 = p4 * (int)(-0.390180644f * 4096 + 0.5);
        t3 += p1 + p4;
        t2 += p2 + p3;
        t1 += p2 + p4;
        t0 += p1 + p3;
        x0 += 65536 + (128 << 17);
        x1 += 65536 + (128 << 17);
        x2 += 65536 + (128 << 17);
        x3 += 65536 + (128 << 17);
        output[i * outStride] = (byte)Math.Clamp((x0 + t3) >> 17, 0, 255);
        output[i * outStride + 7] = (byte)Math.Clamp((x0 - t3) >> 17, 0, 255);
        output[i * outStride + 1] = (byte)Math.Clamp((x1 + t2) >> 17, 0, 255);
        output[i * outStride + 6] = (byte)Math.Clamp((x1 - t2) >> 17, 0, 255);
        output[i * outStride + 2] = (byte)Math.Clamp((x2 + t1) >> 17, 0, 255);
        output[i * outStride + 5] = (byte)Math.Clamp((x2 - t1) >> 17, 0, 255);
        output[i * outStride + 3] = (byte)Math.Clamp((x3 + t0) >> 17, 0, 255);
        output[i * outStride + 4] = (byte)Math.Clamp((x3 - t0) >> 17, 0, 255);
    }
}
        /// <summary>
        ///     Stbis the get marker using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <returns>The </returns>
        public static byte Stbigetmarker(StbiJpeg j)
        {
            byte x = 0;
            if (j.Marker != 0xff)
            {
                x = j.Marker;
                j.Marker = 0xff;
                return x;
            }

            x = stbi__get8(j.S);
            if (x != 0xff)
            {
                return 0xff;
            }

            while (x == 0xff)
            {
                x = stbi__get8(j.S);
            }

            return x;
        }

        /// <summary>
        ///     Stbis the jpeg reset using the specified j
        /// </summary>
        /// <param name="j">The </param>
        public static void Stbijpegreset(StbiJpeg j)
        {
            j.CodeBits = 0;
            j.CodeBuffer = 0;
            j.Nomore = 0;
            j.ImgComp[0].dc_pred = j.ImgComp[1].dc_pred = j.ImgComp[2].dc_pred = j.ImgComp[3].dc_pred = 0;
            j.Marker = 0xff;
            j.Todo = j.RestartInterval != 0 ? j.RestartInterval : 0x7fffffff;
            j.EobRun = 0;
        }

        /// <summary>
        ///     Stbis the parse entropy coded data using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <returns>The int</returns>
        public static int Stbiparseentropycodeddata(StbiJpeg z)
        {
            Stbijpegreset(z);
            if (z.Progressive == 0)
            {
                if (z.ScanN == 1)
                {
                    int i = 0;
                    int j = 0;
                    short* data = stackalloc short[64];
                    int n = z.Order[0];
                    int w = (z.ImgComp[n].x + 7) >> 3;
                    int h = (z.ImgComp[n].y + 7) >> 3;
                    for (j = 0; j < h; ++j)
                    for (i = 0; i < w; ++i)
                    {
                        int ha = z.ImgComp[n].ha;
                        fixed (StbiHuffman* dptr = &z.HuffDc[z.ImgComp[n].hd])
                        fixed (StbiHuffman* aptr = &z.HuffAc[ha])
                        {
                            if (Stbijpegdecodeblock(z, data, dptr, aptr,
                                    z.FastAc[ha], n, z.Dequant[z.ImgComp[n].tq]) == 0)
                            {
                                return 0;
                            }
                        }

                        z.IdctBlockKernel(z.ImgComp[n].data + z.ImgComp[n].w2 * j * 8 + i * 8, z.ImgComp[n].w2,
                            data);
                        if (--z.Todo <= 0)
                        {
                            if (z.CodeBits < 24)
                            {
                                Stbigrowbufferunsafe(z);
                            }

                            if (!((z.Marker >= 0xd0) && (z.Marker <= 0xd7)))
                            {
                                return 1;
                            }

                            Stbijpegreset(z);
                        }
                    }

                    return 1;
                }
                else
                {
                    int i = 0;
                    int j = 0;
                    int k = 0;
                    int x = 0;
                    int y = 0;
                    short* data = stackalloc short[64];
                    for (j = 0; j < z.ImgMcuY; ++j)
                    for (i = 0; i < z.ImgMcuX; ++i)
                    {
                        for (k = 0; k < z.ScanN; ++k)
                        {
                            int n = z.Order[k];
                            for (y = 0; y < z.ImgComp[n].v; ++y)
                            for (x = 0; x < z.ImgComp[n].h; ++x)
                            {
                                int x2 = (i * z.ImgComp[n].h + x) * 8;
                                int y2 = (j * z.ImgComp[n].v + y) * 8;
                                int ha = z.ImgComp[n].ha;

                                fixed (StbiHuffman* dptr = &z.HuffDc[z.ImgComp[n].hd])
                                fixed (StbiHuffman* aptr = &z.HuffAc[ha])
                                {
                                    if (Stbijpegdecodeblock(z, data, dptr, aptr,
                                            z.FastAc[ha], n, z.Dequant[z.ImgComp[n].tq]) == 0)
                                    {
                                        return 0;
                                    }
                                }

                                z.IdctBlockKernel(z.ImgComp[n].data + z.ImgComp[n].w2 * y2 + x2, z.ImgComp[n].w2,
                                    data);
                            }
                        }

                        if (--z.Todo <= 0)
                        {
                            if (z.CodeBits < 24)
                            {
                                Stbigrowbufferunsafe(z);
                            }

                            if (!((z.Marker >= 0xd0) && (z.Marker <= 0xd7)))
                            {
                                return 1;
                            }

                            Stbijpegreset(z);
                        }
                    }

                    return 1;
                }
            }

            if (z.ScanN == 1)
            {
                int i = 0;
                int j = 0;
                int n = z.Order[0];
                int w = (z.ImgComp[n].x + 7) >> 3;
                int h = (z.ImgComp[n].y + 7) >> 3;
                for (j = 0; j < h; ++j)
                for (i = 0; i < w; ++i)
                {
                    short* data = z.ImgComp[n].coeff + 64 * (i + j * z.ImgComp[n].coeff_w);
                    if (z.SpecStart == 0)
                    {
                        fixed (StbiHuffman* dptr = &z.HuffDc[z.ImgComp[n].hd])
                        {
                            if (Stbijpegdecodeblockprogdc(z, data, dptr, n) == 0)
                            {
                                return 0;
                            }
                        }
                    }
                    else
                    {
                        int ha = z.ImgComp[n].ha;
                        fixed (StbiHuffman* aptr = &z.HuffAc[ha])
                        {
                            if (Stbijpegdecodeblockprogac(z, data, aptr, z.FastAc[ha]) == 0)
                            {
                                return 0;
                            }
                        }
                    }

                    if (--z.Todo <= 0)
                    {
                        if (z.CodeBits < 24)
                        {
                            Stbigrowbufferunsafe(z);
                        }

                        if (!((z.Marker >= 0xd0) && (z.Marker <= 0xd7)))
                        {
                            return 1;
                        }

                        Stbijpegreset(z);
                    }
                }

                return 1;
            }
            else
            {
                int i = 0;
                int j = 0;
                int k = 0;
                int x = 0;
                int y = 0;
                for (j = 0; j < z.ImgMcuY; ++j)
                for (i = 0; i < z.ImgMcuX; ++i)
                {
                    for (k = 0; k < z.ScanN; ++k)
                    {
                        int n = z.Order[k];
                        for (y = 0; y < z.ImgComp[n].v; ++y)
                        for (x = 0; x < z.ImgComp[n].h; ++x)
                        {
                            int x2 = i * z.ImgComp[n].h + x;
                            int y2 = j * z.ImgComp[n].v + y;
                            short* data = z.ImgComp[n].coeff + 64 * (x2 + y2 * z.ImgComp[n].coeff_w);


                            fixed (StbiHuffman* dptr = &z.HuffDc[z.ImgComp[n].hd])
                            {
                                if (Stbijpegdecodeblockprogdc(z, data, dptr, n) == 0)
                                {
                                    return 0;
                                }
                            }
                        }
                    }

                    if (--z.Todo <= 0)
                    {
                        if (z.CodeBits < 24)
                        {
                            Stbigrowbufferunsafe(z);
                        }

                        if (!((z.Marker >= 0xd0) && (z.Marker <= 0xd7)))
                        {
                            return 1;
                        }

                        Stbijpegreset(z);
                    }
                }

                return 1;
            }
        }

        /// <summary>
        ///     Stbis the jpeg dequantize using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="dequant">The dequant</param>
        public static void Stbijpegdequantize(short* data, ushort[] dequant)
        {
            int i = 0;
            for (i = 0; i < 64; ++i)
            {
                data[i] *= (short) dequant[i];
            }
        }

        /// <summary>
        ///     Stbis the jpeg finish using the specified z
        /// </summary>
        /// <param name="z">The </param>
        public static void Stbijpegfinish(StbiJpeg z)
        {
            if (z.Progressive != 0)
            {
                int i = 0;
                int j = 0;
                int n = 0;
                for (n = 0; n < z.S.ImgN; ++n)
                {
                    int w = (z.ImgComp[n].x + 7) >> 3;
                    int h = (z.ImgComp[n].y + 7) >> 3;
                    for (j = 0; j < h; ++j)
                    for (i = 0; i < w; ++i)
                    {
                        short* data = z.ImgComp[n].coeff + 64 * (i + j * z.ImgComp[n].coeff_w);
                        Stbijpegdequantize(data, z.Dequant[z.ImgComp[n].tq]);
                        z.IdctBlockKernel(z.ImgComp[n].data + z.ImgComp[n].w2 * j * 8 + i * 8, z.ImgComp[n].w2,
                            data);
                    }
                }
            }
        }

        /// <summary>
        ///     Stbis the process marker using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <param name="m">The </param>
        /// <returns>The int</returns>
        public static int Stbiprocessmarker(StbiJpeg z, int m)
        {
            int l = 0;
            switch (m)
            {
                case 0xff:
                    return stbi__err("expected marker");
                case 0xDD:
                    if (Stbiget16Be(z.S) != 4)
                    {
                        return stbi__err("bad DRI len");
                    }

                    z.RestartInterval = Stbiget16Be(z.S);
                    return 1;
                case 0xDB:
                    l = Stbiget16Be(z.S) - 2;
                    while (l > 0)
                    {
                        int q = stbi__get8(z.S);
                        int p = q >> 4;
                        int sixteen = p != 0 ? 1 : 0;
                        int t = q & 15;
                        int i = 0;
                        if ((p != 0) && (p != 1))
                        {
                            return stbi__err("bad DQT type");
                        }

                        if (t > 3)
                        {
                            return stbi__err("bad DQT table");
                        }

                        for (i = 0; i < 64; ++i)
                        {
                            z.Dequant[t][StbiJpegDezigzag[i]] =
                                (ushort) (sixteen != 0 ? Stbiget16Be(z.S) : stbi__get8(z.S));
                        }

                        l -= sixteen != 0 ? 129 : 65;
                    }

                    return l == 0 ? 1 : 0;
                case 0xC4:
                    l = Stbiget16Be(z.S) - 2;
                    int* sizes = stackalloc int[16];
                    while (l > 0)
                    {
                        int i = 0;
                        int n = 0;
                        int q = stbi__get8(z.S);
                        int tc = q >> 4;
                        int th = q & 15;
                        if (tc > 1 || th > 3)
                        {
                            return stbi__err("bad DHT header");
                        }

                        for (i = 0; i < 16; ++i)
                        {
                            sizes[i] = stbi__get8(z.S);
                            n += sizes[i];
                        }

                        if (n > 256)
                        {
                            return stbi__err("bad DHT header");
                        }

                        l -= 17;
                        if (tc == 0)
                        {
                            fixed (StbiHuffman* hptr = &z.HuffDc[th])
                            {
                                if (Stbibuildhuffman(hptr, sizes) == 0)
                                {
                                    return 0;
                                }

                                byte* v = hptr->values;
                                for (i = 0; i < n; ++i)
                                {
                                    v[i] = stbi__get8(z.S);
                                }
                            }
                        }
                        else
                        {
                            fixed (StbiHuffman* aptr = &z.HuffAc[th])
                            {
                                if (Stbibuildhuffman(aptr, sizes) == 0)
                                {
                                    return 0;
                                }

                                byte* v = aptr->values;
                                for (i = 0; i < n; ++i)
                                {
                                    v[i] = stbi__get8(z.S);
                                }
                            }
                        }

                        if (tc != 0)
                        {
                            fixed (StbiHuffman* aptr = &z.HuffAc[th])
                            {
                                Stbibuildfastac(z.FastAc[th], aptr);
                            }
                        }

                        l -= n;
                    }

                    return l == 0 ? 1 : 0;
            }

            if (((m >= 0xE0) && (m <= 0xEF)) || m == 0xFE)
            {
                l = Stbiget16Be(z.S);
                if (l < 2)
                {
                    if (m == 0xFE)
                    {
                        return stbi__err("bad COM len");
                    }

                    return stbi__err("bad APP len");
                }

                l -= 2;
                if ((m == 0xE0) && (l >= 5))
                {
                    int ok = 1;
                    int i = 0;
                    for (i = 0; i < 5; ++i)
                    {
                        if (stbi__get8(z.S) != StbiProcessMarkerTag[i])
                        {
                            ok = 0;
                        }
                    }

                    l -= 5;
                    if (ok != 0)
                    {
                        z.Jfif = 1;
                    }
                }
                else if ((m == 0xEE) && (l >= 12))
                {
                    int ok = 1;
                    int i = 0;
                    for (i = 0; i < 6; ++i)
                    {
                        if (stbi__get8(z.S) != StbiProcessMarkerTag[i])
                        {
                            ok = 0;
                        }
                    }

                    l -= 6;
                    if (ok != 0)
                    {
                        stbi__get8(z.S);
                        Stbiget16Be(z.S);
                        Stbiget16Be(z.S);
                        z.App14ColorTransform = stbi__get8(z.S);
                        l -= 6;
                    }
                }

                stbi__skip(z.S, l);
                return 1;
            }

            return stbi__err("unknown marker");
        }

        /// <summary>
        ///     Stbis the process scan header using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <returns>The int</returns>
        public static int Stbiprocessscanheader(StbiJpeg z)
        {
            int i = 0;
            int ls = Stbiget16Be(z.S);
            z.ScanN = stbi__get8(z.S);
            if (z.ScanN < 1 || z.ScanN > 4 || z.ScanN > z.S.ImgN)
            {
                return stbi__err("bad SOS component count");
            }

            if (ls != 6 + 2 * z.ScanN)
            {
                return stbi__err("bad SOS len");
            }

            for (i = 0; i < z.ScanN; ++i)
            {
                int id = stbi__get8(z.S);
                int which = 0;
                int q = stbi__get8(z.S);
                for (which = 0; which < z.S.ImgN; ++which)
                {
                    if (z.ImgComp[which].id == id)
                    {
                        break;
                    }
                }

                if (which == z.S.ImgN)
                {
                    return 0;
                }

                z.ImgComp[which].hd = q >> 4;
                if (z.ImgComp[which].hd > 3)
                {
                    return stbi__err("bad DC huff");
                }

                z.ImgComp[which].ha = q & 15;
                if (z.ImgComp[which].ha > 3)
                {
                    return stbi__err("bad AC huff");
                }

                z.Order[i] = which;
            }

            {
                int aa = 0;
                z.SpecStart = stbi__get8(z.S);
                z.SpecEnd = stbi__get8(z.S);
                aa = stbi__get8(z.S);
                z.SuccHigh = aa >> 4;
                z.SuccLow = aa & 15;
                if (z.Progressive != 0)
                {
                    if (z.SpecStart > 63 || z.SpecEnd > 63 || z.SpecStart > z.SpecEnd || z.SuccHigh > 13 ||
                        z.SuccLow > 13)
                    {
                        return stbi__err("bad SOS");
                    }
                }
                else
                {
                    if (z.SpecStart != 0)
                    {
                        return stbi__err("bad SOS");
                    }

                    if (z.SuccHigh != 0 || z.SuccLow != 0)
                    {
                        return stbi__err("bad SOS");
                    }

                    z.SpecEnd = 63;
                }
            }

            return 1;
        }

        /// <summary>
        ///     Stbis the free jpeg components using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <param name="ncomp">The ncomp</param>
        /// <param name="why">The why</param>
        /// <returns>The why</returns>
        public static int Stbifreejpegcomponents(StbiJpeg z, int ncomp, int why)
        {
            int i = 0;
            for (i = 0; i < ncomp; ++i)
            {
                if (z.ImgComp[i].raw_data != null)
                {
                    CRuntime.Free(z.ImgComp[i].raw_data);
                    z.ImgComp[i].raw_data = null;
                    z.ImgComp[i].data = null;
                }

                if (z.ImgComp[i].raw_coeff != null)
                {
                    CRuntime.Free(z.ImgComp[i].raw_coeff);
                    z.ImgComp[i].raw_coeff = null;
                    z.ImgComp[i].coeff = null;
                }

                if (z.ImgComp[i].linebuf != null)
                {
                    CRuntime.Free(z.ImgComp[i].linebuf);
                    z.ImgComp[i].linebuf = null;
                }
            }

            return why;
        }

        /// <summary>
        ///     Stbis the process frame header using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <param name="scan">The scan</param>
        /// <returns>The int</returns>
        public static int Stbiprocessframeheader(StbiJpeg z, int scan)
        {
            StbiContext s = z.S;
            int lf = 0;
            int p = 0;
            int i = 0;
            int q = 0;
            int hMax = 1;
            int vMax = 1;
            int c = 0;
            lf = Stbiget16Be(s);
            if (lf < 11)
            {
                return stbi__err("bad SOF len");
            }

            p = stbi__get8(s);
            if (p != 8)
            {
                return stbi__err("only 8-bit");
            }

            s.ImgY = (uint) Stbiget16Be(s);
            if (s.ImgY == 0)
            {
                return stbi__err("no header height");
            }

            s.ImgX = (uint) Stbiget16Be(s);
            if (s.ImgX == 0)
            {
                return stbi__err("0 width");
            }

            if (s.ImgY > 1 << 24)
            {
                return stbi__err("too large");
            }

            if (s.ImgX > 1 << 24)
            {
                return stbi__err("too large");
            }

            c = stbi__get8(s);
            if ((c != 3) && (c != 1) && (c != 4))
            {
                return stbi__err("bad component count");
            }

            s.ImgN = c;
            for (i = 0; i < c; ++i)
            {
                z.ImgComp[i].data = null;
                z.ImgComp[i].linebuf = null;
            }

            if (lf != 8 + 3 * s.ImgN)
            {
                return stbi__err("bad SOF len");
            }

            z.Rgb = 0;
            for (i = 0; i < s.ImgN; ++i)
            {
                z.ImgComp[i].id = stbi__get8(s);
                if ((s.ImgN == 3) && (z.ImgComp[i].id == StbiProcessFrameHeaderRgb[i]))
                {
                    ++z.Rgb;
                }

                q = stbi__get8(s);
                z.ImgComp[i].h = q >> 4;
                if (z.ImgComp[i].h == 0 || z.ImgComp[i].h > 4)
                {
                    return stbi__err("bad H");
                }

                z.ImgComp[i].v = q & 15;
                if (z.ImgComp[i].v == 0 || z.ImgComp[i].v > 4)
                {
                    return stbi__err("bad V");
                }

                z.ImgComp[i].tq = stbi__get8(s);
                if (z.ImgComp[i].tq > 3)
                {
                    return stbi__err("bad TQ");
                }
            }

            if (scan != StbiScanLoad)
            {
                return 1;
            }

            if (Stbimad3Sizesvalid((int) s.ImgX, (int) s.ImgY, s.ImgN, 0) == 0)
            {
                return stbi__err("too large");
            }

            for (i = 0; i < s.ImgN; ++i)
            {
                if (z.ImgComp[i].h > hMax)
                {
                    hMax = z.ImgComp[i].h;
                }

                if (z.ImgComp[i].v > vMax)
                {
                    vMax = z.ImgComp[i].v;
                }
            }

            for (i = 0; i < s.ImgN; ++i)
            {
                if (hMax % z.ImgComp[i].h != 0)
                {
                    return stbi__err("bad H");
                }

                if (vMax % z.ImgComp[i].v != 0)
                {
                    return stbi__err("bad V");
                }
            }

            z.ImgHMax = hMax;
            z.ImgVMax = vMax;
            z.ImgMcuW = hMax * 8;
            z.ImgMcuH = vMax * 8;
            z.ImgMcuX = (int) ((s.ImgX + z.ImgMcuW - 1) / z.ImgMcuW);
            z.ImgMcuY = (int) ((s.ImgY + z.ImgMcuH - 1) / z.ImgMcuH);
            for (i = 0; i < s.ImgN; ++i)
            {
                z.ImgComp[i].x = (int) ((s.ImgX * z.ImgComp[i].h + hMax - 1) / hMax);
                z.ImgComp[i].y = (int) ((s.ImgY * z.ImgComp[i].v + vMax - 1) / vMax);
                z.ImgComp[i].w2 = z.ImgMcuX * z.ImgComp[i].h * 8;
                z.ImgComp[i].h2 = z.ImgMcuY * z.ImgComp[i].v * 8;
                z.ImgComp[i].coeff = null;
                z.ImgComp[i].raw_coeff = null;
                z.ImgComp[i].linebuf = null;
                z.ImgComp[i].raw_data = stbi__malloc_mad2(z.ImgComp[i].w2, z.ImgComp[i].h2, 15);
                if (z.ImgComp[i].raw_data == null)
                {
                    return Stbifreejpegcomponents(z, i + 1, stbi__err("outofmem"));
                }

                z.ImgComp[i].data = (byte*) (((long) z.ImgComp[i].raw_data + 15) & ~15);
                if (z.Progressive != 0)
                {
                    z.ImgComp[i].coeff_w = z.ImgComp[i].w2 / 8;
                    z.ImgComp[i].coeff_h = z.ImgComp[i].h2 / 8;
                    z.ImgComp[i].raw_coeff = Stbimallocmad3(z.ImgComp[i].w2, z.ImgComp[i].h2, sizeof(short), 15);
                    if (z.ImgComp[i].raw_coeff == null)
                    {
                        return Stbifreejpegcomponents(z, i + 1, stbi__err("outofmem"));
                    }

                    z.ImgComp[i].coeff = (short*) (((long) z.ImgComp[i].raw_coeff + 15) & ~15);
                }
            }

            return 1;
        }

        /// <summary>
        ///     Stbis the decode jpeg header using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <param name="scan">The scan</param>
        /// <returns>The int</returns>
        public static int Stbidecodejpegheader(StbiJpeg z, int scan)
        {
            int m = 0;
            z.Jfif = 0;
            z.App14ColorTransform = -1;
            z.Marker = 0xff;
            m = Stbigetmarker(z);
            if (!(m == 0xd8))
            {
                return stbi__err("no SOI");
            }

            if (scan == StbiScanType)
            {
                return 1;
            }

            m = Stbigetmarker(z);
            while (!(m == 0xc0 || m == 0xc1 || m == 0xc2))
            {
                if (Stbiprocessmarker(z, m) == 0)
                {
                    return 0;
                }

                m = Stbigetmarker(z);
                while (m == 0xff)
                {
                    if (stbi__at_eof(z.S) != 0)
                    {
                        return stbi__err("no SOF");
                    }

                    m = Stbigetmarker(z);
                }
            }

            z.Progressive = m == 0xc2 ? 1 : 0;
            if (Stbiprocessframeheader(z, scan) == 0)
            {
                return 0;
            }

            return 1;
        }

        /// <summary>
        ///     Stbis the skip jpeg junk at end using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <returns>The byte</returns>
        public static byte Stbiskipjpegjunkatend(StbiJpeg j)
        {
            while (stbi__at_eof(j.S) == 0)
            {
                byte x = stbi__get8(j.S);
                while (x == 0xff)
                {
                    if (stbi__at_eof(j.S) != 0)
                    {
                        return 0xff;
                    }

                    x = stbi__get8(j.S);
                    if ((x != 0x00) && (x != 0xff))
                    {
                        return x;
                    }
                }
            }

            return 0xff;
        }

        /// <summary>
        ///     Stbis the decode jpeg image using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <returns>The int</returns>
        public static int Stbidecodejpegimage(StbiJpeg j)
        {
            int m = 0;
            for (m = 0; m < 4; m++)
            {
                j.ImgComp[m].raw_data = null;
                j.ImgComp[m].raw_coeff = null;
            }

            j.RestartInterval = 0;
            if (Stbidecodejpegheader(j, StbiScanLoad) == 0)
            {
                return 0;
            }

            m = Stbigetmarker(j);
            while (!(m == 0xd9))
            {
                if (m == 0xda)
                {
                    if (Stbiprocessscanheader(j) == 0)
                    {
                        return 0;
                    }

                    if (Stbiparseentropycodeddata(j) == 0)
                    {
                        return 0;
                    }

                    if (j.Marker == 0xff)
                    {
                        j.Marker = Stbiskipjpegjunkatend(j);
                    }

                    m = Stbigetmarker(j);
                    if ((m >= 0xd0) && (m <= 0xd7))
                    {
                        m = Stbigetmarker(j);
                    }
                }
                else if (m == 0xdc)
                {
                    int ld = Stbiget16Be(j.S);
                    uint nl = (uint) Stbiget16Be(j.S);
                    if (ld != 4)
                    {
                        return stbi__err("bad DNL len");
                    }

                    if (nl != j.S.ImgY)
                    {
                        return stbi__err("bad DNL height");
                    }

                    m = Stbigetmarker(j);
                }
                else
                {
                    if (Stbiprocessmarker(j, m) == 0)
                    {
                        return 1;
                    }

                    m = Stbigetmarker(j);
                }
            }

            if (j.Progressive != 0)
            {
                Stbijpegfinish(j);
            }

            return 1;
        }

        /// <summary>
        ///     Resamples the row 1 using the specified  out
        /// </summary>
        /// <param name="out">The out</param>
        /// <param name="inNear">The in near</param>
        /// <param name="inFar">The in far</param>
        /// <param name="w">The </param>
        /// <param name="hs">The hs</param>
        /// <returns>The in near</returns>
        public static byte* Resamplerow1(byte* @out, byte* inNear, byte* inFar, int w, int hs) => inNear;

        /// <summary>
        ///     Stbis the resample row v 2 using the specified  out
        /// </summary>
        /// <param name="out">The out</param>
        /// <param name="inNear">The in near</param>
        /// <param name="inFar">The in far</param>
        /// <param name="w">The </param>
        /// <param name="hs">The hs</param>
        /// <returns>The out</returns>
        public static byte* Stbiresamplerowv2(byte* @out, byte* inNear, byte* inFar, int w, int hs)
        {
            int i = 0;
            for (i = 0; i < w; ++i)
            {
                @out[i] = (byte) ((3 * inNear[i] + inFar[i] + 2) >> 2);
            }

            return @out;
        }

        /// <summary>
        ///     Stbis the resample row h 2 using the specified  out
        /// </summary>
        /// <param name="out">The out</param>
        /// <param name="inNear">The in near</param>
        /// <param name="inFar">The in far</param>
        /// <param name="w">The </param>
        /// <param name="hs">The hs</param>
        /// <returns>The out</returns>
        public static byte* Stbiresamplerowh2(byte* @out, byte* inNear, byte* inFar, int w, int hs)
        {
            int i = 0;
            byte* input = inNear;
            if (w == 1)
            {
                @out[0] = @out[1] = input[0];
                return @out;
            }

            @out[0] = input[0];
            @out[1] = (byte) ((input[0] * 3 + input[1] + 2) >> 2);
            for (i = 1; i < w - 1; ++i)
            {
                int n = 3 * input[i] + 2;
                @out[i * 2 + 0] = (byte) ((n + input[i - 1]) >> 2);
                @out[i * 2 + 1] = (byte) ((n + input[i + 1]) >> 2);
            }

            @out[i * 2 + 0] = (byte) ((input[w - 2] * 3 + input[w - 1] + 2) >> 2);
            @out[i * 2 + 1] = input[w - 1];
            return @out;
        }

        /// <summary>
        ///     Stbis the resample row hv 2 using the specified  out
        /// </summary>
        /// <param name="out">The out</param>
        /// <param name="inNear">The in near</param>
        /// <param name="inFar">The in far</param>
        /// <param name="w">The </param>
        /// <param name="hs">The hs</param>
        /// <returns>The out</returns>
        public static byte* Stbiresamplerowhv2(byte* @out, byte* inNear, byte* inFar, int w, int hs)
        {
            int i = 0;
            int t0 = 0;
            int t1 = 0;
            if (w == 1)
            {
                @out[0] = @out[1] = (byte) ((3 * inNear[0] + inFar[0] + 2) >> 2);
                return @out;
            }

            t1 = 3 * inNear[0] + inFar[0];
            @out[0] = (byte) ((t1 + 2) >> 2);
            for (i = 1; i < w; ++i)
            {
                t0 = t1;
                t1 = 3 * inNear[i] + inFar[i];
                @out[i * 2 - 1] = (byte) ((3 * t0 + t1 + 8) >> 4);
                @out[i * 2] = (byte) ((3 * t1 + t0 + 8) >> 4);
            }

            @out[w * 2 - 1] = (byte) ((t1 + 2) >> 2);
            return @out;
        }

        /// <summary>
        ///     Stbis the resample row generic using the specified  out
        /// </summary>
        /// <param name="out">The out</param>
        /// <param name="inNear">The in near</param>
        /// <param name="inFar">The in far</param>
        /// <param name="w">The </param>
        /// <param name="hs">The hs</param>
        /// <returns>The out</returns>
        public static byte* Stbiresamplerowgeneric(byte* @out, byte* inNear, byte* inFar, int w, int hs)
        {
            int i = 0;
            int j = 0;
            for (i = 0; i < w; ++i)
            for (j = 0; j < hs; ++j)
            {
                @out[i * hs + j] = inNear[i];
            }

            return @out;
        }

        /// <summary>
        ///     Stbis the y cb cr to rgb row using the specified  out
        /// </summary>
        /// <param name="out">The out</param>
        /// <param name="y">The </param>
        /// <param name="pcb">The pcb</param>
        /// <param name="pcr">The pcr</param>
        /// <param name="count">The count</param>
        /// <param name="step">The step</param>
        public static void StbiYCbCrtoRgBrow(byte* @out, byte* y, byte* pcb, byte* pcr, int count, int step)
        {
            int i = 0;
            for (i = 0; i < count; ++i)
            {
                int yFixed = (y[i] << 20) + (1 << 19);
                int r = 0;
                int g = 0;
                int b = 0;
                int cr = pcr[i] - 128;
                int cb = pcb[i] - 128;
                r = yFixed + cr * ((int) (1.40200f * 4096.0f + 0.5f) << 8);
                g = (int) (yFixed + cr * -((int) (0.71414f * 4096.0f + 0.5f) << 8) +
                           ((cb * -((int) (0.34414f * 4096.0f + 0.5f) << 8)) & 0xffff0000));
                b = yFixed + cb * ((int) (1.77200f * 4096.0f + 0.5f) << 8);
                r >>= 20;
                g >>= 20;
                b >>= 20;
                if ((uint) r > 255)
                {
                    if (r < 0)
                    {
                        r = 0;
                    }
                    else
                    {
                        r = 255;
                    }
                }

                if ((uint) g > 255)
                {
                    if (g < 0)
                    {
                        g = 0;
                    }
                    else
                    {
                        g = 255;
                    }
                }

                if ((uint) b > 255)
                {
                    if (b < 0)
                    {
                        b = 0;
                    }
                    else
                    {
                        b = 255;
                    }
                }

                @out[0] = (byte) r;
                @out[1] = (byte) g;
                @out[2] = (byte) b;
                @out[3] = 255;
                @out += step;
            }
        }

        /// <summary>
        ///     Stbis the setup jpeg using the specified j
        /// </summary>
        /// <param name="j">The </param>
        public static void Stbisetupjpeg(StbiJpeg j)
        {
            j.IdctBlockKernel = Stbiidctblock;
            j.YCbCrToRgbKernel = StbiYCbCrtoRgBrow;
            j.ResampleRowHv2Kernel = Stbiresamplerowhv2;
        }

        /// <summary>
        ///     Stbis the cleanup jpeg using the specified j
        /// </summary>
        /// <param name="j">The </param>
        public static void Stbicleanupjpeg(StbiJpeg j)
        {
            Stbifreejpegcomponents(j, j.S.ImgN, 0);
        }

        /// <summary>
        ///     Loads the jpeg image using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <param name="outX">The out</param>
        /// <param name="outY">The out</param>
        /// <param name="comp">The comp</param>
        /// <param name="reqComp">The req comp</param>
        /// <returns>The byte</returns>
    public static byte[] Loadjpegimage(StbiJpeg z, out int outX, out int outY, out int comp, int reqComp)
    {
        int n = 0;
        int decodeN = 0;
        int isRgb = 0;
        z.S.ImgN = 0;
    
        if (reqComp < 0 || reqComp > 4)
        {
            throw new InvalidOperationException("bad req_comp");
        }
    
        if (Stbidecodejpegimage(z) == 0)
        {
            Stbicleanupjpeg(z);
            throw new InvalidOperationException("Failed to decode JPEG image");
        }
    
        n = reqComp != 0 ? reqComp : z.S.ImgN >= 3 ? 3 : 1;
        isRgb = (z.S.ImgN == 3) && (z.Rgb == 3 || ((z.App14ColorTransform == 0) && (z.Jfif == 0))) ? 1 : 0;
        decodeN = (z.S.ImgN == 3 && n < 3 && isRgb == 0) ? 1 : z.S.ImgN;
    
        if (decodeN <= 0)
        {
            Stbicleanupjpeg(z);
            throw new InvalidOperationException("Invalid decodeN value");
        }
    
        var resComp = new StbiResample[4];
        for (int k = 0; k < decodeN; ++k)
        {
            resComp[k] = new StbiResample
            {
                Hs = z.ImgHMax / z.ImgComp[k].h,
                Vs = z.ImgVMax / z.ImgComp[k].v,
                Ystep = (z.ImgHMax / z.ImgComp[k].h) >> 1,
                WLores = (int)((z.S.ImgX + (z.ImgHMax / z.ImgComp[k].h) - 1) / (z.ImgHMax / z.ImgComp[k].h)),
                Ypos = 0,
                Line0 = z.ImgComp[k].data,
                Line1 = z.ImgComp[k].data,
                Resample = (z.ImgHMax / z.ImgComp[k].h, z.ImgVMax / z.ImgComp[k].v) switch
                {
                    (1, 1) => Resamplerow1,
                    (1, 2) => Stbiresamplerowv2,
                    (2, 1) => Stbiresamplerowh2,
                    (2, 2) => z.ResampleRowHv2Kernel,
                    _ => Stbiresamplerowgeneric
                }
            };
        }
    
        var output = new byte[n * (int)z.S.ImgX * (int)z.S.ImgY];
        for (uint j = 0; j < z.S.ImgY; ++j)
        {
            var rowOutput = new byte[n * (int)z.S.ImgX];
            for (int k = 0; k < decodeN; ++k)
            {
                var r = resComp[k];
                int yBot = r.Ystep >= r.Vs >> 1 ? 1 : 0;
                var coutput = r.Resample(r.Line0, yBot != 0 ? r.Line1 : r.Line0, yBot != 0 ? r.Line0 : r.Line1, r.WLores, r.Hs);
                if (++r.Ystep >= r.Vs)
                {
                    r.Ystep = 0;
                    r.Line0 = r.Line1;
                    if (++r.Ypos < z.ImgComp[k].y)
                    {
                        r.Line1 += z.ImgComp[k].w2;
                    }
                }
            }
        }
    
        Stbicleanupjpeg(z);
        outX = (int)z.S.ImgX;
        outY = (int)z.S.ImgY;
        comp = z.S.ImgN >= 3 ? 3 : 1;
    
        return output;
    } 
        /// <summary>
        ///     Stbis the jpeg info raw using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <returns>The int</returns>
      public static int Stbijpeginforaw(StbiJpeg j, ref int x, ref int y, ref int comp)
        {
            if (Stbidecodejpegheader(j, StbiScanHeader) == 0)
            {
                Stbirewind(j.S);
                return 0;
            }
        
            x = (int)j.S.ImgX;
            y = (int)j.S.ImgY;
            comp = j.S.ImgN >= 3 ? 3 : 1;
        
            return 1;
        }
    }
}