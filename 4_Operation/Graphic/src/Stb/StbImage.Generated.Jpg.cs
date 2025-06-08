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
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Stb.Hebron.Runtime;

namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The stb image class
    /// </summary>
    unsafe partial class StbImage
    {
        /// <summary>
        ///     The stbi bmask
        /// </summary>
        public static uint[] Stbibmask =
            {0, 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023, 2047, 4095, 8191, 16383, 32767, 65535};

        /// <summary>
        ///     The stbi jbias
        /// </summary>
        public static int[] Stbijbias =
            {0, -1, -3, -7, -15, -31, -63, -127, -255, -511, -1023, -2047, -4095, -8191, -16383, -32767};

        /// <summary>
        ///     The stbi jpeg dezigzag
        /// </summary>
        public static byte[] Stbijpegdezigzag =
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
        public static int Stbijpegtest(Stbicontext s)
        {
            int r = 0;
            Stbijpeg j = new Stbijpeg();
            if (j == null)
            {
                return Stbierr("outofmem");
            }

            j.S = s;
            Stbisetupjpeg(j);
            r = Stbidecodejpegheader(j, StbiscaNtype);
            Stbirewind(s);
            return r;
        }

        /// <summary>
        ///     Stbis the jpeg load using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <param name="reqcomp">The req comp</param>
        /// <param name="ri">The ri</param>
        /// <returns>The result</returns>
        public static void* Stbijpegload(Stbicontext s, int* x, int* y, int* comp, int reqcomp,
            Stbiresultinfo* ri)
        {
            byte* result;
            Stbijpeg j = new Stbijpeg();
            if (j == null)
            {
                return (byte*) (ulong) (Stbierr("outofmem") != 0 ? 0 : 0);
            }

            j.S = s;
            Stbisetupjpeg(j);
            result = Loadjpegimage(j, x, y, comp, reqcomp);
            return result;
        }

        /// <summary>
        ///     Stbis the jpeg info using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <returns>The result</returns>
        public static int Stbijpeginfo(Stbicontext s, int* x, int* y, int* comp)
        {
            int result = 0;
            Stbijpeg j = new Stbijpeg();
            if (j == null)
            {
                return Stbierr("outofmem");
            }

            j.S = s;
            result = Stbijpeginforaw(j, x, y, comp);
            return result;
        }

        /// <summary>
        ///     Stbis the build huffman using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        public static int Stbibuildhuffman(Stbihuffman* h, int* count)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            uint code = 0;
            for (i = 0; i < 16; ++i)
            {
                for (j = 0; j < count[i]; ++j)
                {
                    h->size[k++] = (byte) (i + 1);
                    if (k >= 257)
                    {
                        return Stbierr("bad size list");
                    }
                }
            }

            h->size[k] = 0;
            code = 0;
            k = 0;
            for (j = 1; j <= 16; ++j)
            {
                h->delta[j] = (int) (k - code);
                if (h->size[k] == j)
                {
                    while (h->size[k] == j)
                    {
                        h->code[k++] = (ushort) code++;
                    }

                    if (code - 1 >= 1u << j)
                    {
                        return Stbierr("bad code lengths");
                    }
                }

                h->maxcode[j] = code << (16 - j);
                code <<= 1;
            }

            h->maxcode[j] = 0xffffffff;
            CRuntime.Memset(h->fast, 255, (ulong) (1 << 9));
            for (i = 0; i < k; ++i)
            {
                int s = h->size[i];
                if (s <= 9)
                {
                    int c = h->code[i] << (9 - s);
                    int m = 1 << (9 - s);
                    for (j = 0; j < m; ++j)
                    {
                        h->fast[c + j] = (byte) i;
                    }
                }
            }

            return 1;
        }

        /// <summary>
        ///     Stbis the build fast ac using the specified fast ac
        /// </summary>
        /// <param name="fastac">The fast ac</param>
        /// <param name="h">The </param>
        public static void Stbibuildfastac(short[] fastac, Stbihuffman* h)
        {
            int i = 0;
            for (i = 0; i < 1 << 9; ++i)
            {
                byte fast = h->fast[i];
                fastac[i] = 0;
                if (fast < 255)
                {
                    int rs = h->values[fast];
                    int run = (rs >> 4) & 15;
                    int magbits = rs & 15;
                    int len = h->size[fast];
                    if ((magbits != 0) && (len + magbits <= 9))
                    {
                        int k = ((i << len) & ((1 << 9) - 1)) >> (9 - magbits);
                        int m = 1 << (magbits - 1);
                        if (k < m)
                        {
                            k += (int) ((~0U << magbits) + 1);
                        }

                        if ((k >= -128) && (k <= 127))
                        {
                            fastac[i] = (short) (k * 256 + run * 16 + len + magbits);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Stbis the grow buffer unsafe using the specified j
        /// </summary>
        /// <param name="j">The </param>
        public static void Stbigrowbufferunsafe(Stbijpeg j)
        {
            do
            {
                uint b = (uint) (j.Nomore != 0 ? 0 : Stbiget8(j.S));
                if (b == 0xff)
                {
                    int c = Stbiget8(j.S);
                    while (c == 0xff)
                    {
                        c = Stbiget8(j.S);
                    }

                    if (c != 0)
                    {
                        j.Marker = (byte) c;
                        j.Nomore = 1;
                        return;
                    }
                }

                j.Codebuffer |= b << (24 - j.Codebits);
                j.Codebits += 8;
            } while (j.Codebits <= 24);
        }

        /// <summary>
        ///     Stbis the jpeg huff decode using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        public static int Stbijpeghuffdecode(Stbijpeg j, Stbihuffman* h)
        {
            uint temp = 0;
            int c = 0;
            int k = 0;
            if (j.Codebits < 16)
            {
                Stbigrowbufferunsafe(j);
            }

            c = (int) ((j.Codebuffer >> (32 - 9)) & ((1 << 9) - 1));
            k = h->fast[c];
            if (k < 255)
            {
                int s = h->size[k];
                if (s > j.Codebits)
                {
                    return -1;
                }

                j.Codebuffer <<= s;
                j.Codebits -= s;
                return h->values[k];
            }

            temp = j.Codebuffer >> 16;
            for (k = 9 + 1;; ++k)
            {
                if (temp < h->maxcode[k])
                {
                    break;
                }
            }

            if (k == 17)
            {
                j.Codebits -= 16;
                return -1;
            }

            if (k > j.Codebits)
            {
                return -1;
            }

            c = (int) (((j.Codebuffer >> (32 - k)) & Stbibmask[k]) + h->delta[k]);
            if (c < 0 || c >= 256)
            {
                return -1;
            }

            j.Codebits -= k;
            j.Codebuffer <<= k;
            return h->values[c];
        }

        /// <summary>
        ///     Stbis the extend receive using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <param name="n">The </param>
        /// <returns>The int</returns>
        public static int Stbiextendreceive(Stbijpeg j, int n)
        {
            uint k = 0;
            int sgn = 0;
            if (j.Codebits < n)
            {
                Stbigrowbufferunsafe(j);
            }

            if (j.Codebits < n)
            {
                return 0;
            }

            sgn = (int) (j.Codebuffer >> 31);
            k = CRuntime.Lrotl(j.Codebuffer, n);
            j.Codebuffer = k & ~Stbibmask[n];
            k &= Stbibmask[n];
            j.Codebits -= n;
            return (int) (k + (Stbijbias[n] & (sgn - 1)));
        }

        /// <summary>
        ///     Stbis the jpeg get bits using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <param name="n">The </param>
        /// <returns>The int</returns>
        public static int Stbijpeggetbits(Stbijpeg j, int n)
        {
            uint k = 0;
            if (j.Codebits < n)
            {
                Stbigrowbufferunsafe(j);
            }

            if (j.Codebits < n)
            {
                return 0;
            }

            k = CRuntime.Lrotl(j.Codebuffer, n);
            j.Codebuffer = k & ~Stbibmask[n];
            k &= Stbibmask[n];
            j.Codebits -= n;
            return (int) k;
        }

        /// <summary>
        ///     Stbis the jpeg get bit using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <returns>The int</returns>
        public static int Stbijpeggetbit(Stbijpeg j)
        {
            uint k = 0;
            if (j.Codebits < 1)
            {
                Stbigrowbufferunsafe(j);
            }

            if (j.Codebits < 1)
            {
                return 0;
            }

            k = j.Codebuffer;
            j.Codebuffer <<= 1;
            --j.Codebits;
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
        public static int Stbijpegdecodeblock(Stbijpeg j, short* data, Stbihuffman* hdc, Stbihuffman* hac,
            short[] fac, int b, ushort[] dequant)
        {
            int diff = 0;
            int dc = 0;
            int k = 0;
            int t = 0;
            if (j.Codebits < 16)
            {
                Stbigrowbufferunsafe(j);
            }

            t = Stbijpeghuffdecode(j, hdc);
            if (t < 0 || t > 15)
            {
                return Stbierr("bad huffman code");
            }

            CRuntime.Memset(data, 0, (ulong) (64 * sizeof(short)));
            diff = t != 0 ? Stbiextendreceive(j, t) : 0;
            if (Stbiaddintsvalid(j.Imgcomp[b].dcpred, diff) == 0)
            {
                return Stbierr("bad delta");
            }

            dc = j.Imgcomp[b].dcpred + diff;
            j.Imgcomp[b].dcpred = dc;
            if (Stbimul2Shortsvalid(dc, dequant[0]) == 0)
            {
                return Stbierr("can't merge dc and ac");
            }

            data[0] = (short) (dc * dequant[0]);
            k = 1;
            do
            {
                uint zig = 0;
                int c = 0;
                int r = 0;
                int s = 0;
                if (j.Codebits < 16)
                {
                    Stbigrowbufferunsafe(j);
                }

                c = (int) ((j.Codebuffer >> (32 - 9)) & ((1 << 9) - 1));
                r = fac[c];
                if (r != 0)
                {
                    k += (r >> 4) & 15;
                    s = r & 15;
                    if (s > j.Codebits)
                    {
                        return Stbierr("bad huffman code");
                    }

                    j.Codebuffer <<= s;
                    j.Codebits -= s;
                    zig = Stbijpegdezigzag[k++];
                    data[zig] = (short) ((r >> 8) * dequant[zig]);
                }
                else
                {
                    int rs = Stbijpeghuffdecode(j, hac);
                    if (rs < 0)
                    {
                        return Stbierr("bad huffman code");
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
                        zig = Stbijpegdezigzag[k++];
                        data[zig] = (short) (Stbiextendreceive(j, s) * dequant[zig]);
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
        public static int Stbijpegdecodeblockprogdc(Stbijpeg j, short* data, Stbihuffman* hdc, int b)
        {
            int diff = 0;
            int dc = 0;
            int t = 0;
            if (j.Specend != 0)
            {
                return Stbierr("can't merge dc and ac");
            }

            if (j.Codebits < 16)
            {
                Stbigrowbufferunsafe(j);
            }

            if (j.Succhigh == 0)
            {
                CRuntime.Memset(data, 0, (ulong) (64 * sizeof(short)));
                t = Stbijpeghuffdecode(j, hdc);
                if (t < 0 || t > 15)
                {
                    return Stbierr("can't merge dc and ac");
                }

                diff = t != 0 ? Stbiextendreceive(j, t) : 0;
                if (Stbiaddintsvalid(j.Imgcomp[b].dcpred, diff) == 0)
                {
                    return Stbierr("bad delta");
                }

                dc = j.Imgcomp[b].dcpred + diff;
                j.Imgcomp[b].dcpred = dc;
                if (Stbimul2Shortsvalid(dc, 1 << j.Succlow) == 0)
                {
                    return Stbierr("can't merge dc and ac");
                }

                data[0] = (short) (dc * (1 << j.Succlow));
            }
            else
            {
                if (Stbijpeggetbit(j) != 0)
                {
                    data[0] += (short) (1 << j.Succlow);
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
        public static int Stbijpegdecodeblockprogac(Stbijpeg j, short* data, Stbihuffman* hac, short[] fac)
        {
            int k = 0;
            if (j.Specstart == 0)
            {
                return Stbierr("can't merge dc and ac");
            }

            if (j.Succhigh == 0)
            {
                int shift = j.Succlow;
                if (j.Eobrun != 0)
                {
                    --j.Eobrun;
                    return 1;
                }

                k = j.Specstart;
                do
                {
                    uint zig = 0;
                    int c = 0;
                    int r = 0;
                    int s = 0;
                    if (j.Codebits < 16)
                    {
                        Stbigrowbufferunsafe(j);
                    }

                    c = (int) ((j.Codebuffer >> (32 - 9)) & ((1 << 9) - 1));
                    r = fac[c];
                    if (r != 0)
                    {
                        k += (r >> 4) & 15;
                        s = r & 15;
                        if (s > j.Codebits)
                        {
                            return Stbierr("bad huffman code");
                        }

                        j.Codebuffer <<= s;
                        j.Codebits -= s;
                        zig = Stbijpegdezigzag[k++];
                        data[zig] = (short) ((r >> 8) * (1 << shift));
                    }
                    else
                    {
                        int rs = Stbijpeghuffdecode(j, hac);
                        if (rs < 0)
                        {
                            return Stbierr("bad huffman code");
                        }

                        s = rs & 15;
                        r = rs >> 4;
                        if (s == 0)
                        {
                            if (r < 15)
                            {
                                j.Eobrun = 1 << r;
                                if (r != 0)
                                {
                                    j.Eobrun += Stbijpeggetbits(j, r);
                                }

                                --j.Eobrun;
                                break;
                            }

                            k += 16;
                        }
                        else
                        {
                            k += r;
                            zig = Stbijpegdezigzag[k++];
                            data[zig] = (short) (Stbiextendreceive(j, s) * (1 << shift));
                        }
                    }
                } while (k <= j.Specend);
            }
            else
            {
                short bit = (short) (1 << j.Succlow);
                if (j.Eobrun != 0)
                {
                    --j.Eobrun;
                    for (k = j.Specstart; k <= j.Specend; ++k)
                    {
                        short* p = &data[Stbijpegdezigzag[k]];
                        if (*p != 0)
                        {
                            if (Stbijpeggetbit(j) != 0)
                            {
                                if ((*p & bit) == 0)
                                {
                                    if (*p > 0)
                                    {
                                        *p += bit;
                                    }
                                    else
                                    {
                                        *p -= bit;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    k = j.Specstart;
                    do
                    {
                        int r = 0;
                        int s = 0;
                        int rs = Stbijpeghuffdecode(j, hac);
                        if (rs < 0)
                        {
                            return Stbierr("bad huffman code");
                        }

                        s = rs & 15;
                        r = rs >> 4;
                        if (s == 0)
                        {
                            if (r < 15)
                            {
                                j.Eobrun = (1 << r) - 1;
                                if (r != 0)
                                {
                                    j.Eobrun += Stbijpeggetbits(j, r);
                                }

                                r = 64;
                            }
                        }
                        else
                        {
                            if (s != 1)
                            {
                                return Stbierr("bad huffman code");
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

                        while (k <= j.Specend)
                        {
                            short* p = &data[Stbijpegdezigzag[k++]];
                            if (*p != 0)
                            {
                                if (Stbijpeggetbit(j) != 0)
                                {
                                    if ((*p & bit) == 0)
                                    {
                                        if (*p > 0)
                                        {
                                            *p += bit;
                                        }
                                        else
                                        {
                                            *p -= bit;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (r == 0)
                                {
                                    *p = (short) s;
                                    break;
                                }

                                --r;
                            }
                        }
                    } while (k <= j.Specend);
                }
            }

            return 1;
        }

        /// <summary>
        ///     Stbis the idct block using the specified  @out
        /// </summary>
        /// <param name="@out">The @out</param>
        /// <param name="outstride">The @out stride</param>
        /// <param name="data">The data</param>
        public static void Stbiidctblock(IntPtr @out, int outstride, IntPtr data)
        {
            int i = 0;
            int* val = stackalloc int[64];
            int* v = val;
            byte* o;
            short* d = (short*) data;
            for (i = 0; i < 8; ++i, ++d, ++v)
            {
                if ((d[8] == 0) && (d[16] == 0) && (d[24] == 0) && (d[32] == 0) && (d[40] == 0) && (d[48] == 0) && (d[56] == 0))
                {
                    int dcterm = d[0] * 4;
                    v[0] = v[8] = v[16] = v[24] = v[32] = v[40] = v[48] = v[56] = dcterm;
                }
                else
                {
                    int t0 = 0;
                    int t1 = 0;
                    int t2 = 0;
                    int t3 = 0;
                    int p1 = 0;
                    int p2 = 0;
                    int p3 = 0;
                    int p4 = 0;
                    int p5 = 0;
                    int x0 = 0;
                    int x1 = 0;
                    int x2 = 0;
                    int x3 = 0;
                    p2 = d[16];
                    p3 = d[48];
                    p1 = (p2 + p3) * (int) (0.5411961f * 4096 + 0.5);
                    t2 = p1 + p3 * (int) (-1.847759065f * 4096 + 0.5);
                    t3 = p1 + p2 * (int) (0.765366865f * 4096 + 0.5);
                    p2 = d[0];
                    p3 = d[32];
                    t0 = (p2 + p3) * 4096;
                    t1 = (p2 - p3) * 4096;
                    x0 = t0 + t3;
                    x3 = t0 - t3;
                    x1 = t1 + t2;
                    x2 = t1 - t2;
                    t0 = d[56];
                    t1 = d[40];
                    t2 = d[24];
                    t3 = d[8];
                    p3 = t0 + t2;
                    p4 = t1 + t3;
                    p1 = t0 + t3;
                    p2 = t1 + t2;
                    p5 = (p3 + p4) * (int) (1.175875602f * 4096 + 0.5);
                    t0 = t0 * (int) (0.298631336f * 4096 + 0.5);
                    t1 = t1 * (int) (2.053119869f * 4096 + 0.5);
                    t2 = t2 * (int) (3.072711026f * 4096 + 0.5);
                    t3 = t3 * (int) (1.501321110f * 4096 + 0.5);
                    p1 = p5 + p1 * (int) (-0.899976223f * 4096 + 0.5);
                    p2 = p5 + p2 * (int) (-2.562915447f * 4096 + 0.5);
                    p3 = p3 * (int) (-1.961570560f * 4096 + 0.5);
                    p4 = p4 * (int) (-0.390180644f * 4096 + 0.5);
                    t3 += p1 + p4;
                    t2 += p2 + p3;
                    t1 += p2 + p4;
                    t0 += p1 + p3;
                    x0 += 512;
                    x1 += 512;
                    x2 += 512;
                    x3 += 512;
                    v[0] = (x0 + t3) >> 10;
                    v[56] = (x0 - t3) >> 10;
                    v[8] = (x1 + t2) >> 10;
                    v[48] = (x1 - t2) >> 10;
                    v[16] = (x2 + t1) >> 10;
                    v[40] = (x2 - t1) >> 10;
                    v[24] = (x3 + t0) >> 10;
                    v[32] = (x3 - t0) >> 10;
                }
            }

            for (i = 0, v = val, o = (byte*) @out; i < 8; ++i, v += 8, o += outstride)
            {
                int t0 = 0;
                int t1 = 0;
                int t2 = 0;
                int t3 = 0;
                int p1 = 0;
                int p2 = 0;
                int p3 = 0;
                int p4 = 0;
                int p5 = 0;
                int x0 = 0;
                int x1 = 0;
                int x2 = 0;
                int x3 = 0;
                p2 = v[2];
                p3 = v[6];
                p1 = (p2 + p3) * (int) (0.5411961f * 4096 + 0.5);
                t2 = p1 + p3 * (int) (-1.847759065f * 4096 + 0.5);
                t3 = p1 + p2 * (int) (0.765366865f * 4096 + 0.5);
                p2 = v[0];
                p3 = v[4];
                t0 = (p2 + p3) * 4096;
                t1 = (p2 - p3) * 4096;
                x0 = t0 + t3;
                x3 = t0 - t3;
                x1 = t1 + t2;
                x2 = t1 - t2;
                t0 = v[7];
                t1 = v[5];
                t2 = v[3];
                t3 = v[1];
                p3 = t0 + t2;
                p4 = t1 + t3;
                p1 = t0 + t3;
                p2 = t1 + t2;
                p5 = (p3 + p4) * (int) (1.175875602f * 4096 + 0.5);
                t0 = t0 * (int) (0.298631336f * 4096 + 0.5);
                t1 = t1 * (int) (2.053119869f * 4096 + 0.5);
                t2 = t2 * (int) (3.072711026f * 4096 + 0.5);
                t3 = t3 * (int) (1.501321110f * 4096 + 0.5);
                p1 = p5 + p1 * (int) (-0.899976223f * 4096 + 0.5);
                p2 = p5 + p2 * (int) (-2.562915447f * 4096 + 0.5);
                p3 = p3 * (int) (-1.961570560f * 4096 + 0.5);
                p4 = p4 * (int) (-0.390180644f * 4096 + 0.5);
                t3 += p1 + p4;
                t2 += p2 + p3;
                t1 += p2 + p4;
                t0 += p1 + p3;
                x0 += 65536 + (128 << 17);
                x1 += 65536 + (128 << 17);
                x2 += 65536 + (128 << 17);
                x3 += 65536 + (128 << 17);
                o[0] = Stbiclamp((x0 + t3) >> 17);
                o[7] = Stbiclamp((x0 - t3) >> 17);
                o[1] = Stbiclamp((x1 + t2) >> 17);
                o[6] = Stbiclamp((x1 - t2) >> 17);
                o[2] = Stbiclamp((x2 + t1) >> 17);
                o[5] = Stbiclamp((x2 - t1) >> 17);
                o[3] = Stbiclamp((x3 + t0) >> 17);
                o[4] = Stbiclamp((x3 - t0) >> 17);
            }
        }

        /// <summary>
        ///     Stbis the get marker using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <returns>The </returns>
        public static byte Stbigetmarker(Stbijpeg j)
        {
            byte x = 0;
            if (j.Marker != 0xff)
            {
                x = j.Marker;
                j.Marker = 0xff;
                return x;
            }

            x = Stbiget8(j.S);
            if (x != 0xff)
            {
                return 0xff;
            }

            while (x == 0xff)
            {
                x = Stbiget8(j.S);
            }

            return x;
        }

        /// <summary>
        ///     Stbis the jpeg reset using the specified j
        /// </summary>
        /// <param name="j">The </param>
        public static void Stbijpegreset(Stbijpeg j)
        {
            j.Codebits = 0;
            j.Codebuffer = 0;
            j.Nomore = 0;
            j.Imgcomp[0].dcpred = j.Imgcomp[1].dcpred = j.Imgcomp[2].dcpred = j.Imgcomp[3].dcpred = 0;
            j.Marker = 0xff;
            j.Todo = j.Restartinterval != 0 ? j.Restartinterval : 0x7fffffff;
            j.Eobrun = 0;
        }

        /// <summary>
        ///     Stbis the parse entropy coded data using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <returns>The int</returns>
        public static int Stbiparseentropycodeddata(Stbijpeg z)
        {
            Stbijpegreset(z);
            if (z.Progressive == 0)
            {
                if (z.Scann == 1)
                {
                    int i = 0;
                    int j = 0;
                    short* data = stackalloc short[64];
                    int n = z.Order[0];
                    int w = (z.Imgcomp[n].x + 7) >> 3;
                    int h = (z.Imgcomp[n].y + 7) >> 3;
                    for (j = 0; j < h; ++j)
                    for (i = 0; i < w; ++i)
                    {
                        int ha = z.Imgcomp[n].ha;
                        fixed (Stbihuffman* dptr = &z.Huffdc[z.Imgcomp[n].hd])
                        fixed (Stbihuffman* aptr = &z.Huffac[ha])
                        {
                            if (Stbijpegdecodeblock(z, data, dptr, aptr,
                                    z.Fastac[ha], n, z.Dequant[z.Imgcomp[n].tq]) == 0)
                            {
                                return 0;
                            }
                        }

                        z.Idctblockkernel(z.Imgcomp[n].data + z.Imgcomp[n].w2 * j * 8 + i * 8, z.Imgcomp[n].w2, (IntPtr) data);

                        if (--z.Todo <= 0)
                        {
                            if (z.Codebits < 24)
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
                    for (j = 0; j < z.Imgmcuy; ++j)
                    for (i = 0; i < z.Imgmcux; ++i)
                    {
                        for (k = 0; k < z.Scann; ++k)
                        {
                            int n = z.Order[k];
                            for (y = 0; y < z.Imgcomp[n].v; ++y)
                            for (x = 0; x < z.Imgcomp[n].h; ++x)
                            {
                                int x2 = (i * z.Imgcomp[n].h + x) * 8;
                                int y2 = (j * z.Imgcomp[n].v + y) * 8;
                                int ha = z.Imgcomp[n].ha;

                                fixed (Stbihuffman* dptr = &z.Huffdc[z.Imgcomp[n].hd])
                                fixed (Stbihuffman* aptr = &z.Huffac[ha])
                                {
                                    if (Stbijpegdecodeblock(z, data, dptr, aptr,
                                            z.Fastac[ha], n, z.Dequant[z.Imgcomp[n].tq]) == 0)
                                    {
                                        return 0;
                                    }
                                }

                                z.Idctblockkernel(z.Imgcomp[n].data + z.Imgcomp[n].w2 * y2 + x2, z.Imgcomp[n].w2,
                                    (IntPtr) data);
                            }
                        }

                        if (--z.Todo <= 0)
                        {
                            if (z.Codebits < 24)
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

            if (z.Scann == 1)
            {
                int i = 0;
                int j = 0;
                int n = z.Order[0];
                int w = (z.Imgcomp[n].x + 7) >> 3;
                int h = (z.Imgcomp[n].y + 7) >> 3;
                for (j = 0; j < h; ++j)
                for (i = 0; i < w; ++i)
                {
                    short* data = (short*) (z.Imgcomp[n].coeff + 64 * (i + j * z.Imgcomp[n].coeffw));

                    if (z.Specstart == 0)
                    {
                        fixed (Stbihuffman* dptr = &z.Huffdc[z.Imgcomp[n].hd])
                        {
                            if (Stbijpegdecodeblockprogdc(z, data, dptr, n) == 0)
                            {
                                return 0;
                            }
                        }
                    }
                    else
                    {
                        int ha = z.Imgcomp[n].ha;
                        fixed (Stbihuffman* aptr = &z.Huffac[ha])
                        {
                            if (Stbijpegdecodeblockprogac(z, data, aptr, z.Fastac[ha]) == 0)
                            {
                                return 0;
                            }
                        }
                    }

                    if (--z.Todo <= 0)
                    {
                        if (z.Codebits < 24)
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
                for (j = 0; j < z.Imgmcuy; ++j)
                for (i = 0; i < z.Imgmcux; ++i)
                {
                    for (k = 0; k < z.Scann; ++k)
                    {
                        int n = z.Order[k];
                        for (y = 0; y < z.Imgcomp[n].v; ++y)
                        for (x = 0; x < z.Imgcomp[n].h; ++x)
                        {
                            int x2 = i * z.Imgcomp[n].h + x;
                            int y2 = j * z.Imgcomp[n].v + y;
                            short* data = (short*) (z.Imgcomp[n].coeff + 64 * (x2 + y2 * z.Imgcomp[n].coeffw));


                            fixed (Stbihuffman* dptr = &z.Huffdc[z.Imgcomp[n].hd])
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
                        if (z.Codebits < 24)
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
        public static void Stbijpegfinish(Stbijpeg z)
        {
            if (z.Progressive != 0)
            {
                int i = 0;
                int j = 0;
                int n = 0;
                for (n = 0; n < z.S.Imgn; ++n)
                {
                    int w = (z.Imgcomp[n].x + 7) >> 3;
                    int h = (z.Imgcomp[n].y + 7) >> 3;
                    for (j = 0; j < h; ++j)
                    for (i = 0; i < w; ++i)
                    {
                        short* data = (short*) (z.Imgcomp[n].coeff + 64 * (i + j * z.Imgcomp[n].coeffw));
                        Stbijpegdequantize(data, z.Dequant[z.Imgcomp[n].tq]);
                        z.Idctblockkernel(z.Imgcomp[n].data + z.Imgcomp[n].w2 * j * 8 + i * 8, z.Imgcomp[n].w2,
                            (IntPtr) data);
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
        public static int Stbiprocessmarker(Stbijpeg z, int m)
        {
            int l = 0;
            switch (m)
            {
                case 0xff:
                    return Stbierr("expected marker");
                case 0xDD:
                    if (Stbiget16Be(z.S) != 4)
                    {
                        return Stbierr("bad DRI len");
                    }

                    z.Restartinterval = Stbiget16Be(z.S);
                    return 1;
                case 0xDB:
                    l = Stbiget16Be(z.S) - 2;
                    while (l > 0)
                    {
                        int q = Stbiget8(z.S);
                        int p = q >> 4;
                        int sixteen = p != 0 ? 1 : 0;
                        int t = q & 15;
                        int i = 0;
                        if ((p != 0) && (p != 1))
                        {
                            return Stbierr("bad DQT type");
                        }

                        if (t > 3)
                        {
                            return Stbierr("bad DQT table");
                        }

                        for (i = 0; i < 64; ++i)
                        {
                            z.Dequant[t][Stbijpegdezigzag[i]] =
                                (ushort) (sixteen != 0 ? Stbiget16Be(z.S) : Stbiget8(z.S));
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
                        int q = Stbiget8(z.S);
                        int tc = q >> 4;
                        int th = q & 15;
                        if (tc > 1 || th > 3)
                        {
                            return Stbierr("bad DHT header");
                        }

                        for (i = 0; i < 16; ++i)
                        {
                            sizes[i] = Stbiget8(z.S);
                            n += sizes[i];
                        }

                        if (n > 256)
                        {
                            return Stbierr("bad DHT header");
                        }

                        l -= 17;
                        if (tc == 0)
                        {
                            fixed (Stbihuffman* hptr = &z.Huffdc[th])
                            {
                                if (Stbibuildhuffman(hptr, sizes) == 0)
                                {
                                    return 0;
                                }

                                byte* v = hptr->values;
                                for (i = 0; i < n; ++i)
                                {
                                    v[i] = Stbiget8(z.S);
                                }
                            }
                        }
                        else
                        {
                            fixed (Stbihuffman* aptr = &z.Huffac[th])
                            {
                                if (Stbibuildhuffman(aptr, sizes) == 0)
                                {
                                    return 0;
                                }

                                byte* v = aptr->values;
                                for (i = 0; i < n; ++i)
                                {
                                    v[i] = Stbiget8(z.S);
                                }
                            }
                        }

                        if (tc != 0)
                        {
                            fixed (Stbihuffman* aptr = &z.Huffac[th])
                            {
                                Stbibuildfastac(z.Fastac[th], aptr);
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
                        return Stbierr("bad COM len");
                    }

                    return Stbierr("bad APP len");
                }

                l -= 2;
                if ((m == 0xE0) && (l >= 5))
                {
                    int ok = 1;
                    int i = 0;
                    for (i = 0; i < 5; ++i)
                    {
                        if (Stbiget8(z.S) != Stbiprocessmarkertag[i])
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
                        if (Stbiget8(z.S) != Stbiprocessmarkertag[i])
                        {
                            ok = 0;
                        }
                    }

                    l -= 6;
                    if (ok != 0)
                    {
                        Stbiget8(z.S);
                        Stbiget16Be(z.S);
                        Stbiget16Be(z.S);
                        z.App14Colortransform = Stbiget8(z.S);
                        l -= 6;
                    }
                }

                Stbiskip(z.S, l);
                return 1;
            }

            return Stbierr("unknown marker");
        }

        /// <summary>
        ///     Stbis the process scan header using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <returns>The int</returns>
        public static int Stbiprocessscanheader(Stbijpeg z)
        {
            int i = 0;
            int ls = Stbiget16Be(z.S);
            z.Scann = Stbiget8(z.S);
            if (z.Scann < 1 || z.Scann > 4 || z.Scann > z.S.Imgn)
            {
                return Stbierr("bad SOS component count");
            }

            if (ls != 6 + 2 * z.Scann)
            {
                return Stbierr("bad SOS len");
            }

            for (i = 0; i < z.Scann; ++i)
            {
                int id = Stbiget8(z.S);
                int which = 0;
                int q = Stbiget8(z.S);
                for (which = 0; which < z.S.Imgn; ++which)
                {
                    if (z.Imgcomp[which].id == id)
                    {
                        break;
                    }
                }

                if (which == z.S.Imgn)
                {
                    return 0;
                }

                z.Imgcomp[which].hd = q >> 4;
                if (z.Imgcomp[which].hd > 3)
                {
                    return Stbierr("bad DC huff");
                }

                z.Imgcomp[which].ha = q & 15;
                if (z.Imgcomp[which].ha > 3)
                {
                    return Stbierr("bad AC huff");
                }

                z.Order[i] = which;
            }

            {
                int aa = 0;
                z.Specstart = Stbiget8(z.S);
                z.Specend = Stbiget8(z.S);
                aa = Stbiget8(z.S);
                z.Succhigh = aa >> 4;
                z.Succlow = aa & 15;
                if (z.Progressive != 0)
                {
                    if (z.Specstart > 63 || z.Specend > 63 || z.Specstart > z.Specend || z.Succhigh > 13 ||
                        z.Succlow > 13)
                    {
                        return Stbierr("bad SOS");
                    }
                }
                else
                {
                    if (z.Specstart != 0)
                    {
                        return Stbierr("bad SOS");
                    }

                    if (z.Succhigh != 0 || z.Succlow != 0)
                    {
                        return Stbierr("bad SOS");
                    }

                    z.Specend = 63;
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
        public static int Stbifreejpegcomponents(Stbijpeg z, int ncomp, int why)
        {
            int i = 0;
            for (i = 0; i < ncomp; ++i)
            {
                if (z.Imgcomp[i].rawdata != IntPtr.Zero)
                {
                    CRuntime.Free((void*) z.Imgcomp[i].rawdata);
                    z.Imgcomp[i].rawdata = IntPtr.Zero;
                    z.Imgcomp[i].data = IntPtr.Zero;
                }

                if (z.Imgcomp[i].rawcoeff != IntPtr.Zero)
                {
                    CRuntime.Free((void*) z.Imgcomp[i].rawcoeff);
                    z.Imgcomp[i].rawcoeff = IntPtr.Zero;
                    z.Imgcomp[i].coeff = IntPtr.Zero;
                }

                if (z.Imgcomp[i].linebuf != IntPtr.Zero)
                {
                    CRuntime.Free((void*) z.Imgcomp[i].linebuf);
                    z.Imgcomp[i].linebuf = IntPtr.Zero;
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
        public static int Stbiprocessframeheader(Stbijpeg z, int scan)
        {
            Stbicontext s = z.S;
            int lf = 0;
            int p = 0;
            int i = 0;
            int q = 0;
            int hmax = 1;
            int vmax = 1;
            int c = 0;
            lf = Stbiget16Be(s);
            if (lf < 11)
            {
                return Stbierr("bad SOF len");
            }

            p = Stbiget8(s);
            if (p != 8)
            {
                return Stbierr("only 8-bit");
            }

            s.Imgy = (uint) Stbiget16Be(s);
            if (s.Imgy == 0)
            {
                return Stbierr("no header height");
            }

            s.Imgx = (uint) Stbiget16Be(s);
            if (s.Imgx == 0)
            {
                return Stbierr("0 width");
            }

            if (s.Imgy > 1 << 24)
            {
                return Stbierr("too large");
            }

            if (s.Imgx > 1 << 24)
            {
                return Stbierr("too large");
            }

            c = Stbiget8(s);
            if ((c != 3) && (c != 1) && (c != 4))
            {
                return Stbierr("bad component count");
            }

            s.Imgn = c;
            for (i = 0; i < c; ++i)
            {
                z.Imgcomp[i].data = IntPtr.Zero;
                z.Imgcomp[i].linebuf = IntPtr.Zero;
            }

            if (lf != 8 + 3 * s.Imgn)
            {
                return Stbierr("bad SOF len");
            }

            z.Rgb = 0;
            for (i = 0; i < s.Imgn; ++i)
            {
                z.Imgcomp[i].id = Stbiget8(s);
                if ((s.Imgn == 3) && (z.Imgcomp[i].id == Stbiprocessframeheaderrgb[i]))
                {
                    ++z.Rgb;
                }

                q = Stbiget8(s);
                z.Imgcomp[i].h = q >> 4;
                if (z.Imgcomp[i].h == 0 || z.Imgcomp[i].h > 4)
                {
                    return Stbierr("bad H");
                }

                z.Imgcomp[i].v = q & 15;
                if (z.Imgcomp[i].v == 0 || z.Imgcomp[i].v > 4)
                {
                    return Stbierr("bad V");
                }

                z.Imgcomp[i].tq = Stbiget8(s);
                if (z.Imgcomp[i].tq > 3)
                {
                    return Stbierr("bad TQ");
                }
            }

            if (scan != StbiscaNload)
            {
                return 1;
            }

            if (Stbimad3Sizesvalid((int) s.Imgx, (int) s.Imgy, s.Imgn, 0) == 0)
            {
                return Stbierr("too large");
            }

            for (i = 0; i < s.Imgn; ++i)
            {
                if (z.Imgcomp[i].h > hmax)
                {
                    hmax = z.Imgcomp[i].h;
                }

                if (z.Imgcomp[i].v > vmax)
                {
                    vmax = z.Imgcomp[i].v;
                }
            }

            for (i = 0; i < s.Imgn; ++i)
            {
                if (hmax % z.Imgcomp[i].h != 0)
                {
                    return Stbierr("bad H");
                }

                if (vmax % z.Imgcomp[i].v != 0)
                {
                    return Stbierr("bad V");
                }
            }

            z.Imghmax = hmax;
            z.Imgvmax = vmax;
            z.Imgmcuw = hmax * 8;
            z.Imgmcuh = vmax * 8;
            z.Imgmcux = (int) ((s.Imgx + z.Imgmcuw - 1) / z.Imgmcuw);
            z.Imgmcuy = (int) ((s.Imgy + z.Imgmcuh - 1) / z.Imgmcuh);
            for (i = 0; i < s.Imgn; ++i)
            {
                z.Imgcomp[i].x = (int) ((s.Imgx * z.Imgcomp[i].h + hmax - 1) / hmax);
                z.Imgcomp[i].y = (int) ((s.Imgy * z.Imgcomp[i].v + vmax - 1) / vmax);
                z.Imgcomp[i].w2 = z.Imgmcux * z.Imgcomp[i].h * 8;
                z.Imgcomp[i].h2 = z.Imgmcuy * z.Imgcomp[i].v * 8;
                z.Imgcomp[i].coeff = IntPtr.Zero;
                z.Imgcomp[i].rawcoeff = IntPtr.Zero;
                z.Imgcomp[i].linebuf = IntPtr.Zero;
                z.Imgcomp[i].rawdata = (IntPtr) Stbimallocmad2(z.Imgcomp[i].w2, z.Imgcomp[i].h2, 15);
                if (z.Imgcomp[i].rawdata == IntPtr.Zero)
                {
                    return Stbifreejpegcomponents(z, i + 1, Stbierr("outofmem"));
                }

                z.Imgcomp[i].data = (IntPtr) (((long) z.Imgcomp[i].rawdata + 15) & ~15);
                if (z.Progressive != 0)
                {
                    z.Imgcomp[i].coeffw = z.Imgcomp[i].w2 / 8;
                    z.Imgcomp[i].coeffh = z.Imgcomp[i].h2 / 8;
                    z.Imgcomp[i].rawcoeff = (IntPtr) Stbimallocmad3(z.Imgcomp[i].w2, z.Imgcomp[i].h2, sizeof(short), 15);
                    if (z.Imgcomp[i].rawcoeff == IntPtr.Zero)
                    {
                        return Stbifreejpegcomponents(z, i + 1, Stbierr("outofmem"));
                    }

                    z.Imgcomp[i].coeff = (IntPtr) (((long) z.Imgcomp[i].rawcoeff + 15) & ~15);
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
        public static int Stbidecodejpegheader(Stbijpeg z, int scan)
        {
            int m = 0;
            z.Jfif = 0;
            z.App14Colortransform = -1;
            z.Marker = 0xff;
            m = Stbigetmarker(z);
            if (!(m == 0xd8))
            {
                return Stbierr("no SOI");
            }

            if (scan == StbiscaNtype)
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
                    if (Stbiateof(z.S) != 0)
                    {
                        return Stbierr("no SOF");
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
        public static byte Stbiskipjpegjunkatend(Stbijpeg j)
        {
            while (Stbiateof(j.S) == 0)
            {
                byte x = Stbiget8(j.S);
                while (x == 0xff)
                {
                    if (Stbiateof(j.S) != 0)
                    {
                        return 0xff;
                    }

                    x = Stbiget8(j.S);
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
        public static int Stbidecodejpegimage(Stbijpeg j)
        {
            int m = 0;
            for (m = 0; m < 4; m++)
            {
                j.Imgcomp[m].rawdata = IntPtr.Zero;
                j.Imgcomp[m].rawcoeff = IntPtr.Zero;
            }

            j.Restartinterval = 0;
            if (Stbidecodejpegheader(j, StbiscaNload) == 0)
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
                        return Stbierr("bad DNL len");
                    }

                    if (nl != j.S.Imgy)
                    {
                        return Stbierr("bad DNL height");
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
        ///     Resamples the row 1 using the specified  @out
        /// </summary>
        /// <param name="@out">The @out</param>
        /// <param name="innear">The in near</param>
        /// <param name="infar">The in far</param>
        /// <param name="w">The </param>
        /// <param name="hs">The hs</param>
        /// <returns>The in near</returns>
        public static IntPtr Resamplerow1(IntPtr @out, IntPtr innear, IntPtr infar, int w, int hs) => innear;

        /// <summary>
        ///     Stbis the resample row v 2 using the specified  @out
        /// </summary>
        /// <param name="@out">The @out</param>
        /// <param name="innear">The in near</param>
        /// <param name="infar">The in far</param>
        /// <param name="w">The </param>
        /// <param name="hs">The hs</param>
        /// <returns>The @out</returns>
        public static IntPtr Stbiresamplerowv2(IntPtr outPtr, IntPtr innearPtr, IntPtr infarPtr, int w, int hs)
        {
            byte* @out = (byte*) outPtr;
            byte* innear = (byte*) innearPtr;
            byte* infar = (byte*) infarPtr;

            int i = 0;
            for (i = 0; i < w; ++i)
            {
                @out[i] = (byte) ((3 * innear[i] + infar[i] + 2) >> 2);
            }

            return (IntPtr) @out;
        }

        /// <summary>
        ///     Stbis the resample row h 2 using the specified  @out
        /// </summary>
        /// <param name="@out">The @out</param>
        /// <param name="innear">The in near</param>
        /// <param name="infar">The in far</param>
        /// <param name="w">The </param>
        /// <param name="hs">The hs</param>
        /// <returns>The @out</returns>
        public static IntPtr Stbiresamplerowh2(IntPtr outPtr, IntPtr innearPtr, IntPtr infarPtr, int w, int hs)
        {
            byte* @out = (byte*) outPtr;
            byte* innear = (byte*) innearPtr;
            byte* infar = (byte*) infarPtr;

            int i = 0;
            byte* input = innear;
            if (w == 1)
            {
                @out[0] = @out[1] = input[0];
                return (IntPtr) @out;
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
            return (IntPtr) @out;
        }

        /// <summary>
        ///     Stbis the resample row hv 2 using the specified  @out
        /// </summary>
        /// <param name="@out">The @out</param>
        /// <param name="innear">The in near</param>
        /// <param name="infar">The in far</param>
        /// <param name="w">The </param>
        /// <param name="hs">The hs</param>
        /// <returns>The @out</returns>
        public static IntPtr Stbiresamplerowhv2(IntPtr outPtr, IntPtr innearPtr, IntPtr infarPtr, int w, int hs)
        {
            byte* @out = (byte*) outPtr;
            byte* innear = (byte*) innearPtr;
            byte* infar = (byte*) infarPtr;

            int i = 0;
            int t0 = 0;
            int t1 = 0;
            if (w == 1)
            {
                @out[0] = @out[1] = (byte) ((3 * innear[0] + infar[0] + 2) >> 2);
                return (IntPtr) @out;
            }

            t1 = 3 * innear[0] + infar[0];
            @out[0] = (byte) ((t1 + 2) >> 2);
            for (i = 1; i < w; ++i)
            {
                t0 = t1;
                t1 = 3 * innear[i] + infar[i];
                @out[i * 2 - 1] = (byte) ((3 * t0 + t1 + 8) >> 4);
                @out[i * 2] = (byte) ((3 * t1 + t0 + 8) >> 4);
            }

            @out[w * 2 - 1] = (byte) ((t1 + 2) >> 2);
            return (IntPtr) @out;
        }

        /// <summary>
        ///     Stbis the resample row generic using the specified  @out
        /// </summary>
        /// <param name="@out">The @out</param>
        /// <param name="innear">The in near</param>
        /// <param name="infar">The in far</param>
        /// <param name="w">The </param>
        /// <param name="hs">The hs</param>
        /// <returns>The @out</returns>
        public static IntPtr Stbiresamplerowgeneric(IntPtr outPtr, IntPtr innearPtr, IntPtr infarPtr, int w, int hs)
        {
            byte* @out = (byte*) outPtr;
            byte* innear = (byte*) innearPtr;
            byte* infar = (byte*) infarPtr;


            int i = 0;
            int j = 0;
            for (i = 0; i < w; ++i)
            for (j = 0; j < hs; ++j)
            {
                @out[i * hs + j] = innear[i];
            }

            return (IntPtr) @out;
        }

        /// <summary>
        ///     Stbis the y cb cr to rgb row using the specified  @out
        /// </summary>
        /// <param name="@out">The @out</param>
        /// <param name="y">The </param>
        /// <param name="pcb">The pcb</param>
        /// <param name="pcr">The pcr</param>
        /// <param name="count">The count</param>
        /// <param name="step">The step</param>
        public static void StbiYCbCrtoRgBrow(IntPtr outPtr, IntPtr yPtr, IntPtr pcbPtr, IntPtr pcrPtr, int count, int step)
        {
            byte* @out = (byte*) outPtr;
            int* y = (int*) yPtr;
            byte* pcb = (byte*) pcbPtr;
            byte* pcr = (byte*) pcrPtr;

            int i = 0;
            for (i = 0; i < count; ++i)
            {
                int yfixed = (y[i] << 20) + (1 << 19);
                int r = 0;
                int g = 0;
                int b = 0;
                int cr = pcr[i] - 128;
                int cb = pcb[i] - 128;
                r = yfixed + cr * ((int) (1.40200f * 4096.0f + 0.5f) << 8);
                g = (int) (yfixed + cr * -((int) (0.71414f * 4096.0f + 0.5f) << 8) +
                           ((cb * -((int) (0.34414f * 4096.0f + 0.5f) << 8)) & 0xffff0000));
                b = yfixed + cb * ((int) (1.77200f * 4096.0f + 0.5f) << 8);
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
        public static void Stbisetupjpeg(Stbijpeg j)
        {
            j.Idctblockkernel = Stbiidctblock;
            j.YCbCrtoRgBkernel = StbiYCbCrtoRgBrow;
            j.Resamplerowhv2Kernel = Stbiresamplerowhv2;
        }

        /// <summary>
        ///     Stbis the cleanup jpeg using the specified j
        /// </summary>
        /// <param name="j">The </param>
        public static void Stbicleanupjpeg(Stbijpeg j)
        {
            Stbifreejpegcomponents(j, j.S.Imgn, 0);
        }

        /// <summary>
        ///     Loads the jpeg image using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <param name="outx">The @out</param>
        /// <param name="outy">The @out</param>
        /// <param name="comp">The comp</param>
        /// <param name="reqcomp">The req comp</param>
        /// <returns>The byte</returns>
        public static byte* Loadjpegimage(Stbijpeg z, int* outx, int* outy, int* comp, int reqcomp)
        {
            int n = 0;
            int decoden = 0;
            int isrgb = 0;
            z.S.Imgn = 0;
            if (reqcomp < 0 || reqcomp > 4)
            {
                return (byte*) (ulong) (Stbierr("bad reqcomp") != 0 ? 0 : 0);
            }

            if (Stbidecodejpegimage(z) == 0)
            {
                Stbicleanupjpeg(z);
                return null;
            }

            n = reqcomp != 0 ? reqcomp : z.S.Imgn >= 3 ? 3 : 1;
            isrgb = (z.S.Imgn == 3) && (z.Rgb == 3 || ((z.App14Colortransform == 0) && (z.Jfif == 0))) ? 1 : 0;
            if ((z.S.Imgn == 3) && (n < 3) && (isrgb == 0))
            {
                decoden = 1;
            }
            else
            {
                decoden = z.S.Imgn;
            }

            if (decoden <= 0)
            {
                Stbicleanupjpeg(z);
                return null;
            }

            {
                int k = 0;
                uint i = 0;
                uint j = 0;
                byte* output;
                byte** coutput = stackalloc byte*[] {null, null, null, null};
                Stbiresample[] rescomp = new Stbiresample[4];
                rescomp[0] = new Stbiresample();
                rescomp[1] = new Stbiresample();
                rescomp[2] = new Stbiresample();
                rescomp[3] = new Stbiresample();
                for (k = 0; k < decoden; ++k)
                {
                    Stbiresample r = rescomp[k];
                    z.Imgcomp[k].linebuf = (IntPtr) Stbimalloc(z.S.Imgx + 3);
                    if (z.Imgcomp[k].linebuf == IntPtr.Zero)
                    {
                        Stbicleanupjpeg(z);
                        return (byte*) (ulong) (Stbierr("outofmem") != 0 ? 0 : 0);
                    }

                    r.Hs = z.Imghmax / z.Imgcomp[k].h;
                    r.Vs = z.Imgvmax / z.Imgcomp[k].v;
                    r.Ystep = r.Vs >> 1;
                    r.Wlores = (int) ((z.S.Imgx + r.Hs - 1) / r.Hs);
                    r.Ypos = 0;
                    r.Line0 = r.Line1 = z.Imgcomp[k].data;
                    if ((r.Hs == 1) && (r.Vs == 1))
                    {
                        r.Resample = Resamplerow1;
                    }
                    else if ((r.Hs == 1) && (r.Vs == 2))
                    {
                        r.Resample = Stbiresamplerowv2;
                    }
                    else if ((r.Hs == 2) && (r.Vs == 1))
                    {
                        r.Resample = Stbiresamplerowh2;
                    }
                    else if ((r.Hs == 2) && (r.Vs == 2))
                    {
                        r.Resample = z.Resamplerowhv2Kernel;
                    }
                    else
                    {
                        r.Resample = Stbiresamplerowgeneric;
                    }
                }

                output = (byte*) Stbimallocmad3(n, (int) z.S.Imgx, (int) z.S.Imgy, 1);
                if (output == null)
                {
                    Stbicleanupjpeg(z);
                    return (byte*) (ulong) (Stbierr("outofmem") != 0 ? 0 : 0);
                }

                for (j = 0; j < z.S.Imgy; ++j)
                {
                    byte* @out = output + n * z.S.Imgx * j;
                    for (k = 0; k < decoden; ++k)
                    {
                        Stbiresample r = rescomp[k];
                        int ybot = r.Ystep >= r.Vs >> 1 ? 1 : 0;
                        coutput[k] = (byte*) r.Resample(z.Imgcomp[k].linebuf, ybot != 0 ? r.Line1 : r.Line0,
                            ybot != 0 ? r.Line0 : r.Line1, r.Wlores, r.Hs);
                        if (++r.Ystep >= r.Vs)
                        {
                            r.Ystep = 0;
                            r.Line0 = r.Line1;
                            if (++r.Ypos < z.Imgcomp[k].y)
                            {
                                r.Line1 += z.Imgcomp[k].w2;
                            }
                        }
                    }

                    if (n >= 3)
                    {
                        byte* y = coutput[0];
                        if (z.S.Imgn == 3)
                        {
                            if (isrgb != 0)
                            {
                                for (i = 0; i < z.S.Imgx; ++i)
                                {
                                    @out[0] = y[i];
                                    @out[1] = coutput[1][i];
                                    @out[2] = coutput[2][i];
                                    @out[3] = 255;
                                    @out += n;
                                }
                            }
                            else
                            {
                                z.YCbCrtoRgBkernel((IntPtr) @out, (IntPtr) y, (IntPtr) coutput[1], (IntPtr) coutput[2], (int) z.S.Imgx, n);
                            }
                        }
                        else if (z.S.Imgn == 4)
                        {
                            if (z.App14Colortransform == 0)
                            {
                                for (i = 0; i < z.S.Imgx; ++i)
                                {
                                    byte m = coutput[3][i];
                                    @out[0] = Stbiblinn8X8(coutput[0][i], m);
                                    @out[1] = Stbiblinn8X8(coutput[1][i], m);
                                    @out[2] = Stbiblinn8X8(coutput[2][i], m);
                                    @out[3] = 255;
                                    @out += n;
                                }
                            }
                            else if (z.App14Colortransform == 2)
                            {
                                z.YCbCrtoRgBkernel((IntPtr) @out, (IntPtr) y, (IntPtr) coutput[1], (IntPtr) coutput[2], (int) z.S.Imgx, n);
                                for (i = 0; i < z.S.Imgx; ++i)
                                {
                                    byte m = coutput[3][i];
                                    @out[0] = Stbiblinn8X8((byte) (255 - @out[0]), m);
                                    @out[1] = Stbiblinn8X8((byte) (255 - @out[1]), m);
                                    @out[2] = Stbiblinn8X8((byte) (255 - @out[2]), m);
                                    @out += n;
                                }
                            }
                            else
                            {
                                z.YCbCrtoRgBkernel((IntPtr) @out, (IntPtr) y, (IntPtr) coutput[1], (IntPtr) coutput[2], (int) z.S.Imgx, n);
                            }
                        }
                        else
                        {
                            for (i = 0; i < z.S.Imgx; ++i)
                            {
                                @out[0] = @out[1] = @out[2] = y[i];
                                @out[3] = 255;
                                @out += n;
                            }
                        }
                    }
                    else
                    {
                        if (isrgb != 0)
                        {
                            if (n == 1)
                            {
                                for (i = 0; i < z.S.Imgx; ++i)
                                {
                                    *@out++ = Stbicomputey(coutput[0][i], coutput[1][i], coutput[2][i]);
                                }
                            }
                            else
                            {
                                for (i = 0; i < z.S.Imgx; ++i, @out += 2)
                                {
                                    @out[0] = Stbicomputey(coutput[0][i], coutput[1][i], coutput[2][i]);
                                    @out[1] = 255;
                                }
                            }
                        }
                        else if ((z.S.Imgn == 4) && (z.App14Colortransform == 0))
                        {
                            for (i = 0; i < z.S.Imgx; ++i)
                            {
                                byte m = coutput[3][i];
                                byte r = Stbiblinn8X8(coutput[0][i], m);
                                byte g = Stbiblinn8X8(coutput[1][i], m);
                                byte b = Stbiblinn8X8(coutput[2][i], m);
                                @out[0] = Stbicomputey(r, g, b);
                                @out[1] = 255;
                                @out += n;
                            }
                        }
                        else if ((z.S.Imgn == 4) && (z.App14Colortransform == 2))
                        {
                            for (i = 0; i < z.S.Imgx; ++i)
                            {
                                @out[0] = Stbiblinn8X8((byte) (255 - coutput[0][i]), coutput[3][i]);
                                @out[1] = 255;
                                @out += n;
                            }
                        }
                        else
                        {
                            byte* y = coutput[0];
                            if (n == 1)
                            {
                                for (i = 0; i < z.S.Imgx; ++i)
                                {
                                    @out[i] = y[i];
                                }
                            }
                            else
                            {
                                for (i = 0; i < z.S.Imgx; ++i)
                                {
                                    *@out++ = y[i];
                                    *@out++ = 255;
                                }
                            }
                        }
                    }
                }

                Stbicleanupjpeg(z);
                *outx = (int) z.S.Imgx;
                *outy = (int) z.S.Imgy;
                if (comp != null)
                {
                    *comp = z.S.Imgn >= 3 ? 3 : 1;
                }

                return output;
            }
        }

        /// <summary>
        ///     Stbis the jpeg info raw using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <returns>The int</returns>
        public static int Stbijpeginforaw(Stbijpeg j, int* x, int* y, int* comp)
        {
            if (Stbidecodejpegheader(j, StbiscaNheader) == 0)
            {
                Stbirewind(j.S);
                return 0;
            }

            if (x != null)
            {
                *x = (int) j.S.Imgx;
            }

            if (y != null)
            {
                *y = (int) j.S.Imgy;
            }

            if (comp != null)
            {
                *comp = j.S.Imgn >= 3 ? 3 : 1;
            }

            return 1;
        }

        /// <summary>
        ///     The stbi huffman
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Stbihuffman
        {
            /// <summary>
            ///     The fast
            /// </summary>
            public fixed byte fast[512];

            /// <summary>
            ///     The code
            /// </summary>
            public fixed ushort code[256];

            /// <summary>
            ///     The values
            /// </summary>
            public fixed byte values[256];

            /// <summary>
            ///     The size
            /// </summary>
            public fixed byte size[257];

            /// <summary>
            ///     The maxcode
            /// </summary>
            public fixed uint maxcode[18];

            /// <summary>
            ///     The delta
            /// </summary>
            public fixed int delta[17];
        }

        /// <summary>
        ///     The stbi jpeg class
        /// </summary>
        public class Stbijpeg
        {
            /// <summary>
            ///     The app14 color transform
            /// </summary>
            public int App14Colortransform;

            /// <summary>
            ///     The code bits
            /// </summary>
            public int Codebits;

            /// <summary>
            ///     The code buffer
            /// </summary>
            public uint Codebuffer;

            /// <summary>
            ///     The create array
            /// </summary>
            public ushort[][] Dequant = Utility.CreateArray<ushort>(4, 64);

            /// <summary>
            ///     The eob run
            /// </summary>
            public int Eobrun;

            /// <summary>
            ///     The create array
            /// </summary>
            public short[][] Fastac = Utility.CreateArray<short>(4, 512);

            /// <summary>
            ///     The stbi huffman
            /// </summary>
            public Stbihuffman[] Huffac = new Stbihuffman[4];

            /// <summary>
            ///     The stbi huffman
            /// </summary>
            public Stbihuffman[] Huffdc = new Stbihuffman[4];

            /// <summary>
            ///     The idct block kernel
            /// </summary>
            public Delegate0 Idctblockkernel;

            /// <summary>
            ///     The unnamed
            /// </summary>
            public Unnamed1[] Imgcomp = new Unnamed1[4];

            /// <summary>
            ///     The img max
            /// </summary>
            public int Imghmax;

            /// <summary>
            ///     The img mcu
            /// </summary>
            public int Imgmcuh;

            /// <summary>
            ///     The img mcu
            /// </summary>
            public int Imgmcuw;

            /// <summary>
            ///     The img mcu
            /// </summary>
            public int Imgmcux;

            /// <summary>
            ///     The img mcu
            /// </summary>
            public int Imgmcuy;

            /// <summary>
            ///     The img max
            /// </summary>
            public int Imgvmax;

            /// <summary>
            ///     The jfif
            /// </summary>
            public int Jfif;

            /// <summary>
            ///     The marker
            /// </summary>
            public byte Marker;

            /// <summary>
            ///     The nomore
            /// </summary>
            public int Nomore;

            /// <summary>
            ///     The order
            /// </summary>
            public int[] Order = new int[4];

            /// <summary>
            ///     The progressive
            /// </summary>
            public int Progressive;

            /// <summary>
            ///     The resample row hv kernel
            /// </summary>
            public Delegate2 Resamplerowhv2Kernel;

            /// <summary>
            ///     The restart interval
            /// </summary>
            public int Restartinterval;

            /// <summary>
            ///     The rgb
            /// </summary>
            public int Rgb;

            /// <summary>
            ///     The
            /// </summary>
            public Stbicontext S;

            /// <summary>
            ///     The scan
            /// </summary>
            public int Scann;

            /// <summary>
            ///     The spec end
            /// </summary>
            public int Specend;

            /// <summary>
            ///     The spec start
            /// </summary>
            public int Specstart;

            /// <summary>
            ///     The succ high
            /// </summary>
            public int Succhigh;

            /// <summary>
            ///     The succ low
            /// </summary>
            public int Succlow;

            /// <summary>
            ///     The todo
            /// </summary>
            public int Todo;

            /// <summary>
            ///     The ycbcr to rgb kernel
            /// </summary>
            public Delegate1 YCbCrtoRgBkernel;
        }
    }
}