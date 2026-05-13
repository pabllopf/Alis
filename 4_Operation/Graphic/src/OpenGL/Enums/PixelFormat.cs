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
    /// Defines the pixel data formats used by OpenGL functions such as glReadPixels, glTexImage2D, and glDrawPixels.
    /// Specifies the order and type of color components in the pixel data.
    /// </summary>
    public enum PixelFormat
    {
        /// <summary>Color index mode pixels (GL_COLOR_INDEX = 0x1900).</summary>
        ColorIndex = 0x1900,

        /// <summary>Single stencil component (GL_STENCIL_INDEX = 0x1901).</summary>
        StencilIndex = 0x1901,

        /// <summary>Single depth component (GL_DEPTH_COMPONENT = 0x1902).</summary>
        DepthComponent = 0x1902,

        /// <summary>Red color component only (GL_RED = 0x1903).</summary>
        Red = 0x1903,

        /// <summary>Green color component only (GL_GREEN = 0x1904).</summary>
        Green = 0x1904,

        /// <summary>Blue color component only (GL_BLUE = 0x1905).</summary>
        Blue = 0x1905,

        /// <summary>Alpha component only (GL_ALPHA = 0x1906).</summary>
        Alpha = 0x1906,

        /// <summary>Red, Green, Blue components (GL_RGB = 0x1907).</summary>
        Rgb = 0x1907,

        /// <summary>Red, Green, Blue, Alpha components (GL_RGBA = 0x1908).</summary>
        Rgba = 0x1908,

        /// <summary>Luminance component only (GL_LUMINANCE = 0x1909).</summary>
        Luminance = 0x1909,

        /// <summary>Luminance and Alpha components (GL_LUMINANCE_ALPHA = 0x190A).</summary>
        LuminanceAlpha = 0x190A,

        /// <summary>Extension: ABGR component order (GL_ABGR_EXT = 0x8000).</summary>
        AbgrExt = 0x8000,

        /// <summary>Extension: CMYK components (GL_CMYK_EXT = 0x800C).</summary>
        CmykExt = 0x800C,

        /// <summary>Extension: CMYK with Alpha (GL_CMYKa_EXT = 0x800D).</summary>
        CmykaExt = 0x800D,

        /// <summary>Blue, Green, Red components (GL_BGR = 0x80E0).</summary>
        Bgr = 0x80E0,

        /// <summary>Blue, Green, Red, Alpha components (GL_BGRA = 0x80E1).</summary>
        Bgra = 0x80E1,

        /// <summary>Extension: YCrCb 4:2:2 format (GL_YCBCR_422_SGIX = 0x81BB).</summary>
        Ycrcb422Sgix = 0x81BB,

        /// <summary>Extension: YCrCb 4:4:4 format (GL_YCBCR_444_SGIX = 0x81BC).</summary>
        Ycrcb444Sgix = 0x81BC,

        /// <summary>Red and Green components (GL_RG = 0x8227).</summary>
        Rg = 0x8227,

        /// <summary>Red and Green integer components (GL_RG_INTEGER = 0x8228).</summary>
        RgInteger = 0x8228,

        /// <summary>Depth and Stencil components (GL_DEPTH_STENCIL = 0x84F9).</summary>
        DepthStencil = 0x84F9,

        /// <summary>Red integer component (GL_RED_INTEGER = 0x8D94).</summary>
        RedInteger = 0x8D94,

        /// <summary>Green integer component (GL_GREEN_INTEGER = 0x8D95).</summary>
        GreenInteger = 0x8D95,

        /// <summary>Blue integer component (GL_BLUE_INTEGER = 0x8D96).</summary>
        BlueInteger = 0x8D96,

        /// <summary>Alpha integer component (GL_ALPHA_INTEGER = 0x8D97).</summary>
        AlphaInteger = 0x8D97,

        /// <summary>RGB integer components (GL_RGB_INTEGER = 0x8D98).</summary>
        RgbInteger = 0x8D98,

        /// <summary>RGBA integer components (GL_RGBA_INTEGER = 0x8D99).</summary>
        RgbaInteger = 0x8D99,

        /// <summary>BGR integer components (GL_BGR_INTEGER = 0x8D9A).</summary>
        BgrInteger = 0x8D9A,

        /// <summary>BGRA integer components (GL_BGRA_INTEGER = 0x8D9B).</summary>
        BgraInteger = 0x8D9B
    }
}
