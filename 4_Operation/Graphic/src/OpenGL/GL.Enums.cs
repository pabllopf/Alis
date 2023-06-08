// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GL.Enums.cs
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

namespace Alis.Core.Graphic.OpenGL
{
    /// <summary>
    ///     The gl class
    /// </summary>
    public static partial class Gl
    {
        /// <summary>
        ///     The active attrib type enum
        /// </summary>
        public enum ActiveAttribType
        {
            /// <summary>
            ///     The float active attrib type
            /// </summary>
            Float = 0x1406,

            /// <summary>
            ///     The float vec active attrib type
            /// </summary>
            FloatVec2 = 0x8B50,

            /// <summary>
            ///     The float vec active attrib type
            /// </summary>
            FloatVec3 = 0x8B51,

            /// <summary>
            ///     The float vec active attrib type
            /// </summary>
            FloatVec4 = 0x8B52,

            /// <summary>
            ///     The float mat active attrib type
            /// </summary>
            FloatMat2 = 0x8B5A,

            /// <summary>
            ///     The float mat active attrib type
            /// </summary>
            FloatMat3 = 0x8B5B,

            /// <summary>
            ///     The float mat active attrib type
            /// </summary>
            FloatMat4 = 0x8B5C
        }

        /// <summary>
        ///     The active uniform type enum
        /// </summary>
        public enum ActiveUniformType
        {
            /// <summary>
            ///     The int active uniform type
            /// </summary>
            Int = 0x1404,

            /// <summary>
            ///     The float active uniform type
            /// </summary>
            Float = 0x1406,

            /// <summary>
            ///     The float vec active uniform type
            /// </summary>
            FloatVec2 = 0x8B50,

            /// <summary>
            ///     The float vec active uniform type
            /// </summary>
            FloatVec3 = 0x8B51,

            /// <summary>
            ///     The float vec active uniform type
            /// </summary>
            FloatVec4 = 0x8B52,

            /// <summary>
            ///     The int vec active uniform type
            /// </summary>
            IntVec2 = 0x8B53,

            /// <summary>
            ///     The int vec active uniform type
            /// </summary>
            IntVec3 = 0x8B54,

            /// <summary>
            ///     The int vec active uniform type
            /// </summary>
            IntVec4 = 0x8B55,

            /// <summary>
            ///     The bool active uniform type
            /// </summary>
            Bool = 0x8B56,

            /// <summary>
            ///     The bool vec active uniform type
            /// </summary>
            BoolVec2 = 0x8B57,

            /// <summary>
            ///     The bool vec active uniform type
            /// </summary>
            BoolVec3 = 0x8B58,

            /// <summary>
            ///     The bool vec active uniform type
            /// </summary>
            BoolVec4 = 0x8B59,

            /// <summary>
            ///     The float mat active uniform type
            /// </summary>
            FloatMat2 = 0x8B5A,

            /// <summary>
            ///     The float mat active uniform type
            /// </summary>
            FloatMat3 = 0x8B5B,

            /// <summary>
            ///     The float mat active uniform type
            /// </summary>
            FloatMat4 = 0x8B5C,

            /// <summary>
            ///     The sampler active uniform type
            /// </summary>
            Sampler1D = 0x8B5D,

            /// <summary>
            ///     The sampler active uniform type
            /// </summary>
            Sampler2D = 0x8B5E,

            /// <summary>
            ///     The sampler active uniform type
            /// </summary>
            Sampler3D = 0x8B5F,

            /// <summary>
            ///     The sampler cube active uniform type
            /// </summary>
            SamplerCube = 0x8B60,

            /// <summary>
            ///     The sampler shadow active uniform type
            /// </summary>
            Sampler1DShadow = 0x8B61,

            /// <summary>
            ///     The sampler shadow active uniform type
            /// </summary>
            Sampler2DShadow = 0x8B62,

            /// <summary>
            ///     The sampler rect active uniform type
            /// </summary>
            Sampler2DRect = 0x8B63,

            /// <summary>
            ///     The sampler rect shadow active uniform type
            /// </summary>
            Sampler2DRectShadow = 0x8B64,

            /// <summary>
            ///     The float mat 2x active uniform type
            /// </summary>
            FloatMat2X3 = 0x8B65,

            /// <summary>
            ///     The float mat 2x active uniform type
            /// </summary>
            FloatMat2X4 = 0x8B66,

            /// <summary>
            ///     The float mat 3x active uniform type
            /// </summary>
            FloatMat3X2 = 0x8B67,

            /// <summary>
            ///     The float mat 3x active uniform type
            /// </summary>
            FloatMat3X4 = 0x8B68,

            /// <summary>
            ///     The float mat 4x active uniform type
            /// </summary>
            FloatMat4X2 = 0x8B69,

            /// <summary>
            ///     The float mat 4x active uniform type
            /// </summary>
            FloatMat4X3 = 0x8B6A,

            /// <summary>
            ///     The sampler array active uniform type
            /// </summary>
            Sampler1DArray = 0x8DC0,

            /// <summary>
            ///     The sampler array active uniform type
            /// </summary>
            Sampler2DArray = 0x8DC1,

            /// <summary>
            ///     The sampler buffer active uniform type
            /// </summary>
            SamplerBuffer = 0x8DC2,

            /// <summary>
            ///     The sampler array shadow active uniform type
            /// </summary>
            Sampler1DArrayShadow = 0x8DC3,

            /// <summary>
            ///     The sampler array shadow active uniform type
            /// </summary>
            Sampler2DArrayShadow = 0x8DC4,

            /// <summary>
            ///     The sampler cube shadow active uniform type
            /// </summary>
            SamplerCubeShadow = 0x8DC5,

            /// <summary>
            ///     The unsigned int vec active uniform type
            /// </summary>
            UnsignedIntVec2 = 0x8DC6,

            /// <summary>
            ///     The unsigned int vec active uniform type
            /// </summary>
            UnsignedIntVec3 = 0x8DC7,

            /// <summary>
            ///     The unsigned int vec active uniform type
            /// </summary>
            UnsignedIntVec4 = 0x8DC8,

            /// <summary>
            ///     The int sampler active uniform type
            /// </summary>
            IntSampler1D = 0x8DC9,

            /// <summary>
            ///     The int sampler active uniform type
            /// </summary>
            IntSampler2D = 0x8DCA,

            /// <summary>
            ///     The int sampler active uniform type
            /// </summary>
            IntSampler3D = 0x8DCB,

            /// <summary>
            ///     The int sampler cube active uniform type
            /// </summary>
            IntSamplerCube = 0x8DCC,

            /// <summary>
            ///     The int sampler rect active uniform type
            /// </summary>
            IntSampler2DRect = 0x8DCD,

            /// <summary>
            ///     The int sampler array active uniform type
            /// </summary>
            IntSampler1DArray = 0x8DCE,

            /// <summary>
            ///     The int sampler array active uniform type
            /// </summary>
            IntSampler2DArray = 0x8DCF,

            /// <summary>
            ///     The int sampler buffer active uniform type
            /// </summary>
            IntSamplerBuffer = 0x8DD0,

            /// <summary>
            ///     The unsigned int sampler active uniform type
            /// </summary>
            UnsignedIntSampler1D = 0x8DD1,

            /// <summary>
            ///     The unsigned int sampler active uniform type
            /// </summary>
            UnsignedIntSampler2D = 0x8DD2,

            /// <summary>
            ///     The unsigned int sampler active uniform type
            /// </summary>
            UnsignedIntSampler3D = 0x8DD3,

            /// <summary>
            ///     The unsigned int sampler cube active uniform type
            /// </summary>
            UnsignedIntSamplerCube = 0x8DD4,

            /// <summary>
            ///     The unsigned int sampler rect active uniform type
            /// </summary>
            UnsignedIntSampler2DRect = 0x8DD5,

            /// <summary>
            ///     The unsigned int sampler array active uniform type
            /// </summary>
            UnsignedIntSampler1DArray = 0x8DD6,

            /// <summary>
            ///     The unsigned int sampler array active uniform type
            /// </summary>
            UnsignedIntSampler2DArray = 0x8DD7,

            /// <summary>
            ///     The unsigned int sampler buffer active uniform type
            /// </summary>
            UnsignedIntSamplerBuffer = 0x8DD8,

            /// <summary>
            ///     The sampler multisample active uniform type
            /// </summary>
            Sampler2DMultisample = 0x9108,

            /// <summary>
            ///     The int sampler multisample active uniform type
            /// </summary>
            IntSampler2DMultisample = 0x9109,

            /// <summary>
            ///     The unsigned int sampler multisample active uniform type
            /// </summary>
            UnsignedIntSampler2DMultisample = 0x910A,

            /// <summary>
            ///     The sampler multisample array active uniform type
            /// </summary>
            Sampler2DMultisampleArray = 0x910B,

            /// <summary>
            ///     The int sampler multisample array active uniform type
            /// </summary>
            IntSampler2DMultisampleArray = 0x910C,

            /// <summary>
            ///     The unsigned int sampler multisample array active uniform type
            /// </summary>
            UnsignedIntSampler2DMultisampleArray = 0x910D
        }

        /// <summary>
        ///     The begin mode enum
        /// </summary>
        public enum BeginMode
        {
            /// <summary>
            ///     The points begin mode
            /// </summary>
            Points = 0x0000,

            /// <summary>
            ///     The lines begin mode
            /// </summary>
            Lines = 0x0001,

            /// <summary>
            ///     The line loop begin mode
            /// </summary>
            LineLoop = 0x0002,

            /// <summary>
            ///     The line strip begin mode
            /// </summary>
            LineStrip = 0x0003,

            /// <summary>
            ///     The triangles begin mode
            /// </summary>
            Triangles = 0x0004,

            /// <summary>
            ///     The triangle strip begin mode
            /// </summary>
            TriangleStrip = 0x0005,

            /// <summary>
            ///     The triangle fan begin mode
            /// </summary>
            TriangleFan = 0x0006,

            /// <summary>
            ///     The lines adjacency begin mode
            /// </summary>
            LinesAdjacency = 0xA,

            /// <summary>
            ///     The line strip adjacency begin mode
            /// </summary>
            LineStripAdjacency = 0xB,

            /// <summary>
            ///     The triangles adjacency begin mode
            /// </summary>
            TrianglesAdjacency = 0xC,

            /// <summary>
            ///     The triangle strip adjacency begin mode
            /// </summary>
            TriangleStripAdjacency = 0xD,

            /// <summary>
            ///     The patches begin mode
            /// </summary>
            Patches = 0xE,

            /// <summary>
            ///     The quads begin mode
            /// </summary>
            [Obsolete("OpenGL 4 Core does not support quads.")]
            Quads = 0x0007,

            /// <summary>
            ///     The quad strip begin mode
            /// </summary>
            [Obsolete("OpenGL 4 Core does not support quads.")]
            QuadStrip = 0x0008
        }

        /// <summary>
        ///     The blend equation mode enum
        /// </summary>
        public enum BlendEquationMode
        {
            /// <summary>
            ///     The func add blend equation mode
            /// </summary>
            FuncAdd = 0x8006,

            /// <summary>
            ///     The min blend equation mode
            /// </summary>
            Min = 0x8007,

            /// <summary>
            ///     The max blend equation mode
            /// </summary>
            Max = 0x8008,

            /// <summary>
            ///     The func subtract blend equation mode
            /// </summary>
            FuncSubtract = 0x800A,

            /// <summary>
            ///     The func reverse subtract blend equation mode
            /// </summary>
            FuncReverseSubtract = 0x800B
        }

        /// <summary>
        ///     The blending factor dest enum
        /// </summary>
        public enum BlendingFactorDest
        {
            /// <summary>
            ///     The zero blending factor dest
            /// </summary>
            Zero = 0,

            /// <summary>
            ///     The src color blending factor dest
            /// </summary>
            SrcColor = 0x0300,

            /// <summary>
            ///     The one minus src color blending factor dest
            /// </summary>
            OneMinusSrcColor = 0x0301,

            /// <summary>
            ///     The src alpha blending factor dest
            /// </summary>
            SrcAlpha = 0x0302,

            /// <summary>
            ///     The one minus src alpha blending factor dest
            /// </summary>
            OneMinusSrcAlpha = 0x0303,

            /// <summary>
            ///     The dst alpha blending factor dest
            /// </summary>
            DstAlpha = 0x0304,

            /// <summary>
            ///     The one minus dst alpha blending factor dest
            /// </summary>
            OneMinusDstAlpha = 0x0305,

            /// <summary>
            ///     The dst color blending factor dest
            /// </summary>
            DstColor = 0x0306,

            /// <summary>
            ///     The one minus dst color blending factor dest
            /// </summary>
            OneMinusDstColor = 0x0307,

            /// <summary>
            ///     The constant color blending factor dest
            /// </summary>
            ConstantColor = 0x8001,

            /// <summary>
            ///     The constant color ext blending factor dest
            /// </summary>
            ConstantColorExt = 0x8001,

            /// <summary>
            ///     The one minus constant color blending factor dest
            /// </summary>
            OneMinusConstantColor = 0x8002,

            /// <summary>
            ///     The one minus constant color ext blending factor dest
            /// </summary>
            OneMinusConstantColorExt = 0x8002,

            /// <summary>
            ///     The constant alpha blending factor dest
            /// </summary>
            ConstantAlpha = 0x8003,

            /// <summary>
            ///     The constant alpha ext blending factor dest
            /// </summary>
            ConstantAlphaExt = 0x8003,

            /// <summary>
            ///     The one minus constant alpha blending factor dest
            /// </summary>
            OneMinusConstantAlpha = 0x8004,

            /// <summary>
            ///     The one minus constant alpha ext blending factor dest
            /// </summary>
            OneMinusConstantAlphaExt = 0x8004,

            /// <summary>
            ///     The one blending factor dest
            /// </summary>
            One = 1
        }

        /// <summary>
        ///     The blending factor src enum
        /// </summary>
        public enum BlendingFactorSrc
        {
            /// <summary>
            ///     The zero blending factor src
            /// </summary>
            Zero = 0,

            /// <summary>
            ///     The src alpha blending factor src
            /// </summary>
            SrcAlpha = 0x0302,

            /// <summary>
            ///     The one minus src alpha blending factor src
            /// </summary>
            OneMinusSrcAlpha = 0x0303,

            /// <summary>
            ///     The dst alpha blending factor src
            /// </summary>
            DstAlpha = 0x0304,

            /// <summary>
            ///     The one minus dst alpha blending factor src
            /// </summary>
            OneMinusDstAlpha = 0x0305,

            /// <summary>
            ///     The dst color blending factor src
            /// </summary>
            DstColor = 0x0306,

            /// <summary>
            ///     The one minus dst color blending factor src
            /// </summary>
            OneMinusDstColor = 0x0307,

            /// <summary>
            ///     The src alpha saturate blending factor src
            /// </summary>
            SrcAlphaSaturate = 0x0308,

            /// <summary>
            ///     The constant color blending factor src
            /// </summary>
            ConstantColor = 0x8001,

            /// <summary>
            ///     The constant color ext blending factor src
            /// </summary>
            ConstantColorExt = 0x8001,

            /// <summary>
            ///     The one minus constant color blending factor src
            /// </summary>
            OneMinusConstantColor = 0x8002,

            /// <summary>
            ///     The one minus constant color ext blending factor src
            /// </summary>
            OneMinusConstantColorExt = 0x8002,

            /// <summary>
            ///     The constant alpha blending factor src
            /// </summary>
            ConstantAlpha = 0x8003,

            /// <summary>
            ///     The constant alpha ext blending factor src
            /// </summary>
            ConstantAlphaExt = 0x8003,

            /// <summary>
            ///     The one minus constant alpha blending factor src
            /// </summary>
            OneMinusConstantAlpha = 0x8004,

            /// <summary>
            ///     The one minus constant alpha ext blending factor src
            /// </summary>
            OneMinusConstantAlphaExt = 0x8004,

            /// <summary>
            ///     The one blending factor src
            /// </summary>
            One = 1
        }

        /// <summary>
        ///     The buffer target enum
        /// </summary>
        public enum BufferTarget
        {
            /// <summary>
            ///     The array buffer buffer target
            /// </summary>
            ArrayBuffer = 0x8892,

            /// <summary>
            ///     The element array buffer buffer target
            /// </summary>
            ElementArrayBuffer = 0x8893,

            /// <summary>
            ///     The pixel pack buffer buffer target
            /// </summary>
            PixelPackBuffer = 0x88EB,

            /// <summary>
            ///     The pixel unpack buffer buffer target
            /// </summary>
            PixelUnpackBuffer = 0x88EC,

            /// <summary>
            ///     The uniform buffer buffer target
            /// </summary>
            UniformBuffer = 0x8A11,

            /// <summary>
            ///     The texture buffer buffer target
            /// </summary>
            TextureBuffer = 0x8C2A,

            /// <summary>
            ///     The transform feedback buffer buffer target
            /// </summary>
            TransformFeedbackBuffer = 0x8C8E,

            /// <summary>
            ///     The copy read buffer buffer target
            /// </summary>
            CopyReadBuffer = 0x8F36,

            /// <summary>
            ///     The copy write buffer buffer target
            /// </summary>
            CopyWriteBuffer = 0x8F37,

            /// <summary>
            ///     The draw indirect buffer buffer target
            /// </summary>
            DrawIndirectBuffer = 0x8F3F,

            /// <summary>
            ///     The atomic counter buffer buffer target
            /// </summary>
            AtomicCounterBuffer = 0x92C0,

            /// <summary>
            ///     The dispatch indirect buffer buffer target
            /// </summary>
            DispatchIndirectBuffer = 0x90EE,

            /// <summary>
            ///     The query buffer buffer target
            /// </summary>
            QueryBuffer = 0x9192,

            /// <summary>
            ///     The shader storage buffer buffer target
            /// </summary>
            ShaderStorageBuffer = 0x90D2
        }

        /// <summary>
        ///     The buffer usage hint enum
        /// </summary>
        public enum BufferUsageHint
        {
            /// <summary>
            ///     The stream draw buffer usage hint
            /// </summary>
            StreamDraw = 0x88E0,

            /// <summary>
            ///     The stream read buffer usage hint
            /// </summary>
            StreamRead = 0x88E1,

            /// <summary>
            ///     The stream copy buffer usage hint
            /// </summary>
            StreamCopy = 0x88E2,

            /// <summary>
            ///     The static draw buffer usage hint
            /// </summary>
            StaticDraw = 0x88E4,

            /// <summary>
            ///     The static read buffer usage hint
            /// </summary>
            StaticRead = 0x88E5,

            /// <summary>
            ///     The static copy buffer usage hint
            /// </summary>
            StaticCopy = 0x88E6,

            /// <summary>
            ///     The dynamic draw buffer usage hint
            /// </summary>
            DynamicDraw = 0x88E8,

            /// <summary>
            ///     The dynamic read buffer usage hint
            /// </summary>
            DynamicRead = 0x88E9,

            /// <summary>
            ///     The dynamic copy buffer usage hint
            /// </summary>
            DynamicCopy = 0x88EA
        }

        /// <summary>
        ///     The clear buffer mask enum
        /// </summary>
        [Flags]
        public enum ClearBufferMask
        {
            /// <summary>
            ///     The depth buffer bit clear buffer mask
            /// </summary>
            DepthBufferBit = 0x00000100,

            /// <summary>
            ///     The accum buffer bit clear buffer mask
            /// </summary>
            AccumBufferBit = 0x00000200,

            /// <summary>
            ///     The stencil buffer bit clear buffer mask
            /// </summary>
            StencilBufferBit = 0x00000400,

            /// <summary>
            ///     The color buffer bit clear buffer mask
            /// </summary>
            ColorBufferBit = 0x00004000
        }

        /// <summary>
        ///     The draw elements type enum
        /// </summary>
        public enum DrawElementsType
        {
            /// <summary>
            ///     The unsigned byte draw elements type
            /// </summary>
            UnsignedByte = 0x1401,

            /// <summary>
            ///     The unsigned short draw elements type
            /// </summary>
            UnsignedShort = 0x1403,

            /// <summary>
            ///     The unsigned int draw elements type
            /// </summary>
            UnsignedInt = 0x1405
        }

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
            PixelTexGenSgix = 0x8139,

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
            PixelTextureSgis = 0x8353,

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

        /// <summary>
        ///     The pixel format enum
        /// </summary>
        public enum PixelFormat
        {
            /// <summary>
            ///     The color index pixel format
            /// </summary>
            ColorIndex = 0x1900,

            /// <summary>
            ///     The stencil index pixel format
            /// </summary>
            StencilIndex = 0x1901,

            /// <summary>
            ///     The depth component pixel format
            /// </summary>
            DepthComponent = 0x1902,

            /// <summary>
            ///     The red pixel format
            /// </summary>
            Red = 0x1903,

            /// <summary>
            ///     The green pixel format
            /// </summary>
            Green = 0x1904,

            /// <summary>
            ///     The blue pixel format
            /// </summary>
            Blue = 0x1905,

            /// <summary>
            ///     The alpha pixel format
            /// </summary>
            Alpha = 0x1906,

            /// <summary>
            ///     The rgb pixel format
            /// </summary>
            Rgb = 0x1907,

            /// <summary>
            ///     The rgba pixel format
            /// </summary>
            Rgba = 0x1908,

            /// <summary>
            ///     The luminance pixel format
            /// </summary>
            Luminance = 0x1909,

            /// <summary>
            ///     The luminance alpha pixel format
            /// </summary>
            LuminanceAlpha = 0x190A,

            /// <summary>
            ///     The abgr ext pixel format
            /// </summary>
            AbgrExt = 0x8000,

            /// <summary>
            ///     The cmyk ext pixel format
            /// </summary>
            CmykExt = 0x800C,

            /// <summary>
            ///     The cmyka ext pixel format
            /// </summary>
            CmykaExt = 0x800D,

            /// <summary>
            ///     The bgr pixel format
            /// </summary>
            Bgr = 0x80E0,

            /// <summary>
            ///     The bgra pixel format
            /// </summary>
            Bgra = 0x80E1,

            /// <summary>
            ///     The ycrcb 422 sgix pixel format
            /// </summary>
            Ycrcb422Sgix = 0x81BB,

            /// <summary>
            ///     The ycrcb 444 sgix pixel format
            /// </summary>
            Ycrcb444Sgix = 0x81BC,

            /// <summary>
            ///     The rg pixel format
            /// </summary>
            Rg = 0x8227,

            /// <summary>
            ///     The rg integer pixel format
            /// </summary>
            RgInteger = 0x8228,

            /// <summary>
            ///     The depth stencil pixel format
            /// </summary>
            DepthStencil = 0x84F9,

            /// <summary>
            ///     The red integer pixel format
            /// </summary>
            RedInteger = 0x8D94,

            /// <summary>
            ///     The green integer pixel format
            /// </summary>
            GreenInteger = 0x8D95,

            /// <summary>
            ///     The blue integer pixel format
            /// </summary>
            BlueInteger = 0x8D96,

            /// <summary>
            ///     The alpha integer pixel format
            /// </summary>
            AlphaInteger = 0x8D97,

            /// <summary>
            ///     The rgb integer pixel format
            /// </summary>
            RgbInteger = 0x8D98,

            /// <summary>
            ///     The rgba integer pixel format
            /// </summary>
            RgbaInteger = 0x8D99,

            /// <summary>
            ///     The bgr integer pixel format
            /// </summary>
            BgrInteger = 0x8D9A,

            /// <summary>
            ///     The bgra integer pixel format
            /// </summary>
            BgraInteger = 0x8D9B
        }

        /// <summary>
        ///     The pixel internal format enum
        /// </summary>
        public enum PixelInternalFormat
        {
            /// <summary>
            ///     The depth component pixel internal format
            /// </summary>
            DepthComponent = 0x1902,

            /// <summary>
            ///     The alpha pixel internal format
            /// </summary>
            Alpha = 0x1906,

            /// <summary>
            ///     The rgb pixel internal format
            /// </summary>
            Rgb = 0x1907,

            /// <summary>
            ///     The rgba pixel internal format
            /// </summary>
            Rgba = 0x1908,

            /// <summary>
            ///     The luminance pixel internal format
            /// </summary>
            Luminance = 0x1909,

            /// <summary>
            ///     The luminance alpha pixel internal format
            /// </summary>
            LuminanceAlpha = 0x190A,

            /// <summary>
            ///     The  pixel internal format
            /// </summary>
            R3G3B2 = 0x2A10,

            /// <summary>
            ///     The alpha pixel internal format
            /// </summary>
            Alpha4 = 0x803B,

            /// <summary>
            ///     The alpha pixel internal format
            /// </summary>
            Alpha8 = 0x803C,

            /// <summary>
            ///     The alpha 12 pixel internal format
            /// </summary>
            Alpha12 = 0x803D,

            /// <summary>
            ///     The alpha 16 pixel internal format
            /// </summary>
            Alpha16 = 0x803E,

            /// <summary>
            ///     The luminance pixel internal format
            /// </summary>
            Luminance4 = 0x803F,

            /// <summary>
            ///     The luminance pixel internal format
            /// </summary>
            Luminance8 = 0x8040,

            /// <summary>
            ///     The luminance 12 pixel internal format
            /// </summary>
            Luminance12 = 0x8041,

            /// <summary>
            ///     The luminance 16 pixel internal format
            /// </summary>
            Luminance16 = 0x8042,

            /// <summary>
            ///     The luminance alpha pixel internal format
            /// </summary>
            Luminance4Alpha4 = 0x8043,

            /// <summary>
            ///     The luminance alpha pixel internal format
            /// </summary>
            Luminance6Alpha2 = 0x8044,

            /// <summary>
            ///     The luminance alpha pixel internal format
            /// </summary>
            Luminance8Alpha8 = 0x8045,

            /// <summary>
            ///     The luminance 12 alpha pixel internal format
            /// </summary>
            Luminance12Alpha4 = 0x8046,

            /// <summary>
            ///     The luminance 12 alpha 12 pixel internal format
            /// </summary>
            Luminance12Alpha12 = 0x8047,

            /// <summary>
            ///     The luminance 16 alpha 16 pixel internal format
            /// </summary>
            Luminance16Alpha16 = 0x8048,

            /// <summary>
            ///     The intensity pixel internal format
            /// </summary>
            Intensity = 0x8049,

            /// <summary>
            ///     The intensity pixel internal format
            /// </summary>
            Intensity4 = 0x804A,

            /// <summary>
            ///     The intensity pixel internal format
            /// </summary>
            Intensity8 = 0x804B,

            /// <summary>
            ///     The intensity 12 pixel internal format
            /// </summary>
            Intensity12 = 0x804C,

            /// <summary>
            ///     The intensity 16 pixel internal format
            /// </summary>
            Intensity16 = 0x804D,

            /// <summary>
            ///     The rgb ext pixel internal format
            /// </summary>
            Rgb2Ext = 0x804E,

            /// <summary>
            ///     The rgb pixel internal format
            /// </summary>
            Rgb4 = 0x804F,

            /// <summary>
            ///     The rgb pixel internal format
            /// </summary>
            Rgb5 = 0x8050,

            /// <summary>
            ///     The rgb pixel internal format
            /// </summary>
            Rgb8 = 0x8051,

            /// <summary>
            ///     The rgb 10 pixel internal format
            /// </summary>
            Rgb10 = 0x8052,

            /// <summary>
            ///     The rgb 12 pixel internal format
            /// </summary>
            Rgb12 = 0x8053,

            /// <summary>
            ///     The rgb 16 pixel internal format
            /// </summary>
            Rgb16 = 0x8054,

            /// <summary>
            ///     The rgba pixel internal format
            /// </summary>
            Rgba2 = 0x8055,

            /// <summary>
            ///     The rgba pixel internal format
            /// </summary>
            Rgba4 = 0x8056,

            /// <summary>
            ///     The rgb pixel internal format
            /// </summary>
            Rgb5A1 = 0x8057,

            /// <summary>
            ///     The rgba pixel internal format
            /// </summary>
            Rgba8 = 0x8058,

            /// <summary>
            ///     The rgb 10 pixel internal format
            /// </summary>
            Rgb10A2 = 0x8059,

            /// <summary>
            ///     The rgba 12 pixel internal format
            /// </summary>
            Rgba12 = 0x805A,

            /// <summary>
            ///     The rgba 16 pixel internal format
            /// </summary>
            Rgba16 = 0x805B,

            /// <summary>
            ///     The dual alpha sgis pixel internal format
            /// </summary>
            DualAlpha4Sgis = 0x8110,

            /// <summary>
            ///     The dual alpha sgis pixel internal format
            /// </summary>
            DualAlpha8Sgis = 0x8111,

            /// <summary>
            ///     The dual alpha 12 sgis pixel internal format
            /// </summary>
            DualAlpha12Sgis = 0x8112,

            /// <summary>
            ///     The dual alpha 16 sgis pixel internal format
            /// </summary>
            DualAlpha16Sgis = 0x8113,

            /// <summary>
            ///     The dual luminance sgis pixel internal format
            /// </summary>
            DualLuminance4Sgis = 0x8114,

            /// <summary>
            ///     The dual luminance sgis pixel internal format
            /// </summary>
            DualLuminance8Sgis = 0x8115,

            /// <summary>
            ///     The dual luminance 12 sgis pixel internal format
            /// </summary>
            DualLuminance12Sgis = 0x8116,

            /// <summary>
            ///     The dual luminance 16 sgis pixel internal format
            /// </summary>
            DualLuminance16Sgis = 0x8117,

            /// <summary>
            ///     The dual intensity sgis pixel internal format
            /// </summary>
            DualIntensity4Sgis = 0x8118,

            /// <summary>
            ///     The dual intensity sgis pixel internal format
            /// </summary>
            DualIntensity8Sgis = 0x8119,

            /// <summary>
            ///     The dual intensity 12 sgis pixel internal format
            /// </summary>
            DualIntensity12Sgis = 0x811A,

            /// <summary>
            ///     The dual intensity 16 sgis pixel internal format
            /// </summary>
            DualIntensity16Sgis = 0x811B,

            /// <summary>
            ///     The dual luminance alpha sgis pixel internal format
            /// </summary>
            DualLuminanceAlpha4Sgis = 0x811C,

            /// <summary>
            ///     The dual luminance alpha sgis pixel internal format
            /// </summary>
            DualLuminanceAlpha8Sgis = 0x811D,

            /// <summary>
            ///     The quad alpha sgis pixel internal format
            /// </summary>
            QuadAlpha4Sgis = 0x811E,

            /// <summary>
            ///     The quad alpha sgis pixel internal format
            /// </summary>
            QuadAlpha8Sgis = 0x811F,

            /// <summary>
            ///     The quad luminance sgis pixel internal format
            /// </summary>
            QuadLuminance4Sgis = 0x8120,

            /// <summary>
            ///     The quad luminance sgis pixel internal format
            /// </summary>
            QuadLuminance8Sgis = 0x8121,

            /// <summary>
            ///     The quad intensity sgis pixel internal format
            /// </summary>
            QuadIntensity4Sgis = 0x8122,

            /// <summary>
            ///     The quad intensity sgis pixel internal format
            /// </summary>
            QuadIntensity8Sgis = 0x8123,

            /// <summary>
            ///     The depth component 16 pixel internal format
            /// </summary>
            DepthComponent16 = 0x81a5,

            /// <summary>
            ///     The depth component 16 sgix pixel internal format
            /// </summary>
            DepthComponent16Sgix = 0x81A5,

            /// <summary>
            ///     The depth component 24 pixel internal format
            /// </summary>
            DepthComponent24 = 0x81a6,

            /// <summary>
            ///     The depth component 24 sgix pixel internal format
            /// </summary>
            DepthComponent24Sgix = 0x81A6,

            /// <summary>
            ///     The depth component 32 pixel internal format
            /// </summary>
            DepthComponent32 = 0x81a7,

            /// <summary>
            ///     The depth component 32 sgix pixel internal format
            /// </summary>
            DepthComponent32Sgix = 0x81A7,

            /// <summary>
            ///     The compressed red pixel internal format
            /// </summary>
            CompressedRed = 0x8225,

            /// <summary>
            ///     The compressed rg pixel internal format
            /// </summary>
            CompressedRg = 0x8226,

            /// <summary>
            ///     The  pixel internal format
            /// </summary>
            R8 = 0x8229,

            /// <summary>
            ///     The 16 pixel internal format
            /// </summary>
            R16 = 0x822A,

            /// <summary>
            ///     The rg pixel internal format
            /// </summary>
            Rg8 = 0x822B,

            /// <summary>
            ///     The rg 16 pixel internal format
            /// </summary>
            Rg16 = 0x822C,

            /// <summary>
            ///     The 16f pixel internal format
            /// </summary>
            R16F = 0x822D,

            /// <summary>
            ///     The 32f pixel internal format
            /// </summary>
            R32F = 0x822E,

            /// <summary>
            ///     The rg 16f pixel internal format
            /// </summary>
            Rg16F = 0x822F,

            /// <summary>
            ///     The rg 32f pixel internal format
            /// </summary>
            Rg32F = 0x8230,

            /// <summary>
            ///     The 8i pixel internal format
            /// </summary>
            R8I = 0x8231,

            /// <summary>
            ///     The 8ui pixel internal format
            /// </summary>
            R8Ui = 0x8232,

            /// <summary>
            ///     The 16i pixel internal format
            /// </summary>
            R16I = 0x8233,

            /// <summary>
            ///     The 16ui pixel internal format
            /// </summary>
            R16Ui = 0x8234,

            /// <summary>
            ///     The 32i pixel internal format
            /// </summary>
            R32I = 0x8235,

            /// <summary>
            ///     The 32ui pixel internal format
            /// </summary>
            R32Ui = 0x8236,

            /// <summary>
            ///     The rg 8i pixel internal format
            /// </summary>
            Rg8I = 0x8237,

            /// <summary>
            ///     The rg 8ui pixel internal format
            /// </summary>
            Rg8Ui = 0x8238,

            /// <summary>
            ///     The rg 16i pixel internal format
            /// </summary>
            Rg16I = 0x8239,

            /// <summary>
            ///     The rg 16ui pixel internal format
            /// </summary>
            Rg16Ui = 0x823A,

            /// <summary>
            ///     The rg 32i pixel internal format
            /// </summary>
            Rg32I = 0x823B,

            /// <summary>
            ///     The rg 32ui pixel internal format
            /// </summary>
            Rg32Ui = 0x823C,

            /// <summary>
            ///     The compressed rgb 3tc dxt ext pixel internal format
            /// </summary>
            CompressedRgbS3TcDxt1Ext = 0x83F0,

            /// <summary>
            ///     The compressed rgba 3tc dxt ext pixel internal format
            /// </summary>
            CompressedRgbaS3TcDxt1Ext = 0x83F1,

            /// <summary>
            ///     The compressed rgba 3tc dxt ext pixel internal format
            /// </summary>
            CompressedRgbaS3TcDxt3Ext = 0x83F2,

            /// <summary>
            ///     The compressed rgba 3tc dxt ext pixel internal format
            /// </summary>
            CompressedRgbaS3TcDxt5Ext = 0x83F3,

            /// <summary>
            ///     The compressed alpha pixel internal format
            /// </summary>
            CompressedAlpha = 0x84E9,

            /// <summary>
            ///     The compressed luminance pixel internal format
            /// </summary>
            CompressedLuminance = 0x84EA,

            /// <summary>
            ///     The compressed luminance alpha pixel internal format
            /// </summary>
            CompressedLuminanceAlpha = 0x84EB,

            /// <summary>
            ///     The compressed intensity pixel internal format
            /// </summary>
            CompressedIntensity = 0x84EC,

            /// <summary>
            ///     The compressed rgb pixel internal format
            /// </summary>
            CompressedRgb = 0x84ED,

            /// <summary>
            ///     The compressed rgba pixel internal format
            /// </summary>
            CompressedRgba = 0x84EE,

            /// <summary>
            ///     The depth stencil pixel internal format
            /// </summary>
            DepthStencil = 0x84F9,

            /// <summary>
            ///     The rgba 32f pixel internal format
            /// </summary>
            Rgba32F = 0x8814,

            /// <summary>
            ///     The rgb 32f pixel internal format
            /// </summary>
            Rgb32F = 0x8815,

            /// <summary>
            ///     The rgba 16f pixel internal format
            /// </summary>
            Rgba16F = 0x881A,

            /// <summary>
            ///     The rgb 16f pixel internal format
            /// </summary>
            Rgb16F = 0x881B,

            /// <summary>
            ///     The depth 24 stencil pixel internal format
            /// </summary>
            Depth24Stencil8 = 0x88F0,

            /// <summary>
            ///     The 11f 11f 10f pixel internal format
            /// </summary>
            R11FG11FB10F = 0x8C3A,

            /// <summary>
            ///     The rgb pixel internal format
            /// </summary>
            Rgb9E5 = 0x8C3D,

            /// <summary>
            ///     The srgb pixel internal format
            /// </summary>
            Srgb = 0x8C40,

            /// <summary>
            ///     The srgb pixel internal format
            /// </summary>
            Srgb8 = 0x8C41,

            /// <summary>
            ///     The srgb alpha pixel internal format
            /// </summary>
            SrgbAlpha = 0x8C42,

            /// <summary>
            ///     The srgb alpha pixel internal format
            /// </summary>
            Srgb8Alpha8 = 0x8C43,

            /// <summary>
            ///     The sluminance alpha pixel internal format
            /// </summary>
            SluminanceAlpha = 0x8C44,

            /// <summary>
            ///     The sluminance alpha pixel internal format
            /// </summary>
            Sluminance8Alpha8 = 0x8C45,

            /// <summary>
            ///     The sluminance pixel internal format
            /// </summary>
            Sluminance = 0x8C46,

            /// <summary>
            ///     The sluminance pixel internal format
            /// </summary>
            Sluminance8 = 0x8C47,

            /// <summary>
            ///     The compressed srgb pixel internal format
            /// </summary>
            CompressedSrgb = 0x8C48,

            /// <summary>
            ///     The compressed srgb alpha pixel internal format
            /// </summary>
            CompressedSrgbAlpha = 0x8C49,

            /// <summary>
            ///     The compressed sluminance pixel internal format
            /// </summary>
            CompressedSluminance = 0x8C4A,

            /// <summary>
            ///     The compressed sluminance alpha pixel internal format
            /// </summary>
            CompressedSluminanceAlpha = 0x8C4B,

            /// <summary>
            ///     The compressed srgb 3tc dxt ext pixel internal format
            /// </summary>
            CompressedSrgbS3TcDxt1Ext = 0x8C4C,

            /// <summary>
            ///     The compressed srgb alpha 3tc dxt ext pixel internal format
            /// </summary>
            CompressedSrgbAlphaS3TcDxt1Ext = 0x8C4D,

            /// <summary>
            ///     The compressed srgb alpha 3tc dxt ext pixel internal format
            /// </summary>
            CompressedSrgbAlphaS3TcDxt3Ext = 0x8C4E,

            /// <summary>
            ///     The compressed srgb alpha 3tc dxt ext pixel internal format
            /// </summary>
            CompressedSrgbAlphaS3TcDxt5Ext = 0x8C4F,

            /// <summary>
            ///     The depth component 32f pixel internal format
            /// </summary>
            DepthComponent32F = 0x8CAC,

            /// <summary>
            ///     The depth 32f stencil pixel internal format
            /// </summary>
            Depth32FStencil8 = 0x8CAD,

            /// <summary>
            ///     The rgba 32ui pixel internal format
            /// </summary>
            Rgba32Ui = 0x8D70,

            /// <summary>
            ///     The rgb 32ui pixel internal format
            /// </summary>
            Rgb32Ui = 0x8D71,

            /// <summary>
            ///     The rgba 16ui pixel internal format
            /// </summary>
            Rgba16Ui = 0x8D76,

            /// <summary>
            ///     The rgb 16ui pixel internal format
            /// </summary>
            Rgb16Ui = 0x8D77,

            /// <summary>
            ///     The rgba 8ui pixel internal format
            /// </summary>
            Rgba8Ui = 0x8D7C,

            /// <summary>
            ///     The rgb 8ui pixel internal format
            /// </summary>
            Rgb8Ui = 0x8D7D,

            /// <summary>
            ///     The rgba 32i pixel internal format
            /// </summary>
            Rgba32I = 0x8D82,

            /// <summary>
            ///     The rgb 32i pixel internal format
            /// </summary>
            Rgb32I = 0x8D83,

            /// <summary>
            ///     The rgba 16i pixel internal format
            /// </summary>
            Rgba16I = 0x8D88,

            /// <summary>
            ///     The rgb 16i pixel internal format
            /// </summary>
            Rgb16I = 0x8D89,

            /// <summary>
            ///     The rgba 8i pixel internal format
            /// </summary>
            Rgba8I = 0x8D8E,

            /// <summary>
            ///     The rgb 8i pixel internal format
            /// </summary>
            Rgb8I = 0x8D8F,

            /// <summary>
            ///     The float 32 unsigned int 248 rev pixel internal format
            /// </summary>
            Float32UnsignedInt248Rev = 0x8DAD,

            /// <summary>
            ///     The compressed red rgtc pixel internal format
            /// </summary>
            CompressedRedRgtc1 = 0x8DBB,

            /// <summary>
            ///     The compressed signed red rgtc pixel internal format
            /// </summary>
            CompressedSignedRedRgtc1 = 0x8DBC,

            /// <summary>
            ///     The compressed rg rgtc pixel internal format
            /// </summary>
            CompressedRgRgtc2 = 0x8DBD,

            /// <summary>
            ///     The compressed signed rg rgtc pixel internal format
            /// </summary>
            CompressedSignedRgRgtc2 = 0x8DBE,

            /// <summary>
            ///     The one pixel internal format
            /// </summary>
            One = 1,

            /// <summary>
            ///     The two pixel internal format
            /// </summary>
            Two = 2,

            /// <summary>
            ///     The three pixel internal format
            /// </summary>
            Three = 3,

            /// <summary>
            ///     The four pixel internal format
            /// </summary>
            Four = 4
        }

        /// <summary>
        ///     The pixel store parameter enum
        /// </summary>
        public enum PixelStoreParameter
        {
            /// <summary>
            ///     The unpack swap bytes pixel store parameter
            /// </summary>
            UnpackSwapBytes = 0x0CF0,

            /// <summary>
            ///     The unpack lsb first pixel store parameter
            /// </summary>
            UnpackLsbFirst = 0x0CF1,

            /// <summary>
            ///     The unpack row length pixel store parameter
            /// </summary>
            UnpackRowLength = 0x0CF2,

            /// <summary>
            ///     The unpack skip rows pixel store parameter
            /// </summary>
            UnpackSkipRows = 0x0CF3,

            /// <summary>
            ///     The unpack skip pixels pixel store parameter
            /// </summary>
            UnpackSkipPixels = 0x0CF4,

            /// <summary>
            ///     The unpack alignment pixel store parameter
            /// </summary>
            UnpackAlignment = 0x0CF5,

            /// <summary>
            ///     The pack swap bytes pixel store parameter
            /// </summary>
            PackSwapBytes = 0x0D00,

            /// <summary>
            ///     The pack lsb first pixel store parameter
            /// </summary>
            PackLsbFirst = 0x0D01,

            /// <summary>
            ///     The pack row length pixel store parameter
            /// </summary>
            PackRowLength = 0x0D02,

            /// <summary>
            ///     The pack skip rows pixel store parameter
            /// </summary>
            PackSkipRows = 0x0D03,

            /// <summary>
            ///     The pack skip pixels pixel store parameter
            /// </summary>
            PackSkipPixels = 0x0D04,

            /// <summary>
            ///     The pack alignment pixel store parameter
            /// </summary>
            PackAlignment = 0x0D05,

            /// <summary>
            ///     The pack skip images pixel store parameter
            /// </summary>
            PackSkipImages = 0x806B,

            /// <summary>
            ///     The pack skip images ext pixel store parameter
            /// </summary>
            PackSkipImagesExt = 0x806B,

            /// <summary>
            ///     The pack image height pixel store parameter
            /// </summary>
            PackImageHeight = 0x806C,

            /// <summary>
            ///     The pack image height ext pixel store parameter
            /// </summary>
            PackImageHeightExt = 0x806C,

            /// <summary>
            ///     The unpack skip images pixel store parameter
            /// </summary>
            UnpackSkipImages = 0x806D,

            /// <summary>
            ///     The unpack skip images ext pixel store parameter
            /// </summary>
            UnpackSkipImagesExt = 0x806D,

            /// <summary>
            ///     The unpack image height pixel store parameter
            /// </summary>
            UnpackImageHeight = 0x806E,

            /// <summary>
            ///     The unpack image height ext pixel store parameter
            /// </summary>
            UnpackImageHeightExt = 0x806E,

            /// <summary>
            ///     The pack skip volumes sgis pixel store parameter
            /// </summary>
            PackSkipVolumesSgis = 0x8130,

            /// <summary>
            ///     The pack image depth sgis pixel store parameter
            /// </summary>
            PackImageDepthSgis = 0x8131,

            /// <summary>
            ///     The unpack skip volumes sgis pixel store parameter
            /// </summary>
            UnpackSkipVolumesSgis = 0x8132,

            /// <summary>
            ///     The unpack image depth sgis pixel store parameter
            /// </summary>
            UnpackImageDepthSgis = 0x8133,

            /// <summary>
            ///     The pixel tile width sgix pixel store parameter
            /// </summary>
            PixelTileWidthSgix = 0x8140,

            /// <summary>
            ///     The pixel tile height sgix pixel store parameter
            /// </summary>
            PixelTileHeightSgix = 0x8141,

            /// <summary>
            ///     The pixel tile grid width sgix pixel store parameter
            /// </summary>
            PixelTileGridWidthSgix = 0x8142,

            /// <summary>
            ///     The pixel tile grid height sgix pixel store parameter
            /// </summary>
            PixelTileGridHeightSgix = 0x8143,

            /// <summary>
            ///     The pixel tile grid depth sgix pixel store parameter
            /// </summary>
            PixelTileGridDepthSgix = 0x8144,

            /// <summary>
            ///     The pixel tile cache size sgix pixel store parameter
            /// </summary>
            PixelTileCacheSizeSgix = 0x8145,

            /// <summary>
            ///     The pack resample sgix pixel store parameter
            /// </summary>
            PackResampleSgix = 0x842C,

            /// <summary>
            ///     The unpack resample sgix pixel store parameter
            /// </summary>
            UnpackResampleSgix = 0x842D,

            /// <summary>
            ///     The pack subsample rate sgix pixel store parameter
            /// </summary>
            PackSubsampleRateSgix = 0x85A0,

            /// <summary>
            ///     The unpack subsample rate sgix pixel store parameter
            /// </summary>
            UnpackSubsampleRateSgix = 0x85A1
        }

        /// <summary>
        ///     The pixel type enum
        /// </summary>
        public enum PixelType
        {
            /// <summary>
            ///     The byte pixel type
            /// </summary>
            Byte = 0x1400,

            /// <summary>
            ///     The unsigned byte pixel type
            /// </summary>
            UnsignedByte = 0x1401,

            /// <summary>
            ///     The short pixel type
            /// </summary>
            Short = 0x1402,

            /// <summary>
            ///     The unsigned short pixel type
            /// </summary>
            UnsignedShort = 0x1403,

            /// <summary>
            ///     The int pixel type
            /// </summary>
            Int = 0x1404,

            /// <summary>
            ///     The unsigned int pixel type
            /// </summary>
            UnsignedInt = 0x1405,

            /// <summary>
            ///     The float pixel type
            /// </summary>
            Float = 0x1406,

            /// <summary>
            ///     The half float pixel type
            /// </summary>
            HalfFloat = 0x140B,

            /// <summary>
            ///     The bitmap pixel type
            /// </summary>
            Bitmap = 0x1A00,

            /// <summary>
            ///     The unsigned byte 332 pixel type
            /// </summary>
            UnsignedByte332 = 0x8032,

            /// <summary>
            ///     The unsigned byte 332 ext pixel type
            /// </summary>
            UnsignedByte332Ext = 0x8032,

            /// <summary>
            ///     The unsigned short 4444 pixel type
            /// </summary>
            UnsignedShort4444 = 0x8033,

            /// <summary>
            ///     The unsigned short 4444 ext pixel type
            /// </summary>
            UnsignedShort4444Ext = 0x8033,

            /// <summary>
            ///     The unsigned short 5551 pixel type
            /// </summary>
            UnsignedShort5551 = 0x8034,

            /// <summary>
            ///     The unsigned short 5551 ext pixel type
            /// </summary>
            UnsignedShort5551Ext = 0x8034,

            /// <summary>
            ///     The unsigned int 8888 pixel type
            /// </summary>
            UnsignedInt8888 = 0x8035,

            /// <summary>
            ///     The unsigned int 8888 ext pixel type
            /// </summary>
            UnsignedInt8888Ext = 0x8035,

            /// <summary>
            ///     The unsigned int 1010102 pixel type
            /// </summary>
            UnsignedInt1010102 = 0x8036,

            /// <summary>
            ///     The unsigned int 1010102 ext pixel type
            /// </summary>
            UnsignedInt1010102Ext = 0x8036,

            /// <summary>
            ///     The unsigned byte 233 reversed pixel type
            /// </summary>
            UnsignedByte233Reversed = 0x8362,

            /// <summary>
            ///     The unsigned short 565 pixel type
            /// </summary>
            UnsignedShort565 = 0x8363,

            /// <summary>
            ///     The unsigned short 565 reversed pixel type
            /// </summary>
            UnsignedShort565Reversed = 0x8364,

            /// <summary>
            ///     The unsigned short 4444 reversed pixel type
            /// </summary>
            UnsignedShort4444Reversed = 0x8365,

            /// <summary>
            ///     The unsigned short 1555 reversed pixel type
            /// </summary>
            UnsignedShort1555Reversed = 0x8366,

            /// <summary>
            ///     The unsigned int 8888 reversed pixel type
            /// </summary>
            UnsignedInt8888Reversed = 0x8367,

            /// <summary>
            ///     The unsigned int 2101010 reversed pixel type
            /// </summary>
            UnsignedInt2101010Reversed = 0x8368,

            /// <summary>
            ///     The unsigned int 248 pixel type
            /// </summary>
            UnsignedInt248 = 0x84FA,

            /// <summary>
            ///     The unsigned int 10 11 11 rev pixel type
            /// </summary>
            UnsignedInt10F11F11FRev = 0x8C3B,

            /// <summary>
            ///     The unsigned int 5999 rev pixel type
            /// </summary>
            UnsignedInt5999Rev = 0x8C3E,

            /// <summary>
            ///     The float 32 unsigned int 248 rev pixel type
            /// </summary>
            Float32UnsignedInt248Rev = 0x8DAD
        }

        /// <summary>
        ///     The program parameter enum
        /// </summary>
        public enum ProgramParameter
        {
            /// <summary>
            ///     The active uniform block max name length program parameter
            /// </summary>
            ActiveUniformBlockMaxNameLength = 0x8A35,

            /// <summary>
            ///     The active uniform blocks program parameter
            /// </summary>
            ActiveUniformBlocks = 0x8A36,

            /// <summary>
            ///     The delete status program parameter
            /// </summary>
            DeleteStatus = 0x8B80,

            /// <summary>
            ///     The link status program parameter
            /// </summary>
            LinkStatus = 0x8B82,

            /// <summary>
            ///     The validate status program parameter
            /// </summary>
            ValidateStatus = 0x8B83,

            /// <summary>
            ///     The info log length program parameter
            /// </summary>
            InfoLogLength = 0x8B84,

            /// <summary>
            ///     The attached shaders program parameter
            /// </summary>
            AttachedShaders = 0x8B85,

            /// <summary>
            ///     The active uniforms program parameter
            /// </summary>
            ActiveUniforms = 0x8B86,

            /// <summary>
            ///     The active uniform max length program parameter
            /// </summary>
            ActiveUniformMaxLength = 0x8B87,

            /// <summary>
            ///     The active attributes program parameter
            /// </summary>
            ActiveAttributes = 0x8B89,

            /// <summary>
            ///     The active attribute max length program parameter
            /// </summary>
            ActiveAttributeMaxLength = 0x8B8A,

            /// <summary>
            ///     The transform feedback varying max length program parameter
            /// </summary>
            TransformFeedbackVaryingMaxLength = 0x8C76,

            /// <summary>
            ///     The transform feedback buffer mode program parameter
            /// </summary>
            TransformFeedbackBufferMode = 0x8C7F,

            /// <summary>
            ///     The transform feedback varyings program parameter
            /// </summary>
            TransformFeedbackVaryings = 0x8C83,

            /// <summary>
            ///     The geometry vertices out program parameter
            /// </summary>
            GeometryVerticesOut = 0x8DDA,

            /// <summary>
            ///     The geometry input type program parameter
            /// </summary>
            GeometryInputType = 0x8DDB,

            /// <summary>
            ///     The geometry output type program parameter
            /// </summary>
            GeometryOutputType = 0x8DDC
        }

        /// <summary>
        ///     The shader parameter enum
        /// </summary>
        public enum ShaderParameter
        {
            /// <summary>
            ///     The shader type shader parameter
            /// </summary>
            ShaderType = 0x8B4F,

            /// <summary>
            ///     The delete status shader parameter
            /// </summary>
            DeleteStatus = 0x8B80,

            /// <summary>
            ///     The compile status shader parameter
            /// </summary>
            CompileStatus = 0x8B81,

            /// <summary>
            ///     The info log length shader parameter
            /// </summary>
            InfoLogLength = 0x8B84,

            /// <summary>
            ///     The shader source length shader parameter
            /// </summary>
            ShaderSourceLength = 0x8B88
        }

        /// <summary>
        ///     The shader type enum
        /// </summary>
        public enum ShaderType
        {
            /// <summary>
            ///     The fragment shader shader type
            /// </summary>
            FragmentShader = 0x8B30,

            /// <summary>
            ///     The vertex shader shader type
            /// </summary>
            VertexShader = 0x8B31,

            /// <summary>
            ///     The geometry shader shader type
            /// </summary>
            GeometryShader = 0x8DD9,

            /// <summary>
            ///     The tess control shader shader type
            /// </summary>
            TessControlShader = 0x8E88,

            /// <summary>
            ///     The tess evaluation shader shader type
            /// </summary>
            TessEvaluationShader = 0x8E87,

            /// <summary>
            ///     The compute shader shader type
            /// </summary>
            ComputeShader = 0x91B9
        }

        /// <summary>
        ///     The string name enum
        /// </summary>
        public enum StringName
        {
            /// <summary>
            ///     The vendor string name
            /// </summary>
            Vendor = 0x1F00,

            /// <summary>
            ///     The renderer string name
            /// </summary>
            Renderer = 0x1F01,

            /// <summary>
            ///     The version string name
            /// </summary>
            Version = 0x1F02,

            /// <summary>
            ///     The extensions string name
            /// </summary>
            Extensions = 0x1F03,

            /// <summary>
            ///     The shading language version string name
            /// </summary>
            ShadingLanguageVersion = 0x8B8C
        }

        /// <summary>
        ///     The texture parameter enum
        /// </summary>
        public enum TextureParameter
        {
            /// <summary>
            ///     The nearest texture parameter
            /// </summary>
            Nearest = 0x2600,

            /// <summary>
            ///     The linear texture parameter
            /// </summary>
            Linear = 0x2601,

            /// <summary>
            ///     The nearest mip map nearest texture parameter
            /// </summary>
            NearestMipMapNearest = 0x2700,

            /// <summary>
            ///     The linear mip map nearest texture parameter
            /// </summary>
            LinearMipMapNearest = 0x2701,

            /// <summary>
            ///     The nearest mip map linear texture parameter
            /// </summary>
            NearestMipMapLinear = 0x2702,

            /// <summary>
            ///     The linear mip map linear texture parameter
            /// </summary>
            LinearMipMapLinear = 0x2703,

            /// <summary>
            ///     The clamp to edge texture parameter
            /// </summary>
            ClampToEdge = 0x812F,

            /// <summary>
            ///     The clamp to border texture parameter
            /// </summary>
            ClampToBorder = 0x812D,

            /// <summary>
            ///     The mirror clamp to edge texture parameter
            /// </summary>
            MirrorClampToEdge = 0x8743,

            /// <summary>
            ///     The mirrored repeat texture parameter
            /// </summary>
            MirroredRepeat = 0x8370,

            /// <summary>
            ///     The repeat texture parameter
            /// </summary>
            Repeat = 0x2901,

            /// <summary>
            ///     The red texture parameter
            /// </summary>
            Red = 0x1903,

            /// <summary>
            ///     The green texture parameter
            /// </summary>
            Green = 0x1904,

            /// <summary>
            ///     The blue texture parameter
            /// </summary>
            Blue = 0x1905,

            /// <summary>
            ///     The alpha texture parameter
            /// </summary>
            Alpha = 0x1906,

            /// <summary>
            ///     The zero texture parameter
            /// </summary>
            Zero = 0,

            /// <summary>
            ///     The one texture parameter
            /// </summary>
            One = 1,

            /// <summary>
            ///     The compare ref to texture texture parameter
            /// </summary>
            CompareRefToTexture = 0x884E,

            /// <summary>
            ///     The none texture parameter
            /// </summary>
            None = 0,

            /// <summary>
            ///     The stencil index texture parameter
            /// </summary>
            StencilIndex = 0x1901,

            /// <summary>
            ///     The depth component texture parameter
            /// </summary>
            DepthComponent = 0x1902,

            /// <summary>
            ///     The max anisotropy ext texture parameter
            /// </summary>
            MaxAnisotropyExt = 0x84FE
        }

        /// <summary>
        ///     The texture parameter name enum
        /// </summary>
        public enum TextureParameterName
        {
            /// <summary>
            ///     The texture base level texture parameter name
            /// </summary>
            TextureBaseLevel = 0x813C,

            /// <summary>
            ///     The texture border color texture parameter name
            /// </summary>
            TextureBorderColor = 0x1004,

            /// <summary>
            ///     The texture compare mode texture parameter name
            /// </summary>
            TextureCompareMode = 0x884C,

            /// <summary>
            ///     The texture compare func texture parameter name
            /// </summary>
            TextureCompareFunc = 0x884D,

            /// <summary>
            ///     The texture lod bias texture parameter name
            /// </summary>
            TextureLodBias = 0x8501,

            /// <summary>
            ///     The texture mag filter texture parameter name
            /// </summary>
            TextureMagFilter = 0x2800,

            /// <summary>
            ///     The texture max level texture parameter name
            /// </summary>
            TextureMaxLevel = 0x813D,

            /// <summary>
            ///     The texture max lod texture parameter name
            /// </summary>
            TextureMaxLod = 0x813B,

            /// <summary>
            ///     The texture min filter texture parameter name
            /// </summary>
            TextureMinFilter = 0x2801,

            /// <summary>
            ///     The texture min lod texture parameter name
            /// </summary>
            TextureMinLod = 0x813A,

            /// <summary>
            ///     The texture swizzle texture parameter name
            /// </summary>
            TextureSwizzleR = 0x8E42,

            /// <summary>
            ///     The texture swizzle texture parameter name
            /// </summary>
            TextureSwizzleG = 0x8E43,

            /// <summary>
            ///     The texture swizzle texture parameter name
            /// </summary>
            TextureSwizzleB = 0x8E44,

            /// <summary>
            ///     The texture swizzle texture parameter name
            /// </summary>
            TextureSwizzleA = 0x8E45,

            /// <summary>
            ///     The texture swizzle rgba texture parameter name
            /// </summary>
            TextureSwizzleRgba = 0x8E46,

            /// <summary>
            ///     The texture wrap texture parameter name
            /// </summary>
            TextureWrapS = 0x2802,

            /// <summary>
            ///     The texture wrap texture parameter name
            /// </summary>
            TextureWrapT = 0x2803,

            /// <summary>
            ///     The texture wrap texture parameter name
            /// </summary>
            TextureWrapR = 0x8072,

            /// <summary>
            ///     The max anisotropy ext texture parameter name
            /// </summary>
            MaxAnisotropyExt = 0x84FE
        }

        /// <summary>
        ///     The texture target enum
        /// </summary>
        public enum TextureTarget
        {
            /// <summary>
            ///     The texture texture target
            /// </summary>
            Texture1D = 0x0DE0,

            /// <summary>
            ///     The texture texture target
            /// </summary>
            Texture2D = 0x0DE1,

            /// <summary>
            ///     The texture texture target
            /// </summary>
            Texture3D = 0x806F,

            /// <summary>
            ///     The texture array texture target
            /// </summary>
            Texture1DArray = 0x8C18,

            /// <summary>
            ///     The texture array texture target
            /// </summary>
            Texture2DArray = 0x8C1A,

            /// <summary>
            ///     The texture rectangle texture target
            /// </summary>
            TextureRectangle = 0x84F5,

            /// <summary>
            ///     The texture cube map texture target
            /// </summary>
            TextureCubeMap = 0x8513,

            /// <summary>
            ///     The texture cube map positive texture target
            /// </summary>
            TextureCubeMapPositiveX = 0x8515,

            /// <summary>
            ///     The texture cube map negative texture target
            /// </summary>
            TextureCubeMapNegativeX = 0x8516,

            /// <summary>
            ///     The texture cube map positive texture target
            /// </summary>
            TextureCubeMapPositiveY = 0x8517,

            /// <summary>
            ///     The texture cube map negative texture target
            /// </summary>
            TextureCubeMapNegativeY = 0x8518,

            /// <summary>
            ///     The texture cube map positive texture target
            /// </summary>
            TextureCubeMapPositiveZ = 0x8519,

            /// <summary>
            ///     The texture cube map negative texture target
            /// </summary>
            TextureCubeMapNegativeZ = 0x851A,

            /// <summary>
            ///     The texture cube map array texture target
            /// </summary>
            TextureCubeMapArray = 0x9009,

            /// <summary>
            ///     The texture multisample texture target
            /// </summary>
            Texture2DMultisample = 0x9100,

            /// <summary>
            ///     The texture multisample array texture target
            /// </summary>
            Texture2DMultisampleArray = 0x9102
        }

        /// <summary>
        ///     The vertex attrib pointer type enum
        /// </summary>
        public enum VertexAttribPointerType
        {
            /// <summary>
            ///     The byte vertex attrib pointer type
            /// </summary>
            Byte = 0x1400,

            /// <summary>
            ///     The unsigned byte vertex attrib pointer type
            /// </summary>
            UnsignedByte = 0x1401,

            /// <summary>
            ///     The short vertex attrib pointer type
            /// </summary>
            Short = 0x1402,

            /// <summary>
            ///     The unsigned short vertex attrib pointer type
            /// </summary>
            UnsignedShort = 0x1403,

            /// <summary>
            ///     The int vertex attrib pointer type
            /// </summary>
            Int = 0x1404,

            /// <summary>
            ///     The unsigned int vertex attrib pointer type
            /// </summary>
            UnsignedInt = 0x1405,

            /// <summary>
            ///     The float vertex attrib pointer type
            /// </summary>
            Float = 0x1406,

            /// <summary>
            ///     The double vertex attrib pointer type
            /// </summary>
            Double = 0x140A,

            /// <summary>
            ///     The half float vertex attrib pointer type
            /// </summary>
            HalfFloat = 0x140B,

            /// <summary>
            ///     The unsigned int 2101010 reversed vertex attrib pointer type
            /// </summary>
            UnsignedUInt2101010Reversed = 0x8368,

            /// <summary>
            ///     The unsigned int 2101010 reversed vertex attrib pointer type
            /// </summary>
            UnsignedInt2101010Reversed = 0x8D9F,

            /// <summary>
            ///     The unsigned int 101111 reversed vertex attrib pointer type
            /// </summary>
            UnsignedUInt101111Reversed = 0x8C3B
        }
    }
}