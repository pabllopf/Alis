using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Backends.SDL2;
using Alis.Core.Graphic.Imgui;
using Alis.Core.Graphic.Imgui.Extras.ImGuizmo;
using Alis.Core.Graphic.Imgui.Extras.ImNodes;
using Alis.Core.Graphic.Imgui.Extras.ImPlot;

namespace Alis.Core.Graphic.Backends.UI
{
    /// <summary>
    /// A modified version of Veldrid.ImGui's ImGuiRenderer.
    /// Manages input for ImGui and handles rendering ImGui's DrawLists with Veldrid.
    /// </summary>
    public class ImGuiController : IDisposable
    {
        /// <summary>
        /// The gd
        /// </summary>
        private GraphicsDevice _gd;
        /// <summary>
        /// The window
        /// </summary>
        private readonly Sdl2Window _window;
        /// <summary>
        /// The frame begun
        /// </summary>
        private bool _frameBegun;

        // Veldrid objects
        /// <summary>
        /// The vertex buffer
        /// </summary>
        private DeviceBuffer _vertexBuffer;
        /// <summary>
        /// The index buffer
        /// </summary>
        private DeviceBuffer _indexBuffer;
        /// <summary>
        /// The proj matrix buffer
        /// </summary>
        private DeviceBuffer _projMatrixBuffer;
        /// <summary>
        /// The font texture
        /// </summary>
        private Texture _fontTexture;
        /// <summary>
        /// The font texture view
        /// </summary>
        private TextureView _fontTextureView;
        /// <summary>
        /// The vertex shader
        /// </summary>
        private Shader _vertexShader;
        /// <summary>
        /// The fragment shader
        /// </summary>
        private Shader _fragmentShader;
        /// <summary>
        /// The layout
        /// </summary>
        private ResourceLayout _layout;
        /// <summary>
        /// The texture layout
        /// </summary>
        private ResourceLayout _textureLayout;
        /// <summary>
        /// The pipeline
        /// </summary>
        private Pipeline _pipeline;
        /// <summary>
        /// The main resource set
        /// </summary>
        private ResourceSet _mainResourceSet;
        /// <summary>
        /// The font texture resource set
        /// </summary>
        private ResourceSet _fontTextureResourceSet;

        /// <summary>
        /// The int ptr
        /// </summary>
        private IntPtr _fontAtlasID = (IntPtr)1;
        /// <summary>
        /// The control down
        /// </summary>
        private bool _controlDown;
        /// <summary>
        /// The shift down
        /// </summary>
        private bool _shiftDown;
        /// <summary>
        /// The alt down
        /// </summary>
        private bool _altDown;
        /// <summary>
        /// The win key down
        /// </summary>
        private bool _winKeyDown;

        /// <summary>
        /// The window width
        /// </summary>
        private int _windowWidth;
        /// <summary>
        /// The window height
        /// </summary>
        private int _windowHeight;
        /// <summary>
        /// The one
        /// </summary>
        private Vector2 _scaleFactor = Vector2.One;

        // Image trackers
        /// <summary>
        /// The resource set info
        /// </summary>
        private readonly Dictionary<TextureView, ResourceSetInfo> _setsByView
            = new Dictionary<TextureView, ResourceSetInfo>();
        /// <summary>
        /// The texture view
        /// </summary>
        private readonly Dictionary<Texture, TextureView> _autoViewsByTexture
            = new Dictionary<Texture, TextureView>();
        /// <summary>
        /// The resource set info
        /// </summary>
        private readonly Dictionary<IntPtr, ResourceSetInfo> _viewsById = new Dictionary<IntPtr, ResourceSetInfo>();
        /// <summary>
        /// The disposable
        /// </summary>
        private readonly List<IDisposable> _ownedResources = new List<IDisposable>();
        /// <summary>
        /// The main viewport window
        /// </summary>
        private readonly VeldridImGuiWindow _mainViewportWindow;
        /// <summary>
        /// The create window
        /// </summary>
        private readonly Platform_CreateWindow _createWindow;
        /// <summary>
        /// The destroy window
        /// </summary>
        private readonly Platform_DestroyWindow _destroyWindow;
        /// <summary>
        /// The get window pos
        /// </summary>
        private readonly Platform_GetWindowPos _getWindowPos;
        /// <summary>
        /// The show window
        /// </summary>
        private readonly Platform_ShowWindow _showWindow;
        /// <summary>
        /// The set window pos
        /// </summary>
        private readonly Platform_SetWindowPos _setWindowPos;
        /// <summary>
        /// The set window size
        /// </summary>
        private readonly Platform_SetWindowSize _setWindowSize;
        /// <summary>
        /// The get window size
        /// </summary>
        private readonly Platform_GetWindowSize _getWindowSize;
        /// <summary>
        /// The set window focus
        /// </summary>
        private readonly Platform_SetWindowFocus _setWindowFocus;
        /// <summary>
        /// The get window focus
        /// </summary>
        private readonly Platform_GetWindowFocus _getWindowFocus;
        /// <summary>
        /// The get window minimized
        /// </summary>
        private readonly Platform_GetWindowMinimized _getWindowMinimized;
        /// <summary>
        /// The set window title
        /// </summary>
        private readonly Platform_SetWindowTitle _setWindowTitle;
        /// <summary>
        /// The last assigned id
        /// </summary>
        private int _lastAssignedID = 100;

        /// <summary>
        /// Constructs a new ImGuiController.
        /// </summary>
        public unsafe ImGuiController(GraphicsDevice gd, Sdl2Window window, OutputDescription outputDescription, int width, int height)
        {
            _gd = gd;
            _window = window;
            _windowWidth = width;
            _windowHeight = height;

            IntPtr context = ImGui.CreateContext();
            ImNodes.CreateContext();
            ImPlot.CreateContext();
            ImGuizmo.SetImGuiContext(context);
            ImGui.SetCurrentContext(context);
            ImGuiIOPtr io = ImGui.GetIO();

            io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
            io.ConfigFlags |= ImGuiConfigFlags.ViewportsEnable;

            ImGuiPlatformIOPtr platformIO = ImGui.GetPlatformIO();
            ImGuiViewportPtr mainViewport = platformIO.Viewports[0];
            mainViewport.PlatformHandle = window.Handle;
            _mainViewportWindow = new VeldridImGuiWindow(gd, mainViewport, _window);

            _createWindow = CreateWindow;
            _destroyWindow = DestroyWindow;
            _getWindowPos = GetWindowPos;
            _showWindow = ShowWindow;
            _setWindowPos = SetWindowPos;
            _setWindowSize = SetWindowSize;
            _getWindowSize = GetWindowSize;
            _setWindowFocus = SetWindowFocus;
            _getWindowFocus = GetWindowFocus;
            _getWindowMinimized = GetWindowMinimized;
            _setWindowTitle = SetWindowTitle;

            platformIO.Platform_CreateWindow = Marshal.GetFunctionPointerForDelegate(_createWindow);
            platformIO.Platform_DestroyWindow = Marshal.GetFunctionPointerForDelegate(_destroyWindow);
            platformIO.Platform_ShowWindow = Marshal.GetFunctionPointerForDelegate(_showWindow);
            platformIO.Platform_SetWindowPos = Marshal.GetFunctionPointerForDelegate(_setWindowPos);
            platformIO.Platform_SetWindowSize = Marshal.GetFunctionPointerForDelegate(_setWindowSize);
            platformIO.Platform_SetWindowFocus = Marshal.GetFunctionPointerForDelegate(_setWindowFocus);
            platformIO.Platform_GetWindowFocus = Marshal.GetFunctionPointerForDelegate(_getWindowFocus);
            platformIO.Platform_GetWindowMinimized = Marshal.GetFunctionPointerForDelegate(_getWindowMinimized);
            platformIO.Platform_SetWindowTitle = Marshal.GetFunctionPointerForDelegate(_setWindowTitle);

            ImGuiNative.ImGuiPlatformIO_Set_Platform_GetWindowPos(platformIO.NativePtr, Marshal.GetFunctionPointerForDelegate(_getWindowPos));
            ImGuiNative.ImGuiPlatformIO_Set_Platform_GetWindowSize(platformIO.NativePtr, Marshal.GetFunctionPointerForDelegate(_getWindowSize));

            unsafe
            {
                io.NativePtr->BackendPlatformName = (byte*)new FixedAsciiString("Veldrid.SDL2 Backend").DataPtr;
            }
            
            io.BackendFlags |= ImGuiBackendFlags.HasMouseCursors;
            io.BackendFlags |= ImGuiBackendFlags.HasSetMousePos;
            io.BackendFlags |= ImGuiBackendFlags.PlatformHasViewports;
            io.BackendFlags |= ImGuiBackendFlags.RendererHasViewports;
            ImGui.GetIO().BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset;

            var fonts = ImGui.GetIO().Fonts;
            ImGui.GetIO().Fonts.AddFontDefault();

            CreateDeviceResources(gd, outputDescription);
            SetKeyMappings();

            SetPerFrameImGuiData(1f / 60f);
            UpdateMonitors();

            ImGui.NewFrame();
            _frameBegun = true;
        }

        /// <summary>
        /// Creates the window using the specified vp
        /// </summary>
        /// <param name="vp">The vp</param>
        private void CreateWindow(ImGuiViewportPtr vp)
        {
            VeldridImGuiWindow window = new VeldridImGuiWindow(_gd, vp);
        }

        /// <summary>
        /// Destroys the window using the specified vp
        /// </summary>
        /// <param name="vp">The vp</param>
        private void DestroyWindow(ImGuiViewportPtr vp)
        {
            if (vp.PlatformUserData != IntPtr.Zero)
            {
                VeldridImGuiWindow window = (VeldridImGuiWindow)GCHandle.FromIntPtr(vp.PlatformUserData).Target;
                window.Dispose();

                vp.PlatformUserData = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Shows the window using the specified vp
        /// </summary>
        /// <param name="vp">The vp</param>
        private void ShowWindow(ImGuiViewportPtr vp)
        {
            VeldridImGuiWindow window = (VeldridImGuiWindow)GCHandle.FromIntPtr(vp.PlatformUserData).Target;
            Sdl2Native.SDL_ShowWindow(window.Window.SdlWindowHandle);
        }

        /// <summary>
        /// Gets the window pos using the specified vp
        /// </summary>
        /// <param name="vp">The vp</param>
        /// <param name="outPos">The out pos</param>
        private unsafe void GetWindowPos(ImGuiViewportPtr vp, Vector2* outPos)
        {
            VeldridImGuiWindow window = (VeldridImGuiWindow)GCHandle.FromIntPtr(vp.PlatformUserData).Target;
            *outPos = new Vector2(window.Window.Bounds.X, window.Window.Bounds.Y);
        }

        /// <summary>
        /// Sets the window pos using the specified vp
        /// </summary>
        /// <param name="vp">The vp</param>
        /// <param name="pos">The pos</param>
        private void SetWindowPos(ImGuiViewportPtr vp, Vector2 pos)
        {
            VeldridImGuiWindow window = (VeldridImGuiWindow)GCHandle.FromIntPtr(vp.PlatformUserData).Target;
            window.Window.X = (int)pos.X;
            window.Window.Y = (int)pos.Y;
        }

        /// <summary>
        /// Sets the window size using the specified vp
        /// </summary>
        /// <param name="vp">The vp</param>
        /// <param name="size">The size</param>
        private void SetWindowSize(ImGuiViewportPtr vp, Vector2 size)
        {
            VeldridImGuiWindow window = (VeldridImGuiWindow)GCHandle.FromIntPtr(vp.PlatformUserData).Target;
            Sdl2Native.SDL_SetWindowSize(window.Window.SdlWindowHandle, (int)size.X, (int)size.Y);
        }

        /// <summary>
        /// Gets the window size using the specified vp
        /// </summary>
        /// <param name="vp">The vp</param>
        /// <param name="outSize">The out size</param>
        private unsafe void GetWindowSize(ImGuiViewportPtr vp, Vector2* outSize)
        {
            VeldridImGuiWindow window = (VeldridImGuiWindow)GCHandle.FromIntPtr(vp.PlatformUserData).Target;
            Rectangle bounds = window.Window.Bounds;
            *outSize = new Vector2(bounds.Width, bounds.Height);
        }

        /// <summary>
        /// The sdl raisewindow
        /// </summary>
        private delegate void SDL_RaiseWindow_t(IntPtr sdl2Window);
        /// <summary>
        /// The sdl raisewindow
        /// </summary>
        private static SDL_RaiseWindow_t p_sdl_RaiseWindow;

        /// <summary>
        /// The sdl getglobalmousestate
        /// </summary>
        private unsafe delegate uint SDL_GetGlobalMouseState_t(int* x, int* y);
        /// <summary>
        /// The sdl getglobalmousestate
        /// </summary>
        private static SDL_GetGlobalMouseState_t p_sdl_GetGlobalMouseState;

        /// <summary>
        /// The sdl getdisplayusablebounds
        /// </summary>
        private unsafe delegate int SDL_GetDisplayUsableBounds_t(int displayIndex, Rectangle* rect);
        /// <summary>
        /// The sdl getdisplayusablebounds
        /// </summary>
        private static SDL_GetDisplayUsableBounds_t p_sdl_GetDisplayUsableBounds_t;

        /// <summary>
        /// The sdl getnumvideodisplays
        /// </summary>
        private delegate int SDL_GetNumVideoDisplays_t();
        /// <summary>
        /// The sdl getnumvideodisplays
        /// </summary>
        private static SDL_GetNumVideoDisplays_t p_sdl_GetNumVideoDisplays;

        /// <summary>
        /// Sets the window focus using the specified vp
        /// </summary>
        /// <param name="vp">The vp</param>
        private void SetWindowFocus(ImGuiViewportPtr vp)
        {
            if (p_sdl_RaiseWindow == null)
            {
                p_sdl_RaiseWindow = Sdl2Native.LoadFunction<SDL_RaiseWindow_t>("SDL_RaiseWindow");
            }

            VeldridImGuiWindow window = (VeldridImGuiWindow)GCHandle.FromIntPtr(vp.PlatformUserData).Target;
            p_sdl_RaiseWindow(window.Window.SdlWindowHandle);
        }

        /// <summary>
        /// Gets the window focus using the specified vp
        /// </summary>
        /// <param name="vp">The vp</param>
        /// <returns>The byte</returns>
        private byte GetWindowFocus(ImGuiViewportPtr vp)
        {
            VeldridImGuiWindow window = (VeldridImGuiWindow)GCHandle.FromIntPtr(vp.PlatformUserData).Target;
            SDL_WindowFlags flags = Sdl2Native.SDL_GetWindowFlags(window.Window.SdlWindowHandle);
            return (flags & SDL_WindowFlags.InputFocus) != 0 ? (byte)1 : (byte)0;
        }

        /// <summary>
        /// Gets the window minimized using the specified vp
        /// </summary>
        /// <param name="vp">The vp</param>
        /// <returns>The byte</returns>
        private byte GetWindowMinimized(ImGuiViewportPtr vp)
        {
            VeldridImGuiWindow window = (VeldridImGuiWindow)GCHandle.FromIntPtr(vp.PlatformUserData).Target;
            SDL_WindowFlags flags = Sdl2Native.SDL_GetWindowFlags(window.Window.SdlWindowHandle);
            return (flags & SDL_WindowFlags.Minimized) != 0 ? (byte)1 : (byte)0;
        }

        /// <summary>
        /// Sets the window title using the specified vp
        /// </summary>
        /// <param name="vp">The vp</param>
        /// <param name="title">The title</param>
        private unsafe void SetWindowTitle(ImGuiViewportPtr vp, IntPtr title)
        {
            VeldridImGuiWindow window = (VeldridImGuiWindow)GCHandle.FromIntPtr(vp.PlatformUserData).Target;
            byte* titlePtr = (byte*)title;
            int count = 0;
            while (titlePtr[count] != 0)
            {
                count += 1;
            }
            window.Window.Title = System.Text.Encoding.ASCII.GetString(titlePtr, count);
        }

        /// <summary>
        /// Windows the resized using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void WindowResized(int width, int height)
        {
            _windowWidth = width;
            _windowHeight = height;
        }

        /// <summary>
        /// Destroys the device objects
        /// </summary>
        public void DestroyDeviceObjects()
        {
            Dispose();
        }

        /// <summary>
        /// Creates the device resources using the specified gd
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="outputDescription">The output description</param>
        public void CreateDeviceResources(GraphicsDevice gd, OutputDescription outputDescription)
        {
            _gd = gd;
            ResourceFactory factory = gd.ResourceFactory;
            _vertexBuffer = factory.CreateBuffer(new BufferDescription(10000, BufferUsage.VertexBuffer | BufferUsage.Dynamic));
            _vertexBuffer.Name = "ImGui.NET Vertex Buffer";
            _indexBuffer = factory.CreateBuffer(new BufferDescription(2000, BufferUsage.IndexBuffer | BufferUsage.Dynamic));
            _indexBuffer.Name = "ImGui.NET Index Buffer";
            RecreateFontDeviceTexture(gd);

            _projMatrixBuffer = factory.CreateBuffer(new BufferDescription(64, BufferUsage.UniformBuffer | BufferUsage.Dynamic));
            _projMatrixBuffer.Name = "ImGui.NET Projection Buffer";

            byte[] vertexShaderBytes = LoadEmbeddedShaderCode(gd.ResourceFactory, "imgui-vertex", ShaderStages.Vertex);
            byte[] fragmentShaderBytes = LoadEmbeddedShaderCode(gd.ResourceFactory, "imgui-frag", ShaderStages.Fragment);
            _vertexShader = factory.CreateShader(new ShaderDescription(ShaderStages.Vertex, vertexShaderBytes, gd.BackendType == GraphicsBackend.Metal ? "VS" : "main"));
            _fragmentShader = factory.CreateShader(new ShaderDescription(ShaderStages.Fragment, fragmentShaderBytes, gd.BackendType == GraphicsBackend.Metal ? "FS" : "main"));

            VertexLayoutDescription[] vertexLayouts = new VertexLayoutDescription[]
            {
                new VertexLayoutDescription(
                    new VertexElementDescription("in_position", VertexElementSemantic.Position, VertexElementFormat.Float2),
                    new VertexElementDescription("in_texCoord", VertexElementSemantic.TextureCoordinate, VertexElementFormat.Float2),
                    new VertexElementDescription("in_color", VertexElementSemantic.Color, VertexElementFormat.Byte4_Norm))
            };

            _layout = factory.CreateResourceLayout(new ResourceLayoutDescription(
                new ResourceLayoutElementDescription("ProjectionMatrixBuffer", ResourceKind.UniformBuffer, ShaderStages.Vertex),
                new ResourceLayoutElementDescription("MainSampler", ResourceKind.Sampler, ShaderStages.Fragment)));
            _textureLayout = factory.CreateResourceLayout(new ResourceLayoutDescription(
                new ResourceLayoutElementDescription("MainTexture", ResourceKind.TextureReadOnly, ShaderStages.Fragment)));

            GraphicsPipelineDescription pd = new GraphicsPipelineDescription(
                BlendStateDescription.SingleAlphaBlend,
                new DepthStencilStateDescription(false, false, ComparisonKind.Always),
                new RasterizerStateDescription(FaceCullMode.None, PolygonFillMode.Solid, FrontFace.Clockwise, false, true),
                PrimitiveTopology.TriangleList,
                new ShaderSetDescription(vertexLayouts, new[] { _vertexShader, _fragmentShader }),
                new ResourceLayout[] { _layout, _textureLayout },
                outputDescription,
                ResourceBindingModel.Default);
            _pipeline = factory.CreateGraphicsPipeline(ref pd);

            _mainResourceSet = factory.CreateResourceSet(new ResourceSetDescription(_layout,
                _projMatrixBuffer,
                gd.PointSampler));

            _fontTextureResourceSet = factory.CreateResourceSet(new ResourceSetDescription(_textureLayout, _fontTextureView));
        }

        /// <summary>
        /// Gets or creates a handle for a texture to be drawn with ImGui.
        /// Pass the returned handle to Image() or ImageButton().
        /// </summary>
        public IntPtr GetOrCreateImGuiBinding(ResourceFactory factory, TextureView textureView)
        {
            if (!_setsByView.TryGetValue(textureView, out ResourceSetInfo rsi))
            {
                ResourceSet resourceSet = factory.CreateResourceSet(new ResourceSetDescription(_textureLayout, textureView));
                rsi = new ResourceSetInfo(GetNextImGuiBindingID(), resourceSet);

                _setsByView.Add(textureView, rsi);
                _viewsById.Add(rsi.ImGuiBinding, rsi);
                _ownedResources.Add(resourceSet);
            }

            return rsi.ImGuiBinding;
        }

        /// <summary>
        /// Gets the next im gui binding id
        /// </summary>
        /// <returns>The int ptr</returns>
        private IntPtr GetNextImGuiBindingID()
        {
            int newID = _lastAssignedID++;
            return (IntPtr)newID;
        }

        /// <summary>
        /// Gets or creates a handle for a texture to be drawn with ImGui.
        /// Pass the returned handle to Image() or ImageButton().
        /// </summary>
        public IntPtr GetOrCreateImGuiBinding(ResourceFactory factory, Texture texture)
        {
            if (!_autoViewsByTexture.TryGetValue(texture, out TextureView textureView))
            {
                textureView = factory.CreateTextureView(texture);
                _autoViewsByTexture.Add(texture, textureView);
                _ownedResources.Add(textureView);
            }

            return GetOrCreateImGuiBinding(factory, textureView);
        }

        /// <summary>
        /// Retrieves the shader texture binding for the given helper handle.
        /// </summary>
        public ResourceSet GetImageResourceSet(IntPtr imGuiBinding)
        {
            if (!_viewsById.TryGetValue(imGuiBinding, out ResourceSetInfo tvi))
            {
                throw new InvalidOperationException("No registered ImGui binding with id " + imGuiBinding.ToString());
            }

            return tvi.ResourceSet;
        }

        /// <summary>
        /// Clears the cached image resources
        /// </summary>
        public void ClearCachedImageResources()
        {
            foreach (IDisposable resource in _ownedResources)
            {
                resource.Dispose();
            }

            _ownedResources.Clear();
            _setsByView.Clear();
            _viewsById.Clear();
            _autoViewsByTexture.Clear();
            _lastAssignedID = 100;
        }

        /// <summary>
        /// Loads the embedded shader code using the specified factory
        /// </summary>
        /// <param name="factory">The factory</param>
        /// <param name="name">The name</param>
        /// <param name="stage">The stage</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>The byte array</returns>
        private byte[] LoadEmbeddedShaderCode(ResourceFactory factory, string name, ShaderStages stage)
        {
            switch (factory.BackendType)
            {
                case GraphicsBackend.Direct3D11:
                {
                    string resourceName = name + ".hlsl.bytes";
                    return GetEmbeddedResourceBytes(resourceName);
                }
                case GraphicsBackend.OpenGL:
                {
                    string resourceName = name + ".glsl";
                    return GetEmbeddedResourceBytes(resourceName);
                }
                case GraphicsBackend.Vulkan:
                {
                    string resourceName = name + ".spv";
                    return GetEmbeddedResourceBytes(resourceName);
                }
                case GraphicsBackend.Metal:
                {
                    string resourceName = name + ".metallib";
                    return GetEmbeddedResourceBytes(resourceName);
                }
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the embedded resource bytes using the specified resource name
        /// </summary>
        /// <param name="resourceName">The resource name</param>
        /// <returns>The byte array</returns>
        private byte[] GetEmbeddedResourceBytes(string resourceName)
        {
            Assembly assembly = typeof(ImGuiController).Assembly;
            using (Stream s = assembly.GetManifestResourceStream(resourceName))
            {
                byte[] ret = new byte[s.Length];
                s.Read(ret, 0, (int)s.Length);
                return ret;
            }
        }

        /// <summary>
        /// Recreates the device texture used to render text.
        /// </summary>
        public unsafe void RecreateFontDeviceTexture(GraphicsDevice gd)
        {
            ImGuiIOPtr io = ImGui.GetIO();
            // Build
            byte* pixels;
            int width, height, bytesPerPixel;
            io.Fonts.GetTexDataAsRGBA32(out pixels, out width, out height, out bytesPerPixel);
            // Store our identifier
            io.Fonts.SetTexID(_fontAtlasID);

            _fontTexture = gd.ResourceFactory.CreateTexture(TextureDescription.Texture2D(
                (uint)width,
                (uint)height,
                1,
                1,
                PixelFormat.R8_G8_B8_A8_UNorm,
                TextureUsage.Sampled));
            _fontTexture.Name = "ImGui.NET Font Texture";
            gd.UpdateTexture(
                _fontTexture,
                (IntPtr)pixels,
                (uint)(bytesPerPixel * width * height),
                0,
                0,
                0,
                (uint)width,
                (uint)height,
                1,
                0,
                0);
            _fontTextureView = gd.ResourceFactory.CreateTextureView(_fontTexture);

            io.Fonts.ClearTexData();
        }

        /// <summary>
        /// Renders the ImGui draw list data.
        /// This method requires a <see cref="GraphicsDevice"/> because it may create new DeviceBuffers if the size of vertex
        /// or index data has increased beyond the capacity of the existing buffers.
        /// A <see cref="CommandList"/> is needed to submit drawing and resource update commands.
        /// </summary>
        public void Render(GraphicsDevice gd, CommandList cl)
        {
            if (_frameBegun)
            {
                _frameBegun = false;
                ImGui.Render();
                RenderImDrawData(ImGui.GetDrawData(), gd, cl);

                // Update and Render additional Platform Windows
                if ((ImGui.GetIO().ConfigFlags & ImGuiConfigFlags.ViewportsEnable) != 0)
                {
                    ImGui.UpdatePlatformWindows();
                    ImGuiPlatformIOPtr platformIO = ImGui.GetPlatformIO();
                    for (int i = 1; i < platformIO.Viewports.Size; i++)
                    {
                        ImGuiViewportPtr vp = platformIO.Viewports[i];
                        VeldridImGuiWindow window = (VeldridImGuiWindow)GCHandle.FromIntPtr(vp.PlatformUserData).Target;
                        cl.SetFramebuffer(window.Swapchain.Framebuffer);
                        RenderImDrawData(vp.DrawData, gd, cl);
                    }
                }
            }
        }

        /// <summary>
        /// Swaps the extra windows using the specified gd
        /// </summary>
        /// <param name="gd">The gd</param>
        public void SwapExtraWindows(GraphicsDevice gd)
        {
            ImGuiPlatformIOPtr platformIO = ImGui.GetPlatformIO();
            for (int i = 1; i < platformIO.Viewports.Size; i++)
            {
                ImGuiViewportPtr vp = platformIO.Viewports[i];
                VeldridImGuiWindow window = (VeldridImGuiWindow)GCHandle.FromIntPtr(vp.PlatformUserData).Target;
                gd.SwapBuffers(window.Swapchain);
            }
        }

        /// <summary>
        /// Updates ImGui input and IO configuration state.
        /// </summary>
        public void Update(float deltaSeconds, InputSnapshot snapshot)
        {
            if (_frameBegun)
            {
                ImGui.Render();
                ImGui.UpdatePlatformWindows();
            }

            SetPerFrameImGuiData(deltaSeconds);
            UpdateImGuiInput(snapshot);
            UpdateMonitors();

            _frameBegun = true;
            ImGui.NewFrame();

            ImGui.Text($"Main viewport Position: {ImGui.GetPlatformIO().Viewports[0].Pos}");
            ImGui.Text($"Main viewport Size: {ImGui.GetPlatformIO().Viewports[0].Size}");
            ImGui.Text($"MoouseHoveredViewport: {ImGui.GetIO().MouseHoveredViewport}");
        }

        /// <summary>
        /// Updates the monitors
        /// </summary>
        private unsafe void UpdateMonitors()
        {
            if (p_sdl_GetNumVideoDisplays == null)
            {
                p_sdl_GetNumVideoDisplays = Sdl2Native.LoadFunction<SDL_GetNumVideoDisplays_t>("SDL_GetNumVideoDisplays");
            }
            if (p_sdl_GetDisplayUsableBounds_t == null)
            {
                p_sdl_GetDisplayUsableBounds_t = Sdl2Native.LoadFunction<SDL_GetDisplayUsableBounds_t>("SDL_GetDisplayUsableBounds");
            }

            ImGuiPlatformIOPtr platformIO = ImGui.GetPlatformIO();
            Marshal.FreeHGlobal(platformIO.NativePtr->Monitors.Data);
            int numMonitors = p_sdl_GetNumVideoDisplays();
            IntPtr data = Marshal.AllocHGlobal(Unsafe.SizeOf<ImGuiPlatformMonitor>() * numMonitors);
            platformIO.NativePtr->Monitors = new ImVector(numMonitors, numMonitors, data);
            for (int i = 0; i < numMonitors; i++)
            {
                Rectangle r;
                p_sdl_GetDisplayUsableBounds_t(i, &r);
                ImGuiPlatformMonitorPtr monitor = platformIO.Monitors[i];
                monitor.DpiScale = 1f;
                monitor.MainPos = new Vector2(r.X, r.Y);
                monitor.MainSize = new Vector2(r.Width, r.Height);
                monitor.WorkPos = new Vector2(r.X, r.Y);
                monitor.WorkSize = new Vector2(r.Width, r.Height);
            }
        }

        /// <summary>
        /// Sets per-frame data based on the associated window.
        /// This is called by Update(float).
        /// </summary>
        private void SetPerFrameImGuiData(float deltaSeconds)
        {
            ImGuiIOPtr io = ImGui.GetIO();
            io.DisplaySize = new Vector2(
                _windowWidth / _scaleFactor.X,
                _windowHeight / _scaleFactor.Y);
            io.DisplayFramebufferScale = _scaleFactor;
            io.DeltaTime = deltaSeconds; // DeltaTime is in seconds.

            ImGui.GetPlatformIO().Viewports[0].Pos = new Vector2(_window.X, _window.Y);
            ImGui.GetPlatformIO().Viewports[0].Size = new Vector2(_window.Width, _window.Height);
        }

        /// <summary>
        /// Updates the im gui input using the specified snapshot
        /// </summary>
        /// <param name="snapshot">The snapshot</param>
        private void UpdateImGuiInput(InputSnapshot snapshot)
        {
            ImGuiIOPtr io = ImGui.GetIO();

            Vector2 mousePosition = snapshot.MousePosition;

            // Determine if any of the mouse buttons were pressed during this snapshot period, even if they are no longer held.
            bool leftPressed = false;
            bool middlePressed = false;
            bool rightPressed = false;
            foreach (MouseEvent me in snapshot.MouseEvents)
            {
                if (me.Down)
                {
                    switch (me.MouseButton)
                    {
                        case MouseButton.Left:
                            leftPressed = true;
                            break;
                        case MouseButton.Middle:
                            middlePressed = true;
                            break;
                        case MouseButton.Right:
                            rightPressed = true;
                            break;
                    }
                }
            }

            io.MouseDown[0] = leftPressed || snapshot.IsMouseDown(MouseButton.Left);
            io.MouseDown[1] = middlePressed || snapshot.IsMouseDown(MouseButton.Right);
            io.MouseDown[2] = rightPressed || snapshot.IsMouseDown(MouseButton.Middle);

            if (p_sdl_GetGlobalMouseState == null)
            {
                p_sdl_GetGlobalMouseState = Sdl2Native.LoadFunction<SDL_GetGlobalMouseState_t>("SDL_GetGlobalMouseState");
            }

            int x, y;
            unsafe
            {
                uint buttons = p_sdl_GetGlobalMouseState(&x, &y);
                io.MouseDown[0] = (buttons & 0b0001) != 0;
                io.MouseDown[1] = (buttons & 0b0010) != 0;
                io.MouseDown[2] = (buttons & 0b0100) != 0;
            }

            io.MousePos = new Vector2(x, y);
            io.MouseWheel = snapshot.WheelDelta;

            IReadOnlyList<char> keyCharPresses = snapshot.KeyCharPresses;
            for (int i = 0; i < keyCharPresses.Count; i++)
            {
                char c = keyCharPresses[i];
                io.AddInputCharacter(c);
            }

            IReadOnlyList<KeyEvent> keyEvents = snapshot.KeyEvents;
            for (int i = 0; i < keyEvents.Count; i++)
            {
                KeyEvent keyEvent = keyEvents[i];
                io.KeysDown[(int)keyEvent.Key] = keyEvent.Down;
                if (keyEvent.Key == Key.ControlLeft)
                {
                    _controlDown = keyEvent.Down;
                }
                if (keyEvent.Key == Key.ShiftLeft)
                {
                    _shiftDown = keyEvent.Down;
                }
                if (keyEvent.Key == Key.AltLeft)
                {
                    _altDown = keyEvent.Down;
                }
                if (keyEvent.Key == Key.WinLeft)
                {
                    _winKeyDown = keyEvent.Down;
                }
            }

            io.KeyCtrl = _controlDown;
            io.KeyAlt = _altDown;
            io.KeyShift = _shiftDown;
            io.KeySuper = _winKeyDown;

            ImVector<ImGuiViewportPtr> viewports = ImGui.GetPlatformIO().Viewports;
            for (int i = 1; i < viewports.Size; i++)
            {
                ImGuiViewportPtr v = viewports[i];
                VeldridImGuiWindow window = ((VeldridImGuiWindow)GCHandle.FromIntPtr(v.PlatformUserData).Target);
                window.Update();
            }
        }

        /// <summary>
        /// Sets the key mappings
        /// </summary>
        private static void SetKeyMappings()
        {
            ImGuiIOPtr io = ImGui.GetIO();
            io.KeyMap[(int)ImGuiKey.Tab] = (int)Key.Tab;
            io.KeyMap[(int)ImGuiKey.LeftArrow] = (int)Key.Left;
            io.KeyMap[(int)ImGuiKey.RightArrow] = (int)Key.Right;
            io.KeyMap[(int)ImGuiKey.UpArrow] = (int)Key.Up;
            io.KeyMap[(int)ImGuiKey.DownArrow] = (int)Key.Down;
            io.KeyMap[(int)ImGuiKey.PageUp] = (int)Key.PageUp;
            io.KeyMap[(int)ImGuiKey.PageDown] = (int)Key.PageDown;
            io.KeyMap[(int)ImGuiKey.Home] = (int)Key.Home;
            io.KeyMap[(int)ImGuiKey.End] = (int)Key.End;
            io.KeyMap[(int)ImGuiKey.Delete] = (int)Key.Delete;
            io.KeyMap[(int)ImGuiKey.Backspace] = (int)Key.BackSpace;
            io.KeyMap[(int)ImGuiKey.Enter] = (int)Key.Enter;
            io.KeyMap[(int)ImGuiKey.Escape] = (int)Key.Escape;
            io.KeyMap[(int)ImGuiKey.Space] = (int)Key.Space;
            io.KeyMap[(int)ImGuiKey.A] = (int)Key.A;
            io.KeyMap[(int)ImGuiKey.C] = (int)Key.C;
            io.KeyMap[(int)ImGuiKey.V] = (int)Key.V;
            io.KeyMap[(int)ImGuiKey.X] = (int)Key.X;
            io.KeyMap[(int)ImGuiKey.Y] = (int)Key.Y;
            io.KeyMap[(int)ImGuiKey.Z] = (int)Key.Z;
            io.KeyMap[(int)ImGuiKey.Space] = (int)Key.Space;
        }

        /// <summary>
        /// Renders the im draw data using the specified draw data
        /// </summary>
        /// <param name="draw_data">The draw data</param>
        /// <param name="gd">The gd</param>
        /// <param name="cl">The cl</param>
        /// <exception cref="NotImplementedException"></exception>
        private void RenderImDrawData(ImDrawDataPtr draw_data, GraphicsDevice gd, CommandList cl)
        {
            uint vertexOffsetInVertices = 0;
            uint indexOffsetInElements = 0;

            if (draw_data.CmdListsCount == 0)
            {
                return;
            }

            uint totalVBSize = (uint)(draw_data.TotalVtxCount * Unsafe.SizeOf<ImDrawVert>());
            if (totalVBSize > _vertexBuffer.SizeInBytes)
            {
                gd.DisposeWhenIdle(_vertexBuffer);
                _vertexBuffer = gd.ResourceFactory.CreateBuffer(new BufferDescription((uint)(totalVBSize * 1.5f), BufferUsage.VertexBuffer | BufferUsage.Dynamic));
            }

            uint totalIBSize = (uint)(draw_data.TotalIdxCount * sizeof(ushort));
            if (totalIBSize > _indexBuffer.SizeInBytes)
            {
                gd.DisposeWhenIdle(_indexBuffer);
                _indexBuffer = gd.ResourceFactory.CreateBuffer(new BufferDescription((uint)(totalIBSize * 1.5f), BufferUsage.IndexBuffer | BufferUsage.Dynamic));
            }

            Vector2 pos = draw_data.DisplayPos;
            for (int i = 0; i < draw_data.CmdListsCount; i++)
            {
                ImDrawListPtr cmd_list = draw_data.CmdListsRange[i];

                cl.UpdateBuffer(
                    _vertexBuffer,
                    vertexOffsetInVertices * (uint)Unsafe.SizeOf<ImDrawVert>(),
                    cmd_list.VtxBuffer.Data,
                    (uint)(cmd_list.VtxBuffer.Size * Unsafe.SizeOf<ImDrawVert>()));

                cl.UpdateBuffer(
                    _indexBuffer,
                    indexOffsetInElements * sizeof(ushort),
                    cmd_list.IdxBuffer.Data,
                    (uint)(cmd_list.IdxBuffer.Size * sizeof(ushort)));

                vertexOffsetInVertices += (uint)cmd_list.VtxBuffer.Size;
                indexOffsetInElements += (uint)cmd_list.IdxBuffer.Size;
            }

            // Setup orthographic projection matrix into our constant buffer
            ImGuiIOPtr io = ImGui.GetIO();
            Matrix4x4 mvp = Matrix4x4.CreateOrthographicOffCenter(
                pos.X,
                pos.X + draw_data.DisplaySize.X,
                pos.Y + draw_data.DisplaySize.Y,
                pos.Y,
                -1.0f,
                1.0f);

            cl.UpdateBuffer(_projMatrixBuffer, 0, ref mvp);

            cl.SetVertexBuffer(0, _vertexBuffer);
            cl.SetIndexBuffer(_indexBuffer, IndexFormat.UInt16);
            cl.SetPipeline(_pipeline);
            cl.SetGraphicsResourceSet(0, _mainResourceSet);

            draw_data.ScaleClipRects(io.DisplayFramebufferScale);

            // Render command lists
            int vtx_offset = 0;
            int idx_offset = 0;
            for (int n = 0; n < draw_data.CmdListsCount; n++)
            {
                ImDrawListPtr cmd_list = draw_data.CmdListsRange[n];
                for (int cmd_i = 0; cmd_i < cmd_list.CmdBuffer.Size; cmd_i++)
                {
                    ImDrawCmdPtr pcmd = cmd_list.CmdBuffer[cmd_i];
                    if (pcmd.UserCallback != IntPtr.Zero)
                    {
                        throw new NotImplementedException();
                    }
                    else
                    {
                        if (pcmd.TextureId != IntPtr.Zero)
                        {
                            if (pcmd.TextureId == _fontAtlasID)
                            {
                                cl.SetGraphicsResourceSet(1, _fontTextureResourceSet);
                            }
                            else
                            {
                                cl.SetGraphicsResourceSet(1, GetImageResourceSet(pcmd.TextureId));
                            }
                        }

                        cl.SetScissorRect(
                            0,
                            (uint)(pcmd.ClipRect.X - pos.X),
                            (uint)(pcmd.ClipRect.Y - pos.Y),
                            (uint)(pcmd.ClipRect.Z - pcmd.ClipRect.X),
                            (uint)(pcmd.ClipRect.W - pcmd.ClipRect.Y));

                        cl.DrawIndexed(pcmd.ElemCount, 1, pcmd.IdxOffset + (uint)idx_offset, (int)pcmd.VtxOffset + vtx_offset, 0);
                    }
                }
                vtx_offset += cmd_list.VtxBuffer.Size;
                idx_offset += cmd_list.IdxBuffer.Size;
            }
        }

        /// <summary>
        /// Frees all graphics resources used by the renderer.
        /// </summary>
        public void Dispose()
        {
            _vertexBuffer.Dispose();
            _indexBuffer.Dispose();
            _projMatrixBuffer.Dispose();
            _fontTexture.Dispose();
            _fontTextureView.Dispose();
            _vertexShader.Dispose();
            _fragmentShader.Dispose();
            _layout.Dispose();
            _textureLayout.Dispose();
            _pipeline.Dispose();
            _mainResourceSet.Dispose();

            foreach (IDisposable resource in _ownedResources)
            {
                resource.Dispose();
            }
        }

        /// <summary>
        /// The resource set info
        /// </summary>
        private struct ResourceSetInfo
        {
            /// <summary>
            /// The im gui binding
            /// </summary>
            public readonly IntPtr ImGuiBinding;
            /// <summary>
            /// The resource set
            /// </summary>
            public readonly ResourceSet ResourceSet;

            /// <summary>
            /// Initializes a new instance of the <see cref="ResourceSetInfo"/> class
            /// </summary>
            /// <param name="imGuiBinding">The im gui binding</param>
            /// <param name="resourceSet">The resource set</param>
            public ResourceSetInfo(IntPtr imGuiBinding, ResourceSet resourceSet)
            {
                ImGuiBinding = imGuiBinding;
                ResourceSet = resourceSet;
            }
        }
    }
}
