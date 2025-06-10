// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbImage.Generated.Png.cs
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
    unsafe partial class StbImage
    {
        /// <summary>
        ///     The stbi none
        /// </summary>
        public const int StbiFnone = 0;

        /// <summary>
        ///     The stbi sub
        /// </summary>
        public const int StbiFsub = 1;

        /// <summary>
        ///     The stbi up
        /// </summary>
        public const int StbiFup = 2;

        /// <summary>
        ///     The stbi avg
        /// </summary>
        public const int StbiFavg = 3;

        /// <summary>
        ///     The stbi paeth
        /// </summary>
        public const int StbiFpaeth = 4;

        /// <summary>
        ///     The stbi avg first
        /// </summary>
        public const int StbiFavgfirst = 5;

        /// <summary>
        ///     The stbi sub
        /// </summary>
        public static byte[] Firstrowfilter =
            {StbiFnone, StbiFsub, StbiFnone, StbiFavgfirst, StbiFsub};

        /// <summary>
        ///     The stbi check png header png sig
        /// </summary>
        public static byte[] Stbicheckpngheaderpngsig = {137, 80, 78, 71, 13, 10, 26, 10};

        /// <summary>
        ///     The stbi depth scale table
        /// </summary>
        public static byte[] Stbidepthscaletable = {0, 0xff, 0x55, 0, 0x11, 0, 0, 0, 0x01};

        /// <summary>
        ///     Stbis the png test using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The </returns>
        public static int Stbipngtest(Stbicontext s)
        {
            int r = 0;
            r = Stbicheckpngheader(s);
            Stbirewind(s);
            return r;
        }

        /// <summary>
        ///     Stbis the png load using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <param name="reqcomp">The req comp</param>
        /// <param name="ri">The ri</param>
        /// <returns>The void</returns>
        public static void* Stbipngload(Stbicontext s, int* x, int* y, int* comp, int reqcomp,
            Stbiresultinfo* ri)
        {
            Stbipng p = new Stbipng();
            p.S = s;
            return Stbidopng(p, x, y, comp, reqcomp, ri);
        }

        /// <summary>
        ///     Stbis the png info using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <returns>The int</returns>
        public static int Stbipnginfo(Stbicontext s, ref int x, ref int y, ref int comp)
        {
            Stbipng p = new Stbipng();
            p.S = s;
            return Stbipnginforaw(p, ref x, ref y, ref comp);
        }

        /// <summary>
        ///     Stbis the png is 16 using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The int</returns>
        public static int Stbipngis16(Stbicontext s)
        {
            Stbipng p = new Stbipng();
            p.S = s;
            int i = 0;
            int i1 = 0;
            int comp = 0;
            if (Stbipnginforaw(p, ref i, ref i1, ref comp) == 0)
            {
                return 0;
            }

            if (p.Depth != 16)
            {
                Stbirewind(p.S);
                return 0;
            }

            return 1;
        }

        /// <summary>
        ///     Stbis the get chunk header using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The </returns>
        public static Stbipngchunk Stbigetchunkheader(Stbicontext s)
        {
            Stbipngchunk c = new Stbipngchunk();
            c.length = Stbiget32Be(s);
            c.type = Stbiget32Be(s);
            return c;
        }

        /// <summary>
        ///     Stbis the check png header using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The int</returns>
        public static int Stbicheckpngheader(Stbicontext s)
        {
            int i = 0;
            for (i = 0; i < 8; ++i)
            {
                if (Stbiget8(s) != Stbicheckpngheaderpngsig[i])
                {
                    return Stbierr("bad png sig");
                }
            }

            return 1;
        }

        /// <summary>
        ///     Stbis the paeth using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <returns>The </returns>
        public static int Stbipaeth(int a, int b, int c)
        {
            int thresh = c * 3 - (a + b);
            int lo = a < b ? a : b;
            int hi = a < b ? b : a;
            int t0 = hi <= thresh ? lo : c;
            int t1 = thresh <= lo ? hi : t0;
            return t1;
        }

        /// <summary>
        ///     Stbis the create png alpha expand 8 using the specified dest
        /// </summary>
        /// <param name="dest">The dest</param>
        /// <param name="src">The src</param>
        /// <param name="x">The </param>
        /// <param name="imgn">The img</param>
        public static void Stbicreatepngalphaexpand8(byte* dest, byte* src, uint x, int imgn)
        {
            int i = 0;
            if (imgn == 1)
            {
                for (i = (int) (x - 1); i >= 0; --i)
                {
                    dest[i * 2 + 1] = 255;
                    dest[i * 2 + 0] = src[i];
                }
            }
            else
            {
                for (i = (int) (x - 1); i >= 0; --i)
                {
                    dest[i * 4 + 3] = 255;
                    dest[i * 4 + 2] = src[i * 3 + 2];
                    dest[i * 4 + 1] = src[i * 3 + 1];
                    dest[i * 4 + 0] = src[i * 3 + 0];
                }
            }
        }


        /// <summary>
        ///     Stbis the create png image raw using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="raw">The raw</param>
        /// <param name="rawlen">The raw len</param>
        /// <param name="outn">The @out</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="depth">The depth</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        public static int Stbicreatepngimageraw(Stbipng a, byte* raw, uint rawlen, int outn, uint x, uint y,
            int depth, int color)
        {
            int bytes = depth == 16 ? 2 : 1;
            Stbicontext s = a.S;
            uint i = 0;
            uint j = 0;
            uint stride = (uint) (x * outn * bytes);
            uint imglen = 0;
            uint imgwidthbytes = 0;
            byte* filterbuf;
            int allok = 1;
            int k = 0;
            int imgn = s.Imgn;
            int outputbytes = outn * bytes;
            int filterbytes = imgn * bytes;
            int width = (int) x;
            a.@out = (IntPtr)Stbimallocmad3((int) x, (int) y, outputbytes, 0);
            if (a.@out == IntPtr.Zero)
            {
                return Stbierr("outofmem");
            }

            if (Stbimad3Sizesvalid(imgn, (int) x, depth, 7) == 0)
            {
                return Stbierr("too large");
            }

            imgwidthbytes = (uint) ((imgn * x * depth + 7) >> 3);
            if (Stbimad2Sizesvalid((int) imgwidthbytes, (int) y, (int) imgwidthbytes) == 0)
            {
                return Stbierr("too large");
            }

            imglen = (imgwidthbytes + 1) * y;
            if (rawlen < imglen)
            {
                return Stbierr("not enough pixels");
            }

            filterbuf = (byte*) Stbimallocmad2((int) imgwidthbytes, 2, 0);
            if (filterbuf == null)
            {
                return Stbierr("outofmem");
            }

            if (depth < 8)
            {
                filterbytes = 1;
                width = (int) imgwidthbytes;
            }

            for (j = 0; j < y; ++j)
            {
                byte* cur = filterbuf + (j & 1) * imgwidthbytes;
                byte* prior = filterbuf + (~j & 1) * imgwidthbytes;
                byte* dest = (byte*)(a.@out + (int)(stride * j));
                int nk = width * filterbytes;
                int filter = *raw++;
                if (filter > 4)
                {
                    allok = Stbierr("invalid filter");
                    break;
                }

                if (j == 0)
                {
                    filter = Firstrowfilter[filter];
                }

                switch (filter)
                {
                    case StbiFnone:
                        CRuntime.Memcpy(cur, raw, (ulong) nk);
                        break;
                    case StbiFsub:
                        CRuntime.Memcpy(cur, raw, (ulong) filterbytes);
                        for (k = filterbytes; k < nk; ++k)
                        {
                            cur[k] = (byte) ((raw[k] + cur[k - filterbytes]) & 255);
                        }

                        break;
                    case StbiFup:
                        for (k = 0; k < nk; ++k)
                        {
                            cur[k] = (byte) ((raw[k] + prior[k]) & 255);
                        }

                        break;
                    case StbiFavg:
                        for (k = 0; k < filterbytes; ++k)
                        {
                            cur[k] = (byte) ((raw[k] + (prior[k] >> 1)) & 255);
                        }

                        for (k = filterbytes; k < nk; ++k)
                        {
                            cur[k] = (byte) ((raw[k] + ((prior[k] + cur[k - filterbytes]) >> 1)) & 255);
                        }

                        break;
                    case StbiFpaeth:
                        for (k = 0; k < filterbytes; ++k)
                        {
                            cur[k] = (byte) ((raw[k] + prior[k]) & 255);
                        }

                        for (k = filterbytes; k < nk; ++k)
                        {
                            cur[k] = (byte) ((raw[k] + Stbipaeth(cur[k - filterbytes], prior[k],
                                prior[k - filterbytes])) & 255);
                        }

                        break;
                    case StbiFavgfirst:
                        CRuntime.Memcpy(cur, raw, (ulong) filterbytes);
                        for (k = filterbytes; k < nk; ++k)
                        {
                            cur[k] = (byte) ((raw[k] + (cur[k - filterbytes] >> 1)) & 255);
                        }

                        break;
                }

                raw += nk;
                if (depth < 8)
                {
                    byte scale = (byte) (color == 0 ? Stbidepthscaletable[depth] : 1);
                    byte* @in = cur;
                    byte* @out = dest;
                    byte inb = 0;
                    uint nsmp = (uint) (x * imgn);
                    if (depth == 4)
                    {
                        for (i = 0; i < nsmp; ++i)
                        {
                            if ((i & 1) == 0)
                            {
                                inb = *@in++;
                            }

                            *@out++ = (byte) (scale * (inb >> 4));
                            inb <<= 4;
                        }
                    }
                    else if (depth == 2)
                    {
                        for (i = 0; i < nsmp; ++i)
                        {
                            if ((i & 3) == 0)
                            {
                                inb = *@in++;
                            }

                            *@out++ = (byte) (scale * (inb >> 6));
                            inb <<= 2;
                        }
                    }
                    else
                    {
                        for (i = 0; i < nsmp; ++i)
                        {
                            if ((i & 7) == 0)
                            {
                                inb = *@in++;
                            }

                            *@out++ = (byte) (scale * (inb >> 7));
                            inb <<= 1;
                        }
                    }

                    if (imgn != outn)
                    {
                        Stbicreatepngalphaexpand8(dest, dest, x, imgn);
                    }
                }
                else if (depth == 8)
                {
                    if (imgn == outn)
                    {
                        CRuntime.Memcpy(dest, cur, (ulong) (x * imgn));
                    }
                    else
                    {
                        Stbicreatepngalphaexpand8(dest, cur, x, imgn);
                    }
                }
                else if (depth == 16)
                {
                    ushort* dest16 = (ushort*) dest;
                    uint nsmp = (uint) (x * imgn);
                    if (imgn == outn)
                    {
                        for (i = 0; i < nsmp; ++i, ++dest16, cur += 2)
                        {
                            *dest16 = (ushort) ((cur[0] << 8) | cur[1]);
                        }
                    }
                    else
                    {
                        if (imgn == 1)
                        {
                            for (i = 0; i < x; ++i, dest16 += 2, cur += 2)
                            {
                                dest16[0] = (ushort) ((cur[0] << 8) | cur[1]);
                                dest16[1] = 0xffff;
                            }
                        }
                        else
                        {
                            for (i = 0; i < x; ++i, dest16 += 4, cur += 6)
                            {
                                dest16[0] = (ushort) ((cur[0] << 8) | cur[1]);
                                dest16[1] = (ushort) ((cur[2] << 8) | cur[3]);
                                dest16[2] = (ushort) ((cur[4] << 8) | cur[5]);
                                dest16[3] = 0xffff;
                            }
                        }
                    }
                }
            }

            CRuntime.Free(filterbuf);
            if (allok == 0)
            {
                return 0;
            }

            return 1;
        }

        /// <summary>
        ///     Stbis the create png image using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="imagedata">The image data</param>
        /// <param name="imagedatalen">The image data len</param>
        /// <param name="outn">The @out</param>
        /// <param name="depth">The depth</param>
        /// <param name="color">The color</param>
        /// <param name="interlaced">The interlaced</param>
        /// <returns>The int</returns>
        public static int Stbicreatepngimage(Stbipng a, byte* imagedata, uint imagedatalen, int outn,
            int depth, int color, int interlaced)
        {
            int bytes = depth == 16 ? 2 : 1;
            int outbytes = outn * bytes;
            byte* final;
            int p = 0;
            if (interlaced == 0)
            {
                return Stbicreatepngimageraw(a, imagedata, imagedatalen, outn, a.S.Imgx, a.S.Imgy, depth,
                    color);
            }

            final = (byte*) Stbimallocmad3((int) a.S.Imgx, (int) a.S.Imgy, outbytes, 0);
            if (final == null)
            {
                return Stbierr("outofmem");
            }

            for (p = 0; p < 7; ++p)
            {
#pragma warning disable CA2014
                int* xorig = stackalloc int[] {0, 4, 0, 2, 0, 1, 0};
                int* yorig = stackalloc int[] {0, 0, 4, 0, 2, 0, 1};
                int* xspc = stackalloc int[] {8, 8, 4, 4, 2, 2, 1};
                int* yspc = stackalloc int[] {8, 8, 8, 4, 4, 2, 2};
#pragma warning restore CA2014
                int i = 0;
                int j = 0;
                int x = 0;
                int y = 0;
                x = (int) ((a.S.Imgx - xorig[p] + xspc[p] - 1) / xspc[p]);
                y = (int) ((a.S.Imgy - yorig[p] + yspc[p] - 1) / yspc[p]);
                if ((x != 0) && (y != 0))
                {
                    uint imglen = (uint) ((((a.S.Imgn * x * depth + 7) >> 3) + 1) * y);
                    if (Stbicreatepngimageraw(a, imagedata, imagedatalen, outn, (uint) x, (uint) y, depth,
                            color) == 0)
                    {
                        CRuntime.Free(final);
                        return 0;
                    }

                    for (j = 0; j < y; ++j)
                    for (i = 0; i < x; ++i)
                    {
                        int outy = j * yspc[p] + yorig[p];
                        int outx = i * xspc[p] + xorig[p];
                        CRuntime.Memcpy(final + outy * a.S.Imgx * outbytes + outx * outbytes,
                            (void*)(a.@out + (j * x + i) * outbytes), (ulong) outbytes);
                    }

                    CRuntime.Free((void*)a.@out);
                    imagedata += imglen;
                    imagedatalen -= imglen;
                }
            }

            a.@out = (IntPtr)final;
            return 1;
        }

        /// <summary>
        ///     Stbis the compute transparency using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <param name="tc">The tc</param>
        /// <param name="outn">The @out</param>
        /// <returns>The int</returns>
        public static int Stbicomputetransparency(Stbipng z, byte* tc, int outn)
        {
            Stbicontext s = z.S;
            uint i = 0;
            uint pixelcount = s.Imgx * s.Imgy;
            byte* p = (byte*)z.@out;
            if (outn == 2)
            {
                for (i = 0; i < pixelcount; ++i)
                {
                    p[1] = (byte) (p[0] == tc[0] ? 0 : 255);
                    p += 2;
                }
            }
            else
            {
                for (i = 0; i < pixelcount; ++i)
                {
                    if ((p[0] == tc[0]) && (p[1] == tc[1]) && (p[2] == tc[2]))
                    {
                        p[3] = 0;
                    }

                    p += 4;
                }
            }

            return 1;
        }

        /// <summary>
        ///     Stbis the compute transparency 16 using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <param name="tc">The tc</param>
        /// <param name="outn">The @out</param>
        /// <returns>The int</returns>
        public static int Stbicomputetransparency16(Stbipng z, ushort* tc, int outn)
        {
            Stbicontext s = z.S;
            uint i = 0;
            uint pixelcount = s.Imgx * s.Imgy;
            ushort* p = (ushort*) z.@out;
            if (outn == 2)
            {
                for (i = 0; i < pixelcount; ++i)
                {
                    p[1] = (ushort) (p[0] == tc[0] ? 0 : 65535);
                    p += 2;
                }
            }
            else
            {
                for (i = 0; i < pixelcount; ++i)
                {
                    if ((p[0] == tc[0]) && (p[1] == tc[1]) && (p[2] == tc[2]))
                    {
                        p[3] = 0;
                    }

                    p += 4;
                }
            }

            return 1;
        }

        /// <summary>
        ///     Stbis the expand png palette using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="palette">The palette</param>
        /// <param name="len">The len</param>
        /// <param name="palimgn">The pal img</param>
        /// <returns>The int</returns>
        public static int Stbiexpandpngalette(Stbipng a, byte* palette, int len, int palimgn)
        {
            uint i = 0;
            uint pixelcount = a.S.Imgx * a.S.Imgy;
            byte* p;
            byte* tempout;
            byte* orig = (byte*)a.@out;
            p = (byte*) Stbimallocmad2((int) pixelcount, palimgn, 0);
            if (p == null)
            {
                return Stbierr("outofmem");
            }

            tempout = p;
            if (palimgn == 3)
            {
                for (i = 0; i < pixelcount; ++i)
                {
                    int n = orig[i] * 4;
                    p[0] = palette[n];
                    p[1] = palette[n + 1];
                    p[2] = palette[n + 2];
                    p += 3;
                }
            }
            else
            {
                for (i = 0; i < pixelcount; ++i)
                {
                    int n = orig[i] * 4;
                    p[0] = palette[n];
                    p[1] = palette[n + 1];
                    p[2] = palette[n + 2];
                    p[3] = palette[n + 3];
                    p += 4;
                }
            }

            CRuntime.Free((void*)a.@out);
            a.@out = (IntPtr)tempout;
            return 1;
        }

        /// <summary>
        ///     Stbis the de iphone using the specified z
        /// </summary>
        /// <param name="z">The </param>
        public static void Stbideiphone(Stbipng z)
        {
            Stbicontext s = z.S;
            uint i = 0;
            uint pixelcount = s.Imgx * s.Imgy;
            byte* p = (byte*)z.@out;
            if (s.Imgoutn == 3)
            {
                for (i = 0; i < pixelcount; ++i)
                {
                    byte t = p[0];
                    p[0] = p[2];
                    p[2] = t;
                    p += 3;
                }
            }
            else
            {
                if ((Stbiunpremultiplyonloadset != 0
                        ? Stbiunpremultiplyonloadlocal
                        : Stbiunpremultiplyonloadglobal) != 0)
                {
                    for (i = 0; i < pixelcount; ++i)
                    {
                        byte a = p[3];
                        byte t = p[0];
                        if (a != 0)
                        {
                            byte half = (byte) (a / 2);
                            p[0] = (byte) ((p[2] * 255 + half) / a);
                            p[1] = (byte) ((p[1] * 255 + half) / a);
                            p[2] = (byte) ((t * 255 + half) / a);
                        }
                        else
                        {
                            p[0] = p[2];
                            p[2] = t;
                        }

                        p += 4;
                    }
                }
                else
                {
                    for (i = 0; i < pixelcount; ++i)
                    {
                        byte t = p[0];
                        p[0] = p[2];
                        p[2] = t;
                        p += 4;
                    }
                }
            }
        }

        /// <summary>
        ///     Stbis the parse png file using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <param name="scan">The scan</param>
        /// <param name="reqcomp">The req comp</param>
        /// <returns>The int</returns>
        public static int Stbiparsepngfile(Stbipng z, int scan, int reqcomp)
        {
            byte* palette = stackalloc byte[1024];
            byte palimgn = 0;
            byte hastrans = 0;
            byte* tc = stackalloc byte[] {0, 0, 0};
            ushort* tc16 = stackalloc ushort[3];
            uint ioff = 0;
            uint idatalimit = 0;
            uint i = 0;
            uint pallen = 0;
            int first = 1;
            int k = 0;
            int interlace = 0;
            int color = 0;
            int isiphone = 0;
            Stbicontext s = z.S;
            z.Expanded = IntPtr.Zero;
            z.Idata = IntPtr.Zero;
            z.@out = IntPtr.Zero;
            if (Stbicheckpngheader(s) == 0)
            {
                return 0;
            }

            if (scan == StbiscaNtype)
            {
                return 1;
            }

            for (;;)
            {
                Stbipngchunk c = Stbigetchunkheader(s);
                switch (c.type)
                {
                    case ((uint) 67 << 24) + ((uint) 103 << 16) + ((uint) 66 << 8) + 73:
                        isiphone = 1;
                        Stbiskip(s, (int) c.length);
                        break;
                    case ((uint) 73 << 24) + ((uint) 72 << 16) + ((uint) 68 << 8) + 82:
                    {
                        int comp = 0;
                        int filter = 0;
                        if (first == 0)
                        {
                            return Stbierr("multiple IHDR");
                        }

                        first = 0;
                        if (c.length != 13)
                        {
                            return Stbierr("bad IHDR len");
                        }

                        s.Imgx = Stbiget32Be(s);
                        s.Imgy = Stbiget32Be(s);
                        if (s.Imgy > 1 << 24)
                        {
                            return Stbierr("too large");
                        }

                        if (s.Imgx > 1 << 24)
                        {
                            return Stbierr("too large");
                        }

                        z.Depth = Stbiget8(s);
                        if ((z.Depth != 1) && (z.Depth != 2) && (z.Depth != 4) && (z.Depth != 8) && (z.Depth != 16))
                        {
                            return Stbierr("1/2/4/8/16-bit only");
                        }

                        color = Stbiget8(s);
                        if (color > 6)
                        {
                            return Stbierr("bad ctype");
                        }

                        if ((color == 3) && (z.Depth == 16))
                        {
                            return Stbierr("bad ctype");
                        }

                        if (color == 3)
                        {
                            palimgn = 3;
                        }
                        else if ((color & 1) != 0)
                        {
                            return Stbierr("bad ctype");
                        }

                        comp = Stbiget8(s);
                        if (comp != 0)
                        {
                            return Stbierr("bad comp method");
                        }

                        filter = Stbiget8(s);
                        if (filter != 0)
                        {
                            return Stbierr("bad filter method");
                        }

                        interlace = Stbiget8(s);
                        if (interlace > 1)
                        {
                            return Stbierr("bad interlace method");
                        }

                        if (s.Imgx == 0 || s.Imgy == 0)
                        {
                            return Stbierr("0-pixel image");
                        }

                        if (palimgn == 0)
                        {
                            s.Imgn = ((color & 2) != 0 ? 3 : 1) + ((color & 4) != 0 ? 1 : 0);
                            if ((1 << 30) / s.Imgx / s.Imgn < s.Imgy)
                            {
                                return Stbierr("too large");
                            }
                        }
                        else
                        {
                            s.Imgn = 1;
                            if ((1 << 30) / s.Imgx / 4 < s.Imgy)
                            {
                                return Stbierr("too large");
                            }
                        }

                        break;
                    }

                    case ((uint) 80 << 24) + ((uint) 76 << 16) + ((uint) 84 << 8) + 69:
                    {
                        if (first != 0)
                        {
                            return Stbierr("first not IHDR");
                        }

                        if (c.length > 256 * 3)
                        {
                            return Stbierr("invalid PLTE");
                        }

                        pallen = c.length / 3;
                        if (pallen * 3 != c.length)
                        {
                            return Stbierr("invalid PLTE");
                        }

                        for (i = 0; i < pallen; ++i)
                        {
                            palette[i * 4 + 0] = Stbiget8(s);
                            palette[i * 4 + 1] = Stbiget8(s);
                            palette[i * 4 + 2] = Stbiget8(s);
                            palette[i * 4 + 3] = 255;
                        }

                        break;
                    }

                    case ((uint) 116 << 24) + ((uint) 82 << 16) + ((uint) 78 << 8) + 83:
                    {
                        if (first != 0)
                        {
                            return Stbierr("first not IHDR");
                        }

                        if (z.Idata != IntPtr.Zero)
                        {
                            return Stbierr("tRNS after IDAT");
                        }

                        if (palimgn != 0)
                        {
                            if (scan == StbiscaNheader)
                            {
                                s.Imgn = 4;
                                return 1;
                            }

                            if (pallen == 0)
                            {
                                return Stbierr("tRNS before PLTE");
                            }

                            if (c.length > pallen)
                            {
                                return Stbierr("bad tRNS len");
                            }

                            palimgn = 4;
                            for (i = 0; i < c.length; ++i)
                            {
                                palette[i * 4 + 3] = Stbiget8(s);
                            }
                        }
                        else
                        {
                            if ((s.Imgn & 1) == 0)
                            {
                                return Stbierr("tRNS with alpha");
                            }

                            if (c.length != (uint) s.Imgn * 2)
                            {
                                return Stbierr("bad tRNS len");
                            }

                            hastrans = 1;
                            if (scan == StbiscaNheader)
                            {
                                ++s.Imgn;
                                return 1;
                            }

                            if (z.Depth == 16)
                            {
                                for (k = 0; (k < s.Imgn) && (k < 3); ++k)
                                {
                                    tc16[k] = (ushort) Stbiget16Be(s);
                                }
                            }
                            else
                            {
                                for (k = 0; (k < s.Imgn) && (k < 3); ++k)
                                {
                                    tc[k] = (byte) ((byte) (Stbiget16Be(s) & 255) * Stbidepthscaletable[z.Depth]);
                                }
                            }
                        }

                        break;
                    }

                    case ((uint) 73 << 24) + ((uint) 68 << 16) + ((uint) 65 << 8) + 84:
                    {
                        if (first != 0)
                        {
                            return Stbierr("first not IHDR");
                        }

                        if ((palimgn != 0) && (pallen == 0))
                        {
                            return Stbierr("no PLTE");
                        }

                        if (scan == StbiscaNheader)
                        {
                            if (palimgn != 0)
                            {
                                s.Imgn = palimgn;
                            }

                            return 1;
                        }

                        if (c.length > 1u << 30)
                        {
                            return Stbierr("IDAT size limit");
                        }

                        if ((int) (ioff + c.length) < (int) ioff)
                        {
                            return 0;
                        }

                        if (ioff + c.length > idatalimit)
                        {
                            uint idatalimitold = idatalimit;
                            byte* p;
                            if (idatalimit == 0)
                            {
                                idatalimit = c.length > 4096 ? c.length : 4096;
                            }

                            while (ioff + c.length > idatalimit)
                            {
                                idatalimit *= 2;
                            }

                            p = (byte*) CRuntime.Realloc((void*)z.Idata, (ulong) idatalimit);
                            if (p == null)
                            {
                                return Stbierr("outofmem");
                            }

                            z.Idata = (IntPtr)p;
                        }

                        if (Stbigetn(s, (IntPtr)(z.Idata + (int)ioff), (int) c.length) == 0)
                        {
                            return Stbierr("outofdata");
                        }

                        ioff += c.length;
                        break;
                    }

                    case ((uint) 73 << 24) + ((uint) 69 << 16) + ((uint) 78 << 8) + 68:
                    {
                        uint rawlen = 0;
                        if (first != 0)
                        {
                            return Stbierr("first not IHDR");
                        }

                        if (scan != StbiscaNload)
                        {
                            return 1;
                        }

                        if (z.Idata == IntPtr.Zero)
                        {
                            return Stbierr("no IDAT");
                        }

                        if (z.Expanded == IntPtr.Zero)
                        {
                            return 0;
                        }

                        CRuntime.Free((void*)z.Idata);
                        z.Idata = IntPtr.Zero;
                        if (((reqcomp == s.Imgn + 1) && (reqcomp != 3) && (palimgn == 0)) || hastrans != 0)
                        {
                            s.Imgoutn = s.Imgn + 1;
                        }
                        else
                        {
                            s.Imgoutn = s.Imgn;
                        }

                        if (Stbicreatepngimage(z, (byte*)z.Expanded, rawlen, s.Imgoutn, z.Depth, color, interlace) == 0)
                        {
                            return 0;
                        }

                        if (hastrans != 0)
                        {
                            if (z.Depth == 16)
                            {
                                if (Stbicomputetransparency16(z, tc16, s.Imgoutn) == 0)
                                {
                                    return 0;
                                }
                            }
                            else
                            {
                                if (Stbicomputetransparency(z, tc, s.Imgoutn) == 0)
                                {
                                    return 0;
                                }
                            }
                        }

                        if ((isiphone != 0) &&
                            ((Stbideiphoneflagset != 0
                                ? Stbideiphoneflaglocal
                                : Stbideiphoneflagglobal) != 0) && (s.Imgoutn > 2))
                        {
                            Stbideiphone(z);
                        }

                        if (palimgn != 0)
                        {
                            s.Imgn = palimgn;
                            s.Imgoutn = palimgn;
                            if (reqcomp >= 3)
                            {
                                s.Imgoutn = reqcomp;
                            }

                            if (Stbiexpandpngalette(z, palette, (int) pallen, s.Imgoutn) == 0)
                            {
                                return 0;
                            }
                        }
                        else if (hastrans != 0)
                        {
                            ++s.Imgn;
                        }

                        CRuntime.Free((void*)z.Expanded);
                        z.Expanded = IntPtr.Zero;
                        Stbiget32Be(s);
                        return 1;
                    }

                    default:
                        if (first != 0)
                        {
                            return Stbierr("first not IHDR");
                        }

                        if ((c.type & (1 << 29)) == 0)
                        {
                            Stbiparsepngfileinvalidchunk[0] = (char) ((c.type >> 24) & 255);
                            Stbiparsepngfileinvalidchunk[1] = (char) ((c.type >> 16) & 255);
                            Stbiparsepngfileinvalidchunk[2] = (char) ((c.type >> 8) & 255);
                            Stbiparsepngfileinvalidchunk[3] = (char) ((c.type >> 0) & 255);
                            return Stbierr(new string(Stbiparsepngfileinvalidchunk));
                        }

                        Stbiskip(s, (int) c.length);
                        break;
                }

                Stbiget32Be(s);
            }
        }

        /// <summary>
        ///     Stbis the do png using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="n">The </param>
        /// <param name="reqcomp">The req comp</param>
        /// <param name="ri">The ri</param>
        /// <returns>The result</returns>
        public static void* Stbidopng(Stbipng p, int* x, int* y, int* n, int reqcomp, Stbiresultinfo* ri)
        {
            void* result = null;
            if (reqcomp < 0 || reqcomp > 4)
            {
                return (byte*) (ulong) (Stbierr("bad reqcomp") != 0 ? 0 : 0);
            }

            if (Stbiparsepngfile(p, StbiscaNload, reqcomp) != 0)
            {
                if (p.Depth <= 8)
                {
                    ri->bitsperchannel = 8;
                }
                else if (p.Depth == 16)
                {
                    ri->bitsperchannel = 16;
                }
                else
                {
                    return (byte*) (ulong) (Stbierr("bad bitsperchannel") != 0 ? 0 : 0);
                }

                result = (void*)p.@out;
                p.@out = IntPtr.Zero;
                if ((reqcomp != 0) && (reqcomp != p.S.Imgoutn))
                {
                    if (ri->bitsperchannel == 8)
                    {
                        result = Stbiconvertformat((byte*) result, p.S.Imgoutn, reqcomp, p.S.Imgx, p.S.Imgy);
                    }
                    else
                    {
                        result = Stbiconvertformat16((ushort*) result, p.S.Imgoutn, reqcomp, p.S.Imgx, p.S.Imgy);
                    }

                    p.S.Imgoutn = reqcomp;
                    if (result == null)
                    {
                        return result;
                    }
                }

                *x = (int) p.S.Imgx;
                *y = (int) p.S.Imgy;
                if (n != null)
                {
                    *n = p.S.Imgn;
                }
            }

            CRuntime.Free((void*)p.@out);
            p.@out = IntPtr.Zero;
            CRuntime.Free((void*)p.Expanded);
            p.Expanded = IntPtr.Zero;
            CRuntime.Free((void*)p.Idata);
            p.Idata = IntPtr.Zero;
            return result;
        }

        /// <summary>
        ///     Stbis the png info raw using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <returns>The int</returns>
        public static int Stbipnginforaw(Stbipng p, ref int x, ref int y, ref int comp)
        {
            if (Stbiparsepngfile(p, StbiscaNheader, 0) == 0)
            {
                Stbirewind(p.S);
                return 0;
            }
        
            x = (int)p.S.Imgx;
            y = (int)p.S.Imgy;
            comp = p.S.Imgn;
        
            return 1;
        }
    }
}