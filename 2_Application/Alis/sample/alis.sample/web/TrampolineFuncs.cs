using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Silk.NET.OpenGLES;

namespace Alis.Sample.Web
{
    /// <summary>
    /// The trampoline funcs class
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "OpenGL names")]
    internal unsafe static class TrampolineFuncs
    {
        /// <summary>
        /// Applies the workaround fixing invocations
        /// </summary>
        [DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(TrampolineFuncs))]
        public static void ApplyWorkaroundFixingInvocations()
        {
            // this function needs to be here, else the trampolines below get trimmed
        }

        /// <summary>
        /// The glcullface
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCullFace_t(TriangleFace mode);
        /// <summary>
        /// The glfrontface
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glFrontFace_t(FrontFaceDirection mode);
        /// <summary>
        /// The glhint
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glHint_t(HintTarget target, HintMode mode);
        /// <summary>
        /// The gllinewidth
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glLineWidth_t(float width);
        /// <summary>
        /// The glpointsize
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glPointSize_t(float size);
        /// <summary>
        /// The glpolygonmode
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glPolygonMode_t(GLEnum face, PolygonMode mode);
        /// <summary>
        /// The glscissor
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glScissor_t(int x, int y, int width, int height);
        /// <summary>
        /// The gltexparameterf
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexParameterf_t(TextureTarget target, TextureParameterName pname, float param);
        /// <summary>
        /// The gltexparameterfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexParameterfv_t(TextureTarget target, TextureParameterName pname, float* @params);
        /// <summary>
        /// The gltexparameteri
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexParameteri_t(TextureTarget target, TextureParameterName pname, int param);
        /// <summary>
        /// The gltexparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexParameteriv_t(TextureTarget target, TextureParameterName pname, int* @params);
        /// <summary>
        /// The glteximage1d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexImage1D_t(TextureTarget target, int level, int internalformat, int width, int border, PixelFormat format, PixelType type, void* pixels);
        /// <summary>
        /// The glteximage2d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexImage2D_t(TextureTarget target, int level, int internalformat, int width, int height, int border, PixelFormat format, PixelType type, void* pixels);
        /// <summary>
        /// The gldrawbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawBuffer_t(DrawBufferMode buf);
        /// <summary>
        /// The glclear
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClear_t(uint mask);
        /// <summary>
        /// The glclearcolor
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearColor_t(float red, float green, float blue, float alpha);
        /// <summary>
        /// The glclearstencil
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearStencil_t(int s);
        /// <summary>
        /// The glcleardepth
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearDepth_t(double depth);
        /// <summary>
        /// The glstencilmask
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glStencilMask_t(uint mask);
        /// <summary>
        /// The glcolormask
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glColorMask_t(bool red, bool green, bool blue, bool alpha);
        /// <summary>
        /// The gldepthmask
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDepthMask_t(bool flag);
        /// <summary>
        /// The gldisable
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDisable_t(EnableCap cap);
        /// <summary>
        /// The glenable
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glEnable_t(EnableCap cap);
        /// <summary>
        /// The glfinish
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glFinish_t();
        /// <summary>
        /// The glflush
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glFlush_t();
        /// <summary>
        /// The glblendfunc
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBlendFunc_t(BlendingFactor sfactor, BlendingFactor dfactor);
        /// <summary>
        /// The gllogicop
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glLogicOp_t(LogicOp opcode);
        /// <summary>
        /// The glstencilfunc
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glStencilFunc_t(StencilFunction func, int @ref, uint mask);
        /// <summary>
        /// The glstencilop
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glStencilOp_t(StencilOp fail, StencilOp zfail, StencilOp zpass);
        /// <summary>
        /// The gldepthfunc
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDepthFunc_t(DepthFunction func);
        /// <summary>
        /// The glpixelstoref
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glPixelStoref_t(PixelStoreParameter pname, float param);
        /// <summary>
        /// The glpixelstorei
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glPixelStorei_t(PixelStoreParameter pname, int param);
        /// <summary>
        /// The glreadbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glReadBuffer_t(ReadBufferMode src);
        /// <summary>
        /// The glreadpixels
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glReadPixels_t(int x, int y, int width, int height, PixelFormat format, PixelType type, void* pixels);
        /// <summary>
        /// The glgetbooleanv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetBooleanv_t(GetPName pname, bool* data);
        /// <summary>
        /// The glgetdoublev
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetDoublev_t(GetPName pname, double* data);
        /// <summary>
        /// The glgeterror
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate ErrorCode glGetError_t();
        /// <summary>
        /// The glgetfloatv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetFloatv_t(GetPName pname, float* data);
        /// <summary>
        /// The glgetintegerv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetIntegerv_t(GetPName pname, int* data);
        /// <summary>
        /// The glgetstring
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* glGetString_t(StringName name);
        /// <summary>
        /// The glgetteximage
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTexImage_t(TextureTarget target, int level, PixelFormat format, PixelType type, void* pixels);
        /// <summary>
        /// The glgettexparameterfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTexParameterfv_t(TextureTarget target, GetTextureParameter pname, float* @params);
        /// <summary>
        /// The glgettexparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTexParameteriv_t(TextureTarget target, GetTextureParameter pname, int* @params);
        /// <summary>
        /// The glgettexlevelparameterfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTexLevelParameterfv_t(TextureTarget target, int level, GetTextureParameter pname, float* @params);
        /// <summary>
        /// The glgettexlevelparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTexLevelParameteriv_t(TextureTarget target, int level, GetTextureParameter pname, int* @params);
        /// <summary>
        /// The glisenabled
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool glIsEnabled_t(EnableCap cap);
        /// <summary>
        /// The gldepthrange
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDepthRange_t(double n, double f);
        /// <summary>
        /// The glviewport
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glViewport_t(int x, int y, int width, int height);
        /// <summary>
        /// The gldrawarrays
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawArrays_t(PrimitiveType mode, int first, int count);
        /// <summary>
        /// The gldrawelements
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawElements_t(PrimitiveType mode, int count, DrawElementsType type, void* indices);
        /// <summary>
        /// The glpolygonoffset
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glPolygonOffset_t(float factor, float units);
        /// <summary>
        /// The glcopyteximage1d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCopyTexImage1D_t(TextureTarget target, int level, InternalFormat internalformat, int x, int y, int width, int border);
        /// <summary>
        /// The glcopyteximage2d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCopyTexImage2D_t(TextureTarget target, int level, InternalFormat internalformat, int x, int y, int width, int height, int border);
        /// <summary>
        /// The glcopytexsubimage1d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCopyTexSubImage1D_t(TextureTarget target, int level, int xoffset, int x, int y, int width);
        /// <summary>
        /// The glcopytexsubimage2d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCopyTexSubImage2D_t(TextureTarget target, int level, int xoffset, int yoffset, int x, int y, int width, int height);
        /// <summary>
        /// The gltexsubimage1d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexSubImage1D_t(TextureTarget target, int level, int xoffset, int width, PixelFormat format, PixelType type, void* pixels);
        /// <summary>
        /// The gltexsubimage2d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexSubImage2D_t(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, void* pixels);
        /// <summary>
        /// The glbindtexture
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindTexture_t(TextureTarget target, uint texture);
        /// <summary>
        /// The gldeletetextures
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDeleteTextures_t(int n, uint* textures);
        /// <summary>
        /// The glgentextures
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGenTextures_t(int n, uint* textures);
        /// <summary>
        /// The glistexture
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool glIsTexture_t(uint texture);
        /// <summary>
        /// The gldrawrangeelements
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawRangeElements_t(PrimitiveType mode, uint start, uint end, int count, DrawElementsType type, void* indices);
        /// <summary>
        /// The glteximage3d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexImage3D_t(TextureTarget target, int level, int internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, void* pixels);
        /// <summary>
        /// The gltexsubimage3d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexSubImage3D_t(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, void* pixels);
        /// <summary>
        /// The glcopytexsubimage3d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCopyTexSubImage3D_t(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height);
        /// <summary>
        /// The glactivetexture
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glActiveTexture_t(TextureUnit texture);
        /// <summary>
        /// The glsamplecoverage
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glSampleCoverage_t(float value, bool invert);
        /// <summary>
        /// The glcompressedteximage3d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCompressedTexImage3D_t(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, int imageSize, void* data);
        /// <summary>
        /// The glcompressedteximage2d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCompressedTexImage2D_t(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, int imageSize, void* data);
        /// <summary>
        /// The glcompressedteximage1d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCompressedTexImage1D_t(TextureTarget target, int level, InternalFormat internalformat, int width, int border, int imageSize, void* data);
        /// <summary>
        /// The glcompressedtexsubimage3d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCompressedTexSubImage3D_t(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, int imageSize, void* data);
        /// <summary>
        /// The glcompressedtexsubimage2d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCompressedTexSubImage2D_t(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, void* data);
        /// <summary>
        /// The glcompressedtexsubimage1d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCompressedTexSubImage1D_t(TextureTarget target, int level, int xoffset, int width, PixelFormat format, int imageSize, void* data);
        /// <summary>
        /// The glgetcompressedteximage
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetCompressedTexImage_t(TextureTarget target, int level, void* img);
        /// <summary>
        /// The glblendfuncseparate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBlendFuncSeparate_t(BlendingFactor sfactorRGB, BlendingFactor dfactorRGB, BlendingFactor sfactorAlpha, BlendingFactor dfactorAlpha);
        /// <summary>
        /// The glmultidrawarrays
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMultiDrawArrays_t(PrimitiveType mode, int* first, int* count, int drawcount);
        /// <summary>
        /// The glmultidrawelements
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMultiDrawElements_t(PrimitiveType mode, int* count, DrawElementsType type, IntPtr indices, int drawcount);
        /// <summary>
        /// The glpointparameterf
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glPointParameterf_t(uint pname, float param);
        /// <summary>
        /// The glpointparameterfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glPointParameterfv_t(uint pname, float* @params);
        /// <summary>
        /// The glpointparameteri
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glPointParameteri_t(uint pname, int param);
        /// <summary>
        /// The glpointparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glPointParameteriv_t(uint pname, int* @params);
        /// <summary>
        /// The glblendcolor
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBlendColor_t(float red, float green, float blue, float alpha);
        /// <summary>
        /// The glblendequation
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBlendEquation_t(BlendEquationModeEXT mode);
        /// <summary>
        /// The glgenqueries
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGenQueries_t(int n, uint* ids);
        /// <summary>
        /// The gldeletequeries
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDeleteQueries_t(int n, uint* ids);
        /// <summary>
        /// The glisquery
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool glIsQuery_t(uint id);
        /// <summary>
        /// The glbeginquery
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBeginQuery_t(QueryTarget target, uint id);
        /// <summary>
        /// The glendquery
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glEndQuery_t(QueryTarget target);
        /// <summary>
        /// The glgetqueryiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetQueryiv_t(QueryTarget target, QueryParameterName pname, int* @params);
        /// <summary>
        /// The glgetqueryobjectiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetQueryObjectiv_t(uint id, QueryObjectParameterName pname, int* @params);
        /// <summary>
        /// The glgetqueryobjectuiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetQueryObjectuiv_t(uint id, QueryObjectParameterName pname, uint* @params);
        /// <summary>
        /// The glbindbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindBuffer_t(BufferTargetARB target, uint buffer);
        /// <summary>
        /// The gldeletebuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDeleteBuffers_t(int n, uint* buffers);
        /// <summary>
        /// The glgenbuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGenBuffers_t(int n, uint* buffers);
        /// <summary>
        /// The glisbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool glIsBuffer_t(uint buffer);
        /// <summary>
        /// The glbufferdata
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBufferData_t(BufferTargetARB target, int size, void* data, BufferUsageARB usage);
        /// <summary>
        /// The glbuffersubdata
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBufferSubData_t(BufferTargetARB target, IntPtr offset, int size, void* data);
        /// <summary>
        /// The glgetbuffersubdata
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetBufferSubData_t(BufferTargetARB target, IntPtr offset, int size, void* data);
        /// <summary>
        /// The glmapbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void* glMapBuffer_t(BufferTargetARB target, BufferAccessARB access);
        /// <summary>
        /// The glunmapbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool glUnmapBuffer_t(BufferTargetARB target);
        /// <summary>
        /// The glgetbufferparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetBufferParameteriv_t(BufferTargetARB target, uint pname, int* @params);
        /// <summary>
        /// The glgetbufferpointerv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetBufferPointerv_t(BufferTargetARB target, uint pname, void** @params);
        /// <summary>
        /// The glblendequationseparate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBlendEquationSeparate_t(BlendEquationModeEXT modeRGB, BlendEquationModeEXT modeAlpha);
        /// <summary>
        /// The gldrawbuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawBuffers_t(int n, uint* bufs);
        /// <summary>
        /// The glstencilopseparate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glStencilOpSeparate_t(GLEnum face, StencilOp sfail, StencilOp dpfail, StencilOp dppass);
        /// <summary>
        /// The glstencilfuncseparate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glStencilFuncSeparate_t(GLEnum face, StencilFunction func, int @ref, uint mask);
        /// <summary>
        /// The glstencilmaskseparate
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glStencilMaskSeparate_t(GLEnum face, uint mask);
        /// <summary>
        /// The glattachshader
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glAttachShader_t(uint program, uint shader);
        /// <summary>
        /// The glbindattriblocation
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindAttribLocation_t(uint program, uint index, char* name);
        /// <summary>
        /// The glcompileshader
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCompileShader_t(uint shader);
        /// <summary>
        /// The glcreateprogram
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint glCreateProgram_t();
        /// <summary>
        /// The glcreateshader
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint glCreateShader_t(ShaderType type);
        /// <summary>
        /// The gldeleteprogram
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDeleteProgram_t(uint program);
        /// <summary>
        /// The gldeleteshader
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDeleteShader_t(uint shader);
        /// <summary>
        /// The gldetachshader
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDetachShader_t(uint program, uint shader);
        /// <summary>
        /// The gldisablevertexattribarray
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDisableVertexAttribArray_t(uint index);
        /// <summary>
        /// The glenablevertexattribarray
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glEnableVertexAttribArray_t(uint index);
        /// <summary>
        /// The glgetactiveattrib
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetActiveAttrib_t(uint program, uint index, int bufSize, int* length, int* size, uint* type, char* name);
        /// <summary>
        /// The glgetactiveuniform
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetActiveUniform_t(uint program, uint index, int bufSize, int* length, int* size, uint* type, char* name);
        /// <summary>
        /// The glgetattachedshaders
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetAttachedShaders_t(uint program, int maxCount, int* count, uint* shaders);
        /// <summary>
        /// The glgetattriblocation
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int glGetAttribLocation_t(uint program, char* name);
        /// <summary>
        /// The glgetprogramiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetProgramiv_t(uint program, ProgramPropertyARB pname, int* @params);
        /// <summary>
        /// The glgetprograminfolog
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetProgramInfoLog_t(uint program, int bufSize, int* length, char* infoLog);
        /// <summary>
        /// The glgetshaderiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetShaderiv_t(uint shader, ShaderParameterName pname, int* @params);
        /// <summary>
        /// The glgetshaderinfolog
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetShaderInfoLog_t(uint shader, int bufSize, int* length, char* infoLog);
        /// <summary>
        /// The glgetshadersource
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetShaderSource_t(uint shader, int bufSize, int* length, char* source);
        /// <summary>
        /// The glgetuniformlocation
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int glGetUniformLocation_t(uint program, char* name);
        /// <summary>
        /// The glgetuniformfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetUniformfv_t(uint program, int location, float* @params);
        /// <summary>
        /// The glgetuniformiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetUniformiv_t(uint program, int location, int* @params);
        /// <summary>
        /// The glgetvertexattribdv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetVertexAttribdv_t(uint index, uint pname, double* @params);
        /// <summary>
        /// The glgetvertexattribfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetVertexAttribfv_t(uint index, uint pname, float* @params);
        /// <summary>
        /// The glgetvertexattribiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetVertexAttribiv_t(uint index, uint pname, int* @params);
        /// <summary>
        /// The glgetvertexattribpointerv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetVertexAttribPointerv_t(uint index, uint pname, void** pointer);
        /// <summary>
        /// The glisprogram
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool glIsProgram_t(uint program);
        /// <summary>
        /// The glisshader
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool glIsShader_t(uint shader);
        /// <summary>
        /// The gllinkprogram
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glLinkProgram_t(uint program);
        /// <summary>
        /// The glshadersource
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glShaderSource_t(uint shader, int count, IntPtr @string, int* length);
        /// <summary>
        /// The gluseprogram
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUseProgram_t(uint program);
        /// <summary>
        /// The gluniform1f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform1f_t(int location, float v0);
        /// <summary>
        /// The gluniform2f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform2f_t(int location, float v0, float v1);
        /// <summary>
        /// The gluniform3f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform3f_t(int location, float v0, float v1, float v2);
        /// <summary>
        /// The gluniform4f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform4f_t(int location, float v0, float v1, float v2, float v3);
        /// <summary>
        /// The gluniform1i
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform1i_t(int location, int v0);
        /// <summary>
        /// The gluniform2i
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform2i_t(int location, int v0, int v1);
        /// <summary>
        /// The gluniform3i
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform3i_t(int location, int v0, int v1, int v2);
        /// <summary>
        /// The gluniform4i
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform4i_t(int location, int v0, int v1, int v2, int v3);
        /// <summary>
        /// The gluniform1fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform1fv_t(int location, int count, float* value);
        /// <summary>
        /// The gluniform2fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform2fv_t(int location, int count, float* value);
        /// <summary>
        /// The gluniform3fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform3fv_t(int location, int count, float* value);
        /// <summary>
        /// The gluniform4fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform4fv_t(int location, int count, float* value);
        /// <summary>
        /// The gluniform1iv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform1iv_t(int location, int count, int* value);
        /// <summary>
        /// The gluniform2iv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform2iv_t(int location, int count, int* value);
        /// <summary>
        /// The gluniform3iv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform3iv_t(int location, int count, int* value);
        /// <summary>
        /// The gluniform4iv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform4iv_t(int location, int count, int* value);
        /// <summary>
        /// The gluniformmatrix2fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix2fv_t(int location, int count, bool transpose, float* value);
        /// <summary>
        /// The gluniformmatrix3fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix3fv_t(int location, int count, bool transpose, float* value);
        /// <summary>
        /// The gluniformmatrix4fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix4fv_t(int location, int count, bool transpose, float* value);
        /// <summary>
        /// The glvalidateprogram
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glValidateProgram_t(uint program);
        /// <summary>
        /// The glvertexattrib1d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib1d_t(uint index, double x);
        /// <summary>
        /// The glvertexattrib1dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib1dv_t(uint index, double* v);
        /// <summary>
        /// The glvertexattrib1f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib1f_t(uint index, float x);
        /// <summary>
        /// The glvertexattrib1fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib1fv_t(uint index, float* v);
        /// <summary>
        /// The glvertexattrib1s
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib1s_t(uint index, short x);
        /// <summary>
        /// The glvertexattrib1sv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib1sv_t(uint index, short* v);
        /// <summary>
        /// The glvertexattrib2d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib2d_t(uint index, double x, double y);
        /// <summary>
        /// The glvertexattrib2dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib2dv_t(uint index, double* v);
        /// <summary>
        /// The glvertexattrib2f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib2f_t(uint index, float x, float y);
        /// <summary>
        /// The glvertexattrib2fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib2fv_t(uint index, float* v);
        /// <summary>
        /// The glvertexattrib2s
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib2s_t(uint index, short x, short y);
        /// <summary>
        /// The glvertexattrib2sv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib2sv_t(uint index, short* v);
        /// <summary>
        /// The glvertexattrib3d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib3d_t(uint index, double x, double y, double z);
        /// <summary>
        /// The glvertexattrib3dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib3dv_t(uint index, double* v);
        /// <summary>
        /// The glvertexattrib3f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib3f_t(uint index, float x, float y, float z);
        /// <summary>
        /// The glvertexattrib3fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib3fv_t(uint index, float* v);
        /// <summary>
        /// The glvertexattrib3s
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib3s_t(uint index, short x, short y, short z);
        /// <summary>
        /// The glvertexattrib3sv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib3sv_t(uint index, short* v);
        /// <summary>
        /// The glvertexattrib4nbv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4Nbv_t(uint index, byte* v);
        /// <summary>
        /// The glvertexattrib4niv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4Niv_t(uint index, int* v);
        /// <summary>
        /// The glvertexattrib4nsv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4Nsv_t(uint index, short* v);
        /// <summary>
        /// The glvertexattrib4nub
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4Nub_t(uint index, byte x, byte y, byte z, byte w);
        /// <summary>
        /// The glvertexattrib4nubv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4Nubv_t(uint index, byte* v);
        /// <summary>
        /// The glvertexattrib4nuiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4Nuiv_t(uint index, uint* v);
        /// <summary>
        /// The glvertexattrib4nusv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4Nusv_t(uint index, short* v);
        /// <summary>
        /// The glvertexattrib4bv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4bv_t(uint index, byte* v);
        /// <summary>
        /// The glvertexattrib4d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4d_t(uint index, double x, double y, double z, double w);
        /// <summary>
        /// The glvertexattrib4dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4dv_t(uint index, double* v);
        /// <summary>
        /// The glvertexattrib4f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4f_t(uint index, float x, float y, float z, float w);
        /// <summary>
        /// The glvertexattrib4fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4fv_t(uint index, float* v);
        /// <summary>
        /// The glvertexattrib4iv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4iv_t(uint index, int* v);
        /// <summary>
        /// The glvertexattrib4s
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4s_t(uint index, short x, short y, short z, short w);
        /// <summary>
        /// The glvertexattrib4sv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4sv_t(uint index, short* v);
        /// <summary>
        /// The glvertexattrib4ubv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4ubv_t(uint index, byte* v);
        /// <summary>
        /// The glvertexattrib4uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4uiv_t(uint index, uint* v);
        /// <summary>
        /// The glvertexattrib4usv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttrib4usv_t(uint index, short* v);
        /// <summary>
        /// The glvertexattribpointer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribPointer_t(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, void* pointer);
        /// <summary>
        /// The gluniformmatrix2x3fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix2x3fv_t(int location, int count, bool transpose, float* value);
        /// <summary>
        /// The gluniformmatrix3x2fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix3x2fv_t(int location, int count, bool transpose, float* value);
        /// <summary>
        /// The gluniformmatrix2x4fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix2x4fv_t(int location, int count, bool transpose, float* value);
        /// <summary>
        /// The gluniformmatrix4x2fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix4x2fv_t(int location, int count, bool transpose, float* value);
        /// <summary>
        /// The gluniformmatrix3x4fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix3x4fv_t(int location, int count, bool transpose, float* value);
        /// <summary>
        /// The gluniformmatrix4x3fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix4x3fv_t(int location, int count, bool transpose, float* value);
        /// <summary>
        /// The glcolormaski
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glColorMaski_t(uint index, bool r, bool g, bool b, bool a);
        /// <summary>
        /// The glgetbooleani
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetBooleani_v_t(BufferTargetARB target, uint index, bool* data);
        /// <summary>
        /// The glgetintegeri
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetIntegeri_v_t(GLEnum target, uint index, int* data);
        /// <summary>
        /// The glenablei
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glEnablei_t(EnableCap target, uint index);
        /// <summary>
        /// The gldisablei
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDisablei_t(EnableCap target, uint index);
        /// <summary>
        /// The glisenabledi
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool glIsEnabledi_t(EnableCap target, uint index);
        /// <summary>
        /// The glbegintransformfeedback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBeginTransformFeedback_t(PrimitiveType primitiveMode);
        /// <summary>
        /// The glendtransformfeedback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glEndTransformFeedback_t();
        /// <summary>
        /// The glbindbufferrange
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindBufferRange_t(BufferTargetARB target, uint index, uint buffer, IntPtr offset, int size);
        /// <summary>
        /// The glbindbufferbase
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindBufferBase_t(BufferTargetARB target, uint index, uint buffer);
        /// <summary>
        /// The gltransformfeedbackvaryings
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTransformFeedbackVaryings_t(uint program, int count, IntPtr varyings, uint bufferMode);
        /// <summary>
        /// The glgettransformfeedbackvarying
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTransformFeedbackVarying_t(uint program, uint index, int bufSize, int* length, int* size, uint* type, char* name);
        /// <summary>
        /// The glclampcolor
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClampColor_t(uint target, uint clamp);
        /// <summary>
        /// The glbeginconditionalrender
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBeginConditionalRender_t(uint id, GLEnum mode);
        /// <summary>
        /// The glendconditionalrender
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glEndConditionalRender_t();
        /// <summary>
        /// The glvertexattribipointer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribIPointer_t(uint index, int size, VertexAttribPointerType type, int stride, void* pointer);
        /// <summary>
        /// The glgetvertexattribiiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetVertexAttribIiv_t(uint index, VertexAttribEnum pname, int* @params);
        /// <summary>
        /// The glgetvertexattribiuiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetVertexAttribIuiv_t(uint index, VertexAttribEnum pname, uint* @params);
        /// <summary>
        /// The glvertexattribi1i
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI1i_t(uint index, int x);
        /// <summary>
        /// The glvertexattribi2i
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI2i_t(uint index, int x, int y);
        /// <summary>
        /// The glvertexattribi3i
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI3i_t(uint index, int x, int y, int z);
        /// <summary>
        /// The glvertexattribi4i
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI4i_t(uint index, int x, int y, int z, int w);
        /// <summary>
        /// The glvertexattribi1ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI1ui_t(uint index, uint x);
        /// <summary>
        /// The glvertexattribi2ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI2ui_t(uint index, uint x, uint y);
        /// <summary>
        /// The glvertexattribi3ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI3ui_t(uint index, uint x, uint y, uint z);
        /// <summary>
        /// The glvertexattribi4ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI4ui_t(uint index, uint x, uint y, uint z, uint w);
        /// <summary>
        /// The glvertexattribi1iv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI1iv_t(uint index, int* v);
        /// <summary>
        /// The glvertexattribi2iv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI2iv_t(uint index, int* v);
        /// <summary>
        /// The glvertexattribi3iv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI3iv_t(uint index, int* v);
        /// <summary>
        /// The glvertexattribi4iv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI4iv_t(uint index, int* v);
        /// <summary>
        /// The glvertexattribi1uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI1uiv_t(uint index, uint* v);
        /// <summary>
        /// The glvertexattribi2uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI2uiv_t(uint index, uint* v);
        /// <summary>
        /// The glvertexattribi3uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI3uiv_t(uint index, uint* v);
        /// <summary>
        /// The glvertexattribi4uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI4uiv_t(uint index, uint* v);
        /// <summary>
        /// The glvertexattribi4bv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI4bv_t(uint index, byte* v);
        /// <summary>
        /// The glvertexattribi4sv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI4sv_t(uint index, short* v);
        /// <summary>
        /// The glvertexattribi4ubv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI4ubv_t(uint index, byte* v);
        /// <summary>
        /// The glvertexattribi4usv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribI4usv_t(uint index, short* v);
        /// <summary>
        /// The glgetuniformuiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetUniformuiv_t(uint program, int location, uint* @params);
        /// <summary>
        /// The glbindfragdatalocation
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindFragDataLocation_t(uint program, uint color, char* name);
        /// <summary>
        /// The glgetfragdatalocation
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int glGetFragDataLocation_t(uint program, char* name);
        /// <summary>
        /// The gluniform1ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform1ui_t(int location, uint v0);
        /// <summary>
        /// The gluniform2ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform2ui_t(int location, uint v0, uint v1);
        /// <summary>
        /// The gluniform3ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform3ui_t(int location, uint v0, uint v1, uint v2);
        /// <summary>
        /// The gluniform4ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform4ui_t(int location, uint v0, uint v1, uint v2, uint v3);
        /// <summary>
        /// The gluniform1uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform1uiv_t(int location, int count, uint* value);
        /// <summary>
        /// The gluniform2uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform2uiv_t(int location, int count, uint* value);
        /// <summary>
        /// The gluniform3uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform3uiv_t(int location, int count, uint* value);
        /// <summary>
        /// The gluniform4uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform4uiv_t(int location, int count, uint* value);
        /// <summary>
        /// The gltexparameteriiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexParameterIiv_t(TextureTarget target, TextureParameterName pname, int* @params);
        /// <summary>
        /// The gltexparameteriuiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexParameterIuiv_t(TextureTarget target, TextureParameterName pname, uint* @params);
        /// <summary>
        /// The glgettexparameteriiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTexParameterIiv_t(TextureTarget target, GetTextureParameter pname, int* @params);
        /// <summary>
        /// The glgettexparameteriuiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTexParameterIuiv_t(TextureTarget target, GetTextureParameter pname, uint* @params);
        /// <summary>
        /// The glclearbufferiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearBufferiv_t(GLEnum buffer, int drawbuffer, int* value);
        /// <summary>
        /// The glclearbufferuiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearBufferuiv_t(GLEnum buffer, int drawbuffer, uint* value);
        /// <summary>
        /// The glclearbufferfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearBufferfv_t(GLEnum buffer, int drawbuffer, float* value);
        /// <summary>
        /// The glclearbufferfi
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearBufferfi_t(GLEnum buffer, int drawbuffer, float depth, int stencil);
        /// <summary>
        /// The glgetstringi
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte* glGetStringi_t(StringName name, uint index);
        /// <summary>
        /// The glisrenderbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool glIsRenderbuffer_t(uint renderbuffer);
        /// <summary>
        /// The glbindrenderbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindRenderbuffer_t(RenderbufferTarget target, uint renderbuffer);
        /// <summary>
        /// The gldeleterenderbuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDeleteRenderbuffers_t(int n, uint* renderbuffers);
        /// <summary>
        /// The glgenrenderbuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGenRenderbuffers_t(int n, uint* renderbuffers);
        /// <summary>
        /// The glrenderbufferstorage
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glRenderbufferStorage_t(RenderbufferTarget target, InternalFormat internalformat, int width, int height);
        /// <summary>
        /// The glgetrenderbufferparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetRenderbufferParameteriv_t(RenderbufferTarget target, RenderbufferParameterName pname, int* @params);
        /// <summary>
        /// The glisframebuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool glIsFramebuffer_t(uint framebuffer);
        /// <summary>
        /// The glbindframebuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindFramebuffer_t(FramebufferTarget target, uint framebuffer);
        /// <summary>
        /// The gldeleteframebuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDeleteFramebuffers_t(int n, uint* framebuffers);
        /// <summary>
        /// The glgenframebuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGenFramebuffers_t(int n, uint* framebuffers);
        /// <summary>
        /// The glcheckframebufferstatus
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate FramebufferStatus glCheckFramebufferStatus_t(FramebufferTarget target);
        /// <summary>
        /// The glframebuffertexture1d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glFramebufferTexture1D_t(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, uint texture, int level);
        /// <summary>
        /// The glframebuffertexture2d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glFramebufferTexture2D_t(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, uint texture, int level);
        /// <summary>
        /// The glframebuffertexture3d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glFramebufferTexture3D_t(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, uint texture, int level, int zoffset);
        /// <summary>
        /// The glframebufferrenderbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glFramebufferRenderbuffer_t(FramebufferTarget target, FramebufferAttachment attachment, RenderbufferTarget renderbuffertarget, uint renderbuffer);
        /// <summary>
        /// The glgetframebufferattachmentparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetFramebufferAttachmentParameteriv_t(FramebufferTarget target, FramebufferAttachment attachment, FramebufferAttachmentParameterName pname, int* @params);
        /// <summary>
        /// The glgeneratemipmap
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGenerateMipmap_t(TextureTarget target);
        /// <summary>
        /// The glblitframebuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBlitFramebuffer_t(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, BlitFramebufferFilter filter);
        /// <summary>
        /// The glrenderbufferstoragemultisample
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glRenderbufferStorageMultisample_t(RenderbufferTarget target, int samples, InternalFormat internalformat, int width, int height);
        /// <summary>
        /// The glframebuffertexturelayer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glFramebufferTextureLayer_t(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level, int layer);
        /// <summary>
        /// The glmapbufferrange
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void* glMapBufferRange_t(BufferTargetARB target, IntPtr offset, int length, uint access);
        /// <summary>
        /// The glflushmappedbufferrange
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glFlushMappedBufferRange_t(BufferTargetARB target, IntPtr offset, int length);
        /// <summary>
        /// The glbindvertexarray
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindVertexArray_t(uint array);
        /// <summary>
        /// The gldeletevertexarrays
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDeleteVertexArrays_t(int n, uint* arrays);
        /// <summary>
        /// The glgenvertexarrays
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGenVertexArrays_t(int n, uint* arrays);
        /// <summary>
        /// The glisvertexarray
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool glIsVertexArray_t(uint array);
        /// <summary>
        /// The gldrawarraysinstanced
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawArraysInstanced_t(PrimitiveType mode, int first, int count, int instancecount);
        /// <summary>
        /// The gldrawelementsinstanced
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawElementsInstanced_t(PrimitiveType mode, int count, DrawElementsType type, void* indices, int instancecount);
        /// <summary>
        /// The gltexbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexBuffer_t(TextureTarget target, InternalFormat internalformat, uint buffer);
        /// <summary>
        /// The glprimitiverestartindex
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glPrimitiveRestartIndex_t(uint index);
        /// <summary>
        /// The glcopybuffersubdata
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCopyBufferSubData_t(CopyBufferSubDataTarget readTarget, CopyBufferSubDataTarget writeTarget, IntPtr readOffset, IntPtr writeOffset, int size);
        /// <summary>
        /// The glgetuniformindices
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetUniformIndices_t(uint program, int uniformCount, IntPtr uniformNames, uint* uniformIndices);
        /// <summary>
        /// The glgetactiveuniformsiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetActiveUniformsiv_t(uint program, int uniformCount, uint* uniformIndices, UniformPName pname, int* @params);
        /// <summary>
        /// The glgetactiveuniformname
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetActiveUniformName_t(uint program, uint uniformIndex, int bufSize, int* length, char* uniformName);
        /// <summary>
        /// The glgetuniformblockindex
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint glGetUniformBlockIndex_t(uint program, char* uniformBlockName);
        /// <summary>
        /// The glgetactiveuniformblockiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetActiveUniformBlockiv_t(uint program, uint uniformBlockIndex, UniformBlockPName pname, int* @params);
        /// <summary>
        /// The glgetactiveuniformblockname
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetActiveUniformBlockName_t(uint program, uint uniformBlockIndex, int bufSize, int* length, char* uniformBlockName);
        /// <summary>
        /// The gluniformblockbinding
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformBlockBinding_t(uint program, uint uniformBlockIndex, uint uniformBlockBinding);
        /// <summary>
        /// The gldrawelementsbasevertex
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawElementsBaseVertex_t(PrimitiveType mode, int count, DrawElementsType type, void* indices, int basevertex);
        /// <summary>
        /// The gldrawrangeelementsbasevertex
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawRangeElementsBaseVertex_t(PrimitiveType mode, uint start, uint end, int count, DrawElementsType type, void* indices, int basevertex);
        /// <summary>
        /// The gldrawelementsinstancedbasevertex
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawElementsInstancedBaseVertex_t(PrimitiveType mode, int count, DrawElementsType type, void* indices, int instancecount, int basevertex);
        /// <summary>
        /// The glmultidrawelementsbasevertex
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMultiDrawElementsBaseVertex_t(PrimitiveType mode, int* count, DrawElementsType type, IntPtr indices, int drawcount, int* basevertex);
        /// <summary>
        /// The glprovokingvertex
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProvokingVertex_t(VertexProvokingMode mode);
        /// <summary>
        /// The glfencesync
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr glFenceSync_t(SyncCondition condition, uint flags);
        /// <summary>
        /// The glissync
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool glIsSync_t(IntPtr sync);
        /// <summary>
        /// The gldeletesync
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDeleteSync_t(IntPtr sync);
        /// <summary>
        /// The glclientwaitsync
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate SyncStatus glClientWaitSync_t(IntPtr sync, uint flags, ulong timeout);
        /// <summary>
        /// The glwaitsync
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glWaitSync_t(IntPtr sync, uint flags, ulong timeout);
        /// <summary>
        /// The glgetinteger64v
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetInteger64v_t(GetPName pname, long* data);
        /// <summary>
        /// The glgetsynciv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetSynciv_t(IntPtr sync, SyncParameterName pname, int bufSize, int* length, int* values);
        /// <summary>
        /// The glgetinteger64i
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetInteger64i_v_t(GLEnum target, uint index, long* data);
        /// <summary>
        /// The glgetbufferparameteri64v
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetBufferParameteri64v_t(BufferTargetARB target, uint pname, long* @params);
        /// <summary>
        /// The glframebuffertexture
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glFramebufferTexture_t(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level);
        /// <summary>
        /// The glteximage2dmultisample
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexImage2DMultisample_t(TextureTarget target, int samples, InternalFormat internalformat, int width, int height, bool fixedsamplelocations);
        /// <summary>
        /// The glteximage3dmultisample
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexImage3DMultisample_t(TextureTarget target, int samples, InternalFormat internalformat, int width, int height, int depth, bool fixedsamplelocations);
        /// <summary>
        /// The glgetmultisamplefv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetMultisamplefv_t(uint pname, uint index, float* val);
        /// <summary>
        /// The glsamplemaski
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glSampleMaski_t(uint maskNumber, uint mask);
        /// <summary>
        /// The glbindfragdatalocationindexed
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindFragDataLocationIndexed_t(uint program, uint colorNumber, uint index, char* name);
        /// <summary>
        /// The glgetfragdataindex
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int glGetFragDataIndex_t(uint program, char* name);
        /// <summary>
        /// The glgensamplers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGenSamplers_t(int count, uint* samplers);
        /// <summary>
        /// The gldeletesamplers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDeleteSamplers_t(int count, uint* samplers);
        /// <summary>
        /// The glissampler
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool glIsSampler_t(uint sampler);
        /// <summary>
        /// The glbindsampler
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindSampler_t(uint unit, uint sampler);
        /// <summary>
        /// The glsamplerparameteri
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glSamplerParameteri_t(uint sampler, GLEnum pname, int param);
        /// <summary>
        /// The glsamplerparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glSamplerParameteriv_t(uint sampler, GLEnum pname, int* param);
        /// <summary>
        /// The glsamplerparameterf
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glSamplerParameterf_t(uint sampler, GLEnum pname, float param);
        /// <summary>
        /// The glsamplerparameterfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glSamplerParameterfv_t(uint sampler, GLEnum pname, float* param);
        /// <summary>
        /// The glsamplerparameteriiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glSamplerParameterIiv_t(uint sampler, GLEnum pname, int* param);
        /// <summary>
        /// The glsamplerparameteriuiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glSamplerParameterIuiv_t(uint sampler, GLEnum pname, uint* param);
        /// <summary>
        /// The glgetsamplerparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetSamplerParameteriv_t(uint sampler, GLEnum pname, int* @params);
        /// <summary>
        /// The glgetsamplerparameteriiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetSamplerParameterIiv_t(uint sampler, GLEnum pname, int* @params);
        /// <summary>
        /// The glgetsamplerparameterfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetSamplerParameterfv_t(uint sampler, GLEnum pname, float* @params);
        /// <summary>
        /// The glgetsamplerparameteriuiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetSamplerParameterIuiv_t(uint sampler, GLEnum pname, uint* @params);
        /// <summary>
        /// The glquerycounter
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glQueryCounter_t(uint id, QueryCounterTarget target);
        /// <summary>
        /// The glgetqueryobjecti64v
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetQueryObjecti64v_t(uint id, QueryObjectParameterName pname, long* @params);
        /// <summary>
        /// The glgetqueryobjectui64v
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetQueryObjectui64v_t(uint id, QueryObjectParameterName pname, ulong* @params);
        /// <summary>
        /// The glvertexattribdivisor
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribDivisor_t(uint index, uint divisor);
        /// <summary>
        /// The glvertexattribp1ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribP1ui_t(uint index, VertexAttribPointerType type, bool normalized, uint value);
        /// <summary>
        /// The glvertexattribp1uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribP1uiv_t(uint index, VertexAttribPointerType type, bool normalized, uint* value);
        /// <summary>
        /// The glvertexattribp2ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribP2ui_t(uint index, VertexAttribPointerType type, bool normalized, uint value);
        /// <summary>
        /// The glvertexattribp2uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribP2uiv_t(uint index, VertexAttribPointerType type, bool normalized, uint* value);
        /// <summary>
        /// The glvertexattribp3ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribP3ui_t(uint index, VertexAttribPointerType type, bool normalized, uint value);
        /// <summary>
        /// The glvertexattribp3uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribP3uiv_t(uint index, VertexAttribPointerType type, bool normalized, uint* value);
        /// <summary>
        /// The glvertexattribp4ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribP4ui_t(uint index, VertexAttribPointerType type, bool normalized, uint value);
        /// <summary>
        /// The glvertexattribp4uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribP4uiv_t(uint index, VertexAttribPointerType type, bool normalized, uint* value);
        /// <summary>
        /// The glvertexp2ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexP2ui_t(VertexPointerType type, uint value);
        /// <summary>
        /// The glvertexp2uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexP2uiv_t(VertexPointerType type, uint* value);
        /// <summary>
        /// The glvertexp3ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexP3ui_t(VertexPointerType type, uint value);
        /// <summary>
        /// The glvertexp3uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexP3uiv_t(VertexPointerType type, uint* value);
        /// <summary>
        /// The glvertexp4ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexP4ui_t(VertexPointerType type, uint value);
        /// <summary>
        /// The glvertexp4uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexP4uiv_t(VertexPointerType type, uint* value);
        /// <summary>
        /// The gltexcoordp1ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexCoordP1ui_t(TexCoordPointerType type, uint coords);
        /// <summary>
        /// The gltexcoordp1uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexCoordP1uiv_t(TexCoordPointerType type, uint* coords);
        /// <summary>
        /// The gltexcoordp2ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexCoordP2ui_t(TexCoordPointerType type, uint coords);
        /// <summary>
        /// The gltexcoordp2uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexCoordP2uiv_t(TexCoordPointerType type, uint* coords);
        /// <summary>
        /// The gltexcoordp3ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexCoordP3ui_t(TexCoordPointerType type, uint coords);
        /// <summary>
        /// The gltexcoordp3uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexCoordP3uiv_t(TexCoordPointerType type, uint* coords);
        /// <summary>
        /// The gltexcoordp4ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexCoordP4ui_t(TexCoordPointerType type, uint coords);
        /// <summary>
        /// The gltexcoordp4uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexCoordP4uiv_t(TexCoordPointerType type, uint* coords);
        /// <summary>
        /// The glmultitexcoordp1ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMultiTexCoordP1ui_t(TextureUnit texture, TexCoordPointerType type, uint coords);
        /// <summary>
        /// The glmultitexcoordp1uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMultiTexCoordP1uiv_t(TextureUnit texture, TexCoordPointerType type, uint* coords);
        /// <summary>
        /// The glmultitexcoordp2ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMultiTexCoordP2ui_t(TextureUnit texture, TexCoordPointerType type, uint coords);
        /// <summary>
        /// The glmultitexcoordp2uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMultiTexCoordP2uiv_t(TextureUnit texture, TexCoordPointerType type, uint* coords);
        /// <summary>
        /// The glmultitexcoordp3ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMultiTexCoordP3ui_t(TextureUnit texture, TexCoordPointerType type, uint coords);
        /// <summary>
        /// The glmultitexcoordp3uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMultiTexCoordP3uiv_t(TextureUnit texture, TexCoordPointerType type, uint* coords);
        /// <summary>
        /// The glmultitexcoordp4ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMultiTexCoordP4ui_t(TextureUnit texture, TexCoordPointerType type, uint coords);
        /// <summary>
        /// The glmultitexcoordp4uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMultiTexCoordP4uiv_t(TextureUnit texture, TexCoordPointerType type, uint* coords);
        /// <summary>
        /// The glnormalp3ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glNormalP3ui_t(NormalPointerType type, uint coords);
        /// <summary>
        /// The glnormalp3uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glNormalP3uiv_t(NormalPointerType type, uint* coords);
        /// <summary>
        /// The glcolorp3ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glColorP3ui_t(ColorPointerType type, uint color);
        /// <summary>
        /// The glcolorp3uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glColorP3uiv_t(ColorPointerType type, uint* color);
        /// <summary>
        /// The glcolorp4ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glColorP4ui_t(ColorPointerType type, uint color);
        /// <summary>
        /// The glcolorp4uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glColorP4uiv_t(ColorPointerType type, uint* color);
        /// <summary>
        /// The glsecondarycolorp3ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glSecondaryColorP3ui_t(ColorPointerType type, uint color);
        /// <summary>
        /// The glsecondarycolorp3uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glSecondaryColorP3uiv_t(ColorPointerType type, uint* color);
        /// <summary>
        /// The glminsampleshading
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMinSampleShading_t(float value);
        /// <summary>
        /// The glblendequationi
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBlendEquationi_t(uint buf, BlendEquationModeEXT mode);
        /// <summary>
        /// The glblendequationseparatei
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBlendEquationSeparatei_t(uint buf, BlendEquationModeEXT modeRGB, BlendEquationModeEXT modeAlpha);
        /// <summary>
        /// The glblendfunci
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBlendFunci_t(uint buf, BlendingFactor src, BlendingFactor dst);
        /// <summary>
        /// The glblendfuncseparatei
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBlendFuncSeparatei_t(uint buf, BlendingFactor srcRGB, BlendingFactor dstRGB, BlendingFactor srcAlpha, BlendingFactor dstAlpha);
        /// <summary>
        /// The gldrawarraysindirect
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawArraysIndirect_t(PrimitiveType mode, void* indirect);
        /// <summary>
        /// The gldrawelementsindirect
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawElementsIndirect_t(PrimitiveType mode, DrawElementsType type, void* indirect);
        /// <summary>
        /// The gluniform1d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform1d_t(int location, double x);
        /// <summary>
        /// The gluniform2d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform2d_t(int location, double x, double y);
        /// <summary>
        /// The gluniform3d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform3d_t(int location, double x, double y, double z);
        /// <summary>
        /// The gluniform4d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform4d_t(int location, double x, double y, double z, double w);
        /// <summary>
        /// The gluniform1dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform1dv_t(int location, int count, double* value);
        /// <summary>
        /// The gluniform2dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform2dv_t(int location, int count, double* value);
        /// <summary>
        /// The gluniform3dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform3dv_t(int location, int count, double* value);
        /// <summary>
        /// The gluniform4dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniform4dv_t(int location, int count, double* value);
        /// <summary>
        /// The gluniformmatrix2dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix2dv_t(int location, int count, bool transpose, double* value);
        /// <summary>
        /// The gluniformmatrix3dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix3dv_t(int location, int count, bool transpose, double* value);
        /// <summary>
        /// The gluniformmatrix4dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix4dv_t(int location, int count, bool transpose, double* value);
        /// <summary>
        /// The gluniformmatrix2x3dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix2x3dv_t(int location, int count, bool transpose, double* value);
        /// <summary>
        /// The gluniformmatrix2x4dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix2x4dv_t(int location, int count, bool transpose, double* value);
        /// <summary>
        /// The gluniformmatrix3x2dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix3x2dv_t(int location, int count, bool transpose, double* value);
        /// <summary>
        /// The gluniformmatrix3x4dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix3x4dv_t(int location, int count, bool transpose, double* value);
        /// <summary>
        /// The gluniformmatrix4x2dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix4x2dv_t(int location, int count, bool transpose, double* value);
        /// <summary>
        /// The gluniformmatrix4x3dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformMatrix4x3dv_t(int location, int count, bool transpose, double* value);
        /// <summary>
        /// The glgetuniformdv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetUniformdv_t(uint program, int location, double* @params);
        /// <summary>
        /// The glgetsubroutineuniformlocation
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int glGetSubroutineUniformLocation_t(uint program, ShaderType shadertype, char* name);
        /// <summary>
        /// The glgetsubroutineindex
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint glGetSubroutineIndex_t(uint program, ShaderType shadertype, char* name);
        /// <summary>
        /// The glgetactivesubroutineuniformiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetActiveSubroutineUniformiv_t(uint program, ShaderType shadertype, uint index, SubroutineParameterName pname, int* values);
        /// <summary>
        /// The glgetactivesubroutineuniformname
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetActiveSubroutineUniformName_t(uint program, ShaderType shadertype, uint index, int bufsize, int* length, char* name);
        /// <summary>
        /// The glgetactivesubroutinename
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetActiveSubroutineName_t(uint program, ShaderType shadertype, uint index, int bufsize, int* length, char* name);
        /// <summary>
        /// The gluniformsubroutinesuiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUniformSubroutinesuiv_t(ShaderType shadertype, int count, uint* indices);
        /// <summary>
        /// The glgetuniformsubroutineuiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetUniformSubroutineuiv_t(ShaderType shadertype, int location, uint* @params);
        /// <summary>
        /// The glgetprogramstageiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetProgramStageiv_t(uint program, ShaderType shadertype, ProgramStagePName pname, int* values);
        /// <summary>
        /// The glpatchparameteri
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glPatchParameteri_t(PatchParameterName pname, int value);
        /// <summary>
        /// The glpatchparameterfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glPatchParameterfv_t(PatchParameterName pname, float* values);
        /// <summary>
        /// The glbindtransformfeedback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindTransformFeedback_t(BindTransformFeedbackTarget target, uint id);
        /// <summary>
        /// The gldeletetransformfeedbacks
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDeleteTransformFeedbacks_t(int n, uint* ids);
        /// <summary>
        /// The glgentransformfeedbacks
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGenTransformFeedbacks_t(int n, uint* ids);
        /// <summary>
        /// The glistransformfeedback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool glIsTransformFeedback_t(uint id);
        /// <summary>
        /// The glpausetransformfeedback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glPauseTransformFeedback_t();
        /// <summary>
        /// The glresumetransformfeedback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glResumeTransformFeedback_t();
        /// <summary>
        /// The gldrawtransformfeedback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawTransformFeedback_t(PrimitiveType mode, uint id);
        /// <summary>
        /// The gldrawtransformfeedbackstream
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawTransformFeedbackStream_t(PrimitiveType mode, uint id, uint stream);
        /// <summary>
        /// The glbeginqueryindexed
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBeginQueryIndexed_t(QueryTarget target, uint index, uint id);
        /// <summary>
        /// The glendqueryindexed
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glEndQueryIndexed_t(QueryTarget target, uint index);
        /// <summary>
        /// The glgetqueryindexediv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetQueryIndexediv_t(uint target, uint index, QueryParameterName pname, int* @params);
        /// <summary>
        /// The glreleaseshadercompiler
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glReleaseShaderCompiler_t();
        /// <summary>
        /// The glshaderbinary
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glShaderBinary_t(int count, uint* shaders, uint binaryformat, void* binary, int length);
        /// <summary>
        /// The glgetshaderprecisionformat
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetShaderPrecisionFormat_t(ShaderType shadertype, PrecisionType precisiontype, int* range, int* precision);
        /// <summary>
        /// The gldepthrangef
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDepthRangef_t(float n, float f);
        /// <summary>
        /// The glcleardepthf
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearDepthf_t(float d);
        /// <summary>
        /// The glgetprogrambinary
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetProgramBinary_t(uint program, int bufSize, int* length, uint* binaryFormat, void* binary);
        /// <summary>
        /// The glprogrambinary
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramBinary_t(uint program, uint binaryFormat, void* binary, int length);
        /// <summary>
        /// The glprogramparameteri
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramParameteri_t(uint program, ProgramParameterPName pname, int value);
        /// <summary>
        /// The gluseprogramstages
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glUseProgramStages_t(uint pipeline, uint stages, uint program);
        /// <summary>
        /// The glactiveshaderprogram
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glActiveShaderProgram_t(uint pipeline, uint program);
        /// <summary>
        /// The glcreateshaderprogramv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint glCreateShaderProgramv_t(ShaderType type, int count, IntPtr strings);
        /// <summary>
        /// The glbindprogrampipeline
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindProgramPipeline_t(uint pipeline);
        /// <summary>
        /// The gldeleteprogrampipelines
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDeleteProgramPipelines_t(int n, uint* pipelines);
        /// <summary>
        /// The glgenprogrampipelines
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGenProgramPipelines_t(int n, uint* pipelines);
        /// <summary>
        /// The glisprogrampipeline
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool glIsProgramPipeline_t(uint pipeline);
        /// <summary>
        /// The glgetprogrampipelineiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetProgramPipelineiv_t(uint pipeline, PipelineParameterName pname, int* @params);
        /// <summary>
        /// The glprogramuniform1i
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform1i_t(uint program, int location, int v0);
        /// <summary>
        /// The glprogramuniform1iv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform1iv_t(uint program, int location, int count, int* value);
        /// <summary>
        /// The glprogramuniform1f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform1f_t(uint program, int location, float v0);
        /// <summary>
        /// The glprogramuniform1fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform1fv_t(uint program, int location, int count, float* value);
        /// <summary>
        /// The glprogramuniform1d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform1d_t(uint program, int location, double v0);
        /// <summary>
        /// The glprogramuniform1dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform1dv_t(uint program, int location, int count, double* value);
        /// <summary>
        /// The glprogramuniform1ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform1ui_t(uint program, int location, uint v0);
        /// <summary>
        /// The glprogramuniform1uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform1uiv_t(uint program, int location, int count, uint* value);
        /// <summary>
        /// The glprogramuniform2i
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform2i_t(uint program, int location, int v0, int v1);
        /// <summary>
        /// The glprogramuniform2iv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform2iv_t(uint program, int location, int count, int* value);
        /// <summary>
        /// The glprogramuniform2f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform2f_t(uint program, int location, float v0, float v1);
        /// <summary>
        /// The glprogramuniform2fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform2fv_t(uint program, int location, int count, float* value);
        /// <summary>
        /// The glprogramuniform2d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform2d_t(uint program, int location, double v0, double v1);
        /// <summary>
        /// The glprogramuniform2dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform2dv_t(uint program, int location, int count, double* value);
        /// <summary>
        /// The glprogramuniform2ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform2ui_t(uint program, int location, uint v0, uint v1);
        /// <summary>
        /// The glprogramuniform2uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform2uiv_t(uint program, int location, int count, uint* value);
        /// <summary>
        /// The glprogramuniform3i
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform3i_t(uint program, int location, int v0, int v1, int v2);
        /// <summary>
        /// The glprogramuniform3iv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform3iv_t(uint program, int location, int count, int* value);
        /// <summary>
        /// The glprogramuniform3f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform3f_t(uint program, int location, float v0, float v1, float v2);
        /// <summary>
        /// The glprogramuniform3fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform3fv_t(uint program, int location, int count, float* value);
        /// <summary>
        /// The glprogramuniform3d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform3d_t(uint program, int location, double v0, double v1, double v2);
        /// <summary>
        /// The glprogramuniform3dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform3dv_t(uint program, int location, int count, double* value);
        /// <summary>
        /// The glprogramuniform3ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform3ui_t(uint program, int location, uint v0, uint v1, uint v2);
        /// <summary>
        /// The glprogramuniform3uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform3uiv_t(uint program, int location, int count, uint* value);
        /// <summary>
        /// The glprogramuniform4i
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform4i_t(uint program, int location, int v0, int v1, int v2, int v3);
        /// <summary>
        /// The glprogramuniform4iv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform4iv_t(uint program, int location, int count, int* value);
        /// <summary>
        /// The glprogramuniform4f
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform4f_t(uint program, int location, float v0, float v1, float v2, float v3);
        /// <summary>
        /// The glprogramuniform4fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform4fv_t(uint program, int location, int count, float* value);
        /// <summary>
        /// The glprogramuniform4d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform4d_t(uint program, int location, double v0, double v1, double v2, double v3);
        /// <summary>
        /// The glprogramuniform4dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform4dv_t(uint program, int location, int count, double* value);
        /// <summary>
        /// The glprogramuniform4ui
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform4ui_t(uint program, int location, uint v0, uint v1, uint v2, uint v3);
        /// <summary>
        /// The glprogramuniform4uiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniform4uiv_t(uint program, int location, int count, uint* value);
        /// <summary>
        /// The glprogramuniformmatrix2fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix2fv_t(uint program, int location, int count, bool transpose, float* value);
        /// <summary>
        /// The glprogramuniformmatrix3fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix3fv_t(uint program, int location, int count, bool transpose, float* value);
        /// <summary>
        /// The glprogramuniformmatrix4fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix4fv_t(uint program, int location, int count, bool transpose, float* value);
        /// <summary>
        /// The glprogramuniformmatrix2dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix2dv_t(uint program, int location, int count, bool transpose, double* value);
        /// <summary>
        /// The glprogramuniformmatrix3dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix3dv_t(uint program, int location, int count, bool transpose, double* value);
        /// <summary>
        /// The glprogramuniformmatrix4dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix4dv_t(uint program, int location, int count, bool transpose, double* value);
        /// <summary>
        /// The glprogramuniformmatrix2x3fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix2x3fv_t(uint program, int location, int count, bool transpose, float* value);
        /// <summary>
        /// The glprogramuniformmatrix3x2fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix3x2fv_t(uint program, int location, int count, bool transpose, float* value);
        /// <summary>
        /// The glprogramuniformmatrix2x4fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix2x4fv_t(uint program, int location, int count, bool transpose, float* value);
        /// <summary>
        /// The glprogramuniformmatrix4x2fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix4x2fv_t(uint program, int location, int count, bool transpose, float* value);
        /// <summary>
        /// The glprogramuniformmatrix3x4fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix3x4fv_t(uint program, int location, int count, bool transpose, float* value);
        /// <summary>
        /// The glprogramuniformmatrix4x3fv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix4x3fv_t(uint program, int location, int count, bool transpose, float* value);
        /// <summary>
        /// The glprogramuniformmatrix2x3dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix2x3dv_t(uint program, int location, int count, bool transpose, double* value);
        /// <summary>
        /// The glprogramuniformmatrix3x2dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix3x2dv_t(uint program, int location, int count, bool transpose, double* value);
        /// <summary>
        /// The glprogramuniformmatrix2x4dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix2x4dv_t(uint program, int location, int count, bool transpose, double* value);
        /// <summary>
        /// The glprogramuniformmatrix4x2dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix4x2dv_t(uint program, int location, int count, bool transpose, double* value);
        /// <summary>
        /// The glprogramuniformmatrix3x4dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix3x4dv_t(uint program, int location, int count, bool transpose, double* value);
        /// <summary>
        /// The glprogramuniformmatrix4x3dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glProgramUniformMatrix4x3dv_t(uint program, int location, int count, bool transpose, double* value);
        /// <summary>
        /// The glvalidateprogrampipeline
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glValidateProgramPipeline_t(uint pipeline);
        /// <summary>
        /// The glgetprogrampipelineinfolog
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetProgramPipelineInfoLog_t(uint pipeline, int bufSize, int* length, char* infoLog);
        /// <summary>
        /// The glvertexattribl1d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribL1d_t(uint index, double x);
        /// <summary>
        /// The glvertexattribl2d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribL2d_t(uint index, double x, double y);
        /// <summary>
        /// The glvertexattribl3d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribL3d_t(uint index, double x, double y, double z);
        /// <summary>
        /// The glvertexattribl4d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribL4d_t(uint index, double x, double y, double z, double w);
        /// <summary>
        /// The glvertexattribl1dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribL1dv_t(uint index, double* v);
        /// <summary>
        /// The glvertexattribl2dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribL2dv_t(uint index, double* v);
        /// <summary>
        /// The glvertexattribl3dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribL3dv_t(uint index, double* v);
        /// <summary>
        /// The glvertexattribl4dv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribL4dv_t(uint index, double* v);
        /// <summary>
        /// The glvertexattriblpointer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribLPointer_t(uint index, int size, VertexAttribPointerType type, int stride, void* pointer);
        /// <summary>
        /// The glgetvertexattribldv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetVertexAttribLdv_t(uint index, VertexAttribEnum pname, double* @params);
        /// <summary>
        /// The glviewportarrayv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glViewportArrayv_t(uint first, int count, float* v);
        /// <summary>
        /// The glviewportindexedf
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glViewportIndexedf_t(uint index, float x, float y, float w, float h);
        /// <summary>
        /// The glviewportindexedfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glViewportIndexedfv_t(uint index, float* v);
        /// <summary>
        /// The glscissorarrayv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glScissorArrayv_t(uint first, int count, int* v);
        /// <summary>
        /// The glscissorindexed
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glScissorIndexed_t(uint index, int left, int bottom, int width, int height);
        /// <summary>
        /// The glscissorindexedv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glScissorIndexedv_t(uint index, int* v);
        /// <summary>
        /// The gldepthrangearrayv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDepthRangeArrayv_t(uint first, int count, double* v);
        /// <summary>
        /// The gldepthrangeindexed
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDepthRangeIndexed_t(uint index, double n, double f);
        /// <summary>
        /// The glgetfloati
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetFloati_v_t(GLEnum target, uint index, float* data);
        /// <summary>
        /// The glgetdoublei
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetDoublei_v_t(GLEnum target, uint index, double* data);
        /// <summary>
        /// The gldrawarraysinstancedbaseinstance
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawArraysInstancedBaseInstance_t(PrimitiveType mode, int first, int count, int instancecount, uint baseinstance);
        /// <summary>
        /// The gldrawelementsinstancedbaseinstance
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawElementsInstancedBaseInstance_t(PrimitiveType mode, int count, PrimitiveType type, void* indices, int instancecount, uint baseinstance);
        /// <summary>
        /// The gldrawelementsinstancedbasevertexbaseinstance
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawElementsInstancedBaseVertexBaseInstance_t(PrimitiveType mode, int count, DrawElementsType type, void* indices, int instancecount, int basevertex, uint baseinstance);
        /// <summary>
        /// The glgetinternalformativ
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetInternalformativ_t(TextureTarget target, InternalFormat internalformat, InternalFormatPName pname, int bufSize, int* @params);
        /// <summary>
        /// The glgetactiveatomiccounterbufferiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetActiveAtomicCounterBufferiv_t(uint program, uint bufferIndex, AtomicCounterBufferPName pname, int* @params);
        /// <summary>
        /// The glbindimagetexture
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindImageTexture_t(uint unit, uint texture, int level, bool layered, int layer, BufferAccessARB access, InternalFormat format);
        /// <summary>
        /// The glmemorybarrier
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMemoryBarrier_t(uint barriers);
        /// <summary>
        /// The gltexstorage1d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexStorage1D_t(TextureTarget target, int levels, InternalFormat internalformat, int width);
        /// <summary>
        /// The gltexstorage2d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexStorage2D_t(TextureTarget target, int levels, InternalFormat internalformat, int width, int height);
        /// <summary>
        /// The gltexstorage3d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexStorage3D_t(TextureTarget target, int levels, InternalFormat internalformat, int width, int height, int depth);
        /// <summary>
        /// The gldrawtransformfeedbackinstanced
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawTransformFeedbackInstanced_t(PrimitiveType mode, uint id, int instancecount);
        /// <summary>
        /// The gldrawtransformfeedbackstreaminstanced
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDrawTransformFeedbackStreamInstanced_t(PrimitiveType mode, uint id, uint stream, int instancecount);
        /// <summary>
        /// The glclearbufferdata
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearBufferData_t(BufferStorageTarget target, InternalFormat internalformat, PixelFormat format, PixelType type, void* data);
        /// <summary>
        /// The glclearbuffersubdata
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearBufferSubData_t(uint target, InternalFormat internalformat, IntPtr offset, int size, PixelFormat format, PixelType type, void* data);
        /// <summary>
        /// The gldispatchcompute
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDispatchCompute_t(uint num_groups_x, uint num_groups_y, uint num_groups_z);
        /// <summary>
        /// The gldispatchcomputeindirect
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDispatchComputeIndirect_t(IntPtr indirect);
        /// <summary>
        /// The glcopyimagesubdata
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCopyImageSubData_t(uint srcName, CopyBufferSubDataTarget srcTarget, int srcLevel, int srcX, int srcY, int srcZ, uint dstName, CopyBufferSubDataTarget dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int srcWidth, int srcHeight, int srcDepth);
        /// <summary>
        /// The glframebufferparameteri
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glFramebufferParameteri_t(FramebufferTarget target, FramebufferParameterName pname, int param);
        /// <summary>
        /// The glgetframebufferparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetFramebufferParameteriv_t(FramebufferTarget target, FramebufferAttachmentParameterName pname, int* @params);
        /// <summary>
        /// The glgetinternalformati64v
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetInternalformati64v_t(TextureTarget target, InternalFormat internalformat, InternalFormatPName pname, int bufSize, long* @params);
        /// <summary>
        /// The glinvalidatetexsubimage
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glInvalidateTexSubImage_t(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth);
        /// <summary>
        /// The glinvalidateteximage
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glInvalidateTexImage_t(uint texture, int level);
        /// <summary>
        /// The glinvalidatebuffersubdata
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glInvalidateBufferSubData_t(uint buffer, IntPtr offset, int length);
        /// <summary>
        /// The glinvalidatebufferdata
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glInvalidateBufferData_t(uint buffer);
        /// <summary>
        /// The glinvalidateframebuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glInvalidateFramebuffer_t(FramebufferTarget target, int numAttachments, uint* attachments);
        /// <summary>
        /// The glinvalidatesubframebuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glInvalidateSubFramebuffer_t(uint target, int numAttachments, uint* attachments, int x, int y, int width, int height);
        /// <summary>
        /// The glmultidrawarraysindirect
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMultiDrawArraysIndirect_t(PrimitiveType mode, void* indirect, int drawcount, int stride);
        /// <summary>
        /// The glmultidrawelementsindirect
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMultiDrawElementsIndirect_t(PrimitiveType mode, DrawElementsType type, void* indirect, int drawcount, int stride);
        /// <summary>
        /// The glgetprograminterfaceiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetProgramInterfaceiv_t(uint program, ProgramInterface programInterface, ProgramInterfacePName pname, int* @params);
        /// <summary>
        /// The glgetprogramresourceindex
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint glGetProgramResourceIndex_t(uint program, ProgramInterface programInterface, char* name);
        /// <summary>
        /// The glgetprogramresourcename
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetProgramResourceName_t(uint program, ProgramInterface programInterface, uint index, int bufSize, int* length, char* name);
        /// <summary>
        /// The glgetprogramresourceiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetProgramResourceiv_t(uint program, ProgramInterface programInterface, uint index, int propCount, uint* props, int bufSize, int* length, int* @params);
        /// <summary>
        /// The glgetprogramresourcelocation
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int glGetProgramResourceLocation_t(uint program, ProgramInterface programInterface, char* name);
        /// <summary>
        /// The glgetprogramresourcelocationindex
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int glGetProgramResourceLocationIndex_t(uint program, ProgramInterface programInterface, char* name);
        /// <summary>
        /// The glshaderstorageblockbinding
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glShaderStorageBlockBinding_t(uint program, uint storageBlockIndex, uint storageBlockBinding);
        /// <summary>
        /// The gltexbufferrange
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexBufferRange_t(TextureTarget target, InternalFormat internalformat, uint buffer, IntPtr offset, int size);
        /// <summary>
        /// The gltexstorage2dmultisample
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexStorage2DMultisample_t(TextureTarget target, int samples, InternalFormat internalformat, int width, int height, bool fixedsamplelocations);
        /// <summary>
        /// The gltexstorage3dmultisample
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTexStorage3DMultisample_t(TextureTarget target, int samples, InternalFormat internalformat, int width, int height, int depth, bool fixedsamplelocations);
        /// <summary>
        /// The gltextureview
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureView_t(uint texture, TextureTarget target, uint origtexture, InternalFormat internalformat, uint minlevel, uint numlevels, uint minlayer, uint numlayers);
        /// <summary>
        /// The glbindvertexbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindVertexBuffer_t(uint bindingindex, uint buffer, IntPtr offset, int stride);
        /// <summary>
        /// The glvertexattribformat
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribFormat_t(uint attribindex, int size, uint type, bool normalized, uint relativeoffset);
        /// <summary>
        /// The glvertexattribiformat
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribIFormat_t(uint attribindex, int size, uint type, uint relativeoffset);
        /// <summary>
        /// The glvertexattriblformat
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribLFormat_t(uint attribindex, int size, VertexAttribType type, uint relativeoffset);
        /// <summary>
        /// The glvertexattribbinding
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexAttribBinding_t(uint attribindex, uint bindingindex);
        /// <summary>
        /// The glvertexbindingdivisor
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexBindingDivisor_t(uint bindingindex, uint divisor);
        /// <summary>
        /// The gldebugmessagecontrol
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDebugMessageControl_t(DebugSource source, DebugType type, DebugSeverity severity, int count, uint* ids, bool enabled);
        /// <summary>
        /// The gldebugmessageinsert
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDebugMessageInsert_t(DebugSource source, DebugType type, uint id, DebugSeverity severity, int length, char* buf);
        /// <summary>
        /// The gldebugmessagecallback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDebugMessageCallback_t(IntPtr callback, void* userParam);
        /// <summary>
        /// The glgetdebugmessagelog
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uint glGetDebugMessageLog_t(uint count, int bufSize, uint* sources, uint* types, uint* ids, uint* severities, int* lengths, char* messageLog);
        /// <summary>
        /// The glpushdebuggroup
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glPushDebugGroup_t(DebugSource source, uint id, int length, char* message);
        /// <summary>
        /// The glpopdebuggroup
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glPopDebugGroup_t();
        /// <summary>
        /// The globjectlabel
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glObjectLabel_t(ObjectIdentifier identifier, uint name, int length, char* label);
        /// <summary>
        /// The glgetobjectlabel
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetObjectLabel_t(uint identifier, uint name, int bufSize, int* length, char* label);
        /// <summary>
        /// The globjectptrlabel
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glObjectPtrLabel_t(void* ptr, int length, char* label);
        /// <summary>
        /// The glgetobjectptrlabel
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetObjectPtrLabel_t(void* ptr, int bufSize, int* length, char* label);
        /// <summary>
        /// The glgetpointerv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetPointerv_t(GetPointervPName pname, void** @params);
        /// <summary>
        /// The glbufferstorage
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBufferStorage_t(BufferStorageTarget target, int size, void* data, uint flags);
        /// <summary>
        /// The glclearteximage
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearTexImage_t(uint texture, int level, PixelFormat format, PixelType type, void* data);
        /// <summary>
        /// The glcleartexsubimage
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearTexSubImage_t(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, void* data);
        /// <summary>
        /// The glbindbuffersbase
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindBuffersBase_t(BufferTargetARB target, uint first, int count, uint* buffers);
        /// <summary>
        /// The glbindbuffersrange
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindBuffersRange_t(BufferTargetARB target, uint first, int count, uint* buffers, IntPtr offsets, int* sizes);
        /// <summary>
        /// The glbindtextures
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindTextures_t(uint first, int count, uint* textures);
        /// <summary>
        /// The glbindsamplers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindSamplers_t(uint first, int count, uint* samplers);
        /// <summary>
        /// The glbindimagetextures
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindImageTextures_t(uint first, int count, uint* textures);
        /// <summary>
        /// The glbindvertexbuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindVertexBuffers_t(uint first, int count, uint* buffers, IntPtr offsets, int* strides);
        /// <summary>
        /// The glclipcontrol
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClipControl_t(ClipControlOrigin origin, ClipControlDepth depth);
        /// <summary>
        /// The glcreatetransformfeedbacks
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCreateTransformFeedbacks_t(int n, uint* ids);
        /// <summary>
        /// The gltransformfeedbackbufferbase
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTransformFeedbackBufferBase_t(uint xfb, uint index, uint buffer);
        /// <summary>
        /// The gltransformfeedbackbufferrange
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTransformFeedbackBufferRange_t(uint xfb, uint index, uint buffer, IntPtr offset, int size);
        /// <summary>
        /// The glgettransformfeedbackiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTransformFeedbackiv_t(uint xfb, TransformFeedbackPName pname, int* param);
        /// <summary>
        /// The glgettransformfeedbacki
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTransformFeedbacki_v_t(uint xfb, TransformFeedbackPName pname, uint index, int* param);
        /// <summary>
        /// The glgettransformfeedbacki64
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTransformFeedbacki64_v_t(uint xfb, TransformFeedbackPName pname, uint index, long* param);
        /// <summary>
        /// The glcreatebuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCreateBuffers_t(int n, uint* buffers);
        /// <summary>
        /// The glnamedbufferstorage
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glNamedBufferStorage_t(uint buffer, int size, void* data, uint flags);
        /// <summary>
        /// The glnamedbufferdata
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glNamedBufferData_t(uint buffer, int size, void* data, VertexBufferObjectUsage usage);
        /// <summary>
        /// The glnamedbuffersubdata
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glNamedBufferSubData_t(uint buffer, IntPtr offset, int size, void* data);
        /// <summary>
        /// The glcopynamedbuffersubdata
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCopyNamedBufferSubData_t(uint readBuffer, uint writeBuffer, IntPtr readOffset, IntPtr writeOffset, int size);
        /// <summary>
        /// The glclearnamedbufferdata
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearNamedBufferData_t(uint buffer, InternalFormat internalformat, PixelFormat format, PixelType type, void* data);
        /// <summary>
        /// The glclearnamedbuffersubdata
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearNamedBufferSubData_t(uint buffer, InternalFormat internalformat, IntPtr offset, int size, PixelFormat format, PixelType type, void* data);
        /// <summary>
        /// The glmapnamedbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void* glMapNamedBuffer_t(uint buffer, BufferAccessARB access);
        /// <summary>
        /// The glmapnamedbufferrange
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void* glMapNamedBufferRange_t(uint buffer, IntPtr offset, int length, uint access);
        /// <summary>
        /// The glunmapnamedbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool glUnmapNamedBuffer_t(uint buffer);
        /// <summary>
        /// The glflushmappednamedbufferrange
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glFlushMappedNamedBufferRange_t(uint buffer, IntPtr offset, int length);
        /// <summary>
        /// The glgetnamedbufferparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetNamedBufferParameteriv_t(uint buffer, GLEnum pname, int* @params);
        /// <summary>
        /// The glgetnamedbufferparameteri64v
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetNamedBufferParameteri64v_t(uint buffer, GLEnum pname, long* @params);
        /// <summary>
        /// The glgetnamedbufferpointerv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetNamedBufferPointerv_t(uint buffer, GLEnum pname, void** @params);
        /// <summary>
        /// The glgetnamedbuffersubdata
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetNamedBufferSubData_t(uint buffer, IntPtr offset, int size, void* data);
        /// <summary>
        /// The glcreateframebuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCreateFramebuffers_t(int n, uint* framebuffers);
        /// <summary>
        /// The glnamedframebufferrenderbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glNamedFramebufferRenderbuffer_t(uint framebuffer, FramebufferAttachment attachment, RenderbufferTarget renderbuffertarget, uint renderbuffer);
        /// <summary>
        /// The glnamedframebufferparameteri
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glNamedFramebufferParameteri_t(uint framebuffer, FramebufferParameterName pname, int param);
        /// <summary>
        /// The glnamedframebuffertexture
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glNamedFramebufferTexture_t(uint framebuffer, FramebufferAttachment attachment, uint texture, int level);
        /// <summary>
        /// The glnamedframebuffertexturelayer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glNamedFramebufferTextureLayer_t(uint framebuffer, FramebufferAttachment attachment, uint texture, int level, int layer);
        /// <summary>
        /// The glnamedframebufferdrawbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glNamedFramebufferDrawBuffer_t(uint framebuffer, ColorBuffer buf);
        /// <summary>
        /// The glnamedframebufferdrawbuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glNamedFramebufferDrawBuffers_t(uint framebuffer, int n, uint* bufs);
        /// <summary>
        /// The glnamedframebufferreadbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glNamedFramebufferReadBuffer_t(uint framebuffer, ColorBuffer src);
        /// <summary>
        /// The glinvalidatenamedframebufferdata
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glInvalidateNamedFramebufferData_t(uint framebuffer, int numAttachments, uint* attachments);
        /// <summary>
        /// The glinvalidatenamedframebuffersubdata
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glInvalidateNamedFramebufferSubData_t(uint framebuffer, int numAttachments, uint* attachments, int x, int y, int width, int height);
        /// <summary>
        /// The glclearnamedframebufferiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearNamedFramebufferiv_t(uint framebuffer, GLEnum buffer, int drawbuffer, int* value);
        /// <summary>
        /// The glclearnamedframebufferuiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearNamedFramebufferuiv_t(uint framebuffer, GLEnum buffer, int drawbuffer, uint* value);
        /// <summary>
        /// The glclearnamedframebufferfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearNamedFramebufferfv_t(uint framebuffer, GLEnum buffer, int drawbuffer, float* value);
        /// <summary>
        /// The glclearnamedframebufferfi
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glClearNamedFramebufferfi_t(uint framebuffer, GLEnum buffer, int drawbuffer, float depth, int stencil);
        /// <summary>
        /// The glblitnamedframebuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBlitNamedFramebuffer_t(uint readFramebuffer, uint drawFramebuffer, int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, BlitFramebufferFilter filter);
        /// <summary>
        /// The glchecknamedframebufferstatus
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate FramebufferStatus glCheckNamedFramebufferStatus_t(uint framebuffer, FramebufferTarget target);
        /// <summary>
        /// The glgetnamedframebufferparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetNamedFramebufferParameteriv_t(uint framebuffer, GetFramebufferParameter pname, int* param);
        /// <summary>
        /// The glgetnamedframebufferattachmentparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetNamedFramebufferAttachmentParameteriv_t(uint framebuffer, FramebufferAttachment attachment, FramebufferAttachmentParameterName pname, int* @params);
        /// <summary>
        /// The glcreaterenderbuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCreateRenderbuffers_t(int n, uint* renderbuffers);
        /// <summary>
        /// The glnamedrenderbufferstorage
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glNamedRenderbufferStorage_t(uint renderbuffer, InternalFormat internalformat, int width, int height);
        /// <summary>
        /// The glnamedrenderbufferstoragemultisample
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glNamedRenderbufferStorageMultisample_t(uint renderbuffer, int samples, InternalFormat internalformat, int width, int height);
        /// <summary>
        /// The glgetnamedrenderbufferparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetNamedRenderbufferParameteriv_t(uint renderbuffer, RenderbufferParameterName pname, int* @params);
        /// <summary>
        /// The glcreatetextures
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCreateTextures_t(TextureTarget target, int n, uint* textures);
        /// <summary>
        /// The gltexturebuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureBuffer_t(uint texture, InternalFormat internalformat, uint buffer);
        /// <summary>
        /// The gltexturebufferrange
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureBufferRange_t(uint texture, InternalFormat internalformat, uint buffer, IntPtr offset, int size);
        /// <summary>
        /// The gltexturestorage1d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureStorage1D_t(uint texture, int levels, InternalFormat internalformat, int width);
        /// <summary>
        /// The gltexturestorage2d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureStorage2D_t(uint texture, int levels, InternalFormat internalformat, int width, int height);
        /// <summary>
        /// The gltexturestorage3d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureStorage3D_t(uint texture, int levels, InternalFormat internalformat, int width, int height, int depth);
        /// <summary>
        /// The gltexturestorage2dmultisample
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureStorage2DMultisample_t(uint texture, int samples, InternalFormat internalformat, int width, int height, bool fixedsamplelocations);
        /// <summary>
        /// The gltexturestorage3dmultisample
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureStorage3DMultisample_t(uint texture, int samples, InternalFormat internalformat, int width, int height, int depth, bool fixedsamplelocations);
        /// <summary>
        /// The gltexturesubimage1d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureSubImage1D_t(uint texture, int level, int xoffset, int width, PixelFormat format, PixelType type, void* pixels);
        /// <summary>
        /// The gltexturesubimage2d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureSubImage2D_t(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, void* pixels);
        /// <summary>
        /// The gltexturesubimage3d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureSubImage3D_t(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, void* pixels);
        /// <summary>
        /// The glcompressedtexturesubimage1d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCompressedTextureSubImage1D_t(uint texture, int level, int xoffset, int width, PixelFormat format, int imageSize, void* data);
        /// <summary>
        /// The glcompressedtexturesubimage2d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCompressedTextureSubImage2D_t(uint texture, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, void* data);
        /// <summary>
        /// The glcompressedtexturesubimage3d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCompressedTextureSubImage3D_t(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, int imageSize, void* data);
        /// <summary>
        /// The glcopytexturesubimage1d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCopyTextureSubImage1D_t(uint texture, int level, int xoffset, int x, int y, int width);
        /// <summary>
        /// The glcopytexturesubimage2d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCopyTextureSubImage2D_t(uint texture, int level, int xoffset, int yoffset, int x, int y, int width, int height);
        /// <summary>
        /// The glcopytexturesubimage3d
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCopyTextureSubImage3D_t(uint texture, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height);
        /// <summary>
        /// The gltextureparameterf
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureParameterf_t(uint texture, TextureParameterName pname, float param);
        /// <summary>
        /// The gltextureparameterfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureParameterfv_t(uint texture, TextureParameterName pname, float* param);
        /// <summary>
        /// The gltextureparameteri
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureParameteri_t(uint texture, TextureParameterName pname, int param);
        /// <summary>
        /// The gltextureparameteriiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureParameterIiv_t(uint texture, TextureParameterName pname, int* @params);
        /// <summary>
        /// The gltextureparameteriuiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureParameterIuiv_t(uint texture, TextureParameterName pname, uint* @params);
        /// <summary>
        /// The gltextureparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureParameteriv_t(uint texture, TextureParameterName pname, int* param);
        /// <summary>
        /// The glgeneratetexturemipmap
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGenerateTextureMipmap_t(uint texture);
        /// <summary>
        /// The glbindtextureunit
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glBindTextureUnit_t(uint unit, uint texture);
        /// <summary>
        /// The glgettextureimage
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTextureImage_t(uint texture, int level, PixelFormat format, PixelType type, int bufSize, void* pixels);
        /// <summary>
        /// The glgetcompressedtextureimage
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetCompressedTextureImage_t(uint texture, int level, int bufSize, void* pixels);
        /// <summary>
        /// The glgettexturelevelparameterfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTextureLevelParameterfv_t(uint texture, int level, GetTextureParameter pname, float* @params);
        /// <summary>
        /// The glgettexturelevelparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTextureLevelParameteriv_t(uint texture, int level, GetTextureParameter pname, int* @params);
        /// <summary>
        /// The glgettextureparameterfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTextureParameterfv_t(uint texture, GetTextureParameter pname, float* @params);
        /// <summary>
        /// The glgettextureparameteriiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTextureParameterIiv_t(uint texture, GetTextureParameter pname, int* @params);
        /// <summary>
        /// The glgettextureparameteriuiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTextureParameterIuiv_t(uint texture, GetTextureParameter pname, uint* @params);
        /// <summary>
        /// The glgettextureparameteriv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTextureParameteriv_t(uint texture, GetTextureParameter pname, int* @params);
        /// <summary>
        /// The glcreatevertexarrays
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCreateVertexArrays_t(int n, uint* arrays);
        /// <summary>
        /// The gldisablevertexarrayattrib
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glDisableVertexArrayAttrib_t(uint vaobj, uint index);
        /// <summary>
        /// The glenablevertexarrayattrib
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glEnableVertexArrayAttrib_t(uint vaobj, uint index);
        /// <summary>
        /// The glvertexarrayelementbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexArrayElementBuffer_t(uint vaobj, uint buffer);
        /// <summary>
        /// The glvertexarrayvertexbuffer
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexArrayVertexBuffer_t(uint vaobj, uint bindingindex, uint buffer, IntPtr offset, int stride);
        /// <summary>
        /// The glvertexarrayvertexbuffers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexArrayVertexBuffers_t(uint vaobj, uint first, int count, uint* buffers, IntPtr offsets, int* strides);
        /// <summary>
        /// The glvertexarrayattribbinding
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexArrayAttribBinding_t(uint vaobj, uint attribindex, uint bindingindex);
        /// <summary>
        /// The glvertexarrayattribformat
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexArrayAttribFormat_t(uint vaobj, uint attribindex, int size, VertexAttribType type, bool normalized, uint relativeoffset);
        /// <summary>
        /// The glvertexarrayattribiformat
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexArrayAttribIFormat_t(uint vaobj, uint attribindex, int size, VertexAttribType type, uint relativeoffset);
        /// <summary>
        /// The glvertexarrayattriblformat
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexArrayAttribLFormat_t(uint vaobj, uint attribindex, int size, VertexAttribType type, uint relativeoffset);
        /// <summary>
        /// The glvertexarraybindingdivisor
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glVertexArrayBindingDivisor_t(uint vaobj, uint bindingindex, uint divisor);
        /// <summary>
        /// The glgetvertexarrayiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetVertexArrayiv_t(uint vaobj, VertexArrayPName pname, int* param);
        /// <summary>
        /// The glgetvertexarrayindexediv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetVertexArrayIndexediv_t(uint vaobj, uint index, VertexArrayPName pname, int* param);
        /// <summary>
        /// The glgetvertexarrayindexed64iv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetVertexArrayIndexed64iv_t(uint vaobj, uint index, VertexArrayPName pname, long* param);
        /// <summary>
        /// The glcreatesamplers
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCreateSamplers_t(int n, uint* samplers);
        /// <summary>
        /// The glcreateprogrampipelines
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCreateProgramPipelines_t(int n, uint* pipelines);
        /// <summary>
        /// The glcreatequeries
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glCreateQueries_t(QueryTarget target, int n, uint* ids);
        /// <summary>
        /// The glgetquerybufferobjecti64v
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetQueryBufferObjecti64v_t(uint id, uint buffer, QueryObjectParameterName pname, IntPtr offset);
        /// <summary>
        /// The glgetquerybufferobjectiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetQueryBufferObjectiv_t(uint id, uint buffer, QueryObjectParameterName pname, IntPtr offset);
        /// <summary>
        /// The glgetquerybufferobjectui64v
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetQueryBufferObjectui64v_t(uint id, uint buffer, QueryObjectParameterName pname, IntPtr offset);
        /// <summary>
        /// The glgetquerybufferobjectuiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetQueryBufferObjectuiv_t(uint id, uint buffer, QueryObjectParameterName pname, IntPtr offset);
        /// <summary>
        /// The glmemorybarrierbyregion
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMemoryBarrierByRegion_t(uint barriers);
        /// <summary>
        /// The glgettexturesubimage
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetTextureSubImage_t(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, int bufSize, void* pixels);
        /// <summary>
        /// The glgetcompressedtexturesubimage
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetCompressedTextureSubImage_t(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int bufSize, void* pixels);
        /// <summary>
        /// The glgetgraphicsresetstatus
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate GraphicsResetStatus glGetGraphicsResetStatus_t();
        /// <summary>
        /// The glgetncompressedteximage
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnCompressedTexImage_t(TextureTarget target, int lod, int bufSize, void* pixels);
        /// <summary>
        /// The glgetnteximage
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnTexImage_t(TextureTarget target, int level, PixelFormat format, PixelType type, int bufSize, void* pixels);
        /// <summary>
        /// The glgetnuniformdv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnUniformdv_t(uint program, int location, int bufSize, double* @params);
        /// <summary>
        /// The glgetnuniformfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnUniformfv_t(uint program, int location, int bufSize, float* @params);
        /// <summary>
        /// The glgetnuniformiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnUniformiv_t(uint program, int location, int bufSize, int* @params);
        /// <summary>
        /// The glgetnuniformuiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnUniformuiv_t(uint program, int location, int bufSize, uint* @params);
        /// <summary>
        /// The glreadnpixels
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glReadnPixels_t(int x, int y, int width, int height, PixelFormat format, PixelType type, int bufSize, void* data);
        /// <summary>
        /// The glgetnmapdv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnMapdv_t(MapTarget target, MapQuery query, int bufSize, double* v);
        /// <summary>
        /// The glgetnmapfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnMapfv_t(MapTarget target, MapQuery query, int bufSize, float* v);
        /// <summary>
        /// The glgetnmapiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnMapiv_t(MapTarget target, MapQuery query, int bufSize, int* v);
        /// <summary>
        /// The glgetnpixelmapfv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnPixelMapfv_t(PixelMap map, int bufSize, float* values);
        /// <summary>
        /// The glgetnpixelmapuiv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnPixelMapuiv_t(PixelMap map, int bufSize, uint* values);
        /// <summary>
        /// The glgetnpixelmapusv
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnPixelMapusv_t(PixelMap map, int bufSize, short* values);
        /// <summary>
        /// The glgetnpolygonstipple
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnPolygonStipple_t(int bufSize, byte* pattern);
        /// <summary>
        /// The glgetncolortable
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnColorTable_t(ColorTableTarget target, PixelFormat format, PixelType type, int bufSize, void* table);
        /// <summary>
        /// The glgetnconvolutionfilter
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnConvolutionFilter_t(ConvolutionTarget target, PixelFormat format, PixelType type, int bufSize, void* image);
        /// <summary>
        /// The glgetnseparablefilter
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnSeparableFilter_t(SeparableTargetEXT target, PixelFormat format, PixelType type, int rowBufSize, void* row, int columnBufSize, void* column, void* span);
        /// <summary>
        /// The glgetnhistogram
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnHistogram_t(HistogramTargetEXT target, bool reset, PixelFormat format, PixelType type, int bufSize, void* values);
        /// <summary>
        /// The glgetnminmax
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glGetnMinmax_t(MinmaxTargetEXT target, bool reset, PixelFormat format, PixelType type, int bufSize, void* values);
        /// <summary>
        /// The gltexturebarrier
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glTextureBarrier_t();
        /// <summary>
        /// The glspecializeshader
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glSpecializeShader_t(uint shader, char* pEntryPoint, uint numSpecializationConstants, uint* pConstantIndex, uint* pConstantValue);
        /// <summary>
        /// The glmultidrawarraysindirectcount
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMultiDrawArraysIndirectCount_t(PrimitiveType mode, void* indirect, IntPtr drawcount, int maxdrawcount, int stride);
        /// <summary>
        /// The glmultidrawelementsindirectcount
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glMultiDrawElementsIndirectCount_t(PrimitiveType mode, uint type, void* indirect, IntPtr drawcount, int maxdrawcount, int stride);
        /// <summary>
        /// The glpolygonoffsetclamp
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void glPolygonOffsetClamp_t(float factor, float units, float clamp);
    }
}
