using System;
using System.Runtime.InteropServices;
using static Veldrid.MetalBindings.ObjectiveCRuntime;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl render pass descriptor
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRenderPassDescriptor
    {
        /// <summary>
        /// The mtl render pass descriptor
        /// </summary>
        private static readonly ObjCClass s_class = new ObjCClass(nameof(MTLRenderPassDescriptor));
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;
        /// <summary>
        /// News
        /// </summary>
        /// <returns>The mtl render pass descriptor</returns>
        public static MTLRenderPassDescriptor New() => s_class.AllocInit<MTLRenderPassDescriptor>();

        /// <summary>
        /// Gets the value of the color attachments
        /// </summary>
        public MTLRenderPassColorAttachmentDescriptorArray colorAttachments
            => objc_msgSend<MTLRenderPassColorAttachmentDescriptorArray>(NativePtr, sel_colorAttachments);

        /// <summary>
        /// Gets the value of the depth attachment
        /// </summary>
        public MTLRenderPassDepthAttachmentDescriptor depthAttachment
            => objc_msgSend<MTLRenderPassDepthAttachmentDescriptor>(NativePtr, sel_depthAttachment);

        /// <summary>
        /// Gets the value of the stencil attachment
        /// </summary>
        public MTLRenderPassStencilAttachmentDescriptor stencilAttachment
            => objc_msgSend<MTLRenderPassStencilAttachmentDescriptor>(NativePtr, sel_stencilAttachment);

        /// <summary>
        /// The sel colorattachments
        /// </summary>
        private static readonly Selector sel_colorAttachments = "colorAttachments";
        /// <summary>
        /// The sel depthattachment
        /// </summary>
        private static readonly Selector sel_depthAttachment = "depthAttachment";
        /// <summary>
        /// The sel stencilattachment
        /// </summary>
        private static readonly Selector sel_stencilAttachment = "stencilAttachment";
    }
}