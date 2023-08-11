using System;
using System.Runtime.InteropServices;

namespace Veldrid.OpenGLBinding
{
    // uint = uint
    // GLuint = uint
    // GLuint64 = uint64
    // GLenum = uint
    // Glclampf = 32-bit float, [0, 1]
    /// <summary>
    /// The open gl native class
    /// </summary>
    public static unsafe class OpenGLNative
    {
        /// <summary>
        /// The getprocaddress
        /// </summary>
        private static Func<string, IntPtr> s_getProcAddress;

        /// <summary>
        /// The winapi
        /// </summary>
        private const CallingConvention CallConv = CallingConvention.Winapi;

        /// <summary>
        /// The glgenvertexarrays
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGenVertexArrays_t(uint n, out uint arrays);
        /// <summary>
        /// The glgenvertexarrays
        /// </summary>
        private static glGenVertexArrays_t p_glGenVertexArrays;
        /// <summary>
        /// Gls the gen vertex arrays using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="arrays">The arrays</param>
        public static void glGenVertexArrays(uint n, out uint arrays) => p_glGenVertexArrays(n, out arrays);

        /// <summary>
        /// The glgeterror
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate uint glGetError_t();
        /// <summary>
        /// The glgeterror
        /// </summary>
        private static glGetError_t p_glGetError;
        /// <summary>
        /// Gls the get error
        /// </summary>
        /// <returns>The uint</returns>
        public static uint glGetError() => p_glGetError();

        /// <summary>
        /// The glbindvertexarray
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBindVertexArray_t(uint array);
        /// <summary>
        /// The glbindvertexarray
        /// </summary>
        private static glBindVertexArray_t p_glBindVertexArray;
        /// <summary>
        /// Gls the bind vertex array using the specified array
        /// </summary>
        /// <param name="array">The array</param>
        public static void glBindVertexArray(uint array) => p_glBindVertexArray(array);

        /// <summary>
        /// The glclearcolor
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glClearColor_t(float red, float green, float blue, float alpha);
        /// <summary>
        /// The glclearcolor
        /// </summary>
        private static glClearColor_t p_glClearColor;
        /// <summary>
        /// Gls the clear color using the specified red
        /// </summary>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <param name="alpha">The alpha</param>
        public static void glClearColor(float red, float green, float blue, float alpha)
            => p_glClearColor(red, green, blue, alpha);

        /// <summary>
        /// The gldrawbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDrawBuffer_t(DrawBufferMode mode);
        /// <summary>
        /// The gldrawbuffer
        /// </summary>
        private static glDrawBuffer_t p_glDrawBuffer;
        /// <summary>
        /// Gls the draw buffer using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        public static void glDrawBuffer(DrawBufferMode mode) => p_glDrawBuffer(mode);

        /// <summary>
        /// The gldrawbuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDrawBuffers_t(uint n, DrawBuffersEnum* bufs);
        /// <summary>
        /// The gldrawbuffers
        /// </summary>
        private static glDrawBuffers_t p_glDrawBuffers;
        /// <summary>
        /// Gls the draw buffers using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="bufs">The bufs</param>
        public static void glDrawBuffers(uint n, DrawBuffersEnum* bufs) => p_glDrawBuffers(n, bufs);

        /// <summary>
        /// The glclear
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glClear_t(ClearBufferMask mask);
        /// <summary>
        /// The glclear
        /// </summary>
        private static glClear_t p_glClear;
        /// <summary>
        /// Gls the clear using the specified mask
        /// </summary>
        /// <param name="mask">The mask</param>
        public static void glClear(ClearBufferMask mask) => p_glClear(mask);

        /// <summary>
        /// The glcleardepth
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glClearDepth_t(double depth);
        /// <summary>
        /// The glcleardepth
        /// </summary>
        private static glClearDepth_t p_glClearDepth;
        /// <summary>
        /// Gls the clear depth using the specified depth
        /// </summary>
        /// <param name="depth">The depth</param>
        public static void glClearDepth(double depth) => p_glClearDepth(depth);

        /// <summary>
        /// The glcleardepthf
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glClearDepthf_t(float depth);
        /// <summary>
        /// The glcleardepthf
        /// </summary>
        private static glClearDepthf_t p_glClearDepthf;
        /// <summary>
        /// Gls the clear depthf using the specified depth
        /// </summary>
        /// <param name="depth">The depth</param>
        public static void glClearDepthf(float depth) => p_glClearDepthf(depth);

        /// <summary>
        /// The glcleardepthf compat
        /// </summary>
        private static glClearDepthf_t p_glClearDepthf_Compat;
        /// <summary>
        /// Gls the clear depth compat using the specified depth
        /// </summary>
        /// <param name="depth">The depth</param>
        public static void glClearDepth_Compat(float depth) => p_glClearDepthf_Compat(depth);

        /// <summary>
        /// The gldrawelements
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDrawElements_t(PrimitiveType mode, uint count, DrawElementsType type, void* indices);
        /// <summary>
        /// The gldrawelements
        /// </summary>
        private static glDrawElements_t p_glDrawElements;
        /// <summary>
        /// Gls the draw elements using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="count">The count</param>
        /// <param name="type">The type</param>
        /// <param name="indices">The indices</param>
        public static void glDrawElements(PrimitiveType mode, uint count, DrawElementsType type, void* indices)
            => p_glDrawElements(mode, count, type, indices);

        /// <summary>
        /// The gldrawelementsbasevertex
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDrawElementsBaseVertex_t(
            PrimitiveType mode,
            uint count,
            DrawElementsType type,
            void* indices,
            int basevertex);
        /// <summary>
        /// The gldrawelementsbasevertex
        /// </summary>
        private static glDrawElementsBaseVertex_t p_glDrawElementsBaseVertex;
        /// <summary>
        /// Gls the draw elements base vertex using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="count">The count</param>
        /// <param name="type">The type</param>
        /// <param name="indices">The indices</param>
        /// <param name="basevertex">The basevertex</param>
        public static void glDrawElementsBaseVertex(
            PrimitiveType mode,
            uint count,
            DrawElementsType type,
            void* indices,
            int basevertex) => p_glDrawElementsBaseVertex(mode, count, type, indices, basevertex);

        /// <summary>
        /// The gldrawelementsinstanced
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDrawElementsInstanced_t(
            PrimitiveType mode,
            uint count,
            DrawElementsType type,
            void* indices,
            uint primcount);
        /// <summary>
        /// The gldrawelementsinstanced
        /// </summary>
        private static glDrawElementsInstanced_t p_glDrawElementsInstanced;
        /// <summary>
        /// Gls the draw elements instanced using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="count">The count</param>
        /// <param name="type">The type</param>
        /// <param name="indices">The indices</param>
        /// <param name="primcount">The primcount</param>
        public static void glDrawElementsInstanced(
            PrimitiveType mode,
            uint count,
            DrawElementsType type,
            void* indices,
            uint primcount) => p_glDrawElementsInstanced(mode, count, type, indices, primcount);

        /// <summary>
        /// The gldrawelementsinstancedbasevertex
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDrawElementsInstancedBaseVertex_t(
            PrimitiveType mode,
            uint count,
            DrawElementsType type,
            void* indices,
            uint primcount,
            int basevertex);
        /// <summary>
        /// The gldrawelementsinstancedbasevertex
        /// </summary>
        private static glDrawElementsInstancedBaseVertex_t p_glDrawElementsInstancedBaseVertex;
        /// <summary>
        /// Gls the draw elements instanced base vertex using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="count">The count</param>
        /// <param name="type">The type</param>
        /// <param name="indices">The indices</param>
        /// <param name="primcount">The primcount</param>
        /// <param name="basevertex">The basevertex</param>
        public static void glDrawElementsInstancedBaseVertex(
            PrimitiveType mode,
            uint count,
            DrawElementsType type,
            void* indices,
            uint primcount,
            int basevertex) => p_glDrawElementsInstancedBaseVertex(mode, count, type, indices, primcount, basevertex);

        /// <summary>
        /// The gldrawelementsinstancedbasevertexbaseinstance
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDrawElementsInstancedBaseVertexBaseInstance_t(
            PrimitiveType mode,
            uint count,
            DrawElementsType type,
            void* indices,
            uint primcount,
            int basevertex,
            uint baseinstance);
        /// <summary>
        /// The gldrawelementsinstancedbasevertexbaseinstance
        /// </summary>
        private static glDrawElementsInstancedBaseVertexBaseInstance_t p_glDrawElementsInstancedBaseVertexBaseInstance;
        /// <summary>
        /// Gls the draw elements instanced base vertex base instance using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="count">The count</param>
        /// <param name="type">The type</param>
        /// <param name="indices">The indices</param>
        /// <param name="primcount">The primcount</param>
        /// <param name="basevertex">The basevertex</param>
        /// <param name="baseinstance">The baseinstance</param>
        public static void glDrawElementsInstancedBaseVertexBaseInstance(
            PrimitiveType mode,
            uint count,
            DrawElementsType type,
            void* indices,
            uint primcount,
            int basevertex,
            uint baseinstance)
            => p_glDrawElementsInstancedBaseVertexBaseInstance(
                mode, count, type, indices, primcount, basevertex, baseinstance);

        /// <summary>
        /// The gldrawarrays
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDrawArrays_t(PrimitiveType mode, int first, uint count);
        /// <summary>
        /// The gldrawarrays
        /// </summary>
        private static glDrawArrays_t p_glDrawArrays;
        /// <summary>
        /// Gls the draw arrays using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="first">The first</param>
        /// <param name="count">The count</param>
        public static void glDrawArrays(PrimitiveType mode, int first, uint count) => p_glDrawArrays(mode, first, count);

        /// <summary>
        /// The gldrawarraysinstanced
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDrawArraysInstanced_t(PrimitiveType mode, int first, uint count, uint primcount);
        /// <summary>
        /// The gldrawarraysinstanced
        /// </summary>
        private static glDrawArraysInstanced_t p_glDrawArraysInstanced;
        /// <summary>
        /// Gls the draw arrays instanced using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="first">The first</param>
        /// <param name="count">The count</param>
        /// <param name="primcount">The primcount</param>
        public static void glDrawArraysInstanced(PrimitiveType mode, int first, uint count, uint primcount)
            => p_glDrawArraysInstanced(mode, first, count, primcount);

        /// <summary>
        /// The gldrawarraysinstancedbaseinstance
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDrawArraysInstancedBaseInstance_t(
            PrimitiveType mode,
            int first,
            uint count,
            uint primcount,
            uint baseinstance);
        /// <summary>
        /// The gldrawarraysinstancedbaseinstance
        /// </summary>
        private static glDrawArraysInstancedBaseInstance_t p_glDrawArraysInstancedBaseInstance;
        /// <summary>
        /// Gls the draw arrays instanced base instance using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="first">The first</param>
        /// <param name="count">The count</param>
        /// <param name="primcount">The primcount</param>
        /// <param name="baseinstance">The baseinstance</param>
        public static void glDrawArraysInstancedBaseInstance(
            PrimitiveType mode,
            int first,
            uint count,
            uint primcount,
            uint baseinstance) => p_glDrawArraysInstancedBaseInstance(mode, first, count, primcount, baseinstance);

        /// <summary>
        /// The glgenbuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGenBuffers_t(uint n, out uint buffers);
        /// <summary>
        /// The glgenbuffers
        /// </summary>
        private static glGenBuffers_t p_glGenBuffers;
        /// <summary>
        /// Gls the gen buffers using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="buffers">The buffers</param>
        public static void glGenBuffers(uint n, out uint buffers) => p_glGenBuffers(n, out buffers);

        /// <summary>
        /// The gldeletebuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDeleteBuffers_t(uint n, ref uint buffers);
        /// <summary>
        /// The gldeletebuffers
        /// </summary>
        private static glDeleteBuffers_t p_glDeleteBuffers;
        /// <summary>
        /// Gls the delete buffers using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="buffers">The buffers</param>
        public static void glDeleteBuffers(uint n, ref uint buffers) => p_glDeleteBuffers(n, ref buffers);

        /// <summary>
        /// The glgenframebuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGenFramebuffers_t(uint n, out uint ids);
        /// <summary>
        /// The glgenframebuffers
        /// </summary>
        private static glGenFramebuffers_t p_glGenFramebuffers;
        /// <summary>
        /// Gls the gen framebuffers using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="ids">The ids</param>
        public static void glGenFramebuffers(uint n, out uint ids) => p_glGenFramebuffers(n, out ids);

        /// <summary>
        /// The glactivetexture
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glActiveTexture_t(TextureUnit texture);
        /// <summary>
        /// The glactivetexture
        /// </summary>
        private static glActiveTexture_t p_glActiveTexture;
        /// <summary>
        /// Gls the active texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        public static void glActiveTexture(TextureUnit texture) => p_glActiveTexture(texture);

        /// <summary>
        /// The glframebuffertexture1d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glFramebufferTexture1D_t(
            FramebufferTarget target,
            GLFramebufferAttachment attachment,
            TextureTarget textarget,
            uint texture,
            int level);
        /// <summary>
        /// The glframebuffertexture1d
        /// </summary>
        private static glFramebufferTexture1D_t p_glFramebufferTexture1D;
        /// <summary>
        /// Gls the framebuffer texture 1 d using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="attachment">The attachment</param>
        /// <param name="textarget">The textarget</param>
        /// <param name="texture">The texture</param>
        /// <param name="level">The level</param>
        public static void glFramebufferTexture1D(
            FramebufferTarget target,
            GLFramebufferAttachment attachment,
            TextureTarget textarget,
            uint texture,
            int level) => p_glFramebufferTexture1D(target, attachment, textarget, texture, level);

        /// <summary>
        /// The glframebuffertexture2d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glFramebufferTexture2D_t(
            FramebufferTarget target,
            GLFramebufferAttachment attachment,
            TextureTarget textarget,
            uint texture,
            int level);
        /// <summary>
        /// The glframebuffertexture2d
        /// </summary>
        private static glFramebufferTexture2D_t p_glFramebufferTexture2D;
        /// <summary>
        /// Gls the framebuffer texture 2 d using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="attachment">The attachment</param>
        /// <param name="textarget">The textarget</param>
        /// <param name="texture">The texture</param>
        /// <param name="level">The level</param>
        public static void glFramebufferTexture2D(
            FramebufferTarget target,
            GLFramebufferAttachment attachment,
            TextureTarget textarget,
            uint texture,
            int level) => p_glFramebufferTexture2D(target, attachment, textarget, texture, level);

        /// <summary>
        /// The glbindtexture
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBindTexture_t(TextureTarget target, uint texture);
        /// <summary>
        /// The glbindtexture
        /// </summary>
        private static glBindTexture_t p_glBindTexture;
        /// <summary>
        /// Gls the bind texture using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="texture">The texture</param>
        public static void glBindTexture(TextureTarget target, uint texture) => p_glBindTexture(target, texture);

        /// <summary>
        /// The glbindframebuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBindFramebuffer_t(FramebufferTarget target, uint framebuffer);
        /// <summary>
        /// The glbindframebuffer
        /// </summary>
        private static glBindFramebuffer_t p_glBindFramebuffer;
        /// <summary>
        /// Gls the bind framebuffer using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="framebuffer">The framebuffer</param>
        public static void glBindFramebuffer(FramebufferTarget target, uint framebuffer)
            => p_glBindFramebuffer(target, framebuffer);

        /// <summary>
        /// The gldeleteframebuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDeleteFramebuffers_t(uint n, ref uint framebuffers);
        /// <summary>
        /// The gldeleteframebuffers
        /// </summary>
        private static glDeleteFramebuffers_t p_glDeleteFramebuffers;
        /// <summary>
        /// Gls the delete framebuffers using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="framebuffers">The framebuffers</param>
        public static void glDeleteFramebuffers(uint n, ref uint framebuffers) => p_glDeleteFramebuffers(n, ref framebuffers);

        /// <summary>
        /// The glgentextures
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGenTextures_t(uint n, out uint textures);
        /// <summary>
        /// The glgentextures
        /// </summary>
        private static glGenTextures_t p_glGenTextures;
        /// <summary>
        /// Gls the gen textures using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="textures">The textures</param>
        public static void glGenTextures(uint n, out uint textures) => p_glGenTextures(n, out textures);

        /// <summary>
        /// The gldeletetextures
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDeleteTextures_t(uint n, ref uint textures);
        /// <summary>
        /// The gldeletetextures
        /// </summary>
        private static glDeleteTextures_t p_glDeleteTextures;
        /// <summary>
        /// Gls the delete textures using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="textures">The textures</param>
        public static void glDeleteTextures(uint n, ref uint textures) => p_glDeleteTextures(n, ref textures);

        /// <summary>
        /// The glcheckframebufferstatus
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate FramebufferErrorCode glCheckFramebufferStatus_t(FramebufferTarget target);
        /// <summary>
        /// The glcheckframebufferstatus
        /// </summary>
        private static glCheckFramebufferStatus_t p_glCheckFramebufferStatus;
        /// <summary>
        /// Gls the check framebuffer status using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <returns>The framebuffer error code</returns>
        public static FramebufferErrorCode glCheckFramebufferStatus(FramebufferTarget target)
            => p_glCheckFramebufferStatus(target);

        /// <summary>
        /// The glbindbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBindBuffer_t(BufferTarget target, uint buffer);
        /// <summary>
        /// The glbindbuffer
        /// </summary>
        private static glBindBuffer_t p_glBindBuffer;
        /// <summary>
        /// Gls the bind buffer using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="buffer">The buffer</param>
        public static void glBindBuffer(BufferTarget target, uint buffer) => p_glBindBuffer(target, buffer);

        /// <summary>
        /// The glviewportindexedf
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glViewportIndexedf_t(uint index, float x, float y, float w, float h);
        /// <summary>
        /// The glviewportindexedf
        /// </summary>
        private static glViewportIndexedf_t p_glViewportIndexedf;
        /// <summary>
        /// Gls the viewport indexed using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        public static void glViewportIndexed(uint index, float x, float y, float w, float h)
            => p_glViewportIndexedf(index, x, y, w, h);

        /// <summary>
        /// The glviewport
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glViewport_t(int x, int y, uint width, uint height);
        /// <summary>
        /// The glviewport
        /// </summary>
        private static glViewport_t p_glViewport;
        /// <summary>
        /// Gls the viewport using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public static void glViewport(int x, int y, uint width, uint height) => p_glViewport(x, y, width, height);

        /// <summary>
        /// The gldepthrangeindexed
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDepthRangeIndexed_t(uint index, double nearVal, double farVal);
        /// <summary>
        /// The gldepthrangeindexed
        /// </summary>
        private static glDepthRangeIndexed_t p_glDepthRangeIndexed;
        /// <summary>
        /// Gls the depth range indexed using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="nearVal">The near val</param>
        /// <param name="farVal">The far val</param>
        public static void glDepthRangeIndexed(uint index, double nearVal, double farVal)
            => p_glDepthRangeIndexed(index, nearVal, farVal);

        /// <summary>
        /// The gldepthrangef
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDepthRangef_t(float n, float f);
        /// <summary>
        /// The gldepthrangef
        /// </summary>
        private static glDepthRangef_t p_glDepthRangef;
        /// <summary>
        /// Gls the depth rangef using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="f">The </param>
        public static void glDepthRangef(float n, float f) => p_glDepthRangef(n, f);

        /// <summary>
        /// The glbuffersubdata
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBufferSubData_t(BufferTarget target, IntPtr offset, UIntPtr size, void* data);
        /// <summary>
        /// The glbuffersubdata
        /// </summary>
        private static glBufferSubData_t p_glBufferSubData;
        /// <summary>
        /// Gls the buffer sub data using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="offset">The offset</param>
        /// <param name="size">The size</param>
        /// <param name="data">The data</param>
        public static void glBufferSubData(BufferTarget target, IntPtr offset, UIntPtr size, void* data)
            => p_glBufferSubData(target, offset, size, data);

        /// <summary>
        /// The glnamedbuffersubdata
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glNamedBufferSubData_t(uint buffer, IntPtr offset, uint size, void* data);
        /// <summary>
        /// The glnamedbuffersubdata
        /// </summary>
        private static glNamedBufferSubData_t p_glNamedBufferSubData;
        /// <summary>
        /// Gls the named buffer sub data using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="size">The size</param>
        /// <param name="data">The data</param>
        public static void glNamedBufferSubData(uint buffer, IntPtr offset, uint size, void* data)
            => p_glNamedBufferSubData(buffer, offset, size, data);

        /// <summary>
        /// The glscissorindexed
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glScissorIndexed_t(uint index, int left, int bottom, uint width, uint height);
        /// <summary>
        /// The glscissorindexed
        /// </summary>
        private static glScissorIndexed_t p_glScissorIndexed;
        /// <summary>
        /// Gls the scissor indexed using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="left">The left</param>
        /// <param name="bottom">The bottom</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public static void glScissorIndexed(uint index, int left, int bottom, uint width, uint height)
            => p_glScissorIndexed(index, left, bottom, width, height);

        /// <summary>
        /// The glscissor
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glScissor_t(int x, int y, uint width, uint height);
        /// <summary>
        /// The glscissor
        /// </summary>
        private static glScissor_t p_glScissor;
        /// <summary>
        /// Gls the scissor using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public static void glScissor(int x, int y, uint width, uint height) => p_glScissor(x, y, width, height);

        /// <summary>
        /// The glpixelstorei
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glPixelStorei_t(PixelStoreParameter pname, int param);
        /// <summary>
        /// The glpixelstorei
        /// </summary>
        private static glPixelStorei_t p_glPixelStorei;
        /// <summary>
        /// Gls the pixel storei using the specified pname
        /// </summary>
        /// <param name="pname">The pname</param>
        /// <param name="param">The param</param>
        public static void glPixelStorei(PixelStoreParameter pname, int param) => p_glPixelStorei(pname, param);

        /// <summary>
        /// The gltexsubimage1d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTexSubImage1D_t(
            TextureTarget target,
            int level,
            int xoffset,
            uint width,
            GLPixelFormat format,
            GLPixelType type,
            void* pixels);
        /// <summary>
        /// The gltexsubimage1d
        /// </summary>
        private static glTexSubImage1D_t p_glTexSubImage1D;
        /// <summary>
        /// Gls the tex sub image 1 d using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="level">The level</param>
        /// <param name="xoffset">The xoffset</param>
        /// <param name="width">The width</param>
        /// <param name="format">The format</param>
        /// <param name="type">The type</param>
        /// <param name="pixels">The pixels</param>
        public static void glTexSubImage1D(
            TextureTarget target,
            int level,
            int xoffset,
            uint width,
            GLPixelFormat format,
            GLPixelType type,
            void* pixels) => p_glTexSubImage1D(target, level, xoffset, width, format, type, pixels);

        /// <summary>
        /// The gltexsubimage2d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTexSubImage2D_t(
            TextureTarget target,
            int level,
            int xoffset,
            int yoffset,
            uint width,
            uint height,
            GLPixelFormat format,
            GLPixelType type,
            void* pixels);
        /// <summary>
        /// The gltexsubimage2d
        /// </summary>
        private static glTexSubImage2D_t p_glTexSubImage2D;
        /// <summary>
        /// Gls the tex sub image 2 d using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="level">The level</param>
        /// <param name="xoffset">The xoffset</param>
        /// <param name="yoffset">The yoffset</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="format">The format</param>
        /// <param name="type">The type</param>
        /// <param name="pixels">The pixels</param>
        public static void glTexSubImage2D(
            TextureTarget target,
            int level,
            int xoffset,
            int yoffset,
            uint width,
            uint height,
            GLPixelFormat format,
            GLPixelType type,
            void* pixels) => p_glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels);

        /// <summary>
        /// The gltexsubimage3d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTexSubImage3D_t(
            TextureTarget target,
            int level,
            int xoffset,
            int yoffset,
            int zoffset,
            uint width,
            uint height,
            uint depth,
            GLPixelFormat format,
            GLPixelType type,
            void* pixels);
        /// <summary>
        /// The gltexsubimage3d
        /// </summary>
        private static glTexSubImage3D_t p_glTexSubImage3D;
        /// <summary>
        /// Gls the tex sub image 3 d using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="level">The level</param>
        /// <param name="xoffset">The xoffset</param>
        /// <param name="yoffset">The yoffset</param>
        /// <param name="zoffset">The zoffset</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="format">The format</param>
        /// <param name="type">The type</param>
        /// <param name="pixels">The pixels</param>
        public static void glTexSubImage3D(
            TextureTarget target,
            int level,
            int xoffset,
            int yoffset,
            int zoffset,
            uint width,
            uint height,
            uint depth,
            GLPixelFormat format,
            GLPixelType type,
            void* pixels)
            => p_glTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);

        /// <summary>
        /// The glshadersource
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glShaderSource_t(uint shader, uint count, byte** @string, int* length);
        /// <summary>
        /// The glshadersource
        /// </summary>
        private static glShaderSource_t p_glShaderSource;
        /// <summary>
        /// Gls the shader source using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="count">The count</param>
        /// <param name="@string">The string</param>
        /// <param name="length">The length</param>
        public static void glShaderSource(uint shader, uint count, byte** @string, int* length)
            => p_glShaderSource(shader, count, @string, length);

        /// <summary>
        /// The glcreateshader
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate uint glCreateShader_t(ShaderType shaderType);
        /// <summary>
        /// The glcreateshader
        /// </summary>
        private static glCreateShader_t p_glCreateShader;
        /// <summary>
        /// Gls the create shader using the specified shader type
        /// </summary>
        /// <param name="shaderType">The shader type</param>
        /// <returns>The uint</returns>
        public static uint glCreateShader(ShaderType shaderType) => p_glCreateShader(shaderType);

        /// <summary>
        /// The glcompileshader
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glCompileShader_t(uint shader);
        /// <summary>
        /// The glcompileshader
        /// </summary>
        private static glCompileShader_t p_glCompileShader;
        /// <summary>
        /// Gls the compile shader using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        public static void glCompileShader(uint shader) => p_glCompileShader(shader);

        /// <summary>
        /// The glgetshaderiv
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGetShaderiv_t(uint shader, ShaderParameter pname, int* @params);
        /// <summary>
        /// The glgetshaderiv
        /// </summary>
        private static glGetShaderiv_t p_glGetShaderiv;
        /// <summary>
        /// Gls the get shaderiv using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="pname">The pname</param>
        /// <param name="@params">The params</param>
        public static void glGetShaderiv(uint shader, ShaderParameter pname, int* @params)
            => p_glGetShaderiv(shader, pname, @params);

        /// <summary>
        /// The glgetshaderinfolog
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGetShaderInfoLog_t(uint shader, uint maxLength, uint* length, byte* infoLog);
        /// <summary>
        /// The glgetshaderinfolog
        /// </summary>
        private static glGetShaderInfoLog_t p_glGetShaderInfoLog;
        /// <summary>
        /// Gls the get shader info log using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="length">The length</param>
        /// <param name="infoLog">The info log</param>
        public static void glGetShaderInfoLog(uint shader, uint maxLength, uint* length, byte* infoLog)
            => p_glGetShaderInfoLog(shader, maxLength, length, infoLog);

        /// <summary>
        /// The gldeleteshader
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDeleteShader_t(uint shader);
        /// <summary>
        /// The gldeleteshader
        /// </summary>
        private static glDeleteShader_t p_glDeleteShader;
        /// <summary>
        /// Gls the delete shader using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        public static void glDeleteShader(uint shader) => p_glDeleteShader(shader);

        /// <summary>
        /// The glgensamplers
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGenSamplers_t(uint n, out uint samplers);
        /// <summary>
        /// The glgensamplers
        /// </summary>
        private static glGenSamplers_t p_glGenSamplers;
        /// <summary>
        /// Gls the gen samplers using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="samplers">The samplers</param>
        public static void glGenSamplers(uint n, out uint samplers) => p_glGenSamplers(n, out samplers);

        /// <summary>
        /// The glsamplerparameterf
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glSamplerParameterf_t(uint sampler, SamplerParameterName pname, float param);
        /// <summary>
        /// The glsamplerparameterf
        /// </summary>
        private static glSamplerParameterf_t p_glSamplerParameterf;
        /// <summary>
        /// Gls the sampler parameterf using the specified sampler
        /// </summary>
        /// <param name="sampler">The sampler</param>
        /// <param name="pname">The pname</param>
        /// <param name="param">The param</param>
        public static void glSamplerParameterf(uint sampler, SamplerParameterName pname, float param)
            => p_glSamplerParameterf(sampler, pname, param);

        /// <summary>
        /// The glsamplerparameteri
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glSamplerParameteri_t(uint sampler, SamplerParameterName pname, int param);
        /// <summary>
        /// The glsamplerparameteri
        /// </summary>
        private static glSamplerParameteri_t p_glSamplerParameteri;
        /// <summary>
        /// Gls the sampler parameteri using the specified sampler
        /// </summary>
        /// <param name="sampler">The sampler</param>
        /// <param name="pname">The pname</param>
        /// <param name="param">The param</param>
        public static void glSamplerParameteri(uint sampler, SamplerParameterName pname, int param)
            => p_glSamplerParameteri(sampler, pname, param);

        /// <summary>
        /// The glsamplerparameterfv
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glSamplerParameterfv_t(uint sampler, SamplerParameterName pname, float* @params);
        /// <summary>
        /// The glsamplerparameterfv
        /// </summary>
        private static glSamplerParameterfv_t p_glSamplerParameterfv;
        /// <summary>
        /// Gls the sampler parameterfv using the specified sampler
        /// </summary>
        /// <param name="sampler">The sampler</param>
        /// <param name="pname">The pname</param>
        /// <param name="@params">The params</param>
        public static void glSamplerParameterfv(uint sampler, SamplerParameterName pname, float* @params)
            => p_glSamplerParameterfv(sampler, pname, @params);

        /// <summary>
        /// The glbindsampler
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBindSampler_t(uint unit, uint sampler);
        /// <summary>
        /// The glbindsampler
        /// </summary>
        private static glBindSampler_t p_glBindSampler;
        /// <summary>
        /// Gls the bind sampler using the specified unit
        /// </summary>
        /// <param name="unit">The unit</param>
        /// <param name="sampler">The sampler</param>
        public static void glBindSampler(uint unit, uint sampler) => p_glBindSampler(unit, sampler);

        /// <summary>
        /// The gldeletesamplers
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDeleteSamplers_t(uint n, ref uint samplers);
        /// <summary>
        /// The gldeletesamplers
        /// </summary>
        private static glDeleteSamplers_t p_glDeleteSamplers;
        /// <summary>
        /// Gls the delete samplers using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="samplers">The samplers</param>
        public static void glDeleteSamplers(uint n, ref uint samplers) => p_glDeleteSamplers(n, ref samplers);

        /// <summary>
        /// The glcolormask
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glColorMask_t(
            GLboolean red,
            GLboolean green,
            GLboolean blue,
            GLboolean alpha);
        /// <summary>
        /// The glcolormask
        /// </summary>
        private static glColorMask_t p_glColorMask;
        /// <summary>
        /// Gls the color mask using the specified red
        /// </summary>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <param name="alpha">The alpha</param>
        public static void glColorMask(
            GLboolean red,
            GLboolean green,
            GLboolean blue,
            GLboolean alpha) => p_glColorMask(red, green, blue, alpha);

        /// <summary>
        /// The glcolormaski
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glColorMaski_t(
            uint buf,
            GLboolean red,
            GLboolean green,
            GLboolean blue,
            GLboolean alpha);
        /// <summary>
        /// The glcolormaski
        /// </summary>
        private static glColorMaski_t p_glColorMaski;
        /// <summary>
        /// Gls the color maski using the specified buf
        /// </summary>
        /// <param name="buf">The buf</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <param name="alpha">The alpha</param>
        public static void glColorMaski(
            uint buf,
            GLboolean red,
            GLboolean green,
            GLboolean blue,
            GLboolean alpha) => p_glColorMaski(buf, red, green, blue, alpha);

        /// <summary>
        /// The glblendfuncseparatei
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBlendFuncSeparatei_t(
            uint buf,
            BlendingFactorSrc srcRGB,
            BlendingFactorDest dstRGB,
            BlendingFactorSrc srcAlpha,
            BlendingFactorDest dstAlpha);
        /// <summary>
        /// The glblendfuncseparatei
        /// </summary>
        private static glBlendFuncSeparatei_t p_glBlendFuncSeparatei;
        /// <summary>
        /// Gls the blend func separatei using the specified buf
        /// </summary>
        /// <param name="buf">The buf</param>
        /// <param name="srcRGB">The src rgb</param>
        /// <param name="dstRGB">The dst rgb</param>
        /// <param name="srcAlpha">The src alpha</param>
        /// <param name="dstAlpha">The dst alpha</param>
        public static void glBlendFuncSeparatei(
            uint buf,
            BlendingFactorSrc srcRGB,
            BlendingFactorDest dstRGB,
            BlendingFactorSrc srcAlpha,
            BlendingFactorDest dstAlpha) => p_glBlendFuncSeparatei(buf, srcRGB, dstRGB, srcAlpha, dstAlpha);

        /// <summary>
        /// The glblendfuncseparate
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBlendFuncSeparate_t(
            BlendingFactorSrc srcRGB,
            BlendingFactorDest dstRGB,
            BlendingFactorSrc srcAlpha,
            BlendingFactorDest dstAlpha);
        /// <summary>
        /// The glblendfuncseparate
        /// </summary>
        private static glBlendFuncSeparate_t p_glBlendFuncSeparate;
        /// <summary>
        /// Gls the blend func separate using the specified src rgb
        /// </summary>
        /// <param name="srcRGB">The src rgb</param>
        /// <param name="dstRGB">The dst rgb</param>
        /// <param name="srcAlpha">The src alpha</param>
        /// <param name="dstAlpha">The dst alpha</param>
        public static void glBlendFuncSeparate(
            BlendingFactorSrc srcRGB,
            BlendingFactorDest dstRGB,
            BlendingFactorSrc srcAlpha,
            BlendingFactorDest dstAlpha) => p_glBlendFuncSeparate(srcRGB, dstRGB, srcAlpha, dstAlpha);

        /// <summary>
        /// The glenable
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glEnable_t(EnableCap cap);
        /// <summary>
        /// The glenable
        /// </summary>
        private static glEnable_t p_glEnable;
        /// <summary>
        /// Gls the enable using the specified cap
        /// </summary>
        /// <param name="cap">The cap</param>
        public static void glEnable(EnableCap cap) => p_glEnable(cap);

        /// <summary>
        /// The glenablei
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glEnablei_t(EnableCap cap, uint index);
        /// <summary>
        /// The glenablei
        /// </summary>
        private static glEnablei_t p_glEnablei;
        /// <summary>
        /// Gls the enablei using the specified cap
        /// </summary>
        /// <param name="cap">The cap</param>
        /// <param name="index">The index</param>
        public static void glEnablei(EnableCap cap, uint index) => p_glEnablei(cap, index);

        /// <summary>
        /// The gldisable
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDisable_t(EnableCap cap);
        /// <summary>
        /// The gldisable
        /// </summary>
        private static glDisable_t p_glDisable;
        /// <summary>
        /// Gls the disable using the specified cap
        /// </summary>
        /// <param name="cap">The cap</param>
        public static void glDisable(EnableCap cap) => p_glDisable(cap);

        /// <summary>
        /// The gldisablei
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDisablei_t(EnableCap cap, uint index);
        /// <summary>
        /// The gldisablei
        /// </summary>
        private static glDisablei_t p_glDisablei;
        /// <summary>
        /// Gls the disablei using the specified cap
        /// </summary>
        /// <param name="cap">The cap</param>
        /// <param name="index">The index</param>
        public static void glDisablei(EnableCap cap, uint index) => p_glDisablei(cap, index);

        /// <summary>
        /// The glblendequationseparatei
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBlendEquationSeparatei_t(uint buf, BlendEquationMode modeRGB, BlendEquationMode modeAlpha);
        /// <summary>
        /// The glblendequationseparatei
        /// </summary>
        private static glBlendEquationSeparatei_t p_glBlendEquationSeparatei;
        /// <summary>
        /// Gls the blend equation separatei using the specified buf
        /// </summary>
        /// <param name="buf">The buf</param>
        /// <param name="modeRGB">The mode rgb</param>
        /// <param name="modeAlpha">The mode alpha</param>
        public static void glBlendEquationSeparatei(uint buf, BlendEquationMode modeRGB, BlendEquationMode modeAlpha)
            => p_glBlendEquationSeparatei(buf, modeRGB, modeAlpha);

        /// <summary>
        /// The glblendequationseparate
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBlendEquationSeparate_t(BlendEquationMode modeRGB, BlendEquationMode modeAlpha);
        /// <summary>
        /// The glblendequationseparate
        /// </summary>
        private static glBlendEquationSeparate_t p_glBlendEquationSeparate;
        /// <summary>
        /// Gls the blend equation separate using the specified mode rgb
        /// </summary>
        /// <param name="modeRGB">The mode rgb</param>
        /// <param name="modeAlpha">The mode alpha</param>
        public static void glBlendEquationSeparate(BlendEquationMode modeRGB, BlendEquationMode modeAlpha)
            => p_glBlendEquationSeparate(modeRGB, modeAlpha);

        /// <summary>
        /// The glblendcolor
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBlendColor_t(float red, float green, float blue, float alpha);
        /// <summary>
        /// The glblendcolor
        /// </summary>
        private static glBlendColor_t p_glBlendColor;
        /// <summary>
        /// Gls the blend color using the specified red
        /// </summary>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <param name="alpha">The alpha</param>
        public static void glBlendColor(float red, float green, float blue, float alpha)
            => p_glBlendColor(red, green, blue, alpha);

        /// <summary>
        /// The gldepthfunc
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDepthFunc_t(DepthFunction func);
        /// <summary>
        /// The gldepthfunc
        /// </summary>
        private static glDepthFunc_t p_glDepthFunc;
        /// <summary>
        /// Gls the depth func using the specified func
        /// </summary>
        /// <param name="func">The func</param>
        public static void glDepthFunc(DepthFunction func) => p_glDepthFunc(func);

        /// <summary>
        /// The gldepthmask
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDepthMask_t(GLboolean flag);
        /// <summary>
        /// The gldepthmask
        /// </summary>
        private static glDepthMask_t p_glDepthMask;
        /// <summary>
        /// Gls the depth mask using the specified flag
        /// </summary>
        /// <param name="flag">The flag</param>
        public static void glDepthMask(GLboolean flag) => p_glDepthMask(flag);

        /// <summary>
        /// The glcullface
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glCullFace_t(CullFaceMode mode);
        /// <summary>
        /// The glcullface
        /// </summary>
        private static glCullFace_t p_glCullFace;
        /// <summary>
        /// Gls the cull face using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        public static void glCullFace(CullFaceMode mode) => p_glCullFace(mode);

        /// <summary>
        /// The glpolygonmode
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glPolygonMode_t(MaterialFace face, PolygonMode mode);
        /// <summary>
        /// The glpolygonmode
        /// </summary>
        private static glPolygonMode_t p_glPolygonMode;
        /// <summary>
        /// Gls the polygon mode using the specified face
        /// </summary>
        /// <param name="face">The face</param>
        /// <param name="mode">The mode</param>
        public static void glPolygonMode(MaterialFace face, PolygonMode mode) => p_glPolygonMode(face, mode);

        /// <summary>
        /// The glcreateprogram
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate uint glCreateProgram_t();
        /// <summary>
        /// The glcreateprogram
        /// </summary>
        private static glCreateProgram_t p_glCreateProgram;
        /// <summary>
        /// Gls the create program
        /// </summary>
        /// <returns>The uint</returns>
        public static uint glCreateProgram() => p_glCreateProgram();

        /// <summary>
        /// The glattachshader
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glAttachShader_t(uint program, uint shader);
        /// <summary>
        /// The glattachshader
        /// </summary>
        private static glAttachShader_t p_glAttachShader;
        /// <summary>
        /// Gls the attach shader using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="shader">The shader</param>
        public static void glAttachShader(uint program, uint shader) => p_glAttachShader(program, shader);

        /// <summary>
        /// The glbindattriblocation
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBindAttribLocation_t(uint program, uint index, byte* name);
        /// <summary>
        /// The glbindattriblocation
        /// </summary>
        private static glBindAttribLocation_t p_glBindAttribLocation;
        /// <summary>
        /// Gls the bind attrib location using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="index">The index</param>
        /// <param name="name">The name</param>
        public static void glBindAttribLocation(uint program, uint index, byte* name)
            => p_glBindAttribLocation(program, index, name);

        /// <summary>
        /// The gllinkprogram
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glLinkProgram_t(uint program);
        /// <summary>
        /// The gllinkprogram
        /// </summary>
        private static glLinkProgram_t p_glLinkProgram;
        /// <summary>
        /// Gls the link program using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        public static void glLinkProgram(uint program) => p_glLinkProgram(program);

        /// <summary>
        /// The glgetprogramiv
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGetProgramiv_t(uint program, GetProgramParameterName pname, int* @params);
        /// <summary>
        /// The glgetprogramiv
        /// </summary>
        private static glGetProgramiv_t p_glGetProgramiv;
        /// <summary>
        /// Gls the get programiv using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="pname">The pname</param>
        /// <param name="@params">The params</param>
        public static void glGetProgramiv(uint program, GetProgramParameterName pname, int* @params)
            => p_glGetProgramiv(program, pname, @params);

        /// <summary>
        /// The glgetprograminfolog
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGetProgramInfoLog_t(uint program, uint maxLength, uint* length, byte* infoLog);
        /// <summary>
        /// The glgetprograminfolog
        /// </summary>
        private static glGetProgramInfoLog_t p_glGetProgramInfoLog;
        /// <summary>
        /// Gls the get program info log using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="maxLength">The max length</param>
        /// <param name="length">The length</param>
        /// <param name="infoLog">The info log</param>
        public static void glGetProgramInfoLog(uint program, uint maxLength, uint* length, byte* infoLog)
            => p_glGetProgramInfoLog(program, maxLength, length, infoLog);

        /// <summary>
        /// The gluniformblockbinding
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glUniformBlockBinding_t(uint program, uint uniformBlockIndex, uint uniformBlockBinding);
        /// <summary>
        /// The gluniformblockbinding
        /// </summary>
        private static glUniformBlockBinding_t p_glUniformBlockBinding;
        /// <summary>
        /// Gls the uniform block binding using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="uniformBlockIndex">The uniform block index</param>
        /// <param name="uniformBlockBinding">The uniform block binding</param>
        public static void glUniformBlockBinding(uint program, uint uniformBlockIndex, uint uniformBlockBinding)
            => p_glUniformBlockBinding(program, uniformBlockIndex, uniformBlockBinding);

        /// <summary>
        /// The gldeleteprogram
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDeleteProgram_t(uint program);
        /// <summary>
        /// The gldeleteprogram
        /// </summary>
        private static glDeleteProgram_t p_glDeleteProgram;
        /// <summary>
        /// Gls the delete program using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        public static void glDeleteProgram(uint program) => p_glDeleteProgram(program);

        /// <summary>
        /// The gluniform1i
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glUniform1i_t(int location, int v0);
        /// <summary>
        /// The gluniform1i
        /// </summary>
        private static glUniform1i_t p_glUniform1i;
        /// <summary>
        /// Gls the uniform 1i using the specified location
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="v0">The </param>
        public static void glUniform1i(int location, int v0) => p_glUniform1i(location, v0);

        /// <summary>
        /// The glgetuniformblockindex
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate uint glGetUniformBlockIndex_t(uint program, byte* uniformBlockName);
        /// <summary>
        /// The glgetuniformblockindex
        /// </summary>
        private static glGetUniformBlockIndex_t p_glGetUniformBlockIndex;
        /// <summary>
        /// Gls the get uniform block index using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="uniformBlockName">The uniform block name</param>
        /// <returns>The uint</returns>
        public static uint glGetUniformBlockIndex(uint program, byte* uniformBlockName)
            => p_glGetUniformBlockIndex(program, uniformBlockName);

        /// <summary>
        /// The glgetuniformlocation
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate int glGetUniformLocation_t(uint program, byte* name);
        /// <summary>
        /// The glgetuniformlocation
        /// </summary>
        private static glGetUniformLocation_t p_glGetUniformLocation;
        /// <summary>
        /// Gls the get uniform location using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="name">The name</param>
        /// <returns>The int</returns>
        public static int glGetUniformLocation(uint program, byte* name) => p_glGetUniformLocation(program, name);

        /// <summary>
        /// The glgetattriblocation
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate int glGetAttribLocation_t(uint program, byte* name);
        /// <summary>
        /// The glgetattriblocation
        /// </summary>
        private static glGetAttribLocation_t p_glGetAttribLocation;
        /// <summary>
        /// Gls the get attrib location using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="name">The name</param>
        /// <returns>The int</returns>
        public static int glGetAttribLocation(uint program, byte* name) => p_glGetAttribLocation(program, name);

        /// <summary>
        /// The gluseprogram
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glUseProgram_t(uint program);
        /// <summary>
        /// The gluseprogram
        /// </summary>
        private static glUseProgram_t p_glUseProgram;
        /// <summary>
        /// Gls the use program using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        public static void glUseProgram(uint program) => p_glUseProgram(program);

        /// <summary>
        /// The glbindbufferrange
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBindBufferRange_t(
            BufferRangeTarget target,
            uint index,
            uint buffer,
            IntPtr offset,
            UIntPtr size);
        /// <summary>
        /// The glbindbufferrange
        /// </summary>
        private static glBindBufferRange_t p_glBindBufferRange;
        /// <summary>
        /// Gls the bind buffer range using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="index">The index</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="size">The size</param>
        public static void glBindBufferRange(
            BufferRangeTarget target,
            uint index,
            uint buffer,
            IntPtr offset,
            UIntPtr size) => p_glBindBufferRange(target, index, buffer, offset, size);

        /// <summary>
        /// The debug proc
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        public delegate void DebugProc(
            DebugSource source,
            DebugType type,
            uint id,
            DebugSeverity severity,
            uint length,
            byte* message,
            void* userParam);

        /// <summary>
        /// The gldebugmessagecallback
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDebugMessageCallback_t(DebugProc callback, void* userParam);
        /// <summary>
        /// The gldebugmessagecallback
        /// </summary>
        private static glDebugMessageCallback_t p_glDebugMessageCallback;
        /// <summary>
        /// Gls the debug message callback using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userParam">The user param</param>
        public static void glDebugMessageCallback(DebugProc callback, void* userParam)
            => p_glDebugMessageCallback(callback, userParam);

        /// <summary>
        /// The glbufferdata
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBufferData_t(BufferTarget target, UIntPtr size, void* data, BufferUsageHint usage);
        /// <summary>
        /// The glbufferdata
        /// </summary>
        private static glBufferData_t p_glBufferData;
        /// <summary>
        /// Gls the buffer data using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="size">The size</param>
        /// <param name="data">The data</param>
        /// <param name="usage">The usage</param>
        public static void glBufferData(BufferTarget target, UIntPtr size, void* data, BufferUsageHint usage)
            => p_glBufferData(target, size, data, usage);

        /// <summary>
        /// The glnamedbufferdata
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glNamedBufferData_t(uint buffer, uint size, void* data, BufferUsageHint usage);
        /// <summary>
        /// The glnamedbufferdata
        /// </summary>
        private static glNamedBufferData_t p_glNamedBufferData;
        /// <summary>
        /// Gls the named buffer data using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="size">The size</param>
        /// <param name="data">The data</param>
        /// <param name="usage">The usage</param>
        public static void glNamedBufferData(uint buffer, uint size, void* data, BufferUsageHint usage)
            => p_glNamedBufferData(buffer, size, data, usage);

        /// <summary>
        /// The glteximage1d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTexImage1D_t(
            TextureTarget target,
            int level,
            PixelInternalFormat internalFormat,
            uint width,
            int border,
            GLPixelFormat format,
            GLPixelType type,
            void* data);
        /// <summary>
        /// The glteximage1d
        /// </summary>
        private static glTexImage1D_t p_glTexImage1D;
        /// <summary>
        /// Gls the tex image 1 d using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="level">The level</param>
        /// <param name="internalFormat">The internal format</param>
        /// <param name="width">The width</param>
        /// <param name="border">The border</param>
        /// <param name="format">The format</param>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        public static void glTexImage1D(
            TextureTarget target,
            int level,
            PixelInternalFormat internalFormat,
            uint width,
            int border,
            GLPixelFormat format,
            GLPixelType type,
            void* data) => p_glTexImage1D(target, level, internalFormat, width, border, format, type, data);

        /// <summary>
        /// The glteximage2d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTexImage2D_t(
            TextureTarget target,
            int level,
            PixelInternalFormat internalFormat,
            uint width,
            uint height,
            int border,
            GLPixelFormat format,
            GLPixelType type,
            void* data);
        /// <summary>
        /// The glteximage2d
        /// </summary>
        private static glTexImage2D_t p_glTexImage2D;
        /// <summary>
        /// Gls the tex image 2 d using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="level">The level</param>
        /// <param name="internalFormat">The internal format</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="border">The border</param>
        /// <param name="format">The format</param>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        public static void glTexImage2D(
            TextureTarget target,
            int level,
            PixelInternalFormat internalFormat,
            uint width,
            uint height,
            int border,
            GLPixelFormat format,
            GLPixelType type,
            void* data) => p_glTexImage2D(target, level, internalFormat, width, height, border, format, type, data);

        /// <summary>
        /// The glteximage3d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTexImage3D_t(
            TextureTarget target,
            int level,
            PixelInternalFormat internalFormat,
            uint width,
            uint height,
            uint depth,
            int border,
            GLPixelFormat format,
            GLPixelType type,
            void* data);
        /// <summary>
        /// The glteximage3d
        /// </summary>
        private static glTexImage3D_t p_glTexImage3D;
        /// <summary>
        /// Gls the tex image 3 d using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="level">The level</param>
        /// <param name="internalFormat">The internal format</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="border">The border</param>
        /// <param name="format">The format</param>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        public static void glTexImage3D(
            TextureTarget target,
            int level,
            PixelInternalFormat internalFormat,
            uint width,
            uint height,
            uint depth,
            int border,
            GLPixelFormat format,
            GLPixelType type,
            void* data) => p_glTexImage3D(target, level, internalFormat, width, height, depth, border, format, type, data);

        /// <summary>
        /// The glenablevertexattribarray
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glEnableVertexAttribArray_t(uint index);
        /// <summary>
        /// The glenablevertexattribarray
        /// </summary>
        private static glEnableVertexAttribArray_t p_glEnableVertexAttribArray;
        /// <summary>
        /// Gls the enable vertex attrib array using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        public static void glEnableVertexAttribArray(uint index) => p_glEnableVertexAttribArray(index);

        /// <summary>
        /// The gldisablevertexattribarray
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDisableVertexAttribArray_t(uint index);
        /// <summary>
        /// The gldisablevertexattribarray
        /// </summary>
        private static glDisableVertexAttribArray_t p_glDisableVertexAttribArray;
        /// <summary>
        /// Gls the disable vertex attrib array using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        public static void glDisableVertexAttribArray(uint index) => p_glDisableVertexAttribArray(index);

        /// <summary>
        /// The glvertexattribpointer
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glVertexAttribPointer_t(
            uint index,
            int size,
            VertexAttribPointerType type,
            GLboolean normalized,
            uint stride,
            void* pointer);
        /// <summary>
        /// The glvertexattribpointer
        /// </summary>
        private static glVertexAttribPointer_t p_glVertexAttribPointer;
        /// <summary>
        /// Gls the vertex attrib pointer using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="size">The size</param>
        /// <param name="type">The type</param>
        /// <param name="normalized">The normalized</param>
        /// <param name="stride">The stride</param>
        /// <param name="pointer">The pointer</param>
        public static void glVertexAttribPointer(
            uint index,
            int size,
            VertexAttribPointerType type,
            GLboolean normalized,
            uint stride,
            void* pointer) => p_glVertexAttribPointer(index, size, type, normalized, stride, pointer);

        /// <summary>
        /// The glvertexattribipointer
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glVertexAttribIPointer_t(
            uint index,
            int size,
            VertexAttribPointerType type,
            uint stride,
            void* pointer);
        /// <summary>
        /// The glvertexattribipointer
        /// </summary>
        private static glVertexAttribIPointer_t p_glVertexAttribIPointer;
        /// <summary>
        /// Gls the vertex attrib i pointer using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="size">The size</param>
        /// <param name="type">The type</param>
        /// <param name="stride">The stride</param>
        /// <param name="pointer">The pointer</param>
        public static void glVertexAttribIPointer(
            uint index,
            int size,
            VertexAttribPointerType type,
            uint stride,
            void* pointer) => p_glVertexAttribIPointer(index, size, type, stride, pointer);

        /// <summary>
        /// The glvertexattribdivisor
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glVertexAttribDivisor_t(uint index, uint divisor);
        /// <summary>
        /// The glvertexattribdivisor
        /// </summary>
        private static glVertexAttribDivisor_t p_glVertexAttribDivisor;
        /// <summary>
        /// Gls the vertex attrib divisor using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="divisor">The divisor</param>
        public static void glVertexAttribDivisor(uint index, uint divisor) => p_glVertexAttribDivisor(index, divisor);

        /// <summary>
        /// The glfrontface
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glFrontFace_t(FrontFaceDirection mode);
        /// <summary>
        /// The glfrontface
        /// </summary>
        private static glFrontFace_t p_glFrontFace;
        /// <summary>
        /// Gls the front face using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        public static void glFrontFace(FrontFaceDirection mode) => p_glFrontFace(mode);

        /// <summary>
        /// The glgetintegerv
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGetIntegerv_t(GetPName pname, int* data);
        /// <summary>
        /// The glgetintegerv
        /// </summary>
        private static glGetIntegerv_t p_glGetIntegerv;
        /// <summary>
        /// Gls the get integerv using the specified pname
        /// </summary>
        /// <param name="pname">The pname</param>
        /// <param name="data">The data</param>
        public static void glGetIntegerv(GetPName pname, int* data) => p_glGetIntegerv(pname, data);

        /// <summary>
        /// The glbindtextureunit
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBindTextureUnit_t(uint unit, uint texture);
        /// <summary>
        /// The glbindtextureunit
        /// </summary>
        private static glBindTextureUnit_t p_glBindTextureUnit;
        /// <summary>
        /// Gls the bind texture unit using the specified unit
        /// </summary>
        /// <param name="unit">The unit</param>
        /// <param name="texture">The texture</param>
        public static void glBindTextureUnit(uint unit, uint texture) => p_glBindTextureUnit(unit, texture);

        /// <summary>
        /// The gltexparameteri
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTexParameteri_t(TextureTarget target, TextureParameterName pname, int param);
        /// <summary>
        /// The gltexparameteri
        /// </summary>
        private static glTexParameteri_t p_glTexParameteri;
        /// <summary>
        /// Gls the tex parameteri using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="pname">The pname</param>
        /// <param name="param">The param</param>
        public static void glTexParameteri(TextureTarget target, TextureParameterName pname, int param)
            => p_glTexParameteri(target, pname, param);

        /// <summary>
        /// The glgetstring
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate byte* glGetString_t(StringName name);
        /// <summary>
        /// The glgetstring
        /// </summary>
        private static glGetString_t p_glGetString;
        /// <summary>
        /// Gls the get string using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The byte</returns>
        public static byte* glGetString(StringName name) => p_glGetString(name);

        /// <summary>
        /// The glgetstringi
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate byte* glGetStringi_t(StringNameIndexed name, uint index);
        /// <summary>
        /// The glgetstringi
        /// </summary>
        private static glGetStringi_t p_glGetStringi;
        /// <summary>
        /// Gls the get stringi using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="index">The index</param>
        /// <returns>The byte</returns>
        public static byte* glGetStringi(StringNameIndexed name, uint index) => p_glGetStringi(name, index);

        /// <summary>
        /// The globjectlabel
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glObjectLabel_t(ObjectLabelIdentifier identifier, uint name, uint length, byte* label);
        /// <summary>
        /// The globjectlabel
        /// </summary>
        private static glObjectLabel_t p_glObjectLabel;
        /// <summary>
        /// Gls the object label using the specified identifier
        /// </summary>
        /// <param name="identifier">The identifier</param>
        /// <param name="name">The name</param>
        /// <param name="length">The length</param>
        /// <param name="label">The label</param>
        public static void glObjectLabel(ObjectLabelIdentifier identifier, uint name, uint length, byte* label)
            => p_glObjectLabel(identifier, name, length, label);

        /// <summary>
        /// Indicates whether the glObjectLabel function was successfully loaded.
        /// Some drivers advertise KHR_Debug support, but return null for this function pointer.
        /// </summary>
        public static bool HasGlObjectLabel => p_glObjectLabel != null;

        /// <summary>
        /// The glteximage2dmultisample
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTexImage2DMultisample_t(
            TextureTarget target,
            uint samples,
            PixelInternalFormat internalformat,
            uint width,
            uint height,
            GLboolean fixedsamplelocations);
        /// <summary>
        /// The glteximage2dmultisample
        /// </summary>
        private static glTexImage2DMultisample_t p_glTexImage2DMultisample;
        /// <summary>
        /// Gls the tex image 2 d multi sample using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="samples">The samples</param>
        /// <param name="internalformat">The internalformat</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="fixedsamplelocations">The fixedsamplelocations</param>
        public static void glTexImage2DMultiSample(
            TextureTarget target,
            uint samples,
            PixelInternalFormat internalformat,
            uint width,
            uint height,
            GLboolean fixedsamplelocations) => p_glTexImage2DMultisample(
                target,
                samples,
                internalformat,
                width,
                height,
                fixedsamplelocations);

        /// <summary>
        /// The glteximage3dmultisample
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTexImage3DMultisample_t(
            TextureTarget target,
            uint samples,
            PixelInternalFormat internalformat,
            uint width,
            uint height,
            uint depth,
            GLboolean fixedsamplelocations);
        /// <summary>
        /// The glteximage3dmultisample
        /// </summary>
        private static glTexImage3DMultisample_t p_glTexImage3DMultisample;
        /// <summary>
        /// Gls the tex image 3 d multisample using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="samples">The samples</param>
        /// <param name="internalformat">The internalformat</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="fixedsamplelocations">The fixedsamplelocations</param>
        public static void glTexImage3DMultisample(
            TextureTarget target,
            uint samples,
            PixelInternalFormat internalformat,
            uint width,
            uint height,
            uint depth,
            GLboolean fixedsamplelocations) => p_glTexImage3DMultisample(
                target,
                samples,
                internalformat,
                width,
                height,
                depth,
                fixedsamplelocations);

        /// <summary>
        /// The glblitframebuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBlitFramebuffer_t(
            int srcX0,
            int srcY0,
            int srcX1,
            int srcY1,
            int dstX0,
            int dstY0,
            int dstX1,
            int dstY1,
            ClearBufferMask mask,
            BlitFramebufferFilter filter);
        /// <summary>
        /// The glblitframebuffer
        /// </summary>
        private static glBlitFramebuffer_t p_glBlitFramebuffer;
        /// <summary>
        /// Gls the blit framebuffer using the specified src x 0
        /// </summary>
        /// <param name="srcX0">The src</param>
        /// <param name="srcY0">The src</param>
        /// <param name="srcX1">The src</param>
        /// <param name="srcY1">The src</param>
        /// <param name="dstX0">The dst</param>
        /// <param name="dstY0">The dst</param>
        /// <param name="dstX1">The dst</param>
        /// <param name="dstY1">The dst</param>
        /// <param name="mask">The mask</param>
        /// <param name="filter">The filter</param>
        public static void glBlitFramebuffer(
            int srcX0,
            int srcY0,
            int srcX1,
            int srcY1,
            int dstX0,
            int dstY0,
            int dstX1,
            int dstY1,
            ClearBufferMask mask,
            BlitFramebufferFilter filter)
            => p_glBlitFramebuffer(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);

        /// <summary>
        /// The glframebuffertexturelayer
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glFramebufferTextureLayer_t(
            FramebufferTarget target,
            GLFramebufferAttachment attachment,
            uint texture,
            int level,
            int layer);
        /// <summary>
        /// The glframebuffertexturelayer
        /// </summary>
        private static glFramebufferTextureLayer_t p_glFramebufferTextureLayer;
        /// <summary>
        /// Gls the framebuffer texture layer using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="attachment">The attachment</param>
        /// <param name="texture">The texture</param>
        /// <param name="level">The level</param>
        /// <param name="layer">The layer</param>
        public static void glFramebufferTextureLayer(
            FramebufferTarget target,
            GLFramebufferAttachment attachment,
            uint texture,
            int level,
            int layer) => p_glFramebufferTextureLayer(target, attachment, texture, level, layer);

        /// <summary>
        /// The gldispatchcompute
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDispatchCompute_t(uint num_groups_x, uint num_groups_y, uint num_groups_z);
        /// <summary>
        /// The gldispatchcompute
        /// </summary>
        private static glDispatchCompute_t p_glDispatchCompute;
        /// <summary>
        /// Gls the dispatch compute using the specified num groups x
        /// </summary>
        /// <param name="num_groups_x">The num groups</param>
        /// <param name="num_groups_y">The num groups</param>
        /// <param name="num_groups_z">The num groups</param>
        public static void glDispatchCompute(uint num_groups_x, uint num_groups_y, uint num_groups_z)
            => p_glDispatchCompute(num_groups_x, num_groups_y, num_groups_z);

        /// <summary>
        /// The glgetprograminterfaceiv
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate uint glGetProgramInterfaceiv_t(uint program, ProgramInterface programInterface, ProgramInterfaceParameterName pname, int* @params);
        /// <summary>
        /// The glgetprograminterfaceiv
        /// </summary>
        private static glGetProgramInterfaceiv_t p_glGetProgramInterfaceiv;
        /// <summary>
        /// Gls the get program interfaceiv using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="programInterface">The program interface</param>
        /// <param name="pname">The pname</param>
        /// <param name="@params">The params</param>
        /// <returns>The uint</returns>
        public static uint glGetProgramInterfaceiv(uint program, ProgramInterface programInterface, ProgramInterfaceParameterName pname, int* @params)
            => p_glGetProgramInterfaceiv(program, programInterface, pname, @params);

        /// <summary>
        /// The glgetprogramresourceindex
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate uint glGetProgramResourceIndex_t(uint program, ProgramInterface programInterface, byte* name);
        /// <summary>
        /// The glgetprogramresourceindex
        /// </summary>
        private static glGetProgramResourceIndex_t p_glGetProgramResourceIndex;
        /// <summary>
        /// Gls the get program resource index using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="programInterface">The program interface</param>
        /// <param name="name">The name</param>
        /// <returns>The uint</returns>
        public static uint glGetProgramResourceIndex(uint program, ProgramInterface programInterface, byte* name)
            => p_glGetProgramResourceIndex(program, programInterface, name);

        /// <summary>
        /// The glgetprogramresourcename
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate uint glGetProgramResourceName_t(uint program, ProgramInterface programInterface, uint index, uint bufSize, uint* length, byte* name);
        /// <summary>
        /// The glgetprogramresourcename
        /// </summary>
        private static glGetProgramResourceName_t p_glGetProgramResourceName;
        /// <summary>
        /// Gls the get program resource name using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="programInterface">The program interface</param>
        /// <param name="index">The index</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="length">The length</param>
        /// <param name="name">The name</param>
        /// <returns>The uint</returns>
        public static uint glGetProgramResourceName(uint program, ProgramInterface programInterface, uint index, uint bufSize, uint* length, byte* name)
            => p_glGetProgramResourceName(program, programInterface, index, bufSize, length, name);

        /// <summary>
        /// The glshaderstorageblockbinding
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glShaderStorageBlockBinding_t(uint program, uint storageBlockIndex, uint storageBlockBinding);
        /// <summary>
        /// The glshaderstorageblockbinding
        /// </summary>
        private static glShaderStorageBlockBinding_t p_glShaderStorageBlockBinding;
        /// <summary>
        /// Gls the shader storage block binding using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="storageBlockIndex">The storage block index</param>
        /// <param name="storageBlockBinding">The storage block binding</param>
        public static void glShaderStorageBlockBinding(uint program, uint storageBlockIndex, uint storageBlockBinding)
            => p_glShaderStorageBlockBinding(program, storageBlockIndex, storageBlockBinding);

        /// <summary>
        /// The gldrawelementsindirect
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDrawElementsIndirect_t(PrimitiveType mode, DrawElementsType type, IntPtr indirect);
        /// <summary>
        /// The gldrawelementsindirect
        /// </summary>
        private static glDrawElementsIndirect_t p_glDrawElementsIndirect;
        /// <summary>
        /// Gls the draw elements indirect using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="type">The type</param>
        /// <param name="indirect">The indirect</param>
        public static void glDrawElementsIndirect(PrimitiveType mode, DrawElementsType type, IntPtr indirect)
            => p_glDrawElementsIndirect(mode, type, indirect);

        /// <summary>
        /// The glmultidrawelementsindirect
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glMultiDrawElementsIndirect_t(
            PrimitiveType mode,
            DrawElementsType type,
            IntPtr indirect,
            uint drawcount,
            uint stride);
        /// <summary>
        /// The glmultidrawelementsindirect
        /// </summary>
        private static glMultiDrawElementsIndirect_t p_glMultiDrawElementsIndirect;
        /// <summary>
        /// Gls the multi draw elements indirect using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="type">The type</param>
        /// <param name="indirect">The indirect</param>
        /// <param name="drawcount">The drawcount</param>
        /// <param name="stride">The stride</param>
        public static void glMultiDrawElementsIndirect(
            PrimitiveType mode,
            DrawElementsType type,
            IntPtr indirect,
            uint drawcount,
            uint stride) => p_glMultiDrawElementsIndirect(mode, type, indirect, drawcount, stride);

        /// <summary>
        /// The gldrawarraysindirect
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDrawArraysIndirect_t(PrimitiveType mode, IntPtr indirect);
        /// <summary>
        /// The gldrawarraysindirect
        /// </summary>
        private static glDrawArraysIndirect_t p_glDrawArraysIndirect;
        /// <summary>
        /// Gls the draw arrays indirect using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="indirect">The indirect</param>
        public static void glDrawArraysIndirect(PrimitiveType mode, IntPtr indirect)
            => p_glDrawArraysIndirect(mode, indirect);

        /// <summary>
        /// The glmultidrawarraysindirect
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glMultiDrawArraysIndirect_t(PrimitiveType mode, IntPtr indirect, uint drawcount, uint stride);
        /// <summary>
        /// The glmultidrawarraysindirect
        /// </summary>
        private static glMultiDrawArraysIndirect_t p_glMultiDrawArraysIndirect;
        /// <summary>
        /// Gls the multi draw arrays indirect using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="indirect">The indirect</param>
        /// <param name="drawcount">The drawcount</param>
        /// <param name="stride">The stride</param>
        public static void glMultiDrawArraysIndirect(PrimitiveType mode, IntPtr indirect, uint drawcount, uint stride)
            => p_glMultiDrawArraysIndirect(mode, indirect, drawcount, stride);

        /// <summary>
        /// The gldispatchcomputeindirect
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDispatchComputeIndirect_t(IntPtr indirect);
        /// <summary>
        /// The gldispatchcomputeindirect
        /// </summary>
        private static glDispatchComputeIndirect_t p_glDispatchComputeIndirect;
        /// <summary>
        /// Gls the dispatch compute indirect using the specified indirect
        /// </summary>
        /// <param name="indirect">The indirect</param>
        public static void glDispatchComputeIndirect(IntPtr indirect) => p_glDispatchComputeIndirect(indirect);

        /// <summary>
        /// The glbindimagetexture
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBindImageTexture_t(
            uint unit​,
            uint texture​,
            int level​,
            GLboolean layered​,
            int layer​,
            TextureAccess access​,
            SizedInternalFormat format​);
        /// <summary>
        /// The glbindimagetexture
        /// </summary>
        private static glBindImageTexture_t p_glBindImageTexture;
        /// <summary>
        /// Gls the bind image texture using the specified unit
        /// </summary>
        /// <param name="unit​">The unit</param>
        /// <param name="texture​">The texture</param>
        /// <param name="level​">The level</param>
        /// <param name="layered​">The layered</param>
        /// <param name="layer​">The layer</param>
        /// <param name="access​">The access</param>
        /// <param name="format​">The format</param>
        public static void glBindImageTexture(
            uint unit​,
            uint texture​,
            int level​,
            GLboolean layered​,
            int layer​,
            TextureAccess access​,
            SizedInternalFormat format​) => p_glBindImageTexture(unit, texture, level, layered, layer, access, format);

        /// <summary>
        /// The glmemorybarrier
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glMemoryBarrier_t(MemoryBarrierFlags barriers);
        /// <summary>
        /// The glmemorybarrier
        /// </summary>
        private static glMemoryBarrier_t p_glMemoryBarrier;
        /// <summary>
        /// Gls the memory barrier using the specified barriers
        /// </summary>
        /// <param name="barriers">The barriers</param>
        public static void glMemoryBarrier(MemoryBarrierFlags barriers) => p_glMemoryBarrier(barriers);

        /// <summary>
        /// The gltexstorage1d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTexStorage1D_t(
            TextureTarget target,
            uint levels,
            SizedInternalFormat internalformat,
            uint width);
        /// <summary>
        /// The gltexstorage1d
        /// </summary>
        private static glTexStorage1D_t p_glTexStorage1D;
        /// <summary>
        /// Gls the tex storage 1 d using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="levels">The levels</param>
        /// <param name="internalformat">The internalformat</param>
        /// <param name="width">The width</param>
        public static void glTexStorage1D(TextureTarget target, uint levels, SizedInternalFormat internalformat, uint width)
            => p_glTexStorage1D(target, levels, internalformat, width);

        /// <summary>
        /// The gltexstorage2d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTexStorage2D_t(
            TextureTarget target,
            uint levels,
            SizedInternalFormat internalformat,
            uint width,
            uint height);
        /// <summary>
        /// The gltexstorage2d
        /// </summary>
        private static glTexStorage2D_t p_glTexStorage2D;
        /// <summary>
        /// Gls the tex storage 2 d using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="levels">The levels</param>
        /// <param name="internalformat">The internalformat</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public static void glTexStorage2D(
            TextureTarget target,
            uint levels,
            SizedInternalFormat internalformat,
            uint width,
            uint height) => p_glTexStorage2D(target, levels, internalformat, width, height);

        /// <summary>
        /// The gltexstorage3d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTexStorage3D_t(
            TextureTarget target,
            uint levels,
            SizedInternalFormat internalformat,
            uint width,
            uint height,
            uint depth);
        /// <summary>
        /// The gltexstorage3d
        /// </summary>
        private static glTexStorage3D_t p_glTexStorage3D;
        /// <summary>
        /// Gls the tex storage 3 d using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="levels">The levels</param>
        /// <param name="internalformat">The internalformat</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        public static void glTexStorage3D(
            TextureTarget target,
            uint levels,
            SizedInternalFormat internalformat,
            uint width,
            uint height,
            uint depth) => p_glTexStorage3D(target, levels, internalformat, width, height, depth);

        /// <summary>
        /// The gltexturestorage1d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTextureStorage1D_t(
            uint texture,
            uint levels,
            SizedInternalFormat internalformat,
            uint width);
        /// <summary>
        /// The gltexturestorage1d
        /// </summary>
        private static glTextureStorage1D_t p_glTextureStorage1D;
        /// <summary>
        /// Gls the texture storage 1 d using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="levels">The levels</param>
        /// <param name="internalformat">The internalformat</param>
        /// <param name="width">The width</param>
        public static void glTextureStorage1D(uint texture, uint levels, SizedInternalFormat internalformat, uint width)
            => p_glTextureStorage1D(texture, levels, internalformat, width);

        /// <summary>
        /// The gltexturestorage2d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTextureStorage2D_t(
            uint texture,
            uint levels,
            SizedInternalFormat internalformat,
            uint width,
            uint height);
        /// <summary>
        /// The gltexturestorage2d
        /// </summary>
        private static glTextureStorage2D_t p_glTextureStorage2D;
        /// <summary>
        /// Gls the texture storage 2 d using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="levels">The levels</param>
        /// <param name="internalformat">The internalformat</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public static void glTextureStorage2D(
            uint texture,
            uint levels,
            SizedInternalFormat internalformat,
            uint width,
            uint height) => p_glTextureStorage2D(texture, levels, internalformat, width, height);

        /// <summary>
        /// The gltexturestorage3d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTextureStorage3D_t(
            uint texture,
            uint levels,
            SizedInternalFormat internalformat,
            uint width,
            uint height,
            uint depth);
        /// <summary>
        /// The gltexturestorage3d
        /// </summary>
        private static glTextureStorage3D_t p_glTextureStorage3D;
        /// <summary>
        /// Gls the texture storage 3 d using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="levels">The levels</param>
        /// <param name="internalformat">The internalformat</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        public static void glTextureStorage3D(
            uint texture,
            uint levels,
            SizedInternalFormat internalformat,
            uint width,
            uint height,
            uint depth) => p_glTextureStorage3D(texture, levels, internalformat, width, height, depth);

        /// <summary>
        /// The gltexturestorage2dmultisample
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTextureStorage2DMultisample_t(
            uint texture,
            uint samples,
            SizedInternalFormat internalformat,
            uint width,
            uint height,
            GLboolean fixedsamplelocations);
        /// <summary>
        /// The gltexturestorage2dmultisample
        /// </summary>
        private static glTextureStorage2DMultisample_t p_glTextureStorage2DMultisample;
        /// <summary>
        /// Gls the texture storage 2 d multisample using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="samples">The samples</param>
        /// <param name="internalformat">The internalformat</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="fixedsamplelocations">The fixedsamplelocations</param>
        public static void glTextureStorage2DMultisample(
            uint texture,
            uint samples,
            SizedInternalFormat internalformat,
            uint width,
            uint height,
            GLboolean fixedsamplelocations)
            => p_glTextureStorage2DMultisample(texture, samples, internalformat, width, height, fixedsamplelocations);

        /// <summary>
        /// The gltexturestorage3dmultisample
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTextureStorage3DMultisample_t(
            uint texture,
            uint samples,
            SizedInternalFormat internalformat,
            uint width,
            uint height,
            uint depth,
            GLboolean fixedsamplelocations);
        /// <summary>
        /// The gltexturestorage3dmultisample
        /// </summary>
        private static glTextureStorage3DMultisample_t p_glTextureStorage3DMultisample;
        /// <summary>
        /// Gls the texture storage 3 d multisample using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="samples">The samples</param>
        /// <param name="internalformat">The internalformat</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="fixedsamplelocations">The fixedsamplelocations</param>
        public static void glTextureStorage3DMultisample(
            uint texture,
            uint samples,
            SizedInternalFormat internalformat,
            uint width,
            uint height,
            uint depth,
            GLboolean fixedsamplelocations)
            => p_glTextureStorage3DMultisample(texture, samples, internalformat, width, height, depth, fixedsamplelocations);

        /// <summary>
        /// The gltexstorage2dmultisample
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTexStorage2DMultisample_t(
            TextureTarget target,
            uint samples,
            SizedInternalFormat internalformat,
            uint width,
            uint height,
            GLboolean fixedsamplelocations);
        /// <summary>
        /// The gltexstorage2dmultisample
        /// </summary>
        private static glTexStorage2DMultisample_t p_glTexStorage2DMultisample;
        /// <summary>
        /// Gls the tex storage 2 d multisample using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="samples">The samples</param>
        /// <param name="internalformat">The internalformat</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="fixedsamplelocations">The fixedsamplelocations</param>
        public static void glTexStorage2DMultisample(
            TextureTarget target,
            uint samples,
            SizedInternalFormat internalformat,
            uint width,
            uint height,
            GLboolean fixedsamplelocations)
            => p_glTexStorage2DMultisample(target, samples, internalformat, width, height, fixedsamplelocations);

        /// <summary>
        /// The gltexstorage3dmultisample
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTexStorage3DMultisample_t(
            TextureTarget target,
            uint samples,
            SizedInternalFormat internalformat,
            uint width,
            uint height,
            uint depth,
            GLboolean fixedsamplelocations);
        /// <summary>
        /// The gltexstorage3dmultisample
        /// </summary>
        private static glTexStorage3DMultisample_t p_glTexStorage3DMultisample;
        /// <summary>
        /// Gls the tex storage 3 d multisample using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="samples">The samples</param>
        /// <param name="internalformat">The internalformat</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="fixedsamplelocations">The fixedsamplelocations</param>
        public static void glTexStorage3DMultisample(
            TextureTarget target,
            uint samples,
            SizedInternalFormat internalformat,
            uint width,
            uint height,
            uint depth,
            GLboolean fixedsamplelocations)
            => p_glTexStorage3DMultisample(target, samples, internalformat, width, height, depth, fixedsamplelocations);

        /// <summary>
        /// The gltextureview
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glTextureView_t(
            uint texture,
            TextureTarget target,
            uint origtexture,
            PixelInternalFormat internalformat,
            uint minlevel,
            uint numlevels,
            uint minlayer,
            uint numlayers);
        /// <summary>
        /// The gltextureview
        /// </summary>
        private static glTextureView_t p_glTextureView;
        /// <summary>
        /// Gls the texture view using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="target">The target</param>
        /// <param name="origtexture">The origtexture</param>
        /// <param name="internalformat">The internalformat</param>
        /// <param name="minlevel">The minlevel</param>
        /// <param name="numlevels">The numlevels</param>
        /// <param name="minlayer">The minlayer</param>
        /// <param name="numlayers">The numlayers</param>
        public static void glTextureView(
            uint texture,
            TextureTarget target,
            uint origtexture,
            PixelInternalFormat internalformat,
            uint minlevel,
            uint numlevels,
            uint minlayer,
            uint numlayers)
                => p_glTextureView(texture, target, origtexture, internalformat, minlevel, numlevels, minlayer, numlayers);

        /// <summary>
        /// The glmapbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void* glMapBuffer_t(BufferTarget target, BufferAccess access);
        /// <summary>
        /// The glmapbuffer
        /// </summary>
        private static glMapBuffer_t p_glMapBuffer;
        /// <summary>
        /// Gls the map buffer using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="access">The access</param>
        /// <returns>The void</returns>
        public static void* glMapBuffer(BufferTarget target, BufferAccess access) => p_glMapBuffer(target, access);

        /// <summary>
        /// The glmapnamedbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void* glMapNamedBuffer_t(uint buffer, BufferAccess access);
        /// <summary>
        /// The glmapnamedbuffer
        /// </summary>
        private static glMapNamedBuffer_t p_glMapNamedBuffer;
        /// <summary>
        /// Gls the map named buffer using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="access">The access</param>
        /// <returns>The void</returns>
        public static void* glMapNamedBuffer(uint buffer, BufferAccess access) => p_glMapNamedBuffer(buffer, access);

        /// <summary>
        /// The glunmapbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate GLboolean glUnmapBuffer_t(BufferTarget target);
        /// <summary>
        /// The glunmapbuffer
        /// </summary>
        private static glUnmapBuffer_t p_glUnmapBuffer;
        /// <summary>
        /// Gls the unmap buffer using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <returns>The lboolean</returns>
        public static GLboolean glUnmapBuffer(BufferTarget target) => p_glUnmapBuffer(target);

        /// <summary>
        /// The glunmapnamedbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate GLboolean glUnmapNamedBuffer_t(uint buffer);
        /// <summary>
        /// The glunmapnamedbuffer
        /// </summary>
        private static glUnmapNamedBuffer_t p_glUnmapNamedBuffer;
        /// <summary>
        /// Gls the unmap named buffer using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <returns>The lboolean</returns>
        public static GLboolean glUnmapNamedBuffer(uint buffer) => p_glUnmapNamedBuffer(buffer);

        /// <summary>
        /// The glcopybuffersubdata
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glCopyBufferSubData_t(
            BufferTarget readTarget,
            BufferTarget writeTarget,
            IntPtr readOffset,
            IntPtr writeOffset,
            IntPtr size);
        /// <summary>
        /// The glcopybuffersubdata
        /// </summary>
        private static glCopyBufferSubData_t p_glCopyBufferSubData;
        /// <summary>
        /// Gls the copy buffer sub data using the specified read target
        /// </summary>
        /// <param name="readTarget">The read target</param>
        /// <param name="writeTarget">The write target</param>
        /// <param name="readOffset">The read offset</param>
        /// <param name="writeOffset">The write offset</param>
        /// <param name="size">The size</param>
        public static void glCopyBufferSubData(
            BufferTarget readTarget,
            BufferTarget writeTarget,
            IntPtr readOffset,
            IntPtr writeOffset,
            IntPtr size) => p_glCopyBufferSubData(readTarget, writeTarget, readOffset, writeOffset, size);

        /// <summary>
        /// The glcopytexsubimage2d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glCopyTexSubImage2D_t(
            TextureTarget target,
            int level,
            int xoffset,
            int yoffset,
            int x,
            int y,
            uint width,
            uint height);
        /// <summary>
        /// The glcopytexsubimage2d
        /// </summary>
        private static glCopyTexSubImage2D_t p_glCopyTexSubImage2D;
        /// <summary>
        /// Gls the copy tex sub image 2 d using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="level">The level</param>
        /// <param name="xoffset">The xoffset</param>
        /// <param name="yoffset">The yoffset</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public static void glCopyTexSubImage2D(
            TextureTarget target,
            int level,
            int xoffset,
            int yoffset,
            int x,
            int y,
            uint width,
            uint height) => p_glCopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height);

        /// <summary>
        /// The glcopytexsubimage3d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glCopyTexSubImage3D_t(
            TextureTarget target,
            int level,
            int xoffset,
            int yoffset,
            int zoffset,
            int x,
            int y,
            uint width,
            uint height);
        /// <summary>
        /// The glcopytexsubimage3d
        /// </summary>
        private static glCopyTexSubImage3D_t p_glCopyTexSubImage3D;
        /// <summary>
        /// Gls the copy tex sub image 3 d using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="level">The level</param>
        /// <param name="xoffset">The xoffset</param>
        /// <param name="yoffset">The yoffset</param>
        /// <param name="zoffset">The zoffset</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public static void glCopyTexSubImage3D(
            TextureTarget target,
            int level,
            int xoffset,
            int yoffset,
            int zoffset,
            int x,
            int y,
            uint width,
            uint height) => p_glCopyTexSubImage3D(target, level, xoffset, yoffset, zoffset, x, y, width, height);

        /// <summary>
        /// The glmapbufferrange
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void* glMapBufferRange_t(BufferTarget target, IntPtr offset, IntPtr length, BufferAccessMask access);
        /// <summary>
        /// The glmapbufferrange
        /// </summary>
        private static glMapBufferRange_t p_glMapBufferRange;
        /// <summary>
        /// Gls the map buffer range using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="offset">The offset</param>
        /// <param name="length">The length</param>
        /// <param name="access">The access</param>
        /// <returns>The void</returns>
        public static void* glMapBufferRange(BufferTarget target, IntPtr offset, IntPtr length, BufferAccessMask access)
            => p_glMapBufferRange(target, offset, length, access);

        /// <summary>
        /// The glmapnamedbufferrange
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void* glMapNamedBufferRange_t(uint buffer, IntPtr offset, uint length, BufferAccessMask access);
        /// <summary>
        /// The glmapnamedbufferrange
        /// </summary>
        private static glMapNamedBufferRange_t p_glMapNamedBufferRange;
        /// <summary>
        /// Gls the map named buffer range using the specified buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="length">The length</param>
        /// <param name="access">The access</param>
        /// <returns>The void</returns>
        public static void* glMapNamedBufferRange(uint buffer, IntPtr offset, uint length, BufferAccessMask access)
            => p_glMapNamedBufferRange(buffer, offset, length, access);

        /// <summary>
        /// The glgetteximage
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGetTexImage_t(
            TextureTarget target,
            int level,
            GLPixelFormat format,
            GLPixelType type,
            void* pixels);
        /// <summary>
        /// The glgetteximage
        /// </summary>
        private static glGetTexImage_t p_glGetTexImage;
        /// <summary>
        /// Gls the get tex image using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="level">The level</param>
        /// <param name="format">The format</param>
        /// <param name="type">The type</param>
        /// <param name="pixels">The pixels</param>
        public static void glGetTexImage(TextureTarget target, int level, GLPixelFormat format, GLPixelType type, void* pixels)
            => p_glGetTexImage(target, level, format, type, pixels);

        /// <summary>
        /// The glgettexturesubimage
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGetTextureSubImage_t(
            uint texture,
            int level,
            int xoffset,
            int yoffset,
            int zoffset,
            uint width,
            uint height,
            uint depth,
            GLPixelFormat format,
            GLPixelType type,
            uint bufSize,
            void* pixels);
        /// <summary>
        /// The glgettexturesubimage
        /// </summary>
        private static glGetTextureSubImage_t p_glGetTextureSubImage;
        /// <summary>
        /// Gls the get texture sub image using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="level">The level</param>
        /// <param name="xoffset">The xoffset</param>
        /// <param name="yoffset">The yoffset</param>
        /// <param name="zoffset">The zoffset</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="format">The format</param>
        /// <param name="type">The type</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="pixels">The pixels</param>
        public static void glGetTextureSubImage(
            uint texture,
            int level,
            int xoffset,
            int yoffset,
            int zoffset,
            uint width,
            uint height,
            uint depth,
            GLPixelFormat format,
            GLPixelType type,
            uint bufSize,
            void* pixels)
            => p_glGetTextureSubImage(
                texture,
                level,
                xoffset,
                yoffset,
                zoffset,
                width,
                height,
                depth,
                format,
                type,
                bufSize,
                pixels);

        /// <summary>
        /// The glcopynamedbuffersubdata
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glCopyNamedBufferSubData_t(
            uint readBuffer,
            uint writeBuffer,
            IntPtr readOffset,
            IntPtr writeOffset,
            uint size);
        /// <summary>
        /// The glcopynamedbuffersubdata
        /// </summary>
        private static glCopyNamedBufferSubData_t p_glCopyNamedBufferSubData;
        /// <summary>
        /// Gls the copy named buffer sub data using the specified read buffer
        /// </summary>
        /// <param name="readBuffer">The read buffer</param>
        /// <param name="writeBuffer">The write buffer</param>
        /// <param name="readOffset">The read offset</param>
        /// <param name="writeOffset">The write offset</param>
        /// <param name="size">The size</param>
        public static void glCopyNamedBufferSubData(
            uint readBuffer,
            uint writeBuffer,
            IntPtr readOffset,
            IntPtr writeOffset,
            uint size) => p_glCopyNamedBufferSubData(readBuffer, writeBuffer, readOffset, writeOffset, size);

        /// <summary>
        /// The glcreatebuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glCreateBuffers_t(uint n, uint* buffers);
        /// <summary>
        /// The glcreatebuffers
        /// </summary>
        private static glCreateBuffers_t p_glCreateBuffers;
        /// <summary>
        /// Gls the create buffers using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="buffers">The buffers</param>
        public static void glCreateBuffers(uint n, uint* buffers) => p_glCreateBuffers(n, buffers);

        /// <summary>
        /// The glcreatetextures
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glCreateTextures_t(TextureTarget target, uint n, uint* textures);
        /// <summary>
        /// The glcreatetextures
        /// </summary>
        private static glCreateTextures_t p_glCreateTextures;
        /// <summary>
        /// Gls the create textures using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="n">The </param>
        /// <param name="textures">The textures</param>
        public static void glCreateTextures(TextureTarget target, uint n, uint* textures)
            => p_glCreateTextures(target, n, textures);

        /// <summary>
        /// The glcompressedtexsubimage1d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glCompressedTexSubImage1D_t(
            TextureTarget target,
            int level,
            int xoffset,
            uint width,
            PixelInternalFormat internalformat,
            uint imageSize,
            void* data);
        /// <summary>
        /// The glcompressedtexsubimage1d
        /// </summary>
        private static glCompressedTexSubImage1D_t p_glCompressedTexSubImage1D;
        /// <summary>
        /// Gls the compressed tex sub image 1 d using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="level">The level</param>
        /// <param name="xoffset">The xoffset</param>
        /// <param name="width">The width</param>
        /// <param name="internalformat">The internalformat</param>
        /// <param name="imageSize">The image size</param>
        /// <param name="data">The data</param>
        public static void glCompressedTexSubImage1D(
            TextureTarget target,
            int level,
            int xoffset,
            uint width,
            PixelInternalFormat internalformat,
            uint imageSize,
            void* data) => p_glCompressedTexSubImage1D(target, level, xoffset, width, internalformat, imageSize, data);

        /// <summary>
        /// The glcompressedtexsubimage2d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glCompressedTexSubImage2D_t(
            TextureTarget target,
            int level,
            int xoffset,
            int yoffset,
            uint width,
            uint height,
            PixelInternalFormat format,
            uint imageSize,
            void* data);
        /// <summary>
        /// The glcompressedtexsubimage2d
        /// </summary>
        private static glCompressedTexSubImage2D_t p_glCompressedTexSubImage2D;
        /// <summary>
        /// Gls the compressed tex sub image 2 d using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="level">The level</param>
        /// <param name="xoffset">The xoffset</param>
        /// <param name="yoffset">The yoffset</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="format">The format</param>
        /// <param name="imageSize">The image size</param>
        /// <param name="data">The data</param>
        public static void glCompressedTexSubImage2D(
            TextureTarget target,
            int level,
            int xoffset,
            int yoffset,
            uint width,
            uint height,
            PixelInternalFormat format,
            uint imageSize,
            void* data) => p_glCompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, data);

        /// <summary>
        /// The glcompressedtexsubimage3d
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glCompressedTexSubImage3D_t(
            TextureTarget target,
             int level,
             int xoffset,
             int yoffset,
             int zoffset,
             uint width,
             uint height,
             uint depth,
             PixelInternalFormat format,
             uint imageSize,
             void* data);
        /// <summary>
        /// The glcompressedtexsubimage3d
        /// </summary>
        private static glCompressedTexSubImage3D_t p_glCompressedTexSubImage3D;
        /// <summary>
        /// Gls the compressed tex sub image 3 d using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="level">The level</param>
        /// <param name="xoffset">The xoffset</param>
        /// <param name="yoffset">The yoffset</param>
        /// <param name="zoffset">The zoffset</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="format">The format</param>
        /// <param name="imageSize">The image size</param>
        /// <param name="data">The data</param>
        public static void glCompressedTexSubImage3D(
            TextureTarget target,
             int level,
             int xoffset,
             int yoffset,
             int zoffset,
             uint width,
             uint height,
             uint depth,
             PixelInternalFormat format,
             uint imageSize,
             void* data)
            => p_glCompressedTexSubImage3D(
                target,
                level,
                xoffset,
                yoffset,
                zoffset,
                width,
                height,
                depth,
                format,
                imageSize,
                data);

        /// <summary>
        /// The glcopyimagesubdata
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glCopyImageSubData_t(
            uint srcName,
            TextureTarget srcTarget,
            int srcLevel,
            int srcX,
            int srcY,
            int srcZ,
            uint dstName,
            TextureTarget dstTarget,
            int dstLevel,
            int dstX,
            int dstY,
            int dstZ,
            uint srcWidth,
            uint srcHeight,
            uint srcDepth);
        /// <summary>
        /// The glcopyimagesubdata
        /// </summary>
        private static glCopyImageSubData_t p_glCopyImageSubData;
        /// <summary>
        /// Gls the copy image sub data using the specified src name
        /// </summary>
        /// <param name="srcName">The src name</param>
        /// <param name="srcTarget">The src target</param>
        /// <param name="srcLevel">The src level</param>
        /// <param name="srcX">The src</param>
        /// <param name="srcY">The src</param>
        /// <param name="srcZ">The src</param>
        /// <param name="dstName">The dst name</param>
        /// <param name="dstTarget">The dst target</param>
        /// <param name="dstLevel">The dst level</param>
        /// <param name="dstX">The dst</param>
        /// <param name="dstY">The dst</param>
        /// <param name="dstZ">The dst</param>
        /// <param name="srcWidth">The src width</param>
        /// <param name="srcHeight">The src height</param>
        /// <param name="srcDepth">The src depth</param>
        public static void glCopyImageSubData(
            uint srcName,
            TextureTarget srcTarget,
            int srcLevel,
            int srcX,
            int srcY,
            int srcZ,
            uint dstName,
            TextureTarget dstTarget,
            int dstLevel,
            int dstX,
            int dstY,
            int dstZ,
            uint srcWidth,
            uint srcHeight,
            uint srcDepth) => p_glCopyImageSubData(
                srcName, srcTarget,
                srcLevel, srcX, srcY, srcZ,
                dstName, dstTarget,
                dstLevel, dstX, dstY, dstZ,
                srcWidth, srcHeight, srcDepth);

        /// <summary>
        /// The glstencilfuncseparate
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glStencilFuncSeparate_t(CullFaceMode face, StencilFunction func, int @ref, uint mask);
        /// <summary>
        /// The glstencilfuncseparate
        /// </summary>
        private static glStencilFuncSeparate_t p_glStencilFuncSeparate;
        /// <summary>
        /// Gls the stencil func separate using the specified face
        /// </summary>
        /// <param name="face">The face</param>
        /// <param name="func">The func</param>
        /// <param name="@ref">The ref</param>
        /// <param name="mask">The mask</param>
        public static void glStencilFuncSeparate(CullFaceMode face, StencilFunction func, int @ref, uint mask)
            => p_glStencilFuncSeparate(face, func, @ref, mask);

        /// <summary>
        /// The glstencilopseparate
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glStencilOpSeparate_t(
            CullFaceMode face,
            StencilOp sfail,
            StencilOp dpfail,
            StencilOp dppass);
        /// <summary>
        /// The glstencilopseparate
        /// </summary>
        private static glStencilOpSeparate_t p_glStencilOpSeparate;
        /// <summary>
        /// Gls the stencil op separate using the specified face
        /// </summary>
        /// <param name="face">The face</param>
        /// <param name="sfail">The sfail</param>
        /// <param name="dpfail">The dpfail</param>
        /// <param name="dppass">The dppass</param>
        public static void glStencilOpSeparate(
            CullFaceMode face,
            StencilOp sfail,
            StencilOp dpfail,
            StencilOp dppass) => p_glStencilOpSeparate(face, sfail, dpfail, dppass);

        /// <summary>
        /// The glstencilmask
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glStencilMask_t(uint mask);
        /// <summary>
        /// The glstencilmask
        /// </summary>
        private static glStencilMask_t p_glStencilMask;
        /// <summary>
        /// Gls the stencil mask using the specified mask
        /// </summary>
        /// <param name="mask">The mask</param>
        public static void glStencilMask(uint mask) => p_glStencilMask(mask);

        /// <summary>
        /// The glclearstencil
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glClearStencil_t(int s);
        /// <summary>
        /// The glclearstencil
        /// </summary>
        private static glClearStencil_t p_glClearStencil;
        /// <summary>
        /// Gls the clear stencil using the specified s
        /// </summary>
        /// <param name="s">The </param>
        public static void glClearStencil(int s) => p_glClearStencil(s);

        /// <summary>
        /// The glgetactiveuniformblockiv
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGetActiveUniformBlockiv_t(
            uint program,
            uint uniformBlockIndex,
            ActiveUniformBlockParameter pname,
            int* @params);
        /// <summary>
        /// The glgetactiveuniformblockiv
        /// </summary>
        private static glGetActiveUniformBlockiv_t p_glGetActiveUniformBlockiv;
        /// <summary>
        /// Gls the get active uniform blockiv using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="uniformBlockIndex">The uniform block index</param>
        /// <param name="pname">The pname</param>
        /// <param name="@params">The params</param>
        public static void glGetActiveUniformBlockiv(
            uint program,
            uint uniformBlockIndex,
            ActiveUniformBlockParameter pname,
            int* @params) => p_glGetActiveUniformBlockiv(program, uniformBlockIndex, pname, @params);

        /// <summary>
        /// The glgetactiveuniformblockname
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGetActiveUniformBlockName_t(
            uint program,
            uint uniformBlockIndex,
            uint bufSize,
            uint* length,
            byte* uniformBlockName);
        /// <summary>
        /// The glgetactiveuniformblockname
        /// </summary>
        private static glGetActiveUniformBlockName_t p_glGetActiveUniformBlockName;
        /// <summary>
        /// Gls the get active uniform block name using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="uniformBlockIndex">The uniform block index</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="length">The length</param>
        /// <param name="uniformBlockName">The uniform block name</param>
        public static void glGetActiveUniformBlockName(
            uint program,
            uint uniformBlockIndex,
            uint bufSize,
            uint* length,
            byte* uniformBlockName) => p_glGetActiveUniformBlockName(program, uniformBlockIndex, bufSize, length, uniformBlockName);

        /// <summary>
        /// The glgetactiveuniform
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGetActiveUniform_t(
            uint program,
            uint index,
            uint bufSize,
            uint* length,
            int* size,
            uint* type,
            byte* name);
        /// <summary>
        /// The glgetactiveuniform
        /// </summary>
        private static glGetActiveUniform_t p_glGetActiveUniform;
        /// <summary>
        /// Gls the get active uniform using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="index">The index</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="length">The length</param>
        /// <param name="size">The size</param>
        /// <param name="type">The type</param>
        /// <param name="name">The name</param>
        public static void glGetActiveUniform(
            uint program,
            uint index,
            uint bufSize,
            uint* length,
            int* size,
            uint* type,
            byte* name) => p_glGetActiveUniform(program, index, bufSize, length, size, type, name);

        /// <summary>
        /// The glgetcompressedteximage
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGetCompressedTexImage_t(TextureTarget target, int level, void* pixels);
        /// <summary>
        /// The glgetcompressedteximage
        /// </summary>
        private static glGetCompressedTexImage_t p_glGetCompressedTexImage;
        /// <summary>
        /// Gls the get compressed tex image using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="level">The level</param>
        /// <param name="pixels">The pixels</param>
        public static void glGetCompressedTexImage(TextureTarget target, int level, void* pixels)
            => p_glGetCompressedTexImage(target, level, pixels);

        /// <summary>
        /// The glgetcompressedtextureimage
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGetCompressedTextureImage_t(uint texture, int level, uint bufSize, void* pixels);
        /// <summary>
        /// The glgetcompressedtextureimage
        /// </summary>
        private static glGetCompressedTextureImage_t p_glGetCompressedTextureImage;
        /// <summary>
        /// Gls the get compressed texture image using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="level">The level</param>
        /// <param name="bufSize">The buf size</param>
        /// <param name="pixels">The pixels</param>
        public static void glGetCompressedTextureImage(uint texture, int level, uint bufSize, void* pixels)
            => p_glGetCompressedTextureImage(texture, level, bufSize, pixels);

        /// <summary>
        /// The glgettexlevelparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGetTexLevelParameteriv_t(
            TextureTarget target,
            int level,
            GetTextureParameter pname,
            int* @params);
        /// <summary>
        /// The glgettexlevelparameteriv
        /// </summary>
        private static glGetTexLevelParameteriv_t p_glGetTexLevelParameteriv;
        /// <summary>
        /// Gls the get tex level parameteriv using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="level">The level</param>
        /// <param name="pname">The pname</param>
        /// <param name="@params">The params</param>
        public static void glGetTexLevelParameteriv(
            TextureTarget target,
            int level,
            GetTextureParameter pname,
            int* @params) => p_glGetTexLevelParameteriv(target, level, pname, @params);

        /// <summary>
        /// The glframebufferrenderbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glFramebufferRenderbuffer_t(
            FramebufferTarget target,
            GLFramebufferAttachment attachment,
            RenderbufferTarget renderbuffertarget,
            uint renderbuffer);
        /// <summary>
        /// The glframebufferrenderbuffer
        /// </summary>
        private static glFramebufferRenderbuffer_t p_glFramebufferRenderbuffer;
        /// <summary>
        /// Gls the framebuffer renderbuffer using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="attachment">The attachment</param>
        /// <param name="renderbuffertarget">The renderbuffertarget</param>
        /// <param name="renderbuffer">The renderbuffer</param>
        public static void glFramebufferRenderbuffer(
            FramebufferTarget target,
            GLFramebufferAttachment attachment,
            RenderbufferTarget renderbuffertarget,
            uint renderbuffer)
            => p_glFramebufferRenderbuffer(target, attachment, renderbuffertarget, renderbuffer);

        /// <summary>
        /// The glrenderbufferstorage
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glRenderbufferStorage_t(
            RenderbufferTarget target,
            uint internalformat,
            uint width,
            uint height);
        /// <summary>
        /// The glrenderbufferstorage
        /// </summary>
        private static glRenderbufferStorage_t p_glRenderbufferStorage;
        /// <summary>
        /// Gls the renderbuffer storage using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="internalFormat">The internal format</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public static void glRenderbufferStorage(
            RenderbufferTarget target,
            uint internalFormat,
            uint width,
            uint height) => p_glRenderbufferStorage(target, internalFormat, width, height);

        /// <summary>
        /// The glgetrenderbufferparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGetRenderbufferParameteriv_t(
            RenderbufferTarget target,
            RenderbufferPname pname,
            out int parameters);
        /// <summary>
        /// The glgetrenderbufferparameteriv
        /// </summary>
        private static glGetRenderbufferParameteriv_t p_glGetRenderbufferParameteriv;
        /// <summary>
        /// Gls the get renderbuffer parameteriv using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="pname">The pname</param>
        /// <param name="parameters">The parameters</param>
        public static void glGetRenderbufferParameteriv(
            RenderbufferTarget target,
            RenderbufferPname pname,
            out int parameters) => p_glGetRenderbufferParameteriv(target, pname, out parameters);

        /// <summary>
        /// The glgenrenderbuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGenRenderbuffers_t(uint count, out uint names);
        /// <summary>
        /// The glgenrenderbuffers
        /// </summary>
        private static glGenRenderbuffers_t p_glGenRenderbuffers;
        /// <summary>
        /// Gls the gen renderbuffers using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        /// <param name="names">The names</param>
        public static void glGenRenderbuffers(uint count, out uint names)
            => p_glGenRenderbuffers(count, out names);

        /// <summary>
        /// The glbindrenderbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glBindRenderbuffer_t(RenderbufferTarget bindPoint, uint name);
        /// <summary>
        /// The glbindrenderbuffer
        /// </summary>
        private static glBindRenderbuffer_t p_glBindRenderbuffer;
        /// <summary>
        /// Gls the bind renderbuffer using the specified bind point
        /// </summary>
        /// <param name="bindPoint">The bind point</param>
        /// <param name="name">The name</param>
        public static void glBindRenderbuffer(RenderbufferTarget bindPoint, uint name)
            => p_glBindRenderbuffer(bindPoint, name);

        /// <summary>
        /// The glgeneratemipmap
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGenerateMipmap_t(TextureTarget target);
        /// <summary>
        /// The glgeneratemipmap
        /// </summary>
        private static glGenerateMipmap_t p_glGenerateMipmap;
        /// <summary>
        /// Gls the generate mipmap using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        public static void glGenerateMipmap(TextureTarget target) => p_glGenerateMipmap(target);

        /// <summary>
        /// The glgeneratetexturemipmap
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGenerateTextureMipmap_t(uint texture);
        /// <summary>
        /// The glgeneratetexturemipmap
        /// </summary>
        private static glGenerateTextureMipmap_t p_glGenerateTextureMipmap;
        /// <summary>
        /// Gls the generate texture mipmap using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        public static void glGenerateTextureMipmap(uint texture) => p_glGenerateTextureMipmap(texture);

        /// <summary>
        /// The glclipcontrol
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glClipControl_t(ClipControlOrigin origin, ClipControlDepthRange depth);
        /// <summary>
        /// The glclipcontrol
        /// </summary>
        private static glClipControl_t p_glClipControl;
        /// <summary>
        /// Gls the clip control using the specified origin
        /// </summary>
        /// <param name="origin">The origin</param>
        /// <param name="depth">The depth</param>
        public static void glClipControl(ClipControlOrigin origin, ClipControlDepthRange depth)
            => p_glClipControl(origin, depth);

        /// <summary>
        /// The glgetframebufferattachmentparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glGetFramebufferAttachmentParameteriv_t(
            FramebufferTarget target,
            GLFramebufferAttachment attachment,
            FramebufferParameterName pname,
            int* @params);
        /// <summary>
        /// The glgetframebufferattachmentparameteriv
        /// </summary>
        private static glGetFramebufferAttachmentParameteriv_t p_glGetFramebufferAttachmentParameteriv;
        /// <summary>
        /// Gls the get framebuffer attachment parameteriv using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="attachment">The attachment</param>
        /// <param name="pname">The pname</param>
        /// <param name="@params">The params</param>
        public static void glGetFramebufferAttachmentParameteriv(
            FramebufferTarget target,
            GLFramebufferAttachment attachment,
            FramebufferParameterName pname,
            int* @params) => p_glGetFramebufferAttachmentParameteriv(target, attachment, pname, @params);

        /// <summary>
        /// The glflush
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glFlush_t();
        /// <summary>
        /// The glflush
        /// </summary>
        private static glFlush_t p_glFlush;
        /// <summary>
        /// Gls the flush
        /// </summary>
        public static void glFlush() => p_glFlush();

        /// <summary>
        /// The glfinish
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glFinish_t();
        /// <summary>
        /// The glfinish
        /// </summary>
        private static glFinish_t p_glFinish;
        /// <summary>
        /// Gls the finish
        /// </summary>
        public static void glFinish() => p_glFinish();

        /// <summary>
        /// The glpushdebuggroup
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glPushDebugGroup_t(DebugSource source, uint id, uint length, byte* message);
        /// <summary>
        /// The glpushdebuggroup
        /// </summary>
        private static glPushDebugGroup_t p_glPushDebugGroup;
        /// <summary>
        /// Gls the push debug group using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">The id</param>
        /// <param name="length">The length</param>
        /// <param name="message">The message</param>
        public static void glPushDebugGroup(DebugSource source, uint id, uint length, byte* message)
            => p_glPushDebugGroup(source, id, length, message);

        /// <summary>
        /// The glpopdebuggroup
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glPopDebugGroup_t();
        /// <summary>
        /// The glpopdebuggroup
        /// </summary>
        private static glPopDebugGroup_t p_glPopDebugGroup;
        /// <summary>
        /// Gls the pop debug group
        /// </summary>
        public static void glPopDebugGroup() => p_glPopDebugGroup();

        /// <summary>
        /// The gldebugmessageinsert
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glDebugMessageInsert_t(
            DebugSource source,
            DebugType type,
            uint id,
            DebugSeverity severity,
            uint length,
            byte* message);
        /// <summary>
        /// The gldebugmessageinsert
        /// </summary>
        private static glDebugMessageInsert_t p_glDebugMessageInsert;
        /// <summary>
        /// Gls the debug message insert using the specified source
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="type">The type</param>
        /// <param name="id">The id</param>
        /// <param name="severity">The severity</param>
        /// <param name="length">The length</param>
        /// <param name="message">The message</param>
        public static void glDebugMessageInsert(
            DebugSource source,
            DebugType type,
            uint id,
            DebugSeverity severity,
            uint length,
            byte* message) => p_glDebugMessageInsert(source, type, id, severity, length, message);

        /// <summary>
        /// The glinserteventmarker
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glInsertEventMarker_t(uint length, byte* marker);
        /// <summary>
        /// The glinserteventmarker
        /// </summary>
        private static glInsertEventMarker_t p_glInsertEventMarker;
        /// <summary>
        /// Gls the insert event marker using the specified length
        /// </summary>
        /// <param name="length">The length</param>
        /// <param name="marker">The marker</param>
        public static void glInsertEventMarker(uint length, byte* marker) => p_glInsertEventMarker(length, marker);

        /// <summary>
        /// The glpushgroupmarkerext
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glPushGroupMarkerEXT_t(uint length, byte* marker);
        /// <summary>
        /// The glpushgroupmarker
        /// </summary>
        private static glPushGroupMarkerEXT_t p_glPushGroupMarker;
        /// <summary>
        /// Gls the push group marker using the specified length
        /// </summary>
        /// <param name="length">The length</param>
        /// <param name="marker">The marker</param>
        public static void glPushGroupMarker(uint length, byte* marker) => p_glPushGroupMarker(length, marker);

        /// <summary>
        /// The glpopgroupmarkerext
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glPopGroupMarkerEXT_t();
        /// <summary>
        /// The glpopgroupmarker
        /// </summary>
        private static glPopGroupMarkerEXT_t p_glPopGroupMarker;
        /// <summary>
        /// Gls the pop group marker
        /// </summary>
        public static void glPopGroupMarker() => p_glPopGroupMarker();

        /// <summary>
        /// The glreadpixels
        /// </summary>
        [UnmanagedFunctionPointer(CallConv)]
        private delegate void glReadPixels_t(
            int x,
            int y,
            uint width,
            uint height,
            GLPixelFormat format,
            GLPixelType type,
            void* data);
        /// <summary>
        /// The glreadpixels
        /// </summary>
        private static glReadPixels_t p_glReadPixels;
        /// <summary>
        /// Gls the read pixels using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="format">The format</param>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        public static void glReadPixels(
            int x,
            int y,
            uint width,
            uint height,
            GLPixelFormat format,
            GLPixelType type,
            void* data) => p_glReadPixels(x, y, width, height, format, type, data);

        /// <summary>
        /// Loads the get string using the specified gl context
        /// </summary>
        /// <param name="glContext">The gl context</param>
        /// <param name="getProcAddress">The get proc address</param>
        public static void LoadGetString(IntPtr glContext, Func<string, IntPtr> getProcAddress)
        {
            s_getProcAddress = getProcAddress;
            LoadFunction("glGetString", out p_glGetString);
        }

        /// <summary>
        /// Loads the all functions using the specified gl context
        /// </summary>
        /// <param name="glContext">The gl context</param>
        /// <param name="getProcAddress">The get proc address</param>
        /// <param name="gles">The gles</param>
        public static void LoadAllFunctions(IntPtr glContext, Func<string, IntPtr> getProcAddress, bool gles)
        {
            s_getProcAddress = getProcAddress;

            // Common functions

            LoadFunction("glCompressedTexSubImage2D", out p_glCompressedTexSubImage2D);
            LoadFunction("glCompressedTexSubImage3D", out p_glCompressedTexSubImage3D);
            LoadFunction("glStencilFuncSeparate", out p_glStencilFuncSeparate);
            LoadFunction("glStencilOpSeparate", out p_glStencilOpSeparate);
            LoadFunction("glStencilMask", out p_glStencilMask);
            LoadFunction("glClearStencil", out p_glClearStencil);
            LoadFunction("glGetActiveUniformBlockiv", out p_glGetActiveUniformBlockiv);
            LoadFunction("glGetActiveUniformBlockName", out p_glGetActiveUniformBlockName);
            LoadFunction("glGetActiveUniform", out p_glGetActiveUniform);
            LoadFunction("glGetCompressedTexImage", out p_glGetCompressedTexImage);
            LoadFunction("glGetCompressedTextureImage", out p_glGetCompressedTextureImage);
            LoadFunction("glGetTexLevelParameteriv", out p_glGetTexLevelParameteriv);
            LoadFunction("glTexImage1D", out p_glTexImage1D);
            LoadFunction("glCompressedTexImage1D", out p_glCompressedTexSubImage1D);

            LoadFunction("glGenVertexArrays", out p_glGenVertexArrays);
            LoadFunction("glGetError", out p_glGetError);
            LoadFunction("glBindVertexArray", out p_glBindVertexArray);
            LoadFunction("glClearColor", out p_glClearColor);
            LoadFunction("glDrawBuffer", out p_glDrawBuffer);
            LoadFunction("glDrawBuffers", out p_glDrawBuffers);
            LoadFunction("glClear", out p_glClear);
            LoadFunction("glClearDepth", out p_glClearDepth);
            LoadFunction("glClearDepthf", out p_glClearDepthf);
            if (p_glClearDepthf != null) { p_glClearDepthf_Compat = p_glClearDepthf; }
            else { p_glClearDepthf_Compat = depth => p_glClearDepth(depth); }

            LoadFunction("glDrawElements", out p_glDrawElements);
            LoadFunction("glDrawElementsBaseVertex", out p_glDrawElementsBaseVertex);
            LoadFunction("glDrawElementsInstanced", out p_glDrawElementsInstanced);
            LoadFunction("glDrawElementsInstancedBaseVertex", out p_glDrawElementsInstancedBaseVertex);
            LoadFunction("glDrawArrays", out p_glDrawArrays);
            LoadFunction("glDrawArraysInstanced", out p_glDrawArraysInstanced);
            LoadFunction("glDrawArraysInstancedBaseInstance", out p_glDrawArraysInstancedBaseInstance);
            LoadFunction("glGenBuffers", out p_glGenBuffers);
            LoadFunction("glDeleteBuffers", out p_glDeleteBuffers);
            LoadFunction("glGenFramebuffers", out p_glGenFramebuffers);
            LoadFunction("glActiveTexture", out p_glActiveTexture);
            LoadFunction("glFramebufferTexture2D", out p_glFramebufferTexture2D);
            LoadFunction("glBindTexture", out p_glBindTexture);
            LoadFunction("glBindFramebuffer", out p_glBindFramebuffer);
            LoadFunction("glDeleteFramebuffers", out p_glDeleteFramebuffers);
            LoadFunction("glGenTextures", out p_glGenTextures);
            LoadFunction("glDeleteTextures", out p_glDeleteTextures);
            LoadFunction("glCheckFramebufferStatus", out p_glCheckFramebufferStatus);
            LoadFunction("glBindBuffer", out p_glBindBuffer);
            LoadFunction("glDepthRangeIndexed", out p_glDepthRangeIndexed);
            LoadFunction("glBufferSubData", out p_glBufferSubData);
            LoadFunction("glNamedBufferSubData", out p_glNamedBufferSubData);
            LoadFunction("glScissorIndexed", out p_glScissorIndexed);
            LoadFunction("glTexSubImage1D", out p_glTexSubImage1D);
            LoadFunction("glTexSubImage2D", out p_glTexSubImage2D);
            LoadFunction("glTexSubImage3D", out p_glTexSubImage3D);
            LoadFunction("glPixelStorei", out p_glPixelStorei);
            LoadFunction("glShaderSource", out p_glShaderSource);
            LoadFunction("glCreateShader", out p_glCreateShader);
            LoadFunction("glCompileShader", out p_glCompileShader);
            LoadFunction("glGetShaderiv", out p_glGetShaderiv);
            LoadFunction("glGetShaderInfoLog", out p_glGetShaderInfoLog);
            LoadFunction("glDeleteShader", out p_glDeleteShader);
            LoadFunction("glGenSamplers", out p_glGenSamplers);
            LoadFunction("glSamplerParameterf", out p_glSamplerParameterf);
            LoadFunction("glSamplerParameteri", out p_glSamplerParameteri);
            LoadFunction("glSamplerParameterfv", out p_glSamplerParameterfv);
            LoadFunction("glBindSampler", out p_glBindSampler);
            LoadFunction("glDeleteSamplers", out p_glDeleteSamplers);
            LoadFunction("glColorMaski", out p_glColorMaski);
            LoadFunction("glColorMask", out p_glColorMask);
            LoadFunction("glBlendFuncSeparatei", out p_glBlendFuncSeparatei);
            LoadFunction("glBlendFuncSeparate", out p_glBlendFuncSeparate);
            LoadFunction("glEnable", out p_glEnable);
            LoadFunction("glEnablei", out p_glEnablei);
            LoadFunction("glDisable", out p_glDisable);
            LoadFunction("glDisablei", out p_glDisablei);
            LoadFunction("glBlendEquationSeparatei", out p_glBlendEquationSeparatei);
            LoadFunction("glBlendEquationSeparate", out p_glBlendEquationSeparate);
            LoadFunction("glBlendColor", out p_glBlendColor);
            LoadFunction("glDepthFunc", out p_glDepthFunc);
            LoadFunction("glDepthMask", out p_glDepthMask);
            LoadFunction("glCullFace", out p_glCullFace);
            LoadFunction("glCreateProgram", out p_glCreateProgram);
            LoadFunction("glAttachShader", out p_glAttachShader);
            LoadFunction("glBindAttribLocation", out p_glBindAttribLocation);
            LoadFunction("glLinkProgram", out p_glLinkProgram);
            LoadFunction("glGetProgramiv", out p_glGetProgramiv);
            LoadFunction("glGetProgramInfoLog", out p_glGetProgramInfoLog);
            LoadFunction("glGetProgramInterfaceiv", out p_glGetProgramInterfaceiv);
            LoadFunction("glGetProgramResourceIndex", out p_glGetProgramResourceIndex);
            LoadFunction("glGetProgramResourceName", out p_glGetProgramResourceName);
            LoadFunction("glUniformBlockBinding", out p_glUniformBlockBinding);
            LoadFunction("glDeleteProgram", out p_glDeleteProgram);
            LoadFunction("glUniform1i", out p_glUniform1i);
            LoadFunction("glGetUniformBlockIndex", out p_glGetUniformBlockIndex);
            LoadFunction("glGetUniformLocation", out p_glGetUniformLocation);
            LoadFunction("glGetAttribLocation", out p_glGetAttribLocation);
            LoadFunction("glUseProgram", out p_glUseProgram);
            LoadFunction("glBindBufferRange", out p_glBindBufferRange);
            LoadFunction("glDebugMessageCallback", out p_glDebugMessageCallback);
            LoadFunction("glBufferData", out p_glBufferData);
            LoadFunction("glNamedBufferData", out p_glNamedBufferData);
            LoadFunction("glTexImage2D", out p_glTexImage2D);
            LoadFunction("glTexImage3D", out p_glTexImage3D);
            LoadFunction("glEnableVertexAttribArray", out p_glEnableVertexAttribArray);
            LoadFunction("glDisableVertexAttribArray", out p_glDisableVertexAttribArray);
            LoadFunction("glVertexAttribPointer", out p_glVertexAttribPointer);
            LoadFunction("glVertexAttribIPointer", out p_glVertexAttribIPointer);
            LoadFunction("glVertexAttribDivisor", out p_glVertexAttribDivisor);
            LoadFunction("glFrontFace", out p_glFrontFace);
            LoadFunction("glGetIntegerv", out p_glGetIntegerv);
            LoadFunction("glBindTextureUnit", out p_glBindTextureUnit);
            LoadFunction("glTexParameteri", out p_glTexParameteri);
            LoadFunction("glGetStringi", out p_glGetStringi);
            LoadFunction("glObjectLabel", out p_glObjectLabel);
            LoadFunction("glTexImage2DMultisample", out p_glTexImage2DMultisample);
            LoadFunction("glTexImage3DMultisample", out p_glTexImage3DMultisample);
            LoadFunction("glBlitFramebuffer", out p_glBlitFramebuffer);
            LoadFunction("glFramebufferTextureLayer", out p_glFramebufferTextureLayer);
            LoadFunction("glDispatchCompute", out p_glDispatchCompute);
            LoadFunction("glShaderStorageBlockBinding", out p_glShaderStorageBlockBinding);
            LoadFunction("glDrawElementsIndirect", out p_glDrawElementsIndirect);
            LoadFunction("glMultiDrawElementsIndirect", out p_glMultiDrawElementsIndirect);
            LoadFunction("glDrawArraysIndirect", out p_glDrawArraysIndirect);
            LoadFunction("glMultiDrawArraysIndirect", out p_glMultiDrawArraysIndirect);
            LoadFunction("glDispatchComputeIndirect", out p_glDispatchComputeIndirect);
            LoadFunction("glBindImageTexture", out p_glBindImageTexture);
            LoadFunction("glMemoryBarrier", out p_glMemoryBarrier);
            LoadFunction("glTexStorage1D", out p_glTexStorage1D);
            LoadFunction("glTexStorage2D", out p_glTexStorage2D);
            LoadFunction("glTexStorage3D", out p_glTexStorage3D);
            LoadFunction("glTextureStorage1D", out p_glTextureStorage1D);
            LoadFunction("glTextureStorage2D", out p_glTextureStorage2D);
            LoadFunction("glTextureStorage3D", out p_glTextureStorage3D);
            LoadFunction("glTextureStorage2DMultisample", out p_glTextureStorage2DMultisample);
            LoadFunction("glTextureStorage3DMultisample", out p_glTextureStorage3DMultisample);
            LoadFunction("glTexStorage2DMultisample", out p_glTexStorage2DMultisample);
            LoadFunction("glTexStorage3DMultisample", out p_glTexStorage3DMultisample);
            
            LoadFunction("glMapBuffer", out p_glMapBuffer);
            LoadFunction("glMapNamedBuffer", out p_glMapNamedBuffer);
            LoadFunction("glUnmapBuffer", out p_glUnmapBuffer);
            LoadFunction("glUnmapNamedBuffer", out p_glUnmapNamedBuffer);
            LoadFunction("glCopyBufferSubData", out p_glCopyBufferSubData);
            LoadFunction("glCopyTexSubImage2D", out p_glCopyTexSubImage2D);
            LoadFunction("glCopyTexSubImage3D", out p_glCopyTexSubImage3D);
            LoadFunction("glMapBufferRange", out p_glMapBufferRange);
            LoadFunction("glMapNamedBufferRange", out p_glMapNamedBufferRange);
            LoadFunction("glGetTextureSubImage", out p_glGetTextureSubImage);
            LoadFunction("glCopyNamedBufferSubData", out p_glCopyNamedBufferSubData);
            LoadFunction("glCreateBuffers", out p_glCreateBuffers);
            LoadFunction("glCreateTextures", out p_glCreateTextures);
            LoadFunction("glGenerateMipmap", out p_glGenerateMipmap);
            LoadFunction("glGetFramebufferAttachmentParameteriv", out p_glGetFramebufferAttachmentParameteriv);
            LoadFunction("glFlush", out p_glFlush);
            LoadFunction("glFinish", out p_glFinish);

            LoadFunction("glPushDebugGroup", out p_glPushDebugGroup);
            LoadFunction("glPopDebugGroup", out p_glPopDebugGroup);
            LoadFunction("glDebugMessageInsert", out p_glDebugMessageInsert);

            LoadFunction("glReadPixels", out p_glReadPixels);

            if (!gles)
            {
                LoadFunction("glFramebufferTexture1D", out p_glFramebufferTexture1D);
                LoadFunction("glGetTexImage", out p_glGetTexImage);
                LoadFunction("glPolygonMode", out p_glPolygonMode);
                LoadFunction("glViewportIndexedf", out p_glViewportIndexedf);
                LoadFunction("glCopyImageSubData", out p_glCopyImageSubData);
                LoadFunction("glTextureView", out p_glTextureView);
                LoadFunction("glGenerateTextureMipmap", out p_glGenerateTextureMipmap);
                LoadFunction("glClipControl", out p_glClipControl);
                LoadFunction("glDrawElementsInstancedBaseVertexBaseInstance", out p_glDrawElementsInstancedBaseVertexBaseInstance);
            }
            else
            {
                LoadFunction("glViewport", out p_glViewport);
                LoadFunction("glDepthRangef", out p_glDepthRangef);
                LoadFunction("glScissor", out p_glScissor);
                LoadFunction("glCopyImageSubData", out p_glCopyImageSubData);
                if (p_glCopyImageSubData == null)
                {
                    LoadFunction("glCopyImageSubDataOES", out p_glCopyImageSubData);
                }
                if (p_glCopyImageSubData == null)
                {
                    LoadFunction("glCopyImageSubDataEXT", out p_glCopyImageSubData);
                }

                LoadFunction("glTextureView", out p_glTextureView);
                if(p_glTextureView == null)
                {
                    LoadFunction("glTextureViewOES", out p_glTextureView);
                }

                LoadFunction("glRenderbufferStorage", out p_glRenderbufferStorage);
                LoadFunction("glFramebufferRenderbuffer", out p_glFramebufferRenderbuffer);
                LoadFunction("glGetRenderbufferParameteriv", out p_glGetRenderbufferParameteriv);
                LoadFunction("glGenRenderbuffers", out p_glGenRenderbuffers);
                LoadFunction("glBindRenderbuffer", out p_glBindRenderbuffer);
                LoadFunction("glInsertEventMarker", out p_glInsertEventMarker);
                LoadFunction("glPushGroupMarker", out p_glPushGroupMarker);
                LoadFunction("glPopGroupMarker", out p_glPopGroupMarker);
            }
        }

        /// <summary>
        /// Loads the function using the specified name
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="name">The name</param>
        /// <param name="field">The field</param>
        private static void LoadFunction<T>(string name, out T field)
        {
            IntPtr funcPtr = s_getProcAddress(name);
            if (funcPtr != IntPtr.Zero)
            {
                field = Marshal.GetDelegateForFunctionPointer<T>(funcPtr);
            }
            else
            {
                field = default(T);
            }
        }

        /// <summary>
        /// Loads the function using the specified field
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="field">The field</param>
        private static void LoadFunction<T>(out T field)
        {
            // Slow version using reflection -- prefer above.
            string name = typeof(T).Name;
            name = name.Substring(0, name.Length - 2); // Remove _t
            LoadFunction(name, out field);
        }
    }
}
