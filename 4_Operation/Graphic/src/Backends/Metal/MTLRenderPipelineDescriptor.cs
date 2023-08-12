using System;
using System.Runtime.InteropServices;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl render pipeline descriptor
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRenderPipelineDescriptor
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLRenderPipelineDescriptor"/> class
        /// </summary>
        /// <param name="ptr">The ptr</param>
        public MTLRenderPipelineDescriptor(IntPtr ptr) => NativePtr = ptr;

        /// <summary>
        /// News
        /// </summary>
        /// <returns>The ret</returns>
        public static MTLRenderPipelineDescriptor New()
        {
            var cls = new ObjCClass("MTLRenderPipelineDescriptor");
            var ret = cls.AllocInit<MTLRenderPipelineDescriptor>();
            return ret;
        }

        /// <summary>
        /// Gets or sets the value of the vertex function
        /// </summary>
        public MTLFunction vertexFunction
        {
            get => objc_msgSend<MTLFunction>(NativePtr, sel_vertexFunction);
            set => objc_msgSend(NativePtr, sel_setVertexFunction, value.NativePtr);
        }

        /// <summary>
        /// Gets or sets the value of the fragment function
        /// </summary>
        public MTLFunction fragmentFunction
        {
            get => objc_msgSend<MTLFunction>(NativePtr, sel_fragmentFunction);
            set => objc_msgSend(NativePtr, sel_setFragmentFunction, value.NativePtr);
        }

        /// <summary>
        /// Gets the value of the color attachments
        /// </summary>
        public MTLRenderPipelineColorAttachmentDescriptorArray colorAttachments
            => objc_msgSend<MTLRenderPipelineColorAttachmentDescriptorArray>(NativePtr, sel_colorAttachments);

        /// <summary>
        /// Gets or sets the value of the depth attachment pixel format
        /// </summary>
        public MTLPixelFormat depthAttachmentPixelFormat
        {
            get => (MTLPixelFormat)uint_objc_msgSend(NativePtr, sel_depthAttachmentPixelFormat);
            set => objc_msgSend(NativePtr, sel_setDepthAttachmentPixelFormat, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the stencil attachment pixel format
        /// </summary>
        public MTLPixelFormat stencilAttachmentPixelFormat
        {
            get => (MTLPixelFormat)uint_objc_msgSend(NativePtr, sel_stencilAttachmentPixelFormat);
            set => objc_msgSend(NativePtr, sel_setStencilAttachmentPixelFormat, (uint)value);
        }

        /// <summary>
        /// Gets or sets the value of the sample count
        /// </summary>
        public UIntPtr sampleCount
        {
            get => UIntPtr_objc_msgSend(NativePtr, sel_sampleCount);
            set => objc_msgSend(NativePtr, sel_setSampleCount, value);
        }

        /// <summary>
        /// Gets the value of the vertex descriptor
        /// </summary>
        public MTLVertexDescriptor vertexDescriptor => objc_msgSend<MTLVertexDescriptor>(NativePtr, sel_vertexDescriptor);

        /// <summary>
        /// Gets or sets the value of the alpha to coverage enabled
        /// </summary>
        public Bool8 alphaToCoverageEnabled
        {
            get => bool8_objc_msgSend(NativePtr, sel_isAlphaToCoverageEnabled);
            set => objc_msgSend(NativePtr, sel_setAlphaToCoverageEnabled, value);
        }

        /// <summary>
        /// The sel vertexfunction
        /// </summary>
        private static readonly Selector sel_vertexFunction = "vertexFunction";
        /// <summary>
        /// The sel setvertexfunction
        /// </summary>
        private static readonly Selector sel_setVertexFunction = "setVertexFunction:";
        /// <summary>
        /// The sel fragmentfunction
        /// </summary>
        private static readonly Selector sel_fragmentFunction = "fragmentFunction";
        /// <summary>
        /// The sel setfragmentfunction
        /// </summary>
        private static readonly Selector sel_setFragmentFunction = "setFragmentFunction:";
        /// <summary>
        /// The sel colorattachments
        /// </summary>
        private static readonly Selector sel_colorAttachments = "colorAttachments";
        /// <summary>
        /// The sel depthattachmentpixelformat
        /// </summary>
        private static readonly Selector sel_depthAttachmentPixelFormat = "depthAttachmentPixelFormat";
        /// <summary>
        /// The sel setdepthattachmentpixelformat
        /// </summary>
        private static readonly Selector sel_setDepthAttachmentPixelFormat = "setDepthAttachmentPixelFormat:";
        /// <summary>
        /// The sel stencilattachmentpixelformat
        /// </summary>
        private static readonly Selector sel_stencilAttachmentPixelFormat = "stencilAttachmentPixelFormat";
        /// <summary>
        /// The sel setstencilattachmentpixelformat
        /// </summary>
        private static readonly Selector sel_setStencilAttachmentPixelFormat = "setStencilAttachmentPixelFormat:";
        /// <summary>
        /// The sel samplecount
        /// </summary>
        private static readonly Selector sel_sampleCount = "sampleCount";
        /// <summary>
        /// The sel setsamplecount
        /// </summary>
        private static readonly Selector sel_setSampleCount = "setSampleCount:";
        /// <summary>
        /// The sel vertexdescriptor
        /// </summary>
        private static readonly Selector sel_vertexDescriptor = "vertexDescriptor";
        /// <summary>
        /// The sel isalphatocoverageenabled
        /// </summary>
        private static readonly Selector sel_isAlphaToCoverageEnabled = "isAlphaToCoverageEnabled";
        /// <summary>
        /// The sel setalphatocoverageenabled
        /// </summary>
        private static readonly Selector sel_setAlphaToCoverageEnabled = "setAlphaToCoverageEnabled:";
    }
}
