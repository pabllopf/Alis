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

namespace Alis.Core.Graphic.OpenGL.Enums
{
    /// <summary>
    /// Defines the capability flags that can be enabled or disabled via glEnable and glDisable.
    /// Controls various OpenGL features such as blending, depth testing, face culling, and texturing.
    /// </summary>
    public enum EnableCap
    {
        /// <summary>Smooth line rendering (GL_LINE_SMOOTH = 0x0B20).</summary>
        LineSmooth = 0x0B20,

        /// <summary>Smooth polygon rendering (GL_POLYGON_SMOOTH = 0x0B41).</summary>
        PolygonSmooth = 0x0B41,

        /// <summary>Face culling (GL_CULL_FACE = 0x0B44).</summary>
        CullFace = 0x0B44,

        /// <summary>Depth buffer testing (GL_DEPTH_TEST = 0x0B71).</summary>
        DepthTest = 0x0B71,

        /// <summary>Stencil buffer testing (GL_STENCIL_TEST = 0x0B90).</summary>
        StencilTest = 0x0B90,

        /// <summary>Dithering of color components (GL_DITHER = 0x0BD0).</summary>
        Dither = 0x0BD0,

        /// <summary>Blending of fragment colors (GL_BLEND = 0x0BE2).</summary>
        Blend = 0x0BE2,

        /// <summary>Index logic operations (GL_INDEX_LOGIC_OP = 0x0BF1).</summary>
        IndexLogicOp = 0x0BF1,

        /// <summary>Color logic operations (GL_COLOR_LOGIC_OP = 0x0BF2).</summary>
        ColorLogicOp = 0x0BF2,

        /// <summary>Scissor rectangle test (GL_SCISSOR_TEST = 0x0C11).</summary>
        ScissorTest = 0x0C11,

        /// <summary>Automatic normal generation (GL_AUTO_NORMAL = 0x0D80).</summary>
        AutoNormal = 0x0D80,

        /// <summary>1D color evaluator map (GL_MAP1_COLOR_4 = 0x0D90).</summary>
        Map1Color4 = 0x0D90,

        /// <summary>1D index evaluator map (GL_MAP1_INDEX = 0x0D91).</summary>
        Map1Index = 0x0D91,

        /// <summary>1D normal evaluator map (GL_MAP1_NORMAL = 0x0D92).</summary>
        Map1Normal = 0x0D92,

        /// <summary>1D texture coordinate 1 evaluator map (GL_MAP1_TEXTURE_COORD_1 = 0x0D93).</summary>
        Map1TextureCoord1 = 0x0D93,

        /// <summary>1D texture coordinate 2 evaluator map (GL_MAP1_TEXTURE_COORD_2 = 0x0D94).</summary>
        Map1TextureCoord2 = 0x0D94,

        /// <summary>1D texture coordinate 3 evaluator map (GL_MAP1_TEXTURE_COORD_3 = 0x0D95).</summary>
        Map1TextureCoord3 = 0x0D95,

        /// <summary>1D texture coordinate 4 evaluator map (GL_MAP1_TEXTURE_COORD_4 = 0x0D96).</summary>
        Map1TextureCoord4 = 0x0D96,

        /// <summary>1D vertex 3 evaluator map (GL_MAP1_VERTEX_3 = 0x0D97).</summary>
        Map1Vertex3 = 0x0D97,

        /// <summary>1D vertex 4 evaluator map (GL_MAP1_VERTEX_4 = 0x0D98).</summary>
        Map1Vertex4 = 0x0D98,

        /// <summary>2D color evaluator map (GL_MAP2_COLOR_4 = 0x0DB0).</summary>
        Map2Color4 = 0x0DB0,

        /// <summary>2D index evaluator map (GL_MAP2_INDEX = 0x0DB1).</summary>
        Map2Index = 0x0DB1,

        /// <summary>2D normal evaluator map (GL_MAP2_NORMAL = 0x0DB2).</summary>
        Map2Normal = 0x0DB2,

        /// <summary>2D texture coordinate 1 evaluator map (GL_MAP2_TEXTURE_COORD_1 = 0x0DB3).</summary>
        Map2TextureCoord1 = 0x0DB3,

        /// <summary>2D texture coordinate 2 evaluator map (GL_MAP2_TEXTURE_COORD_2 = 0x0DB4).</summary>
        Map2TextureCoord2 = 0x0DB4,

        /// <summary>2D texture coordinate 3 evaluator map (GL_MAP2_TEXTURE_COORD_3 = 0x0DB5).</summary>
        Map2TextureCoord3 = 0x0DB5,

        /// <summary>2D texture coordinate 4 evaluator map (GL_MAP2_TEXTURE_COORD_4 = 0x0DB6).</summary>
        Map2TextureCoord4 = 0x0DB6,

        /// <summary>2D vertex 3 evaluator map (GL_MAP2_VERTEX_3 = 0x0DB7).</summary>
        Map2Vertex3 = 0x0DB7,

        /// <summary>2D vertex 4 evaluator map (GL_MAP2_VERTEX_4 = 0x0DB8).</summary>
        Map2Vertex4 = 0x0DB8,

        /// <summary>1D texture mapping (GL_TEXTURE_1D = 0x0DE0).</summary>
        Texture1D = 0x0DE0,

        /// <summary>2D texture mapping (GL_TEXTURE_2D = 0x0DE1).</summary>
        Texture2D = 0x0DE1,

        /// <summary>Polygon offset for points (GL_POLYGON_OFFSET_POINT = 0x2A01).</summary>
        PolygonOffsetPoint = 0x2A01,

        /// <summary>Polygon offset for lines (GL_POLYGON_OFFSET_LINE = 0x2A02).</summary>
        PolygonOffsetLine = 0x2A02,

        /// <summary>Clip plane 0 (GL_CLIP_PLANE0 = 0x3000).</summary>
        ClipPlane0 = 0x3000,

        /// <summary>Clip plane 1 (GL_CLIP_PLANE1 = 0x3001).</summary>
        ClipPlane1 = 0x3001,

        /// <summary>Clip plane 2 (GL_CLIP_PLANE2 = 0x3002).</summary>
        ClipPlane2 = 0x3002,

        /// <summary>Clip plane 3 (GL_CLIP_PLANE3 = 0x3003).</summary>
        ClipPlane3 = 0x3003,

        /// <summary>Clip plane 4 (GL_CLIP_PLANE4 = 0x3004).</summary>
        ClipPlane4 = 0x3004,

        /// <summary>Clip plane 5 (GL_CLIP_PLANE5 = 0x3005).</summary>
        ClipPlane5 = 0x3005,

        /// <summary>1D convolution filter (GL_CONVOLUTION_1D = 0x8010).</summary>
        Convolution1D = 0x8010,

        /// <summary>Extension alias for 1D convolution (GL_CONVOLUTION_1D_EXT = 0x8010).</summary>
        Convolution1DExt = 0x8010,

        /// <summary>2D convolution filter (GL_CONVOLUTION_2D = 0x8011).</summary>
        Convolution2D = 0x8011,

        /// <summary>Extension alias for 2D convolution (GL_CONVOLUTION_2D_EXT = 0x8011).</summary>
        Convolution2DExt = 0x8011,

        /// <summary>2D separable filter (GL_SEPARABLE_2D = 0x8012).</summary>
        Separable2D = 0x8012,

        /// <summary>Extension alias for separable 2D (GL_SEPARABLE_2D_EXT = 0x8012).</summary>
        Separable2DExt = 0x8012,

        /// <summary>Histogram (GL_HISTOGRAM = 0x8024).</summary>
        Histogram = 0x8024,

        /// <summary>Extension alias for histogram (GL_HISTOGRAM_EXT = 0x8024).</summary>
        HistogramExt = 0x8024,

        /// <summary>Extension alias for minmax (GL_MINMAX_EXT = 0x802E).</summary>
        MinmaxExt = 0x802E,

        /// <summary>Polygon offset for fill mode (GL_POLYGON_OFFSET_FILL = 0x8037).</summary>
        PolygonOffsetFill = 0x8037,

        /// <summary>Extension alias for rescale normal (GL_RESCALE_NORMAL_EXT = 0x803A).</summary>
        RescaleNormalExt = 0x803A,

        /// <summary>Extension alias for 3D texture (GL_TEXTURE_3D_EXT = 0x806F).</summary>
        Texture3DExt = 0x806F,

        /// <summary>Vertex array (GL_VERTEX_ARRAY = 0x8074).</summary>
        VertexArray = 0x8074,

        /// <summary>Normal array (GL_NORMAL_ARRAY = 0x8075).</summary>
        NormalArray = 0x8075,

        /// <summary>Color array (GL_COLOR_ARRAY = 0x8076).</summary>
        ColorArray = 0x8076,

        /// <summary>Index array (GL_INDEX_ARRAY = 0x8077).</summary>
        IndexArray = 0x8077,

        /// <summary>Texture coordinate array (GL_TEXTURE_COORD_ARRAY = 0x8078).</summary>
        TextureCoordArray = 0x8078,

        /// <summary>Edge flag array (GL_EDGE_FLAG_ARRAY = 0x8079).</summary>
        EdgeFlagArray = 0x8079,

        /// <summary>Extension alias for interlace (GL_INTERLACE_SGIX = 0x8094).</summary>
        InterlaceSgix = 0x8094,

        /// <summary>Multisample rasterization (GL_MULTISAMPLE = 0x809D).</summary>
        Multisample = 0x809D,

        /// <summary>Sample alpha to coverage (GL_SAMPLE_ALPHA_TO_COVERAGE = 0x809E).</summary>
        SampleAlphaToCoverage = 0x809E,

        /// <summary>Extension alias for sample alpha to mask (GL_SAMPLE_ALPHA_TO_MASK_SGIS = 0x809E).</summary>
        SampleAlphaToMaskSgis = 0x809E,

        /// <summary>Sample alpha to one (GL_SAMPLE_ALPHA_TO_ONE = 0x809F).</summary>
        SampleAlphaToOne = 0x809F,

        /// <summary>Extension alias for sample alpha to one (GL_SAMPLE_ALPHA_TO_ONE_SGIS = 0x809F).</summary>
        SampleAlphaToOneSgis = 0x809F,

        /// <summary>Sample coverage (GL_SAMPLE_COVERAGE = 0x80A0).</summary>
        SampleCoverage = 0x80A0,

        /// <summary>Extension alias for sample mask (GL_SAMPLE_MASK_SGIS = 0x80A0).</summary>
        SampleMaskSgis = 0x80A0,

        /// <summary>Extension alias for texture color table (GL_TEXTURE_COLOR_TABLE_SGI = 0x80BC).</summary>
        TextureColorTableSgi = 0x80BC,

        /// <summary>Color table lookup (GL_COLOR_TABLE = 0x80D0).</summary>
        ColorTable = 0x80D0,

        /// <summary>Extension alias for color table (GL_COLOR_TABLE_SGI = 0x80D0).</summary>
        ColorTableSgi = 0x80D0,

        /// <summary>Post convolution color table (GL_POST_CONVOLUTION_COLOR_TABLE = 0x80D1).</summary>
        PostConvolutionColorTable = 0x80D1,

        /// <summary>Extension alias for post convolution color table (GL_POST_CONVOLUTION_COLOR_TABLE_SGI = 0x80D1).</summary>
        PostConvolutionColorTableSgi = 0x80D1,

        /// <summary>Post color matrix color table (GL_POST_COLOR_MATRIX_COLOR_TABLE = 0x80D2).</summary>
        PostColorMatrixColorTable = 0x80D2,

        /// <summary>Extension alias for post color matrix color table (GL_POST_COLOR_MATRIX_COLOR_TABLE_SGI = 0x80D2).</summary>
        PostColorMatrixColorTableSgi = 0x80D2,

        /// <summary>Extension alias for 4D texture (GL_TEXTURE_4D_SGIS = 0x8134).</summary>
        Texture4DSgis = 0x8134,

        /// <summary>Extension alias for tex gen (GL_TEX_GEN_SGIX = 0x8139).</summary>
        TexGenSgix = 0x8139,

        /// <summary>Extension alias for sprite (GL_SPRITE_SGIX = 0x8148).</summary>
        SpriteSgix = 0x8148,

        /// <summary>Extension alias for reference plane (GL_REFERENCE_PLANE_SGIX = 0x817D).</summary>
        ReferencePlaneSgix = 0x817D,

        /// <summary>Extension alias for IR instrument (GL_IR_INSTRUMENT1_SGIX = 0x817F).</summary>
        IrInstrument1Sgix = 0x817F,

        /// <summary>Extension alias for calligraphic fragment (GL_CALLIGRAPHIC_FRAGMENT_SGIX = 0x8183).</summary>
        CalligraphicFragmentSgix = 0x8183,

        /// <summary>Extension alias for framezoom (GL_FRAMEZOOM_SGIX = 0x818B).</summary>
        FramezoomSgix = 0x818B,

        /// <summary>Extension alias for fog offset (GL_FOG_OFFSET_SGIX = 0x8198).</summary>
        FogOffsetSgix = 0x8198,

        /// <summary>Extension alias for shared texture palette (GL_SHARED_TEXTURE_PALETTE_EXT = 0x81FB).</summary>
        SharedTexturePaletteExt = 0x81FB,

        /// <summary>Extension alias for async histogram (GL_ASYNC_HISTOGRAM_SGIX = 0x832C).</summary>
        AsyncHistogramSgix = 0x832C,

        /// <summary>Extension alias for pixel texture (GL_TEXTURE_SGIS = 0x8353).</summary>
        TextureSgis = 0x8353,

        /// <summary>Extension alias for async tex image (GL_ASYNC_TEX_IMAGE_SGIX = 0x835C).</summary>
        AsyncTexImageSgix = 0x835C,

        /// <summary>Extension alias for async draw pixels (GL_ASYNC_DRAW_PIXELS_SGIX = 0x835D).</summary>
        AsyncDrawPixelsSgix = 0x835D,

        /// <summary>Extension alias for async read pixels (GL_ASYNC_READ_PIXELS_SGIX = 0x835E).</summary>
        AsyncReadPixelsSgix = 0x835E,

        /// <summary>Extension alias for fragment lighting (GL_FRAGMENT_LIGHTING_SGIX = 0x8400).</summary>
        FragmentLightingSgix = 0x8400,

        /// <summary>Extension alias for fragment color material (GL_FRAGMENT_COLOR_MATERIAL_SGIX = 0x8401).</summary>
        FragmentColorMaterialSgix = 0x8401,

        /// <summary>Extension alias for fragment light 0 (GL_FRAGMENT_LIGHT0_SGIX = 0x840C).</summary>
        FragmentLight0Sgix = 0x840C,

        /// <summary>Extension alias for fragment light 1 (GL_FRAGMENT_LIGHT1_SGIX = 0x840D).</summary>
        FragmentLight1Sgix = 0x840D,

        /// <summary>Extension alias for fragment light 2 (GL_FRAGMENT_LIGHT2_SGIX = 0x840E).</summary>
        FragmentLight2Sgix = 0x840E,

        /// <summary>Extension alias for fragment light 3 (GL_FRAGMENT_LIGHT3_SGIX = 0x840F).</summary>
        FragmentLight3Sgix = 0x840F,

        /// <summary>Extension alias for fragment light 4 (GL_FRAGMENT_LIGHT4_SGIX = 0x8410).</summary>
        FragmentLight4Sgix = 0x8410,

        /// <summary>Extension alias for fragment light 5 (GL_FRAGMENT_LIGHT5_SGIX = 0x8411).</summary>
        FragmentLight5Sgix = 0x8411,

        /// <summary>Extension alias for fragment light 6 (GL_FRAGMENT_LIGHT6_SGIX = 0x8412).</summary>
        FragmentLight6Sgix = 0x8412,

        /// <summary>Extension alias for fragment light 7 (GL_FRAGMENT_LIGHT7_SGIX = 0x8413).</summary>
        FragmentLight7Sgix = 0x8413,

        /// <summary>Color sum (GL_COLOR_SUM = 0x8458).</summary>
        ColorSum = 0x8458,

        /// <summary>Secondary color array (GL_SECONDARY_COLOR_ARRAY = 0x845E).</summary>
        SecondaryColorArray = 0x845E,

        /// <summary>Cube map texturing (GL_TEXTURE_CUBE_MAP = 0x8513).</summary>
        TextureCubeMap = 0x8513,

        /// <summary>Program point size (GL_PROGRAM_POINT_SIZE = 0x8642).</summary>
        ProgramPointSize = 0x8642,

        /// <summary>Vertex program point size alias (GL_VERTEX_PROGRAM_POINT_SIZE = 0x8642).</summary>
        VertexProgramPointSize = 0x8642,

        /// <summary>Depth clamping (GL_DEPTH_CLAMP = 0x864F).</summary>
        DepthClamp = 0x864F,

        /// <summary>Seamless cube map filtering (GL_TEXTURE_CUBE_MAP_SEAMLESS = 0x884F).</summary>
        TextureCubeMapSeamless = 0x884F,

        /// <summary>Point sprite rendering (GL_POINT_SPRITE = 0x8861).</summary>
        PointSprite = 0x8861,

        /// <summary>Rasterizer discard (GL_RASTERIZER_DISCARD = 0x8C89).</summary>
        RasterizerDiscard = 0x8C89,

        /// <summary>sRGB framebuffer (GL_FRAMEBUFFER_SRGB = 0x8DB9).</summary>
        FramebufferSrgb = 0x8DB9,

        /// <summary>Sample mask for multisampling (GL_SAMPLE_MASK = 0x8E51).</summary>
        SampleMask = 0x8E51,

        /// <summary>Primitive restart (GL_PRIMITIVE_RESTART = 0x8F9D).</summary>
        PrimitiveRestart = 0x8F9D
    }
}
