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
    ///     The enable cap enum
    /// </summary>
    public enum EnableCap
    {
        /// <summary>
        ///     Enables line antialiasing smoothing (GL_LINE_SMOOTH)
        /// </summary>
        LineSmooth = 0x0B20,

        /// <summary>
        ///     Enables polygon antialiasing smoothing (GL_POLYGON_SMOOTH)
        /// </summary>
        PolygonSmooth = 0x0B41,

        /// <summary>
        ///     Enables face culling based on winding order (GL_CULL_FACE)
        /// </summary>
        CullFace = 0x0B44,

        /// <summary>
        ///     Enables depth buffer testing (GL_DEPTH_TEST)
        /// </summary>
        DepthTest = 0x0B71,

        /// <summary>
        ///     Enables stencil buffer testing (GL_STENCIL_TEST)
        /// </summary>
        StencilTest = 0x0B90,

        /// <summary>
        ///     Enables color dithering (GL_DITHER)
        /// </summary>
        Dither = 0x0BD0,

        /// <summary>
        ///     Enables blending of incoming fragment colors (GL_BLEND)
        /// </summary>
        Blend = 0x0BE2,

        /// <summary>
        ///     Enables per-index logical operations (GL_INDEX_LOGIC_OP)
        /// </summary>
        IndexLogicOp = 0x0BF1,

        /// <summary>
        ///     Enables per-color logical operations (GL_COLOR_LOGIC_OP)
        /// </summary>
        ColorLogicOp = 0x0BF2,

        /// <summary>
        ///     Enables scissor rectangle test (GL_SCISSOR_TEST)
        /// </summary>
        ScissorTest = 0x0C11,

        /// <summary>
        ///     Enables automatic normal vector generation (GL_AUTO_NORMAL)
        /// </summary>
        AutoNormal = 0x0D80,

        /// <summary>
        ///     Enables 1D evaluator for RGBA color mapping (GL_MAP1_COLOR_4)
        /// </summary>
        Map1Color4 = 0x0D90,

        /// <summary>
        ///     Enables 1D evaluator for color index mapping (GL_MAP1_INDEX)
        /// </summary>
        Map1Index = 0x0D91,

        /// <summary>
        ///     Enables 1D evaluator for normal vector mapping (GL_MAP1_NORMAL)
        /// </summary>
        Map1Normal = 0x0D92,

        /// <summary>
        ///     Enables 1D evaluator for S texture coordinate (GL_MAP1_TEXTURE_COORD_1)
        /// </summary>
        Map1TextureCoord1 = 0x0D93,

        /// <summary>
        ///     Enables 1D evaluator for S/T texture coordinates (GL_MAP1_TEXTURE_COORD_2)
        /// </summary>
        Map1TextureCoord2 = 0x0D94,

        /// <summary>
        ///     Enables 1D evaluator for S/T/R texture coordinates (GL_MAP1_TEXTURE_COORD_3)
        /// </summary>
        Map1TextureCoord3 = 0x0D95,

        /// <summary>
        ///     Enables 1D evaluator for S/T/R/Q texture coordinates (GL_MAP1_TEXTURE_COORD_4)
        /// </summary>
        Map1TextureCoord4 = 0x0D96,

        /// <summary>
        ///     Enables 1D evaluator for 3D vertex positions (GL_MAP1_VERTEX_3)
        /// </summary>
        Map1Vertex3 = 0x0D97,

        /// <summary>
        ///     Enables 1D evaluator for 4D vertex positions (GL_MAP1_VERTEX_4)
        /// </summary>
        Map1Vertex4 = 0x0D98,

        /// <summary>
        ///     Enables 2D evaluator for RGBA color mapping (GL_MAP2_COLOR_4)
        /// </summary>
        Map2Color4 = 0x0DB0,

        /// <summary>
        ///     Enables 2D evaluator for color index mapping (GL_MAP2_INDEX)
        /// </summary>
        Map2Index = 0x0DB1,

        /// <summary>
        ///     Enables 2D evaluator for normal vector mapping (GL_MAP2_NORMAL)
        /// </summary>
        Map2Normal = 0x0DB2,

        /// <summary>
        ///     Enables 2D evaluator for S texture coordinate (GL_MAP2_TEXTURE_COORD_1)
        /// </summary>
        Map2TextureCoord1 = 0x0DB3,

        /// <summary>
        ///     Enables 2D evaluator for S/T texture coordinates (GL_MAP2_TEXTURE_COORD_2)
        /// </summary>
        Map2TextureCoord2 = 0x0DB4,

        /// <summary>
        ///     Enables 2D evaluator for S/T/R texture coordinates (GL_MAP2_TEXTURE_COORD_3)
        /// </summary>
        Map2TextureCoord3 = 0x0DB5,

        /// <summary>
        ///     Enables 2D evaluator for S/T/R/Q texture coordinates (GL_MAP2_TEXTURE_COORD_4)
        /// </summary>
        Map2TextureCoord4 = 0x0DB6,

        /// <summary>
        ///     Enables 2D evaluator for 3D vertex positions (GL_MAP2_VERTEX_3)
        /// </summary>
        Map2Vertex3 = 0x0DB7,

        /// <summary>
        ///     Enables 2D evaluator for 4D vertex positions (GL_MAP2_VERTEX_4)
        /// </summary>
        Map2Vertex4 = 0x0DB8,

        /// <summary>
        ///     Enables 1D texturing (GL_TEXTURE_1D)
        /// </summary>
        Texture1D = 0x0DE0,

        /// <summary>
        ///     Enables 2D texturing (GL_TEXTURE_2D)
        /// </summary>
        Texture2D = 0x0DE1,

        /// <summary>
        ///     Enables polygon offset for point mode (GL_POLYGON_OFFSET_POINT)
        /// </summary>
        PolygonOffsetPoint = 0x2A01,

        /// <summary>
        ///     Enables polygon offset for line mode (GL_POLYGON_OFFSET_LINE)
        /// </summary>
        PolygonOffsetLine = 0x2A02,

        /// <summary>
        ///     Enables user-defined clipping plane 0 (GL_CLIP_PLANE0)
        /// </summary>
        ClipPlane0 = 0x3000,

        /// <summary>
        ///     Enables user-defined clipping plane 1 (GL_CLIP_PLANE1)
        /// </summary>
        ClipPlane1 = 0x3001,

        /// <summary>
        ///     Enables user-defined clipping plane 2 (GL_CLIP_PLANE2)
        /// </summary>
        ClipPlane2 = 0x3002,

        /// <summary>
        ///     Enables user-defined clipping plane 3 (GL_CLIP_PLANE3)
        /// </summary>
        ClipPlane3 = 0x3003,

        /// <summary>
        ///     Enables user-defined clipping plane 4 (GL_CLIP_PLANE4)
        /// </summary>
        ClipPlane4 = 0x3004,

        /// <summary>
        ///     Enables user-defined clipping plane 5 (GL_CLIP_PLANE5)
        /// </summary>
        ClipPlane5 = 0x3005,

        /// <summary>
        ///     Enables 1D convolution operations (GL_CONVOLUTION_1D)
        /// </summary>
        Convolution1D = 0x8010,

        /// <summary>
        ///     Enables 1D convolution operations, EXT version (GL_CONVOLUTION_1D_EXT)
        /// </summary>
        Convolution1DExt = 0x8010,

        /// <summary>
        ///     Enables 2D convolution operations (GL_CONVOLUTION_2D)
        /// </summary>
        Convolution2D = 0x8011,

        /// <summary>
        ///     Enables 2D convolution operations, EXT version (GL_CONVOLUTION_2D_EXT)
        /// </summary>
        Convolution2DExt = 0x8011,

        /// <summary>
        ///     Enables separable 2D convolution (GL_SEPARABLE_2D)
        /// </summary>
        Separable2D = 0x8012,

        /// <summary>
        ///     Enables separable 2D convolution, EXT version (GL_SEPARABLE_2D_EXT)
        /// </summary>
        Separable2DExt = 0x8012,

        /// <summary>
        ///     Enables histogram operations (GL_HISTOGRAM)
        /// </summary>
        Histogram = 0x8024,

        /// <summary>
        ///     Enables histogram operations, EXT version (GL_HISTOGRAM_EXT)
        /// </summary>
        HistogramExt = 0x8024,

        /// <summary>
        ///     Enables min/max computation, EXT version (GL_MINMAX_EXT)
        /// </summary>
        MinmaxExt = 0x802E,

        /// <summary>
        ///     Enables polygon offset for fill mode (GL_POLYGON_OFFSET_FILL)
        /// </summary>
        PolygonOffsetFill = 0x8037,

        /// <summary>
        ///     Enables rescaling of normal vectors, EXT (GL_RESCALE_NORMAL_EXT)
        /// </summary>
        RescaleNormalExt = 0x803A,

        /// <summary>
        ///     Enables 3D texturing, EXT version (GL_TEXTURE_3D_EXT)
        /// </summary>
        Texture3DExt = 0x806F,

        /// <summary>
        ///     Enables vertex array client state (GL_VERTEX_ARRAY)
        /// </summary>
        VertexArray = 0x8074,

        /// <summary>
        ///     Enables normal array client state (GL_NORMAL_ARRAY)
        /// </summary>
        NormalArray = 0x8075,

        /// <summary>
        ///     Enables color array client state (GL_COLOR_ARRAY)
        /// </summary>
        ColorArray = 0x8076,

        /// <summary>
        ///     Enables color index array client state (GL_INDEX_ARRAY)
        /// </summary>
        IndexArray = 0x8077,

        /// <summary>
        ///     Enables texture coordinate array client state (GL_TEXTURE_COORD_ARRAY)
        /// </summary>
        TextureCoordArray = 0x8078,

        /// <summary>
        ///     Enables edge flag array client state (GL_EDGE_FLAG_ARRAY)
        /// </summary>
        EdgeFlagArray = 0x8079,

        /// <summary>
        ///     Enables interlace readback, SGIX (GL_INTERLACE_SGIX)
        /// </summary>
        InterlaceSgix = 0x8094,

        /// <summary>
        ///     Enables multisample antialiasing (GL_MULTISAMPLE)
        /// </summary>
        Multisample = 0x809D,

        /// <summary>
        ///     Enables alpha-to-coverage multisample mode (GL_SAMPLE_ALPHA_TO_COVERAGE)
        /// </summary>
        SampleAlphaToCoverage = 0x809E,

        /// <summary>
        ///     Enables alpha-to-coverage multisample mode, SGIS (GL_SAMPLE_ALPHA_TO_MASK_SGIS)
        /// </summary>
        SampleAlphaToMaskSgis = 0x809E,

        /// <summary>
        ///     Enables alpha-to-one multisample mode (GL_SAMPLE_ALPHA_TO_ONE)
        /// </summary>
        SampleAlphaToOne = 0x809F,

        /// <summary>
        ///     Enables alpha-to-one multisample mode, SGIS (GL_SAMPLE_ALPHA_TO_ONE_SGIS)
        /// </summary>
        SampleAlphaToOneSgis = 0x809F,

        /// <summary>
        ///     Enables sample coverage for multisampling (GL_SAMPLE_COVERAGE)
        /// </summary>
        SampleCoverage = 0x80A0,

        /// <summary>
        ///     Enables sample mask for multisampling, SGIS (GL_SAMPLE_MASK_SGIS)
        /// </summary>
        SampleMaskSgis = 0x80A0,

        /// <summary>
        ///     Enables texture color table lookups, SGI (GL_TEXTURE_COLOR_TABLE_SGI)
        /// </summary>
        TextureColorTableSgi = 0x80BC,

        /// <summary>
        ///     Enables color table lookups (GL_COLOR_TABLE)
        /// </summary>
        ColorTable = 0x80D0,

        /// <summary>
        ///     Enables color table lookups, SGI version (GL_COLOR_TABLE_SGI)
        /// </summary>
        ColorTableSgi = 0x80D0,

        /// <summary>
        ///     Enables post-convolution color table (GL_POST_CONVOLUTION_COLOR_TABLE)
        /// </summary>
        PostConvolutionColorTable = 0x80D1,

        /// <summary>
        ///     Enables post-convolution color table, SGI (GL_POST_CONVOLUTION_COLOR_TABLE_SGI)
        /// </summary>
        PostConvolutionColorTableSgi = 0x80D1,

        /// <summary>
        ///     Enables post-color-matrix color table (GL_POST_COLOR_MATRIX_COLOR_TABLE)
        /// </summary>
        PostColorMatrixColorTable = 0x80D2,

        /// <summary>
        ///     Enables post-color-matrix color table, SGI (GL_POST_COLOR_MATRIX_COLOR_TABLE_SGI)
        /// </summary>
        PostColorMatrixColorTableSgi = 0x80D2,

        /// <summary>
        ///     Enables 4D texturing, SGIS (GL_TEXTURE_4D_SGIS)
        /// </summary>
        Texture4DSgis = 0x8134,

        /// <summary>
        ///     Enables pixel texture coordinate generation, SGIX (GL_PIXEL_TEX_GEN_SGIX)
        /// </summary>
        TexGenSgix = 0x8139,

        /// <summary>
        ///     Enables sprite point rendering, SGIX (GL_SPRITE_SGIX)
        /// </summary>
        SpriteSgix = 0x8148,

        /// <summary>
        ///     Enables reference plane for clipping, SGIX (GL_REFERENCE_PLANE_SGIX)
        /// </summary>
        ReferencePlaneSgix = 0x817D,

        /// <summary>
        ///     Enables infrared instrument, SGIX (GL_IR_INSTRUMENT1_SGIX)
        /// </summary>
        IrInstrument1Sgix = 0x817F,

        /// <summary>
        ///     Enables calligraphic fragment rendering, SGIX (GL_CALLIGRAPHIC_FRAGMENT_SGIX)
        /// </summary>
        CalligraphicFragmentSgix = 0x8183,

        /// <summary>
        ///     Enables frame zoom, SGIX (GL_FRAMEZOOM_SGIX)
        /// </summary>
        FramezoomSgix = 0x818B,

        /// <summary>
        ///     Enables fog offset calculation, SGIX (GL_FOG_OFFSET_SGIX)
        /// </summary>
        FogOffsetSgix = 0x8198,

        /// <summary>
        ///     Enables shared texture palette, EXT (GL_SHARED_TEXTURE_PALETTE_EXT)
        /// </summary>
        SharedTexturePaletteExt = 0x81FB,

        /// <summary>
        ///     Enables asynchronous histogram operations, SGIX (GL_ASYNC_HISTOGRAM_SGIX)
        /// </summary>
        AsyncHistogramSgix = 0x832C,

        /// <summary>
        ///     Enables pixel texture, SGIS (GL_PIXEL_TEXTURE_SGIS)
        /// </summary>
        TextureSgis = 0x8353,

        /// <summary>
        ///     Enables asynchronous texture image loading, SGIX (GL_ASYNC_TEX_IMAGE_SGIX)
        /// </summary>
        AsyncTexImageSgix = 0x835C,

        /// <summary>
        ///     Enables asynchronous draw pixels, SGIX (GL_ASYNC_DRAW_PIXELS_SGIX)
        /// </summary>
        AsyncDrawPixelsSgix = 0x835D,

        /// <summary>
        ///     Enables asynchronous read pixels, SGIX (GL_ASYNC_READ_PIXELS_SGIX)
        /// </summary>
        AsyncReadPixelsSgix = 0x835E,

        /// <summary>
        ///     Enables per-fragment lighting, SGIX (GL_FRAGMENT_LIGHTING_SGIX)
        /// </summary>
        FragmentLightingSgix = 0x8400,

        /// <summary>
        ///     Enables fragment color material tracking, SGIX (GL_FRAGMENT_COLOR_MATERIAL_SGIX)
        /// </summary>
        FragmentColorMaterialSgix = 0x8401,

        /// <summary>
        ///     Enables fragment light source 0, SGIX (GL_FRAGMENT_LIGHT0_SGIX)
        /// </summary>
        FragmentLight0Sgix = 0x840C,

        /// <summary>
        ///     Enables fragment light source 1, SGIX (GL_FRAGMENT_LIGHT1_SGIX)
        /// </summary>
        FragmentLight1Sgix = 0x840D,

        /// <summary>
        ///     Enables fragment light source 2, SGIX (GL_FRAGMENT_LIGHT2_SGIX)
        /// </summary>
        FragmentLight2Sgix = 0x840E,

        /// <summary>
        ///     Enables fragment light source 3, SGIX (GL_FRAGMENT_LIGHT3_SGIX)
        /// </summary>
        FragmentLight3Sgix = 0x840F,

        /// <summary>
        ///     Enables fragment light source 4, SGIX (GL_FRAGMENT_LIGHT4_SGIX)
        /// </summary>
        FragmentLight4Sgix = 0x8410,

        /// <summary>
        ///     Enables fragment light source 5, SGIX (GL_FRAGMENT_LIGHT5_SGIX)
        /// </summary>
        FragmentLight5Sgix = 0x8411,

        /// <summary>
        ///     Enables fragment light source 6, SGIX (GL_FRAGMENT_LIGHT6_SGIX)
        /// </summary>
        FragmentLight6Sgix = 0x8412,

        /// <summary>
        ///     Enables fragment light source 7, SGIX (GL_FRAGMENT_LIGHT7_SGIX)
        /// </summary>
        FragmentLight7Sgix = 0x8413,

        /// <summary>
        ///     Enables secondary color summation (GL_COLOR_SUM)
        /// </summary>
        ColorSum = 0x8458,

        /// <summary>
        ///     Enables secondary color array client state (GL_SECONDARY_COLOR_ARRAY)
        /// </summary>
        SecondaryColorArray = 0x845E,

        /// <summary>
        ///     Enables cube map texturing (GL_TEXTURE_CUBE_MAP)
        /// </summary>
        TextureCubeMap = 0x8513,

        /// <summary>
        ///     Enables program-defined point size (GL_PROGRAM_POINT_SIZE)
        /// </summary>
        ProgramPointSize = 0x8642,

        /// <summary>
        ///     Enables vertex program point size control (GL_VERTEX_PROGRAM_POINT_SIZE)
        /// </summary>
        VertexProgramPointSize = 0x8642,

        /// <summary>
        ///     Enables depth value clamping (GL_DEPTH_CLAMP)
        /// </summary>
        DepthClamp = 0x864F,

        /// <summary>
        ///     Enables seamless cube map filtering (GL_TEXTURE_CUBE_MAP_SEAMLESS)
        /// </summary>
        TextureCubeMapSeamless = 0x884F,

        /// <summary>
        ///     Enables point sprite rendering (GL_POINT_SPRITE)
        /// </summary>
        PointSprite = 0x8861,

        /// <summary>
        ///     Enables rasterizer discard, skipping fragment processing (GL_RASTERIZER_DISCARD)
        /// </summary>
        RasterizerDiscard = 0x8C89,

        /// <summary>
        ///     Enables sRGB framebuffer conversion (GL_FRAMEBUFFER_SRGB)
        /// </summary>
        FramebufferSrgb = 0x8DB9,

        /// <summary>
        ///     Enables sample mask for multisampling (GL_SAMPLE_MASK)
        /// </summary>
        SampleMask = 0x8E51,

        /// <summary>
        ///     Enables primitive restart for indexed drawing (GL_PRIMITIVE_RESTART)
        /// </summary>
        PrimitiveRestart = 0x8F9D
    }
}