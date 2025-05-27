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

using Alis.Core.Graphic.Stb.Hebron.Runtime;

namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The stb image class
    /// </summary>
    partial class StbImage
    {
        /// <summary>
        ///     The stbi none
        /// </summary>
        public const int StbiFNone = 0;

        /// <summary>
        ///     The stbi sub
        /// </summary>
        public const int StbiFSub = 1;

        /// <summary>
        ///     The stbi up
        /// </summary>
        public const int StbiFUp = 2;

        /// <summary>
        ///     The stbi avg
        /// </summary>
        public const int StbiFAvg = 3;

        /// <summary>
        ///     The stbi paeth
        /// </summary>
        public const int StbiFPaeth = 4;

        /// <summary>
        ///     The stbi avg first
        /// </summary>
        public const int StbiFAvgFirst = 5;

        /// <summary>
        ///     The stbi sub
        /// </summary>
        public static byte[] FirstRowFilter =
            {StbiFNone, StbiFSub, StbiFNone, StbiFAvgFirst, StbiFSub};

        /// <summary>
        ///     The stbi check png header png sig
        /// </summary>
        public static byte[] StbiCheckPngHeaderPngSig = {137, 80, 78, 71, 13, 10, 26, 10};

        /// <summary>
        ///     The stbi depth scale table
        /// </summary>
        public static byte[] StbiDepthScaleTable = {0, 0xff, 0x55, 0, 0x11, 0, 0, 0, 0x01};

        /// <summary>
        ///     Stbis the png test using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The </returns>
        public static int stbi__png_test(StbiContext s)
        {
            int r = 0;
            r = stbi__check_png_header(s);
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
        /// <param name="reqComp">The req comp</param>
        /// <param name="ri">The ri</param>
        /// <returns>The void</returns>
        public static void* stbi__png_load(StbiContext s, int* x, int* y, int* comp, int reqComp,
            StbiResultInfo* ri)
        {
            StbiPng p = new StbiPng();
            p.S = s;
            return stbi__do_png(p, x, y, comp, reqComp, ri);
        }

        /// <summary>
        ///     Stbis the png info using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <returns>The int</returns>
        public static int stbi__png_info(StbiContext s, int* x, int* y, int* comp)
        {
            StbiPng p = new StbiPng();
            p.S = s;
            return stbi__png_info_raw(p, x, y, comp);
        }

        /// <summary>
        ///     Stbis the png is 16 using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The int</returns>
        public static int stbi__png_is16(StbiContext s)
        {
            StbiPng p = new StbiPng();
            p.S = s;
            if (stbi__png_info_raw(p, null, null, null) == 0)
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
        public static StbiPngchunk stbi__get_chunk_header(StbiContext s)
        {
            StbiPngchunk c = new StbiPngchunk();
            c.length = Stbiget32Be(s);
            c.type = Stbiget32Be(s);
            return c;
        }

        /// <summary>
        ///     Stbis the check png header using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The int</returns>
        public static int stbi__check_png_header(StbiContext s)
        {
            int i = 0;
            for (i = 0; i < 8; ++i)
            {
                if (stbi__get8(s) != StbiCheckPngHeaderPngSig[i])
                {
                    return stbi__err("bad png sig");
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
        public static int stbi__paeth(int a, int b, int c)
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
        /// <param name="imgN">The img</param>
        public static void stbi__create_png_alpha_expand8(byte* dest, byte* src, uint x, int imgN)
        {
            int i = 0;
            if (imgN == 1)
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
        /// <param name="rawLen">The raw len</param>
        /// <param name="outN">The out</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="depth">The depth</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        public static int stbi__create_png_image_raw(StbiPng a, byte* raw, uint rawLen, int outN, uint x, uint y,
            int depth, int color)
        {
            int bytes = depth == 16 ? 2 : 1;
            StbiContext s = a.S;
            uint i = 0;
            uint j = 0;
            uint stride = (uint) (x * outN * bytes);
            uint imgLen = 0;
            uint imgWidthBytes = 0;
            byte* filterBuf;
            int allOk = 1;
            int k = 0;
            int imgN = s.ImgN;
            int outputBytes = outN * bytes;
            int filterBytes = imgN * bytes;
            int width = (int) x;
            a.Out = (byte*) Stbimallocmad3((int) x, (int) y, outputBytes, 0);
            if (a.Out == null)
            {
                return stbi__err("outofmem");
            }

            if (Stbimad3Sizesvalid(imgN, (int) x, depth, 7) == 0)
            {
                return stbi__err("too large");
            }

            imgWidthBytes = (uint) ((imgN * x * depth + 7) >> 3);
            if (Stbimad2Sizesvalid((int) imgWidthBytes, (int) y, (int) imgWidthBytes) == 0)
            {
                return stbi__err("too large");
            }

            imgLen = (imgWidthBytes + 1) * y;
            if (rawLen < imgLen)
            {
                return stbi__err("not enough pixels");
            }

            filterBuf = (byte*) stbi__malloc_mad2((int) imgWidthBytes, 2, 0);
            if (filterBuf == null)
            {
                return stbi__err("outofmem");
            }

            if (depth < 8)
            {
                filterBytes = 1;
                width = (int) imgWidthBytes;
            }

            for (j = 0; j < y; ++j)
            {
                byte* cur = filterBuf + (j & 1) * imgWidthBytes;
                byte* prior = filterBuf + (~j & 1) * imgWidthBytes;
                byte* dest = a.Out + stride * j;
                int nk = width * filterBytes;
                int filter = *raw++;
                if (filter > 4)
                {
                    allOk = stbi__err("invalid filter");
                    break;
                }

                if (j == 0)
                {
                    filter = FirstRowFilter[filter];
                }

                switch (filter)
                {
                    case StbiFNone:
                        CRuntime.Memcpy(cur, raw, (ulong) nk);
                        break;
                    case StbiFSub:
                        CRuntime.Memcpy(cur, raw, (ulong) filterBytes);
                        for (k = filterBytes; k < nk; ++k)
                        {
                            cur[k] = (byte) ((raw[k] + cur[k - filterBytes]) & 255);
                        }

                        break;
                    case StbiFUp:
                        for (k = 0; k < nk; ++k)
                        {
                            cur[k] = (byte) ((raw[k] + prior[k]) & 255);
                        }

                        break;
                    case StbiFAvg:
                        for (k = 0; k < filterBytes; ++k)
                        {
                            cur[k] = (byte) ((raw[k] + (prior[k] >> 1)) & 255);
                        }

                        for (k = filterBytes; k < nk; ++k)
                        {
                            cur[k] = (byte) ((raw[k] + ((prior[k] + cur[k - filterBytes]) >> 1)) & 255);
                        }

                        break;
                    case StbiFPaeth:
                        for (k = 0; k < filterBytes; ++k)
                        {
                            cur[k] = (byte) ((raw[k] + prior[k]) & 255);
                        }

                        for (k = filterBytes; k < nk; ++k)
                        {
                            cur[k] = (byte) ((raw[k] + stbi__paeth(cur[k - filterBytes], prior[k],
                                prior[k - filterBytes])) & 255);
                        }

                        break;
                    case StbiFAvgFirst:
                        CRuntime.Memcpy(cur, raw, (ulong) filterBytes);
                        for (k = filterBytes; k < nk; ++k)
                        {
                            cur[k] = (byte) ((raw[k] + (cur[k - filterBytes] >> 1)) & 255);
                        }

                        break;
                }

                raw += nk;
                if (depth < 8)
                {
                    byte scale = (byte) (color == 0 ? StbiDepthScaleTable[depth] : 1);
                    byte* @in = cur;
                    byte* @out = dest;
                    byte inb = 0;
                    uint nsmp = (uint) (x * imgN);
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

                    if (imgN != outN)
                    {
                        stbi__create_png_alpha_expand8(dest, dest, x, imgN);
                    }
                }
                else if (depth == 8)
                {
                    if (imgN == outN)
                    {
                        CRuntime.Memcpy(dest, cur, (ulong) (x * imgN));
                    }
                    else
                    {
                        stbi__create_png_alpha_expand8(dest, cur, x, imgN);
                    }
                }
                else if (depth == 16)
                {
                    ushort* dest16 = (ushort*) dest;
                    uint nsmp = (uint) (x * imgN);
                    if (imgN == outN)
                    {
                        for (i = 0; i < nsmp; ++i, ++dest16, cur += 2)
                        {
                            *dest16 = (ushort) ((cur[0] << 8) | cur[1]);
                        }
                    }
                    else
                    {
                        if (imgN == 1)
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

            CRuntime.Free(filterBuf);
            if (allOk == 0)
            {
                return 0;
            }

            return 1;
        }

        /// <summary>
        ///     Stbis the create png image using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="imageData">The image data</param>
        /// <param name="imageDataLen">The image data len</param>
        /// <param name="outN">The out</param>
        /// <param name="depth">The depth</param>
        /// <param name="color">The color</param>
        /// <param name="interlaced">The interlaced</param>
        /// <returns>The int</returns>
        public static int stbi__create_png_image(StbiPng a, byte* imageData, uint imageDataLen, int outN,
            int depth, int color, int interlaced)
        {
            int bytes = depth == 16 ? 2 : 1;
            int outBytes = outN * bytes;
            byte* final;
            int p = 0;
            if (interlaced == 0)
            {
                return stbi__create_png_image_raw(a, imageData, imageDataLen, outN, a.S.ImgX, a.S.ImgY, depth,
                    color);
            }

            final = (byte*) Stbimallocmad3((int) a.S.ImgX, (int) a.S.ImgY, outBytes, 0);
            if (final == null)
            {
                return stbi__err("outofmem");
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
                x = (int) ((a.S.ImgX - xorig[p] + xspc[p] - 1) / xspc[p]);
                y = (int) ((a.S.ImgY - yorig[p] + yspc[p] - 1) / yspc[p]);
                if ((x != 0) && (y != 0))
                {
                    uint imgLen = (uint) ((((a.S.ImgN * x * depth + 7) >> 3) + 1) * y);
                    if (stbi__create_png_image_raw(a, imageData, imageDataLen, outN, (uint) x, (uint) y, depth,
                            color) == 0)
                    {
                        CRuntime.Free(final);
                        return 0;
                    }

                    for (j = 0; j < y; ++j)
                    for (i = 0; i < x; ++i)
                    {
                        int outY = j * yspc[p] + yorig[p];
                        int outX = i * xspc[p] + xorig[p];
                        CRuntime.Memcpy(final + outY * a.S.ImgX * outBytes + outX * outBytes,
                            a.Out + (j * x + i) * outBytes, (ulong) outBytes);
                    }

                    CRuntime.Free(a.Out);
                    imageData += imgLen;
                    imageDataLen -= imgLen;
                }
            }

            a.Out = final;
            return 1;
        }

        /// <summary>
        ///     Stbis the compute transparency using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <param name="tc">The tc</param>
        /// <param name="outN">The out</param>
        /// <returns>The int</returns>
        public static int stbi__compute_transparency(StbiPng z, byte* tc, int outN)
        {
            StbiContext s = z.S;
            uint i = 0;
            uint pixelCount = s.ImgX * s.ImgY;
            byte* p = z.Out;
            if (outN == 2)
            {
                for (i = 0; i < pixelCount; ++i)
                {
                    p[1] = (byte) (p[0] == tc[0] ? 0 : 255);
                    p += 2;
                }
            }
            else
            {
                for (i = 0; i < pixelCount; ++i)
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
        /// <param name="outN">The out</param>
        /// <returns>The int</returns>
        public static int stbi__compute_transparency16(StbiPng z, ushort* tc, int outN)
        {
            StbiContext s = z.S;
            uint i = 0;
            uint pixelCount = s.ImgX * s.ImgY;
            ushort* p = (ushort*) z.Out;
            if (outN == 2)
            {
                for (i = 0; i < pixelCount; ++i)
                {
                    p[1] = (ushort) (p[0] == tc[0] ? 0 : 65535);
                    p += 2;
                }
            }
            else
            {
                for (i = 0; i < pixelCount; ++i)
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
        /// <param name="palImgN">The pal img</param>
        /// <returns>The int</returns>
        public static int stbi__expand_png_palette(StbiPng a, byte* palette, int len, int palImgN)
        {
            uint i = 0;
            uint pixelCount = a.S.ImgX * a.S.ImgY;
            byte* p;
            byte* tempOut;
            byte* orig = a.Out;
            p = (byte*) stbi__malloc_mad2((int) pixelCount, palImgN, 0);
            if (p == null)
            {
                return stbi__err("outofmem");
            }

            tempOut = p;
            if (palImgN == 3)
            {
                for (i = 0; i < pixelCount; ++i)
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
                for (i = 0; i < pixelCount; ++i)
                {
                    int n = orig[i] * 4;
                    p[0] = palette[n];
                    p[1] = palette[n + 1];
                    p[2] = palette[n + 2];
                    p[3] = palette[n + 3];
                    p += 4;
                }
            }

            CRuntime.Free(a.Out);
            a.Out = tempOut;
            return 1;
        }

        /// <summary>
        ///     Stbis the de iphone using the specified z
        /// </summary>
        /// <param name="z">The </param>
        public static void stbi__de_iphone(StbiPng z)
        {
            StbiContext s = z.S;
            uint i = 0;
            uint pixelCount = s.ImgX * s.ImgY;
            byte* p = z.Out;
            if (s.ImgOutN == 3)
            {
                for (i = 0; i < pixelCount; ++i)
                {
                    byte t = p[0];
                    p[0] = p[2];
                    p[2] = t;
                    p += 3;
                }
            }
            else
            {
                if ((StbiUnpremultiplyOnLoadSet != 0
                        ? StbiUnpremultiplyOnLoadLocal
                        : StbiUnpremultiplyOnLoadGlobal) != 0)
                {
                    for (i = 0; i < pixelCount; ++i)
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
                    for (i = 0; i < pixelCount; ++i)
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
        /// <param name="reqComp">The req comp</param>
        /// <returns>The int</returns>
        public static int stbi__parse_png_file(StbiPng z, int scan, int reqComp)
        {
            byte* palette = stackalloc byte[1024];
            byte palImgN = 0;
            byte hasTrans = 0;
            byte* tc = stackalloc byte[] {0, 0, 0};
            ushort* tc16 = stackalloc ushort[3];
            uint ioff = 0;
            uint idataLimit = 0;
            uint i = 0;
            uint palLen = 0;
            int first = 1;
            int k = 0;
            int interlace = 0;
            int color = 0;
            int isIphone = 0;
            StbiContext s = z.S;
            z.Expanded = null;
            z.Idata = null;
            z.Out = null;
            if (stbi__check_png_header(s) == 0)
            {
                return 0;
            }

            if (scan == StbiScanType)
            {
                return 1;
            }

            for (;;)
            {
                StbiPngchunk c = stbi__get_chunk_header(s);
                switch (c.type)
                {
                    case ((uint) 67 << 24) + ((uint) 103 << 16) + ((uint) 66 << 8) + 73:
                        isIphone = 1;
                        stbi__skip(s, (int) c.length);
                        break;
                    case ((uint) 73 << 24) + ((uint) 72 << 16) + ((uint) 68 << 8) + 82:
                    {
                        int comp = 0;
                        int filter = 0;
                        if (first == 0)
                        {
                            return stbi__err("multiple IHDR");
                        }

                        first = 0;
                        if (c.length != 13)
                        {
                            return stbi__err("bad IHDR len");
                        }

                        s.ImgX = Stbiget32Be(s);
                        s.ImgY = Stbiget32Be(s);
                        if (s.ImgY > 1 << 24)
                        {
                            return stbi__err("too large");
                        }

                        if (s.ImgX > 1 << 24)
                        {
                            return stbi__err("too large");
                        }

                        z.Depth = stbi__get8(s);
                        if ((z.Depth != 1) && (z.Depth != 2) && (z.Depth != 4) && (z.Depth != 8) && (z.Depth != 16))
                        {
                            return stbi__err("1/2/4/8/16-bit only");
                        }

                        color = stbi__get8(s);
                        if (color > 6)
                        {
                            return stbi__err("bad ctype");
                        }

                        if ((color == 3) && (z.Depth == 16))
                        {
                            return stbi__err("bad ctype");
                        }

                        if (color == 3)
                        {
                            palImgN = 3;
                        }
                        else if ((color & 1) != 0)
                        {
                            return stbi__err("bad ctype");
                        }

                        comp = stbi__get8(s);
                        if (comp != 0)
                        {
                            return stbi__err("bad comp method");
                        }

                        filter = stbi__get8(s);
                        if (filter != 0)
                        {
                            return stbi__err("bad filter method");
                        }

                        interlace = stbi__get8(s);
                        if (interlace > 1)
                        {
                            return stbi__err("bad interlace method");
                        }

                        if (s.ImgX == 0 || s.ImgY == 0)
                        {
                            return stbi__err("0-pixel image");
                        }

                        if (palImgN == 0)
                        {
                            s.ImgN = ((color & 2) != 0 ? 3 : 1) + ((color & 4) != 0 ? 1 : 0);
                            if ((1 << 30) / s.ImgX / s.ImgN < s.ImgY)
                            {
                                return stbi__err("too large");
                            }
                        }
                        else
                        {
                            s.ImgN = 1;
                            if ((1 << 30) / s.ImgX / 4 < s.ImgY)
                            {
                                return stbi__err("too large");
                            }
                        }

                        break;
                    }

                    case ((uint) 80 << 24) + ((uint) 76 << 16) + ((uint) 84 << 8) + 69:
                    {
                        if (first != 0)
                        {
                            return stbi__err("first not IHDR");
                        }

                        if (c.length > 256 * 3)
                        {
                            return stbi__err("invalid PLTE");
                        }

                        palLen = c.length / 3;
                        if (palLen * 3 != c.length)
                        {
                            return stbi__err("invalid PLTE");
                        }

                        for (i = 0; i < palLen; ++i)
                        {
                            palette[i * 4 + 0] = stbi__get8(s);
                            palette[i * 4 + 1] = stbi__get8(s);
                            palette[i * 4 + 2] = stbi__get8(s);
                            palette[i * 4 + 3] = 255;
                        }

                        break;
                    }

                    case ((uint) 116 << 24) + ((uint) 82 << 16) + ((uint) 78 << 8) + 83:
                    {
                        if (first != 0)
                        {
                            return stbi__err("first not IHDR");
                        }

                        if (z.Idata != null)
                        {
                            return stbi__err("tRNS after IDAT");
                        }

                        if (palImgN != 0)
                        {
                            if (scan == StbiScanHeader)
                            {
                                s.ImgN = 4;
                                return 1;
                            }

                            if (palLen == 0)
                            {
                                return stbi__err("tRNS before PLTE");
                            }

                            if (c.length > palLen)
                            {
                                return stbi__err("bad tRNS len");
                            }

                            palImgN = 4;
                            for (i = 0; i < c.length; ++i)
                            {
                                palette[i * 4 + 3] = stbi__get8(s);
                            }
                        }
                        else
                        {
                            if ((s.ImgN & 1) == 0)
                            {
                                return stbi__err("tRNS with alpha");
                            }

                            if (c.length != (uint) s.ImgN * 2)
                            {
                                return stbi__err("bad tRNS len");
                            }

                            hasTrans = 1;
                            if (scan == StbiScanHeader)
                            {
                                ++s.ImgN;
                                return 1;
                            }

                            if (z.Depth == 16)
                            {
                                for (k = 0; (k < s.ImgN) && (k < 3); ++k)
                                {
                                    tc16[k] = (ushort) Stbiget16Be(s);
                                }
                            }
                            else
                            {
                                for (k = 0; (k < s.ImgN) && (k < 3); ++k)
                                {
                                    tc[k] = (byte) ((byte) (Stbiget16Be(s) & 255) * StbiDepthScaleTable[z.Depth]);
                                }
                            }
                        }

                        break;
                    }

                    case ((uint) 73 << 24) + ((uint) 68 << 16) + ((uint) 65 << 8) + 84:
                    {
                        if (first != 0)
                        {
                            return stbi__err("first not IHDR");
                        }

                        if ((palImgN != 0) && (palLen == 0))
                        {
                            return stbi__err("no PLTE");
                        }

                        if (scan == StbiScanHeader)
                        {
                            if (palImgN != 0)
                            {
                                s.ImgN = palImgN;
                            }

                            return 1;
                        }

                        if (c.length > 1u << 30)
                        {
                            return stbi__err("IDAT size limit");
                        }

                        if ((int) (ioff + c.length) < (int) ioff)
                        {
                            return 0;
                        }

                        if (ioff + c.length > idataLimit)
                        {
                            uint idataLimitOld = idataLimit;
                            byte* p;
                            if (idataLimit == 0)
                            {
                                idataLimit = c.length > 4096 ? c.length : 4096;
                            }

                            while (ioff + c.length > idataLimit)
                            {
                                idataLimit *= 2;
                            }

                            p = (byte*) CRuntime.Realloc(z.Idata, (ulong) idataLimit);
                            if (p == null)
                            {
                                return stbi__err("outofmem");
                            }

                            z.Idata = p;
                        }

                        if (stbi__getn(s, z.Idata + ioff, (int) c.length) == 0)
                        {
                            return stbi__err("outofdata");
                        }

                        ioff += c.length;
                        break;
                    }

                    case ((uint) 73 << 24) + ((uint) 69 << 16) + ((uint) 78 << 8) + 68:
                    {
                        uint rawLen = 0;
                        if (first != 0)
                        {
                            return stbi__err("first not IHDR");
                        }

                        if (scan != StbiScanLoad)
                        {
                            return 1;
                        }

                        if (z.Idata == null)
                        {
                            return stbi__err("no IDAT");
                        }

                        if (z.Expanded == null)
                        {
                            return 0;
                        }

                        CRuntime.Free(z.Idata);
                        z.Idata = null;
                        if (((reqComp == s.ImgN + 1) && (reqComp != 3) && (palImgN == 0)) || hasTrans != 0)
                        {
                            s.ImgOutN = s.ImgN + 1;
                        }
                        else
                        {
                            s.ImgOutN = s.ImgN;
                        }

                        if (stbi__create_png_image(z, z.Expanded, rawLen, s.ImgOutN, z.Depth, color, interlace) == 0)
                        {
                            return 0;
                        }

                        if (hasTrans != 0)
                        {
                            if (z.Depth == 16)
                            {
                                if (stbi__compute_transparency16(z, tc16, s.ImgOutN) == 0)
                                {
                                    return 0;
                                }
                            }
                            else
                            {
                                if (stbi__compute_transparency(z, tc, s.ImgOutN) == 0)
                                {
                                    return 0;
                                }
                            }
                        }

                        if ((isIphone != 0) &&
                            ((StbiDeIphoneFlagSet != 0
                                ? StbiDeIphoneFlagLocal
                                : StbiDeIphoneFlagGlobal) != 0) && (s.ImgOutN > 2))
                        {
                            stbi__de_iphone(z);
                        }

                        if (palImgN != 0)
                        {
                            s.ImgN = palImgN;
                            s.ImgOutN = palImgN;
                            if (reqComp >= 3)
                            {
                                s.ImgOutN = reqComp;
                            }

                            if (stbi__expand_png_palette(z, palette, (int) palLen, s.ImgOutN) == 0)
                            {
                                return 0;
                            }
                        }
                        else if (hasTrans != 0)
                        {
                            ++s.ImgN;
                        }

                        CRuntime.Free(z.Expanded);
                        z.Expanded = null;
                        Stbiget32Be(s);
                        return 1;
                    }

                    default:
                        if (first != 0)
                        {
                            return stbi__err("first not IHDR");
                        }

                        if ((c.type & (1 << 29)) == 0)
                        {
                            StbiParsePngFileInvalidChunk[0] = (char) ((c.type >> 24) & 255);
                            StbiParsePngFileInvalidChunk[1] = (char) ((c.type >> 16) & 255);
                            StbiParsePngFileInvalidChunk[2] = (char) ((c.type >> 8) & 255);
                            StbiParsePngFileInvalidChunk[3] = (char) ((c.type >> 0) & 255);
                            return stbi__err(new string(StbiParsePngFileInvalidChunk));
                        }

                        stbi__skip(s, (int) c.length);
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
        /// <param name="reqComp">The req comp</param>
        /// <param name="ri">The ri</param>
        /// <returns>The result</returns>
        public static void* stbi__do_png(StbiPng p, int* x, int* y, int* n, int reqComp, StbiResultInfo* ri)
        {
            void* result = null;
            if (reqComp < 0 || reqComp > 4)
            {
                return (byte*) (ulong) (stbi__err("bad req_comp") != 0 ? 0 : 0);
            }

            if (stbi__parse_png_file(p, StbiScanLoad, reqComp) != 0)
            {
                if (p.Depth <= 8)
                {
                    ri->bits_per_channel = 8;
                }
                else if (p.Depth == 16)
                {
                    ri->bits_per_channel = 16;
                }
                else
                {
                    return (byte*) (ulong) (stbi__err("bad bits_per_channel") != 0 ? 0 : 0);
                }

                result = p.Out;
                p.Out = null;
                if ((reqComp != 0) && (reqComp != p.S.ImgOutN))
                {
                    if (ri->bits_per_channel == 8)
                    {
                        result = Stbiconvertformat((byte*) result, p.S.ImgOutN, reqComp, p.S.ImgX, p.S.ImgY);
                    }
                    else
                    {
                        result = Stbiconvertformat16((ushort*) result, p.S.ImgOutN, reqComp, p.S.ImgX, p.S.ImgY);
                    }

                    p.S.ImgOutN = reqComp;
                    if (result == null)
                    {
                        return result;
                    }
                }

                *x = (int) p.S.ImgX;
                *y = (int) p.S.ImgY;
                if (n != null)
                {
                    *n = p.S.ImgN;
                }
            }

            CRuntime.Free(p.Out);
            p.Out = null;
            CRuntime.Free(p.Expanded);
            p.Expanded = null;
            CRuntime.Free(p.Idata);
            p.Idata = null;
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
        public static int stbi__png_info_raw(StbiPng p, int* x, int* y, int* comp)
        {
            if (stbi__parse_png_file(p, StbiScanHeader, 0) == 0)
            {
                Stbirewind(p.S);
                return 0;
            }

            if (x != null)
            {
                *x = (int) p.S.ImgX;
            }

            if (y != null)
            {
                *y = (int) p.S.ImgY;
            }

            if (comp != null)
            {
                *comp = p.S.ImgN;
            }

            return 1;
        }
    }
}