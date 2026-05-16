// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PixelFormat.cs
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

namespace Alis.Core.Graphic.OpenGL.Enums
{
    /// <summary>
    ///     The pixel format enum
    /// </summary>
    public enum PixelFormat
    {
        /// <summary>
        ///     Color-indexed pixel data (GL_COLOR_INDEX)
        /// </summary>
        ColorIndex = 0x1900,

        /// <summary>
        ///     Stencil index pixel data (GL_STENCIL_INDEX)
        /// </summary>
        StencilIndex = 0x1901,

        /// <summary>
        ///     Depth component pixel data (GL_DEPTH_COMPONENT)
        /// </summary>
        DepthComponent = 0x1902,

        /// <summary>
        ///     Red color channel pixel data (GL_RED)
        /// </summary>
        Red = 0x1903,

        /// <summary>
        ///     Green color channel pixel data (GL_GREEN)
        /// </summary>
        Green = 0x1904,

        /// <summary>
        ///     Blue color channel pixel data (GL_BLUE)
        /// </summary>
        Blue = 0x1905,

        /// <summary>
        ///     Alpha transparency channel pixel data (GL_ALPHA)
        /// </summary>
        Alpha = 0x1906,

        /// <summary>
        ///     RGB color pixel data (GL_RGB)
        /// </summary>
        Rgb = 0x1907,

        /// <summary>
        ///     RGBA color pixel data with alpha (GL_RGBA)
        /// </summary>
        Rgba = 0x1908,

        /// <summary>
        ///     Luminance (grayscale) pixel data (GL_LUMINANCE)
        /// </summary>
        Luminance = 0x1909,

        /// <summary>
        ///     Luminance with alpha pixel data (GL_LUMINANCE_ALPHA)
        /// </summary>
        LuminanceAlpha = 0x190A,

        /// <summary>
        ///     ABGR pixel format extension (GL_ABGR_EXT)
        /// </summary>
        AbgrExt = 0x8000,

        /// <summary>
        ///     CMYK pixel format extension (GL_CMYK_EXT)
        /// </summary>
        CmykExt = 0x800C,

        /// <summary>
        ///     CMYKA pixel format extension (GL_CMYKA_EXT)
        /// </summary>
        CmykaExt = 0x800D,

        /// <summary>
        ///     Blue-green-red pixel data (GL_BGR)
        /// </summary>
        Bgr = 0x80E0,

        /// <summary>
        ///     Blue-green-red-alpha pixel data (GL_BGRA)
        /// </summary>
        Bgra = 0x80E1,

        /// <summary>
        ///     YCrCb 4:2:2 pixel format, SGIX (GL_YCRCB_422_SGIX)
        /// </summary>
        Ycrcb422Sgix = 0x81BB,

        /// <summary>
        ///     YCrCb 4:4:4 pixel format, SGIX (GL_YCRCB_444_SGIX)
        /// </summary>
        Ycrcb444Sgix = 0x81BC,

        /// <summary>
        ///     Red-green two-component pixel data (GL_RG)
        /// </summary>
        Rg = 0x8227,

        /// <summary>
        ///     Red-green integer pixel data (GL_RG_INTEGER)
        /// </summary>
        RgInteger = 0x8228,

        /// <summary>
        ///     Depth and stencil packed pixel data (GL_DEPTH_STENCIL)
        /// </summary>
        DepthStencil = 0x84F9,

        /// <summary>
        ///     Red integer channel pixel data (GL_RED_INTEGER)
        /// </summary>
        RedInteger = 0x8D94,

        /// <summary>
        ///     Green integer channel pixel data (GL_GREEN_INTEGER)
        /// </summary>
        GreenInteger = 0x8D95,

        /// <summary>
        ///     Blue integer channel pixel data (GL_BLUE_INTEGER)
        /// </summary>
        BlueInteger = 0x8D96,

        /// <summary>
        ///     Alpha integer channel pixel data (GL_ALPHA_INTEGER)
        /// </summary>
        AlphaInteger = 0x8D97,

        /// <summary>
        ///     RGB integer pixel data (GL_RGB_INTEGER)
        /// </summary>
        RgbInteger = 0x8D98,

        /// <summary>
        ///     RGBA integer pixel data (GL_RGBA_INTEGER)
        /// </summary>
        RgbaInteger = 0x8D99,

        /// <summary>
        ///     BGR integer pixel data (GL_BGR_INTEGER)
        /// </summary>
        BgrInteger = 0x8D9A,

        /// <summary>
        ///     BGRA integer pixel data (GL_BGRA_INTEGER)
        /// </summary>
        BgraInteger = 0x8D9B
    }
}