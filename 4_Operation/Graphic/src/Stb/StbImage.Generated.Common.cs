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
        ///     The stbi default
        /// </summary>
        public const int STBI_default = 0;

        /// <summary>
        ///     The stbi grey
        /// </summary>
        public const int STBI_grey = 1;

        /// <summary>
        ///     The stbi grey alpha
        /// </summary>
        public const int STBI_grey_alpha = 2;

        /// <summary>
        ///     The stbi rgb
        /// </summary>
        public const int STBI_rgb = 3;

        /// <summary>
        ///     The stbi rgb alpha
        /// </summary>
        public const int STBI_rgb_alpha = 4;

        /// <summary>
        ///     The stbi order rgb
        /// </summary>
        public const int STBI_ORDER_RGB = 0;

        /// <summary>
        ///     The stbi order bgr
        /// </summary>
        public const int STBI_ORDER_BGR = 1;

        /// <summary>
        ///     The stbi scan load
        /// </summary>
        public const int STBI__SCAN_load = 0;

        /// <summary>
        ///     The stbi scan type
        /// </summary>
        public const int STBI__SCAN_type = 1;

        /// <summary>
        ///     The stbi scan header
        /// </summary>
        public const int STBI__SCAN_header = 2;

        /// <summary>
        ///     The stbi vertically flip on load global
        /// </summary>
        public static int stbi__vertically_flip_on_load_global;

        /// <summary>
        ///     The stbi vertically flip on load local
        /// </summary>
        public static int stbi__vertically_flip_on_load_local;

        /// <summary>
        ///     The stbi vertically flip on load set
        /// </summary>
        public static int stbi__vertically_flip_on_load_set;

        /// <summary>
        ///     The stbi l2h gamma
        /// </summary>
        public static float stbi__l2h_gamma = 2.2f;

        /// <summary>
        ///     The stbi l2h scale
        /// </summary>
        public static float stbi__l2h_scale = 1.0f;

        /// <summary>
        ///     The stbi h2l gamma
        /// </summary>
        public static float stbi__h2l_gamma_i = 1.0f / 2.2f;

        /// <summary>
        ///     The stbi h2l scale
        /// </summary>
        public static float stbi__h2l_scale_i = 1.0f;

        /// <summary>
        ///     The stbi unpremultiply on load global
        /// </summary>
        public static int stbi__unpremultiply_on_load_global;

        /// <summary>
        ///     The stbi de iphone flag global
        /// </summary>
        public static int stbi__de_iphone_flag_global;

        /// <summary>
        ///     The stbi unpremultiply on load local
        /// </summary>
        public static int stbi__unpremultiply_on_load_local;

        /// <summary>
        ///     The stbi unpremultiply on load set
        /// </summary>
        public static int stbi__unpremultiply_on_load_set;

        /// <summary>
        ///     The stbi de iphone flag local
        /// </summary>
        public static int stbi__de_iphone_flag_local;

        /// <summary>
        ///     The stbi de iphone flag set
        /// </summary>
        public static int stbi__de_iphone_flag_set;

        /// <summary>
        ///     The stbi process marker tag
        /// </summary>
        public static byte[] stbi__process_marker_tag = {65, 100, 111, 98, 101, 0};

        /// <summary>
        ///     The stbi process frame header rgb
        /// </summary>
        public static byte[] stbi__process_frame_header_rgb = {82, 71, 66};

        /// <summary>
        ///     The stbi compute huffman codes length dezigzag
        /// </summary>
        public static byte[] stbi__compute_huffman_codes_length_dezigzag =
            {16, 17, 18, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 14, 1, 15};

        /// <summary>
        ///     The stbi shiftsigned mul table
        /// </summary>
        public static int[] stbi__shiftsigned_mul_table = {0, 0xff, 0x55, 0x49, 0x11, 0x21, 0x41, 0x81, 0x01};

        /// <summary>
        ///     The stbi shiftsigned shift table
        /// </summary>
        public static int[] stbi__shiftsigned_shift_table = {0, 0, 0, 1, 0, 2, 4, 6, 0};

        /// <summary>
        ///     Stbis the hdr to ldr gamma using the specified gamma
        /// </summary>
        /// <param name="gamma">The gamma</param>
        public static void stbi_hdr_to_ldr_gamma(float gamma)
        {
            stbi__h2l_gamma_i = 1 / gamma;
        }

        /// <summary>
        ///     Stbis the hdr to ldr scale using the specified scale
        /// </summary>
        /// <param name="scale">The scale</param>
        public static void stbi_hdr_to_ldr_scale(float scale)
        {
            stbi__h2l_scale_i = 1 / scale;
        }

        /// <summary>
        ///     Stbis the ldr to hdr gamma using the specified gamma
        /// </summary>
        /// <param name="gamma">The gamma</param>
        public static void stbi_ldr_to_hdr_gamma(float gamma)
        {
            stbi__l2h_gamma = gamma;
        }

        /// <summary>
        ///     Stbis the ldr to hdr scale using the specified scale
        /// </summary>
        /// <param name="scale">The scale</param>
        public static void stbi_ldr_to_hdr_scale(float scale)
        {
            stbi__l2h_scale = scale;
        }

        /// <summary>
        ///     Stbis the set unpremultiply on load using the specified flag true if should unpremultiply
        /// </summary>
        /// <param name="flag_true_if_should_unpremultiply">The flag true if should unpremultiply</param>
        public static void stbi_set_unpremultiply_on_load(int flag_true_if_should_unpremultiply)
        {
            stbi__unpremultiply_on_load_global = flag_true_if_should_unpremultiply;
        }

        /// <summary>
        ///     Stbis the convert iphone png to rgb using the specified flag true if should convert
        /// </summary>
        /// <param name="flag_true_if_should_convert">The flag true if should convert</param>
        public static void stbi_convert_iphone_png_to_rgb(int flag_true_if_should_convert)
        {
            stbi__de_iphone_flag_global = flag_true_if_should_convert;
        }

        /// <summary>
        ///     Stbis the set flip vertically on load using the specified flag true if should flip
        /// </summary>
        /// <param name="flag_true_if_should_flip">The flag true if should flip</param>
        public static void stbi_set_flip_vertically_on_load(int flag_true_if_should_flip)
        {
            stbi__vertically_flip_on_load_global = flag_true_if_should_flip;
        }

        /// <summary>
        ///     Stbis the set unpremultiply on load thread using the specified flag true if should unpremultiply
        /// </summary>
        /// <param name="flag_true_if_should_unpremultiply">The flag true if should unpremultiply</param>
        public static void stbi_set_unpremultiply_on_load_thread(int flag_true_if_should_unpremultiply)
        {
            stbi__unpremultiply_on_load_local = flag_true_if_should_unpremultiply;
            stbi__unpremultiply_on_load_set = 1;
        }

        /// <summary>
        ///     Stbis the convert iphone png to rgb thread using the specified flag true if should convert
        /// </summary>
        /// <param name="flag_true_if_should_convert">The flag true if should convert</param>
        public static void stbi_convert_iphone_png_to_rgb_thread(int flag_true_if_should_convert)
        {
            stbi__de_iphone_flag_local = flag_true_if_should_convert;
            stbi__de_iphone_flag_set = 1;
        }

        /// <summary>
        ///     Stbis the set flip vertically on load thread using the specified flag true if should flip
        /// </summary>
        /// <param name="flag_true_if_should_flip">The flag true if should flip</param>
        public static void stbi_set_flip_vertically_on_load_thread(int flag_true_if_should_flip)
        {
            stbi__vertically_flip_on_load_local = flag_true_if_should_flip;
            stbi__vertically_flip_on_load_set = 1;
        }

        /// <summary>
        ///     Stbis the malloc using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The void</returns>
        public static void* stbi__malloc(ulong size) => CRuntime.malloc(size);

        /// <summary>
        ///     Stbis the addsizes valid using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        public static int stbi__addsizes_valid(int a, int b)
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
        public static int stbi__mul2sizes_valid(int a, int b)
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
        public static int stbi__mad2sizes_valid(int a, int b, int add) => stbi__mul2sizes_valid(a, b) != 0 && stbi__addsizes_valid(a * b, add) != 0 ? 1 : 0;

        /// <summary>
        ///     Stbis the mad 3sizes valid using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="add">The add</param>
        /// <returns>The int</returns>
        public static int stbi__mad3sizes_valid(int a, int b, int c, int add) => stbi__mul2sizes_valid(a, b) != 0 && stbi__mul2sizes_valid(a * b, c) != 0 &&
                                                                                 stbi__addsizes_valid(a * b * c, add) != 0
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
        public static int stbi__mad4sizes_valid(int a, int b, int c, int d, int add) => stbi__mul2sizes_valid(a, b) != 0 && stbi__mul2sizes_valid(a * b, c) != 0 &&
                                                                                        stbi__mul2sizes_valid(a * b * c, d) != 0 && stbi__addsizes_valid(a * b * c * d, add) != 0
            ? 1
            : 0;

        /// <summary>
        ///     Stbis the malloc mad 2 using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="add">The add</param>
        /// <returns>The void</returns>
        public static void* stbi__malloc_mad2(int a, int b, int add)
        {
            if (stbi__mad2sizes_valid(a, b, add) == 0)
            {
                return null;
            }

            return stbi__malloc((ulong) (a * b + add));
        }

        /// <summary>
        ///     Stbis the malloc mad 3 using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="add">The add</param>
        /// <returns>The void</returns>
        public static void* stbi__malloc_mad3(int a, int b, int c, int add)
        {
            if (stbi__mad3sizes_valid(a, b, c, add) == 0)
            {
                return null;
            }

            return stbi__malloc((ulong) (a * b * c + add));
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
        public static void* stbi__malloc_mad4(int a, int b, int c, int d, int add)
        {
            if (stbi__mad4sizes_valid(a, b, c, d, add) == 0)
            {
                return null;
            }

            return stbi__malloc((ulong) (a * b * c * d + add));
        }

        /// <summary>
        ///     Stbis the addints valid using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        public static int stbi__addints_valid(int a, int b)
        {
            if (a >= 0 != b >= 0)
            {
                return 1;
            }

            if (a < 0 && b < 0)
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
        public static int stbi__mul2shorts_valid(int a, int b)
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
        public static float* stbi__ldr_to_hdr(byte* data, int x, int y, int comp)
        {
            int i = 0;
            int k = 0;
            int n = 0;
            float* output;
            if (data == null)
            {
                return null;
            }

            output = (float*) stbi__malloc_mad4(x, y, comp, sizeof(float), 0);
            if (output == null)
            {
                CRuntime.free(data);
                return (float*) (ulong) (stbi__err("outofmem") != 0 ? 0 : 0);
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
                output[i * comp + k] =
                    (float) (CRuntime.pow(data[i * comp + k] / 255.0f, stbi__l2h_gamma) * stbi__l2h_scale);

            if (n < comp)
            {
                for (i = 0; i < x * y; ++i)
                    output[i * comp + n] = data[i * comp + n] / 255.0f;
            }

            CRuntime.free(data);
            return output;
        }

        /// <summary>
        ///     Stbis the load main using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <param name="req_comp">The req comp</param>
        /// <param name="ri">The ri</param>
        /// <param name="bpc">The bpc</param>
        /// <returns>The void</returns>
        public static void* stbi__load_main(stbi__context s, int* x, int* y, int* comp, int req_comp,
            stbi__result_info* ri, int bpc)
        {
            CRuntime.memset(ri, 0, (ulong) sizeof(stbi__result_info));
            ri->bits_per_channel = 8;
            ri->channel_order = STBI_ORDER_RGB;
            ri->num_channels = 0;
            if (stbi__png_test(s) != 0)
            {
                return stbi__png_load(s, x, y, comp, req_comp, ri);
            }

            if (stbi__bmp_test(s) != 0)
            {
                return stbi__bmp_load(s, x, y, comp, req_comp, ri);
            }

            if (stbi__jpeg_test(s) != 0)
            {
                return stbi__jpeg_load(s, x, y, comp, req_comp, ri);
            }

            return (byte*) (ulong) (stbi__err("unknown image type") != 0 ? 0 : 0);
        }

        /// <summary>
        ///     Stbis the convert 16 to 8 using the specified orig
        /// </summary>
        /// <param name="orig">The orig</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="channels">The channels</param>
        /// <returns>The reduced</returns>
        public static byte* stbi__convert_16_to_8(ushort* orig, int w, int h, int channels)
        {
            int i = 0;
            int img_len = w * h * channels;
            byte* reduced;
            reduced = (byte*) stbi__malloc((ulong) img_len);
            if (reduced == null)
            {
                return (byte*) (ulong) (stbi__err("outofmem") != 0 ? 0 : 0);
            }

            for (i = 0; i < img_len; ++i)
                reduced[i] = (byte) ((orig[i] >> 8) & 0xFF);

            CRuntime.free(orig);
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
        public static ushort* stbi__convert_8_to_16(byte* orig, int w, int h, int channels)
        {
            int i = 0;
            int img_len = w * h * channels;
            ushort* enlarged;
            enlarged = (ushort*) stbi__malloc((ulong) (img_len * 2));
            if (enlarged == null)
            {
                return (ushort*) (byte*) (ulong) (stbi__err("outofmem") != 0 ? 0 : 0);
            }

            for (i = 0; i < img_len; ++i)
                enlarged[i] = (ushort) ((orig[i] << 8) + orig[i]);

            CRuntime.free(orig);
            return enlarged;
        }

        /// <summary>
        ///     Stbis the vertical flip using the specified image
        /// </summary>
        /// <param name="image">The image</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="bytes_per_pixel">The bytes per pixel</param>
        public static void stbi__vertical_flip(void* image, int w, int h, int bytes_per_pixel)
        {
            int row = 0;
            int bytes_per_row = w * bytes_per_pixel;
            byte* temp = stackalloc byte[2048];
            byte* bytes = (byte*) image;
            for (row = 0; row < h >> 1; row++)
            {
                byte* row0 = bytes + row * bytes_per_row;
                byte* row1 = bytes + (h - row - 1) * bytes_per_row;
                ulong bytes_left = (ulong) bytes_per_row;
                while (bytes_left != 0)
                {
                    ulong bytes_copy = bytes_left < 2048 * sizeof(byte) ? bytes_left : 2048 * sizeof(byte);
                    CRuntime.memcpy(temp, row0, bytes_copy);
                    CRuntime.memcpy(row0, row1, bytes_copy);
                    CRuntime.memcpy(row1, temp, bytes_copy);
                    row0 += bytes_copy;
                    row1 += bytes_copy;
                    bytes_left -= bytes_copy;
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
        /// <param name="bytes_per_pixel">The bytes per pixel</param>
        public static void stbi__vertical_flip_slices(void* image, int w, int h, int z, int bytes_per_pixel)
        {
            int slice = 0;
            int slice_size = w * h * bytes_per_pixel;
            byte* bytes = (byte*) image;
            for (slice = 0; slice < z; ++slice)
            {
                stbi__vertical_flip(bytes, w, h, bytes_per_pixel);
                bytes += slice_size;
            }
        }

        /// <summary>
        ///     Stbis the load and postprocess 8bit using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <param name="req_comp">The req comp</param>
        /// <returns>The byte</returns>
        public static byte* stbi__load_and_postprocess_8bit(stbi__context s, int* x, int* y, int* comp, int req_comp)
        {
            stbi__result_info ri = new stbi__result_info();
            void* result = stbi__load_main(s, x, y, comp, req_comp, &ri, 8);
            if (result == null)
            {
                return null;
            }

            if (ri.bits_per_channel != 8)
            {
                result = stbi__convert_16_to_8((ushort*) result, *x, *y, req_comp == 0 ? *comp : req_comp);
                ri.bits_per_channel = 8;
            }

            if ((stbi__vertically_flip_on_load_set != 0
                    ? stbi__vertically_flip_on_load_local
                    : stbi__vertically_flip_on_load_global) != 0)
            {
                int channels = req_comp != 0 ? req_comp : *comp;
                stbi__vertical_flip(result, *x, *y, channels * sizeof(byte));
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
        /// <param name="req_comp">The req comp</param>
        /// <returns>The ushort</returns>
        public static ushort* stbi__load_and_postprocess_16bit(stbi__context s, int* x, int* y, int* comp, int req_comp)
        {
            stbi__result_info ri = new stbi__result_info();
            void* result = stbi__load_main(s, x, y, comp, req_comp, &ri, 16);
            if (result == null)
            {
                return null;
            }

            if (ri.bits_per_channel != 16)
            {
                result = stbi__convert_8_to_16((byte*) result, *x, *y, req_comp == 0 ? *comp : req_comp);
                ri.bits_per_channel = 16;
            }

            if ((stbi__vertically_flip_on_load_set != 0
                    ? stbi__vertically_flip_on_load_local
                    : stbi__vertically_flip_on_load_global) != 0)
            {
                int channels = req_comp != 0 ? req_comp : *comp;
                stbi__vertical_flip(result, *x, *y, channels * sizeof(ushort));
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
        /// <param name="req_comp">The req comp</param>
        public static void stbi__float_postprocess(float* result, int* x, int* y, int* comp, int req_comp)
        {
            if ((stbi__vertically_flip_on_load_set != 0
                    ? stbi__vertically_flip_on_load_local
                    : stbi__vertically_flip_on_load_global) != 0 && result != null)
            {
                int channels = req_comp != 0 ? req_comp : *comp;
                stbi__vertical_flip(result, *x, *y, channels * sizeof(float));
            }
        }

        /// <summary>
        ///     Stbis the loadf main using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <param name="req_comp">The req comp</param>
        /// <returns>The float</returns>
        public static float* stbi__loadf_main(stbi__context s, int* x, int* y, int* comp, int req_comp)
        {
            byte* data;
            data = stbi__load_and_postprocess_8bit(s, x, y, comp, req_comp);
            if (data != null)
            {
                return stbi__ldr_to_hdr(data, *x, *y, req_comp != 0 ? req_comp : *comp);
            }

            return (float*) (ulong) (stbi__err("unknown image type") != 0 ? 0 : 0);
        }

        /// <summary>
        ///     Stbis the get 16be using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The int</returns>
        public static int stbi__get16be(stbi__context s)
        {
            int z = stbi__get8(s);
            return (z << 8) + stbi__get8(s);
        }

        /// <summary>
        ///     Stbis the get 32be using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The uint</returns>
        public static uint stbi__get32be(stbi__context s)
        {
            uint z = (uint) stbi__get16be(s);
            return (uint) ((z << 16) + stbi__get16be(s));
        }

        /// <summary>
        ///     Stbis the get 16le using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The int</returns>
        public static int stbi__get16le(stbi__context s)
        {
            int z = stbi__get8(s);
            return z + (stbi__get8(s) << 8);
        }

        /// <summary>
        ///     Stbis the get 32le using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The </returns>
        public static uint stbi__get32le(stbi__context s)
        {
            uint z = (uint) stbi__get16le(s);
            z += (uint) stbi__get16le(s) << 16;
            return z;
        }

        /// <summary>
        ///     Stbis the compute y using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The byte</returns>
        public static byte stbi__compute_y(int r, int g, int b) => (byte) ((r * 77 + g * 150 + 29 * b) >> 8);

        /// <summary>
        ///     Stbis the convert format using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="img_n">The img</param>
        /// <param name="req_comp">The req comp</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The good</returns>
        public static byte* stbi__convert_format(byte* data, int img_n, int req_comp, uint x, uint y)
        {
            int i = 0;
            int j = 0;
            byte* good;
            if (req_comp == img_n)
            {
                return data;
            }

            good = (byte*) stbi__malloc_mad3(req_comp, (int) x, (int) y, 0);
            if (good == null)
            {
                CRuntime.free(data);
                return (byte*) (ulong) (stbi__err("outofmem") != 0 ? 0 : 0);
            }

            for (j = 0; j < (int) y; ++j)
            {
                byte* src = data + j * x * img_n;
                byte* dest = good + j * x * req_comp;
                switch (img_n * 8 + req_comp)
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
                            dest[0] = dest[1] = dest[2] = src[0];

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
                            dest[0] = src[0];

                        break;
                    case 2 * 8 + 3:
                        for (i = (int) (x - 1); i >= 0; --i, src += 2, dest += 3)
                            dest[0] = dest[1] = dest[2] = src[0];

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
                            dest[0] = stbi__compute_y(src[0], src[1], src[2]);

                        break;
                    case 3 * 8 + 2:
                        for (i = (int) (x - 1); i >= 0; --i, src += 3, dest += 2)
                        {
                            dest[0] = stbi__compute_y(src[0], src[1], src[2]);
                            dest[1] = 255;
                        }

                        break;
                    case 4 * 8 + 1:
                        for (i = (int) (x - 1); i >= 0; --i, src += 4, dest += 1)
                            dest[0] = stbi__compute_y(src[0], src[1], src[2]);

                        break;
                    case 4 * 8 + 2:
                        for (i = (int) (x - 1); i >= 0; --i, src += 4, dest += 2)
                        {
                            dest[0] = stbi__compute_y(src[0], src[1], src[2]);
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
                        CRuntime.free(data);
                        CRuntime.free(good);
                        return (byte*) (ulong) (stbi__err("unsupported") != 0 ? 0 : 0);
                }
            }

            CRuntime.free(data);
            return good;
        }

        /// <summary>
        ///     Stbis the compute y 16 using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The ushort</returns>
        public static ushort stbi__compute_y_16(int r, int g, int b) => (ushort) ((r * 77 + g * 150 + 29 * b) >> 8);

        /// <summary>
        ///     Stbis the convert format 16 using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="img_n">The img</param>
        /// <param name="req_comp">The req comp</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The good</returns>
        public static ushort* stbi__convert_format16(ushort* data, int img_n, int req_comp, uint x, uint y)
        {
            int i = 0;
            int j = 0;
            ushort* good;
            if (req_comp == img_n)
            {
                return data;
            }

            good = (ushort*) stbi__malloc((ulong) (req_comp * x * y * 2));
            if (good == null)
            {
                CRuntime.free(data);
                return (ushort*) (byte*) (ulong) (stbi__err("outofmem") != 0 ? 0 : 0);
            }

            for (j = 0; j < (int) y; ++j)
            {
                ushort* src = data + j * x * img_n;
                ushort* dest = good + j * x * req_comp;
                switch (img_n * 8 + req_comp)
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
                            dest[0] = dest[1] = dest[2] = src[0];

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
                            dest[0] = src[0];

                        break;
                    case 2 * 8 + 3:
                        for (i = (int) (x - 1); i >= 0; --i, src += 2, dest += 3)
                            dest[0] = dest[1] = dest[2] = src[0];

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
                            dest[0] = stbi__compute_y_16(src[0], src[1], src[2]);

                        break;
                    case 3 * 8 + 2:
                        for (i = (int) (x - 1); i >= 0; --i, src += 3, dest += 2)
                        {
                            dest[0] = stbi__compute_y_16(src[0], src[1], src[2]);
                            dest[1] = 0xffff;
                        }

                        break;
                    case 4 * 8 + 1:
                        for (i = (int) (x - 1); i >= 0; --i, src += 4, dest += 1)
                            dest[0] = stbi__compute_y_16(src[0], src[1], src[2]);

                        break;
                    case 4 * 8 + 2:
                        for (i = (int) (x - 1); i >= 0; --i, src += 4, dest += 2)
                        {
                            dest[0] = stbi__compute_y_16(src[0], src[1], src[2]);
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
                        CRuntime.free(data);
                        CRuntime.free(good);
                        return (ushort*) (byte*) (ulong) (stbi__err("unsupported") != 0 ? 0 : 0);
                }
            }

            CRuntime.free(data);
            return good;
        }

        /// <summary>
        ///     Stbis the clamp using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        public static byte stbi__clamp(int x)
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
        public static byte stbi__blinn_8x8(byte x, byte y)
        {
            uint t = (uint) (x * y + 128);
            return (byte) ((t + (t >> 8)) >> 8);
        }

        /// <summary>
        ///     Stbis the bitreverse 16 using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <returns>The </returns>
        public static int stbi__bitreverse16(int n)
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
        public static int stbi__bit_reverse(int v, int bits) => stbi__bitreverse16(v) >> (16 - bits);

        /// <summary>
        ///     Stbis the high bit using the specified z
        /// </summary>
        /// <param name="z">The </param>
        /// <returns>The </returns>
        public static int stbi__high_bit(uint z)
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
        public static int stbi__bitcount(uint a)
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
        public static int stbi__shiftsigned(uint v, int shift, int bits)
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
            return (int) (v * stbi__shiftsigned_mul_table[bits]) >> stbi__shiftsigned_shift_table[bits];
        }

        /// <summary>
        ///     Stbis the info main using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="comp">The comp</param>
        /// <returns>The int</returns>
        public static int stbi__info_main(stbi__context s, int* x, int* y, int* comp)
        {
            if (stbi__jpeg_info(s, x, y, comp) != 0)
            {
                return 1;
            }

            if (stbi__png_info(s, x, y, comp) != 0)
            {
                return 1;
            }

            if (stbi__bmp_info(s, x, y, comp) != 0)
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
        public static int stbi__is_16_main(stbi__context s)
        {
            if (stbi__png_is16(s) != 0)
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        ///     The stbi result info
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct stbi__result_info
        {
            /// <summary>
            ///     The bits per channel
            /// </summary>
            public int bits_per_channel;

            /// <summary>
            ///     The num channels
            /// </summary>
            public int num_channels;

            /// <summary>
            ///     The channel order
            /// </summary>
            public int channel_order;
        }
    }
}