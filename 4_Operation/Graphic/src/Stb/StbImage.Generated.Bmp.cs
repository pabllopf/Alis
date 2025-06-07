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
        public static int Stbibmptest(Stbicontext s)
        {
            int r = Stbibmptestraw(s);
            Stbirewind(s);
            return r;
        }

        /// <summary>
        ///     Stbis the bmp load using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <param name="reqcomp">The req comp</param>
        /// <param name="ri">The ri</param>
        /// <returns>The @out</returns>
        public static void* Stbibmpload(Stbicontext s, int* x, int* y, int* comp, int reqcomp,
            Stbiresultinfo* ri)
        {
            byte* @out;
            uint mr = 0;
            uint mg = 0;
            uint mb = 0;
            uint ma = 0;
            uint alla = 0;
            byte[][] pal = Utility.CreateArray<byte>(256, 4);
            int psize = 0;
            int i = 0;
            int j = 0;
            int width = 0;
            int flipvertically = 0;
            int pad = 0;
            int target = 0;
            Stbibmpdata info = new Stbibmpdata();
            info.alla = 255;
            if (Stbibmpparseheader(s, &info) == null)
            {
                return null;
            }

            flipvertically = (int) s.Imgy > 0 ? 1 : 0;
            s.Imgy = (uint) CRuntime.Abs((int) s.Imgy);
            if (s.Imgy > 1 << 24)
            {
                return (byte*) (ulong) (Stbierr("too large") != 0 ? 0 : 0);
            }

            if (s.Imgx > 1 << 24)
            {
                return (byte*) (ulong) (Stbierr("too large") != 0 ? 0 : 0);
            }

            mr = info.mr;
            mg = info.mg;
            mb = info.mb;
            ma = info.ma;
            alla = info.alla;
            if (info.hsz == 12)
            {
                if (info.bpp < 24)
                {
                    psize = (info.offset - info.extraread - 24) / 3;
                }
            }
            else
            {
                if (info.bpp < 16)
                {
                    psize = (info.offset - info.extraread - info.hsz) >> 2;
                }
            }

            if (psize == 0)
            {
                int bytesreadsofar = (int) s.Stream.Position;
                int headerlimit = 1024;
                int extradatalimit = 256 * 4;
                if (bytesreadsofar <= 0 || bytesreadsofar > headerlimit)
                {
                    return (byte*) (ulong) (Stbierr("bad header") != 0 ? 0 : 0);
                }

                if (info.offset < bytesreadsofar || info.offset - bytesreadsofar > extradatalimit)
                {
                    return (byte*) (ulong) (Stbierr("bad offset") != 0 ? 0 : 0);
                }

                Stbiskip(s, info.offset - bytesreadsofar);
            }

            if ((info.bpp == 24) && (ma == 0xff000000))
            {
                s.Imgn = 3;
            }
            else
            {
                s.Imgn = ma != 0 ? 4 : 3;
            }

            if ((reqcomp != 0) && (reqcomp >= 3))
            {
                target = reqcomp;
            }
            else
            {
                target = s.Imgn;
            }

            if (Stbimad3Sizesvalid(target, (int) s.Imgx, (int) s.Imgy, 0) == 0)
            {
                return (byte*) (ulong) (Stbierr("too large") != 0 ? 0 : 0);
            }

            @out = (byte*) Stbimallocmad3(target, (int) s.Imgx, (int) s.Imgy, 0);
            if (@out == null)
            {
                return (byte*) (ulong) (Stbierr("outofmem") != 0 ? 0 : 0);
            }

            if (info.bpp < 16)
            {
                int z = 0;
                if (psize == 0 || psize > 256)
                {
                    CRuntime.Free(@out);
                    return (byte*) (ulong) (Stbierr("invalid") != 0 ? 0 : 0);
                }

                for (i = 0; i < psize; ++i)
                {
                    pal[i][2] = Stbiget8(s);
                    pal[i][1] = Stbiget8(s);
                    pal[i][0] = Stbiget8(s);
                    if (info.hsz != 12)
                    {
                        Stbiget8(s);
                    }

                    pal[i][3] = 255;
                }

                Stbiskip(s, info.offset - info.extraread - info.hsz - psize * (info.hsz == 12 ? 3 : 4));
                if (info.bpp == 1)
                {
                    width = (int) ((s.Imgx + 7) >> 3);
                }
                else if (info.bpp == 4)
                {
                    width = (int) ((s.Imgx + 1) >> 1);
                }
                else if (info.bpp == 8)
                {
                    width = (int) s.Imgx;
                }
                else
                {
                    CRuntime.Free(@out);
                    return (byte*) (ulong) (Stbierr("bad bpp") != 0 ? 0 : 0);
                }

                pad = -width & 3;
                if (info.bpp == 1)
                {
                    for (j = 0; j < (int) s.Imgy; ++j)
                    {
                        int bitoffset = 7;
                        int v = Stbiget8(s);
                        for (i = 0; i < (int) s.Imgx; ++i)
                        {
                            int color = (v >> bitoffset) & 0x1;
                            @out[z++] = pal[color][0];
                            @out[z++] = pal[color][1];
                            @out[z++] = pal[color][2];
                            if (target == 4)
                            {
                                @out[z++] = 255;
                            }

                            if (i + 1 == (int) s.Imgx)
                            {
                                break;
                            }

                            if (--bitoffset < 0)
                            {
                                bitoffset = 7;
                                v = Stbiget8(s);
                            }
                        }

                        Stbiskip(s, pad);
                    }
                }
                else
                {
                    for (j = 0; j < (int) s.Imgy; ++j)
                    {
                        for (i = 0; i < (int) s.Imgx; i += 2)
                        {
                            int v = Stbiget8(s);
                            int v2 = 0;
                            if (info.bpp == 4)
                            {
                                v2 = v & 15;
                                v >>= 4;
                            }

                            @out[z++] = pal[v][0];
                            @out[z++] = pal[v][1];
                            @out[z++] = pal[v][2];
                            if (target == 4)
                            {
                                @out[z++] = 255;
                            }

                            if (i + 1 == (int) s.Imgx)
                            {
                                break;
                            }

                            v = info.bpp == 8 ? Stbiget8(s) : v2;
                            @out[z++] = pal[v][0];
                            @out[z++] = pal[v][1];
                            @out[z++] = pal[v][2];
                            if (target == 4)
                            {
                                @out[z++] = 255;
                            }
                        }

                        Stbiskip(s, pad);
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
                Stbiskip(s, info.offset - info.extraread - info.hsz);
                if (info.bpp == 24)
                {
                    width = (int) (3 * s.Imgx);
                }
                else if (info.bpp == 16)
                {
                    width = (int) (2 * s.Imgx);
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
                    if ((mb == 0xff) && (mg == 0xff00) && (mr == 0x00ff0000) && (ma == 0xff000000))
                    {
                        easy = 2;
                    }
                }

                if (easy == 0)
                {
                    if (mr == 0 || mg == 0 || mb == 0)
                    {
                        CRuntime.Free(@out);
                        return (byte*) (ulong) (Stbierr("bad masks") != 0 ? 0 : 0);
                    }

                    rshift = Stbihighbit(mr) - 7;
                    rcount = Stbibitcount(mr);
                    gshift = Stbihighbit(mg) - 7;
                    gcount = Stbibitcount(mg);
                    bshift = Stbihighbit(mb) - 7;
                    bcount = Stbibitcount(mb);
                    ashift = Stbihighbit(ma) - 7;
                    acount = Stbibitcount(ma);
                    if (rcount > 8 || gcount > 8 || bcount > 8 || acount > 8)
                    {
                        CRuntime.Free(@out);
                        return (byte*) (ulong) (Stbierr("bad masks") != 0 ? 0 : 0);
                    }
                }

                for (j = 0; j < (int) s.Imgy; ++j)
                {
                    if (easy != 0)
                    {
                        for (i = 0; i < (int) s.Imgx; ++i)
                        {
                            byte a = 0;
                            @out[z + 2] = Stbiget8(s);
                            @out[z + 1] = Stbiget8(s);
                            @out[z + 0] = Stbiget8(s);
                            z += 3;
                            a = (byte) (easy == 2 ? Stbiget8(s) : 255);
                            alla |= a;
                            if (target == 4)
                            {
                                @out[z++] = a;
                            }
                        }
                    }
                    else
                    {
                        int bpp = info.bpp;
                        for (i = 0; i < (int) s.Imgx; ++i)
                        {
                            uint v = bpp == 16 ? (uint) Stbiget16Le(s) : Stbiget32Le(s);
                            uint a = 0;
                            @out[z++] = (byte) (Stbishiftsigned(v & mr, rshift, rcount) & 255);
                            @out[z++] = (byte) (Stbishiftsigned(v & mg, gshift, gcount) & 255);
                            @out[z++] = (byte) (Stbishiftsigned(v & mb, bshift, bcount) & 255);
                            a = (uint) (ma != 0 ? Stbishiftsigned(v & ma, ashift, acount) : 255);
                            alla |= a;
                            if (target == 4)
                            {
                                @out[z++] = (byte) (a & 255);
                            }
                        }
                    }

                    Stbiskip(s, pad);
                }
            }

            if ((target == 4) && (alla == 0))
            {
                for (i = (int) (4 * s.Imgx * s.Imgy - 1); i >= 0; i -= 4)
                {
                    @out[i] = 255;
                }
            }

            if (flipvertically != 0)
            {
                byte t = 0;
                for (j = 0; j < (int) s.Imgy >> 1; ++j)
                {
                    byte* p1 = @out + j * s.Imgx * target;
                    byte* p2 = @out + (s.Imgy - 1 - j) * s.Imgx * target;
                    for (i = 0; i < (int) s.Imgx * target; ++i)
                    {
                        t = p1[i];
                        p1[i] = p2[i];
                        p2[i] = t;
                    }
                }
            }

            if ((reqcomp != 0) && (reqcomp != target))
            {
                @out = Stbiconvertformat(@out, target, reqcomp, s.Imgx, s.Imgy);
                if (@out == null)
                {
                    return @out;
                }
            }

            *x = (int) s.Imgx;
            *y = (int) s.Imgy;
            if (comp != null)
            {
                *comp = s.Imgn;
            }

            return @out;
        }

        /// <summary>
        ///     Stbis the bmp info using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <returns>The int</returns>
        public static int Stbibmpinfo(Stbicontext s, int* x, int* y, int* comp)
        {
            void* p;
            Stbibmpdata info = new Stbibmpdata();
            info.alla = 255;
            p = Stbibmpparseheader(s, &info);
            if (p == null)
            {
                Stbirewind(s);
                return 0;
            }

            if (x != null)
            {
                *x = (int) s.Imgx;
            }

            if (y != null)
            {
                *y = (int) s.Imgy;
            }

            if (comp != null)
            {
                if ((info.bpp == 24) && (info.ma == 0xff000000))
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
        public static int Stbibmptestraw(Stbicontext s)
        {
            int r = 0;
            int sz = 0;
            if (Stbiget8(s) != 66)
            {
                return 0;
            }

            if (Stbiget8(s) != 77)
            {
                return 0;
            }

            Stbiget32Le(s);
            Stbiget16Le(s);
            Stbiget16Le(s);
            Stbiget32Le(s);
            sz = (int) Stbiget32Le(s);
            r = sz == 12 || sz == 40 || sz == 56 || sz == 108 || sz == 124 ? 1 : 0;
            return r;
        }

        /// <summary>
        ///     Stbis the bmp set mask defaults using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="compress">The compress</param>
        /// <returns>The int</returns>
        public static int Stbibmpsetmaskdefaults(Stbibmpdata* info, int compress)
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
                    info->alla = 0;
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
        public static void* Stbibmpparseheader(Stbicontext s, Stbibmpdata* info)
        {
            int hsz = 0;
            if (Stbiget8(s) != 66 || Stbiget8(s) != 77)
            {
                return (byte*) (ulong) (Stbierr("not BMP") != 0 ? 0 : 0);
            }

            Stbiget32Le(s);
            Stbiget16Le(s);
            Stbiget16Le(s);
            info->offset = (int) Stbiget32Le(s);
            info->hsz = hsz = (int) Stbiget32Le(s);
            info->mr = info->mg = info->mb = info->ma = 0;
            info->extraread = 14;
            if (info->offset < 0)
            {
                return (byte*) (ulong) (Stbierr("bad BMP") != 0 ? 0 : 0);
            }

            if ((hsz != 12) && (hsz != 40) && (hsz != 56) && (hsz != 108) && (hsz != 124))
            {
                return (byte*) (ulong) (Stbierr("unknown BMP") != 0 ? 0 : 0);
            }

            if (hsz == 12)
            {
                s.Imgx = (uint) Stbiget16Le(s);
                s.Imgy = (uint) Stbiget16Le(s);
            }
            else
            {
                s.Imgx = Stbiget32Le(s);
                s.Imgy = Stbiget32Le(s);
            }

            if (Stbiget16Le(s) != 1)
            {
                return (byte*) (ulong) (Stbierr("bad BMP") != 0 ? 0 : 0);
            }

            info->bpp = Stbiget16Le(s);
            if (hsz != 12)
            {
                int compress = (int) Stbiget32Le(s);
                if (compress == 1 || compress == 2)
                {
                    return (byte*) (ulong) (Stbierr("BMP RLE") != 0 ? 0 : 0);
                }

                if (compress >= 4)
                {
                    return (byte*) (ulong) (Stbierr("BMP JPEG/PNG") != 0 ? 0 : 0);
                }

                if ((compress == 3) && (info->bpp != 16) && (info->bpp != 32))
                {
                    return (byte*) (ulong) (Stbierr("bad BMP") != 0 ? 0 : 0);
                }

                Stbiget32Le(s);
                Stbiget32Le(s);
                Stbiget32Le(s);
                Stbiget32Le(s);
                Stbiget32Le(s);
                if (hsz == 40 || hsz == 56)
                {
                    if (hsz == 56)
                    {
                        Stbiget32Le(s);
                        Stbiget32Le(s);
                        Stbiget32Le(s);
                        Stbiget32Le(s);
                    }

                    if (info->bpp == 16 || info->bpp == 32)
                    {
                        if (compress == 0)
                        {
                            Stbibmpsetmaskdefaults(info, compress);
                        }
                        else if (compress == 3)
                        {
                            info->mr = Stbiget32Le(s);
                            info->mg = Stbiget32Le(s);
                            info->mb = Stbiget32Le(s);
                            info->extraread += 12;
                            if ((info->mr == info->mg) && (info->mg == info->mb))
                            {
                                return (byte*) (ulong) (Stbierr("bad BMP") != 0 ? 0 : 0);
                            }
                        }
                        else
                        {
                            return (byte*) (ulong) (Stbierr("bad BMP") != 0 ? 0 : 0);
                        }
                    }
                }
                else
                {
                    int i = 0;
                    if ((hsz != 108) && (hsz != 124))
                    {
                        return (byte*) (ulong) (Stbierr("bad BMP") != 0 ? 0 : 0);
                    }

                    info->mr = Stbiget32Le(s);
                    info->mg = Stbiget32Le(s);
                    info->mb = Stbiget32Le(s);
                    info->ma = Stbiget32Le(s);
                    if (compress != 3)
                    {
                        Stbibmpsetmaskdefaults(info, compress);
                    }

                    Stbiget32Le(s);
                    for (i = 0; i < 12; ++i)
                    {
                        Stbiget32Le(s);
                    }

                    if (hsz == 124)
                    {
                        Stbiget32Le(s);
                        Stbiget32Le(s);
                        Stbiget32Le(s);
                        Stbiget32Le(s);
                    }
                }
            }

            return (void*) 1;
        }

        /// <summary>
        ///     The stbi bmp data
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Stbibmpdata
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
            public uint alla;

            /// <summary>
            ///     The extra read
            /// </summary>
            public int extraread;
        }
    }
}