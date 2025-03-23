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
        ///     The delegate
        /// </summary>
        public delegate void delegate0(byte* arg0, int arg1, short* arg2);

        /// <summary>
        ///     The delegate
        /// </summary>
        public delegate void delegate1(byte* arg0, byte* arg1, byte* arg2, byte* arg3, int arg4, int arg5);

        /// <summary>
        ///     The delegate
        /// </summary>
        public delegate byte* delegate2(byte* arg0, byte* arg1, byte* arg2, int arg3, int arg4);

        /// <summary>
        ///     The stbi bmask
        /// </summary>
        public static uint[] stbi__bmask =
            {0, 1, 3, 7, 15, 31, 63, 127, 255, 511, 1023, 2047, 4095, 8191, 16383, 32767, 65535};

        /// <summary>
        ///     The stbi jbias
        /// </summary>
        public static int[] stbi__jbias =
            {0, -1, -3, -7, -15, -31, -63, -127, -255, -511, -1023, -2047, -4095, -8191, -16383, -32767};

        /// <summary>
        ///     The stbi jpeg dezigzag
        /// </summary>
        public static byte[] stbi__jpeg_dezigzag =
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
        public static int stbi__jpeg_test(stbi__context s)
        {
            int r = 0;
            stbi__jpeg j = new stbi__jpeg();
            if (j == null)
            {
                return stbi__err("outofmem");
            }

            j.s = s;
            stbi__setup_jpeg(j);
            r = stbi__decode_jpeg_header(j, STBI__SCAN_type);
            stbi__rewind(s);
            return r;
        }

        /// <summary>
        ///     Stbis the jpeg load using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <param name="req_comp">The req comp</param>
        /// <param name="ri">The ri</param>
        /// <returns>The result</returns>
        public static void* stbi__jpeg_load(stbi__context s, int* x, int* y, int* comp, int req_comp,
            stbi__result_info* ri)
        {
            byte* result;
            stbi__jpeg j = new stbi__jpeg();
            if (j == null)
            {
                return (byte*) (ulong) (stbi__err("outofmem") != 0 ? 0 : 0);
            }

            j.s = s;
            stbi__setup_jpeg(j);
            result = load_jpeg_image(j, x, y, comp, req_comp);
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
        public static int stbi__jpeg_info(stbi__context s, int* x, int* y, int* comp)
        {
            int result = 0;
            stbi__jpeg j = new stbi__jpeg();
            if (j == null)
            {
                return stbi__err("outofmem");
            }

            j.s = s;
            result = stbi__jpeg_info_raw(j, x, y, comp);
            return result;
        }

        /// <summary>
        ///     Stbis the build huffman using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        public static int stbi__build_huffman(stbi__huffman* h, int* count)
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
                        return stbi__err("bad size list");
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
                        return stbi__err("bad code lengths");
                    }
                }

                h->maxcode[j] = code << (16 - j);
                code <<= 1;
            }

            h->maxcode[j] = 0xffffffff;
            CRuntime.memset(h->fast, 255, (ulong) (1 << 9));
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
        /// <param name="fast_ac">The fast ac</param>
        /// <param name="h">The </param>
        public static void stbi__build_fast_ac(short[] fast_ac, stbi__huffman* h)
        {
            int i = 0;
            for (i = 0; i < 1 << 9; ++i)
            {
                byte fast = h->fast[i];
                fast_ac[i] = 0;
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
                            fast_ac[i] = (short) (k * 256 + run * 16 + len + magbits);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Stbis the grow buffer unsafe using the specified j
        /// </summary>
        /// <param name="j">The </param>
        public static void stbi__grow_buffer_unsafe(stbi__jpeg j)
        {
            do
            {
                uint b = (uint) (j.nomore != 0 ? 0 : stbi__get8(j.s));
                if (b == 0xff)
                {
                    int c = stbi__get8(j.s);
                    while (c == 0xff)
                    {
                        c = stbi__get8(j.s);
                    }

                    if (c != 0)
                    {
                        j.marker = (byte) c;
                        j.nomore = 1;
                        return;
                    }
                }

                j.code_buffer |= b << (24 - j.code_bits);
                j.code_bits += 8;
            } while (j.code_bits <= 24);
        }

        /// <summary>
        ///     Stbis the jpeg huff decode using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        public static int stbi__jpeg_huff_decode(stbi__jpeg j, stbi__huffman* h)
        {
            uint temp = 0;
            int c = 0;
            int k = 0;
            if (j.code_bits < 16)
            {
                stbi__grow_buffer_unsafe(j);
            }

            c = (int) ((j.code_buffer >> (32 - 9)) & ((1 << 9) - 1));
            k = h->fast[c];
            if (k < 255)
            {
                int s = h->size[k];
                if (s > j.code_bits)
                {
                    return -1;
                }

                j.code_buffer <<= s;
                j.code_bits -= s;
                return h->values[k];
            }

            temp = j.code_buffer >> 16;
            for (k = 9 + 1;; ++k)
            {
                if (temp < h->maxcode[k])
                {
                    break;
                }
            }

            if (k == 17)
            {
                j.code_bits -= 16;
                return -1;
            }

            if (k > j.code_bits)
            {
                return -1;
            }

            c = (int) (((j.code_buffer >> (32 - k)) & stbi__bmask[k]) + h->delta[k]);
            if (c < 0 || c >= 256)
            {
                return -1;
            }

            j.code_bits -= k;
            j.code_buffer <<= k;
            return h->values[c];
        }

        /// <summary>
        ///     Stbis the extend receive using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <param name="n">The </param>
        /// <returns>The int</returns>
        public static int stbi__extend_receive(stbi__jpeg j, int n)
        {
            uint k = 0;
            int sgn = 0;
            if (j.code_bits < n)
            {
                stbi__grow_buffer_unsafe(j);
            }

            if (j.code_bits < n)
            {
                return 0;
            }

            sgn = (int) (j.code_buffer >> 31);
            k = CRuntime._lrotl(j.code_buffer, n);
            j.code_buffer = k & ~stbi__bmask[n];
            k &= stbi__bmask[n];
            j.code_bits -= n;
            return (int) (k + (stbi__jbias[n] & (sgn - 1)));
        }

        /// <summary>
        ///     Stbis the jpeg get bits using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <param name="n">The </param>
        /// <returns>The int</returns>
        public static int stbi__jpeg_get_bits(stbi__jpeg j, int n)
        {
            uint k = 0;
            if (j.code_bits < n)
            {
                stbi__grow_buffer_unsafe(j);
            }

            if (j.code_bits < n)
            {
                return 0;
            }

            k = CRuntime._lrotl(j.code_buffer, n);
            j.code_buffer = k & ~stbi__bmask[n];
            k &= stbi__bmask[n];
            j.code_bits -= n;
            return (int) k;
        }

        /// <summary>
        ///     Stbis the jpeg get bit using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <returns>The int</returns>
        public static int stbi__jpeg_get_bit(stbi__jpeg j)
        {
            uint k = 0;
            if (j.code_bits < 1)
            {
                stbi__grow_buffer_unsafe(j);
            }

            if (j.code_bits < 1)
            {
                return 0;
            }

            k = j.code_buffer;
            j.code_buffer <<= 1;
            --j.code_bits;
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
        public static int stbi__jpeg_decode_block(stbi__jpeg j, short* data, stbi__huffman* hdc, stbi__huffman* hac,
            short[] fac, int b, ushort[] dequant)
        {
            int diff = 0;
            int dc = 0;
            int k = 0;
            int t = 0;
            if (j.code_bits < 16)
            {
                stbi__grow_buffer_unsafe(j);
            }

            t = stbi__jpeg_huff_decode(j, hdc);
            if (t < 0 || t > 15)
            {
                return stbi__err("bad huffman code");
            }

            CRuntime.memset(data, 0, (ulong) (64 * sizeof(short)));
            diff = t != 0 ? stbi__extend_receive(j, t) : 0;
            if (stbi__addints_valid(j.img_comp[b].dc_pred, diff) == 0)
            {
                return stbi__err("bad delta");
            }

            dc = j.img_comp[b].dc_pred + diff;
            j.img_comp[b].dc_pred = dc;
            if (stbi__mul2shorts_valid(dc, dequant[0]) == 0)
            {
                return stbi__err("can't merge dc and ac");
            }

            data[0] = (short) (dc * dequant[0]);
            k = 1;
            do
            {
                uint zig = 0;
                int c = 0;
                int r = 0;
                int s = 0;
                if (j.code_bits < 16)
                {
                    stbi__grow_buffer_unsafe(j);
                }

                c = (int) ((j.code_buffer >> (32 - 9)) & ((1 << 9) - 1));
                r = fac[c];
                if (r != 0)
                {
                    k += (r >> 4) & 15;
                    s = r & 15;
                    if (s > j.code_bits)
                    {
                        return stbi__err("bad huffman code");
                    }

                    j.code_buffer <<= s;
                    j.code_bits -= s;
                    zig = stbi__jpeg_dezigzag[k++];
                    data[zig] = (short) ((r >> 8) * dequant[zig]);
                }
                else
                {
                    int rs = stbi__jpeg_huff_decode(j, hac);
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
                        zig = stbi__jpeg_dezigzag[k++];
                        data[zig] = (short) (stbi__extend_receive(j, s) * dequant[zig]);
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
        public static int stbi__jpeg_decode_block_prog_dc(stbi__jpeg j, short* data, stbi__huffman* hdc, int b)
        {
            int diff = 0;
            int dc = 0;
            int t = 0;
            if (j.spec_end != 0)
            {
                return stbi__err("can't merge dc and ac");
            }

            if (j.code_bits < 16)
            {
                stbi__grow_buffer_unsafe(j);
            }

            if (j.succ_high == 0)
            {
                CRuntime.memset(data, 0, (ulong) (64 * sizeof(short)));
                t = stbi__jpeg_huff_decode(j, hdc);
                if (t < 0 || t > 15)
                {
                    return stbi__err("can't merge dc and ac");
                }

                diff = t != 0 ? stbi__extend_receive(j, t) : 0;
                if (stbi__addints_valid(j.img_comp[b].dc_pred, diff) == 0)
                {
                    return stbi__err("bad delta");
                }

                dc = j.img_comp[b].dc_pred + diff;
                j.img_comp[b].dc_pred = dc;
                if (stbi__mul2shorts_valid(dc, 1 << j.succ_low) == 0)
                {
                    return stbi__err("can't merge dc and ac");
                }

                data[0] = (short) (dc * (1 << j.succ_low));
            }
            else
            {
                if (stbi__jpeg_get_bit(j) != 0)
                {
                    data[0] += (short) (1 << j.succ_low);
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
        public static int stbi__jpeg_decode_block_prog_ac(stbi__jpeg j, short* data, stbi__huffman* hac, short[] fac)
        {
            int k = 0;
            if (j.spec_start == 0)
            {
                return stbi__err("can't merge dc and ac");
            }

            if (j.succ_high == 0)
            {
                int shift = j.succ_low;
                if (j.eob_run != 0)
                {
                    --j.eob_run;
                    return 1;
                }

                k = j.spec_start;
                do
                {
                    uint zig = 0;
                    int c = 0;
                    int r = 0;
                    int s = 0;
                    if (j.code_bits < 16)
                    {
                        stbi__grow_buffer_unsafe(j);
                    }

                    c = (int) ((j.code_buffer >> (32 - 9)) & ((1 << 9) - 1));
                    r = fac[c];
                    if (r != 0)
                    {
                        k += (r >> 4) & 15;
                        s = r & 15;
                        if (s > j.code_bits)
                        {
                            return stbi__err("bad huffman code");
                        }

                        j.code_buffer <<= s;
                        j.code_bits -= s;
                        zig = stbi__jpeg_dezigzag[k++];
                        data[zig] = (short) ((r >> 8) * (1 << shift));
                    }
                    else
                    {
                        int rs = stbi__jpeg_huff_decode(j, hac);
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
                                j.eob_run = 1 << r;
                                if (r != 0)
                                {
                                    j.eob_run += stbi__jpeg_get_bits(j, r);
                                }

                                --j.eob_run;
                                break;
                            }

                            k += 16;
                        }
                        else
                        {
                            k += r;
                            zig = stbi__jpeg_dezigzag[k++];
                            data[zig] = (short) (stbi__extend_receive(j, s) * (1 << shift));
                        }
                    }
                } while (k <= j.spec_end);
            }
            else
            {
                short bit = (short) (1 << j.succ_low);
                if (j.eob_run != 0)
                {
                    --j.eob_run;
                    for (k = j.spec_start; k <= j.spec_end; ++k)
                    {
                        short* p = &data[stbi__jpeg_dezigzag[k]];
                        if (*p != 0)
                        {
                            if (stbi__jpeg_get_bit(j) != 0)
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
                    k = j.spec_start;
                    do
                    {
                        int r = 0;
                        int s = 0;
                        int rs = stbi__jpeg_huff_decode(j, hac);
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
                                j.eob_run = (1 << r) - 1;
                                if (r != 0)
                                {
                                    j.eob_run += stbi__jpeg_get_bits(j, r);
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

                            if (stbi__jpeg_get_bit(j) != 0)
                            {
                                s = bit;
                            }
                            else
                            {
                                s = -bit;
                            }
                        }

                        while (k <= j.spec_end)
                        {
                            short* p = &data[stbi__jpeg_dezigzag[k++]];
                            if (*p != 0)
                            {
                                if (stbi__jpeg_get_bit(j) != 0)
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
                    } while (k <= j.spec_end);
                }
            }

            return 1;
        }

        /// <summary>
        ///     Stbis the idct block using the specified  out
        /// </summary>
        /// <param name="_out_">The out</param>
        /// <param name="out_stride">The out stride</param>
        /// <param name="data">The data</param>
        public static void stbi__idct_block(byte* _out_, int out_stride, short* data)
        {
            int i = 0;
            int* val = stackalloc int[64];
            int* v = val;
            byte* o;
            short* d = data;
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

            for (i = 0, v = val, o = _out_; i < 8; ++i, v += 8, o += out_stride)
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
                o[0] = stbi__clamp((x0 + t3) >> 17);
                o[7] = stbi__clamp((x0 - t3) >> 17);
                o[1] = stbi__clamp((x1 + t2) >> 17);
                o[6] = stbi__clamp((x1 - t2) >> 17);
                o[2] = stbi__clamp((x2 + t1) >> 17);
                o[5] = stbi__clamp((x2 - t1) >> 17);
                o[3] = stbi__clamp((x3 + t0) >> 17);
                o[4] = stbi__clamp((x3 - t0) >> 17);
            }
        }

        /// <summary>
        ///     Stbis the get marker using the specified j
        /// </summary>
        /// <param name="j">The </param>
        /// <returns>The </returns>
        public static byte stbi__get_marker(stbi__jpeg j)
        {
            byte x = 0;
            if (j.marker != 0xff)
            {
                x = j.marker;
                j.marker = 0xff;
                return x;
            }

            x = stbi__get8(j.s);
            if (x != 0xff)
            {
                return 0xff;
            }

            while (x == 0xff)
            {
                x = stbi__get8(j.s);
            }

            return x;
        }

        /// <summary>
        ///     Stbis the jpeg reset using the specified j
        /// </summary>
        /// <param name="j">The </param>
        public static void stbi__jpeg_reset(stbi__jpeg j)
        {
            j.code_bits = 0;
            j.code_buffer = 0;
            j.nomore = 0;
            j.img_comp[0].dc_pred = j.img_comp[1].dc_pred = j.img_comp[2].dc_pred = j.img_comp[3].dc_pred = 0;
            j.marker = 0xff;
            j.todo = j.restart_interval != 0 ? j.restart_interval : 0x7fffffff;
            j.eob_run = 0;
        }

        /// <summary>
        ///     Stbis the parse entropy coded data using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <returns>The int</returns>
        public static int stbi__parse_entropy_coded_data(stbi__jpeg z)
        {
            stbi__jpeg_reset(z);
            if (z.progressive == 0)
            {
                if (z.scan_n == 1)
                {
                    int i = 0;
                    int j = 0;
                    short* data = stackalloc short[64];
                    int n = z.order[0];
                    int w = (z.img_comp[n].x + 7) >> 3;
                    int h = (z.img_comp[n].y + 7) >> 3;
                    for (j = 0; j < h; ++j)
                    for (i = 0; i < w; ++i)
                    {
                        int ha = z.img_comp[n].ha;
                        fixed (stbi__huffman* dptr = &z.huff_dc[z.img_comp[n].hd])
                        fixed (stbi__huffman* aptr = &z.huff_ac[ha])
                        {
                            if (stbi__jpeg_decode_block(z, data, dptr, aptr,
                                    z.fast_ac[ha], n, z.dequant[z.img_comp[n].tq]) == 0)
                            {
                                return 0;
                            }
                        }

                        z.idct_block_kernel(z.img_comp[n].data + z.img_comp[n].w2 * j * 8 + i * 8, z.img_comp[n].w2,
                            data);
                        if (--z.todo <= 0)
                        {
                            if (z.code_bits < 24)
                            {
                                stbi__grow_buffer_unsafe(z);
                            }

                            if (!((z.marker >= 0xd0) && (z.marker <= 0xd7)))
                            {
                                return 1;
                            }

                            stbi__jpeg_reset(z);
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
                    for (j = 0; j < z.img_mcu_y; ++j)
                    for (i = 0; i < z.img_mcu_x; ++i)
                    {
                        for (k = 0; k < z.scan_n; ++k)
                        {
                            int n = z.order[k];
                            for (y = 0; y < z.img_comp[n].v; ++y)
                            for (x = 0; x < z.img_comp[n].h; ++x)
                            {
                                int x2 = (i * z.img_comp[n].h + x) * 8;
                                int y2 = (j * z.img_comp[n].v + y) * 8;
                                int ha = z.img_comp[n].ha;

                                fixed (stbi__huffman* dptr = &z.huff_dc[z.img_comp[n].hd])
                                fixed (stbi__huffman* aptr = &z.huff_ac[ha])
                                {
                                    if (stbi__jpeg_decode_block(z, data, dptr, aptr,
                                            z.fast_ac[ha], n, z.dequant[z.img_comp[n].tq]) == 0)
                                    {
                                        return 0;
                                    }
                                }

                                z.idct_block_kernel(z.img_comp[n].data + z.img_comp[n].w2 * y2 + x2, z.img_comp[n].w2,
                                    data);
                            }
                        }

                        if (--z.todo <= 0)
                        {
                            if (z.code_bits < 24)
                            {
                                stbi__grow_buffer_unsafe(z);
                            }

                            if (!((z.marker >= 0xd0) && (z.marker <= 0xd7)))
                            {
                                return 1;
                            }

                            stbi__jpeg_reset(z);
                        }
                    }

                    return 1;
                }
            }

            if (z.scan_n == 1)
            {
                int i = 0;
                int j = 0;
                int n = z.order[0];
                int w = (z.img_comp[n].x + 7) >> 3;
                int h = (z.img_comp[n].y + 7) >> 3;
                for (j = 0; j < h; ++j)
                for (i = 0; i < w; ++i)
                {
                    short* data = z.img_comp[n].coeff + 64 * (i + j * z.img_comp[n].coeff_w);
                    if (z.spec_start == 0)
                    {
                        fixed (stbi__huffman* dptr = &z.huff_dc[z.img_comp[n].hd])
                        {
                            if (stbi__jpeg_decode_block_prog_dc(z, data, dptr, n) == 0)
                            {
                                return 0;
                            }
                        }
                    }
                    else
                    {
                        int ha = z.img_comp[n].ha;
                        fixed (stbi__huffman* aptr = &z.huff_ac[ha])
                        {
                            if (stbi__jpeg_decode_block_prog_ac(z, data, aptr, z.fast_ac[ha]) == 0)
                            {
                                return 0;
                            }
                        }
                    }

                    if (--z.todo <= 0)
                    {
                        if (z.code_bits < 24)
                        {
                            stbi__grow_buffer_unsafe(z);
                        }

                        if (!((z.marker >= 0xd0) && (z.marker <= 0xd7)))
                        {
                            return 1;
                        }

                        stbi__jpeg_reset(z);
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
                for (j = 0; j < z.img_mcu_y; ++j)
                for (i = 0; i < z.img_mcu_x; ++i)
                {
                    for (k = 0; k < z.scan_n; ++k)
                    {
                        int n = z.order[k];
                        for (y = 0; y < z.img_comp[n].v; ++y)
                        for (x = 0; x < z.img_comp[n].h; ++x)
                        {
                            int x2 = i * z.img_comp[n].h + x;
                            int y2 = j * z.img_comp[n].v + y;
                            short* data = z.img_comp[n].coeff + 64 * (x2 + y2 * z.img_comp[n].coeff_w);


                            fixed (stbi__huffman* dptr = &z.huff_dc[z.img_comp[n].hd])
                            {
                                if (stbi__jpeg_decode_block_prog_dc(z, data, dptr, n) == 0)
                                {
                                    return 0;
                                }
                            }
                        }
                    }

                    if (--z.todo <= 0)
                    {
                        if (z.code_bits < 24)
                        {
                            stbi__grow_buffer_unsafe(z);
                        }

                        if (!((z.marker >= 0xd0) && (z.marker <= 0xd7)))
                        {
                            return 1;
                        }

                        stbi__jpeg_reset(z);
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
        public static void stbi__jpeg_dequantize(short* data, ushort[] dequant)
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
        public static void stbi__jpeg_finish(stbi__jpeg z)
        {
            if (z.progressive != 0)
            {
                int i = 0;
                int j = 0;
                int n = 0;
                for (n = 0; n < z.s.img_n; ++n)
                {
                    int w = (z.img_comp[n].x + 7) >> 3;
                    int h = (z.img_comp[n].y + 7) >> 3;
                    for (j = 0; j < h; ++j)
                    for (i = 0; i < w; ++i)
                    {
                        short* data = z.img_comp[n].coeff + 64 * (i + j * z.img_comp[n].coeff_w);
                        stbi__jpeg_dequantize(data, z.dequant[z.img_comp[n].tq]);
                        z.idct_block_kernel(z.img_comp[n].data + z.img_comp[n].w2 * j * 8 + i * 8, z.img_comp[n].w2,
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
        public static int stbi__process_marker(stbi__jpeg z, int m)
        {
            int L = 0;
            switch (m)
            {
                case 0xff:
                    return stbi__err("expected marker");
                case 0xDD:
                    if (stbi__get16be(z.s) != 4)
                    {
                        return stbi__err("bad DRI len");
                    }

                    z.restart_interval = stbi__get16be(z.s);
                    return 1;
                case 0xDB:
                    L = stbi__get16be(z.s) - 2;
                    while (L > 0)
                    {
                        int q = stbi__get8(z.s);
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
                            z.dequant[t][stbi__jpeg_dezigzag[i]] =
                                (ushort) (sixteen != 0 ? stbi__get16be(z.s) : stbi__get8(z.s));
                        }

                        L -= sixteen != 0 ? 129 : 65;
                    }

                    return L == 0 ? 1 : 0;
                case 0xC4:
                    L = stbi__get16be(z.s) - 2;
                    int* sizes = stackalloc int[16];
                    while (L > 0)
                    {
                        int i = 0;
                        int n = 0;
                        int q = stbi__get8(z.s);
                        int tc = q >> 4;
                        int th = q & 15;
                        if (tc > 1 || th > 3)
                        {
                            return stbi__err("bad DHT header");
                        }

                        for (i = 0; i < 16; ++i)
                        {
                            sizes[i] = stbi__get8(z.s);
                            n += sizes[i];
                        }

                        if (n > 256)
                        {
                            return stbi__err("bad DHT header");
                        }

                        L -= 17;
                        if (tc == 0)
                        {
                            fixed (stbi__huffman* hptr = &z.huff_dc[th])
                            {
                                if (stbi__build_huffman(hptr, sizes) == 0)
                                {
                                    return 0;
                                }

                                byte* v = hptr->values;
                                for (i = 0; i < n; ++i)
                                {
                                    v[i] = stbi__get8(z.s);
                                }
                            }
                        }
                        else
                        {
                            fixed (stbi__huffman* aptr = &z.huff_ac[th])
                            {
                                if (stbi__build_huffman(aptr, sizes) == 0)
                                {
                                    return 0;
                                }

                                byte* v = aptr->values;
                                for (i = 0; i < n; ++i)
                                {
                                    v[i] = stbi__get8(z.s);
                                }
                            }
                        }

                        if (tc != 0)
                        {
                            fixed (stbi__huffman* aptr = &z.huff_ac[th])
                            {
                                stbi__build_fast_ac(z.fast_ac[th], aptr);
                            }
                        }

                        L -= n;
                    }

                    return L == 0 ? 1 : 0;
            }

            if (((m >= 0xE0) && (m <= 0xEF)) || m == 0xFE)
            {
                L = stbi__get16be(z.s);
                if (L < 2)
                {
                    if (m == 0xFE)
                    {
                        return stbi__err("bad COM len");
                    }

                    return stbi__err("bad APP len");
                }

                L -= 2;
                if ((m == 0xE0) && (L >= 5))
                {
                    int ok = 1;
                    int i = 0;
                    for (i = 0; i < 5; ++i)
                    {
                        if (stbi__get8(z.s) != stbi__process_marker_tag[i])
                        {
                            ok = 0;
                        }
                    }

                    L -= 5;
                    if (ok != 0)
                    {
                        z.jfif = 1;
                    }
                }
                else if ((m == 0xEE) && (L >= 12))
                {
                    int ok = 1;
                    int i = 0;
                    for (i = 0; i < 6; ++i)
                    {
                        if (stbi__get8(z.s) != stbi__process_marker_tag[i])
                        {
                            ok = 0;
                        }
                    }

                    L -= 6;
                    if (ok != 0)
                    {
                        stbi__get8(z.s);
                        stbi__get16be(z.s);
                        stbi__get16be(z.s);
                        z.app14_color_transform = stbi__get8(z.s);
                        L -= 6;
                    }
                }

                stbi__skip(z.s, L);
                return 1;
            }

            return stbi__err("unknown marker");
        }

        /// <summary>
        ///     Stbis the process scan header using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <returns>The int</returns>
        public static int stbi__process_scan_header(stbi__jpeg z)
        {
            int i = 0;
            int Ls = stbi__get16be(z.s);
            z.scan_n = stbi__get8(z.s);
            if (z.scan_n < 1 || z.scan_n > 4 || z.scan_n > z.s.img_n)
            {
                return stbi__err("bad SOS component count");
            }

            if (Ls != 6 + 2 * z.scan_n)
            {
                return stbi__err("bad SOS len");
            }

            for (i = 0; i < z.scan_n; ++i)
            {
                int id = stbi__get8(z.s);
                int which = 0;
                int q = stbi__get8(z.s);
                for (which = 0; which < z.s.img_n; ++which)
                {
                    if (z.img_comp[which].id == id)
                    {
                        break;
                    }
                }

                if (which == z.s.img_n)
                {
                    return 0;
                }

                z.img_comp[which].hd = q >> 4;
                if (z.img_comp[which].hd > 3)
                {
                    return stbi__err("bad DC huff");
                }

                z.img_comp[which].ha = q & 15;
                if (z.img_comp[which].ha > 3)
                {
                    return stbi__err("bad AC huff");
                }

                z.order[i] = which;
            }

            {
                int aa = 0;
                z.spec_start = stbi__get8(z.s);
                z.spec_end = stbi__get8(z.s);
                aa = stbi__get8(z.s);
                z.succ_high = aa >> 4;
                z.succ_low = aa & 15;
                if (z.progressive != 0)
                {
                    if (z.spec_start > 63 || z.spec_end > 63 || z.spec_start > z.spec_end || z.succ_high > 13 ||
                        z.succ_low > 13)
                    {
                        return stbi__err("bad SOS");
                    }
                }
                else
                {
                    if (z.spec_start != 0)
                    {
                        return stbi__err("bad SOS");
                    }

                    if (z.succ_high != 0 || z.succ_low != 0)
                    {
                        return stbi__err("bad SOS");
                    }

                    z.spec_end = 63;
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
        public static int stbi__free_jpeg_components(stbi__jpeg z, int ncomp, int why)
        {
            int i = 0;
            for (i = 0; i < ncomp; ++i)
            {
                if (z.img_comp[i].raw_data != null)
                {
                    CRuntime.free(z.img_comp[i].raw_data);
                    z.img_comp[i].raw_data = null;
                    z.img_comp[i].data = null;
                }

                if (z.img_comp[i].raw_coeff != null)
                {
                    CRuntime.free(z.img_comp[i].raw_coeff);
                    z.img_comp[i].raw_coeff = null;
                    z.img_comp[i].coeff = null;
                }

                if (z.img_comp[i].linebuf != null)
                {
                    CRuntime.free(z.img_comp[i].linebuf);
                    z.img_comp[i].linebuf = null;
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
        public static int stbi__process_frame_header(stbi__jpeg z, int scan)
        {
            stbi__context s = z.s;
            int Lf = 0;
            int p = 0;
            int i = 0;
            int q = 0;
            int h_max = 1;
            int v_max = 1;
            int c = 0;
            Lf = stbi__get16be(s);
            if (Lf < 11)
            {
                return stbi__err("bad SOF len");
            }

            p = stbi__get8(s);
            if (p != 8)
            {
                return stbi__err("only 8-bit");
            }

            s.img_y = (uint) stbi__get16be(s);
            if (s.img_y == 0)
            {
                return stbi__err("no header height");
            }

            s.img_x = (uint) stbi__get16be(s);
            if (s.img_x == 0)
            {
                return stbi__err("0 width");
            }

            if (s.img_y > 1 << 24)
            {
                return stbi__err("too large");
            }

            if (s.img_x > 1 << 24)
            {
                return stbi__err("too large");
            }

            c = stbi__get8(s);
            if ((c != 3) && (c != 1) && (c != 4))
            {
                return stbi__err("bad component count");
            }

            s.img_n = c;
            for (i = 0; i < c; ++i)
            {
                z.img_comp[i].data = null;
                z.img_comp[i].linebuf = null;
            }

            if (Lf != 8 + 3 * s.img_n)
            {
                return stbi__err("bad SOF len");
            }

            z.rgb = 0;
            for (i = 0; i < s.img_n; ++i)
            {
                z.img_comp[i].id = stbi__get8(s);
                if ((s.img_n == 3) && (z.img_comp[i].id == stbi__process_frame_header_rgb[i]))
                {
                    ++z.rgb;
                }

                q = stbi__get8(s);
                z.img_comp[i].h = q >> 4;
                if (z.img_comp[i].h == 0 || z.img_comp[i].h > 4)
                {
                    return stbi__err("bad H");
                }

                z.img_comp[i].v = q & 15;
                if (z.img_comp[i].v == 0 || z.img_comp[i].v > 4)
                {
                    return stbi__err("bad V");
                }

                z.img_comp[i].tq = stbi__get8(s);
                if (z.img_comp[i].tq > 3)
                {
                    return stbi__err("bad TQ");
                }
            }

            if (scan != STBI__SCAN_load)
            {
                return 1;
            }

            if (stbi__mad3sizes_valid((int) s.img_x, (int) s.img_y, s.img_n, 0) == 0)
            {
                return stbi__err("too large");
            }

            for (i = 0; i < s.img_n; ++i)
            {
                if (z.img_comp[i].h > h_max)
                {
                    h_max = z.img_comp[i].h;
                }

                if (z.img_comp[i].v > v_max)
                {
                    v_max = z.img_comp[i].v;
                }
            }

            for (i = 0; i < s.img_n; ++i)
            {
                if (h_max % z.img_comp[i].h != 0)
                {
                    return stbi__err("bad H");
                }

                if (v_max % z.img_comp[i].v != 0)
                {
                    return stbi__err("bad V");
                }
            }

            z.img_h_max = h_max;
            z.img_v_max = v_max;
            z.img_mcu_w = h_max * 8;
            z.img_mcu_h = v_max * 8;
            z.img_mcu_x = (int) ((s.img_x + z.img_mcu_w - 1) / z.img_mcu_w);
            z.img_mcu_y = (int) ((s.img_y + z.img_mcu_h - 1) / z.img_mcu_h);
            for (i = 0; i < s.img_n; ++i)
            {
                z.img_comp[i].x = (int) ((s.img_x * z.img_comp[i].h + h_max - 1) / h_max);
                z.img_comp[i].y = (int) ((s.img_y * z.img_comp[i].v + v_max - 1) / v_max);
                z.img_comp[i].w2 = z.img_mcu_x * z.img_comp[i].h * 8;
                z.img_comp[i].h2 = z.img_mcu_y * z.img_comp[i].v * 8;
                z.img_comp[i].coeff = null;
                z.img_comp[i].raw_coeff = null;
                z.img_comp[i].linebuf = null;
                z.img_comp[i].raw_data = stbi__malloc_mad2(z.img_comp[i].w2, z.img_comp[i].h2, 15);
                if (z.img_comp[i].raw_data == null)
                {
                    return stbi__free_jpeg_components(z, i + 1, stbi__err("outofmem"));
                }

                z.img_comp[i].data = (byte*) (((long) z.img_comp[i].raw_data + 15) & ~15);
                if (z.progressive != 0)
                {
                    z.img_comp[i].coeff_w = z.img_comp[i].w2 / 8;
                    z.img_comp[i].coeff_h = z.img_comp[i].h2 / 8;
                    z.img_comp[i].raw_coeff = stbi__malloc_mad3(z.img_comp[i].w2, z.img_comp[i].h2, sizeof(short), 15);
                    if (z.img_comp[i].raw_coeff == null)
                    {
                        return stbi__free_jpeg_components(z, i + 1, stbi__err("outofmem"));
                    }

                    z.img_comp[i].coeff = (short*) (((long) z.img_comp[i].raw_coeff + 15) & ~15);
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
        public static int stbi__decode_jpeg_header(stbi__jpeg z, int scan)
        {
            int m = 0;
            z.jfif = 0;
            z.app14_color_transform = -1;
            z.marker = 0xff;
            m = stbi__get_marker(z);
            if (!(m == 0xd8))
            {
                return stbi__err("no SOI");
            }

            if (scan == STBI__SCAN_type)
            {
                return 1;
            }

            m = stbi__get_marker(z);
            while (!(m == 0xc0 || m == 0xc1 || m == 0xc2))
            {
                if (stbi__process_marker(z, m) == 0)
                {
                    return 0;
                }

                m = stbi__get_marker(z);
                while (m == 0xff)
                {
                    if (stbi__at_eof(z.s) != 0)
                    {
                        return stbi__err("no SOF");
                    }

                    m = stbi__get_marker(z);
                }
            }

            z.progressive = m == 0xc2 ? 1 : 0;
            if (stbi__process_frame_header(z, scan) == 0)
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
        public static byte stbi__skip_jpeg_junk_at_end(stbi__jpeg j)
        {
            while (stbi__at_eof(j.s) == 0)
            {
                byte x = stbi__get8(j.s);
                while (x == 0xff)
                {
                    if (stbi__at_eof(j.s) != 0)
                    {
                        return 0xff;
                    }

                    x = stbi__get8(j.s);
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
        public static int stbi__decode_jpeg_image(stbi__jpeg j)
        {
            int m = 0;
            for (m = 0; m < 4; m++)
            {
                j.img_comp[m].raw_data = null;
                j.img_comp[m].raw_coeff = null;
            }

            j.restart_interval = 0;
            if (stbi__decode_jpeg_header(j, STBI__SCAN_load) == 0)
            {
                return 0;
            }

            m = stbi__get_marker(j);
            while (!(m == 0xd9))
            {
                if (m == 0xda)
                {
                    if (stbi__process_scan_header(j) == 0)
                    {
                        return 0;
                    }

                    if (stbi__parse_entropy_coded_data(j) == 0)
                    {
                        return 0;
                    }

                    if (j.marker == 0xff)
                    {
                        j.marker = stbi__skip_jpeg_junk_at_end(j);
                    }

                    m = stbi__get_marker(j);
                    if ((m >= 0xd0) && (m <= 0xd7))
                    {
                        m = stbi__get_marker(j);
                    }
                }
                else if (m == 0xdc)
                {
                    int Ld = stbi__get16be(j.s);
                    uint NL = (uint) stbi__get16be(j.s);
                    if (Ld != 4)
                    {
                        return stbi__err("bad DNL len");
                    }

                    if (NL != j.s.img_y)
                    {
                        return stbi__err("bad DNL height");
                    }

                    m = stbi__get_marker(j);
                }
                else
                {
                    if (stbi__process_marker(j, m) == 0)
                    {
                        return 1;
                    }

                    m = stbi__get_marker(j);
                }
            }

            if (j.progressive != 0)
            {
                stbi__jpeg_finish(j);
            }

            return 1;
        }

        /// <summary>
        ///     Resamples the row 1 using the specified  out
        /// </summary>
        /// <param name="_out_">The out</param>
        /// <param name="in_near">The in near</param>
        /// <param name="in_far">The in far</param>
        /// <param name="w">The </param>
        /// <param name="hs">The hs</param>
        /// <returns>The in near</returns>
        public static byte* resample_row_1(byte* _out_, byte* in_near, byte* in_far, int w, int hs) => in_near;

        /// <summary>
        ///     Stbis the resample row v 2 using the specified  out
        /// </summary>
        /// <param name="_out_">The out</param>
        /// <param name="in_near">The in near</param>
        /// <param name="in_far">The in far</param>
        /// <param name="w">The </param>
        /// <param name="hs">The hs</param>
        /// <returns>The out</returns>
        public static byte* stbi__resample_row_v_2(byte* _out_, byte* in_near, byte* in_far, int w, int hs)
        {
            int i = 0;
            for (i = 0; i < w; ++i)
            {
                _out_[i] = (byte) ((3 * in_near[i] + in_far[i] + 2) >> 2);
            }

            return _out_;
        }

        /// <summary>
        ///     Stbis the resample row h 2 using the specified  out
        /// </summary>
        /// <param name="_out_">The out</param>
        /// <param name="in_near">The in near</param>
        /// <param name="in_far">The in far</param>
        /// <param name="w">The </param>
        /// <param name="hs">The hs</param>
        /// <returns>The out</returns>
        public static byte* stbi__resample_row_h_2(byte* _out_, byte* in_near, byte* in_far, int w, int hs)
        {
            int i = 0;
            byte* input = in_near;
            if (w == 1)
            {
                _out_[0] = _out_[1] = input[0];
                return _out_;
            }

            _out_[0] = input[0];
            _out_[1] = (byte) ((input[0] * 3 + input[1] + 2) >> 2);
            for (i = 1; i < w - 1; ++i)
            {
                int n = 3 * input[i] + 2;
                _out_[i * 2 + 0] = (byte) ((n + input[i - 1]) >> 2);
                _out_[i * 2 + 1] = (byte) ((n + input[i + 1]) >> 2);
            }

            _out_[i * 2 + 0] = (byte) ((input[w - 2] * 3 + input[w - 1] + 2) >> 2);
            _out_[i * 2 + 1] = input[w - 1];
            return _out_;
        }

        /// <summary>
        ///     Stbis the resample row hv 2 using the specified  out
        /// </summary>
        /// <param name="_out_">The out</param>
        /// <param name="in_near">The in near</param>
        /// <param name="in_far">The in far</param>
        /// <param name="w">The </param>
        /// <param name="hs">The hs</param>
        /// <returns>The out</returns>
        public static byte* stbi__resample_row_hv_2(byte* _out_, byte* in_near, byte* in_far, int w, int hs)
        {
            int i = 0;
            int t0 = 0;
            int t1 = 0;
            if (w == 1)
            {
                _out_[0] = _out_[1] = (byte) ((3 * in_near[0] + in_far[0] + 2) >> 2);
                return _out_;
            }

            t1 = 3 * in_near[0] + in_far[0];
            _out_[0] = (byte) ((t1 + 2) >> 2);
            for (i = 1; i < w; ++i)
            {
                t0 = t1;
                t1 = 3 * in_near[i] + in_far[i];
                _out_[i * 2 - 1] = (byte) ((3 * t0 + t1 + 8) >> 4);
                _out_[i * 2] = (byte) ((3 * t1 + t0 + 8) >> 4);
            }

            _out_[w * 2 - 1] = (byte) ((t1 + 2) >> 2);
            return _out_;
        }

        /// <summary>
        ///     Stbis the resample row generic using the specified  out
        /// </summary>
        /// <param name="_out_">The out</param>
        /// <param name="in_near">The in near</param>
        /// <param name="in_far">The in far</param>
        /// <param name="w">The </param>
        /// <param name="hs">The hs</param>
        /// <returns>The out</returns>
        public static byte* stbi__resample_row_generic(byte* _out_, byte* in_near, byte* in_far, int w, int hs)
        {
            int i = 0;
            int j = 0;
            for (i = 0; i < w; ++i)
            for (j = 0; j < hs; ++j)
            {
                _out_[i * hs + j] = in_near[i];
            }

            return _out_;
        }

        /// <summary>
        ///     Stbis the y cb cr to rgb row using the specified  out
        /// </summary>
        /// <param name="_out_">The out</param>
        /// <param name="y">The </param>
        /// <param name="pcb">The pcb</param>
        /// <param name="pcr">The pcr</param>
        /// <param name="count">The count</param>
        /// <param name="step">The step</param>
        public static void stbi__YCbCr_to_RGB_row(byte* _out_, byte* y, byte* pcb, byte* pcr, int count, int step)
        {
            int i = 0;
            for (i = 0; i < count; ++i)
            {
                int y_fixed = (y[i] << 20) + (1 << 19);
                int r = 0;
                int g = 0;
                int b = 0;
                int cr = pcr[i] - 128;
                int cb = pcb[i] - 128;
                r = y_fixed + cr * ((int) (1.40200f * 4096.0f + 0.5f) << 8);
                g = (int) (y_fixed + cr * -((int) (0.71414f * 4096.0f + 0.5f) << 8) +
                           ((cb * -((int) (0.34414f * 4096.0f + 0.5f) << 8)) & 0xffff0000));
                b = y_fixed + cb * ((int) (1.77200f * 4096.0f + 0.5f) << 8);
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

                _out_[0] = (byte) r;
                _out_[1] = (byte) g;
                _out_[2] = (byte) b;
                _out_[3] = 255;
                _out_ += step;
            }
        }

        /// <summary>
        ///     Stbis the setup jpeg using the specified j
        /// </summary>
        /// <param name="j">The </param>
        public static void stbi__setup_jpeg(stbi__jpeg j)
        {
            j.idct_block_kernel = stbi__idct_block;
            j.YCbCr_to_RGB_kernel = stbi__YCbCr_to_RGB_row;
            j.resample_row_hv_2_kernel = stbi__resample_row_hv_2;
        }

        /// <summary>
        ///     Stbis the cleanup jpeg using the specified j
        /// </summary>
        /// <param name="j">The </param>
        public static void stbi__cleanup_jpeg(stbi__jpeg j)
        {
            stbi__free_jpeg_components(j, j.s.img_n, 0);
        }

        /// <summary>
        ///     Loads the jpeg image using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <param name="out_x">The out</param>
        /// <param name="out_y">The out</param>
        /// <param name="comp">The comp</param>
        /// <param name="req_comp">The req comp</param>
        /// <returns>The byte</returns>
        public static byte* load_jpeg_image(stbi__jpeg z, int* out_x, int* out_y, int* comp, int req_comp)
        {
            int n = 0;
            int decode_n = 0;
            int is_rgb = 0;
            z.s.img_n = 0;
            if (req_comp < 0 || req_comp > 4)
            {
                return (byte*) (ulong) (stbi__err("bad req_comp") != 0 ? 0 : 0);
            }

            if (stbi__decode_jpeg_image(z) == 0)
            {
                stbi__cleanup_jpeg(z);
                return null;
            }

            n = req_comp != 0 ? req_comp : z.s.img_n >= 3 ? 3 : 1;
            is_rgb = (z.s.img_n == 3) && (z.rgb == 3 || ((z.app14_color_transform == 0) && (z.jfif == 0))) ? 1 : 0;
            if ((z.s.img_n == 3) && (n < 3) && (is_rgb == 0))
            {
                decode_n = 1;
            }
            else
            {
                decode_n = z.s.img_n;
            }

            if (decode_n <= 0)
            {
                stbi__cleanup_jpeg(z);
                return null;
            }

            {
                int k = 0;
                uint i = 0;
                uint j = 0;
                byte* output;
                byte** coutput = stackalloc byte*[] {null, null, null, null};
                stbi__resample[] res_comp = new stbi__resample[4];
                res_comp[0] = new stbi__resample();
                res_comp[1] = new stbi__resample();
                res_comp[2] = new stbi__resample();
                res_comp[3] = new stbi__resample();
                for (k = 0; k < decode_n; ++k)
                {
                    stbi__resample r = res_comp[k];
                    z.img_comp[k].linebuf = (byte*) stbi__malloc(z.s.img_x + 3);
                    if (z.img_comp[k].linebuf == null)
                    {
                        stbi__cleanup_jpeg(z);
                        return (byte*) (ulong) (stbi__err("outofmem") != 0 ? 0 : 0);
                    }

                    r.hs = z.img_h_max / z.img_comp[k].h;
                    r.vs = z.img_v_max / z.img_comp[k].v;
                    r.ystep = r.vs >> 1;
                    r.w_lores = (int) ((z.s.img_x + r.hs - 1) / r.hs);
                    r.ypos = 0;
                    r.line0 = r.line1 = z.img_comp[k].data;
                    if ((r.hs == 1) && (r.vs == 1))
                    {
                        r.resample = resample_row_1;
                    }
                    else if ((r.hs == 1) && (r.vs == 2))
                    {
                        r.resample = stbi__resample_row_v_2;
                    }
                    else if ((r.hs == 2) && (r.vs == 1))
                    {
                        r.resample = stbi__resample_row_h_2;
                    }
                    else if ((r.hs == 2) && (r.vs == 2))
                    {
                        r.resample = z.resample_row_hv_2_kernel;
                    }
                    else
                    {
                        r.resample = stbi__resample_row_generic;
                    }
                }

                output = (byte*) stbi__malloc_mad3(n, (int) z.s.img_x, (int) z.s.img_y, 1);
                if (output == null)
                {
                    stbi__cleanup_jpeg(z);
                    return (byte*) (ulong) (stbi__err("outofmem") != 0 ? 0 : 0);
                }

                for (j = 0; j < z.s.img_y; ++j)
                {
                    byte* _out_ = output + n * z.s.img_x * j;
                    for (k = 0; k < decode_n; ++k)
                    {
                        stbi__resample r = res_comp[k];
                        int y_bot = r.ystep >= r.vs >> 1 ? 1 : 0;
                        coutput[k] = r.resample(z.img_comp[k].linebuf, y_bot != 0 ? r.line1 : r.line0,
                            y_bot != 0 ? r.line0 : r.line1, r.w_lores, r.hs);
                        if (++r.ystep >= r.vs)
                        {
                            r.ystep = 0;
                            r.line0 = r.line1;
                            if (++r.ypos < z.img_comp[k].y)
                            {
                                r.line1 += z.img_comp[k].w2;
                            }
                        }
                    }

                    if (n >= 3)
                    {
                        byte* y = coutput[0];
                        if (z.s.img_n == 3)
                        {
                            if (is_rgb != 0)
                            {
                                for (i = 0; i < z.s.img_x; ++i)
                                {
                                    _out_[0] = y[i];
                                    _out_[1] = coutput[1][i];
                                    _out_[2] = coutput[2][i];
                                    _out_[3] = 255;
                                    _out_ += n;
                                }
                            }
                            else
                            {
                                z.YCbCr_to_RGB_kernel(_out_, y, coutput[1], coutput[2], (int) z.s.img_x, n);
                            }
                        }
                        else if (z.s.img_n == 4)
                        {
                            if (z.app14_color_transform == 0)
                            {
                                for (i = 0; i < z.s.img_x; ++i)
                                {
                                    byte m = coutput[3][i];
                                    _out_[0] = stbi__blinn_8x8(coutput[0][i], m);
                                    _out_[1] = stbi__blinn_8x8(coutput[1][i], m);
                                    _out_[2] = stbi__blinn_8x8(coutput[2][i], m);
                                    _out_[3] = 255;
                                    _out_ += n;
                                }
                            }
                            else if (z.app14_color_transform == 2)
                            {
                                z.YCbCr_to_RGB_kernel(_out_, y, coutput[1], coutput[2], (int) z.s.img_x, n);
                                for (i = 0; i < z.s.img_x; ++i)
                                {
                                    byte m = coutput[3][i];
                                    _out_[0] = stbi__blinn_8x8((byte) (255 - _out_[0]), m);
                                    _out_[1] = stbi__blinn_8x8((byte) (255 - _out_[1]), m);
                                    _out_[2] = stbi__blinn_8x8((byte) (255 - _out_[2]), m);
                                    _out_ += n;
                                }
                            }
                            else
                            {
                                z.YCbCr_to_RGB_kernel(_out_, y, coutput[1], coutput[2], (int) z.s.img_x, n);
                            }
                        }
                        else
                        {
                            for (i = 0; i < z.s.img_x; ++i)
                            {
                                _out_[0] = _out_[1] = _out_[2] = y[i];
                                _out_[3] = 255;
                                _out_ += n;
                            }
                        }
                    }
                    else
                    {
                        if (is_rgb != 0)
                        {
                            if (n == 1)
                            {
                                for (i = 0; i < z.s.img_x; ++i)
                                {
                                    *_out_++ = stbi__compute_y(coutput[0][i], coutput[1][i], coutput[2][i]);
                                }
                            }
                            else
                            {
                                for (i = 0; i < z.s.img_x; ++i, _out_ += 2)
                                {
                                    _out_[0] = stbi__compute_y(coutput[0][i], coutput[1][i], coutput[2][i]);
                                    _out_[1] = 255;
                                }
                            }
                        }
                        else if ((z.s.img_n == 4) && (z.app14_color_transform == 0))
                        {
                            for (i = 0; i < z.s.img_x; ++i)
                            {
                                byte m = coutput[3][i];
                                byte r = stbi__blinn_8x8(coutput[0][i], m);
                                byte g = stbi__blinn_8x8(coutput[1][i], m);
                                byte b = stbi__blinn_8x8(coutput[2][i], m);
                                _out_[0] = stbi__compute_y(r, g, b);
                                _out_[1] = 255;
                                _out_ += n;
                            }
                        }
                        else if ((z.s.img_n == 4) && (z.app14_color_transform == 2))
                        {
                            for (i = 0; i < z.s.img_x; ++i)
                            {
                                _out_[0] = stbi__blinn_8x8((byte) (255 - coutput[0][i]), coutput[3][i]);
                                _out_[1] = 255;
                                _out_ += n;
                            }
                        }
                        else
                        {
                            byte* y = coutput[0];
                            if (n == 1)
                            {
                                for (i = 0; i < z.s.img_x; ++i)
                                {
                                    _out_[i] = y[i];
                                }
                            }
                            else
                            {
                                for (i = 0; i < z.s.img_x; ++i)
                                {
                                    *_out_++ = y[i];
                                    *_out_++ = 255;
                                }
                            }
                        }
                    }
                }

                stbi__cleanup_jpeg(z);
                *out_x = (int) z.s.img_x;
                *out_y = (int) z.s.img_y;
                if (comp != null)
                {
                    *comp = z.s.img_n >= 3 ? 3 : 1;
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
        public static int stbi__jpeg_info_raw(stbi__jpeg j, int* x, int* y, int* comp)
        {
            if (stbi__decode_jpeg_header(j, STBI__SCAN_header) == 0)
            {
                stbi__rewind(j.s);
                return 0;
            }

            if (x != null)
            {
                *x = (int) j.s.img_x;
            }

            if (y != null)
            {
                *y = (int) j.s.img_y;
            }

            if (comp != null)
            {
                *comp = j.s.img_n >= 3 ? 3 : 1;
            }

            return 1;
        }

        /// <summary>
        ///     The stbi huffman
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct stbi__huffman
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
        public class stbi__jpeg
        {
            /// <summary>
            ///     The app14 color transform
            /// </summary>
            public int app14_color_transform;

            /// <summary>
            ///     The code bits
            /// </summary>
            public int code_bits;

            /// <summary>
            ///     The code buffer
            /// </summary>
            public uint code_buffer;

            /// <summary>
            ///     The create array
            /// </summary>
            public ushort[][] dequant = Utility.CreateArray<ushort>(4, 64);

            /// <summary>
            ///     The eob run
            /// </summary>
            public int eob_run;

            /// <summary>
            ///     The create array
            /// </summary>
            public short[][] fast_ac = Utility.CreateArray<short>(4, 512);

            /// <summary>
            ///     The stbi huffman
            /// </summary>
            public stbi__huffman[] huff_ac = new stbi__huffman[4];

            /// <summary>
            ///     The stbi huffman
            /// </summary>
            public stbi__huffman[] huff_dc = new stbi__huffman[4];

            /// <summary>
            ///     The idct block kernel
            /// </summary>
            public delegate0 idct_block_kernel;

            /// <summary>
            ///     The unnamed
            /// </summary>
            public unnamed1[] img_comp = new unnamed1[4];

            /// <summary>
            ///     The img max
            /// </summary>
            public int img_h_max;

            /// <summary>
            ///     The img mcu
            /// </summary>
            public int img_mcu_h;

            /// <summary>
            ///     The img mcu
            /// </summary>
            public int img_mcu_w;

            /// <summary>
            ///     The img mcu
            /// </summary>
            public int img_mcu_x;

            /// <summary>
            ///     The img mcu
            /// </summary>
            public int img_mcu_y;

            /// <summary>
            ///     The img max
            /// </summary>
            public int img_v_max;

            /// <summary>
            ///     The jfif
            /// </summary>
            public int jfif;

            /// <summary>
            ///     The marker
            /// </summary>
            public byte marker;

            /// <summary>
            ///     The nomore
            /// </summary>
            public int nomore;

            /// <summary>
            ///     The order
            /// </summary>
            public int[] order = new int[4];

            /// <summary>
            ///     The progressive
            /// </summary>
            public int progressive;

            /// <summary>
            ///     The resample row hv kernel
            /// </summary>
            public delegate2 resample_row_hv_2_kernel;

            /// <summary>
            ///     The restart interval
            /// </summary>
            public int restart_interval;

            /// <summary>
            ///     The rgb
            /// </summary>
            public int rgb;

            /// <summary>
            ///     The
            /// </summary>
            public stbi__context s;

            /// <summary>
            ///     The scan
            /// </summary>
            public int scan_n;

            /// <summary>
            ///     The spec end
            /// </summary>
            public int spec_end;

            /// <summary>
            ///     The spec start
            /// </summary>
            public int spec_start;

            /// <summary>
            ///     The succ high
            /// </summary>
            public int succ_high;

            /// <summary>
            ///     The succ low
            /// </summary>
            public int succ_low;

            /// <summary>
            ///     The todo
            /// </summary>
            public int todo;

            /// <summary>
            ///     The ycbcr to rgb kernel
            /// </summary>
            public delegate1 YCbCr_to_RGB_kernel;

            /// <summary>
            ///     The unnamed
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct unnamed1
            {
                /// <summary>
                ///     The id
                /// </summary>
                public int id;

                /// <summary>
                ///     The
                /// </summary>
                public int h;

                /// <summary>
                ///     The
                /// </summary>
                public int v;

                /// <summary>
                ///     The tq
                /// </summary>
                public int tq;

                /// <summary>
                ///     The hd
                /// </summary>
                public int hd;

                /// <summary>
                ///     The ha
                /// </summary>
                public int ha;

                /// <summary>
                ///     The dc pred
                /// </summary>
                public int dc_pred;

                /// <summary>
                ///     The
                /// </summary>
                public int x;

                /// <summary>
                ///     The
                /// </summary>
                public int y;

                /// <summary>
                ///     The
                /// </summary>
                public int w2;

                /// <summary>
                ///     The
                /// </summary>
                public int h2;

                /// <summary>
                ///     The data
                /// </summary>
                public byte* data;

                /// <summary>
                ///     The raw data
                /// </summary>
                public void* raw_data;

                /// <summary>
                ///     The raw coeff
                /// </summary>
                public void* raw_coeff;

                /// <summary>
                ///     The linebuf
                /// </summary>
                public byte* linebuf;

                /// <summary>
                ///     The coeff
                /// </summary>
                public short* coeff;

                /// <summary>
                ///     The coeff
                /// </summary>
                public int coeff_w;

                /// <summary>
                ///     The coeff
                /// </summary>
                public int coeff_h;
            }
        }

        /// <summary>
        ///     The stbi resample class
        /// </summary>
        public class stbi__resample
        {
            /// <summary>
            ///     The hs
            /// </summary>
            public int hs;

            /// <summary>
            ///     The line
            /// </summary>
            public byte* line0;

            /// <summary>
            ///     The line
            /// </summary>
            public byte* line1;

            /// <summary>
            ///     The resample
            /// </summary>
            public delegate2 resample;

            /// <summary>
            ///     The vs
            /// </summary>
            public int vs;

            /// <summary>
            ///     The lores
            /// </summary>
            public int w_lores;

            /// <summary>
            ///     The ypos
            /// </summary>
            public int ypos;

            /// <summary>
            ///     The ystep
            /// </summary>
            public int ystep;
        }
    }
}