using System;

namespace Veldrid.OpenGLBinding
{
    /// <summary>
    /// The draw buffer mode enum
    /// </summary>
    public enum DrawBufferMode
    {
        /// <summary>
        /// The none draw buffer mode
        /// </summary>
        None = 0,
        /// <summary>
        /// The none oes draw buffer mode
        /// </summary>
        NoneOes = 0,
        /// <summary>
        /// The front left draw buffer mode
        /// </summary>
        FrontLeft = 1024,
        /// <summary>
        /// The front right draw buffer mode
        /// </summary>
        FrontRight = 1025,
        /// <summary>
        /// The back left draw buffer mode
        /// </summary>
        BackLeft = 1026,
        /// <summary>
        /// The back right draw buffer mode
        /// </summary>
        BackRight = 1027,
        /// <summary>
        /// The front draw buffer mode
        /// </summary>
        Front = 1028,
        /// <summary>
        /// The back draw buffer mode
        /// </summary>
        Back = 1029,
        /// <summary>
        /// The left draw buffer mode
        /// </summary>
        Left = 1030,
        /// <summary>
        /// The right draw buffer mode
        /// </summary>
        Right = 1031,
        /// <summary>
        /// The front and back draw buffer mode
        /// </summary>
        FrontAndBack = 1032,
        /// <summary>
        /// The aux draw buffer mode
        /// </summary>
        Aux0 = 1033,
        /// <summary>
        /// The aux draw buffer mode
        /// </summary>
        Aux1 = 1034,
        /// <summary>
        /// The aux draw buffer mode
        /// </summary>
        Aux2 = 1035,
        /// <summary>
        /// The aux draw buffer mode
        /// </summary>
        Aux3 = 1036,
        /// <summary>
        /// The color attachment draw buffer mode
        /// </summary>
        ColorAttachment0 = 36064,
        /// <summary>
        /// The color attachment draw buffer mode
        /// </summary>
        ColorAttachment1 = 36065,
        /// <summary>
        /// The color attachment draw buffer mode
        /// </summary>
        ColorAttachment2 = 36066,
        /// <summary>
        /// The color attachment draw buffer mode
        /// </summary>
        ColorAttachment3 = 36067,
        /// <summary>
        /// The color attachment draw buffer mode
        /// </summary>
        ColorAttachment4 = 36068,
        /// <summary>
        /// The color attachment draw buffer mode
        /// </summary>
        ColorAttachment5 = 36069,
        /// <summary>
        /// The color attachment draw buffer mode
        /// </summary>
        ColorAttachment6 = 36070,
        /// <summary>
        /// The color attachment draw buffer mode
        /// </summary>
        ColorAttachment7 = 36071,
        /// <summary>
        /// The color attachment draw buffer mode
        /// </summary>
        ColorAttachment8 = 36072,
        /// <summary>
        /// The color attachment draw buffer mode
        /// </summary>
        ColorAttachment9 = 36073,
        /// <summary>
        /// The color attachment 10 draw buffer mode
        /// </summary>
        ColorAttachment10 = 36074,
        /// <summary>
        /// The color attachment 11 draw buffer mode
        /// </summary>
        ColorAttachment11 = 36075,
        /// <summary>
        /// The color attachment 12 draw buffer mode
        /// </summary>
        ColorAttachment12 = 36076,
        /// <summary>
        /// The color attachment 13 draw buffer mode
        /// </summary>
        ColorAttachment13 = 36077,
        /// <summary>
        /// The color attachment 14 draw buffer mode
        /// </summary>
        ColorAttachment14 = 36078,
        /// <summary>
        /// The color attachment 15 draw buffer mode
        /// </summary>
        ColorAttachment15 = 36079
    }

    /// <summary>
    /// The clear buffer mask enum
    /// </summary>
    [Flags]
    public enum ClearBufferMask
    {
        /// <summary>
        /// The none clear buffer mask
        /// </summary>
        None = 0,
        /// <summary>
        /// The depth buffer bit clear buffer mask
        /// </summary>
        DepthBufferBit = 256,
        /// <summary>
        /// The accum buffer bit clear buffer mask
        /// </summary>
        AccumBufferBit = 512,
        /// <summary>
        /// The stencil buffer bit clear buffer mask
        /// </summary>
        StencilBufferBit = 1024,
        /// <summary>
        /// The color buffer bit clear buffer mask
        /// </summary>
        ColorBufferBit = 16384,
        /// <summary>
        /// The coverage buffer bit nv clear buffer mask
        /// </summary>
        CoverageBufferBitNv = 32768
    }

    /// <summary>
    /// The primitive type enum
    /// </summary>
    public enum PrimitiveType
    {
        /// <summary>
        /// The points primitive type
        /// </summary>
        Points = 0,
        /// <summary>
        /// The lines primitive type
        /// </summary>
        Lines = 1,
        /// <summary>
        /// The line loop primitive type
        /// </summary>
        LineLoop = 2,
        /// <summary>
        /// The line strip primitive type
        /// </summary>
        LineStrip = 3,
        /// <summary>
        /// The triangles primitive type
        /// </summary>
        Triangles = 4,
        /// <summary>
        /// The triangle strip primitive type
        /// </summary>
        TriangleStrip = 5,
        /// <summary>
        /// The triangle fan primitive type
        /// </summary>
        TriangleFan = 6,
        /// <summary>
        /// The quads primitive type
        /// </summary>
        Quads = 7,
        /// <summary>
        /// The quads ext primitive type
        /// </summary>
        QuadsExt = 7,
        /// <summary>
        /// The quad strip primitive type
        /// </summary>
        QuadStrip = 8,
        /// <summary>
        /// The polygon primitive type
        /// </summary>
        Polygon = 9,
        /// <summary>
        /// The lines adjacency primitive type
        /// </summary>
        LinesAdjacency = 10,
        /// <summary>
        /// The lines adjacency arb primitive type
        /// </summary>
        LinesAdjacencyArb = 10,
        /// <summary>
        /// The lines adjacency ext primitive type
        /// </summary>
        LinesAdjacencyExt = 10,
        /// <summary>
        /// The line strip adjacency primitive type
        /// </summary>
        LineStripAdjacency = 11,
        /// <summary>
        /// The line strip adjacency arb primitive type
        /// </summary>
        LineStripAdjacencyArb = 11,
        /// <summary>
        /// The line strip adjacency ext primitive type
        /// </summary>
        LineStripAdjacencyExt = 11,
        /// <summary>
        /// The triangles adjacency primitive type
        /// </summary>
        TrianglesAdjacency = 12,
        /// <summary>
        /// The triangles adjacency arb primitive type
        /// </summary>
        TrianglesAdjacencyArb = 12,
        /// <summary>
        /// The triangles adjacency ext primitive type
        /// </summary>
        TrianglesAdjacencyExt = 12,
        /// <summary>
        /// The triangle strip adjacency primitive type
        /// </summary>
        TriangleStripAdjacency = 13,
        /// <summary>
        /// The triangle strip adjacency arb primitive type
        /// </summary>
        TriangleStripAdjacencyArb = 13,
        /// <summary>
        /// The triangle strip adjacency ext primitive type
        /// </summary>
        TriangleStripAdjacencyExt = 13,
        /// <summary>
        /// The patches primitive type
        /// </summary>
        Patches = 14,
        /// <summary>
        /// The patches ext primitive type
        /// </summary>
        PatchesExt = 14
    }

    /// <summary>
    /// The draw elements type enum
    /// </summary>
    public enum DrawElementsType
    {
        /// <summary>
        /// The unsigned byte draw elements type
        /// </summary>
        UnsignedByte = 5121,
        /// <summary>
        /// The unsigned short draw elements type
        /// </summary>
        UnsignedShort = 5123,
        /// <summary>
        /// The unsigned int draw elements type
        /// </summary>
        UnsignedInt = 5125
    }

    /// <summary>
    /// The texture unit enum
    /// </summary>
    public enum TextureUnit
    {
        /// <summary>
        /// The texture texture unit
        /// </summary>
        Texture0 = 33984,
        /// <summary>
        /// The texture texture unit
        /// </summary>
        Texture1 = 33985,
        /// <summary>
        /// The texture texture unit
        /// </summary>
        Texture2 = 33986,
        /// <summary>
        /// The texture texture unit
        /// </summary>
        Texture3 = 33987,
        /// <summary>
        /// The texture texture unit
        /// </summary>
        Texture4 = 33988,
        /// <summary>
        /// The texture texture unit
        /// </summary>
        Texture5 = 33989,
        /// <summary>
        /// The texture texture unit
        /// </summary>
        Texture6 = 33990,
        /// <summary>
        /// The texture texture unit
        /// </summary>
        Texture7 = 33991,
        /// <summary>
        /// The texture texture unit
        /// </summary>
        Texture8 = 33992,
        /// <summary>
        /// The texture texture unit
        /// </summary>
        Texture9 = 33993,
        /// <summary>
        /// The texture 10 texture unit
        /// </summary>
        Texture10 = 33994,
        /// <summary>
        /// The texture 11 texture unit
        /// </summary>
        Texture11 = 33995,
        /// <summary>
        /// The texture 12 texture unit
        /// </summary>
        Texture12 = 33996,
        /// <summary>
        /// The texture 13 texture unit
        /// </summary>
        Texture13 = 33997,
        /// <summary>
        /// The texture 14 texture unit
        /// </summary>
        Texture14 = 33998,
        /// <summary>
        /// The texture 15 texture unit
        /// </summary>
        Texture15 = 33999,
        /// <summary>
        /// The texture 16 texture unit
        /// </summary>
        Texture16 = 34000,
        /// <summary>
        /// The texture 17 texture unit
        /// </summary>
        Texture17 = 34001,
        /// <summary>
        /// The texture 18 texture unit
        /// </summary>
        Texture18 = 34002,
        /// <summary>
        /// The texture 19 texture unit
        /// </summary>
        Texture19 = 34003,
        /// <summary>
        /// The texture 20 texture unit
        /// </summary>
        Texture20 = 34004,
        /// <summary>
        /// The texture 21 texture unit
        /// </summary>
        Texture21 = 34005,
        /// <summary>
        /// The texture 22 texture unit
        /// </summary>
        Texture22 = 34006,
        /// <summary>
        /// The texture 23 texture unit
        /// </summary>
        Texture23 = 34007,
        /// <summary>
        /// The texture 24 texture unit
        /// </summary>
        Texture24 = 34008,
        /// <summary>
        /// The texture 25 texture unit
        /// </summary>
        Texture25 = 34009,
        /// <summary>
        /// The texture 26 texture unit
        /// </summary>
        Texture26 = 34010,
        /// <summary>
        /// The texture 27 texture unit
        /// </summary>
        Texture27 = 34011,
        /// <summary>
        /// The texture 28 texture unit
        /// </summary>
        Texture28 = 34012,
        /// <summary>
        /// The texture 29 texture unit
        /// </summary>
        Texture29 = 34013,
        /// <summary>
        /// The texture 30 texture unit
        /// </summary>
        Texture30 = 34014,
        /// <summary>
        /// The texture 31 texture unit
        /// </summary>
        Texture31 = 34015
    }

    /// <summary>
    /// The framebuffer target enum
    /// </summary>
    public enum FramebufferTarget
    {
        /// <summary>
        /// The read framebuffer framebuffer target
        /// </summary>
        ReadFramebuffer = 36008,
        /// <summary>
        /// The draw framebuffer framebuffer target
        /// </summary>
        DrawFramebuffer = 36009,
        /// <summary>
        /// The framebuffer framebuffer target
        /// </summary>
        Framebuffer = 36160,
        /// <summary>
        /// The framebuffer ext framebuffer target
        /// </summary>
        FramebufferExt = 36160
    }

    /// <summary>
    /// The renderbuffer target enum
    /// </summary>
    public enum RenderbufferTarget
    {
        /// <summary>
        /// The renderbuffer renderbuffer target
        /// </summary>
        Renderbuffer = 36161
    }

    /// <summary>
    /// The gl framebuffer attachment enum
    /// </summary>
    public enum GLFramebufferAttachment
    {
        /// <summary>
        /// The front left gl framebuffer attachment
        /// </summary>
        FrontLeft = 1024,
        /// <summary>
        /// The front right gl framebuffer attachment
        /// </summary>
        FrontRight = 1025,
        /// <summary>
        /// The back left gl framebuffer attachment
        /// </summary>
        BackLeft = 1026,
        /// <summary>
        /// The back right gl framebuffer attachment
        /// </summary>
        BackRight = 1027,
        /// <summary>
        /// The aux gl framebuffer attachment
        /// </summary>
        Aux0 = 1033,
        /// <summary>
        /// The aux gl framebuffer attachment
        /// </summary>
        Aux1 = 1034,
        /// <summary>
        /// The aux gl framebuffer attachment
        /// </summary>
        Aux2 = 1035,
        /// <summary>
        /// The aux gl framebuffer attachment
        /// </summary>
        Aux3 = 1036,
        /// <summary>
        /// The color gl framebuffer attachment
        /// </summary>
        Color = 6144,
        /// <summary>
        /// The depth gl framebuffer attachment
        /// </summary>
        Depth = 6145,
        /// <summary>
        /// The stencil gl framebuffer attachment
        /// </summary>
        Stencil = 6146,
        /// <summary>
        /// The depth stencil attachment gl framebuffer attachment
        /// </summary>
        DepthStencilAttachment = 33306,
        /// <summary>
        /// The color attachment gl framebuffer attachment
        /// </summary>
        ColorAttachment0 = 36064,
        /// <summary>
        /// The color attachment ext gl framebuffer attachment
        /// </summary>
        ColorAttachment0Ext = 36064,
        /// <summary>
        /// The color attachment gl framebuffer attachment
        /// </summary>
        ColorAttachment1 = 36065,
        /// <summary>
        /// The color attachment ext gl framebuffer attachment
        /// </summary>
        ColorAttachment1Ext = 36065,
        /// <summary>
        /// The color attachment gl framebuffer attachment
        /// </summary>
        ColorAttachment2 = 36066,
        /// <summary>
        /// The color attachment ext gl framebuffer attachment
        /// </summary>
        ColorAttachment2Ext = 36066,
        /// <summary>
        /// The color attachment gl framebuffer attachment
        /// </summary>
        ColorAttachment3 = 36067,
        /// <summary>
        /// The color attachment ext gl framebuffer attachment
        /// </summary>
        ColorAttachment3Ext = 36067,
        /// <summary>
        /// The color attachment gl framebuffer attachment
        /// </summary>
        ColorAttachment4 = 36068,
        /// <summary>
        /// The color attachment ext gl framebuffer attachment
        /// </summary>
        ColorAttachment4Ext = 36068,
        /// <summary>
        /// The color attachment gl framebuffer attachment
        /// </summary>
        ColorAttachment5 = 36069,
        /// <summary>
        /// The color attachment ext gl framebuffer attachment
        /// </summary>
        ColorAttachment5Ext = 36069,
        /// <summary>
        /// The color attachment gl framebuffer attachment
        /// </summary>
        ColorAttachment6 = 36070,
        /// <summary>
        /// The color attachment ext gl framebuffer attachment
        /// </summary>
        ColorAttachment6Ext = 36070,
        /// <summary>
        /// The color attachment gl framebuffer attachment
        /// </summary>
        ColorAttachment7 = 36071,
        /// <summary>
        /// The color attachment ext gl framebuffer attachment
        /// </summary>
        ColorAttachment7Ext = 36071,
        /// <summary>
        /// The color attachment gl framebuffer attachment
        /// </summary>
        ColorAttachment8 = 36072,
        /// <summary>
        /// The color attachment ext gl framebuffer attachment
        /// </summary>
        ColorAttachment8Ext = 36072,
        /// <summary>
        /// The color attachment gl framebuffer attachment
        /// </summary>
        ColorAttachment9 = 36073,
        /// <summary>
        /// The color attachment ext gl framebuffer attachment
        /// </summary>
        ColorAttachment9Ext = 36073,
        /// <summary>
        /// The color attachment 10 gl framebuffer attachment
        /// </summary>
        ColorAttachment10 = 36074,
        /// <summary>
        /// The color attachment 10 ext gl framebuffer attachment
        /// </summary>
        ColorAttachment10Ext = 36074,
        /// <summary>
        /// The color attachment 11 gl framebuffer attachment
        /// </summary>
        ColorAttachment11 = 36075,
        /// <summary>
        /// The color attachment 11 ext gl framebuffer attachment
        /// </summary>
        ColorAttachment11Ext = 36075,
        /// <summary>
        /// The color attachment 12 gl framebuffer attachment
        /// </summary>
        ColorAttachment12 = 36076,
        /// <summary>
        /// The color attachment 12 ext gl framebuffer attachment
        /// </summary>
        ColorAttachment12Ext = 36076,
        /// <summary>
        /// The color attachment 13 gl framebuffer attachment
        /// </summary>
        ColorAttachment13 = 36077,
        /// <summary>
        /// The color attachment 13 ext gl framebuffer attachment
        /// </summary>
        ColorAttachment13Ext = 36077,
        /// <summary>
        /// The color attachment 14 gl framebuffer attachment
        /// </summary>
        ColorAttachment14 = 36078,
        /// <summary>
        /// The color attachment 14 ext gl framebuffer attachment
        /// </summary>
        ColorAttachment14Ext = 36078,
        /// <summary>
        /// The color attachment 15 gl framebuffer attachment
        /// </summary>
        ColorAttachment15 = 36079,
        /// <summary>
        /// The color attachment 15 ext gl framebuffer attachment
        /// </summary>
        ColorAttachment15Ext = 36079,
        /// <summary>
        /// The depth attachment gl framebuffer attachment
        /// </summary>
        DepthAttachment = 36096,
        /// <summary>
        /// The depth attachment ext gl framebuffer attachment
        /// </summary>
        DepthAttachmentExt = 36096,
        /// <summary>
        /// The stencil attachment gl framebuffer attachment
        /// </summary>
        StencilAttachment = 36128,
        /// <summary>
        /// The stencil attachment ext gl framebuffer attachment
        /// </summary>
        StencilAttachmentExt = 36128
    }

    /// <summary>
    /// The texture target enum
    /// </summary>
    public enum TextureTarget
    {
        /// <summary>
        /// The texture texture target
        /// </summary>
        Texture1D = 3552,
        /// <summary>
        /// The texture texture target
        /// </summary>
        Texture2D = 3553,
        /// <summary>
        /// The proxy texture texture target
        /// </summary>
        ProxyTexture1D = 32867,
        /// <summary>
        /// The proxy texture ext texture target
        /// </summary>
        ProxyTexture1DExt = 32867,
        /// <summary>
        /// The proxy texture texture target
        /// </summary>
        ProxyTexture2D = 32868,
        /// <summary>
        /// The proxy texture ext texture target
        /// </summary>
        ProxyTexture2DExt = 32868,
        /// <summary>
        /// The texture texture target
        /// </summary>
        Texture3D = 32879,
        /// <summary>
        /// The texture ext texture target
        /// </summary>
        Texture3DExt = 32879,
        /// <summary>
        /// The texture oes texture target
        /// </summary>
        Texture3DOes = 32879,
        /// <summary>
        /// The proxy texture texture target
        /// </summary>
        ProxyTexture3D = 32880,
        /// <summary>
        /// The proxy texture ext texture target
        /// </summary>
        ProxyTexture3DExt = 32880,
        /// <summary>
        /// The detail texture sgis texture target
        /// </summary>
        DetailTexture2DSgis = 32917,
        /// <summary>
        /// The texture sgis texture target
        /// </summary>
        Texture4DSgis = 33076,
        /// <summary>
        /// The proxy texture sgis texture target
        /// </summary>
        ProxyTexture4DSgis = 33077,
        /// <summary>
        /// The texture min lod texture target
        /// </summary>
        TextureMinLod = 33082,
        /// <summary>
        /// The texture min lod sgis texture target
        /// </summary>
        TextureMinLodSgis = 33082,
        /// <summary>
        /// The texture max lod texture target
        /// </summary>
        TextureMaxLod = 33083,
        /// <summary>
        /// The texture max lod sgis texture target
        /// </summary>
        TextureMaxLodSgis = 33083,
        /// <summary>
        /// The texture base level texture target
        /// </summary>
        TextureBaseLevel = 33084,
        /// <summary>
        /// The texture base level sgis texture target
        /// </summary>
        TextureBaseLevelSgis = 33084,
        /// <summary>
        /// The texture max level texture target
        /// </summary>
        TextureMaxLevel = 33085,
        /// <summary>
        /// The texture max level sgis texture target
        /// </summary>
        TextureMaxLevelSgis = 33085,
        /// <summary>
        /// The texture rectangle texture target
        /// </summary>
        TextureRectangle = 34037,
        /// <summary>
        /// The texture rectangle arb texture target
        /// </summary>
        TextureRectangleArb = 34037,
        /// <summary>
        /// The texture rectangle nv texture target
        /// </summary>
        TextureRectangleNv = 34037,
        /// <summary>
        /// The proxy texture rectangle texture target
        /// </summary>
        ProxyTextureRectangle = 34039,
        /// <summary>
        /// The texture cube map texture target
        /// </summary>
        TextureCubeMap = 34067,
        /// <summary>
        /// The texture binding cube map texture target
        /// </summary>
        TextureBindingCubeMap = 34068,
        /// <summary>
        /// The texture cube map positive texture target
        /// </summary>
        TextureCubeMapPositiveX = 34069,
        /// <summary>
        /// The texture cube map negative texture target
        /// </summary>
        TextureCubeMapNegativeX = 34070,
        /// <summary>
        /// The texture cube map positive texture target
        /// </summary>
        TextureCubeMapPositiveY = 34071,
        /// <summary>
        /// The texture cube map negative texture target
        /// </summary>
        TextureCubeMapNegativeY = 34072,
        /// <summary>
        /// The texture cube map positive texture target
        /// </summary>
        TextureCubeMapPositiveZ = 34073,
        /// <summary>
        /// The texture cube map negative texture target
        /// </summary>
        TextureCubeMapNegativeZ = 34074,
        /// <summary>
        /// The proxy texture cube map texture target
        /// </summary>
        ProxyTextureCubeMap = 34075,
        /// <summary>
        /// The texture array texture target
        /// </summary>
        Texture1DArray = 35864,
        /// <summary>
        /// The proxy texture array texture target
        /// </summary>
        ProxyTexture1DArray = 35865,
        /// <summary>
        /// The texture array texture target
        /// </summary>
        Texture2DArray = 35866,
        /// <summary>
        /// The proxy texture array texture target
        /// </summary>
        ProxyTexture2DArray = 35867,
        /// <summary>
        /// The texture buffer texture target
        /// </summary>
        TextureBuffer = 35882,
        /// <summary>
        /// The texture external oes texture target
        /// </summary>
        TextureExternalOes = 36197,
        /// <summary>
        /// The texture cube map array texture target
        /// </summary>
        TextureCubeMapArray = 36873,
        /// <summary>
        /// The proxy texture cube map array texture target
        /// </summary>
        ProxyTextureCubeMapArray = 36875,
        /// <summary>
        /// The texture multisample texture target
        /// </summary>
        Texture2DMultisample = 37120,
        /// <summary>
        /// The proxy texture multisample texture target
        /// </summary>
        ProxyTexture2DMultisample = 37121,
        /// <summary>
        /// The texture multisample array texture target
        /// </summary>
        Texture2DMultisampleArray = 37122,
        /// <summary>
        /// The proxy texture multisample array texture target
        /// </summary>
        ProxyTexture2DMultisampleArray = 37123
    }

    /// <summary>
    /// The draw buffers enum enum
    /// </summary>
    public enum DrawBuffersEnum
    {
        /// <summary>
        /// The none draw buffers enum
        /// </summary>
        None = 0,
        /// <summary>
        /// The front left draw buffers enum
        /// </summary>
        FrontLeft = 1024,
        /// <summary>
        /// The front right draw buffers enum
        /// </summary>
        FrontRight = 1025,
        /// <summary>
        /// The back left draw buffers enum
        /// </summary>
        BackLeft = 1026,
        /// <summary>
        /// The back right draw buffers enum
        /// </summary>
        BackRight = 1027,
        /// <summary>
        /// The aux draw buffers enum
        /// </summary>
        Aux0 = 1033,
        /// <summary>
        /// The aux draw buffers enum
        /// </summary>
        Aux1 = 1034,
        /// <summary>
        /// The aux draw buffers enum
        /// </summary>
        Aux2 = 1035,
        /// <summary>
        /// The aux draw buffers enum
        /// </summary>
        Aux3 = 1036,
        /// <summary>
        /// The color attachment draw buffers enum
        /// </summary>
        ColorAttachment0 = 36064,
        /// <summary>
        /// The color attachment draw buffers enum
        /// </summary>
        ColorAttachment1 = 36065,
        /// <summary>
        /// The color attachment draw buffers enum
        /// </summary>
        ColorAttachment2 = 36066,
        /// <summary>
        /// The color attachment draw buffers enum
        /// </summary>
        ColorAttachment3 = 36067,
        /// <summary>
        /// The color attachment draw buffers enum
        /// </summary>
        ColorAttachment4 = 36068,
        /// <summary>
        /// The color attachment draw buffers enum
        /// </summary>
        ColorAttachment5 = 36069,
        /// <summary>
        /// The color attachment draw buffers enum
        /// </summary>
        ColorAttachment6 = 36070,
        /// <summary>
        /// The color attachment draw buffers enum
        /// </summary>
        ColorAttachment7 = 36071,
        /// <summary>
        /// The color attachment draw buffers enum
        /// </summary>
        ColorAttachment8 = 36072,
        /// <summary>
        /// The color attachment draw buffers enum
        /// </summary>
        ColorAttachment9 = 36073,
        /// <summary>
        /// The color attachment 10 draw buffers enum
        /// </summary>
        ColorAttachment10 = 36074,
        /// <summary>
        /// The color attachment 11 draw buffers enum
        /// </summary>
        ColorAttachment11 = 36075,
        /// <summary>
        /// The color attachment 12 draw buffers enum
        /// </summary>
        ColorAttachment12 = 36076,
        /// <summary>
        /// The color attachment 13 draw buffers enum
        /// </summary>
        ColorAttachment13 = 36077,
        /// <summary>
        /// The color attachment 14 draw buffers enum
        /// </summary>
        ColorAttachment14 = 36078,
        /// <summary>
        /// The color attachment 15 draw buffers enum
        /// </summary>
        ColorAttachment15 = 36079
    }

    /// <summary>
    /// The framebuffer error code enum
    /// </summary>
    public enum FramebufferErrorCode
    {
        /// <summary>
        /// The framebuffer undefined framebuffer error code
        /// </summary>
        FramebufferUndefined = 33305,
        /// <summary>
        /// The framebuffer complete framebuffer error code
        /// </summary>
        FramebufferComplete = 36053,
        /// <summary>
        /// The framebuffer complete ext framebuffer error code
        /// </summary>
        FramebufferCompleteExt = 36053,
        /// <summary>
        /// The framebuffer incomplete attachment framebuffer error code
        /// </summary>
        FramebufferIncompleteAttachment = 36054,
        /// <summary>
        /// The framebuffer incomplete attachment ext framebuffer error code
        /// </summary>
        FramebufferIncompleteAttachmentExt = 36054,
        /// <summary>
        /// The framebuffer incomplete missing attachment framebuffer error code
        /// </summary>
        FramebufferIncompleteMissingAttachment = 36055,
        /// <summary>
        /// The framebuffer incomplete missing attachment ext framebuffer error code
        /// </summary>
        FramebufferIncompleteMissingAttachmentExt = 36055,
        /// <summary>
        /// The framebuffer incomplete dimensions ext framebuffer error code
        /// </summary>
        FramebufferIncompleteDimensionsExt = 36057,
        /// <summary>
        /// The framebuffer incomplete formats ext framebuffer error code
        /// </summary>
        FramebufferIncompleteFormatsExt = 36058,
        /// <summary>
        /// The framebuffer incomplete draw buffer framebuffer error code
        /// </summary>
        FramebufferIncompleteDrawBuffer = 36059,
        /// <summary>
        /// The framebuffer incomplete draw buffer ext framebuffer error code
        /// </summary>
        FramebufferIncompleteDrawBufferExt = 36059,
        /// <summary>
        /// The framebuffer incomplete read buffer framebuffer error code
        /// </summary>
        FramebufferIncompleteReadBuffer = 36060,
        /// <summary>
        /// The framebuffer incomplete read buffer ext framebuffer error code
        /// </summary>
        FramebufferIncompleteReadBufferExt = 36060,
        /// <summary>
        /// The framebuffer unsupported framebuffer error code
        /// </summary>
        FramebufferUnsupported = 36061,
        /// <summary>
        /// The framebuffer unsupported ext framebuffer error code
        /// </summary>
        FramebufferUnsupportedExt = 36061,
        /// <summary>
        /// The framebuffer incomplete multisample framebuffer error code
        /// </summary>
        FramebufferIncompleteMultisample = 36182,
        /// <summary>
        /// The framebuffer incomplete layer targets framebuffer error code
        /// </summary>
        FramebufferIncompleteLayerTargets = 36264,
        /// <summary>
        /// The framebuffer incomplete layer count framebuffer error code
        /// </summary>
        FramebufferIncompleteLayerCount = 36265
    }

    /// <summary>
    /// The buffer target enum
    /// </summary>
    public enum BufferTarget
    {
        /// <summary>
        /// The array buffer buffer target
        /// </summary>
        ArrayBuffer = 34962,
        /// <summary>
        /// The element array buffer buffer target
        /// </summary>
        ElementArrayBuffer = 34963,
        /// <summary>
        /// The pixel pack buffer buffer target
        /// </summary>
        PixelPackBuffer = 35051,
        /// <summary>
        /// The pixel unpack buffer buffer target
        /// </summary>
        PixelUnpackBuffer = 35052,
        /// <summary>
        /// The uniform buffer buffer target
        /// </summary>
        UniformBuffer = 35345,
        /// <summary>
        /// The texture buffer buffer target
        /// </summary>
        TextureBuffer = 35882,
        /// <summary>
        /// The transform feedback buffer buffer target
        /// </summary>
        TransformFeedbackBuffer = 35982,
        /// <summary>
        /// The copy read buffer buffer target
        /// </summary>
        CopyReadBuffer = 36662,
        /// <summary>
        /// The copy write buffer buffer target
        /// </summary>
        CopyWriteBuffer = 36663,
        /// <summary>
        /// The draw indirect buffer buffer target
        /// </summary>
        DrawIndirectBuffer = 36671,
        /// <summary>
        /// The shader storage buffer buffer target
        /// </summary>
        ShaderStorageBuffer = 37074,
        /// <summary>
        /// The dispatch indirect buffer buffer target
        /// </summary>
        DispatchIndirectBuffer = 37102,
        /// <summary>
        /// The query buffer buffer target
        /// </summary>
        QueryBuffer = 37266,
        /// <summary>
        /// The atomic counter buffer buffer target
        /// </summary>
        AtomicCounterBuffer = 37568
    }

    /// <summary>
    /// The gl pixel format enum
    /// </summary>
    public enum GLPixelFormat
    {
        /// <summary>
        /// The unsigned short gl pixel format
        /// </summary>
        UnsignedShort = 5123,
        /// <summary>
        /// The unsigned int gl pixel format
        /// </summary>
        UnsignedInt = 5125,
        /// <summary>
        /// The color index gl pixel format
        /// </summary>
        ColorIndex = 6400,
        /// <summary>
        /// The stencil index gl pixel format
        /// </summary>
        StencilIndex = 6401,
        /// <summary>
        /// The depth component gl pixel format
        /// </summary>
        DepthComponent = 6402,
        /// <summary>
        /// The red gl pixel format
        /// </summary>
        Red = 6403,
        /// <summary>
        /// The red ext gl pixel format
        /// </summary>
        RedExt = 6403,
        /// <summary>
        /// The green gl pixel format
        /// </summary>
        Green = 6404,
        /// <summary>
        /// The blue gl pixel format
        /// </summary>
        Blue = 6405,
        /// <summary>
        /// The alpha gl pixel format
        /// </summary>
        Alpha = 6406,
        /// <summary>
        /// The rgb gl pixel format
        /// </summary>
        Rgb = 6407,
        /// <summary>
        /// The rgba gl pixel format
        /// </summary>
        Rgba = 6408,
        /// <summary>
        /// The luminance gl pixel format
        /// </summary>
        Luminance = 6409,
        /// <summary>
        /// The luminance alpha gl pixel format
        /// </summary>
        LuminanceAlpha = 6410,
        /// <summary>
        /// The abgr ext gl pixel format
        /// </summary>
        AbgrExt = 32768,
        /// <summary>
        /// The cmyk ext gl pixel format
        /// </summary>
        CmykExt = 32780,
        /// <summary>
        /// The cmyka ext gl pixel format
        /// </summary>
        CmykaExt = 32781,
        /// <summary>
        /// The bgr gl pixel format
        /// </summary>
        Bgr = 32992,
        /// <summary>
        /// The bgra gl pixel format
        /// </summary>
        Bgra = 32993,
        /// <summary>
        /// The ycrcb 422 sgix gl pixel format
        /// </summary>
        Ycrcb422Sgix = 33211,
        /// <summary>
        /// The ycrcb 444 sgix gl pixel format
        /// </summary>
        Ycrcb444Sgix = 33212,
        /// <summary>
        /// The rg gl pixel format
        /// </summary>
        Rg = 33319,
        /// <summary>
        /// The rg integer gl pixel format
        /// </summary>
        RgInteger = 33320,
        /// <summary>
        /// The icc sgix gl pixel format
        /// </summary>
        R5G6B5IccSgix = 33894,
        /// <summary>
        /// The icc sgix gl pixel format
        /// </summary>
        R5G6B5A8IccSgix = 33895,
        /// <summary>
        /// The alpha 16 icc sgix gl pixel format
        /// </summary>
        Alpha16IccSgix = 33896,
        /// <summary>
        /// The luminance 16 icc sgix gl pixel format
        /// </summary>
        Luminance16IccSgix = 33897,
        /// <summary>
        /// The luminance 16 alpha icc sgix gl pixel format
        /// </summary>
        Luminance16Alpha8IccSgix = 33899,
        /// <summary>
        /// The depth stencil gl pixel format
        /// </summary>
        DepthStencil = 34041,
        /// <summary>
        /// The red integer gl pixel format
        /// </summary>
        RedInteger = 36244,
        /// <summary>
        /// The green integer gl pixel format
        /// </summary>
        GreenInteger = 36245,
        /// <summary>
        /// The blue integer gl pixel format
        /// </summary>
        BlueInteger = 36246,
        /// <summary>
        /// The alpha integer gl pixel format
        /// </summary>
        AlphaInteger = 36247,
        /// <summary>
        /// The rgb integer gl pixel format
        /// </summary>
        RgbInteger = 36248,
        /// <summary>
        /// The rgba integer gl pixel format
        /// </summary>
        RgbaInteger = 36249,
        /// <summary>
        /// The bgr integer gl pixel format
        /// </summary>
        BgrInteger = 36250,
        /// <summary>
        /// The bgra integer gl pixel format
        /// </summary>
        BgraInteger = 36251
    }

    /// <summary>
    /// The gl pixel type enum
    /// </summary>
    public enum GLPixelType
    {
        /// <summary>
        /// The byte gl pixel type
        /// </summary>
        Byte = 5120,
        /// <summary>
        /// The unsigned byte gl pixel type
        /// </summary>
        UnsignedByte = 5121,
        /// <summary>
        /// The short gl pixel type
        /// </summary>
        Short = 5122,
        /// <summary>
        /// The unsigned short gl pixel type
        /// </summary>
        UnsignedShort = 5123,
        /// <summary>
        /// The int gl pixel type
        /// </summary>
        Int = 5124,
        /// <summary>
        /// The unsigned int gl pixel type
        /// </summary>
        UnsignedInt = 5125,
        /// <summary>
        /// The float gl pixel type
        /// </summary>
        Float = 5126,
        /// <summary>
        /// The half float gl pixel type
        /// </summary>
        HalfFloat = 5131,
        /// <summary>
        /// The bitmap gl pixel type
        /// </summary>
        Bitmap = 6656,
        /// <summary>
        /// The unsigned byte 332 gl pixel type
        /// </summary>
        UnsignedByte332 = 32818,
        /// <summary>
        /// The unsigned byte 332 ext gl pixel type
        /// </summary>
        UnsignedByte332Ext = 32818,
        /// <summary>
        /// The unsigned short 4444 gl pixel type
        /// </summary>
        UnsignedShort4444 = 32819,
        /// <summary>
        /// The unsigned short 4444 ext gl pixel type
        /// </summary>
        UnsignedShort4444Ext = 32819,
        /// <summary>
        /// The unsigned short 5551 gl pixel type
        /// </summary>
        UnsignedShort5551 = 32820,
        /// <summary>
        /// The unsigned short 5551 ext gl pixel type
        /// </summary>
        UnsignedShort5551Ext = 32820,
        /// <summary>
        /// The unsigned int 8888 gl pixel type
        /// </summary>
        UnsignedInt8888 = 32821,
        /// <summary>
        /// The unsigned int 8888 ext gl pixel type
        /// </summary>
        UnsignedInt8888Ext = 32821,
        /// <summary>
        /// The unsigned int 1010102 gl pixel type
        /// </summary>
        UnsignedInt1010102 = 32822,
        /// <summary>
        /// The unsigned int 1010102 ext gl pixel type
        /// </summary>
        UnsignedInt1010102Ext = 32822,
        /// <summary>
        /// The unsigned byte 233 reversed gl pixel type
        /// </summary>
        UnsignedByte233Reversed = 33634,
        /// <summary>
        /// The unsigned short 565 gl pixel type
        /// </summary>
        UnsignedShort565 = 33635,
        /// <summary>
        /// The unsigned short 565 reversed gl pixel type
        /// </summary>
        UnsignedShort565Reversed = 33636,
        /// <summary>
        /// The unsigned short 4444 reversed gl pixel type
        /// </summary>
        UnsignedShort4444Reversed = 33637,
        /// <summary>
        /// The unsigned short 1555 reversed gl pixel type
        /// </summary>
        UnsignedShort1555Reversed = 33638,
        /// <summary>
        /// The unsigned int 8888 reversed gl pixel type
        /// </summary>
        UnsignedInt8888Reversed = 33639,
        /// <summary>
        /// The unsigned int 2101010 reversed gl pixel type
        /// </summary>
        UnsignedInt2101010Reversed = 33640,
        /// <summary>
        /// The unsigned int 248 gl pixel type
        /// </summary>
        UnsignedInt248 = 34042,
        /// <summary>
        /// The unsigned int 10 11 11 rev gl pixel type
        /// </summary>
        UnsignedInt10F11F11FRev = 35899,
        /// <summary>
        /// The unsigned int 5999 rev gl pixel type
        /// </summary>
        UnsignedInt5999Rev = 35902,
        /// <summary>
        /// The float 32 unsigned int 248 rev gl pixel type
        /// </summary>
        Float32UnsignedInt248Rev = 36269
    }

    /// <summary>
    /// The pixel internal format enum
    /// </summary>
    public enum PixelInternalFormat
    {
        /// <summary>
        /// The one pixel internal format
        /// </summary>
        One = 1,
        /// <summary>
        /// The two pixel internal format
        /// </summary>
        Two = 2,
        /// <summary>
        /// The three pixel internal format
        /// </summary>
        Three = 3,
        /// <summary>
        /// The four pixel internal format
        /// </summary>
        Four = 4,
        /// <summary>
        /// The depth component pixel internal format
        /// </summary>
        DepthComponent = 6402,
        /// <summary>
        /// The alpha pixel internal format
        /// </summary>
        Alpha = 6406,
        /// <summary>
        /// The rgb pixel internal format
        /// </summary>
        Rgb = 6407,
        /// <summary>
        /// The rgba pixel internal format
        /// </summary>
        Rgba = 6408,
        /// <summary>
        /// The luminance pixel internal format
        /// </summary>
        Luminance = 6409,
        /// <summary>
        /// The luminance alpha pixel internal format
        /// </summary>
        LuminanceAlpha = 6410,
        /// <summary>
        /// The  pixel internal format
        /// </summary>
        R3G3B2 = 10768,
        /// <summary>
        /// The alpha pixel internal format
        /// </summary>
        Alpha4 = 32827,
        /// <summary>
        /// The alpha pixel internal format
        /// </summary>
        Alpha8 = 32828,
        /// <summary>
        /// The alpha 12 pixel internal format
        /// </summary>
        Alpha12 = 32829,
        /// <summary>
        /// The alpha 16 pixel internal format
        /// </summary>
        Alpha16 = 32830,
        /// <summary>
        /// The luminance pixel internal format
        /// </summary>
        Luminance4 = 32831,
        /// <summary>
        /// The luminance pixel internal format
        /// </summary>
        Luminance8 = 32832,
        /// <summary>
        /// The luminance 12 pixel internal format
        /// </summary>
        Luminance12 = 32833,
        /// <summary>
        /// The luminance 16 pixel internal format
        /// </summary>
        Luminance16 = 32834,
        /// <summary>
        /// The luminance alpha pixel internal format
        /// </summary>
        Luminance4Alpha4 = 32835,
        /// <summary>
        /// The luminance alpha pixel internal format
        /// </summary>
        Luminance6Alpha2 = 32836,
        /// <summary>
        /// The luminance alpha pixel internal format
        /// </summary>
        Luminance8Alpha8 = 32837,
        /// <summary>
        /// The luminance 12 alpha pixel internal format
        /// </summary>
        Luminance12Alpha4 = 32838,
        /// <summary>
        /// The luminance 12 alpha 12 pixel internal format
        /// </summary>
        Luminance12Alpha12 = 32839,
        /// <summary>
        /// The luminance 16 alpha 16 pixel internal format
        /// </summary>
        Luminance16Alpha16 = 32840,
        /// <summary>
        /// The intensity pixel internal format
        /// </summary>
        Intensity = 32841,
        /// <summary>
        /// The intensity pixel internal format
        /// </summary>
        Intensity4 = 32842,
        /// <summary>
        /// The intensity pixel internal format
        /// </summary>
        Intensity8 = 32843,
        /// <summary>
        /// The intensity 12 pixel internal format
        /// </summary>
        Intensity12 = 32844,
        /// <summary>
        /// The intensity 16 pixel internal format
        /// </summary>
        Intensity16 = 32845,
        /// <summary>
        /// The rgb ext pixel internal format
        /// </summary>
        Rgb2Ext = 32846,
        /// <summary>
        /// The rgb pixel internal format
        /// </summary>
        Rgb4 = 32847,
        /// <summary>
        /// The rgb pixel internal format
        /// </summary>
        Rgb5 = 32848,
        /// <summary>
        /// The rgb pixel internal format
        /// </summary>
        Rgb8 = 32849,
        /// <summary>
        /// The rgb 10 pixel internal format
        /// </summary>
        Rgb10 = 32850,
        /// <summary>
        /// The rgb 12 pixel internal format
        /// </summary>
        Rgb12 = 32851,
        /// <summary>
        /// The rgb 16 pixel internal format
        /// </summary>
        Rgb16 = 32852,
        /// <summary>
        /// The rgba pixel internal format
        /// </summary>
        Rgba2 = 32853,
        /// <summary>
        /// The rgba pixel internal format
        /// </summary>
        Rgba4 = 32854,
        /// <summary>
        /// The rgb pixel internal format
        /// </summary>
        Rgb5A1 = 32855,
        /// <summary>
        /// The rgba pixel internal format
        /// </summary>
        Rgba8 = 32856,
        /// <summary>
        /// The rgb 10 pixel internal format
        /// </summary>
        Rgb10A2 = 32857,
        /// <summary>
        /// The rgba 12 pixel internal format
        /// </summary>
        Rgba12 = 32858,
        /// <summary>
        /// The rgba 16 pixel internal format
        /// </summary>
        Rgba16 = 32859,
        /// <summary>
        /// The dual alpha sgis pixel internal format
        /// </summary>
        DualAlpha4Sgis = 33040,
        /// <summary>
        /// The dual alpha sgis pixel internal format
        /// </summary>
        DualAlpha8Sgis = 33041,
        /// <summary>
        /// The dual alpha 12 sgis pixel internal format
        /// </summary>
        DualAlpha12Sgis = 33042,
        /// <summary>
        /// The dual alpha 16 sgis pixel internal format
        /// </summary>
        DualAlpha16Sgis = 33043,
        /// <summary>
        /// The dual luminance sgis pixel internal format
        /// </summary>
        DualLuminance4Sgis = 33044,
        /// <summary>
        /// The dual luminance sgis pixel internal format
        /// </summary>
        DualLuminance8Sgis = 33045,
        /// <summary>
        /// The dual luminance 12 sgis pixel internal format
        /// </summary>
        DualLuminance12Sgis = 33046,
        /// <summary>
        /// The dual luminance 16 sgis pixel internal format
        /// </summary>
        DualLuminance16Sgis = 33047,
        /// <summary>
        /// The dual intensity sgis pixel internal format
        /// </summary>
        DualIntensity4Sgis = 33048,
        /// <summary>
        /// The dual intensity sgis pixel internal format
        /// </summary>
        DualIntensity8Sgis = 33049,
        /// <summary>
        /// The dual intensity 12 sgis pixel internal format
        /// </summary>
        DualIntensity12Sgis = 33050,
        /// <summary>
        /// The dual intensity 16 sgis pixel internal format
        /// </summary>
        DualIntensity16Sgis = 33051,
        /// <summary>
        /// The dual luminance alpha sgis pixel internal format
        /// </summary>
        DualLuminanceAlpha4Sgis = 33052,
        /// <summary>
        /// The dual luminance alpha sgis pixel internal format
        /// </summary>
        DualLuminanceAlpha8Sgis = 33053,
        /// <summary>
        /// The quad alpha sgis pixel internal format
        /// </summary>
        QuadAlpha4Sgis = 33054,
        /// <summary>
        /// The quad alpha sgis pixel internal format
        /// </summary>
        QuadAlpha8Sgis = 33055,
        /// <summary>
        /// The quad luminance sgis pixel internal format
        /// </summary>
        QuadLuminance4Sgis = 33056,
        /// <summary>
        /// The quad luminance sgis pixel internal format
        /// </summary>
        QuadLuminance8Sgis = 33057,
        /// <summary>
        /// The quad intensity sgis pixel internal format
        /// </summary>
        QuadIntensity4Sgis = 33058,
        /// <summary>
        /// The quad intensity sgis pixel internal format
        /// </summary>
        QuadIntensity8Sgis = 33059,
        /// <summary>
        /// The depth component 16 pixel internal format
        /// </summary>
        DepthComponent16 = 33189,
        /// <summary>
        /// The depth component 16 sgix pixel internal format
        /// </summary>
        DepthComponent16Sgix = 33189,
        /// <summary>
        /// The depth component 24 pixel internal format
        /// </summary>
        DepthComponent24 = 33190,
        /// <summary>
        /// The depth component 24 sgix pixel internal format
        /// </summary>
        DepthComponent24Sgix = 33190,
        /// <summary>
        /// The depth component 32 pixel internal format
        /// </summary>
        DepthComponent32 = 33191,
        /// <summary>
        /// The depth component 32 sgix pixel internal format
        /// </summary>
        DepthComponent32Sgix = 33191,
        /// <summary>
        /// The compressed red pixel internal format
        /// </summary>
        CompressedRed = 33317,
        /// <summary>
        /// The compressed rg pixel internal format
        /// </summary>
        CompressedRg = 33318,
        /// <summary>
        /// The  pixel internal format
        /// </summary>
        R8 = 33321,
        /// <summary>
        /// The 16 pixel internal format
        /// </summary>
        R16 = 33322,
        /// <summary>
        /// The rg pixel internal format
        /// </summary>
        Rg8 = 33323,
        /// <summary>
        /// The rg 16 pixel internal format
        /// </summary>
        Rg16 = 33324,
        /// <summary>
        /// The 16f pixel internal format
        /// </summary>
        R16f = 33325,
        /// <summary>
        /// The 32f pixel internal format
        /// </summary>
        R32f = 33326,
        /// <summary>
        /// The rg 16f pixel internal format
        /// </summary>
        Rg16f = 33327,
        /// <summary>
        /// The rg 32f pixel internal format
        /// </summary>
        Rg32f = 33328,
        /// <summary>
        /// The 8i pixel internal format
        /// </summary>
        R8i = 33329,
        /// <summary>
        /// The 8ui pixel internal format
        /// </summary>
        R8ui = 33330,
        /// <summary>
        /// The 16i pixel internal format
        /// </summary>
        R16i = 33331,
        /// <summary>
        /// The 16ui pixel internal format
        /// </summary>
        R16ui = 33332,
        /// <summary>
        /// The 32i pixel internal format
        /// </summary>
        R32i = 33333,
        /// <summary>
        /// The 32ui pixel internal format
        /// </summary>
        R32ui = 33334,
        /// <summary>
        /// The rg 8i pixel internal format
        /// </summary>
        Rg8i = 33335,
        /// <summary>
        /// The rg 8ui pixel internal format
        /// </summary>
        Rg8ui = 33336,
        /// <summary>
        /// The rg 16i pixel internal format
        /// </summary>
        Rg16i = 33337,
        /// <summary>
        /// The rg 16ui pixel internal format
        /// </summary>
        Rg16ui = 33338,
        /// <summary>
        /// The rg 32i pixel internal format
        /// </summary>
        Rg32i = 33339,
        /// <summary>
        /// The rg 32ui pixel internal format
        /// </summary>
        Rg32ui = 33340,
        /// <summary>
        /// The compressed rgb 3tc dxt ext pixel internal format
        /// </summary>
        CompressedRgbS3tcDxt1Ext = 33776,
        /// <summary>
        /// The compressed rgba 3tc dxt ext pixel internal format
        /// </summary>
        CompressedRgbaS3tcDxt1Ext = 33777,
        /// <summary>
        /// The compressed rgba 3tc dxt ext pixel internal format
        /// </summary>
        CompressedRgbaS3tcDxt3Ext = 33778,
        /// <summary>
        /// The compressed rgba 3tc dxt ext pixel internal format
        /// </summary>
        CompressedRgbaS3tcDxt5Ext = 33779,
        /// <summary>
        /// The rgb icc sgix pixel internal format
        /// </summary>
        RgbIccSgix = 33888,
        /// <summary>
        /// The rgba icc sgix pixel internal format
        /// </summary>
        RgbaIccSgix = 33889,
        /// <summary>
        /// The alpha icc sgix pixel internal format
        /// </summary>
        AlphaIccSgix = 33890,
        /// <summary>
        /// The luminance icc sgix pixel internal format
        /// </summary>
        LuminanceIccSgix = 33891,
        /// <summary>
        /// The intensity icc sgix pixel internal format
        /// </summary>
        IntensityIccSgix = 33892,
        /// <summary>
        /// The luminance alpha icc sgix pixel internal format
        /// </summary>
        LuminanceAlphaIccSgix = 33893,
        /// <summary>
        /// The icc sgix pixel internal format
        /// </summary>
        R5G6B5IccSgix = 33894,
        /// <summary>
        /// The icc sgix pixel internal format
        /// </summary>
        R5G6B5A8IccSgix = 33895,
        /// <summary>
        /// The alpha 16 icc sgix pixel internal format
        /// </summary>
        Alpha16IccSgix = 33896,
        /// <summary>
        /// The luminance 16 icc sgix pixel internal format
        /// </summary>
        Luminance16IccSgix = 33897,
        /// <summary>
        /// The intensity 16 icc sgix pixel internal format
        /// </summary>
        Intensity16IccSgix = 33898,
        /// <summary>
        /// The luminance 16 alpha icc sgix pixel internal format
        /// </summary>
        Luminance16Alpha8IccSgix = 33899,
        /// <summary>
        /// The compressed alpha pixel internal format
        /// </summary>
        CompressedAlpha = 34025,
        /// <summary>
        /// The compressed luminance pixel internal format
        /// </summary>
        CompressedLuminance = 34026,
        /// <summary>
        /// The compressed luminance alpha pixel internal format
        /// </summary>
        CompressedLuminanceAlpha = 34027,
        /// <summary>
        /// The compressed intensity pixel internal format
        /// </summary>
        CompressedIntensity = 34028,
        /// <summary>
        /// The compressed rgb pixel internal format
        /// </summary>
        CompressedRgb = 34029,
        /// <summary>
        /// The compressed rgba pixel internal format
        /// </summary>
        CompressedRgba = 34030,
        /// <summary>
        /// The depth stencil pixel internal format
        /// </summary>
        DepthStencil = 34041,
        /// <summary>
        /// The rgba 32f pixel internal format
        /// </summary>
        Rgba32f = 34836,
        /// <summary>
        /// The rgb 32f pixel internal format
        /// </summary>
        Rgb32f = 34837,
        /// <summary>
        /// The rgba 16f pixel internal format
        /// </summary>
        Rgba16f = 34842,
        /// <summary>
        /// The rgb 16f pixel internal format
        /// </summary>
        Rgb16f = 34843,
        /// <summary>
        /// The depth 24 stencil pixel internal format
        /// </summary>
        Depth24Stencil8 = 35056,
        /// <summary>
        /// The 11f 11f 10f pixel internal format
        /// </summary>
        R11fG11fB10f = 35898,
        /// <summary>
        /// The rgb pixel internal format
        /// </summary>
        Rgb9E5 = 35901,
        /// <summary>
        /// The srgb pixel internal format
        /// </summary>
        Srgb = 35904,
        /// <summary>
        /// The srgb pixel internal format
        /// </summary>
        Srgb8 = 35905,
        /// <summary>
        /// The srgb alpha pixel internal format
        /// </summary>
        SrgbAlpha = 35906,
        /// <summary>
        /// The srgb alpha pixel internal format
        /// </summary>
        Srgb8Alpha8 = 35907,
        /// <summary>
        /// The sluminance alpha pixel internal format
        /// </summary>
        SluminanceAlpha = 35908,
        /// <summary>
        /// The sluminance alpha pixel internal format
        /// </summary>
        Sluminance8Alpha8 = 35909,
        /// <summary>
        /// The sluminance pixel internal format
        /// </summary>
        Sluminance = 35910,
        /// <summary>
        /// The sluminance pixel internal format
        /// </summary>
        Sluminance8 = 35911,
        /// <summary>
        /// The compressed srgb pixel internal format
        /// </summary>
        CompressedSrgb = 35912,
        /// <summary>
        /// The compressed srgb alpha pixel internal format
        /// </summary>
        CompressedSrgbAlpha = 35913,
        /// <summary>
        /// The compressed sluminance pixel internal format
        /// </summary>
        CompressedSluminance = 35914,
        /// <summary>
        /// The compressed sluminance alpha pixel internal format
        /// </summary>
        CompressedSluminanceAlpha = 35915,
        /// <summary>
        /// The compressed srgb 3tc dxt ext pixel internal format
        /// </summary>
        CompressedSrgbS3tcDxt1Ext = 35916,
        /// <summary>
        /// The compressed srgb alpha 3tc dxt ext pixel internal format
        /// </summary>
        CompressedSrgbAlphaS3tcDxt1Ext = 35917,
        /// <summary>
        /// The compressed srgb alpha 3tc dxt ext pixel internal format
        /// </summary>
        CompressedSrgbAlphaS3tcDxt3Ext = 35918,
        /// <summary>
        /// The compressed srgb alpha 3tc dxt ext pixel internal format
        /// </summary>
        CompressedSrgbAlphaS3tcDxt5Ext = 35919,
        /// <summary>
        /// The depth component 32f pixel internal format
        /// </summary>
        DepthComponent32f = 36012,
        /// <summary>
        /// The depth 32f stencil pixel internal format
        /// </summary>
        Depth32fStencil8 = 36013,
        /// <summary>
        /// The rgba 32ui pixel internal format
        /// </summary>
        Rgba32ui = 36208,
        /// <summary>
        /// The rgb 32ui pixel internal format
        /// </summary>
        Rgb32ui = 36209,
        /// <summary>
        /// The rgba 16ui pixel internal format
        /// </summary>
        Rgba16ui = 36214,
        /// <summary>
        /// The rgb 16ui pixel internal format
        /// </summary>
        Rgb16ui = 36215,
        /// <summary>
        /// The rgba 8ui pixel internal format
        /// </summary>
        Rgba8ui = 36220,
        /// <summary>
        /// The rgb 8ui pixel internal format
        /// </summary>
        Rgb8ui = 36221,
        /// <summary>
        /// The rgba 32i pixel internal format
        /// </summary>
        Rgba32i = 36226,
        /// <summary>
        /// The rgb 32i pixel internal format
        /// </summary>
        Rgb32i = 36227,
        /// <summary>
        /// The rgba 16i pixel internal format
        /// </summary>
        Rgba16i = 36232,
        /// <summary>
        /// The rgb 16i pixel internal format
        /// </summary>
        Rgb16i = 36233,
        /// <summary>
        /// The rgba 8i pixel internal format
        /// </summary>
        Rgba8i = 36238,
        /// <summary>
        /// The rgb 8i pixel internal format
        /// </summary>
        Rgb8i = 36239,
        /// <summary>
        /// The float 32 unsigned int 248 rev pixel internal format
        /// </summary>
        Float32UnsignedInt248Rev = 36269,
        /// <summary>
        /// The compressed red rgtc pixel internal format
        /// </summary>
        CompressedRedRgtc1 = 36283,
        /// <summary>
        /// The compressed signed red rgtc pixel internal format
        /// </summary>
        CompressedSignedRedRgtc1 = 36284,
        /// <summary>
        /// The compressed rg rgtc pixel internal format
        /// </summary>
        CompressedRgRgtc2 = 36285,
        /// <summary>
        /// The compressed signed rg rgtc pixel internal format
        /// </summary>
        CompressedSignedRgRgtc2 = 36286,
        /// <summary>
        /// The compressed rgba bptc unorm pixel internal format
        /// </summary>
        CompressedRgbaBptcUnorm = 36492,
        /// <summary>
        /// The compressed srgb alpha bptc unorm pixel internal format
        /// </summary>
        CompressedSrgbAlphaBptcUnorm = 36493,
        /// <summary>
        /// The compressed rgb bptc signed float pixel internal format
        /// </summary>
        CompressedRgbBptcSignedFloat = 36494,
        /// <summary>
        /// The compressed rgb bptc unsigned float pixel internal format
        /// </summary>
        CompressedRgbBptcUnsignedFloat = 36495,
        /// <summary>
        /// The snorm pixel internal format
        /// </summary>
        R8Snorm = 36756,
        /// <summary>
        /// The rg snorm pixel internal format
        /// </summary>
        Rg8Snorm = 36757,
        /// <summary>
        /// The rgb snorm pixel internal format
        /// </summary>
        Rgb8Snorm = 36758,
        /// <summary>
        /// The rgba snorm pixel internal format
        /// </summary>
        Rgba8Snorm = 36759,
        /// <summary>
        /// The 16 snorm pixel internal format
        /// </summary>
        R16Snorm = 36760,
        /// <summary>
        /// The rg 16 snorm pixel internal format
        /// </summary>
        Rg16Snorm = 36761,
        /// <summary>
        /// The rgb 16 snorm pixel internal format
        /// </summary>
        Rgb16Snorm = 36762,
        /// <summary>
        /// The rgba 16 snorm pixel internal format
        /// </summary>
        Rgba16Snorm = 36763,
        /// <summary>
        /// The rgb 10 2ui pixel internal format
        /// </summary>
        Rgb10A2ui = 36975,
        /// <summary>
        /// The compressed rgb etc pixel internal format
        /// </summary>
        CompressedRgb8Etc2 = 0x9274,
        /// <summary>
        /// The compressed rgb punchthrough alpha etc pixel internal format
        /// </summary>
        CompressedRgb8PunchthroughAlpha1Etc2 = 0x9276,
        /// <summary>
        /// The compressed rgba etc eac pixel internal format
        /// </summary>
        CompressedRgba8Etc2Eac = 0x9278,
    }

    /// <summary>
    /// The pixel store parameter enum
    /// </summary>
    public enum PixelStoreParameter
    {
        /// <summary>
        /// The unpack swap bytes pixel store parameter
        /// </summary>
        UnpackSwapBytes = 3312,
        /// <summary>
        /// The unpack lsb first pixel store parameter
        /// </summary>
        UnpackLsbFirst = 3313,
        /// <summary>
        /// The unpack row length pixel store parameter
        /// </summary>
        UnpackRowLength = 3314,
        /// <summary>
        /// The unpack row length ext pixel store parameter
        /// </summary>
        UnpackRowLengthExt = 3314,
        /// <summary>
        /// The unpack skip rows pixel store parameter
        /// </summary>
        UnpackSkipRows = 3315,
        /// <summary>
        /// The unpack skip rows ext pixel store parameter
        /// </summary>
        UnpackSkipRowsExt = 3315,
        /// <summary>
        /// The unpack skip pixels pixel store parameter
        /// </summary>
        UnpackSkipPixels = 3316,
        /// <summary>
        /// The unpack skip pixels ext pixel store parameter
        /// </summary>
        UnpackSkipPixelsExt = 3316,
        /// <summary>
        /// The unpack alignment pixel store parameter
        /// </summary>
        UnpackAlignment = 3317,
        /// <summary>
        /// The pack swap bytes pixel store parameter
        /// </summary>
        PackSwapBytes = 3328,
        /// <summary>
        /// The pack lsb first pixel store parameter
        /// </summary>
        PackLsbFirst = 3329,
        /// <summary>
        /// The pack row length pixel store parameter
        /// </summary>
        PackRowLength = 3330,
        /// <summary>
        /// The pack skip rows pixel store parameter
        /// </summary>
        PackSkipRows = 3331,
        /// <summary>
        /// The pack skip pixels pixel store parameter
        /// </summary>
        PackSkipPixels = 3332,
        /// <summary>
        /// The pack alignment pixel store parameter
        /// </summary>
        PackAlignment = 3333,
        /// <summary>
        /// The pack skip images pixel store parameter
        /// </summary>
        PackSkipImages = 32875,
        /// <summary>
        /// The pack skip images ext pixel store parameter
        /// </summary>
        PackSkipImagesExt = 32875,
        /// <summary>
        /// The pack image height pixel store parameter
        /// </summary>
        PackImageHeight = 32876,
        /// <summary>
        /// The pack image height ext pixel store parameter
        /// </summary>
        PackImageHeightExt = 32876,
        /// <summary>
        /// The unpack skip images pixel store parameter
        /// </summary>
        UnpackSkipImages = 32877,
        /// <summary>
        /// The unpack skip images ext pixel store parameter
        /// </summary>
        UnpackSkipImagesExt = 32877,
        /// <summary>
        /// The unpack image height pixel store parameter
        /// </summary>
        UnpackImageHeight = 32878,
        /// <summary>
        /// The unpack image height ext pixel store parameter
        /// </summary>
        UnpackImageHeightExt = 32878,
        /// <summary>
        /// The pack skip volumes sgis pixel store parameter
        /// </summary>
        PackSkipVolumesSgis = 33072,
        /// <summary>
        /// The pack image depth sgis pixel store parameter
        /// </summary>
        PackImageDepthSgis = 33073,
        /// <summary>
        /// The unpack skip volumes sgis pixel store parameter
        /// </summary>
        UnpackSkipVolumesSgis = 33074,
        /// <summary>
        /// The unpack image depth sgis pixel store parameter
        /// </summary>
        UnpackImageDepthSgis = 33075,
        /// <summary>
        /// The pixel tile width sgix pixel store parameter
        /// </summary>
        PixelTileWidthSgix = 33088,
        /// <summary>
        /// The pixel tile height sgix pixel store parameter
        /// </summary>
        PixelTileHeightSgix = 33089,
        /// <summary>
        /// The pixel tile grid width sgix pixel store parameter
        /// </summary>
        PixelTileGridWidthSgix = 33090,
        /// <summary>
        /// The pixel tile grid height sgix pixel store parameter
        /// </summary>
        PixelTileGridHeightSgix = 33091,
        /// <summary>
        /// The pixel tile grid depth sgix pixel store parameter
        /// </summary>
        PixelTileGridDepthSgix = 33092,
        /// <summary>
        /// The pixel tile cache size sgix pixel store parameter
        /// </summary>
        PixelTileCacheSizeSgix = 33093,
        /// <summary>
        /// The pack resample sgix pixel store parameter
        /// </summary>
        PackResampleSgix = 33836,
        /// <summary>
        /// The unpack resample sgix pixel store parameter
        /// </summary>
        UnpackResampleSgix = 33837,
        /// <summary>
        /// The pack subsample rate sgix pixel store parameter
        /// </summary>
        PackSubsampleRateSgix = 34208,
        /// <summary>
        /// The unpack subsample rate sgix pixel store parameter
        /// </summary>
        UnpackSubsampleRateSgix = 34209,
        /// <summary>
        /// The pack resample oml pixel store parameter
        /// </summary>
        PackResampleOml = 35204,
        /// <summary>
        /// The unpack resample oml pixel store parameter
        /// </summary>
        UnpackResampleOml = 35205,
        /// <summary>
        /// The unpack compressed block width pixel store parameter
        /// </summary>
        UnpackCompressedBlockWidth = 37159,
        /// <summary>
        /// The unpack compressed block height pixel store parameter
        /// </summary>
        UnpackCompressedBlockHeight = 37160,
        /// <summary>
        /// The unpack compressed block depth pixel store parameter
        /// </summary>
        UnpackCompressedBlockDepth = 37161,
        /// <summary>
        /// The unpack compressed block size pixel store parameter
        /// </summary>
        UnpackCompressedBlockSize = 37162,
        /// <summary>
        /// The pack compressed block width pixel store parameter
        /// </summary>
        PackCompressedBlockWidth = 37163,
        /// <summary>
        /// The pack compressed block height pixel store parameter
        /// </summary>
        PackCompressedBlockHeight = 37164,
        /// <summary>
        /// The pack compressed block depth pixel store parameter
        /// </summary>
        PackCompressedBlockDepth = 37165,
        /// <summary>
        /// The pack compressed block size pixel store parameter
        /// </summary>
        PackCompressedBlockSize = 37166
    }

    /// <summary>
    /// The shader type enum
    /// </summary>
    public enum ShaderType
    {
        /// <summary>
        /// The fragment shader shader type
        /// </summary>
        FragmentShader = 35632,
        /// <summary>
        /// The vertex shader shader type
        /// </summary>
        VertexShader = 35633,
        /// <summary>
        /// The geometry shader shader type
        /// </summary>
        GeometryShader = 36313,
        /// <summary>
        /// The geometry shader ext shader type
        /// </summary>
        GeometryShaderExt = 36313,
        /// <summary>
        /// The tess evaluation shader shader type
        /// </summary>
        TessEvaluationShader = 36487,
        /// <summary>
        /// The tess control shader shader type
        /// </summary>
        TessControlShader = 36488,
        /// <summary>
        /// The compute shader shader type
        /// </summary>
        ComputeShader = 37305
    }

    /// <summary>
    /// The shader parameter enum
    /// </summary>
    public enum ShaderParameter
    {
        /// <summary>
        /// The shader type shader parameter
        /// </summary>
        ShaderType = 35663,
        /// <summary>
        /// The delete status shader parameter
        /// </summary>
        DeleteStatus = 35712,
        /// <summary>
        /// The compile status shader parameter
        /// </summary>
        CompileStatus = 35713,
        /// <summary>
        /// The info log length shader parameter
        /// </summary>
        InfoLogLength = 35716,
        /// <summary>
        /// The shader source length shader parameter
        /// </summary>
        ShaderSourceLength = 35720
    }

    /// <summary>
    /// The sampler parameter name enum
    /// </summary>
    public enum SamplerParameterName
    {
        /// <summary>
        /// The texture border color sampler parameter name
        /// </summary>
        TextureBorderColor = 4100,
        /// <summary>
        /// The texture mag filter sampler parameter name
        /// </summary>
        TextureMagFilter = 10240,
        /// <summary>
        /// The texture min filter sampler parameter name
        /// </summary>
        TextureMinFilter = 10241,
        /// <summary>
        /// The texture wrap sampler parameter name
        /// </summary>
        TextureWrapS = 10242,
        /// <summary>
        /// The texture wrap sampler parameter name
        /// </summary>
        TextureWrapT = 10243,
        /// <summary>
        /// The texture wrap sampler parameter name
        /// </summary>
        TextureWrapR = 32882,
        /// <summary>
        /// The texture min lod sampler parameter name
        /// </summary>
        TextureMinLod = 33082,
        /// <summary>
        /// The texture max lod sampler parameter name
        /// </summary>
        TextureMaxLod = 33083,
        /// <summary>
        /// The texture max anisotropy ext sampler parameter name
        /// </summary>
        TextureMaxAnisotropyExt = 34046,
        /// <summary>
        /// The texture lod bias sampler parameter name
        /// </summary>
        TextureLodBias = 34049,
        /// <summary>
        /// The texture compare mode sampler parameter name
        /// </summary>
        TextureCompareMode = 34892,
        /// <summary>
        /// The texture compare func sampler parameter name
        /// </summary>
        TextureCompareFunc = 34893
    }

    /// <summary>
    /// The texture wrap mode enum
    /// </summary>
    public enum TextureWrapMode
    {
        /// <summary>
        /// The clamp texture wrap mode
        /// </summary>
        Clamp = 10496,
        /// <summary>
        /// The repeat texture wrap mode
        /// </summary>
        Repeat = 10497,
        /// <summary>
        /// The clamp to border texture wrap mode
        /// </summary>
        ClampToBorder = 33069,
        /// <summary>
        /// The clamp to border arb texture wrap mode
        /// </summary>
        ClampToBorderArb = 33069,
        /// <summary>
        /// The clamp to border nv texture wrap mode
        /// </summary>
        ClampToBorderNv = 33069,
        /// <summary>
        /// The clamp to border sgis texture wrap mode
        /// </summary>
        ClampToBorderSgis = 33069,
        /// <summary>
        /// The clamp to edge texture wrap mode
        /// </summary>
        ClampToEdge = 33071,
        /// <summary>
        /// The clamp to edge sgis texture wrap mode
        /// </summary>
        ClampToEdgeSgis = 33071,
        /// <summary>
        /// The mirrored repeat texture wrap mode
        /// </summary>
        MirroredRepeat = 33648
    }

    /// <summary>
    /// The texture min filter enum
    /// </summary>
    public enum TextureMinFilter
    {
        /// <summary>
        /// The nearest texture min filter
        /// </summary>
        Nearest = 9728,
        /// <summary>
        /// The linear texture min filter
        /// </summary>
        Linear = 9729,
        /// <summary>
        /// The nearest mipmap nearest texture min filter
        /// </summary>
        NearestMipmapNearest = 9984,
        /// <summary>
        /// The linear mipmap nearest texture min filter
        /// </summary>
        LinearMipmapNearest = 9985,
        /// <summary>
        /// The nearest mipmap linear texture min filter
        /// </summary>
        NearestMipmapLinear = 9986,
        /// <summary>
        /// The linear mipmap linear texture min filter
        /// </summary>
        LinearMipmapLinear = 9987,
        /// <summary>
        /// The filter sgis texture min filter
        /// </summary>
        Filter4Sgis = 33094,
        /// <summary>
        /// The linear clipmap linear sgix texture min filter
        /// </summary>
        LinearClipmapLinearSgix = 33136,
        /// <summary>
        /// The pixel tex gen ceiling sgix texture min filter
        /// </summary>
        PixelTexGenQCeilingSgix = 33156,
        /// <summary>
        /// The pixel tex gen round sgix texture min filter
        /// </summary>
        PixelTexGenQRoundSgix = 33157,
        /// <summary>
        /// The pixel tex gen floor sgix texture min filter
        /// </summary>
        PixelTexGenQFloorSgix = 33158,
        /// <summary>
        /// The nearest clipmap nearest sgix texture min filter
        /// </summary>
        NearestClipmapNearestSgix = 33869,
        /// <summary>
        /// The nearest clipmap linear sgix texture min filter
        /// </summary>
        NearestClipmapLinearSgix = 33870,
        /// <summary>
        /// The linear clipmap nearest sgix texture min filter
        /// </summary>
        LinearClipmapNearestSgix = 33871
    }

    /// <summary>
    /// The texture mag filter enum
    /// </summary>
    public enum TextureMagFilter
    {
        /// <summary>
        /// The nearest texture mag filter
        /// </summary>
        Nearest = 9728,
        /// <summary>
        /// The linear texture mag filter
        /// </summary>
        Linear = 9729,
        /// <summary>
        /// The linear detail sgis texture mag filter
        /// </summary>
        LinearDetailSgis = 32919,
        /// <summary>
        /// The linear detail alpha sgis texture mag filter
        /// </summary>
        LinearDetailAlphaSgis = 32920,
        /// <summary>
        /// The linear detail color sgis texture mag filter
        /// </summary>
        LinearDetailColorSgis = 32921,
        /// <summary>
        /// The linear sharpen sgis texture mag filter
        /// </summary>
        LinearSharpenSgis = 32941,
        /// <summary>
        /// The linear sharpen alpha sgis texture mag filter
        /// </summary>
        LinearSharpenAlphaSgis = 32942,
        /// <summary>
        /// The linear sharpen color sgis texture mag filter
        /// </summary>
        LinearSharpenColorSgis = 32943,
        /// <summary>
        /// The filter sgis texture mag filter
        /// </summary>
        Filter4Sgis = 33094,
        /// <summary>
        /// The pixel tex gen ceiling sgix texture mag filter
        /// </summary>
        PixelTexGenQCeilingSgix = 33156,
        /// <summary>
        /// The pixel tex gen round sgix texture mag filter
        /// </summary>
        PixelTexGenQRoundSgix = 33157,
        /// <summary>
        /// The pixel tex gen floor sgix texture mag filter
        /// </summary>
        PixelTexGenQFloorSgix = 33158
    }

    /// <summary>
    /// The texture compare mode enum
    /// </summary>
    public enum TextureCompareMode
    {
        /// <summary>
        /// The none texture compare mode
        /// </summary>
        None = 0,
        /// <summary>
        /// The compare ref to texture texture compare mode
        /// </summary>
        CompareRefToTexture = 34894,
        /// <summary>
        /// The compare to texture texture compare mode
        /// </summary>
        CompareRToTexture = 34894
    }

    /// <summary>
    /// The depth function enum
    /// </summary>
    public enum DepthFunction
    {
        /// <summary>
        /// The never depth function
        /// </summary>
        Never = 512,
        /// <summary>
        /// The less depth function
        /// </summary>
        Less = 513,
        /// <summary>
        /// The equal depth function
        /// </summary>
        Equal = 514,
        /// <summary>
        /// The lequal depth function
        /// </summary>
        Lequal = 515,
        /// <summary>
        /// The greater depth function
        /// </summary>
        Greater = 516,
        /// <summary>
        /// The notequal depth function
        /// </summary>
        Notequal = 517,
        /// <summary>
        /// The gequal depth function
        /// </summary>
        Gequal = 518,
        /// <summary>
        /// The always depth function
        /// </summary>
        Always = 519
    }

    /// <summary>
    /// The blending factor src enum
    /// </summary>
    public enum BlendingFactorSrc
    {
        /// <summary>
        /// The zero blending factor src
        /// </summary>
        Zero = 0,
        /// <summary>
        /// The one blending factor src
        /// </summary>
        One = 1,
        /// <summary>
        /// The src color blending factor src
        /// </summary>
        SrcColor = 768,
        /// <summary>
        /// The one minus src color blending factor src
        /// </summary>
        OneMinusSrcColor = 769,
        /// <summary>
        /// The src alpha blending factor src
        /// </summary>
        SrcAlpha = 770,
        /// <summary>
        /// The one minus src alpha blending factor src
        /// </summary>
        OneMinusSrcAlpha = 771,
        /// <summary>
        /// The dst alpha blending factor src
        /// </summary>
        DstAlpha = 772,
        /// <summary>
        /// The one minus dst alpha blending factor src
        /// </summary>
        OneMinusDstAlpha = 773,
        /// <summary>
        /// The dst color blending factor src
        /// </summary>
        DstColor = 774,
        /// <summary>
        /// The one minus dst color blending factor src
        /// </summary>
        OneMinusDstColor = 775,
        /// <summary>
        /// The src alpha saturate blending factor src
        /// </summary>
        SrcAlphaSaturate = 776,
        /// <summary>
        /// The constant color blending factor src
        /// </summary>
        ConstantColor = 32769,
        /// <summary>
        /// The constant color ext blending factor src
        /// </summary>
        ConstantColorExt = 32769,
        /// <summary>
        /// The one minus constant color blending factor src
        /// </summary>
        OneMinusConstantColor = 32770,
        /// <summary>
        /// The one minus constant color ext blending factor src
        /// </summary>
        OneMinusConstantColorExt = 32770,
        /// <summary>
        /// The constant alpha blending factor src
        /// </summary>
        ConstantAlpha = 32771,
        /// <summary>
        /// The constant alpha ext blending factor src
        /// </summary>
        ConstantAlphaExt = 32771,
        /// <summary>
        /// The one minus constant alpha blending factor src
        /// </summary>
        OneMinusConstantAlpha = 32772,
        /// <summary>
        /// The one minus constant alpha ext blending factor src
        /// </summary>
        OneMinusConstantAlphaExt = 32772,
        /// <summary>
        /// The src alpha blending factor src
        /// </summary>
        Src1Alpha = 34185,
        /// <summary>
        /// The src color blending factor src
        /// </summary>
        Src1Color = 35065,
        /// <summary>
        /// The one minus src color blending factor src
        /// </summary>
        OneMinusSrc1Color = 35066,
        /// <summary>
        /// The one minus src alpha blending factor src
        /// </summary>
        OneMinusSrc1Alpha = 35067
    }

    /// <summary>
    /// The blending factor dest enum
    /// </summary>
    public enum BlendingFactorDest
    {
        /// <summary>
        /// The zero blending factor dest
        /// </summary>
        Zero = 0,
        /// <summary>
        /// The one blending factor dest
        /// </summary>
        One = 1,
        /// <summary>
        /// The src color blending factor dest
        /// </summary>
        SrcColor = 768,
        /// <summary>
        /// The one minus src color blending factor dest
        /// </summary>
        OneMinusSrcColor = 769,
        /// <summary>
        /// The src alpha blending factor dest
        /// </summary>
        SrcAlpha = 770,
        /// <summary>
        /// The one minus src alpha blending factor dest
        /// </summary>
        OneMinusSrcAlpha = 771,
        /// <summary>
        /// The dst alpha blending factor dest
        /// </summary>
        DstAlpha = 772,
        /// <summary>
        /// The one minus dst alpha blending factor dest
        /// </summary>
        OneMinusDstAlpha = 773,
        /// <summary>
        /// The dst color blending factor dest
        /// </summary>
        DstColor = 774,
        /// <summary>
        /// The one minus dst color blending factor dest
        /// </summary>
        OneMinusDstColor = 775,
        /// <summary>
        /// The src alpha saturate blending factor dest
        /// </summary>
        SrcAlphaSaturate = 776,
        /// <summary>
        /// The constant color blending factor dest
        /// </summary>
        ConstantColor = 32769,
        /// <summary>
        /// The constant color ext blending factor dest
        /// </summary>
        ConstantColorExt = 32769,
        /// <summary>
        /// The one minus constant color blending factor dest
        /// </summary>
        OneMinusConstantColor = 32770,
        /// <summary>
        /// The one minus constant color ext blending factor dest
        /// </summary>
        OneMinusConstantColorExt = 32770,
        /// <summary>
        /// The constant alpha blending factor dest
        /// </summary>
        ConstantAlpha = 32771,
        /// <summary>
        /// The constant alpha ext blending factor dest
        /// </summary>
        ConstantAlphaExt = 32771,
        /// <summary>
        /// The one minus constant alpha blending factor dest
        /// </summary>
        OneMinusConstantAlpha = 32772,
        /// <summary>
        /// The one minus constant alpha ext blending factor dest
        /// </summary>
        OneMinusConstantAlphaExt = 32772,
        /// <summary>
        /// The src alpha blending factor dest
        /// </summary>
        Src1Alpha = 34185,
        /// <summary>
        /// The src color blending factor dest
        /// </summary>
        Src1Color = 35065,
        /// <summary>
        /// The one minus src color blending factor dest
        /// </summary>
        OneMinusSrc1Color = 35066,
        /// <summary>
        /// The one minus src alpha blending factor dest
        /// </summary>
        OneMinusSrc1Alpha = 35067
    }

    /// <summary>
    /// The enable cap enum
    /// </summary>
    public enum EnableCap
    {
        /// <summary>
        /// The point smooth enable cap
        /// </summary>
        PointSmooth = 2832,
        /// <summary>
        /// The line smooth enable cap
        /// </summary>
        LineSmooth = 2848,
        /// <summary>
        /// The line stipple enable cap
        /// </summary>
        LineStipple = 2852,
        /// <summary>
        /// The polygon smooth enable cap
        /// </summary>
        PolygonSmooth = 2881,
        /// <summary>
        /// The polygon stipple enable cap
        /// </summary>
        PolygonStipple = 2882,
        /// <summary>
        /// The cull face enable cap
        /// </summary>
        CullFace = 2884,
        /// <summary>
        /// The lighting enable cap
        /// </summary>
        Lighting = 2896,
        /// <summary>
        /// The color material enable cap
        /// </summary>
        ColorMaterial = 2903,
        /// <summary>
        /// The fog enable cap
        /// </summary>
        Fog = 2912,
        /// <summary>
        /// The depth test enable cap
        /// </summary>
        DepthTest = 2929,
        /// <summary>
        /// The stencil test enable cap
        /// </summary>
        StencilTest = 2960,
        /// <summary>
        /// The normalize enable cap
        /// </summary>
        Normalize = 2977,
        /// <summary>
        /// The alpha test enable cap
        /// </summary>
        AlphaTest = 3008,
        /// <summary>
        /// The dither enable cap
        /// </summary>
        Dither = 3024,
        /// <summary>
        /// The blend enable cap
        /// </summary>
        Blend = 3042,
        /// <summary>
        /// The index logic op enable cap
        /// </summary>
        IndexLogicOp = 3057,
        /// <summary>
        /// The color logic op enable cap
        /// </summary>
        ColorLogicOp = 3058,
        /// <summary>
        /// The scissor test enable cap
        /// </summary>
        ScissorTest = 3089,
        /// <summary>
        /// The texture gen enable cap
        /// </summary>
        TextureGenS = 3168,
        /// <summary>
        /// The texture gen enable cap
        /// </summary>
        TextureGenT = 3169,
        /// <summary>
        /// The texture gen enable cap
        /// </summary>
        TextureGenR = 3170,
        /// <summary>
        /// The texture gen enable cap
        /// </summary>
        TextureGenQ = 3171,
        /// <summary>
        /// The auto normal enable cap
        /// </summary>
        AutoNormal = 3456,
        /// <summary>
        /// The map color enable cap
        /// </summary>
        Map1Color4 = 3472,
        /// <summary>
        /// The map index enable cap
        /// </summary>
        Map1Index = 3473,
        /// <summary>
        /// The map normal enable cap
        /// </summary>
        Map1Normal = 3474,
        /// <summary>
        /// The map texture coord enable cap
        /// </summary>
        Map1TextureCoord1 = 3475,
        /// <summary>
        /// The map texture coord enable cap
        /// </summary>
        Map1TextureCoord2 = 3476,
        /// <summary>
        /// The map texture coord enable cap
        /// </summary>
        Map1TextureCoord3 = 3477,
        /// <summary>
        /// The map texture coord enable cap
        /// </summary>
        Map1TextureCoord4 = 3478,
        /// <summary>
        /// The map vertex enable cap
        /// </summary>
        Map1Vertex3 = 3479,
        /// <summary>
        /// The map vertex enable cap
        /// </summary>
        Map1Vertex4 = 3480,
        /// <summary>
        /// The map color enable cap
        /// </summary>
        Map2Color4 = 3504,
        /// <summary>
        /// The map index enable cap
        /// </summary>
        Map2Index = 3505,
        /// <summary>
        /// The map normal enable cap
        /// </summary>
        Map2Normal = 3506,
        /// <summary>
        /// The map texture coord enable cap
        /// </summary>
        Map2TextureCoord1 = 3507,
        /// <summary>
        /// The map texture coord enable cap
        /// </summary>
        Map2TextureCoord2 = 3508,
        /// <summary>
        /// The map texture coord enable cap
        /// </summary>
        Map2TextureCoord3 = 3509,
        /// <summary>
        /// The map texture coord enable cap
        /// </summary>
        Map2TextureCoord4 = 3510,
        /// <summary>
        /// The map vertex enable cap
        /// </summary>
        Map2Vertex3 = 3511,
        /// <summary>
        /// The map vertex enable cap
        /// </summary>
        Map2Vertex4 = 3512,
        /// <summary>
        /// The texture enable cap
        /// </summary>
        Texture1D = 3552,
        /// <summary>
        /// The texture enable cap
        /// </summary>
        Texture2D = 3553,
        /// <summary>
        /// The polygon offset point enable cap
        /// </summary>
        PolygonOffsetPoint = 10753,
        /// <summary>
        /// The polygon offset line enable cap
        /// </summary>
        PolygonOffsetLine = 10754,
        /// <summary>
        /// The clip distance enable cap
        /// </summary>
        ClipDistance0 = 12288,
        /// <summary>
        /// The clip plane enable cap
        /// </summary>
        ClipPlane0 = 12288,
        /// <summary>
        /// The clip distance enable cap
        /// </summary>
        ClipDistance1 = 12289,
        /// <summary>
        /// The clip plane enable cap
        /// </summary>
        ClipPlane1 = 12289,
        /// <summary>
        /// The clip distance enable cap
        /// </summary>
        ClipDistance2 = 12290,
        /// <summary>
        /// The clip plane enable cap
        /// </summary>
        ClipPlane2 = 12290,
        /// <summary>
        /// The clip distance enable cap
        /// </summary>
        ClipDistance3 = 12291,
        /// <summary>
        /// The clip plane enable cap
        /// </summary>
        ClipPlane3 = 12291,
        /// <summary>
        /// The clip distance enable cap
        /// </summary>
        ClipDistance4 = 12292,
        /// <summary>
        /// The clip plane enable cap
        /// </summary>
        ClipPlane4 = 12292,
        /// <summary>
        /// The clip distance enable cap
        /// </summary>
        ClipDistance5 = 12293,
        /// <summary>
        /// The clip plane enable cap
        /// </summary>
        ClipPlane5 = 12293,
        /// <summary>
        /// The clip distance enable cap
        /// </summary>
        ClipDistance6 = 12294,
        /// <summary>
        /// The clip distance enable cap
        /// </summary>
        ClipDistance7 = 12295,
        /// <summary>
        /// The light enable cap
        /// </summary>
        Light0 = 16384,
        /// <summary>
        /// The light enable cap
        /// </summary>
        Light1 = 16385,
        /// <summary>
        /// The light enable cap
        /// </summary>
        Light2 = 16386,
        /// <summary>
        /// The light enable cap
        /// </summary>
        Light3 = 16387,
        /// <summary>
        /// The light enable cap
        /// </summary>
        Light4 = 16388,
        /// <summary>
        /// The light enable cap
        /// </summary>
        Light5 = 16389,
        /// <summary>
        /// The light enable cap
        /// </summary>
        Light6 = 16390,
        /// <summary>
        /// The light enable cap
        /// </summary>
        Light7 = 16391,
        /// <summary>
        /// The convolution enable cap
        /// </summary>
        Convolution1D = 32784,
        /// <summary>
        /// The convolution ext enable cap
        /// </summary>
        Convolution1DExt = 32784,
        /// <summary>
        /// The convolution enable cap
        /// </summary>
        Convolution2D = 32785,
        /// <summary>
        /// The convolution ext enable cap
        /// </summary>
        Convolution2DExt = 32785,
        /// <summary>
        /// The separable enable cap
        /// </summary>
        Separable2D = 32786,
        /// <summary>
        /// The separable ext enable cap
        /// </summary>
        Separable2DExt = 32786,
        /// <summary>
        /// The histogram enable cap
        /// </summary>
        Histogram = 32804,
        /// <summary>
        /// The histogram ext enable cap
        /// </summary>
        HistogramExt = 32804,
        /// <summary>
        /// The minmax ext enable cap
        /// </summary>
        MinmaxExt = 32814,
        /// <summary>
        /// The polygon offset fill enable cap
        /// </summary>
        PolygonOffsetFill = 32823,
        /// <summary>
        /// The rescale normal enable cap
        /// </summary>
        RescaleNormal = 32826,
        /// <summary>
        /// The rescale normal ext enable cap
        /// </summary>
        RescaleNormalExt = 32826,
        /// <summary>
        /// The texture ext enable cap
        /// </summary>
        Texture3DExt = 32879,
        /// <summary>
        /// The vertex array enable cap
        /// </summary>
        VertexArray = 32884,
        /// <summary>
        /// The normal array enable cap
        /// </summary>
        NormalArray = 32885,
        /// <summary>
        /// The color array enable cap
        /// </summary>
        ColorArray = 32886,
        /// <summary>
        /// The index array enable cap
        /// </summary>
        IndexArray = 32887,
        /// <summary>
        /// The texture coord array enable cap
        /// </summary>
        TextureCoordArray = 32888,
        /// <summary>
        /// The edge flag array enable cap
        /// </summary>
        EdgeFlagArray = 32889,
        /// <summary>
        /// The interlace sgix enable cap
        /// </summary>
        InterlaceSgix = 32916,
        /// <summary>
        /// The multisample enable cap
        /// </summary>
        Multisample = 32925,
        /// <summary>
        /// The multisample sgis enable cap
        /// </summary>
        MultisampleSgis = 32925,
        /// <summary>
        /// The sample alpha to coverage enable cap
        /// </summary>
        SampleAlphaToCoverage = 32926,
        /// <summary>
        /// The sample alpha to mask sgis enable cap
        /// </summary>
        SampleAlphaToMaskSgis = 32926,
        /// <summary>
        /// The sample alpha to one enable cap
        /// </summary>
        SampleAlphaToOne = 32927,
        /// <summary>
        /// The sample alpha to one sgis enable cap
        /// </summary>
        SampleAlphaToOneSgis = 32927,
        /// <summary>
        /// The sample coverage enable cap
        /// </summary>
        SampleCoverage = 32928,
        /// <summary>
        /// The sample mask sgis enable cap
        /// </summary>
        SampleMaskSgis = 32928,
        /// <summary>
        /// The texture color table sgi enable cap
        /// </summary>
        TextureColorTableSgi = 32956,
        /// <summary>
        /// The color table enable cap
        /// </summary>
        ColorTable = 32976,
        /// <summary>
        /// The color table sgi enable cap
        /// </summary>
        ColorTableSgi = 32976,
        /// <summary>
        /// The post convolution color table enable cap
        /// </summary>
        PostConvolutionColorTable = 32977,
        /// <summary>
        /// The post convolution color table sgi enable cap
        /// </summary>
        PostConvolutionColorTableSgi = 32977,
        /// <summary>
        /// The post color matrix color table enable cap
        /// </summary>
        PostColorMatrixColorTable = 32978,
        /// <summary>
        /// The post color matrix color table sgi enable cap
        /// </summary>
        PostColorMatrixColorTableSgi = 32978,
        /// <summary>
        /// The texture sgis enable cap
        /// </summary>
        Texture4DSgis = 33076,
        /// <summary>
        /// The pixel tex gen sgix enable cap
        /// </summary>
        PixelTexGenSgix = 33081,
        /// <summary>
        /// The sprite sgix enable cap
        /// </summary>
        SpriteSgix = 33096,
        /// <summary>
        /// The reference plane sgix enable cap
        /// </summary>
        ReferencePlaneSgix = 33149,
        /// <summary>
        /// The ir instrument sgix enable cap
        /// </summary>
        IrInstrument1Sgix = 33151,
        /// <summary>
        /// The calligraphic fragment sgix enable cap
        /// </summary>
        CalligraphicFragmentSgix = 33155,
        /// <summary>
        /// The framezoom sgix enable cap
        /// </summary>
        FramezoomSgix = 33163,
        /// <summary>
        /// The fog offset sgix enable cap
        /// </summary>
        FogOffsetSgix = 33176,
        /// <summary>
        /// The shared texture palette ext enable cap
        /// </summary>
        SharedTexturePaletteExt = 33275,
        /// <summary>
        /// The debug output synchronous enable cap
        /// </summary>
        DebugOutputSynchronous = 33346,
        /// <summary>
        /// The async histogram sgix enable cap
        /// </summary>
        AsyncHistogramSgix = 33580,
        /// <summary>
        /// The pixel texture sgis enable cap
        /// </summary>
        PixelTextureSgis = 33619,
        /// <summary>
        /// The async tex image sgix enable cap
        /// </summary>
        AsyncTexImageSgix = 33628,
        /// <summary>
        /// The async draw pixels sgix enable cap
        /// </summary>
        AsyncDrawPixelsSgix = 33629,
        /// <summary>
        /// The async read pixels sgix enable cap
        /// </summary>
        AsyncReadPixelsSgix = 33630,
        /// <summary>
        /// The fragment lighting sgix enable cap
        /// </summary>
        FragmentLightingSgix = 33792,
        /// <summary>
        /// The fragment color material sgix enable cap
        /// </summary>
        FragmentColorMaterialSgix = 33793,
        /// <summary>
        /// The fragment light sgix enable cap
        /// </summary>
        FragmentLight0Sgix = 33804,
        /// <summary>
        /// The fragment light sgix enable cap
        /// </summary>
        FragmentLight1Sgix = 33805,
        /// <summary>
        /// The fragment light sgix enable cap
        /// </summary>
        FragmentLight2Sgix = 33806,
        /// <summary>
        /// The fragment light sgix enable cap
        /// </summary>
        FragmentLight3Sgix = 33807,
        /// <summary>
        /// The fragment light sgix enable cap
        /// </summary>
        FragmentLight4Sgix = 33808,
        /// <summary>
        /// The fragment light sgix enable cap
        /// </summary>
        FragmentLight5Sgix = 33809,
        /// <summary>
        /// The fragment light sgix enable cap
        /// </summary>
        FragmentLight6Sgix = 33810,
        /// <summary>
        /// The fragment light sgix enable cap
        /// </summary>
        FragmentLight7Sgix = 33811,
        /// <summary>
        /// The fog coord array enable cap
        /// </summary>
        FogCoordArray = 33879,
        /// <summary>
        /// The color sum enable cap
        /// </summary>
        ColorSum = 33880,
        /// <summary>
        /// The secondary color array enable cap
        /// </summary>
        SecondaryColorArray = 33886,
        /// <summary>
        /// The texture rectangle enable cap
        /// </summary>
        TextureRectangle = 34037,
        /// <summary>
        /// The texture cube map enable cap
        /// </summary>
        TextureCubeMap = 34067,
        /// <summary>
        /// The program point size enable cap
        /// </summary>
        ProgramPointSize = 34370,
        /// <summary>
        /// The vertex program point size enable cap
        /// </summary>
        VertexProgramPointSize = 34370,
        /// <summary>
        /// The vertex program two side enable cap
        /// </summary>
        VertexProgramTwoSide = 34371,
        /// <summary>
        /// The depth clamp enable cap
        /// </summary>
        DepthClamp = 34383,
        /// <summary>
        /// The texture cube map seamless enable cap
        /// </summary>
        TextureCubeMapSeamless = 34895,
        /// <summary>
        /// The point sprite enable cap
        /// </summary>
        PointSprite = 34913,
        /// <summary>
        /// The sample shading enable cap
        /// </summary>
        SampleShading = 35894,
        /// <summary>
        /// The rasterizer discard enable cap
        /// </summary>
        RasterizerDiscard = 35977,
        /// <summary>
        /// The primitive restart fixed index enable cap
        /// </summary>
        PrimitiveRestartFixedIndex = 36201,
        /// <summary>
        /// The framebuffer srgb enable cap
        /// </summary>
        FramebufferSrgb = 36281,
        /// <summary>
        /// The sample mask enable cap
        /// </summary>
        SampleMask = 36433,
        /// <summary>
        /// The primitive restart enable cap
        /// </summary>
        PrimitiveRestart = 36765,
        /// <summary>
        /// The debug output enable cap
        /// </summary>
        DebugOutput = 37600
    }

    /// <summary>
    /// The blend equation mode enum
    /// </summary>
    public enum BlendEquationMode
    {
        /// <summary>
        /// The func add blend equation mode
        /// </summary>
        FuncAdd = 32774,
        /// <summary>
        /// The min blend equation mode
        /// </summary>
        Min = 32775,
        /// <summary>
        /// The max blend equation mode
        /// </summary>
        Max = 32776,
        /// <summary>
        /// The func subtract blend equation mode
        /// </summary>
        FuncSubtract = 32778,
        /// <summary>
        /// The func reverse subtract blend equation mode
        /// </summary>
        FuncReverseSubtract = 32779
    }

    /// <summary>
    /// The cull face mode enum
    /// </summary>
    public enum CullFaceMode
    {
        /// <summary>
        /// The front cull face mode
        /// </summary>
        Front = 1028,
        /// <summary>
        /// The back cull face mode
        /// </summary>
        Back = 1029,
        /// <summary>
        /// The front and back cull face mode
        /// </summary>
        FrontAndBack = 1032
    }

    /// <summary>
    /// The material face enum
    /// </summary>
    public enum MaterialFace
    {
        /// <summary>
        /// The front material face
        /// </summary>
        Front = 1028,
        /// <summary>
        /// The back material face
        /// </summary>
        Back = 1029,
        /// <summary>
        /// The front and back material face
        /// </summary>
        FrontAndBack = 1032
    }

    /// <summary>
    /// The polygon mode enum
    /// </summary>
    public enum PolygonMode
    {
        /// <summary>
        /// The point polygon mode
        /// </summary>
        Point = 6912,
        /// <summary>
        /// The line polygon mode
        /// </summary>
        Line = 6913,
        /// <summary>
        /// The fill polygon mode
        /// </summary>
        Fill = 6914
    }

    /// <summary>
    /// The get program parameter name enum
    /// </summary>
    public enum GetProgramParameterName
    {
        /// <summary>
        /// The program binary retrievable hint get program parameter name
        /// </summary>
        ProgramBinaryRetrievableHint = 33367,
        /// <summary>
        /// The program separable get program parameter name
        /// </summary>
        ProgramSeparable = 33368,
        /// <summary>
        /// The geometry shader invocations get program parameter name
        /// </summary>
        GeometryShaderInvocations = 34943,
        /// <summary>
        /// The geometry vertices out get program parameter name
        /// </summary>
        GeometryVerticesOut = 35094,
        /// <summary>
        /// The geometry input type get program parameter name
        /// </summary>
        GeometryInputType = 35095,
        /// <summary>
        /// The geometry output type get program parameter name
        /// </summary>
        GeometryOutputType = 35096,
        /// <summary>
        /// The active uniform block max name length get program parameter name
        /// </summary>
        ActiveUniformBlockMaxNameLength = 35381,
        /// <summary>
        /// The active uniform blocks get program parameter name
        /// </summary>
        ActiveUniformBlocks = 35382,
        /// <summary>
        /// The delete status get program parameter name
        /// </summary>
        DeleteStatus = 35712,
        /// <summary>
        /// The link status get program parameter name
        /// </summary>
        LinkStatus = 35714,
        /// <summary>
        /// The validate status get program parameter name
        /// </summary>
        ValidateStatus = 35715,
        /// <summary>
        /// The info log length get program parameter name
        /// </summary>
        InfoLogLength = 35716,
        /// <summary>
        /// The attached shaders get program parameter name
        /// </summary>
        AttachedShaders = 35717,
        /// <summary>
        /// The active uniforms get program parameter name
        /// </summary>
        ActiveUniforms = 35718,
        /// <summary>
        /// The active uniform max length get program parameter name
        /// </summary>
        ActiveUniformMaxLength = 35719,
        /// <summary>
        /// The active attributes get program parameter name
        /// </summary>
        ActiveAttributes = 35721,
        /// <summary>
        /// The active attribute max length get program parameter name
        /// </summary>
        ActiveAttributeMaxLength = 35722,
        /// <summary>
        /// The transform feedback varying max length get program parameter name
        /// </summary>
        TransformFeedbackVaryingMaxLength = 35958,
        /// <summary>
        /// The transform feedback buffer mode get program parameter name
        /// </summary>
        TransformFeedbackBufferMode = 35967,
        /// <summary>
        /// The transform feedback varyings get program parameter name
        /// </summary>
        TransformFeedbackVaryings = 35971,
        /// <summary>
        /// The tess control output vertices get program parameter name
        /// </summary>
        TessControlOutputVertices = 36469,
        /// <summary>
        /// The tess gen mode get program parameter name
        /// </summary>
        TessGenMode = 36470,
        /// <summary>
        /// The tess gen spacing get program parameter name
        /// </summary>
        TessGenSpacing = 36471,
        /// <summary>
        /// The tess gen vertex order get program parameter name
        /// </summary>
        TessGenVertexOrder = 36472,
        /// <summary>
        /// The tess gen point mode get program parameter name
        /// </summary>
        TessGenPointMode = 36473,
        /// <summary>
        /// The max compute work group size get program parameter name
        /// </summary>
        MaxComputeWorkGroupSize = 37311,
        /// <summary>
        /// The active atomic counter buffers get program parameter name
        /// </summary>
        ActiveAtomicCounterBuffers = 37593
    }

    /// <summary>
    /// The buffer range target enum
    /// </summary>
    public enum BufferRangeTarget
    {
        /// <summary>
        /// The uniform buffer buffer range target
        /// </summary>
        UniformBuffer = 35345,
        /// <summary>
        /// The transform feedback buffer buffer range target
        /// </summary>
        TransformFeedbackBuffer = 35982,
        /// <summary>
        /// The shader storage buffer buffer range target
        /// </summary>
        ShaderStorageBuffer = 37074,
        /// <summary>
        /// The atomic counter buffer buffer range target
        /// </summary>
        AtomicCounterBuffer = 37568
    }

    /// <summary>
    /// The debug source enum
    /// </summary>
    public enum DebugSource
    {
        /// <summary>
        /// The debug source api debug source
        /// </summary>
        DebugSourceApi = 33350,
        /// <summary>
        /// The debug source window system debug source
        /// </summary>
        DebugSourceWindowSystem = 33351,
        /// <summary>
        /// The debug source shader compiler debug source
        /// </summary>
        DebugSourceShaderCompiler = 33352,
        /// <summary>
        /// The debug source third party debug source
        /// </summary>
        DebugSourceThirdParty = 33353,
        /// <summary>
        /// The debug source application debug source
        /// </summary>
        DebugSourceApplication = 33354,
        /// <summary>
        /// The debug source other debug source
        /// </summary>
        DebugSourceOther = 33355
    }

    /// <summary>
    /// The debug type enum
    /// </summary>
    public enum DebugType
    {
        /// <summary>
        /// The debug type error debug type
        /// </summary>
        DebugTypeError = 33356,
        /// <summary>
        /// The debug type deprecated behavior debug type
        /// </summary>
        DebugTypeDeprecatedBehavior = 33357,
        /// <summary>
        /// The debug type undefined behavior debug type
        /// </summary>
        DebugTypeUndefinedBehavior = 33358,
        /// <summary>
        /// The debug type portability debug type
        /// </summary>
        DebugTypePortability = 33359,
        /// <summary>
        /// The debug type performance debug type
        /// </summary>
        DebugTypePerformance = 33360,
        /// <summary>
        /// The debug type other debug type
        /// </summary>
        DebugTypeOther = 33361,
        /// <summary>
        /// The debug type marker debug type
        /// </summary>
        DebugTypeMarker = 33384,
        /// <summary>
        /// The debug type push group debug type
        /// </summary>
        DebugTypePushGroup = 33385,
        /// <summary>
        /// The debug type pop group debug type
        /// </summary>
        DebugTypePopGroup = 33386
    }

    /// <summary>
    /// The debug severity enum
    /// </summary>
    public enum DebugSeverity
    {
        /// <summary>
        /// The debug severity notification debug severity
        /// </summary>
        DebugSeverityNotification = 33387,
        /// <summary>
        /// The debug severity high debug severity
        /// </summary>
        DebugSeverityHigh = 37190,
        /// <summary>
        /// The debug severity medium debug severity
        /// </summary>
        DebugSeverityMedium = 37191,
        /// <summary>
        /// The debug severity low debug severity
        /// </summary>
        DebugSeverityLow = 37192
    }

    /// <summary>
    /// The buffer usage hint enum
    /// </summary>
    public enum BufferUsageHint
    {
        /// <summary>
        /// The stream draw buffer usage hint
        /// </summary>
        StreamDraw = 35040,
        /// <summary>
        /// The stream read buffer usage hint
        /// </summary>
        StreamRead = 35041,
        /// <summary>
        /// The stream copy buffer usage hint
        /// </summary>
        StreamCopy = 35042,
        /// <summary>
        /// The static draw buffer usage hint
        /// </summary>
        StaticDraw = 35044,
        /// <summary>
        /// The static read buffer usage hint
        /// </summary>
        StaticRead = 35045,
        /// <summary>
        /// The static copy buffer usage hint
        /// </summary>
        StaticCopy = 35046,
        /// <summary>
        /// The dynamic draw buffer usage hint
        /// </summary>
        DynamicDraw = 35048,
        /// <summary>
        /// The dynamic read buffer usage hint
        /// </summary>
        DynamicRead = 35049,
        /// <summary>
        /// The dynamic copy buffer usage hint
        /// </summary>
        DynamicCopy = 35050
    }

    /// <summary>
    /// The vertex attrib pointer type enum
    /// </summary>
    public enum VertexAttribPointerType
    {
        /// <summary>
        /// The byte vertex attrib pointer type
        /// </summary>
        Byte = 5120,
        /// <summary>
        /// The unsigned byte vertex attrib pointer type
        /// </summary>
        UnsignedByte = 5121,
        /// <summary>
        /// The short vertex attrib pointer type
        /// </summary>
        Short = 5122,
        /// <summary>
        /// The unsigned short vertex attrib pointer type
        /// </summary>
        UnsignedShort = 5123,
        /// <summary>
        /// The int vertex attrib pointer type
        /// </summary>
        Int = 5124,
        /// <summary>
        /// The unsigned int vertex attrib pointer type
        /// </summary>
        UnsignedInt = 5125,
        /// <summary>
        /// The float vertex attrib pointer type
        /// </summary>
        Float = 5126,
        /// <summary>
        /// The double vertex attrib pointer type
        /// </summary>
        Double = 5130,
        /// <summary>
        /// The half float vertex attrib pointer type
        /// </summary>
        HalfFloat = 5131,
        /// <summary>
        /// The fixed vertex attrib pointer type
        /// </summary>
        Fixed = 5132,
        /// <summary>
        /// The unsigned int 2101010 rev vertex attrib pointer type
        /// </summary>
        UnsignedInt2101010Rev = 33640,
        /// <summary>
        /// The int 2101010 rev vertex attrib pointer type
        /// </summary>
        Int2101010Rev = 36255
    }

    /// <summary>
    /// The front face direction enum
    /// </summary>
    public enum FrontFaceDirection
    {
        /// <summary>
        /// The cw front face direction
        /// </summary>
        Cw = 2304,
        /// <summary>
        /// The ccw front face direction
        /// </summary>
        Ccw = 2305
    }

    /// <summary>
    /// The get name enum
    /// </summary>
    public enum GetPName
    {
        /// <summary>
        /// The current color get name
        /// </summary>
        CurrentColor = 2816,
        /// <summary>
        /// The current index get name
        /// </summary>
        CurrentIndex = 2817,
        /// <summary>
        /// The current normal get name
        /// </summary>
        CurrentNormal = 2818,
        /// <summary>
        /// The current texture coords get name
        /// </summary>
        CurrentTextureCoords = 2819,
        /// <summary>
        /// The current raster color get name
        /// </summary>
        CurrentRasterColor = 2820,
        /// <summary>
        /// The current raster index get name
        /// </summary>
        CurrentRasterIndex = 2821,
        /// <summary>
        /// The current raster texture coords get name
        /// </summary>
        CurrentRasterTextureCoords = 2822,
        /// <summary>
        /// The current raster position get name
        /// </summary>
        CurrentRasterPosition = 2823,
        /// <summary>
        /// The current raster position valid get name
        /// </summary>
        CurrentRasterPositionValid = 2824,
        /// <summary>
        /// The current raster distance get name
        /// </summary>
        CurrentRasterDistance = 2825,
        /// <summary>
        /// The point smooth get name
        /// </summary>
        PointSmooth = 2832,
        /// <summary>
        /// The point size get name
        /// </summary>
        PointSize = 2833,
        /// <summary>
        /// The point size range get name
        /// </summary>
        PointSizeRange = 2834,
        /// <summary>
        /// The smooth point size range get name
        /// </summary>
        SmoothPointSizeRange = 2834,
        /// <summary>
        /// The point size granularity get name
        /// </summary>
        PointSizeGranularity = 2835,
        /// <summary>
        /// The smooth point size granularity get name
        /// </summary>
        SmoothPointSizeGranularity = 2835,
        /// <summary>
        /// The line smooth get name
        /// </summary>
        LineSmooth = 2848,
        /// <summary>
        /// The line width get name
        /// </summary>
        LineWidth = 2849,
        /// <summary>
        /// The line width range get name
        /// </summary>
        LineWidthRange = 2850,
        /// <summary>
        /// The smooth line width range get name
        /// </summary>
        SmoothLineWidthRange = 2850,
        /// <summary>
        /// The line width granularity get name
        /// </summary>
        LineWidthGranularity = 2851,
        /// <summary>
        /// The smooth line width granularity get name
        /// </summary>
        SmoothLineWidthGranularity = 2851,
        /// <summary>
        /// The line stipple get name
        /// </summary>
        LineStipple = 2852,
        /// <summary>
        /// The line stipple pattern get name
        /// </summary>
        LineStipplePattern = 2853,
        /// <summary>
        /// The line stipple repeat get name
        /// </summary>
        LineStippleRepeat = 2854,
        /// <summary>
        /// The list mode get name
        /// </summary>
        ListMode = 2864,
        /// <summary>
        /// The max list nesting get name
        /// </summary>
        MaxListNesting = 2865,
        /// <summary>
        /// The list base get name
        /// </summary>
        ListBase = 2866,
        /// <summary>
        /// The list index get name
        /// </summary>
        ListIndex = 2867,
        /// <summary>
        /// The polygon mode get name
        /// </summary>
        PolygonMode = 2880,
        /// <summary>
        /// The polygon smooth get name
        /// </summary>
        PolygonSmooth = 2881,
        /// <summary>
        /// The polygon stipple get name
        /// </summary>
        PolygonStipple = 2882,
        /// <summary>
        /// The edge flag get name
        /// </summary>
        EdgeFlag = 2883,
        /// <summary>
        /// The cull face get name
        /// </summary>
        CullFace = 2884,
        /// <summary>
        /// The cull face mode get name
        /// </summary>
        CullFaceMode = 2885,
        /// <summary>
        /// The front face get name
        /// </summary>
        FrontFace = 2886,
        /// <summary>
        /// The lighting get name
        /// </summary>
        Lighting = 2896,
        /// <summary>
        /// The light model local viewer get name
        /// </summary>
        LightModelLocalViewer = 2897,
        /// <summary>
        /// The light model two side get name
        /// </summary>
        LightModelTwoSide = 2898,
        /// <summary>
        /// The light model ambient get name
        /// </summary>
        LightModelAmbient = 2899,
        /// <summary>
        /// The shade model get name
        /// </summary>
        ShadeModel = 2900,
        /// <summary>
        /// The color material face get name
        /// </summary>
        ColorMaterialFace = 2901,
        /// <summary>
        /// The color material parameter get name
        /// </summary>
        ColorMaterialParameter = 2902,
        /// <summary>
        /// The color material get name
        /// </summary>
        ColorMaterial = 2903,
        /// <summary>
        /// The fog get name
        /// </summary>
        Fog = 2912,
        /// <summary>
        /// The fog index get name
        /// </summary>
        FogIndex = 2913,
        /// <summary>
        /// The fog density get name
        /// </summary>
        FogDensity = 2914,
        /// <summary>
        /// The fog start get name
        /// </summary>
        FogStart = 2915,
        /// <summary>
        /// The fog end get name
        /// </summary>
        FogEnd = 2916,
        /// <summary>
        /// The fog mode get name
        /// </summary>
        FogMode = 2917,
        /// <summary>
        /// The fog color get name
        /// </summary>
        FogColor = 2918,
        /// <summary>
        /// The depth range get name
        /// </summary>
        DepthRange = 2928,
        /// <summary>
        /// The depth test get name
        /// </summary>
        DepthTest = 2929,
        /// <summary>
        /// The depth writemask get name
        /// </summary>
        DepthWritemask = 2930,
        /// <summary>
        /// The depth clear value get name
        /// </summary>
        DepthClearValue = 2931,
        /// <summary>
        /// The depth func get name
        /// </summary>
        DepthFunc = 2932,
        /// <summary>
        /// The accum clear value get name
        /// </summary>
        AccumClearValue = 2944,
        /// <summary>
        /// The stencil test get name
        /// </summary>
        StencilTest = 2960,
        /// <summary>
        /// The stencil clear value get name
        /// </summary>
        StencilClearValue = 2961,
        /// <summary>
        /// The stencil func get name
        /// </summary>
        StencilFunc = 2962,
        /// <summary>
        /// The stencil value mask get name
        /// </summary>
        StencilValueMask = 2963,
        /// <summary>
        /// The stencil fail get name
        /// </summary>
        StencilFail = 2964,
        /// <summary>
        /// The stencil pass depth fail get name
        /// </summary>
        StencilPassDepthFail = 2965,
        /// <summary>
        /// The stencil pass depth pass get name
        /// </summary>
        StencilPassDepthPass = 2966,
        /// <summary>
        /// The stencil ref get name
        /// </summary>
        StencilRef = 2967,
        /// <summary>
        /// The stencil writemask get name
        /// </summary>
        StencilWritemask = 2968,
        /// <summary>
        /// The matrix mode get name
        /// </summary>
        MatrixMode = 2976,
        /// <summary>
        /// The normalize get name
        /// </summary>
        Normalize = 2977,
        /// <summary>
        /// The viewport get name
        /// </summary>
        Viewport = 2978,
        /// <summary>
        /// The modelview stack depth ext get name
        /// </summary>
        Modelview0StackDepthExt = 2979,
        /// <summary>
        /// The modelview stack depth get name
        /// </summary>
        ModelviewStackDepth = 2979,
        /// <summary>
        /// The projection stack depth get name
        /// </summary>
        ProjectionStackDepth = 2980,
        /// <summary>
        /// The texture stack depth get name
        /// </summary>
        TextureStackDepth = 2981,
        /// <summary>
        /// The modelview matrix ext get name
        /// </summary>
        Modelview0MatrixExt = 2982,
        /// <summary>
        /// The modelview matrix get name
        /// </summary>
        ModelviewMatrix = 2982,
        /// <summary>
        /// The projection matrix get name
        /// </summary>
        ProjectionMatrix = 2983,
        /// <summary>
        /// The texture matrix get name
        /// </summary>
        TextureMatrix = 2984,
        /// <summary>
        /// The attrib stack depth get name
        /// </summary>
        AttribStackDepth = 2992,
        /// <summary>
        /// The client attrib stack depth get name
        /// </summary>
        ClientAttribStackDepth = 2993,
        /// <summary>
        /// The alpha test get name
        /// </summary>
        AlphaTest = 3008,
        /// <summary>
        /// The alpha test qcom get name
        /// </summary>
        AlphaTestQcom = 3008,
        /// <summary>
        /// The alpha test func get name
        /// </summary>
        AlphaTestFunc = 3009,
        /// <summary>
        /// The alpha test func qcom get name
        /// </summary>
        AlphaTestFuncQcom = 3009,
        /// <summary>
        /// The alpha test ref get name
        /// </summary>
        AlphaTestRef = 3010,
        /// <summary>
        /// The alpha test ref qcom get name
        /// </summary>
        AlphaTestRefQcom = 3010,
        /// <summary>
        /// The dither get name
        /// </summary>
        Dither = 3024,
        /// <summary>
        /// The blend dst get name
        /// </summary>
        BlendDst = 3040,
        /// <summary>
        /// The blend src get name
        /// </summary>
        BlendSrc = 3041,
        /// <summary>
        /// The blend get name
        /// </summary>
        Blend = 3042,
        /// <summary>
        /// The logic op mode get name
        /// </summary>
        LogicOpMode = 3056,
        /// <summary>
        /// The index logic op get name
        /// </summary>
        IndexLogicOp = 3057,
        /// <summary>
        /// The logic op get name
        /// </summary>
        LogicOp = 3057,
        /// <summary>
        /// The color logic op get name
        /// </summary>
        ColorLogicOp = 3058,
        /// <summary>
        /// The aux buffers get name
        /// </summary>
        AuxBuffers = 3072,
        /// <summary>
        /// The draw buffer get name
        /// </summary>
        DrawBuffer = 3073,
        /// <summary>
        /// The draw buffer ext get name
        /// </summary>
        DrawBufferExt = 3073,
        /// <summary>
        /// The read buffer get name
        /// </summary>
        ReadBuffer = 3074,
        /// <summary>
        /// The read buffer ext get name
        /// </summary>
        ReadBufferExt = 3074,
        /// <summary>
        /// The read buffer nv get name
        /// </summary>
        ReadBufferNv = 3074,
        /// <summary>
        /// The scissor box get name
        /// </summary>
        ScissorBox = 3088,
        /// <summary>
        /// The scissor test get name
        /// </summary>
        ScissorTest = 3089,
        /// <summary>
        /// The index clear value get name
        /// </summary>
        IndexClearValue = 3104,
        /// <summary>
        /// The index writemask get name
        /// </summary>
        IndexWritemask = 3105,
        /// <summary>
        /// The color clear value get name
        /// </summary>
        ColorClearValue = 3106,
        /// <summary>
        /// The color writemask get name
        /// </summary>
        ColorWritemask = 3107,
        /// <summary>
        /// The index mode get name
        /// </summary>
        IndexMode = 3120,
        /// <summary>
        /// The rgba mode get name
        /// </summary>
        RgbaMode = 3121,
        /// <summary>
        /// The doublebuffer get name
        /// </summary>
        Doublebuffer = 3122,
        /// <summary>
        /// The stereo get name
        /// </summary>
        Stereo = 3123,
        /// <summary>
        /// The render mode get name
        /// </summary>
        RenderMode = 3136,
        /// <summary>
        /// The perspective correction hint get name
        /// </summary>
        PerspectiveCorrectionHint = 3152,
        /// <summary>
        /// The point smooth hint get name
        /// </summary>
        PointSmoothHint = 3153,
        /// <summary>
        /// The line smooth hint get name
        /// </summary>
        LineSmoothHint = 3154,
        /// <summary>
        /// The polygon smooth hint get name
        /// </summary>
        PolygonSmoothHint = 3155,
        /// <summary>
        /// The fog hint get name
        /// </summary>
        FogHint = 3156,
        /// <summary>
        /// The texture gen get name
        /// </summary>
        TextureGenS = 3168,
        /// <summary>
        /// The texture gen get name
        /// </summary>
        TextureGenT = 3169,
        /// <summary>
        /// The texture gen get name
        /// </summary>
        TextureGenR = 3170,
        /// <summary>
        /// The texture gen get name
        /// </summary>
        TextureGenQ = 3171,
        /// <summary>
        /// The pixel map to size get name
        /// </summary>
        PixelMapIToISize = 3248,
        /// <summary>
        /// The pixel map to size get name
        /// </summary>
        PixelMapSToSSize = 3249,
        /// <summary>
        /// The pixel map to size get name
        /// </summary>
        PixelMapIToRSize = 3250,
        /// <summary>
        /// The pixel map to size get name
        /// </summary>
        PixelMapIToGSize = 3251,
        /// <summary>
        /// The pixel map to size get name
        /// </summary>
        PixelMapIToBSize = 3252,
        /// <summary>
        /// The pixel map to size get name
        /// </summary>
        PixelMapIToASize = 3253,
        /// <summary>
        /// The pixel map to size get name
        /// </summary>
        PixelMapRToRSize = 3254,
        /// <summary>
        /// The pixel map to size get name
        /// </summary>
        PixelMapGToGSize = 3255,
        /// <summary>
        /// The pixel map to size get name
        /// </summary>
        PixelMapBToBSize = 3256,
        /// <summary>
        /// The pixel map to size get name
        /// </summary>
        PixelMapAToASize = 3257,
        /// <summary>
        /// The unpack swap bytes get name
        /// </summary>
        UnpackSwapBytes = 3312,
        /// <summary>
        /// The unpack lsb first get name
        /// </summary>
        UnpackLsbFirst = 3313,
        /// <summary>
        /// The unpack row length get name
        /// </summary>
        UnpackRowLength = 3314,
        /// <summary>
        /// The unpack skip rows get name
        /// </summary>
        UnpackSkipRows = 3315,
        /// <summary>
        /// The unpack skip pixels get name
        /// </summary>
        UnpackSkipPixels = 3316,
        /// <summary>
        /// The unpack alignment get name
        /// </summary>
        UnpackAlignment = 3317,
        /// <summary>
        /// The pack swap bytes get name
        /// </summary>
        PackSwapBytes = 3328,
        /// <summary>
        /// The pack lsb first get name
        /// </summary>
        PackLsbFirst = 3329,
        /// <summary>
        /// The pack row length get name
        /// </summary>
        PackRowLength = 3330,
        /// <summary>
        /// The pack skip rows get name
        /// </summary>
        PackSkipRows = 3331,
        /// <summary>
        /// The pack skip pixels get name
        /// </summary>
        PackSkipPixels = 3332,
        /// <summary>
        /// The pack alignment get name
        /// </summary>
        PackAlignment = 3333,
        /// <summary>
        /// The map color get name
        /// </summary>
        MapColor = 3344,
        /// <summary>
        /// The map stencil get name
        /// </summary>
        MapStencil = 3345,
        /// <summary>
        /// The index shift get name
        /// </summary>
        IndexShift = 3346,
        /// <summary>
        /// The index offset get name
        /// </summary>
        IndexOffset = 3347,
        /// <summary>
        /// The red scale get name
        /// </summary>
        RedScale = 3348,
        /// <summary>
        /// The red bias get name
        /// </summary>
        RedBias = 3349,
        /// <summary>
        /// The zoom get name
        /// </summary>
        ZoomX = 3350,
        /// <summary>
        /// The zoom get name
        /// </summary>
        ZoomY = 3351,
        /// <summary>
        /// The green scale get name
        /// </summary>
        GreenScale = 3352,
        /// <summary>
        /// The green bias get name
        /// </summary>
        GreenBias = 3353,
        /// <summary>
        /// The blue scale get name
        /// </summary>
        BlueScale = 3354,
        /// <summary>
        /// The blue bias get name
        /// </summary>
        BlueBias = 3355,
        /// <summary>
        /// The alpha scale get name
        /// </summary>
        AlphaScale = 3356,
        /// <summary>
        /// The alpha bias get name
        /// </summary>
        AlphaBias = 3357,
        /// <summary>
        /// The depth scale get name
        /// </summary>
        DepthScale = 3358,
        /// <summary>
        /// The depth bias get name
        /// </summary>
        DepthBias = 3359,
        /// <summary>
        /// The max eval order get name
        /// </summary>
        MaxEvalOrder = 3376,
        /// <summary>
        /// The max lights get name
        /// </summary>
        MaxLights = 3377,
        /// <summary>
        /// The max clip distances get name
        /// </summary>
        MaxClipDistances = 3378,
        /// <summary>
        /// The max clip planes get name
        /// </summary>
        MaxClipPlanes = 3378,
        /// <summary>
        /// The max texture size get name
        /// </summary>
        MaxTextureSize = 3379,
        /// <summary>
        /// The max pixel map table get name
        /// </summary>
        MaxPixelMapTable = 3380,
        /// <summary>
        /// The max attrib stack depth get name
        /// </summary>
        MaxAttribStackDepth = 3381,
        /// <summary>
        /// The max modelview stack depth get name
        /// </summary>
        MaxModelviewStackDepth = 3382,
        /// <summary>
        /// The max name stack depth get name
        /// </summary>
        MaxNameStackDepth = 3383,
        /// <summary>
        /// The max projection stack depth get name
        /// </summary>
        MaxProjectionStackDepth = 3384,
        /// <summary>
        /// The max texture stack depth get name
        /// </summary>
        MaxTextureStackDepth = 3385,
        /// <summary>
        /// The max viewport dims get name
        /// </summary>
        MaxViewportDims = 3386,
        /// <summary>
        /// The max client attrib stack depth get name
        /// </summary>
        MaxClientAttribStackDepth = 3387,
        /// <summary>
        /// The subpixel bits get name
        /// </summary>
        SubpixelBits = 3408,
        /// <summary>
        /// The index bits get name
        /// </summary>
        IndexBits = 3409,
        /// <summary>
        /// The red bits get name
        /// </summary>
        RedBits = 3410,
        /// <summary>
        /// The green bits get name
        /// </summary>
        GreenBits = 3411,
        /// <summary>
        /// The blue bits get name
        /// </summary>
        BlueBits = 3412,
        /// <summary>
        /// The alpha bits get name
        /// </summary>
        AlphaBits = 3413,
        /// <summary>
        /// The depth bits get name
        /// </summary>
        DepthBits = 3414,
        /// <summary>
        /// The stencil bits get name
        /// </summary>
        StencilBits = 3415,
        /// <summary>
        /// The accum red bits get name
        /// </summary>
        AccumRedBits = 3416,
        /// <summary>
        /// The accum green bits get name
        /// </summary>
        AccumGreenBits = 3417,
        /// <summary>
        /// The accum blue bits get name
        /// </summary>
        AccumBlueBits = 3418,
        /// <summary>
        /// The accum alpha bits get name
        /// </summary>
        AccumAlphaBits = 3419,
        /// <summary>
        /// The name stack depth get name
        /// </summary>
        NameStackDepth = 3440,
        /// <summary>
        /// The auto normal get name
        /// </summary>
        AutoNormal = 3456,
        /// <summary>
        /// The map color get name
        /// </summary>
        Map1Color4 = 3472,
        /// <summary>
        /// The map index get name
        /// </summary>
        Map1Index = 3473,
        /// <summary>
        /// The map normal get name
        /// </summary>
        Map1Normal = 3474,
        /// <summary>
        /// The map texture coord get name
        /// </summary>
        Map1TextureCoord1 = 3475,
        /// <summary>
        /// The map texture coord get name
        /// </summary>
        Map1TextureCoord2 = 3476,
        /// <summary>
        /// The map texture coord get name
        /// </summary>
        Map1TextureCoord3 = 3477,
        /// <summary>
        /// The map texture coord get name
        /// </summary>
        Map1TextureCoord4 = 3478,
        /// <summary>
        /// The map vertex get name
        /// </summary>
        Map1Vertex3 = 3479,
        /// <summary>
        /// The map vertex get name
        /// </summary>
        Map1Vertex4 = 3480,
        /// <summary>
        /// The map color get name
        /// </summary>
        Map2Color4 = 3504,
        /// <summary>
        /// The map index get name
        /// </summary>
        Map2Index = 3505,
        /// <summary>
        /// The map normal get name
        /// </summary>
        Map2Normal = 3506,
        /// <summary>
        /// The map texture coord get name
        /// </summary>
        Map2TextureCoord1 = 3507,
        /// <summary>
        /// The map texture coord get name
        /// </summary>
        Map2TextureCoord2 = 3508,
        /// <summary>
        /// The map texture coord get name
        /// </summary>
        Map2TextureCoord3 = 3509,
        /// <summary>
        /// The map texture coord get name
        /// </summary>
        Map2TextureCoord4 = 3510,
        /// <summary>
        /// The map vertex get name
        /// </summary>
        Map2Vertex3 = 3511,
        /// <summary>
        /// The map vertex get name
        /// </summary>
        Map2Vertex4 = 3512,
        /// <summary>
        /// The map grid domain get name
        /// </summary>
        Map1GridDomain = 3536,
        /// <summary>
        /// The map grid segments get name
        /// </summary>
        Map1GridSegments = 3537,
        /// <summary>
        /// The map grid domain get name
        /// </summary>
        Map2GridDomain = 3538,
        /// <summary>
        /// The map grid segments get name
        /// </summary>
        Map2GridSegments = 3539,
        /// <summary>
        /// The texture get name
        /// </summary>
        Texture1D = 3552,
        /// <summary>
        /// The texture get name
        /// </summary>
        Texture2D = 3553,
        /// <summary>
        /// The feedback buffer size get name
        /// </summary>
        FeedbackBufferSize = 3569,
        /// <summary>
        /// The feedback buffer type get name
        /// </summary>
        FeedbackBufferType = 3570,
        /// <summary>
        /// The selection buffer size get name
        /// </summary>
        SelectionBufferSize = 3572,
        /// <summary>
        /// The polygon offset units get name
        /// </summary>
        PolygonOffsetUnits = 10752,
        /// <summary>
        /// The polygon offset point get name
        /// </summary>
        PolygonOffsetPoint = 10753,
        /// <summary>
        /// The polygon offset line get name
        /// </summary>
        PolygonOffsetLine = 10754,
        /// <summary>
        /// The clip plane get name
        /// </summary>
        ClipPlane0 = 12288,
        /// <summary>
        /// The clip plane get name
        /// </summary>
        ClipPlane1 = 12289,
        /// <summary>
        /// The clip plane get name
        /// </summary>
        ClipPlane2 = 12290,
        /// <summary>
        /// The clip plane get name
        /// </summary>
        ClipPlane3 = 12291,
        /// <summary>
        /// The clip plane get name
        /// </summary>
        ClipPlane4 = 12292,
        /// <summary>
        /// The clip plane get name
        /// </summary>
        ClipPlane5 = 12293,
        /// <summary>
        /// The light get name
        /// </summary>
        Light0 = 16384,
        /// <summary>
        /// The light get name
        /// </summary>
        Light1 = 16385,
        /// <summary>
        /// The light get name
        /// </summary>
        Light2 = 16386,
        /// <summary>
        /// The light get name
        /// </summary>
        Light3 = 16387,
        /// <summary>
        /// The light get name
        /// </summary>
        Light4 = 16388,
        /// <summary>
        /// The light get name
        /// </summary>
        Light5 = 16389,
        /// <summary>
        /// The light get name
        /// </summary>
        Light6 = 16390,
        /// <summary>
        /// The light get name
        /// </summary>
        Light7 = 16391,
        /// <summary>
        /// The blend color ext get name
        /// </summary>
        BlendColorExt = 32773,
        /// <summary>
        /// The blend equation ext get name
        /// </summary>
        BlendEquationExt = 32777,
        /// <summary>
        /// The blend equation rgb get name
        /// </summary>
        BlendEquationRgb = 32777,
        /// <summary>
        /// The pack cmyk hint ext get name
        /// </summary>
        PackCmykHintExt = 32782,
        /// <summary>
        /// The unpack cmyk hint ext get name
        /// </summary>
        UnpackCmykHintExt = 32783,
        /// <summary>
        /// The convolution ext get name
        /// </summary>
        Convolution1DExt = 32784,
        /// <summary>
        /// The convolution ext get name
        /// </summary>
        Convolution2DExt = 32785,
        /// <summary>
        /// The separable ext get name
        /// </summary>
        Separable2DExt = 32786,
        /// <summary>
        /// The post convolution red scale ext get name
        /// </summary>
        PostConvolutionRedScaleExt = 32796,
        /// <summary>
        /// The post convolution green scale ext get name
        /// </summary>
        PostConvolutionGreenScaleExt = 32797,
        /// <summary>
        /// The post convolution blue scale ext get name
        /// </summary>
        PostConvolutionBlueScaleExt = 32798,
        /// <summary>
        /// The post convolution alpha scale ext get name
        /// </summary>
        PostConvolutionAlphaScaleExt = 32799,
        /// <summary>
        /// The post convolution red bias ext get name
        /// </summary>
        PostConvolutionRedBiasExt = 32800,
        /// <summary>
        /// The post convolution green bias ext get name
        /// </summary>
        PostConvolutionGreenBiasExt = 32801,
        /// <summary>
        /// The post convolution blue bias ext get name
        /// </summary>
        PostConvolutionBlueBiasExt = 32802,
        /// <summary>
        /// The post convolution alpha bias ext get name
        /// </summary>
        PostConvolutionAlphaBiasExt = 32803,
        /// <summary>
        /// The histogram ext get name
        /// </summary>
        HistogramExt = 32804,
        /// <summary>
        /// The minmax ext get name
        /// </summary>
        MinmaxExt = 32814,
        /// <summary>
        /// The polygon offset fill get name
        /// </summary>
        PolygonOffsetFill = 32823,
        /// <summary>
        /// The polygon offset factor get name
        /// </summary>
        PolygonOffsetFactor = 32824,
        /// <summary>
        /// The polygon offset bias ext get name
        /// </summary>
        PolygonOffsetBiasExt = 32825,
        /// <summary>
        /// The rescale normal ext get name
        /// </summary>
        RescaleNormalExt = 32826,
        /// <summary>
        /// The texture binding get name
        /// </summary>
        TextureBinding1D = 32872,
        /// <summary>
        /// The texture binding get name
        /// </summary>
        TextureBinding2D = 32873,
        /// <summary>
        /// The texture binding ext get name
        /// </summary>
        Texture3DBindingExt = 32874,
        /// <summary>
        /// The texture binding get name
        /// </summary>
        TextureBinding3D = 32874,
        /// <summary>
        /// The pack skip images ext get name
        /// </summary>
        PackSkipImagesExt = 32875,
        /// <summary>
        /// The pack image height ext get name
        /// </summary>
        PackImageHeightExt = 32876,
        /// <summary>
        /// The unpack skip images ext get name
        /// </summary>
        UnpackSkipImagesExt = 32877,
        /// <summary>
        /// The unpack image height ext get name
        /// </summary>
        UnpackImageHeightExt = 32878,
        /// <summary>
        /// The texture ext get name
        /// </summary>
        Texture3DExt = 32879,
        /// <summary>
        /// The max texture size get name
        /// </summary>
        Max3DTextureSize = 32883,
        /// <summary>
        /// The max texture size ext get name
        /// </summary>
        Max3DTextureSizeExt = 32883,
        /// <summary>
        /// The vertex array get name
        /// </summary>
        VertexArray = 32884,
        /// <summary>
        /// The normal array get name
        /// </summary>
        NormalArray = 32885,
        /// <summary>
        /// The color array get name
        /// </summary>
        ColorArray = 32886,
        /// <summary>
        /// The index array get name
        /// </summary>
        IndexArray = 32887,
        /// <summary>
        /// The texture coord array get name
        /// </summary>
        TextureCoordArray = 32888,
        /// <summary>
        /// The edge flag array get name
        /// </summary>
        EdgeFlagArray = 32889,
        /// <summary>
        /// The vertex array size get name
        /// </summary>
        VertexArraySize = 32890,
        /// <summary>
        /// The vertex array type get name
        /// </summary>
        VertexArrayType = 32891,
        /// <summary>
        /// The vertex array stride get name
        /// </summary>
        VertexArrayStride = 32892,
        /// <summary>
        /// The vertex array count ext get name
        /// </summary>
        VertexArrayCountExt = 32893,
        /// <summary>
        /// The normal array type get name
        /// </summary>
        NormalArrayType = 32894,
        /// <summary>
        /// The normal array stride get name
        /// </summary>
        NormalArrayStride = 32895,
        /// <summary>
        /// The normal array count ext get name
        /// </summary>
        NormalArrayCountExt = 32896,
        /// <summary>
        /// The color array size get name
        /// </summary>
        ColorArraySize = 32897,
        /// <summary>
        /// The color array type get name
        /// </summary>
        ColorArrayType = 32898,
        /// <summary>
        /// The color array stride get name
        /// </summary>
        ColorArrayStride = 32899,
        /// <summary>
        /// The color array count ext get name
        /// </summary>
        ColorArrayCountExt = 32900,
        /// <summary>
        /// The index array type get name
        /// </summary>
        IndexArrayType = 32901,
        /// <summary>
        /// The index array stride get name
        /// </summary>
        IndexArrayStride = 32902,
        /// <summary>
        /// The index array count ext get name
        /// </summary>
        IndexArrayCountExt = 32903,
        /// <summary>
        /// The texture coord array size get name
        /// </summary>
        TextureCoordArraySize = 32904,
        /// <summary>
        /// The texture coord array type get name
        /// </summary>
        TextureCoordArrayType = 32905,
        /// <summary>
        /// The texture coord array stride get name
        /// </summary>
        TextureCoordArrayStride = 32906,
        /// <summary>
        /// The texture coord array count ext get name
        /// </summary>
        TextureCoordArrayCountExt = 32907,
        /// <summary>
        /// The edge flag array stride get name
        /// </summary>
        EdgeFlagArrayStride = 32908,
        /// <summary>
        /// The edge flag array count ext get name
        /// </summary>
        EdgeFlagArrayCountExt = 32909,
        /// <summary>
        /// The interlace sgix get name
        /// </summary>
        InterlaceSgix = 32916,
        /// <summary>
        /// The detail texture binding sgis get name
        /// </summary>
        DetailTexture2DBindingSgis = 32918,
        /// <summary>
        /// The multisample get name
        /// </summary>
        Multisample = 32925,
        /// <summary>
        /// The multisample sgis get name
        /// </summary>
        MultisampleSgis = 32925,
        /// <summary>
        /// The sample alpha to coverage get name
        /// </summary>
        SampleAlphaToCoverage = 32926,
        /// <summary>
        /// The sample alpha to mask sgis get name
        /// </summary>
        SampleAlphaToMaskSgis = 32926,
        /// <summary>
        /// The sample alpha to one get name
        /// </summary>
        SampleAlphaToOne = 32927,
        /// <summary>
        /// The sample alpha to one sgis get name
        /// </summary>
        SampleAlphaToOneSgis = 32927,
        /// <summary>
        /// The sample coverage get name
        /// </summary>
        SampleCoverage = 32928,
        /// <summary>
        /// The sample mask sgis get name
        /// </summary>
        SampleMaskSgis = 32928,
        /// <summary>
        /// The sample buffers get name
        /// </summary>
        SampleBuffers = 32936,
        /// <summary>
        /// The sample buffers sgis get name
        /// </summary>
        SampleBuffersSgis = 32936,
        /// <summary>
        /// The samples get name
        /// </summary>
        Samples = 32937,
        /// <summary>
        /// The samples sgis get name
        /// </summary>
        SamplesSgis = 32937,
        /// <summary>
        /// The sample coverage value get name
        /// </summary>
        SampleCoverageValue = 32938,
        /// <summary>
        /// The sample mask value sgis get name
        /// </summary>
        SampleMaskValueSgis = 32938,
        /// <summary>
        /// The sample coverage invert get name
        /// </summary>
        SampleCoverageInvert = 32939,
        /// <summary>
        /// The sample mask invert sgis get name
        /// </summary>
        SampleMaskInvertSgis = 32939,
        /// <summary>
        /// The sample pattern sgis get name
        /// </summary>
        SamplePatternSgis = 32940,
        /// <summary>
        /// The color matrix sgi get name
        /// </summary>
        ColorMatrixSgi = 32945,
        /// <summary>
        /// The color matrix stack depth sgi get name
        /// </summary>
        ColorMatrixStackDepthSgi = 32946,
        /// <summary>
        /// The max color matrix stack depth sgi get name
        /// </summary>
        MaxColorMatrixStackDepthSgi = 32947,
        /// <summary>
        /// The post color matrix red scale sgi get name
        /// </summary>
        PostColorMatrixRedScaleSgi = 32948,
        /// <summary>
        /// The post color matrix green scale sgi get name
        /// </summary>
        PostColorMatrixGreenScaleSgi = 32949,
        /// <summary>
        /// The post color matrix blue scale sgi get name
        /// </summary>
        PostColorMatrixBlueScaleSgi = 32950,
        /// <summary>
        /// The post color matrix alpha scale sgi get name
        /// </summary>
        PostColorMatrixAlphaScaleSgi = 32951,
        /// <summary>
        /// The post color matrix red bias sgi get name
        /// </summary>
        PostColorMatrixRedBiasSgi = 32952,
        /// <summary>
        /// The post color matrix green bias sgi get name
        /// </summary>
        PostColorMatrixGreenBiasSgi = 32953,
        /// <summary>
        /// The post color matrix blue bias sgi get name
        /// </summary>
        PostColorMatrixBlueBiasSgi = 32954,
        /// <summary>
        /// The post color matrix alpha bias sgi get name
        /// </summary>
        PostColorMatrixAlphaBiasSgi = 32955,
        /// <summary>
        /// The texture color table sgi get name
        /// </summary>
        TextureColorTableSgi = 32956,
        /// <summary>
        /// The blend dst rgb get name
        /// </summary>
        BlendDstRgb = 32968,
        /// <summary>
        /// The blend src rgb get name
        /// </summary>
        BlendSrcRgb = 32969,
        /// <summary>
        /// The blend dst alpha get name
        /// </summary>
        BlendDstAlpha = 32970,
        /// <summary>
        /// The blend src alpha get name
        /// </summary>
        BlendSrcAlpha = 32971,
        /// <summary>
        /// The color table sgi get name
        /// </summary>
        ColorTableSgi = 32976,
        /// <summary>
        /// The post convolution color table sgi get name
        /// </summary>
        PostConvolutionColorTableSgi = 32977,
        /// <summary>
        /// The post color matrix color table sgi get name
        /// </summary>
        PostColorMatrixColorTableSgi = 32978,
        /// <summary>
        /// The max elements vertices get name
        /// </summary>
        MaxElementsVertices = 33000,
        /// <summary>
        /// The max elements indices get name
        /// </summary>
        MaxElementsIndices = 33001,
        /// <summary>
        /// The point size min get name
        /// </summary>
        PointSizeMin = 33062,
        /// <summary>
        /// The point size min sgis get name
        /// </summary>
        PointSizeMinSgis = 33062,
        /// <summary>
        /// The point size max get name
        /// </summary>
        PointSizeMax = 33063,
        /// <summary>
        /// The point size max sgis get name
        /// </summary>
        PointSizeMaxSgis = 33063,
        /// <summary>
        /// The point fade threshold size get name
        /// </summary>
        PointFadeThresholdSize = 33064,
        /// <summary>
        /// The point fade threshold size sgis get name
        /// </summary>
        PointFadeThresholdSizeSgis = 33064,
        /// <summary>
        /// The distance attenuation sgis get name
        /// </summary>
        DistanceAttenuationSgis = 33065,
        /// <summary>
        /// The point distance attenuation get name
        /// </summary>
        PointDistanceAttenuation = 33065,
        /// <summary>
        /// The fog func points sgis get name
        /// </summary>
        FogFuncPointsSgis = 33067,
        /// <summary>
        /// The max fog func points sgis get name
        /// </summary>
        MaxFogFuncPointsSgis = 33068,
        /// <summary>
        /// The pack skip volumes sgis get name
        /// </summary>
        PackSkipVolumesSgis = 33072,
        /// <summary>
        /// The pack image depth sgis get name
        /// </summary>
        PackImageDepthSgis = 33073,
        /// <summary>
        /// The unpack skip volumes sgis get name
        /// </summary>
        UnpackSkipVolumesSgis = 33074,
        /// <summary>
        /// The unpack image depth sgis get name
        /// </summary>
        UnpackImageDepthSgis = 33075,
        /// <summary>
        /// The texture sgis get name
        /// </summary>
        Texture4DSgis = 33076,
        /// <summary>
        /// The max texture size sgis get name
        /// </summary>
        Max4DTextureSizeSgis = 33080,
        /// <summary>
        /// The pixel tex gen sgix get name
        /// </summary>
        PixelTexGenSgix = 33081,
        /// <summary>
        /// The pixel tile best alignment sgix get name
        /// </summary>
        PixelTileBestAlignmentSgix = 33086,
        /// <summary>
        /// The pixel tile cache increment sgix get name
        /// </summary>
        PixelTileCacheIncrementSgix = 33087,
        /// <summary>
        /// The pixel tile width sgix get name
        /// </summary>
        PixelTileWidthSgix = 33088,
        /// <summary>
        /// The pixel tile height sgix get name
        /// </summary>
        PixelTileHeightSgix = 33089,
        /// <summary>
        /// The pixel tile grid width sgix get name
        /// </summary>
        PixelTileGridWidthSgix = 33090,
        /// <summary>
        /// The pixel tile grid height sgix get name
        /// </summary>
        PixelTileGridHeightSgix = 33091,
        /// <summary>
        /// The pixel tile grid depth sgix get name
        /// </summary>
        PixelTileGridDepthSgix = 33092,
        /// <summary>
        /// The pixel tile cache size sgix get name
        /// </summary>
        PixelTileCacheSizeSgix = 33093,
        /// <summary>
        /// The sprite sgix get name
        /// </summary>
        SpriteSgix = 33096,
        /// <summary>
        /// The sprite mode sgix get name
        /// </summary>
        SpriteModeSgix = 33097,
        /// <summary>
        /// The sprite axis sgix get name
        /// </summary>
        SpriteAxisSgix = 33098,
        /// <summary>
        /// The sprite translation sgix get name
        /// </summary>
        SpriteTranslationSgix = 33099,
        /// <summary>
        /// The texture binding sgis get name
        /// </summary>
        Texture4DBindingSgis = 33103,
        /// <summary>
        /// The max clipmap depth sgix get name
        /// </summary>
        MaxClipmapDepthSgix = 33143,
        /// <summary>
        /// The max clipmap virtual depth sgix get name
        /// </summary>
        MaxClipmapVirtualDepthSgix = 33144,
        /// <summary>
        /// The post texture filter bias range sgix get name
        /// </summary>
        PostTextureFilterBiasRangeSgix = 33147,
        /// <summary>
        /// The post texture filter scale range sgix get name
        /// </summary>
        PostTextureFilterScaleRangeSgix = 33148,
        /// <summary>
        /// The reference plane sgix get name
        /// </summary>
        ReferencePlaneSgix = 33149,
        /// <summary>
        /// The reference plane equation sgix get name
        /// </summary>
        ReferencePlaneEquationSgix = 33150,
        /// <summary>
        /// The ir instrument sgix get name
        /// </summary>
        IrInstrument1Sgix = 33151,
        /// <summary>
        /// The instrument measurements sgix get name
        /// </summary>
        InstrumentMeasurementsSgix = 33153,
        /// <summary>
        /// The calligraphic fragment sgix get name
        /// </summary>
        CalligraphicFragmentSgix = 33155,
        /// <summary>
        /// The framezoom sgix get name
        /// </summary>
        FramezoomSgix = 33163,
        /// <summary>
        /// The framezoom factor sgix get name
        /// </summary>
        FramezoomFactorSgix = 33164,
        /// <summary>
        /// The max framezoom factor sgix get name
        /// </summary>
        MaxFramezoomFactorSgix = 33165,
        /// <summary>
        /// The generate mipmap hint get name
        /// </summary>
        GenerateMipmapHint = 33170,
        /// <summary>
        /// The generate mipmap hint sgis get name
        /// </summary>
        GenerateMipmapHintSgis = 33170,
        /// <summary>
        /// The deformations mask sgix get name
        /// </summary>
        DeformationsMaskSgix = 33174,
        /// <summary>
        /// The fog offset sgix get name
        /// </summary>
        FogOffsetSgix = 33176,
        /// <summary>
        /// The fog offset value sgix get name
        /// </summary>
        FogOffsetValueSgix = 33177,
        /// <summary>
        /// The light model color control get name
        /// </summary>
        LightModelColorControl = 33272,
        /// <summary>
        /// The shared texture palette ext get name
        /// </summary>
        SharedTexturePaletteExt = 33275,
        /// <summary>
        /// The major version get name
        /// </summary>
        MajorVersion = 33307,
        /// <summary>
        /// The minor version get name
        /// </summary>
        MinorVersion = 33308,
        /// <summary>
        /// The num extensions get name
        /// </summary>
        NumExtensions = 33309,
        /// <summary>
        /// The context flags get name
        /// </summary>
        ContextFlags = 33310,
        /// <summary>
        /// The reset notification strategy get name
        /// </summary>
        ResetNotificationStrategy = 33366,
        /// <summary>
        /// The program pipeline binding get name
        /// </summary>
        ProgramPipelineBinding = 33370,
        /// <summary>
        /// The max viewports get name
        /// </summary>
        MaxViewports = 33371,
        /// <summary>
        /// The viewport subpixel bits get name
        /// </summary>
        ViewportSubpixelBits = 33372,
        /// <summary>
        /// The viewport bounds range get name
        /// </summary>
        ViewportBoundsRange = 33373,
        /// <summary>
        /// The layer provoking vertex get name
        /// </summary>
        LayerProvokingVertex = 33374,
        /// <summary>
        /// The viewport index provoking vertex get name
        /// </summary>
        ViewportIndexProvokingVertex = 33375,
        /// <summary>
        /// The max label length get name
        /// </summary>
        MaxLabelLength = 33512,
        /// <summary>
        /// The max cull distances get name
        /// </summary>
        MaxCullDistances = 33529,
        /// <summary>
        /// The max combined clip and cull distances get name
        /// </summary>
        MaxCombinedClipAndCullDistances = 33530,
        /// <summary>
        /// The context release behavior get name
        /// </summary>
        ContextReleaseBehavior = 33531,
        /// <summary>
        /// The convolution hint sgix get name
        /// </summary>
        ConvolutionHintSgix = 33558,
        /// <summary>
        /// The async marker sgix get name
        /// </summary>
        AsyncMarkerSgix = 33577,
        /// <summary>
        /// The pixel tex gen mode sgix get name
        /// </summary>
        PixelTexGenModeSgix = 33579,
        /// <summary>
        /// The async histogram sgix get name
        /// </summary>
        AsyncHistogramSgix = 33580,
        /// <summary>
        /// The max async histogram sgix get name
        /// </summary>
        MaxAsyncHistogramSgix = 33581,
        /// <summary>
        /// The pixel texture sgis get name
        /// </summary>
        PixelTextureSgis = 33619,
        /// <summary>
        /// The async tex image sgix get name
        /// </summary>
        AsyncTexImageSgix = 33628,
        /// <summary>
        /// The async draw pixels sgix get name
        /// </summary>
        AsyncDrawPixelsSgix = 33629,
        /// <summary>
        /// The async read pixels sgix get name
        /// </summary>
        AsyncReadPixelsSgix = 33630,
        /// <summary>
        /// The max async tex image sgix get name
        /// </summary>
        MaxAsyncTexImageSgix = 33631,
        /// <summary>
        /// The max async draw pixels sgix get name
        /// </summary>
        MaxAsyncDrawPixelsSgix = 33632,
        /// <summary>
        /// The max async read pixels sgix get name
        /// </summary>
        MaxAsyncReadPixelsSgix = 33633,
        /// <summary>
        /// The vertex preclip sgix get name
        /// </summary>
        VertexPreclipSgix = 33774,
        /// <summary>
        /// The vertex preclip hint sgix get name
        /// </summary>
        VertexPreclipHintSgix = 33775,
        /// <summary>
        /// The fragment lighting sgix get name
        /// </summary>
        FragmentLightingSgix = 33792,
        /// <summary>
        /// The fragment color material sgix get name
        /// </summary>
        FragmentColorMaterialSgix = 33793,
        /// <summary>
        /// The fragment color material face sgix get name
        /// </summary>
        FragmentColorMaterialFaceSgix = 33794,
        /// <summary>
        /// The fragment color material parameter sgix get name
        /// </summary>
        FragmentColorMaterialParameterSgix = 33795,
        /// <summary>
        /// The max fragment lights sgix get name
        /// </summary>
        MaxFragmentLightsSgix = 33796,
        /// <summary>
        /// The max active lights sgix get name
        /// </summary>
        MaxActiveLightsSgix = 33797,
        /// <summary>
        /// The light env mode sgix get name
        /// </summary>
        LightEnvModeSgix = 33799,
        /// <summary>
        /// The fragment light model local viewer sgix get name
        /// </summary>
        FragmentLightModelLocalViewerSgix = 33800,
        /// <summary>
        /// The fragment light model two side sgix get name
        /// </summary>
        FragmentLightModelTwoSideSgix = 33801,
        /// <summary>
        /// The fragment light model ambient sgix get name
        /// </summary>
        FragmentLightModelAmbientSgix = 33802,
        /// <summary>
        /// The fragment light model normal interpolation sgix get name
        /// </summary>
        FragmentLightModelNormalInterpolationSgix = 33803,
        /// <summary>
        /// The fragment light sgix get name
        /// </summary>
        FragmentLight0Sgix = 33804,
        /// <summary>
        /// The pack resample sgix get name
        /// </summary>
        PackResampleSgix = 33836,
        /// <summary>
        /// The unpack resample sgix get name
        /// </summary>
        UnpackResampleSgix = 33837,
        /// <summary>
        /// The current fog coord get name
        /// </summary>
        CurrentFogCoord = 33875,
        /// <summary>
        /// The fog coord array type get name
        /// </summary>
        FogCoordArrayType = 33876,
        /// <summary>
        /// The fog coord array stride get name
        /// </summary>
        FogCoordArrayStride = 33877,
        /// <summary>
        /// The color sum get name
        /// </summary>
        ColorSum = 33880,
        /// <summary>
        /// The current secondary color get name
        /// </summary>
        CurrentSecondaryColor = 33881,
        /// <summary>
        /// The secondary color array size get name
        /// </summary>
        SecondaryColorArraySize = 33882,
        /// <summary>
        /// The secondary color array type get name
        /// </summary>
        SecondaryColorArrayType = 33883,
        /// <summary>
        /// The secondary color array stride get name
        /// </summary>
        SecondaryColorArrayStride = 33884,
        /// <summary>
        /// The current raster secondary color get name
        /// </summary>
        CurrentRasterSecondaryColor = 33887,
        /// <summary>
        /// The aliased point size range get name
        /// </summary>
        AliasedPointSizeRange = 33901,
        /// <summary>
        /// The aliased line width range get name
        /// </summary>
        AliasedLineWidthRange = 33902,
        /// <summary>
        /// The active texture get name
        /// </summary>
        ActiveTexture = 34016,
        /// <summary>
        /// The client active texture get name
        /// </summary>
        ClientActiveTexture = 34017,
        /// <summary>
        /// The max texture units get name
        /// </summary>
        MaxTextureUnits = 34018,
        /// <summary>
        /// The transpose modelview matrix get name
        /// </summary>
        TransposeModelviewMatrix = 34019,
        /// <summary>
        /// The transpose projection matrix get name
        /// </summary>
        TransposeProjectionMatrix = 34020,
        /// <summary>
        /// The transpose texture matrix get name
        /// </summary>
        TransposeTextureMatrix = 34021,
        /// <summary>
        /// The transpose color matrix get name
        /// </summary>
        TransposeColorMatrix = 34022,
        /// <summary>
        /// The max renderbuffer size get name
        /// </summary>
        MaxRenderbufferSize = 34024,
        /// <summary>
        /// The max renderbuffer size ext get name
        /// </summary>
        MaxRenderbufferSizeExt = 34024,
        /// <summary>
        /// The texture compression hint get name
        /// </summary>
        TextureCompressionHint = 34031,
        /// <summary>
        /// The texture binding rectangle get name
        /// </summary>
        TextureBindingRectangle = 34038,
        /// <summary>
        /// The max rectangle texture size get name
        /// </summary>
        MaxRectangleTextureSize = 34040,
        /// <summary>
        /// The max texture lod bias get name
        /// </summary>
        MaxTextureLodBias = 34045,
        /// <summary>
        /// The texture cube map get name
        /// </summary>
        TextureCubeMap = 34067,
        /// <summary>
        /// The texture binding cube map get name
        /// </summary>
        TextureBindingCubeMap = 34068,
        /// <summary>
        /// The max cube map texture size get name
        /// </summary>
        MaxCubeMapTextureSize = 34076,
        /// <summary>
        /// The pack subsample rate sgix get name
        /// </summary>
        PackSubsampleRateSgix = 34208,
        /// <summary>
        /// The unpack subsample rate sgix get name
        /// </summary>
        UnpackSubsampleRateSgix = 34209,
        /// <summary>
        /// The vertex array binding get name
        /// </summary>
        VertexArrayBinding = 34229,
        /// <summary>
        /// The program point size get name
        /// </summary>
        ProgramPointSize = 34370,
        /// <summary>
        /// The depth clamp get name
        /// </summary>
        DepthClamp = 34383,
        /// <summary>
        /// The num compressed texture formats get name
        /// </summary>
        NumCompressedTextureFormats = 34466,
        /// <summary>
        /// The compressed texture formats get name
        /// </summary>
        CompressedTextureFormats = 34467,
        /// <summary>
        /// The num program binary formats get name
        /// </summary>
        NumProgramBinaryFormats = 34814,
        /// <summary>
        /// The program binary formats get name
        /// </summary>
        ProgramBinaryFormats = 34815,
        /// <summary>
        /// The stencil back func get name
        /// </summary>
        StencilBackFunc = 34816,
        /// <summary>
        /// The stencil back fail get name
        /// </summary>
        StencilBackFail = 34817,
        /// <summary>
        /// The stencil back pass depth fail get name
        /// </summary>
        StencilBackPassDepthFail = 34818,
        /// <summary>
        /// The stencil back pass depth pass get name
        /// </summary>
        StencilBackPassDepthPass = 34819,
        /// <summary>
        /// The rgba float mode get name
        /// </summary>
        RgbaFloatMode = 34848,
        /// <summary>
        /// The max draw buffers get name
        /// </summary>
        MaxDrawBuffers = 34852,
        /// <summary>
        /// The draw buffer get name
        /// </summary>
        DrawBuffer0 = 34853,
        /// <summary>
        /// The draw buffer get name
        /// </summary>
        DrawBuffer1 = 34854,
        /// <summary>
        /// The draw buffer get name
        /// </summary>
        DrawBuffer2 = 34855,
        /// <summary>
        /// The draw buffer get name
        /// </summary>
        DrawBuffer3 = 34856,
        /// <summary>
        /// The draw buffer get name
        /// </summary>
        DrawBuffer4 = 34857,
        /// <summary>
        /// The draw buffer get name
        /// </summary>
        DrawBuffer5 = 34858,
        /// <summary>
        /// The draw buffer get name
        /// </summary>
        DrawBuffer6 = 34859,
        /// <summary>
        /// The draw buffer get name
        /// </summary>
        DrawBuffer7 = 34860,
        /// <summary>
        /// The draw buffer get name
        /// </summary>
        DrawBuffer8 = 34861,
        /// <summary>
        /// The draw buffer get name
        /// </summary>
        DrawBuffer9 = 34862,
        /// <summary>
        /// The draw buffer 10 get name
        /// </summary>
        DrawBuffer10 = 34863,
        /// <summary>
        /// The draw buffer 11 get name
        /// </summary>
        DrawBuffer11 = 34864,
        /// <summary>
        /// The draw buffer 12 get name
        /// </summary>
        DrawBuffer12 = 34865,
        /// <summary>
        /// The draw buffer 13 get name
        /// </summary>
        DrawBuffer13 = 34866,
        /// <summary>
        /// The draw buffer 14 get name
        /// </summary>
        DrawBuffer14 = 34867,
        /// <summary>
        /// The draw buffer 15 get name
        /// </summary>
        DrawBuffer15 = 34868,
        /// <summary>
        /// The blend equation alpha get name
        /// </summary>
        BlendEquationAlpha = 34877,
        /// <summary>
        /// The texture cube map seamless get name
        /// </summary>
        TextureCubeMapSeamless = 34895,
        /// <summary>
        /// The point sprite get name
        /// </summary>
        PointSprite = 34913,
        /// <summary>
        /// The max vertex attribs get name
        /// </summary>
        MaxVertexAttribs = 34921,
        /// <summary>
        /// The max tess control input components get name
        /// </summary>
        MaxTessControlInputComponents = 34924,
        /// <summary>
        /// The max tess evaluation input components get name
        /// </summary>
        MaxTessEvaluationInputComponents = 34925,
        /// <summary>
        /// The max texture coords get name
        /// </summary>
        MaxTextureCoords = 34929,
        /// <summary>
        /// The max texture image units get name
        /// </summary>
        MaxTextureImageUnits = 34930,
        /// <summary>
        /// The array buffer binding get name
        /// </summary>
        ArrayBufferBinding = 34964,
        /// <summary>
        /// The element array buffer binding get name
        /// </summary>
        ElementArrayBufferBinding = 34965,
        /// <summary>
        /// The vertex array buffer binding get name
        /// </summary>
        VertexArrayBufferBinding = 34966,
        /// <summary>
        /// The normal array buffer binding get name
        /// </summary>
        NormalArrayBufferBinding = 34967,
        /// <summary>
        /// The color array buffer binding get name
        /// </summary>
        ColorArrayBufferBinding = 34968,
        /// <summary>
        /// The index array buffer binding get name
        /// </summary>
        IndexArrayBufferBinding = 34969,
        /// <summary>
        /// The texture coord array buffer binding get name
        /// </summary>
        TextureCoordArrayBufferBinding = 34970,
        /// <summary>
        /// The edge flag array buffer binding get name
        /// </summary>
        EdgeFlagArrayBufferBinding = 34971,
        /// <summary>
        /// The secondary color array buffer binding get name
        /// </summary>
        SecondaryColorArrayBufferBinding = 34972,
        /// <summary>
        /// The fog coord array buffer binding get name
        /// </summary>
        FogCoordArrayBufferBinding = 34973,
        /// <summary>
        /// The weight array buffer binding get name
        /// </summary>
        WeightArrayBufferBinding = 34974,
        /// <summary>
        /// The vertex attrib array buffer binding get name
        /// </summary>
        VertexAttribArrayBufferBinding = 34975,
        /// <summary>
        /// The pixel pack buffer binding get name
        /// </summary>
        PixelPackBufferBinding = 35053,
        /// <summary>
        /// The pixel unpack buffer binding get name
        /// </summary>
        PixelUnpackBufferBinding = 35055,
        /// <summary>
        /// The max dual source draw buffers get name
        /// </summary>
        MaxDualSourceDrawBuffers = 35068,
        /// <summary>
        /// The max array texture layers get name
        /// </summary>
        MaxArrayTextureLayers = 35071,
        /// <summary>
        /// The min program texel offset get name
        /// </summary>
        MinProgramTexelOffset = 35076,
        /// <summary>
        /// The max program texel offset get name
        /// </summary>
        MaxProgramTexelOffset = 35077,
        /// <summary>
        /// The sampler binding get name
        /// </summary>
        SamplerBinding = 35097,
        /// <summary>
        /// The clamp vertex color get name
        /// </summary>
        ClampVertexColor = 35098,
        /// <summary>
        /// The clamp fragment color get name
        /// </summary>
        ClampFragmentColor = 35099,
        /// <summary>
        /// The clamp read color get name
        /// </summary>
        ClampReadColor = 35100,
        /// <summary>
        /// The max vertex uniform blocks get name
        /// </summary>
        MaxVertexUniformBlocks = 35371,
        /// <summary>
        /// The max geometry uniform blocks get name
        /// </summary>
        MaxGeometryUniformBlocks = 35372,
        /// <summary>
        /// The max fragment uniform blocks get name
        /// </summary>
        MaxFragmentUniformBlocks = 35373,
        /// <summary>
        /// The max combined uniform blocks get name
        /// </summary>
        MaxCombinedUniformBlocks = 35374,
        /// <summary>
        /// The max uniform buffer bindings get name
        /// </summary>
        MaxUniformBufferBindings = 35375,
        /// <summary>
        /// The max uniform block size get name
        /// </summary>
        MaxUniformBlockSize = 35376,
        /// <summary>
        /// The max combined vertex uniform components get name
        /// </summary>
        MaxCombinedVertexUniformComponents = 35377,
        /// <summary>
        /// The max combined geometry uniform components get name
        /// </summary>
        MaxCombinedGeometryUniformComponents = 35378,
        /// <summary>
        /// The max combined fragment uniform components get name
        /// </summary>
        MaxCombinedFragmentUniformComponents = 35379,
        /// <summary>
        /// The uniform buffer offset alignment get name
        /// </summary>
        UniformBufferOffsetAlignment = 35380,
        /// <summary>
        /// The max fragment uniform components get name
        /// </summary>
        MaxFragmentUniformComponents = 35657,
        /// <summary>
        /// The max vertex uniform components get name
        /// </summary>
        MaxVertexUniformComponents = 35658,
        /// <summary>
        /// The max varying components get name
        /// </summary>
        MaxVaryingComponents = 35659,
        /// <summary>
        /// The max varying floats get name
        /// </summary>
        MaxVaryingFloats = 35659,
        /// <summary>
        /// The max vertex texture image units get name
        /// </summary>
        MaxVertexTextureImageUnits = 35660,
        /// <summary>
        /// The max combined texture image units get name
        /// </summary>
        MaxCombinedTextureImageUnits = 35661,
        /// <summary>
        /// The fragment shader derivative hint get name
        /// </summary>
        FragmentShaderDerivativeHint = 35723,
        /// <summary>
        /// The current program get name
        /// </summary>
        CurrentProgram = 35725,
        /// <summary>
        /// The implementation color read type get name
        /// </summary>
        ImplementationColorReadType = 35738,
        /// <summary>
        /// The implementation color read format get name
        /// </summary>
        ImplementationColorReadFormat = 35739,
        /// <summary>
        /// The texture binding array get name
        /// </summary>
        TextureBinding1DArray = 35868,
        /// <summary>
        /// The texture binding array get name
        /// </summary>
        TextureBinding2DArray = 35869,
        /// <summary>
        /// The max geometry texture image units get name
        /// </summary>
        MaxGeometryTextureImageUnits = 35881,
        /// <summary>
        /// The texture buffer get name
        /// </summary>
        TextureBuffer = 35882,
        /// <summary>
        /// The max texture buffer size get name
        /// </summary>
        MaxTextureBufferSize = 35883,
        /// <summary>
        /// The texture binding buffer get name
        /// </summary>
        TextureBindingBuffer = 35884,
        /// <summary>
        /// The texture buffer data store binding get name
        /// </summary>
        TextureBufferDataStoreBinding = 35885,
        /// <summary>
        /// The sample shading get name
        /// </summary>
        SampleShading = 35894,
        /// <summary>
        /// The min sample shading value get name
        /// </summary>
        MinSampleShadingValue = 35895,
        /// <summary>
        /// The max transform feedback separate components get name
        /// </summary>
        MaxTransformFeedbackSeparateComponents = 35968,
        /// <summary>
        /// The max transform feedback interleaved components get name
        /// </summary>
        MaxTransformFeedbackInterleavedComponents = 35978,
        /// <summary>
        /// The max transform feedback separate attribs get name
        /// </summary>
        MaxTransformFeedbackSeparateAttribs = 35979,
        /// <summary>
        /// The stencil back ref get name
        /// </summary>
        StencilBackRef = 36003,
        /// <summary>
        /// The stencil back value mask get name
        /// </summary>
        StencilBackValueMask = 36004,
        /// <summary>
        /// The stencil back writemask get name
        /// </summary>
        StencilBackWritemask = 36005,
        /// <summary>
        /// The draw framebuffer binding get name
        /// </summary>
        DrawFramebufferBinding = 36006,
        /// <summary>
        /// The framebuffer binding get name
        /// </summary>
        FramebufferBinding = 36006,
        /// <summary>
        /// The framebuffer binding ext get name
        /// </summary>
        FramebufferBindingExt = 36006,
        /// <summary>
        /// The renderbuffer binding get name
        /// </summary>
        RenderbufferBinding = 36007,
        /// <summary>
        /// The renderbuffer binding ext get name
        /// </summary>
        RenderbufferBindingExt = 36007,
        /// <summary>
        /// The read framebuffer binding get name
        /// </summary>
        ReadFramebufferBinding = 36010,
        /// <summary>
        /// The max color attachments get name
        /// </summary>
        MaxColorAttachments = 36063,
        /// <summary>
        /// The max color attachments ext get name
        /// </summary>
        MaxColorAttachmentsExt = 36063,
        /// <summary>
        /// The max samples get name
        /// </summary>
        MaxSamples = 36183,
        /// <summary>
        /// The framebuffer srgb get name
        /// </summary>
        FramebufferSrgb = 36281,
        /// <summary>
        /// The max geometry varying components get name
        /// </summary>
        MaxGeometryVaryingComponents = 36317,
        /// <summary>
        /// The max vertex varying components get name
        /// </summary>
        MaxVertexVaryingComponents = 36318,
        /// <summary>
        /// The max geometry uniform components get name
        /// </summary>
        MaxGeometryUniformComponents = 36319,
        /// <summary>
        /// The max geometry output vertices get name
        /// </summary>
        MaxGeometryOutputVertices = 36320,
        /// <summary>
        /// The max geometry total output components get name
        /// </summary>
        MaxGeometryTotalOutputComponents = 36321,
        /// <summary>
        /// The max subroutines get name
        /// </summary>
        MaxSubroutines = 36327,
        /// <summary>
        /// The max subroutine uniform locations get name
        /// </summary>
        MaxSubroutineUniformLocations = 36328,
        /// <summary>
        /// The shader binary formats get name
        /// </summary>
        ShaderBinaryFormats = 36344,
        /// <summary>
        /// The num shader binary formats get name
        /// </summary>
        NumShaderBinaryFormats = 36345,
        /// <summary>
        /// The shader compiler get name
        /// </summary>
        ShaderCompiler = 36346,
        /// <summary>
        /// The max vertex uniform vectors get name
        /// </summary>
        MaxVertexUniformVectors = 36347,
        /// <summary>
        /// The max varying vectors get name
        /// </summary>
        MaxVaryingVectors = 36348,
        /// <summary>
        /// The max fragment uniform vectors get name
        /// </summary>
        MaxFragmentUniformVectors = 36349,
        /// <summary>
        /// The max combined tess control uniform components get name
        /// </summary>
        MaxCombinedTessControlUniformComponents = 36382,
        /// <summary>
        /// The max combined tess evaluation uniform components get name
        /// </summary>
        MaxCombinedTessEvaluationUniformComponents = 36383,
        /// <summary>
        /// The transform feedback buffer paused get name
        /// </summary>
        TransformFeedbackBufferPaused = 36387,
        /// <summary>
        /// The transform feedback buffer active get name
        /// </summary>
        TransformFeedbackBufferActive = 36388,
        /// <summary>
        /// The transform feedback binding get name
        /// </summary>
        TransformFeedbackBinding = 36389,
        /// <summary>
        /// The timestamp get name
        /// </summary>
        Timestamp = 36392,
        /// <summary>
        /// The quads follow provoking vertex convention get name
        /// </summary>
        QuadsFollowProvokingVertexConvention = 36428,
        /// <summary>
        /// The provoking vertex get name
        /// </summary>
        ProvokingVertex = 36431,
        /// <summary>
        /// The sample mask get name
        /// </summary>
        SampleMask = 36433,
        /// <summary>
        /// The max sample mask words get name
        /// </summary>
        MaxSampleMaskWords = 36441,
        /// <summary>
        /// The max geometry shader invocations get name
        /// </summary>
        MaxGeometryShaderInvocations = 36442,
        /// <summary>
        /// The min fragment interpolation offset get name
        /// </summary>
        MinFragmentInterpolationOffset = 36443,
        /// <summary>
        /// The max fragment interpolation offset get name
        /// </summary>
        MaxFragmentInterpolationOffset = 36444,
        /// <summary>
        /// The fragment interpolation offset bits get name
        /// </summary>
        FragmentInterpolationOffsetBits = 36445,
        /// <summary>
        /// The min program texture gather offset get name
        /// </summary>
        MinProgramTextureGatherOffset = 36446,
        /// <summary>
        /// The max program texture gather offset get name
        /// </summary>
        MaxProgramTextureGatherOffset = 36447,
        /// <summary>
        /// The max transform feedback buffers get name
        /// </summary>
        MaxTransformFeedbackBuffers = 36464,
        /// <summary>
        /// The max vertex streams get name
        /// </summary>
        MaxVertexStreams = 36465,
        /// <summary>
        /// The patch vertices get name
        /// </summary>
        PatchVertices = 36466,
        /// <summary>
        /// The patch default inner level get name
        /// </summary>
        PatchDefaultInnerLevel = 36467,
        /// <summary>
        /// The patch default outer level get name
        /// </summary>
        PatchDefaultOuterLevel = 36468,
        /// <summary>
        /// The max patch vertices get name
        /// </summary>
        MaxPatchVertices = 36477,
        /// <summary>
        /// The max tess gen level get name
        /// </summary>
        MaxTessGenLevel = 36478,
        /// <summary>
        /// The max tess control uniform components get name
        /// </summary>
        MaxTessControlUniformComponents = 36479,
        /// <summary>
        /// The max tess evaluation uniform components get name
        /// </summary>
        MaxTessEvaluationUniformComponents = 36480,
        /// <summary>
        /// The max tess control texture image units get name
        /// </summary>
        MaxTessControlTextureImageUnits = 36481,
        /// <summary>
        /// The max tess evaluation texture image units get name
        /// </summary>
        MaxTessEvaluationTextureImageUnits = 36482,
        /// <summary>
        /// The max tess control output components get name
        /// </summary>
        MaxTessControlOutputComponents = 36483,
        /// <summary>
        /// The max tess patch components get name
        /// </summary>
        MaxTessPatchComponents = 36484,
        /// <summary>
        /// The max tess control total output components get name
        /// </summary>
        MaxTessControlTotalOutputComponents = 36485,
        /// <summary>
        /// The max tess evaluation output components get name
        /// </summary>
        MaxTessEvaluationOutputComponents = 36486,
        /// <summary>
        /// The max tess control uniform blocks get name
        /// </summary>
        MaxTessControlUniformBlocks = 36489,
        /// <summary>
        /// The max tess evaluation uniform blocks get name
        /// </summary>
        MaxTessEvaluationUniformBlocks = 36490,
        /// <summary>
        /// The draw indirect buffer binding get name
        /// </summary>
        DrawIndirectBufferBinding = 36675,
        /// <summary>
        /// The max vertex image uniforms get name
        /// </summary>
        MaxVertexImageUniforms = 37066,
        /// <summary>
        /// The max tess control image uniforms get name
        /// </summary>
        MaxTessControlImageUniforms = 37067,
        /// <summary>
        /// The max tess evaluation image uniforms get name
        /// </summary>
        MaxTessEvaluationImageUniforms = 37068,
        /// <summary>
        /// The max geometry image uniforms get name
        /// </summary>
        MaxGeometryImageUniforms = 37069,
        /// <summary>
        /// The max fragment image uniforms get name
        /// </summary>
        MaxFragmentImageUniforms = 37070,
        /// <summary>
        /// The max combined image uniforms get name
        /// </summary>
        MaxCombinedImageUniforms = 37071,
        /// <summary>
        /// The shader storage buffer offset alignment get name
        /// </summary>
        ShaderStorageBufferOffsetAlignment = 37087,
        /// <summary>
        /// The context robust access get name
        /// </summary>
        ContextRobustAccess = 37107,
        /// <summary>
        /// The texture binding multisample get name
        /// </summary>
        TextureBinding2DMultisample = 37124,
        /// <summary>
        /// The texture binding multisample array get name
        /// </summary>
        TextureBinding2DMultisampleArray = 37125,
        /// <summary>
        /// The max color texture samples get name
        /// </summary>
        MaxColorTextureSamples = 37134,
        /// <summary>
        /// The max depth texture samples get name
        /// </summary>
        MaxDepthTextureSamples = 37135,
        /// <summary>
        /// The max integer samples get name
        /// </summary>
        MaxIntegerSamples = 37136,
        /// <summary>
        /// The max vertex output components get name
        /// </summary>
        MaxVertexOutputComponents = 37154,
        /// <summary>
        /// The max geometry input components get name
        /// </summary>
        MaxGeometryInputComponents = 37155,
        /// <summary>
        /// The max geometry output components get name
        /// </summary>
        MaxGeometryOutputComponents = 37156,
        /// <summary>
        /// The max fragment input components get name
        /// </summary>
        MaxFragmentInputComponents = 37157,
        /// <summary>
        /// The max compute image uniforms get name
        /// </summary>
        MaxComputeImageUniforms = 37309,
        /// <summary>
        /// The clip origin get name
        /// </summary>
        ClipOrigin = 37724,
        /// <summary>
        /// The clip depth mode get name
        /// </summary>
        ClipDepthMode = 37725
    }

    /// <summary>
    /// The texture parameter name enum
    /// </summary>
    public enum TextureParameterName
    {
        /// <summary>
        /// The texture border color texture parameter name
        /// </summary>
        TextureBorderColor = 4100,
        /// <summary>
        /// The texture mag filter texture parameter name
        /// </summary>
        TextureMagFilter = 10240,
        /// <summary>
        /// The texture min filter texture parameter name
        /// </summary>
        TextureMinFilter = 10241,
        /// <summary>
        /// The texture wrap texture parameter name
        /// </summary>
        TextureWrapS = 10242,
        /// <summary>
        /// The texture wrap texture parameter name
        /// </summary>
        TextureWrapT = 10243,
        /// <summary>
        /// The texture priority texture parameter name
        /// </summary>
        TexturePriority = 32870,
        /// <summary>
        /// The texture priority ext texture parameter name
        /// </summary>
        TexturePriorityExt = 32870,
        /// <summary>
        /// The texture depth texture parameter name
        /// </summary>
        TextureDepth = 32881,
        /// <summary>
        /// The texture wrap texture parameter name
        /// </summary>
        TextureWrapR = 32882,
        /// <summary>
        /// The texture wrap ext texture parameter name
        /// </summary>
        TextureWrapRExt = 32882,
        /// <summary>
        /// The texture wrap oes texture parameter name
        /// </summary>
        TextureWrapROes = 32882,
        /// <summary>
        /// The detail texture level sgis texture parameter name
        /// </summary>
        DetailTextureLevelSgis = 32922,
        /// <summary>
        /// The detail texture mode sgis texture parameter name
        /// </summary>
        DetailTextureModeSgis = 32923,
        /// <summary>
        /// The shadow ambient sgix texture parameter name
        /// </summary>
        ShadowAmbientSgix = 32959,
        /// <summary>
        /// The texture compare fail value texture parameter name
        /// </summary>
        TextureCompareFailValue = 32959,
        /// <summary>
        /// The dual texture select sgis texture parameter name
        /// </summary>
        DualTextureSelectSgis = 33060,
        /// <summary>
        /// The quad texture select sgis texture parameter name
        /// </summary>
        QuadTextureSelectSgis = 33061,
        /// <summary>
        /// The clamp to border texture parameter name
        /// </summary>
        ClampToBorder = 33069,
        /// <summary>
        /// The clamp to edge texture parameter name
        /// </summary>
        ClampToEdge = 33071,
        /// <summary>
        /// The texture wrap sgis texture parameter name
        /// </summary>
        TextureWrapQSgis = 33079,
        /// <summary>
        /// The texture min lod texture parameter name
        /// </summary>
        TextureMinLod = 33082,
        /// <summary>
        /// The texture max lod texture parameter name
        /// </summary>
        TextureMaxLod = 33083,
        /// <summary>
        /// The texture base level texture parameter name
        /// </summary>
        TextureBaseLevel = 33084,
        /// <summary>
        /// The texture max level texture parameter name
        /// </summary>
        TextureMaxLevel = 33085,
        /// <summary>
        /// The texture clipmap center sgix texture parameter name
        /// </summary>
        TextureClipmapCenterSgix = 33137,
        /// <summary>
        /// The texture clipmap frame sgix texture parameter name
        /// </summary>
        TextureClipmapFrameSgix = 33138,
        /// <summary>
        /// The texture clipmap offset sgix texture parameter name
        /// </summary>
        TextureClipmapOffsetSgix = 33139,
        /// <summary>
        /// The texture clipmap virtual depth sgix texture parameter name
        /// </summary>
        TextureClipmapVirtualDepthSgix = 33140,
        /// <summary>
        /// The texture clipmap lod offset sgix texture parameter name
        /// </summary>
        TextureClipmapLodOffsetSgix = 33141,
        /// <summary>
        /// The texture clipmap depth sgix texture parameter name
        /// </summary>
        TextureClipmapDepthSgix = 33142,
        /// <summary>
        /// The post texture filter bias sgix texture parameter name
        /// </summary>
        PostTextureFilterBiasSgix = 33145,
        /// <summary>
        /// The post texture filter scale sgix texture parameter name
        /// </summary>
        PostTextureFilterScaleSgix = 33146,
        /// <summary>
        /// The texture lod bias sgix texture parameter name
        /// </summary>
        TextureLodBiasSSgix = 33166,
        /// <summary>
        /// The texture lod bias sgix texture parameter name
        /// </summary>
        TextureLodBiasTSgix = 33167,
        /// <summary>
        /// The texture lod bias sgix texture parameter name
        /// </summary>
        TextureLodBiasRSgix = 33168,
        /// <summary>
        /// The generate mipmap texture parameter name
        /// </summary>
        GenerateMipmap = 33169,
        /// <summary>
        /// The generate mipmap sgis texture parameter name
        /// </summary>
        GenerateMipmapSgis = 33169,
        /// <summary>
        /// The texture compare sgix texture parameter name
        /// </summary>
        TextureCompareSgix = 33178,
        /// <summary>
        /// The texture max clamp sgix texture parameter name
        /// </summary>
        TextureMaxClampSSgix = 33641,
        /// <summary>
        /// The texture max clamp sgix texture parameter name
        /// </summary>
        TextureMaxClampTSgix = 33642,
        /// <summary>
        /// The texture max clamp sgix texture parameter name
        /// </summary>
        TextureMaxClampRSgix = 33643,
        /// <summary>
        /// The texture lod bias texture parameter name
        /// </summary>
        TextureLodBias = 34049,
        /// <summary>
        /// The depth texture mode texture parameter name
        /// </summary>
        DepthTextureMode = 34891,
        /// <summary>
        /// The texture compare mode texture parameter name
        /// </summary>
        TextureCompareMode = 34892,
        /// <summary>
        /// The texture compare func texture parameter name
        /// </summary>
        TextureCompareFunc = 34893,
        /// <summary>
        /// The texture swizzle texture parameter name
        /// </summary>
        TextureSwizzleR = 36418,
        /// <summary>
        /// The texture swizzle texture parameter name
        /// </summary>
        TextureSwizzleG = 36419,
        /// <summary>
        /// The texture swizzle texture parameter name
        /// </summary>
        TextureSwizzleB = 36420,
        /// <summary>
        /// The texture swizzle texture parameter name
        /// </summary>
        TextureSwizzleA = 36421,
        /// <summary>
        /// The texture swizzle rgba texture parameter name
        /// </summary>
        TextureSwizzleRgba = 36422
    }

    /// <summary>
    /// The string name enum
    /// </summary>
    public enum StringName
    {
        /// <summary>
        /// The vendor string name
        /// </summary>
        Vendor = 0x1F00,
        /// <summary>
        /// The renderer string name
        /// </summary>
        Renderer = 0x1F01,
        /// <summary>
        /// The version string name
        /// </summary>
        Version = 0x1F02,
        /// <summary>
        /// The shading language version string name
        /// </summary>
        ShadingLanguageVersion = 35724,
    }

    /// <summary>
    /// The string name indexed enum
    /// </summary>
    public enum StringNameIndexed
    {
        /// <summary>
        /// The extensions string name indexed
        /// </summary>
        Extensions = 7939
    }

    /// <summary>
    /// The object label identifier enum
    /// </summary>
    public enum ObjectLabelIdentifier
    {
        /// <summary>
        /// The texture object label identifier
        /// </summary>
        Texture = 5890,
        /// <summary>
        /// The vertex array object label identifier
        /// </summary>
        VertexArray = 32884,
        /// <summary>
        /// The buffer object label identifier
        /// </summary>
        Buffer = 33504,
        /// <summary>
        /// The shader object label identifier
        /// </summary>
        Shader = 33505,
        /// <summary>
        /// The program object label identifier
        /// </summary>
        Program = 33506,
        /// <summary>
        /// The query object label identifier
        /// </summary>
        Query = 33507,
        /// <summary>
        /// The program pipeline object label identifier
        /// </summary>
        ProgramPipeline = 33508,
        /// <summary>
        /// The sampler object label identifier
        /// </summary>
        Sampler = 33510,
        /// <summary>
        /// The framebuffer object label identifier
        /// </summary>
        Framebuffer = 36160,
        /// <summary>
        /// The renderbuffer object label identifier
        /// </summary>
        Renderbuffer = 36161,
        /// <summary>
        /// The transform feedback object label identifier
        /// </summary>
        TransformFeedback = 36386
    }

    /// <summary>
    /// The blit framebuffer filter enum
    /// </summary>
    public enum BlitFramebufferFilter
    {
        /// <summary>
        /// The nearest blit framebuffer filter
        /// </summary>
        Nearest = 9728,
        /// <summary>
        /// The linear blit framebuffer filter
        /// </summary>
        Linear = 9729
    }

    /// <summary>
    /// The error code enum
    /// </summary>
    public enum ErrorCode : int
    {
        /// <summary>
        /// The no error error code
        /// </summary>
        NoError = ((int)0),
        /// <summary>
        /// The invalid enum error code
        /// </summary>
        InvalidEnum = ((int)0x0500),
        /// <summary>
        /// The invalid value error code
        /// </summary>
        InvalidValue = ((int)0x0501),
        /// <summary>
        /// The invalid operation error code
        /// </summary>
        InvalidOperation = ((int)0x0502),
        /// <summary>
        /// The stack overflow error code
        /// </summary>
        StackOverflow = ((int)0x0503),
        /// <summary>
        /// The stack underflow error code
        /// </summary>
        StackUnderflow = ((int)0x0504),
        /// <summary>
        /// The out of memory error code
        /// </summary>
        OutOfMemory = ((int)0x0505),
        /// <summary>
        /// The invalid framebuffer operation error code
        /// </summary>
        InvalidFramebufferOperation = ((int)0x0506),
        /// <summary>
        /// The invalid framebuffer operation ext error code
        /// </summary>
        InvalidFramebufferOperationExt = ((int)0x0506),
        /// <summary>
        /// The invalid framebuffer operation oes error code
        /// </summary>
        InvalidFramebufferOperationOes = ((int)0x0506),
        /// <summary>
        /// The context lost error code
        /// </summary>
        ContextLost = ((int)0x0507),
        /// <summary>
        /// The table too large error code
        /// </summary>
        TableTooLarge = ((int)0x8031),
        /// <summary>
        /// The table too large ext error code
        /// </summary>
        TableTooLargeExt = ((int)0x8031),
        /// <summary>
        /// The texture too large ext error code
        /// </summary>
        TextureTooLargeExt = ((int)0x8065),
    }

    /// <summary>
    /// The program interface enum
    /// </summary>
    public enum ProgramInterface : int
    {
        /// <summary>
        /// The transform feedback buffer program interface
        /// </summary>
        TransformFeedbackBuffer = ((int)0x8C8E),
        /// <summary>
        /// The atomic counter buffer program interface
        /// </summary>
        AtomicCounterBuffer = ((int)0x92C0),
        /// <summary>
        /// The uniform program interface
        /// </summary>
        Uniform = ((int)0x92E1),
        /// <summary>
        /// The uniform block program interface
        /// </summary>
        UniformBlock = ((int)0x92E2),
        /// <summary>
        /// The program input program interface
        /// </summary>
        ProgramInput = ((int)0x92E3),
        /// <summary>
        /// The program output program interface
        /// </summary>
        ProgramOutput = ((int)0x92E4),
        /// <summary>
        /// The buffer variable program interface
        /// </summary>
        BufferVariable = ((int)0x92E5),
        /// <summary>
        /// The shader storage block program interface
        /// </summary>
        ShaderStorageBlock = ((int)0x92E6),
        /// <summary>
        /// The vertex subroutine program interface
        /// </summary>
        VertexSubroutine = ((int)0x92E8),
        /// <summary>
        /// The tess control subroutine program interface
        /// </summary>
        TessControlSubroutine = ((int)0x92E9),
        /// <summary>
        /// The tess evaluation subroutine program interface
        /// </summary>
        TessEvaluationSubroutine = ((int)0x92EA),
        /// <summary>
        /// The geometry subroutine program interface
        /// </summary>
        GeometrySubroutine = ((int)0x92EB),
        /// <summary>
        /// The fragment subroutine program interface
        /// </summary>
        FragmentSubroutine = ((int)0x92EC),
        /// <summary>
        /// The compute subroutine program interface
        /// </summary>
        ComputeSubroutine = ((int)0x92ED),
        /// <summary>
        /// The vertex subroutine uniform program interface
        /// </summary>
        VertexSubroutineUniform = ((int)0x92EE),
        /// <summary>
        /// The tess control subroutine uniform program interface
        /// </summary>
        TessControlSubroutineUniform = ((int)0x92EF),
        /// <summary>
        /// The tess evaluation subroutine uniform program interface
        /// </summary>
        TessEvaluationSubroutineUniform = ((int)0x92F0),
        /// <summary>
        /// The geometry subroutine uniform program interface
        /// </summary>
        GeometrySubroutineUniform = ((int)0x92F1),
        /// <summary>
        /// The fragment subroutine uniform program interface
        /// </summary>
        FragmentSubroutineUniform = ((int)0x92F2),
        /// <summary>
        /// The compute subroutine uniform program interface
        /// </summary>
        ComputeSubroutineUniform = ((int)0x92F3),
        /// <summary>
        /// The transform feedback varying program interface
        /// </summary>
        TransformFeedbackVarying = ((int)0x92F4),
    }

    /// <summary>
    /// The program interface parameter name enum
    /// </summary>
    public enum ProgramInterfaceParameterName : int
    {
        /// <summary>
        /// The active resources program interface parameter name
        /// </summary>
        ActiveResources = 0x92F5,
        /// <summary>
        /// The max name length program interface parameter name
        /// </summary>
        MaxNameLength = 0x92F6,
        /// <summary>
        /// The max num active variables program interface parameter name
        /// </summary>
        MaxNumActiveVariables = 0x92F7,
        /// <summary>
        /// The max num compatible subroutines program interface parameter name
        /// </summary>
        MaxNumCompatibleSubroutines = 0x92F8,
    }

    /// <summary>
    /// The texture access enum
    /// </summary>
    public enum TextureAccess : int
    {
        /// <summary>
        /// The read only texture access
        /// </summary>
        ReadOnly = ((int)0x88B8),
        /// <summary>
        /// The write only texture access
        /// </summary>
        WriteOnly = ((int)0x88B9),
        /// <summary>
        /// The read write texture access
        /// </summary>
        ReadWrite = ((int)0x88BA),
    }

    /// <summary>
    /// The sized internal format enum
    /// </summary>
    public enum SizedInternalFormat : int
    {
        /// <summary>
        /// The rgba sized internal format
        /// </summary>
        Rgba8 = ((int)0x8058),
        /// <summary>
        /// The rgba 16 sized internal format
        /// </summary>
        Rgba16 = ((int)0x805B),
        /// <summary>
        /// The  sized internal format
        /// </summary>
        R8 = ((int)0x8229),
        /// <summary>
        /// The 16 sized internal format
        /// </summary>
        R16 = ((int)0x822A),
        /// <summary>
        /// The rg sized internal format
        /// </summary>
        Rg8 = ((int)0x822B),
        /// <summary>
        /// The rg 16 sized internal format
        /// </summary>
        Rg16 = ((int)0x822C),
        /// <summary>
        /// The 16f sized internal format
        /// </summary>
        R16f = ((int)0x822D),
        /// <summary>
        /// The 32f sized internal format
        /// </summary>
        R32f = ((int)0x822E),
        /// <summary>
        /// The rg 16f sized internal format
        /// </summary>
        Rg16f = ((int)0x822F),
        /// <summary>
        /// The rg 32f sized internal format
        /// </summary>
        Rg32f = ((int)0x8230),
        /// <summary>
        /// The 8i sized internal format
        /// </summary>
        R8i = ((int)0x8231),
        /// <summary>
        /// The 8ui sized internal format
        /// </summary>
        R8ui = ((int)0x8232),
        /// <summary>
        /// The 16i sized internal format
        /// </summary>
        R16i = ((int)0x8233),
        /// <summary>
        /// The 16ui sized internal format
        /// </summary>
        R16ui = ((int)0x8234),
        /// <summary>
        /// The 32i sized internal format
        /// </summary>
        R32i = ((int)0x8235),
        /// <summary>
        /// The 32ui sized internal format
        /// </summary>
        R32ui = ((int)0x8236),
        /// <summary>
        /// The rg 8i sized internal format
        /// </summary>
        Rg8i = ((int)0x8237),
        /// <summary>
        /// The rg 8ui sized internal format
        /// </summary>
        Rg8ui = ((int)0x8238),
        /// <summary>
        /// The rg 16i sized internal format
        /// </summary>
        Rg16i = ((int)0x8239),
        /// <summary>
        /// The rg 16ui sized internal format
        /// </summary>
        Rg16ui = ((int)0x823A),
        /// <summary>
        /// The rg 32i sized internal format
        /// </summary>
        Rg32i = ((int)0x823B),
        /// <summary>
        /// The rg 32ui sized internal format
        /// </summary>
        Rg32ui = ((int)0x823C),
        /// <summary>
        /// The rgba 32f sized internal format
        /// </summary>
        Rgba32f = ((int)0x8814),
        /// <summary>
        /// The rgba 16f sized internal format
        /// </summary>
        Rgba16f = ((int)0x881A),
        /// <summary>
        /// The rgba 32ui sized internal format
        /// </summary>
        Rgba32ui = ((int)0x8D70),
        /// <summary>
        /// The rgba 16ui sized internal format
        /// </summary>
        Rgba16ui = ((int)0x8D76),
        /// <summary>
        /// The rgba 8ui sized internal format
        /// </summary>
        Rgba8ui = ((int)0x8D7C),
        /// <summary>
        /// The rgba 32i sized internal format
        /// </summary>
        Rgba32i = ((int)0x8D82),
        /// <summary>
        /// The rgba 16i sized internal format
        /// </summary>
        Rgba16i = ((int)0x8D88),
        /// <summary>
        /// The rgba 8i sized internal format
        /// </summary>
        Rgba8i = ((int)0x8D8E),
    }

    /// <summary>
    /// The memory barrier flags enum
    /// </summary>
    public enum MemoryBarrierFlags : int
    {
        /// <summary>
        /// The vertex attrib array barrier bit memory barrier flags
        /// </summary>
        VertexAttribArrayBarrierBit = ((int)0x00000001),
        /// <summary>
        /// The element array barrier bit memory barrier flags
        /// </summary>
        ElementArrayBarrierBit = ((int)0x00000002),
        /// <summary>
        /// The uniform barrier bit memory barrier flags
        /// </summary>
        UniformBarrierBit = ((int)0x00000004),
        /// <summary>
        /// The texture fetch barrier bit memory barrier flags
        /// </summary>
        TextureFetchBarrierBit = ((int)0x00000008),
        /// <summary>
        /// The shader image access barrier bit memory barrier flags
        /// </summary>
        ShaderImageAccessBarrierBit = ((int)0x00000020),
        /// <summary>
        /// The command barrier bit memory barrier flags
        /// </summary>
        CommandBarrierBit = ((int)0x00000040),
        /// <summary>
        /// The pixel buffer barrier bit memory barrier flags
        /// </summary>
        PixelBufferBarrierBit = ((int)0x00000080),
        /// <summary>
        /// The texture update barrier bit memory barrier flags
        /// </summary>
        TextureUpdateBarrierBit = ((int)0x00000100),
        /// <summary>
        /// The buffer update barrier bit memory barrier flags
        /// </summary>
        BufferUpdateBarrierBit = ((int)0x00000200),
        /// <summary>
        /// The framebuffer barrier bit memory barrier flags
        /// </summary>
        FramebufferBarrierBit = ((int)0x00000400),
        /// <summary>
        /// The transform feedback barrier bit memory barrier flags
        /// </summary>
        TransformFeedbackBarrierBit = ((int)0x00000800),
        /// <summary>
        /// The atomic counter barrier bit memory barrier flags
        /// </summary>
        AtomicCounterBarrierBit = ((int)0x00001000),
        /// <summary>
        /// The shader storage barrier bit memory barrier flags
        /// </summary>
        ShaderStorageBarrierBit = ((int)0x00002000),
        /// <summary>
        /// The client mapped buffer barrier bit memory barrier flags
        /// </summary>
        ClientMappedBufferBarrierBit = ((int)0x00004000),
        /// <summary>
        /// The query buffer barrier bit memory barrier flags
        /// </summary>
        QueryBufferBarrierBit = ((int)0x00008000),
        /// <summary>
        /// The all barrier bits memory barrier flags
        /// </summary>
        AllBarrierBits = unchecked((int)0xFFFFFFFF),
    }


    /// <summary>
    /// The buffer access enum
    /// </summary>
    public enum BufferAccess : int
    {
        /// <summary>
        /// The read only buffer access
        /// </summary>
        ReadOnly = ((int)0x88B8),
        /// <summary>
        /// The write only buffer access
        /// </summary>
        WriteOnly = ((int)0x88B9),
        /// <summary>
        /// The read write buffer access
        /// </summary>
        ReadWrite = ((int)0x88BA),
    }

    /// <summary>
    /// The buffer access mask enum
    /// </summary>
    [Flags]
    public enum BufferAccessMask : int
    {
        /// <summary>
        /// The read buffer access mask
        /// </summary>
        Read = ((int)0x0001),
        /// <summary>
        /// The write buffer access mask
        /// </summary>
        Write = ((int)0x0002),
        /// <summary>
        /// The invalidate range buffer access mask
        /// </summary>
        InvalidateRange = ((int)0x0004),
        /// <summary>
        /// The invalidate buffer buffer access mask
        /// </summary>
        InvalidateBuffer = ((int)0x0008),
        /// <summary>
        /// The flush explicit buffer access mask
        /// </summary>
        FlushExplicit = ((int)0x0010),
        /// <summary>
        /// The unsynchronized buffer access mask
        /// </summary>
        Unsynchronized = ((int)0x0020),
        /// <summary>
        /// The persistent buffer access mask
        /// </summary>
        Persistent = ((int)0x0040),
        /// <summary>
        /// The coherent buffer access mask
        /// </summary>
        Coherent = ((int)0x0080),
    }

    /// <summary>
    /// The stencil function enum
    /// </summary>
    public enum StencilFunction : int
    {
        /// <summary>
        /// The never stencil function
        /// </summary>
        Never = ((int)0x0200),
        /// <summary>
        /// The less stencil function
        /// </summary>
        Less = ((int)0x0201),
        /// <summary>
        /// The equal stencil function
        /// </summary>
        Equal = ((int)0x0202),
        /// <summary>
        /// The lequal stencil function
        /// </summary>
        Lequal = ((int)0x0203),
        /// <summary>
        /// The greater stencil function
        /// </summary>
        Greater = ((int)0x0204),
        /// <summary>
        /// The notequal stencil function
        /// </summary>
        Notequal = ((int)0x0205),
        /// <summary>
        /// The gequal stencil function
        /// </summary>
        Gequal = ((int)0x0206),
        /// <summary>
        /// The always stencil function
        /// </summary>
        Always = ((int)0x0207),
    }

    /// <summary>
    /// The stencil op enum
    /// </summary>
    public enum StencilOp : int
    {
        /// <summary>
        /// The zero stencil op
        /// </summary>
        Zero = ((int)0),
        /// <summary>
        /// The invert stencil op
        /// </summary>
        Invert = ((int)0x150A),
        /// <summary>
        /// The keep stencil op
        /// </summary>
        Keep = ((int)0x1E00),
        /// <summary>
        /// The replace stencil op
        /// </summary>
        Replace = ((int)0x1E01),
        /// <summary>
        /// The incr stencil op
        /// </summary>
        Incr = ((int)0x1E02),
        /// <summary>
        /// The decr stencil op
        /// </summary>
        Decr = ((int)0x1E03),
        /// <summary>
        /// The incr wrap stencil op
        /// </summary>
        IncrWrap = ((int)0x8507),
        /// <summary>
        /// The decr wrap stencil op
        /// </summary>
        DecrWrap = ((int)0x8508),
    }

    /// <summary>
    /// The active uniform block parameter enum
    /// </summary>
    public enum ActiveUniformBlockParameter : int
    {
        /// <summary>
        /// The uniform block referenced by tess control shader active uniform block parameter
        /// </summary>
        UniformBlockReferencedByTessControlShader = ((int)0x84F0),
        /// <summary>
        /// The uniform block referenced by tess evaluation shader active uniform block parameter
        /// </summary>
        UniformBlockReferencedByTessEvaluationShader = ((int)0x84F1),
        /// <summary>
        /// The uniform block binding active uniform block parameter
        /// </summary>
        UniformBlockBinding = ((int)0x8A3F),
        /// <summary>
        /// The uniform block data size active uniform block parameter
        /// </summary>
        UniformBlockDataSize = ((int)0x8A40),
        /// <summary>
        /// The uniform block name length active uniform block parameter
        /// </summary>
        UniformBlockNameLength = ((int)0x8A41),
        /// <summary>
        /// The uniform block active uniforms active uniform block parameter
        /// </summary>
        UniformBlockActiveUniforms = ((int)0x8A42),
        /// <summary>
        /// The uniform block active uniform indices active uniform block parameter
        /// </summary>
        UniformBlockActiveUniformIndices = ((int)0x8A43),
        /// <summary>
        /// The uniform block referenced by vertex shader active uniform block parameter
        /// </summary>
        UniformBlockReferencedByVertexShader = ((int)0x8A44),
        /// <summary>
        /// The uniform block referenced by geometry shader active uniform block parameter
        /// </summary>
        UniformBlockReferencedByGeometryShader = ((int)0x8A45),
        /// <summary>
        /// The uniform block referenced by fragment shader active uniform block parameter
        /// </summary>
        UniformBlockReferencedByFragmentShader = ((int)0x8A46),
        /// <summary>
        /// The uniform block referenced by compute shader active uniform block parameter
        /// </summary>
        UniformBlockReferencedByComputeShader = ((int)0x90EC),
    }

    /// <summary>
    /// The get texture parameter enum
    /// </summary>
    public enum GetTextureParameter : int
    {
        /// <summary>
        /// The texture width get texture parameter
        /// </summary>
        TextureWidth = ((int)0x1000),
        /// <summary>
        /// The texture height get texture parameter
        /// </summary>
        TextureHeight = ((int)0x1001),
        /// <summary>
        /// The texture components get texture parameter
        /// </summary>
        TextureComponents = ((int)0x1003),
        /// <summary>
        /// The texture internal format get texture parameter
        /// </summary>
        TextureInternalFormat = ((int)0x1003),
        /// <summary>
        /// The texture border color get texture parameter
        /// </summary>
        TextureBorderColor = ((int)0x1004),
        /// <summary>
        /// The texture border color nv get texture parameter
        /// </summary>
        TextureBorderColorNv = ((int)0x1004),
        /// <summary>
        /// The texture border get texture parameter
        /// </summary>
        TextureBorder = ((int)0x1005),
        /// <summary>
        /// The texture target get texture parameter
        /// </summary>
        TextureTarget = ((int)0x1006),
        /// <summary>
        /// The texture mag filter get texture parameter
        /// </summary>
        TextureMagFilter = ((int)0x2800),
        /// <summary>
        /// The texture min filter get texture parameter
        /// </summary>
        TextureMinFilter = ((int)0x2801),
        /// <summary>
        /// The texture wrap get texture parameter
        /// </summary>
        TextureWrapS = ((int)0x2802),
        /// <summary>
        /// The texture wrap get texture parameter
        /// </summary>
        TextureWrapT = ((int)0x2803),
        /// <summary>
        /// The texture red size get texture parameter
        /// </summary>
        TextureRedSize = ((int)0x805C),
        /// <summary>
        /// The texture green size get texture parameter
        /// </summary>
        TextureGreenSize = ((int)0x805D),
        /// <summary>
        /// The texture blue size get texture parameter
        /// </summary>
        TextureBlueSize = ((int)0x805E),
        /// <summary>
        /// The texture alpha size get texture parameter
        /// </summary>
        TextureAlphaSize = ((int)0x805F),
        /// <summary>
        /// The texture luminance size get texture parameter
        /// </summary>
        TextureLuminanceSize = ((int)0x8060),
        /// <summary>
        /// The texture intensity size get texture parameter
        /// </summary>
        TextureIntensitySize = ((int)0x8061),
        /// <summary>
        /// The texture priority get texture parameter
        /// </summary>
        TexturePriority = ((int)0x8066),
        /// <summary>
        /// The texture resident get texture parameter
        /// </summary>
        TextureResident = ((int)0x8067),
        /// <summary>
        /// The texture depth get texture parameter
        /// </summary>
        TextureDepth = ((int)0x8071),
        /// <summary>
        /// The texture depth ext get texture parameter
        /// </summary>
        TextureDepthExt = ((int)0x8071),
        /// <summary>
        /// The texture wrap get texture parameter
        /// </summary>
        TextureWrapR = ((int)0x8072),
        /// <summary>
        /// The texture wrap ext get texture parameter
        /// </summary>
        TextureWrapRExt = ((int)0x8072),
        /// <summary>
        /// The detail texture level sgis get texture parameter
        /// </summary>
        DetailTextureLevelSgis = ((int)0x809A),
        /// <summary>
        /// The detail texture mode sgis get texture parameter
        /// </summary>
        DetailTextureModeSgis = ((int)0x809B),
        /// <summary>
        /// The detail texture func points sgis get texture parameter
        /// </summary>
        DetailTextureFuncPointsSgis = ((int)0x809C),
        /// <summary>
        /// The sharpen texture func points sgis get texture parameter
        /// </summary>
        SharpenTextureFuncPointsSgis = ((int)0x80B0),
        /// <summary>
        /// The shadow ambient sgix get texture parameter
        /// </summary>
        ShadowAmbientSgix = ((int)0x80BF),
        /// <summary>
        /// The dual texture select sgis get texture parameter
        /// </summary>
        DualTextureSelectSgis = ((int)0x8124),
        /// <summary>
        /// The quad texture select sgis get texture parameter
        /// </summary>
        QuadTextureSelectSgis = ((int)0x8125),
        /// <summary>
        /// The texture dsize sgis get texture parameter
        /// </summary>
        Texture4DsizeSgis = ((int)0x8136),
        /// <summary>
        /// The texture wrap sgis get texture parameter
        /// </summary>
        TextureWrapQSgis = ((int)0x8137),
        /// <summary>
        /// The texture min lod get texture parameter
        /// </summary>
        TextureMinLod = ((int)0x813A),
        /// <summary>
        /// The texture min lod sgis get texture parameter
        /// </summary>
        TextureMinLodSgis = ((int)0x813A),
        /// <summary>
        /// The texture max lod get texture parameter
        /// </summary>
        TextureMaxLod = ((int)0x813B),
        /// <summary>
        /// The texture max lod sgis get texture parameter
        /// </summary>
        TextureMaxLodSgis = ((int)0x813B),
        /// <summary>
        /// The texture base level get texture parameter
        /// </summary>
        TextureBaseLevel = ((int)0x813C),
        /// <summary>
        /// The texture base level sgis get texture parameter
        /// </summary>
        TextureBaseLevelSgis = ((int)0x813C),
        /// <summary>
        /// The texture max level get texture parameter
        /// </summary>
        TextureMaxLevel = ((int)0x813D),
        /// <summary>
        /// The texture max level sgis get texture parameter
        /// </summary>
        TextureMaxLevelSgis = ((int)0x813D),
        /// <summary>
        /// The texture filter size sgis get texture parameter
        /// </summary>
        TextureFilter4SizeSgis = ((int)0x8147),
        /// <summary>
        /// The texture clipmap center sgix get texture parameter
        /// </summary>
        TextureClipmapCenterSgix = ((int)0x8171),
        /// <summary>
        /// The texture clipmap frame sgix get texture parameter
        /// </summary>
        TextureClipmapFrameSgix = ((int)0x8172),
        /// <summary>
        /// The texture clipmap offset sgix get texture parameter
        /// </summary>
        TextureClipmapOffsetSgix = ((int)0x8173),
        /// <summary>
        /// The texture clipmap virtual depth sgix get texture parameter
        /// </summary>
        TextureClipmapVirtualDepthSgix = ((int)0x8174),
        /// <summary>
        /// The texture clipmap lod offset sgix get texture parameter
        /// </summary>
        TextureClipmapLodOffsetSgix = ((int)0x8175),
        /// <summary>
        /// The texture clipmap depth sgix get texture parameter
        /// </summary>
        TextureClipmapDepthSgix = ((int)0x8176),
        /// <summary>
        /// The post texture filter bias sgix get texture parameter
        /// </summary>
        PostTextureFilterBiasSgix = ((int)0x8179),
        /// <summary>
        /// The post texture filter scale sgix get texture parameter
        /// </summary>
        PostTextureFilterScaleSgix = ((int)0x817A),
        /// <summary>
        /// The texture lod bias sgix get texture parameter
        /// </summary>
        TextureLodBiasSSgix = ((int)0x818E),
        /// <summary>
        /// The texture lod bias sgix get texture parameter
        /// </summary>
        TextureLodBiasTSgix = ((int)0x818F),
        /// <summary>
        /// The texture lod bias sgix get texture parameter
        /// </summary>
        TextureLodBiasRSgix = ((int)0x8190),
        /// <summary>
        /// The generate mipmap get texture parameter
        /// </summary>
        GenerateMipmap = ((int)0x8191),
        /// <summary>
        /// The generate mipmap sgis get texture parameter
        /// </summary>
        GenerateMipmapSgis = ((int)0x8191),
        /// <summary>
        /// The texture compare sgix get texture parameter
        /// </summary>
        TextureCompareSgix = ((int)0x819A),
        /// <summary>
        /// The texture compare operator sgix get texture parameter
        /// </summary>
        TextureCompareOperatorSgix = ((int)0x819B),
        /// <summary>
        /// The texture lequal sgix get texture parameter
        /// </summary>
        TextureLequalRSgix = ((int)0x819C),
        /// <summary>
        /// The texture gequal sgix get texture parameter
        /// </summary>
        TextureGequalRSgix = ((int)0x819D),
        /// <summary>
        /// The texture view min level get texture parameter
        /// </summary>
        TextureViewMinLevel = ((int)0x82DB),
        /// <summary>
        /// The texture view num levels get texture parameter
        /// </summary>
        TextureViewNumLevels = ((int)0x82DC),
        /// <summary>
        /// The texture view min layer get texture parameter
        /// </summary>
        TextureViewMinLayer = ((int)0x82DD),
        /// <summary>
        /// The texture view num layers get texture parameter
        /// </summary>
        TextureViewNumLayers = ((int)0x82DE),
        /// <summary>
        /// The texture immutable levels get texture parameter
        /// </summary>
        TextureImmutableLevels = ((int)0x82DF),
        /// <summary>
        /// The texture max clamp sgix get texture parameter
        /// </summary>
        TextureMaxClampSSgix = ((int)0x8369),
        /// <summary>
        /// The texture max clamp sgix get texture parameter
        /// </summary>
        TextureMaxClampTSgix = ((int)0x836A),
        /// <summary>
        /// The texture max clamp sgix get texture parameter
        /// </summary>
        TextureMaxClampRSgix = ((int)0x836B),
        /// <summary>
        /// The texture compressed image size get texture parameter
        /// </summary>
        TextureCompressedImageSize = ((int)0x86A0),
        /// <summary>
        /// The texture compressed get texture parameter
        /// </summary>
        TextureCompressed = ((int)0x86A1),
        /// <summary>
        /// The texture depth size get texture parameter
        /// </summary>
        TextureDepthSize = ((int)0x884A),
        /// <summary>
        /// The depth texture mode get texture parameter
        /// </summary>
        DepthTextureMode = ((int)0x884B),
        /// <summary>
        /// The texture compare mode get texture parameter
        /// </summary>
        TextureCompareMode = ((int)0x884C),
        /// <summary>
        /// The texture compare func get texture parameter
        /// </summary>
        TextureCompareFunc = ((int)0x884D),
        /// <summary>
        /// The texture stencil size get texture parameter
        /// </summary>
        TextureStencilSize = ((int)0x88F1),
        /// <summary>
        /// The texture red type get texture parameter
        /// </summary>
        TextureRedType = ((int)0x8C10),
        /// <summary>
        /// The texture green type get texture parameter
        /// </summary>
        TextureGreenType = ((int)0x8C11),
        /// <summary>
        /// The texture blue type get texture parameter
        /// </summary>
        TextureBlueType = ((int)0x8C12),
        /// <summary>
        /// The texture alpha type get texture parameter
        /// </summary>
        TextureAlphaType = ((int)0x8C13),
        /// <summary>
        /// The texture luminance type get texture parameter
        /// </summary>
        TextureLuminanceType = ((int)0x8C14),
        /// <summary>
        /// The texture intensity type get texture parameter
        /// </summary>
        TextureIntensityType = ((int)0x8C15),
        /// <summary>
        /// The texture depth type get texture parameter
        /// </summary>
        TextureDepthType = ((int)0x8C16),
        /// <summary>
        /// The texture shared size get texture parameter
        /// </summary>
        TextureSharedSize = ((int)0x8C3F),
        /// <summary>
        /// The texture swizzle get texture parameter
        /// </summary>
        TextureSwizzleR = ((int)0x8E42),
        /// <summary>
        /// The texture swizzle get texture parameter
        /// </summary>
        TextureSwizzleG = ((int)0x8E43),
        /// <summary>
        /// The texture swizzle get texture parameter
        /// </summary>
        TextureSwizzleB = ((int)0x8E44),
        /// <summary>
        /// The texture swizzle get texture parameter
        /// </summary>
        TextureSwizzleA = ((int)0x8E45),
        /// <summary>
        /// The texture swizzle rgba get texture parameter
        /// </summary>
        TextureSwizzleRgba = ((int)0x8E46),
        /// <summary>
        /// The image format compatibility type get texture parameter
        /// </summary>
        ImageFormatCompatibilityType = ((int)0x90C7),
        /// <summary>
        /// The texture samples get texture parameter
        /// </summary>
        TextureSamples = ((int)0x9106),
        /// <summary>
        /// The texture fixed sample locations get texture parameter
        /// </summary>
        TextureFixedSampleLocations = ((int)0x9107),
        /// <summary>
        /// The texture immutable format get texture parameter
        /// </summary>
        TextureImmutableFormat = ((int)0x912F),
    }

    /// <summary>
    /// The renderbuffer pname enum
    /// </summary>
    public enum RenderbufferPname
    {
        /// <summary>
        /// The renderbuffer width renderbuffer pname
        /// </summary>
        RenderbufferWidth = 0x8D42,
        /// <summary>
        /// The renderbuffer height renderbuffer pname
        /// </summary>
        RenderbufferHeight = 0x8D43,
    }

    /// <summary>
    /// The clip control origin enum
    /// </summary>
    public enum ClipControlOrigin
    {
        /// <summary>
        /// The lower left clip control origin
        /// </summary>
        LowerLeft = 0x8CA1,
        /// <summary>
        /// The upper left clip control origin
        /// </summary>
        UpperLeft = 0x8CA2,
    }

    /// <summary>
    /// The clip control depth range enum
    /// </summary>
    public enum ClipControlDepthRange
    {
        /// <summary>
        /// The negative one to one clip control depth range
        /// </summary>
        NegativeOneToOne = 0x935E,
        /// <summary>
        /// The zero to one clip control depth range
        /// </summary>
        ZeroToOne = 0x935F,
    }

    /// <summary>
    /// The framebuffer parameter name enum
    /// </summary>
    public enum FramebufferParameterName
    {
        /// <summary>
        /// The color encoding framebuffer parameter name
        /// </summary>
        ColorEncoding = 0x8210,
        /// <summary>
        /// The component type framebuffer parameter name
        /// </summary>
        ComponentType = 0x8211,
        /// <summary>
        /// The red size framebuffer parameter name
        /// </summary>
        RedSize = 0x8212,
        /// <summary>
        /// The green size framebuffer parameter name
        /// </summary>
        GreenSize = 0x8213,
        /// <summary>
        /// The blue size framebuffer parameter name
        /// </summary>
        BlueSize = 0x8214,
        /// <summary>
        /// The alpha size framebuffer parameter name
        /// </summary>
        AlphaSize = 0x8215,
        /// <summary>
        /// The depth size framebuffer parameter name
        /// </summary>
        DepthSize = 0x8216,
        /// <summary>
        /// The stencil size framebuffer parameter name
        /// </summary>
        StencilSize = 0x8217,
        /// <summary>
        /// The object type framebuffer parameter name
        /// </summary>
        ObjectType = 0x8CD0,
        /// <summary>
        /// The object name framebuffer parameter name
        /// </summary>
        ObjectName = 0x8CD1,
        /// <summary>
        /// The texture lvel framebuffer parameter name
        /// </summary>
        TextureLvel = 0x8CD2,
        /// <summary>
        /// The cube map face framebuffer parameter name
        /// </summary>
        CubeMapFace = 0x8CD3,
        /// <summary>
        /// The texture layer framebuffer parameter name
        /// </summary>
        TextureLayer = 0x8CD4,
        /// <summary>
        /// The layered framebuffer parameter name
        /// </summary>
        Layered = 0x8DA7,
        /// <summary>
        /// The layer targets framebuffer parameter name
        /// </summary>
        LayerTargets = 0x8DA8,
    }
}
