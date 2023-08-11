using System;
using System.Runtime.InteropServices;
using Veldrid.MetalBindings;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.OpenGL.EAGL
{
    /// <summary>
    /// The eagl context
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct EAGLContext
    {
        /// <summary>
        /// The obj
        /// </summary>
        private static ObjCClass s_class = new ObjCClass("EAGLContext");

        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Renders the buffer storage using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="drawable">The drawable</param>
        /// <returns>The bool</returns>
        public Bool8 renderBufferStorage(UIntPtr target, IntPtr drawable)
            => bool8_objc_msgSend(NativePtr, sel_renderBufferStorage, target, drawable);

        /// <summary>
        /// Presents the render buffer using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <returns>The bool</returns>
        public Bool8 presentRenderBuffer(UIntPtr target)
            => bool8_objc_msgSend(NativePtr, sel_presentRenderBuffer, target);

        /// <summary>
        /// Creates the api
        /// </summary>
        /// <param name="api">The api</param>
        /// <returns>The ret</returns>
        public static EAGLContext Create(EAGLRenderingAPI api)
        {
            EAGLContext ret = s_class.Alloc<EAGLContext>();
            objc_msgSend(ret.NativePtr, sel_initWithAPI, (uint)api);
            return ret;
        }

        /// <summary>
        /// Sets the current context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The bool</returns>
        public static Bool8 setCurrentContext(IntPtr context)
            => bool8_objc_msgSend(s_class, sel_setCurrentContext, context);

        /// <summary>
        /// Gets the value of the current context
        /// </summary>
        public static EAGLContext currentContext
            => objc_msgSend<EAGLContext>(s_class, sel_currentContext);

        /// <summary>
        /// Releases this instance
        /// </summary>
        public void Release() => release(NativePtr);

        /// <summary>
        /// The sel initwithapi
        /// </summary>
        private static readonly Selector sel_initWithAPI = "initWithAPI:";
        /// <summary>
        /// The sel setcurrentcontext
        /// </summary>
        private static readonly Selector sel_setCurrentContext = "setCurrentContext:";
        /// <summary>
        /// The sel renderbufferstorage
        /// </summary>
        private static readonly Selector sel_renderBufferStorage = "renderbufferStorage:fromDrawable:";
        /// <summary>
        /// The sel presentrenderbuffer
        /// </summary>
        private static readonly Selector sel_presentRenderBuffer = "presentRenderbuffer:";
        /// <summary>
        /// The sel currentcontext
        /// </summary>
        private static readonly Selector sel_currentContext = "currentContext";
    }

    /// <summary>
    /// The eagl rendering api enum
    /// </summary>
    internal enum EAGLRenderingAPI
    {
        /// <summary>
        /// The open gles eagl rendering api
        /// </summary>
        OpenGLES1 = 1,
        /// <summary>
        /// The open gles eagl rendering api
        /// </summary>
        OpenGLES2 = 2,
        /// <summary>
        /// The open gles eagl rendering api
        /// </summary>
        OpenGLES3 = 3,
    }
}