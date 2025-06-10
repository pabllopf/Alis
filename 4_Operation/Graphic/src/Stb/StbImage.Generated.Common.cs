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

using Alis.Core.Graphic.Stb.Hebron.Runtime;

namespace Alis.Core.Graphic.Stb
{
    /// <summary>
    ///     The stb image class
    /// </summary>
    unsafe partial class StbImage
    {
        /// <summary>
        ///     The stbi default
        /// </summary>
        public const int StbIdefault = 0;

        /// <summary>
        ///     The stbi grey
        /// </summary>
        public const int StbIgrey = 1;

        /// <summary>
        ///     The stbi grey alpha
        /// </summary>
        public const int StbIgreyalpha = 2;

        /// <summary>
        ///     The stbi rgb
        /// </summary>
        public const int StbIrgb = 3;

        /// <summary>
        ///     The stbi rgb alpha
        /// </summary>
        public const int StbIrgbalpha = 4;

        /// <summary>
        ///     The stbi order rgb
        /// </summary>
        public const int Stbiorderrgb = 0;

        /// <summary>
        ///     The stbi order bgr
        /// </summary>
        public const int Stbiorderbgr = 1;

        /// <summary>
        ///     The stbi scan load
        /// </summary>
        public const int StbiscaNload = 0;

        /// <summary>
        ///     The stbi scan type
        /// </summary>
        public const int StbiscaNtype = 1;

        /// <summary>
        ///     The stbi scan header
        /// </summary>
        public const int StbiscaNheader = 2;

        /// <summary>
        ///     The stbi vertically flip on load global
        /// </summary>
        public static int Stbiverticallyfliponloadglobal;

        /// <summary>
        ///     The stbi vertically flip on load local
        /// </summary>
        public static int Stbiverticallyfliponloadlocal;

        /// <summary>
        ///     The stbi vertically flip on load set
        /// </summary>
        public static int Stbiverticallyfliponloadset;

        /// <summary>
        ///     The stbi l2h gamma
        /// </summary>
        public static float Stbil2Hgamma = 2.2f;

        /// <summary>
        ///     The stbi l2h scale
        /// </summary>
        public static float Stbil2Hscale = 1.0f;

        /// <summary>
        ///     The stbi h2l gamma
        /// </summary>
        public static float Stbih2Lgammai = 1.0f / 2.2f;

        /// <summary>
        ///     The stbi h2l scale
        /// </summary>
        public static float Stbih2Lscalei = 1.0f;

        /// <summary>
        ///     The stbi unpremultiply on load global
        /// </summary>
        public static int Stbiunpremultiplyonloadglobal;

        /// <summary>
        ///     The stbi de iphone flag global
        /// </summary>
        public static int Stbideiphoneflagglobal;

        /// <summary>
        ///     The stbi unpremultiply on load local
        /// </summary>
        public static int Stbiunpremultiplyonloadlocal;

        /// <summary>
        ///     The stbi unpremultiply on load set
        /// </summary>
        public static int Stbiunpremultiplyonloadset;

        /// <summary>
        ///     The stbi de iphone flag local
        /// </summary>
        public static int Stbideiphoneflaglocal;

        /// <summary>
        ///     The stbi de iphone flag set
        /// </summary>
        public static int Stbideiphoneflagset;

        /// <summary>
        ///     The stbi process marker tag
        /// </summary>
        public static byte[] Stbiprocessmarkertag = {65, 100, 111, 98, 101, 0};

        /// <summary>
        ///     The stbi process frame header rgb
        /// </summary>
        public static byte[] Stbiprocessframeheaderrgb = {82, 71, 66};

        /// <summary>
        ///     The stbi compute huffman codes length dezigzag
        /// </summary>
        public static byte[] Stbicomputehuffmancodeslengthdezigzag =
            {16, 17, 18, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 14, 1, 15};

        /// <summary>
        ///     The stbi shiftsigned mul table
        /// </summary>
        public static int[] Stbishiftsignedmultable = {0, 0xff, 0x55, 0x49, 0x11, 0x21, 0x41, 0x81, 0x01};

        /// <summary>
        ///     The stbi shiftsigned shift table
        /// </summary>
        public static int[] Stbishiftsignedshifttable = {0, 0, 0, 1, 0, 2, 4, 6, 0};

        /// <summary>
        ///     Stbis the hdr to ldr gamma using the specified gamma
        /// </summary>
        /// <param name="gamma">The gamma</param>
        public static void Stbihdrtoldrgamma(float gamma)
        {
            Stbih2Lgammai = 1 / gamma;
        }

        /// <summary>
        ///     Stbis the hdr to ldr scale using the specified scale
        /// </summary>
        /// <param name="scale">The scale</param>
        public static void Stbihdrtoldrscale(float scale)
        {
            Stbih2Lscalei = 1 / scale;
        }

        /// <summary>
        ///     Stbis the ldr to hdr gamma using the specified gamma
        /// </summary>
        /// <param name="gamma">The gamma</param>
        public static void Stbildrtohdrgamma(float gamma)
        {
            Stbil2Hgamma = gamma;
        }

        /// <summary>
        ///     Stbis the ldr to hdr scale using the specified scale
        /// </summary>
        /// <param name="scale">The scale</param>
        public static void Stbildrtohdrscale(float scale)
        {
            Stbil2Hscale = scale;
        }

        /// <summary>
        ///     Stbis the set unpremultiply on load using the specified flag true if should unpremultiply
        /// </summary>
        /// <param name="flagtrueifshouldunpremultiply">The flag true if should unpremultiply</param>
        public static void Stbisetunpremultiplyonload(int flagtrueifshouldunpremultiply)
        {
            Stbiunpremultiplyonloadglobal = flagtrueifshouldunpremultiply;
        }

        /// <summary>
        ///     Stbis the convert iphone png to rgb using the specified flag true if should convert
        /// </summary>
        /// <param name="flagtrueifshouldconvert">The flag true if should convert</param>
        public static void Stbiconvertiphonepngtorgb(int flagtrueifshouldconvert)
        {
            Stbideiphoneflagglobal = flagtrueifshouldconvert;
        }

        /// <summary>
        ///     Stbis the set flip vertically on load using the specified flag true if should flip
        /// </summary>
        /// <param name="flagtrueifshouldflip">The flag true if should flip</param>
        public static void Stbisetflipverticallyonload(int flagtrueifshouldflip)
        {
            Stbiverticallyfliponloadglobal = flagtrueifshouldflip;
        }

        /// <summary>
        ///     Stbis the set unpremultiply on load thread using the specified flag true if should unpremultiply
        /// </summary>
        /// <param name="flagtrueifshouldunpremultiply">The flag true if should unpremultiply</param>
        public static void Stbisetunpremultiplyonloadthread(int flagtrueifshouldunpremultiply)
        {
            Stbiunpremultiplyonloadlocal = flagtrueifshouldunpremultiply;
            Stbiunpremultiplyonloadset = 1;
        }

        /// <summary>
        ///     Stbis the convert iphone png to rgb thread using the specified flag true if should convert
        /// </summary>
        /// <param name="flagtrueifshouldconvert">The flag true if should convert</param>
        public static void Stbiconvertiphonepngtorgbthread(int flagtrueifshouldconvert)
        {
            Stbideiphoneflaglocal = flagtrueifshouldconvert;
            Stbideiphoneflagset = 1;
        }

        /// <summary>
        ///     Stbis the set flip vertically on load thread using the specified flag true if should flip
        /// </summary>
        /// <param name="flagtrueifshouldflip">The flag true if should flip</param>
        public static void Stbisetflipverticallyonloadthread(int flagtrueifshouldflip)
        {
            Stbiverticallyfliponloadlocal = flagtrueifshouldflip;
            Stbiverticallyfliponloadset = 1;
        }

        /// <summary>
        ///     Stbis the malloc using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The void</returns>
        public static void* Stbimalloc(ulong size) => CRuntime.Malloc(size);

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
        public static void* Stbimallocmad2(int a, int b, int add)
        {
            if (Stbimad2Sizesvalid(a, b, add) == 0)
            {
                return null;
            }

            return Stbimalloc((ulong) (a * b + add));
        }

        /// <summary>
        ///     Stbis the malloc mad 3 using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="add">The add</param>
        /// <returns>The void</returns>
        public static void* Stbimallocmad3(int a, int b, int c, int add)
        {
            if (Stbimad3Sizesvalid(a, b, c, add) == 0)
            {
                return null;
            }

            return Stbimalloc((ulong) (a * b * c + add));
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
        public static void* Stbimallocmad4(int a, int b, int c, int d, int add)
        {
            if (Stbimad4Sizesvalid(a, b, c, d, add) == 0)
            {
                return null;
            }

            return Stbimalloc((ulong) (a * b * c * d + add));
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
        public static float* Stbildrtohdr(byte* data, int x, int y, int comp)
        {
            int i = 0;
            int k = 0;
            int n = 0;
            float* output;
            if (data == null)
            {
                return null;
            }

            output = (float*) Stbimallocmad4(x, y, comp, sizeof(float), 0);
            if (output == null)
            {
                CRuntime.Free(data);
                return (float*) (ulong) (Stbierr("outofmem") != 0 ? 0 : 0);
            }

            if ((comp & 1) != 0)
            {
                n = comp;
            }
            else
            {
                n = comp - 1;
            }

            for (i = 0; i < x * y; ++i)
            for (k = 0; k < n; ++k)
            {
                output[i * comp + k] =
                    (float) (CRuntime.Pow(data[i * comp + k] / 255.0f, Stbil2Hgamma) * Stbil2Hscale);
            }

            if (n < comp)
            {
                for (i = 0; i < x * y; ++i)
                {
                    output[i * comp + n] = data[i * comp + n] / 255.0f;
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
        /// <param name="reqcomp">The req comp</param>
        /// <param name="ri">The ri</param>
        /// <param name="bpc">The bpc</param>
        /// <returns>The void</returns>
        public static void* Stbiloadmain(Stbicontext s, int* x, int* y, int* comp, int reqcomp,
            Stbiresultinfo* ri, int bpc)
        {
            CRuntime.Memset(ri, 0, (ulong) sizeof(Stbiresultinfo));
            ri->bitsperchannel = 8;
            ri->channelorder = Stbiorderrgb;
            ri->numchannels = 0;
            if (Stbipngtest(s) != 0)
            {
                return Stbipngload(s, x, y, comp, reqcomp, ri);
            }

            if (Stbibmptest(s) != 0)
            {
                return Stbibmpload(s, x, y, comp, reqcomp, ri);
            }

            if (Stbijpegtest(s) != 0)
            {
                return Stbijpegload(s, x, y, comp, reqcomp, ri);
            }

            return (byte*) (ulong) (Stbierr("unknown image type") != 0 ? 0 : 0);
        }

        /// <summary>
        ///     Stbis the convert 16 to 8 using the specified orig
        /// </summary>
        /// <param name="orig">The orig</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="channels">The channels</param>
        /// <returns>The reduced</returns>
        public static byte* Stbiconvert16To8(ushort* orig, int w, int h, int channels)
        {
            int i = 0;
            int imglen = w * h * channels;
            byte* reduced;
            reduced = (byte*) Stbimalloc((ulong) imglen);
            if (reduced == null)
            {
                return (byte*) (ulong) (Stbierr("outofmem") != 0 ? 0 : 0);
            }

            for (i = 0; i < imglen; ++i)
            {
                reduced[i] = (byte) ((orig[i] >> 8) & 0xFF);
            }

            CRuntime.Free(orig);
            return reduced;
        }

        /// <summary>
        ///     Stbis the convert 8 to 16 using the specified orig
        /// </summary>
        /// <param name="orig">The orig</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="channels">The channels</param>
        /// <returns>The enlarged</returns>
        public static ushort* Stbiconvert8To16(byte* orig, int w, int h, int channels)
        {
            int i = 0;
            int imglen = w * h * channels;
            ushort* enlarged;
            enlarged = (ushort*) Stbimalloc((ulong) (imglen * 2));
            if (enlarged == null)
            {
                return (ushort*) (byte*) (ulong) (Stbierr("outofmem") != 0 ? 0 : 0);
            }

            for (i = 0; i < imglen; ++i)
            {
                enlarged[i] = (ushort) ((orig[i] << 8) + orig[i]);
            }

            CRuntime.Free(orig);
            return enlarged;
        }

        /// <summary>
        ///     Stbis the vertical flip using the specified image
        /// </summary>
        /// <param name="image">The image</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="bytesperpixel">The bytes per pixel</param>
        public static void Stbiverticalflip(void* image, int w, int h, int bytesperpixel)
        {
            int row = 0;
            int bytesperrow = w * bytesperpixel;
            byte* temp = stackalloc byte[2048];
            byte* bytes = (byte*) image;
            for (row = 0; row < h >> 1; row++)
            {
                byte* row0 = bytes + row * bytesperrow;
                byte* row1 = bytes + (h - row - 1) * bytesperrow;
                ulong bytesleft = (ulong) bytesperrow;
                while (bytesleft != 0)
                {
                    ulong bytescopy = bytesleft < 2048 * sizeof(byte) ? bytesleft : 2048 * sizeof(byte);
                    CRuntime.Memcpy(temp, row0, bytescopy);
                    CRuntime.Memcpy(row0, row1, bytescopy);
                    CRuntime.Memcpy(row1, temp, bytescopy);
                    row0 += bytescopy;
                    row1 += bytescopy;
                    bytesleft -= bytescopy;
                }
            }
        }

        /// <summary>
        ///     Stbis the vertical flip slices using the specified image
        /// </summary>
        /// <param name="image">The image</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="z">The </param>
        /// <param name="bytesperpixel">The bytes per pixel</param>
        public static void Stbiverticalflipslices(void* image, int w, int h, int z, int bytesperpixel)
        {
            int slice = 0;
            int slicesize = w * h * bytesperpixel;
            byte* bytes = (byte*) image;
            for (slice = 0; slice < z; ++slice)
            {
                Stbiverticalflip(bytes, w, h, bytesperpixel);
                bytes += slicesize;
            }
        }

        /// <summary>
        ///     Stbis the load and postprocess 8bit using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <param name="reqcomp">The req comp</param>
        /// <returns>The byte</returns>
        public static byte* Stbiloadandpostprocess8Bit(Stbicontext s, int* x, int* y, int* comp, int reqcomp)
        {
            Stbiresultinfo ri = new Stbiresultinfo();
            void* result = Stbiloadmain(s, x, y, comp, reqcomp, &ri, 8);
            if (result == null)
            {
                return null;
            }

            if (ri.bitsperchannel != 8)
            {
                result = Stbiconvert16To8((ushort*) result, *x, *y, reqcomp == 0 ? *comp : reqcomp);
                ri.bitsperchannel = 8;
            }

            if ((Stbiverticallyfliponloadset != 0
                    ? Stbiverticallyfliponloadlocal
                    : Stbiverticallyfliponloadglobal) != 0)
            {
                int channels = reqcomp != 0 ? reqcomp : *comp;
                Stbiverticalflip(result, *x, *y, channels * sizeof(byte));
            }

            return (byte*) result;
        }

        /// <summary>
        ///     Stbis the load and postprocess 16bit using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <param name="reqcomp">The req comp</param>
        /// <returns>The ushort</returns>
        public static ushort* Stbiloadandpostprocess16Bit(Stbicontext s, int* x, int* y, int* comp, int reqcomp)
        {
            Stbiresultinfo ri = new Stbiresultinfo();
            void* result = Stbiloadmain(s, x, y, comp, reqcomp, &ri, 16);
            if (result == null)
            {
                return null;
            }

            if (ri.bitsperchannel != 16)
            {
                result = Stbiconvert8To16((byte*) result, *x, *y, reqcomp == 0 ? *comp : reqcomp);
                ri.bitsperchannel = 16;
            }

            if ((Stbiverticallyfliponloadset != 0
                    ? Stbiverticallyfliponloadlocal
                    : Stbiverticallyfliponloadglobal) != 0)
            {
                int channels = reqcomp != 0 ? reqcomp : *comp;
                Stbiverticalflip(result, *x, *y, channels * sizeof(ushort));
            }

            return (ushort*) result;
        }

        /// <summary>
        ///     Stbis the float postprocess using the specified result
        /// </summary>
        /// <param name="result">The result</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <param name="reqcomp">The req comp</param>
        public static void Stbifloatpostprocess(float* result, int* x, int* y, int* comp, int reqcomp)
        {
            if (((Stbiverticallyfliponloadset != 0
                    ? Stbiverticallyfliponloadlocal
                    : Stbiverticallyfliponloadglobal) != 0) && (result != null))
            {
                int channels = reqcomp != 0 ? reqcomp : *comp;
                Stbiverticalflip(result, *x, *y, channels * sizeof(float));
            }
        }

        /// <summary>
        ///     Stbis the loadf main using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <param name="reqcomp">The req comp</param>
        /// <returns>The float</returns>
        public static float* Stbiloadfmain(Stbicontext s, int* x, int* y, int* comp, int reqcomp)
        {
            byte* data;
            data = Stbiloadandpostprocess8Bit(s, x, y, comp, reqcomp);
            if (data != null)
            {
                return Stbildrtohdr(data, *x, *y, reqcomp != 0 ? reqcomp : *comp);
            }

            return (float*) (ulong) (Stbierr("unknown image type") != 0 ? 0 : 0);
        }

        /// <summary>
        ///     Stbis the get 16be using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The int</returns>
        public static int Stbiget16Be(Stbicontext s)
        {
            int z = Stbiget8(s);
            return (z << 8) + Stbiget8(s);
        }

        /// <summary>
        ///     Stbis the get 32be using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The uint</returns>
        public static uint Stbiget32Be(Stbicontext s)
        {
            uint z = (uint) Stbiget16Be(s);
            return (uint) ((z << 16) + Stbiget16Be(s));
        }

        /// <summary>
        ///     Stbis the get 16le using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The int</returns>
        public static int Stbiget16Le(Stbicontext s)
        {
            int z = Stbiget8(s);
            return z + (Stbiget8(s) << 8);
        }

        /// <summary>
        ///     Stbis the get 32le using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The </returns>
        public static uint Stbiget32Le(Stbicontext s)
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
        /// <param name="imgn">The img</param>
        /// <param name="reqcomp">The req comp</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The good</returns>
        public static byte* Stbiconvertformat(byte* data, int imgn, int reqcomp, uint x, uint y)
        {
            int i = 0;
            int j = 0;
            byte* good;
            if (reqcomp == imgn)
            {
                return data;
            }

            good = (byte*) Stbimallocmad3(reqcomp, (int) x, (int) y, 0);
            if (good == null)
            {
                CRuntime.Free(data);
                return (byte*) (ulong) (Stbierr("outofmem") != 0 ? 0 : 0);
            }

            for (j = 0; j < (int) y; ++j)
            {
                byte* src = data + j * x * imgn;
                byte* dest = good + j * x * reqcomp;
                switch (imgn * 8 + reqcomp)
                {
                    case 1 * 8 + 2:
                        for (i = (int) (x - 1); i >= 0; --i, src += 1, dest += 2)
                        {
                            dest[0] = src[0];
                            dest[1] = 255;
                        }

                        break;
                    case 1 * 8 + 3:
                        for (i = (int) (x - 1); i >= 0; --i, src += 1, dest += 3)
                        {
                            dest[0] = dest[1] = dest[2] = src[0];
                        }

                        break;
                    case 1 * 8 + 4:
                        for (i = (int) (x - 1); i >= 0; --i, src += 1, dest += 4)
                        {
                            dest[0] = dest[1] = dest[2] = src[0];
                            dest[3] = 255;
                        }

                        break;
                    case 2 * 8 + 1:
                        for (i = (int) (x - 1); i >= 0; --i, src += 2, dest += 1)
                        {
                            dest[0] = src[0];
                        }

                        break;
                    case 2 * 8 + 3:
                        for (i = (int) (x - 1); i >= 0; --i, src += 2, dest += 3)
                        {
                            dest[0] = dest[1] = dest[2] = src[0];
                        }

                        break;
                    case 2 * 8 + 4:
                        for (i = (int) (x - 1); i >= 0; --i, src += 2, dest += 4)
                        {
                            dest[0] = dest[1] = dest[2] = src[0];
                            dest[3] = src[1];
                        }

                        break;
                    case 3 * 8 + 4:
                        for (i = (int) (x - 1); i >= 0; --i, src += 3, dest += 4)
                        {
                            dest[0] = src[0];
                            dest[1] = src[1];
                            dest[2] = src[2];
                            dest[3] = 255;
                        }

                        break;
                    case 3 * 8 + 1:
                        for (i = (int) (x - 1); i >= 0; --i, src += 3, dest += 1)
                        {
                            dest[0] = Stbicomputey(src[0], src[1], src[2]);
                        }

                        break;
                    case 3 * 8 + 2:
                        for (i = (int) (x - 1); i >= 0; --i, src += 3, dest += 2)
                        {
                            dest[0] = Stbicomputey(src[0], src[1], src[2]);
                            dest[1] = 255;
                        }

                        break;
                    case 4 * 8 + 1:
                        for (i = (int) (x - 1); i >= 0; --i, src += 4, dest += 1)
                        {
                            dest[0] = Stbicomputey(src[0], src[1], src[2]);
                        }

                        break;
                    case 4 * 8 + 2:
                        for (i = (int) (x - 1); i >= 0; --i, src += 4, dest += 2)
                        {
                            dest[0] = Stbicomputey(src[0], src[1], src[2]);
                            dest[1] = src[3];
                        }

                        break;
                    case 4 * 8 + 3:
                        for (i = (int) (x - 1); i >= 0; --i, src += 4, dest += 3)
                        {
                            dest[0] = src[0];
                            dest[1] = src[1];
                            dest[2] = src[2];
                        }

                        break;
                    default:
                        ;
                        CRuntime.Free(data);
                        CRuntime.Free(good);
                        return (byte*) (ulong) (Stbierr("unsupported") != 0 ? 0 : 0);
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
        /// <param name="imgn">The img</param>
        /// <param name="reqcomp">The req comp</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The good</returns>
        public static ushort* Stbiconvertformat16(ushort* data, int imgn, int reqcomp, uint x, uint y)
        {
            int i = 0;
            int j = 0;
            ushort* good;
            if (reqcomp == imgn)
            {
                return data;
            }

            good = (ushort*) Stbimalloc((ulong) (reqcomp * x * y * 2));
            if (good == null)
            {
                CRuntime.Free(data);
                return (ushort*) (byte*) (ulong) (Stbierr("outofmem") != 0 ? 0 : 0);
            }

            for (j = 0; j < (int) y; ++j)
            {
                ushort* src = data + j * x * imgn;
                ushort* dest = good + j * x * reqcomp;
                switch (imgn * 8 + reqcomp)
                {
                    case 1 * 8 + 2:
                        for (i = (int) (x - 1); i >= 0; --i, src += 1, dest += 2)
                        {
                            dest[0] = src[0];
                            dest[1] = 0xffff;
                        }

                        break;
                    case 1 * 8 + 3:
                        for (i = (int) (x - 1); i >= 0; --i, src += 1, dest += 3)
                        {
                            dest[0] = dest[1] = dest[2] = src[0];
                        }

                        break;
                    case 1 * 8 + 4:
                        for (i = (int) (x - 1); i >= 0; --i, src += 1, dest += 4)
                        {
                            dest[0] = dest[1] = dest[2] = src[0];
                            dest[3] = 0xffff;
                        }

                        break;
                    case 2 * 8 + 1:
                        for (i = (int) (x - 1); i >= 0; --i, src += 2, dest += 1)
                        {
                            dest[0] = src[0];
                        }

                        break;
                    case 2 * 8 + 3:
                        for (i = (int) (x - 1); i >= 0; --i, src += 2, dest += 3)
                        {
                            dest[0] = dest[1] = dest[2] = src[0];
                        }

                        break;
                    case 2 * 8 + 4:
                        for (i = (int) (x - 1); i >= 0; --i, src += 2, dest += 4)
                        {
                            dest[0] = dest[1] = dest[2] = src[0];
                            dest[3] = src[1];
                        }

                        break;
                    case 3 * 8 + 4:
                        for (i = (int) (x - 1); i >= 0; --i, src += 3, dest += 4)
                        {
                            dest[0] = src[0];
                            dest[1] = src[1];
                            dest[2] = src[2];
                            dest[3] = 0xffff;
                        }

                        break;
                    case 3 * 8 + 1:
                        for (i = (int) (x - 1); i >= 0; --i, src += 3, dest += 1)
                        {
                            dest[0] = Stbicomputey16(src[0], src[1], src[2]);
                        }

                        break;
                    case 3 * 8 + 2:
                        for (i = (int) (x - 1); i >= 0; --i, src += 3, dest += 2)
                        {
                            dest[0] = Stbicomputey16(src[0], src[1], src[2]);
                            dest[1] = 0xffff;
                        }

                        break;
                    case 4 * 8 + 1:
                        for (i = (int) (x - 1); i >= 0; --i, src += 4, dest += 1)
                        {
                            dest[0] = Stbicomputey16(src[0], src[1], src[2]);
                        }

                        break;
                    case 4 * 8 + 2:
                        for (i = (int) (x - 1); i >= 0; --i, src += 4, dest += 2)
                        {
                            dest[0] = Stbicomputey16(src[0], src[1], src[2]);
                            dest[1] = src[3];
                        }

                        break;
                    case 4 * 8 + 3:
                        for (i = (int) (x - 1); i >= 0; --i, src += 4, dest += 3)
                        {
                            dest[0] = src[0];
                            dest[1] = src[1];
                            dest[2] = src[2];
                        }

                        break;
                    default:
                        ;
                        CRuntime.Free(data);
                        CRuntime.Free(good);
                        return (ushort*) (byte*) (ulong) (Stbierr("unsupported") != 0 ? 0 : 0);
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
            return (int) (v * Stbishiftsignedmultable[bits]) >> Stbishiftsignedshifttable[bits];
        }

        /// <summary>
        ///     Stbis the info main using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <returns>The int</returns>
        public static int Stbiinfomain(Stbicontext s, ref int x, ref int y, ref int comp)
        {
            if (Stbijpeginfo(s, (int*)x, (int*)y, (int*)comp) != 0)
            {
                return 1;
            }

            if (Stbipnginfo(s, (int*)x, (int*)y, (int*)comp) != 0)
            {
                return 1;
            }

            if (Stbibmpinfo(s, (int*)x, (int*)y, (int*)comp) != 0)
            {
                return 1;
            }

            return Stbierr("unknown image type");
        }

        /// <summary>
        ///     Stbis the is 16 main using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The int</returns>
        public static int Stbiis16Main(Stbicontext s)
        {
            if (Stbipngis16(s) != 0)
            {
                return 1;
            }

            return 0;
        }
    }
}