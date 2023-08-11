using System;
using System.Diagnostics;
using Veldrid.MetalBindings;

namespace Veldrid.MTL
{
    /// <summary>
    /// The mtl swapchain class
    /// </summary>
    /// <seealso cref="Swapchain"/>
    internal class MTLSwapchain : Swapchain
    {
        /// <summary>
        /// The framebuffer
        /// </summary>
        private readonly MTLSwapchainFramebuffer _framebuffer;
        /// <summary>
        /// The metal layer
        /// </summary>
        private CAMetalLayer _metalLayer;
        /// <summary>
        /// The gd
        /// </summary>
        private readonly MTLGraphicsDevice _gd;
        /// <summary>
        /// The ui view
        /// </summary>
        private UIView _uiView; // Valid only when a UIViewSwapchainSource is used.
        /// <summary>
        /// The sync to vertical blank
        /// </summary>
        private bool _syncToVerticalBlank;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// The drawable
        /// </summary>
        private CAMetalDrawable _drawable;

        /// <summary>
        /// Gets the value of the framebuffer
        /// </summary>
        public override Framebuffer Framebuffer => _framebuffer;
        /// <summary>
        /// Gets or sets the value of the sync to vertical blank
        /// </summary>
        public override bool SyncToVerticalBlank
        {
            get => _syncToVerticalBlank;
            set
            {
                if (_syncToVerticalBlank != value)
                {
                    SetSyncToVerticalBlank(value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Gets the value of the current drawable
        /// </summary>
        public CAMetalDrawable CurrentDrawable => _drawable;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLSwapchain"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        /// <exception cref="VeldridException">A Metal Swapchain can only be created from an NSWindow, NSView, or UIView.</exception>
        public MTLSwapchain(MTLGraphicsDevice gd, ref SwapchainDescription description)
        {
            _gd = gd;
            _syncToVerticalBlank = description.SyncToVerticalBlank;

            uint width;
            uint height;

            SwapchainSource source = description.Source;
            if (source is NSWindowSwapchainSource nsWindowSource)
            {
                NSWindow nswindow = new NSWindow(nsWindowSource.NSWindow);
                NSView contentView = nswindow.contentView;
                CGSize windowContentSize = contentView.frame.size;
                width = (uint)windowContentSize.width;
                height = (uint)windowContentSize.height;

                if (!CAMetalLayer.TryCast(contentView.layer, out _metalLayer))
                {
                    _metalLayer = CAMetalLayer.New();
                    contentView.wantsLayer = true;
                    contentView.layer = _metalLayer.NativePtr;
                }
            }
            else if (source is NSViewSwapchainSource nsViewSource)
            {
                NSView contentView = new NSView(nsViewSource.NSView);
                CGSize windowContentSize = contentView.frame.size;
                width = (uint)windowContentSize.width;
                height = (uint)windowContentSize.height;

                if (!CAMetalLayer.TryCast(contentView.layer, out _metalLayer))
                {
                    _metalLayer = CAMetalLayer.New();
                    contentView.wantsLayer = true;
                    contentView.layer = _metalLayer.NativePtr;
                }
            }
            else if (source is UIViewSwapchainSource uiViewSource)
            {
                UIScreen mainScreen = UIScreen.mainScreen;
                CGFloat nativeScale = mainScreen.nativeScale;

                _uiView = new UIView(uiViewSource.UIView);
                CGSize viewSize = _uiView.frame.size;
                width = (uint)(viewSize.width * nativeScale);
                height = (uint)(viewSize.height * nativeScale);

                if (!CAMetalLayer.TryCast(_uiView.layer, out _metalLayer))
                {
                    _metalLayer = CAMetalLayer.New();
                    _metalLayer.frame = _uiView.frame;
                    _metalLayer.opaque = true;
                    _uiView.layer.addSublayer(_metalLayer.NativePtr);
                }
            }
            else
            {
                throw new VeldridException($"A Metal Swapchain can only be created from an NSWindow, NSView, or UIView.");
            }

            PixelFormat format = description.ColorSrgb
                ? PixelFormat.B8_G8_R8_A8_UNorm_SRgb
                : PixelFormat.B8_G8_R8_A8_UNorm;

            _metalLayer.device = _gd.Device;
            _metalLayer.pixelFormat = MTLFormats.VdToMTLPixelFormat(format, false);
            _metalLayer.framebufferOnly = true;
            _metalLayer.drawableSize = new CGSize(width, height);

            SetSyncToVerticalBlank(_syncToVerticalBlank);

            GetNextDrawable();

            _framebuffer = new MTLSwapchainFramebuffer(
                gd,
                this,
                width,
                height,
                description.DepthFormat,
                format);
        }

        /// <summary>
        /// Gets the next drawable
        /// </summary>
        public void GetNextDrawable()
        {
            if (!_drawable.IsNull)
            {
                ObjectiveCRuntime.release(_drawable.NativePtr);
            }

            using (NSAutoreleasePool.Begin())
            {
                _drawable = _metalLayer.nextDrawable();
                ObjectiveCRuntime.retain(_drawable.NativePtr);
            }
        }

        /// <summary>
        /// Resizes the width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public override void Resize(uint width, uint height)
        {
            if (_uiView.NativePtr != IntPtr.Zero)
            {
                UIScreen mainScreen = UIScreen.mainScreen;
                CGFloat nativeScale = mainScreen.nativeScale;
                width = (uint)(width * nativeScale);
                height = (uint)(height * nativeScale);

                _metalLayer.frame = _uiView.frame;
            }

            _framebuffer.Resize(width, height);
            _metalLayer.drawableSize = new CGSize(width, height);
            if (_uiView.NativePtr != IntPtr.Zero)
            {
                _metalLayer.frame = _uiView.frame;
            }
            GetNextDrawable();
        }

        /// <summary>
        /// Sets the sync to vertical blank using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        private void SetSyncToVerticalBlank(bool value)
        {
            _syncToVerticalBlank = value;

            if (_gd.MetalFeatures.MaxFeatureSet == MTLFeatureSet.macOS_GPUFamily1_v3
                || _gd.MetalFeatures.MaxFeatureSet == MTLFeatureSet.macOS_GPUFamily1_v4
                || _gd.MetalFeatures.MaxFeatureSet == MTLFeatureSet.macOS_GPUFamily2_v1)
            {
                _metalLayer.displaySyncEnabled = value;
            }
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            if (_drawable.NativePtr != IntPtr.Zero)
            {
                ObjectiveCRuntime.objc_msgSend(_drawable.NativePtr, "release");
            }
            _framebuffer.Dispose();
            ObjectiveCRuntime.release(_metalLayer.NativePtr);

            _disposed = true;
        }
    }
}
