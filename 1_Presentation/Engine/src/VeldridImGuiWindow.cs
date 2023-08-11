using ImGuiNET;
using System;
using System.Runtime.InteropServices;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;

namespace ImGui.NET.SampleProgram
{
    /// <summary>
    /// The veldrid im gui window class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class VeldridImGuiWindow : IDisposable
    {
        /// <summary>
        /// The gc handle
        /// </summary>
        private readonly GCHandle _gcHandle;
        /// <summary>
        /// The gd
        /// </summary>
        private readonly GraphicsDevice _gd;
        /// <summary>
        /// The vp
        /// </summary>
        private readonly ImGuiViewportPtr _vp;
        /// <summary>
        /// The window
        /// </summary>
        private readonly Sdl2Window _window;
        /// <summary>
        /// The sc
        /// </summary>
        private readonly Swapchain _sc;

        /// <summary>
        /// Gets the value of the window
        /// </summary>
        public Sdl2Window Window => _window;
        /// <summary>
        /// Gets the value of the swapchain
        /// </summary>
        public Swapchain Swapchain => _sc;

        /// <summary>
        /// Initializes a new instance of the <see cref="VeldridImGuiWindow"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="vp">The vp</param>
        public VeldridImGuiWindow(GraphicsDevice gd, ImGuiViewportPtr vp)
        {
            _gcHandle = GCHandle.Alloc(this);
            _gd = gd;
            _vp = vp;

            SDL_WindowFlags flags = SDL_WindowFlags.Hidden;
            if ((vp.Flags & ImGuiViewportFlags.NoTaskBarIcon) != 0)
            {
                flags |= SDL_WindowFlags.SkipTaskbar;
            }
            if ((vp.Flags & ImGuiViewportFlags.NoDecoration) != 0)
            {
                flags |= SDL_WindowFlags.Borderless;
            }
            else
            {
                flags |= SDL_WindowFlags.Resizable;
            }

            if ((vp.Flags & ImGuiViewportFlags.TopMost) != 0)
            {
                flags |= SDL_WindowFlags.AlwaysOnTop;
            }

            _window = new Sdl2Window(
                "No Title Yet",
                (int)vp.Pos.X, (int)vp.Pos.Y,
                (int)vp.Size.X, (int)vp.Size.Y,
                flags,
                false);
            _window.Resized += () => _vp.PlatformRequestResize = true;
            _window.Moved += p => _vp.PlatformRequestMove = true;
            _window.Closed += () => _vp.PlatformRequestClose = true;

            SwapchainSource scSource = VeldridStartup.GetSwapchainSource(_window);
            SwapchainDescription scDesc = new SwapchainDescription(scSource, (uint)_window.Width, (uint)_window.Height, null, true, false);
            _sc = _gd.ResourceFactory.CreateSwapchain(scDesc);
            _window.Resized += () => _sc.Resize((uint)_window.Width, (uint)_window.Height);

            vp.PlatformUserData = (IntPtr)_gcHandle;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VeldridImGuiWindow"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="vp">The vp</param>
        /// <param name="window">The window</param>
        public VeldridImGuiWindow(GraphicsDevice gd, ImGuiViewportPtr vp, Sdl2Window window)
        {
            _gcHandle = GCHandle.Alloc(this);
            _gd = gd;
            _vp = vp;
            _window = window;
            vp.PlatformUserData = (IntPtr)_gcHandle;
        }

        /// <summary>
        /// Updates this instance
        /// </summary>
        public void Update()
        {
            _window.PumpEvents();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _gd.WaitForIdle(); // TODO: Shouldn't be necessary, but Vulkan backend trips a validation error (swapchain in use when disposed).
            _sc.Dispose();
            _window.Close();
            _gcHandle.Free();
        }
    }
}
