// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbImage.Generated.Bmp.cs
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
        ///     Stbis the bmp test using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The </returns>
        public static int stbi__bmp_test(stbi__context s)
        {
            int r = stbi__bmp_test_raw(s);
            stbi__rewind(s);
            return r;
        }

        /// <summary>
        ///     Stbis the bmp load using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <param name="req_comp">The req comp</param>
        /// <param name="ri">The ri</param>
        /// <returns>The out</returns>
        public static void* stbi__bmp_load(stbi__context s, int* x, int* y, int* comp, int req_comp,
            stbi__result_info* ri)
        {
            byte* _out_;
            uint mr = 0;
            uint mg = 0;
            uint mb = 0;
            uint ma = 0;
            uint all_a = 0;
            byte[][] pal = Utility.CreateArray<byte>(256, 4);
            int psize = 0;
            int i = 0;
            int j = 0;
            int width = 0;
            int flip_vertically = 0;
            int pad = 0;
            int target = 0;
            stbi__bmp_data info = new stbi__bmp_data();
            info.all_a = 255;
            if (stbi__bmp_parse_header(s, &info) == null)
            {
                return null;
            }

            flip_vertically = (int) s.img_y > 0 ? 1 : 0;
            s.img_y = (uint) CRuntime.abs((int) s.img_y);
            if (s.img_y > 1 << 24)
            {
                return (byte*) (ulong) (stbi__err("too large") != 0 ? 0 : 0);
            }

            if (s.img_x > 1 << 24)
            {
                return (byte*) (ulong) (stbi__err("too large") != 0 ? 0 : 0);
            }

            mr = info.mr;
            mg = info.mg;
            mb = info.mb;
            ma = info.ma;
            all_a = info.all_a;
            if (info.hsz == 12)
            {
                if (info.bpp < 24)
                {
                    psize = (info.offset - info.extra_read - 24) / 3;
                }
            }
            else
            {
                if (info.bpp < 16)
                {
                    psize = (info.offset - info.extra_read - info.hsz) >> 2;
                }
            }

            if (psize == 0)
            {
                int bytes_read_so_far = (int) s.Stream.Position;
                int header_limit = 1024;
                int extra_data_limit = 256 * 4;
                if (bytes_read_so_far <= 0 || bytes_read_so_far > header_limit)
                {
                    return (byte*) (ulong) (stbi__err("bad header") != 0 ? 0 : 0);
                }

                if (info.offset < bytes_read_so_far || info.offset - bytes_read_so_far > extra_data_limit)
                {
                    return (byte*) (ulong) (stbi__err("bad offset") != 0 ? 0 : 0);
                }

                stbi__skip(s, info.offset - bytes_read_so_far);
            }

            if (info.bpp == 24 && ma == 0xff000000)
            {
                s.img_n = 3;
            }
            else
            {
                s.img_n = ma != 0 ? 4 : 3;
            }

            if (req_comp != 0 && req_comp >= 3)
            {
                target = req_comp;
            }
            else
            {
                target = s.img_n;
            }

            if (stbi__mad3sizes_valid(target, (int) s.img_x, (int) s.img_y, 0) == 0)
            {
                return (byte*) (ulong) (stbi__err("too large") != 0 ? 0 : 0);
            }

            _out_ = (byte*) stbi__malloc_mad3(target, (int) s.img_x, (int) s.img_y, 0);
            if (_out_ == null)
            {
                return (byte*) (ulong) (stbi__err("outofmem") != 0 ? 0 : 0);
            }

            if (info.bpp < 16)
            {
                int z = 0;
                if (psize == 0 || psize > 256)
                {
                    CRuntime.free(_out_);
                    return (byte*) (ulong) (stbi__err("invalid") != 0 ? 0 : 0);
                }

                for (i = 0; i < psize; ++i)
                {
                    pal[i][2] = stbi__get8(s);
                    pal[i][1] = stbi__get8(s);
                    pal[i][0] = stbi__get8(s);
                    if (info.hsz != 12)
                    {
                        stbi__get8(s);
                    }

                    pal[i][3] = 255;
                }

                stbi__skip(s, info.offset - info.extra_read - info.hsz - psize * (info.hsz == 12 ? 3 : 4));
                if (info.bpp == 1)
                {
                    width = (int) ((s.img_x + 7) >> 3);
                }
                else if (info.bpp == 4)
                {
                    width = (int) ((s.img_x + 1) >> 1);
                }
                else if (info.bpp == 8)
                {
                    width = (int) s.img_x;
                }
                else
                {
                    CRuntime.free(_out_);
                    return (byte*) (ulong) (stbi__err("bad bpp") != 0 ? 0 : 0);
                }

                pad = -width & 3;
                if (info.bpp == 1)
                {
                    for (j = 0; j < (int) s.img_y; ++j)
                    {
                        int bit_offset = 7;
                        int v = stbi__get8(s);
                        for (i = 0; i < (int) s.img_x; ++i)
                        {
                            int color = (v >> bit_offset) & 0x1;
                            _out_[z++] = pal[color][0];
                            _out_[z++] = pal[color][1];
                            _out_[z++] = pal[color][2];
                            if (target == 4)
                            {
                                _out_[z++] = 255;
                            }

                            if (i + 1 == (int) s.img_x)
                            {
                                break;
                            }

                            if (--bit_offset < 0)
                            {
                                bit_offset = 7;
                                v = stbi__get8(s);
                            }
                        }

                        stbi__skip(s, pad);
                    }
                }
                else
                {
                    for (j = 0; j < (int) s.img_y; ++j)
                    {
                        for (i = 0; i < (int) s.img_x; i += 2)
                        {
                            int v = stbi__get8(s);
                            int v2 = 0;
                            if (info.bpp == 4)
                            {
                                v2 = v & 15;
                                v >>= 4;
                            }

                            _out_[z++] = pal[v][0];
                            _out_[z++] = pal[v][1];
                            _out_[z++] = pal[v][2];
                            if (target == 4)
                            {
                                _out_[z++] = 255;
                            }

                            if (i + 1 == (int) s.img_x)
                            {
                                break;
                            }

                            v = info.bpp == 8 ? stbi__get8(s) : v2;
                            _out_[z++] = pal[v][0];
                            _out_[z++] = pal[v][1];
                            _out_[z++] = pal[v][2];
                            if (target == 4)
                            {
                                _out_[z++] = 255;
                            }
                        }

                        stbi__skip(s, pad);
                    }
                }
            }
            else
            {
                int rshift = 0;
                int gshift = 0;
                int bshift = 0;
                int ashift = 0;
                int rcount = 0;
                int gcount = 0;
                int bcount = 0;
                int acount = 0;
                int z = 0;
                int easy = 0;
                stbi__skip(s, info.offset - info.extra_read - info.hsz);
                if (info.bpp == 24)
                {
                    width = (int) (3 * s.img_x);
                }
                else if (info.bpp == 16)
                {
                    width = (int) (2 * s.img_x);
                }
                else
                {
                    width = 0;
                }

                pad = -width & 3;
                if (info.bpp == 24)
                {
                    easy = 1;
                }
                else if (info.bpp == 32)
                {
                    if (mb == 0xff && mg == 0xff00 && mr == 0x00ff0000 && ma == 0xff000000)
                    {
                        easy = 2;
                    }
                }

                if (easy == 0)
                {
                    if (mr == 0 || mg == 0 || mb == 0)
                    {
                        CRuntime.free(_out_);
                        return (byte*) (ulong) (stbi__err("bad masks") != 0 ? 0 : 0);
                    }

                    rshift = stbi__high_bit(mr) - 7;
                    rcount = stbi__bitcount(mr);
                    gshift = stbi__high_bit(mg) - 7;
                    gcount = stbi__bitcount(mg);
                    bshift = stbi__high_bit(mb) - 7;
                    bcount = stbi__bitcount(mb);
                    ashift = stbi__high_bit(ma) - 7;
                    acount = stbi__bitcount(ma);
                    if (rcount > 8 || gcount > 8 || bcount > 8 || acount > 8)
                    {
                        CRuntime.free(_out_);
                        return (byte*) (ulong) (stbi__err("bad masks") != 0 ? 0 : 0);
                    }
                }

                for (j = 0; j < (int) s.img_y; ++j)
                {
                    if (easy != 0)
                    {
                        for (i = 0; i < (int) s.img_x; ++i)
                        {
                            byte a = 0;
                            _out_[z + 2] = stbi__get8(s);
                            _out_[z + 1] = stbi__get8(s);
                            _out_[z + 0] = stbi__get8(s);
                            z += 3;
                            a = (byte) (easy == 2 ? stbi__get8(s) : 255);
                            all_a |= a;
                            if (target == 4)
                            {
                                _out_[z++] = a;
                            }
                        }
                    }
                    else
                    {
                        int bpp = info.bpp;
                        for (i = 0; i < (int) s.img_x; ++i)
                        {
                            uint v = bpp == 16 ? (uint) stbi__get16le(s) : stbi__get32le(s);
                            uint a = 0;
                            _out_[z++] = (byte) (stbi__shiftsigned(v & mr, rshift, rcount) & 255);
                            _out_[z++] = (byte) (stbi__shiftsigned(v & mg, gshift, gcount) & 255);
                            _out_[z++] = (byte) (stbi__shiftsigned(v & mb, bshift, bcount) & 255);
                            a = (uint) (ma != 0 ? stbi__shiftsigned(v & ma, ashift, acount) : 255);
                            all_a |= a;
                            if (target == 4)
                            {
                                _out_[z++] = (byte) (a & 255);
                            }
                        }
                    }

                    stbi__skip(s, pad);
                }
            }

            if (target == 4 && all_a == 0)
            {
                for (i = (int) (4 * s.img_x * s.img_y - 1); i >= 0; i -= 4)
                    _out_[i] = 255;
            }

            if (flip_vertically != 0)
            {
                byte t = 0;
                for (j = 0; j < (int) s.img_y >> 1; ++j)
                {
                    byte* p1 = _out_ + j * s.img_x * target;
                    byte* p2 = _out_ + (s.img_y - 1 - j) * s.img_x * target;
                    for (i = 0; i < (int) s.img_x * target; ++i)
                    {
                        t = p1[i];
                        p1[i] = p2[i];
                        p2[i] = t;
                    }
                }
            }

            if (req_comp != 0 && req_comp != target)
            {
                _out_ = stbi__convert_format(_out_, target, req_comp, s.img_x, s.img_y);
                if (_out_ == null)
                {
                    return _out_;
                }
            }

            *x = (int) s.img_x;
            *y = (int) s.img_y;
            if (comp != null)
            {
                *comp = s.img_n;
            }

            return _out_;
        }

        /// <summary>
        ///     Stbis the bmp info using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <returns>The int</returns>
        public static int stbi__bmp_info(stbi__context s, int* x, int* y, int* comp)
        {
            void* p;
            stbi__bmp_data info = new stbi__bmp_data();
            info.all_a = 255;
            p = stbi__bmp_parse_header(s, &info);
            if (p == null)
            {
                stbi__rewind(s);
                return 0;
            }

            if (x != null)
            {
                *x = (int) s.img_x;
            }

            if (y != null)
            {
                *y = (int) s.img_y;
            }

            if (comp != null)
            {
                if (info.bpp == 24 && info.ma == 0xff000000)
                {
                    *comp = 3;
                }
                else
                {
                    *comp = info.ma != 0 ? 4 : 3;
                }
            }

            return 1;
        }

        /// <summary>
        ///     Stbis the bmp test raw using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The </returns>
        public static int stbi__bmp_test_raw(stbi__context s)
        {
            int r = 0;
            int sz = 0;
            if (stbi__get8(s) != 66)
            {
                return 0;
            }

            if (stbi__get8(s) != 77)
            {
                return 0;
            }

            stbi__get32le(s);
            stbi__get16le(s);
            stbi__get16le(s);
            stbi__get32le(s);
            sz = (int) stbi__get32le(s);
            r = sz == 12 || sz == 40 || sz == 56 || sz == 108 || sz == 124 ? 1 : 0;
            return r;
        }

        /// <summary>
        ///     Stbis the bmp set mask defaults using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="compress">The compress</param>
        /// <returns>The int</returns>
        public static int stbi__bmp_set_mask_defaults(stbi__bmp_data* info, int compress)
        {
            if (compress == 3)
            {
                return 1;
            }

            if (compress == 0)
            {
                if (info->bpp == 16)
                {
                    info->mr = 31u << 10;
                    info->mg = 31u << 5;
                    info->mb = 31u << 0;
                }
                else if (info->bpp == 32)
                {
                    info->mr = 0xffu << 16;
                    info->mg = 0xffu << 8;
                    info->mb = 0xffu << 0;
                    info->ma = 0xffu << 24;
                    info->all_a = 0;
                }
                else
                {
                    info->mr = info->mg = info->mb = info->ma = 0;
                }

                return 1;
            }

            return 0;
        }

        /// <summary>
        ///     Stbis the bmp parse header using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="info">The info</param>
        /// <returns>The void</returns>
        public static void* stbi__bmp_parse_header(stbi__context s, stbi__bmp_data* info)
        {
            int hsz = 0;
            if (stbi__get8(s) != 66 || stbi__get8(s) != 77)
            {
                return (byte*) (ulong) (stbi__err("not BMP") != 0 ? 0 : 0);
            }

            stbi__get32le(s);
            stbi__get16le(s);
            stbi__get16le(s);
            info->offset = (int) stbi__get32le(s);
            info->hsz = hsz = (int) stbi__get32le(s);
            info->mr = info->mg = info->mb = info->ma = 0;
            info->extra_read = 14;
            if (info->offset < 0)
            {
                return (byte*) (ulong) (stbi__err("bad BMP") != 0 ? 0 : 0);
            }

            if (hsz != 12 && hsz != 40 && hsz != 56 && hsz != 108 && hsz != 124)
            {
                return (byte*) (ulong) (stbi__err("unknown BMP") != 0 ? 0 : 0);
            }

            if (hsz == 12)
            {
                s.img_x = (uint) stbi__get16le(s);
                s.img_y = (uint) stbi__get16le(s);
            }
            else
            {
                s.img_x = stbi__get32le(s);
                s.img_y = stbi__get32le(s);
            }

            if (stbi__get16le(s) != 1)
            {
                return (byte*) (ulong) (stbi__err("bad BMP") != 0 ? 0 : 0);
            }

            info->bpp = stbi__get16le(s);
            if (hsz != 12)
            {
                int compress = (int) stbi__get32le(s);
                if (compress == 1 || compress == 2)
                {
                    return (byte*) (ulong) (stbi__err("BMP RLE") != 0 ? 0 : 0);
                }

                if (compress >= 4)
                {
                    return (byte*) (ulong) (stbi__err("BMP JPEG/PNG") != 0 ? 0 : 0);
                }

                if (compress == 3 && info->bpp != 16 && info->bpp != 32)
                {
                    return (byte*) (ulong) (stbi__err("bad BMP") != 0 ? 0 : 0);
                }

                stbi__get32le(s);
                stbi__get32le(s);
                stbi__get32le(s);
                stbi__get32le(s);
                stbi__get32le(s);
                if (hsz == 40 || hsz == 56)
                {
                    if (hsz == 56)
                    {
                        stbi__get32le(s);
                        stbi__get32le(s);
                        stbi__get32le(s);
                        stbi__get32le(s);
                    }

                    if (info->bpp == 16 || info->bpp == 32)
                    {
                        if (compress == 0)
                        {
                            stbi__bmp_set_mask_defaults(info, compress);
                        }
                        else if (compress == 3)
                        {
                            info->mr = stbi__get32le(s);
                            info->mg = stbi__get32le(s);
                            info->mb = stbi__get32le(s);
                            info->extra_read += 12;
                            if (info->mr == info->mg && info->mg == info->mb)
                            {
                                return (byte*) (ulong) (stbi__err("bad BMP") != 0 ? 0 : 0);
                            }
                        }
                        else
                        {
                            return (byte*) (ulong) (stbi__err("bad BMP") != 0 ? 0 : 0);
                        }
                    }
                }
                else
                {
                    int i = 0;
                    if (hsz != 108 && hsz != 124)
                    {
                        return (byte*) (ulong) (stbi__err("bad BMP") != 0 ? 0 : 0);
                    }

                    info->mr = stbi__get32le(s);
                    info->mg = stbi__get32le(s);
                    info->mb = stbi__get32le(s);
                    info->ma = stbi__get32le(s);
                    if (compress != 3)
                    {
                        stbi__bmp_set_mask_defaults(info, compress);
                    }

                    stbi__get32le(s);
                    for (i = 0; i < 12; ++i)
                        stbi__get32le(s);

                    if (hsz == 124)
                    {
                        stbi__get32le(s);
                        stbi__get32le(s);
                        stbi__get32le(s);
                        stbi__get32le(s);
                    }
                }
            }

            return (void*) 1;
        }

        /// <summary>
        ///     The stbi bmp data
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct stbi__bmp_data
        {
            /// <summary>
            ///     The bpp
            /// </summary>
            public int bpp;

            /// <summary>
            ///     The offset
            /// </summary>
            public int offset;

            /// <summary>
            ///     The hsz
            /// </summary>
            public int hsz;

            /// <summary>
            ///     The mr
            /// </summary>
            public uint mr;

            /// <summary>
            ///     The mg
            /// </summary>
            public uint mg;

            /// <summary>
            ///     The mb
            /// </summary>
            public uint mb;

            /// <summary>
            ///     The ma
            /// </summary>
            public uint ma;

            /// <summary>
            ///     The all
            /// </summary>
            public uint all_a;

            /// <summary>
            ///     The extra read
            /// </summary>
            public int extra_read;
        }
    }
}