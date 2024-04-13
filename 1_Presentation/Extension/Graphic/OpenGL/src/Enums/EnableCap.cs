// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnableCap.cs
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

namespace Alis.Extension.Graphic.OpenGL.Enums
{
    /// <summary>
    ///     The enable cap enum
    /// </summary>
    public enum EnableCap
    {
        /// <summary>
        ///     The line smooth enable cap
        /// </summary>
        LineSmooth = 0x0B20,
        
        /// <summary>
        ///     The polygon smooth enable cap
        /// </summary>
        PolygonSmooth = 0x0B41,
        
        /// <summary>
        ///     The cull face enable cap
        /// </summary>
        CullFace = 0x0B44,
        
        /// <summary>
        ///     The depth test enable cap
        /// </summary>
        DepthTest = 0x0B71,
        
        /// <summary>
        ///     The stencil test enable cap
        /// </summary>
        StencilTest = 0x0B90,
        
        /// <summary>
        ///     The dither enable cap
        /// </summary>
        Dither = 0x0BD0,
        
        /// <summary>
        ///     The blend enable cap
        /// </summary>
        Blend = 0x0BE2,
        
        /// <summary>
        ///     The index logic op enable cap
        /// </summary>
        IndexLogicOp = 0x0BF1,
        
        /// <summary>
        ///     The color logic op enable cap
        /// </summary>
        ColorLogicOp = 0x0BF2,
        
        /// <summary>
        ///     The scissor test enable cap
        /// </summary>
        ScissorTest = 0x0C11,
        
        /// <summary>
        ///     The auto normal enable cap
        /// </summary>
        AutoNormal = 0x0D80,
        
        /// <summary>
        ///     The map color enable cap
        /// </summary>
        Map1Color4 = 0x0D90,
        
        /// <summary>
        ///     The map index enable cap
        /// </summary>
        Map1Index = 0x0D91,
        
        /// <summary>
        ///     The map normal enable cap
        /// </summary>
        Map1Normal = 0x0D92,
        
        /// <summary>
        ///     The map texture coord enable cap
        /// </summary>
        Map1TextureCoord1 = 0x0D93,
        
        /// <summary>
        ///     The map texture coord enable cap
        /// </summary>
        Map1TextureCoord2 = 0x0D94,
        
        /// <summary>
        ///     The map texture coord enable cap
        /// </summary>
        Map1TextureCoord3 = 0x0D95,
        
        /// <summary>
        ///     The map texture coord enable cap
        /// </summary>
        Map1TextureCoord4 = 0x0D96,
        
        /// <summary>
        ///     The map vertex enable cap
        /// </summary>
        Map1Vertex3 = 0x0D97,
        
        /// <summary>
        ///     The map vertex enable cap
        /// </summary>
        Map1Vertex4 = 0x0D98,
        
        /// <summary>
        ///     The map color enable cap
        /// </summary>
        Map2Color4 = 0x0DB0,
        
        /// <summary>
        ///     The map index enable cap
        /// </summary>
        Map2Index = 0x0DB1,
        
        /// <summary>
        ///     The map normal enable cap
        /// </summary>
        Map2Normal = 0x0DB2,
        
        /// <summary>
        ///     The map texture coord enable cap
        /// </summary>
        Map2TextureCoord1 = 0x0DB3,
        
        /// <summary>
        ///     The map texture coord enable cap
        /// </summary>
        Map2TextureCoord2 = 0x0DB4,
        
        /// <summary>
        ///     The map texture coord enable cap
        /// </summary>
        Map2TextureCoord3 = 0x0DB5,
        
        /// <summary>
        ///     The map texture coord enable cap
        /// </summary>
        Map2TextureCoord4 = 0x0DB6,
        
        /// <summary>
        ///     The map vertex enable cap
        /// </summary>
        Map2Vertex3 = 0x0DB7,
        
        /// <summary>
        ///     The map vertex enable cap
        /// </summary>
        Map2Vertex4 = 0x0DB8,
        
        /// <summary>
        ///     The texture enable cap
        /// </summary>
        Texture1D = 0x0DE0,
        
        /// <summary>
        ///     The texture enable cap
        /// </summary>
        Texture2D = 0x0DE1,
        
        /// <summary>
        ///     The polygon offset point enable cap
        /// </summary>
        PolygonOffsetPoint = 0x2A01,
        
        /// <summary>
        ///     The polygon offset line enable cap
        /// </summary>
        PolygonOffsetLine = 0x2A02,
        
        /// <summary>
        ///     The clip plane enable cap
        /// </summary>
        ClipPlane0 = 0x3000,
        
        /// <summary>
        ///     The clip plane enable cap
        /// </summary>
        ClipPlane1 = 0x3001,
        
        /// <summary>
        ///     The clip plane enable cap
        /// </summary>
        ClipPlane2 = 0x3002,
        
        /// <summary>
        ///     The clip plane enable cap
        /// </summary>
        ClipPlane3 = 0x3003,
        
        /// <summary>
        ///     The clip plane enable cap
        /// </summary>
        ClipPlane4 = 0x3004,
        
        /// <summary>
        ///     The clip plane enable cap
        /// </summary>
        ClipPlane5 = 0x3005,
        
        /// <summary>
        ///     The convolution enable cap
        /// </summary>
        Convolution1D = 0x8010,
        
        /// <summary>
        ///     The convolution ext enable cap
        /// </summary>
        Convolution1DExt = 0x8010,
        
        /// <summary>
        ///     The convolution enable cap
        /// </summary>
        Convolution2D = 0x8011,
        
        /// <summary>
        ///     The convolution ext enable cap
        /// </summary>
        Convolution2DExt = 0x8011,
        
        /// <summary>
        ///     The separable enable cap
        /// </summary>
        Separable2D = 0x8012,
        
        /// <summary>
        ///     The separable ext enable cap
        /// </summary>
        Separable2DExt = 0x8012,
        
        /// <summary>
        ///     The histogram enable cap
        /// </summary>
        Histogram = 0x8024,
        
        /// <summary>
        ///     The histogram ext enable cap
        /// </summary>
        HistogramExt = 0x8024,
        
        /// <summary>
        ///     The minmax ext enable cap
        /// </summary>
        MinmaxExt = 0x802E,
        
        /// <summary>
        ///     The polygon offset fill enable cap
        /// </summary>
        PolygonOffsetFill = 0x8037,
        
        /// <summary>
        ///     The rescale normal ext enable cap
        /// </summary>
        RescaleNormalExt = 0x803A,
        
        /// <summary>
        ///     The texture ext enable cap
        /// </summary>
        Texture3DExt = 0x806F,
        
        /// <summary>
        ///     The vertex array enable cap
        /// </summary>
        VertexArray = 0x8074,
        
        /// <summary>
        ///     The normal array enable cap
        /// </summary>
        NormalArray = 0x8075,
        
        /// <summary>
        ///     The color array enable cap
        /// </summary>
        ColorArray = 0x8076,
        
        /// <summary>
        ///     The index array enable cap
        /// </summary>
        IndexArray = 0x8077,
        
        /// <summary>
        ///     The texture coord array enable cap
        /// </summary>
        TextureCoordArray = 0x8078,
        
        /// <summary>
        ///     The edge flag array enable cap
        /// </summary>
        EdgeFlagArray = 0x8079,
        
        /// <summary>
        ///     The interlace sgix enable cap
        /// </summary>
        InterlaceSgix = 0x8094,
        
        /// <summary>
        ///     The multisample enable cap
        /// </summary>
        Multisample = 0x809D,
        
        /// <summary>
        ///     The sample alpha to coverage enable cap
        /// </summary>
        SampleAlphaToCoverage = 0x809E,
        
        /// <summary>
        ///     The sample alpha to mask sgis enable cap
        /// </summary>
        SampleAlphaToMaskSgis = 0x809E,
        
        /// <summary>
        ///     The sample alpha to one enable cap
        /// </summary>
        SampleAlphaToOne = 0x809F,
        
        /// <summary>
        ///     The sample alpha to one sgis enable cap
        /// </summary>
        SampleAlphaToOneSgis = 0x809F,
        
        /// <summary>
        ///     The sample coverage enable cap
        /// </summary>
        SampleCoverage = 0x80A0,
        
        /// <summary>
        ///     The sample mask sgis enable cap
        /// </summary>
        SampleMaskSgis = 0x80A0,
        
        /// <summary>
        ///     The texture color table sgi enable cap
        /// </summary>
        TextureColorTableSgi = 0x80BC,
        
        /// <summary>
        ///     The color table enable cap
        /// </summary>
        ColorTable = 0x80D0,
        
        /// <summary>
        ///     The color table sgi enable cap
        /// </summary>
        ColorTableSgi = 0x80D0,
        
        /// <summary>
        ///     The post convolution color table enable cap
        /// </summary>
        PostConvolutionColorTable = 0x80D1,
        
        /// <summary>
        ///     The post convolution color table sgi enable cap
        /// </summary>
        PostConvolutionColorTableSgi = 0x80D1,
        
        /// <summary>
        ///     The post color matrix color table enable cap
        /// </summary>
        PostColorMatrixColorTable = 0x80D2,
        
        /// <summary>
        ///     The post color matrix color table sgi enable cap
        /// </summary>
        PostColorMatrixColorTableSgi = 0x80D2,
        
        /// <summary>
        ///     The texture sgis enable cap
        /// </summary>
        Texture4DSgis = 0x8134,
        
        /// <summary>
        ///     The pixel tex gen sgix enable cap
        /// </summary>
        TexGenSgix = 0x8139,
        
        /// <summary>
        ///     The sprite sgix enable cap
        /// </summary>
        SpriteSgix = 0x8148,
        
        /// <summary>
        ///     The reference plane sgix enable cap
        /// </summary>
        ReferencePlaneSgix = 0x817D,
        
        /// <summary>
        ///     The ir instrument sgix enable cap
        /// </summary>
        IrInstrument1Sgix = 0x817F,
        
        /// <summary>
        ///     The calligraphic fragment sgix enable cap
        /// </summary>
        CalligraphicFragmentSgix = 0x8183,
        
        /// <summary>
        ///     The framezoom sgix enable cap
        /// </summary>
        FramezoomSgix = 0x818B,
        
        /// <summary>
        ///     The fog offset sgix enable cap
        /// </summary>
        FogOffsetSgix = 0x8198,
        
        /// <summary>
        ///     The shared texture palette ext enable cap
        /// </summary>
        SharedTexturePaletteExt = 0x81FB,
        
        /// <summary>
        ///     The async histogram sgix enable cap
        /// </summary>
        AsyncHistogramSgix = 0x832C,
        
        /// <summary>
        ///     The pixel texture sgis enable cap
        /// </summary>
        TextureSgis = 0x8353,
        
        /// <summary>
        ///     The async tex image sgix enable cap
        /// </summary>
        AsyncTexImageSgix = 0x835C,
        
        /// <summary>
        ///     The async draw pixels sgix enable cap
        /// </summary>
        AsyncDrawPixelsSgix = 0x835D,
        
        /// <summary>
        ///     The async read pixels sgix enable cap
        /// </summary>
        AsyncReadPixelsSgix = 0x835E,
        
        /// <summary>
        ///     The fragment lighting sgix enable cap
        /// </summary>
        FragmentLightingSgix = 0x8400,
        
        /// <summary>
        ///     The fragment color material sgix enable cap
        /// </summary>
        FragmentColorMaterialSgix = 0x8401,
        
        /// <summary>
        ///     The fragment light sgix enable cap
        /// </summary>
        FragmentLight0Sgix = 0x840C,
        
        /// <summary>
        ///     The fragment light sgix enable cap
        /// </summary>
        FragmentLight1Sgix = 0x840D,
        
        /// <summary>
        ///     The fragment light sgix enable cap
        /// </summary>
        FragmentLight2Sgix = 0x840E,
        
        /// <summary>
        ///     The fragment light sgix enable cap
        /// </summary>
        FragmentLight3Sgix = 0x840F,
        
        /// <summary>
        ///     The fragment light sgix enable cap
        /// </summary>
        FragmentLight4Sgix = 0x8410,
        
        /// <summary>
        ///     The fragment light sgix enable cap
        /// </summary>
        FragmentLight5Sgix = 0x8411,
        
        /// <summary>
        ///     The fragment light sgix enable cap
        /// </summary>
        FragmentLight6Sgix = 0x8412,
        
        /// <summary>
        ///     The fragment light sgix enable cap
        /// </summary>
        FragmentLight7Sgix = 0x8413,
        
        /// <summary>
        ///     The color sum enable cap
        /// </summary>
        ColorSum = 0x8458,
        
        /// <summary>
        ///     The secondary color array enable cap
        /// </summary>
        SecondaryColorArray = 0x845E,
        
        /// <summary>
        ///     The texture cube map enable cap
        /// </summary>
        TextureCubeMap = 0x8513,
        
        /// <summary>
        ///     The program point size enable cap
        /// </summary>
        ProgramPointSize = 0x8642,
        
        /// <summary>
        ///     The vertex program point size enable cap
        /// </summary>
        VertexProgramPointSize = 0x8642,
        
        /// <summary>
        ///     The depth clamp enable cap
        /// </summary>
        DepthClamp = 0x864F,
        
        /// <summary>
        ///     The texture cube map seamless enable cap
        /// </summary>
        TextureCubeMapSeamless = 0x884F,
        
        /// <summary>
        ///     The point sprite enable cap
        /// </summary>
        PointSprite = 0x8861,
        
        /// <summary>
        ///     The rasterizer discard enable cap
        /// </summary>
        RasterizerDiscard = 0x8C89,
        
        /// <summary>
        ///     The framebuffer srgb enable cap
        /// </summary>
        FramebufferSrgb = 0x8DB9,
        
        /// <summary>
        ///     The sample mask enable cap
        /// </summary>
        SampleMask = 0x8E51,
        
        /// <summary>
        ///     The primitive restart enable cap
        /// </summary>
        PrimitiveRestart = 0x8F9D
    }
}