// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Engine.cs
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
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Alis.App.Engine.Core;
using Alis.App.Engine.Fonts;
using Alis.App.Engine.Shaders;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Memory.Exceptions;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Extension.Graphic.Sdl2;
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Alis.Extension.Graphic.Ui.Extras.Node;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using BeginMode = Alis.Core.Graphic.OpenGL.Enums.BeginMode;
using BlendEquationMode = Alis.Core.Graphic.OpenGL.Enums.BlendEquationMode;
using BlendingFactorDest = Alis.Core.Graphic.OpenGL.Enums.BlendingFactorDest;
using BlendingFactorSrc = Alis.Core.Graphic.OpenGL.Enums.BlendingFactorSrc;
using BufferTarget = Alis.Core.Graphic.OpenGL.Enums.BufferTarget;
using BufferUsageHint = Alis.Core.Graphic.OpenGL.Enums.BufferUsageHint;
using ClearBufferMask = Alis.Core.Graphic.OpenGL.Enums.ClearBufferMask;
using DrawElementsType = Alis.Core.Graphic.OpenGL.Enums.DrawElementsType;
using EnableCap = Alis.Core.Graphic.OpenGL.Enums.EnableCap;
using PixelFormat = Alis.Core.Graphic.OpenGL.Enums.PixelFormat;
using PixelInternalFormat = Alis.Core.Graphic.OpenGL.Enums.PixelInternalFormat;
using PixelType = Alis.Core.Graphic.OpenGL.Enums.PixelType;
using StringName = Alis.Core.Graphic.OpenGL.Enums.StringName;
using TextureParameterName = Alis.Core.Graphic.OpenGL.Enums.TextureParameterName;
using TextureTarget = Alis.Core.Graphic.OpenGL.Enums.TextureTarget;
using VertexAttribPointerType = Alis.Core.Graphic.OpenGL.Enums.VertexAttribPointerType;


namespace Alis.App.Engine
{
    /// <summary>
    ///     The engine class
    /// </summary>
    public class Engine : IDisposable
    {
        /// <summary>
        ///     The name engine
        /// </summary>
        private const string NameEngine = "Welcome to Alis by @pabllopf";

        /// <summary>
        ///     The vertex shader
        /// </summary>
        private static readonly VertexShader VertexShader = new VertexShader();

        /// <summary>
        ///     The fragment shader
        /// </summary>
        private static readonly FragmentShader FragmentShader = new FragmentShader();

        /// <summary>
        ///     The mouse pressed
        /// </summary>
        private readonly bool[] _mousePressed = {false, false, false};

        /// <summary>
        ///     The fullscreen
        /// </summary>
        private readonly bool fullscreen = false;

        /// <summary>
        ///     The height window
        /// </summary>
        private readonly int heightWindow = 575;

        /// <summary>
        ///     The high dpi
        /// </summary>
        private readonly bool highDpi = false;

        /// <summary>
        ///     The width window
        /// </summary>
        private readonly int widthWindow = 1025;

        /// <summary>
        ///     The font texture id
        /// </summary>
        private uint _elementsHandle;

        /// <summary>
        ///     The font texture id
        /// </summary>
        private uint _fontTextureId;

        /// <summary>
        ///     The gl context
        /// </summary>
        private IntPtr _glContext;

        /// <summary>
        ///     The shader
        /// </summary>
        private GlShaderProgram _shader;

        /// <summary>
        ///     The time
        /// </summary>
        private float _time;

        /// <summary>
        ///     The font texture id
        /// </summary>
        private uint _vboHandle;

        /// <summary>
        ///     The font texture id
        /// </summary>
        private uint _vertexArrayObject;

        /// <summary>
        ///     The dockspaceflags
        /// </summary>
        private ImGuiWindowFlags dockspaceflags;

        /// <summary>
        ///     The engine path
        /// </summary>
        private string enginePath;

        /// <summary>
        ///     The windows
        /// </summary>
        private SpaceWork spaceWork = new SpaceWork();

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _shader?.Dispose();
        }


        /// <summary>
        ///     Starts this instance
        /// </summary>
        /// <returns>The int</returns>
        public void Run()
        {
            // Ejecutar la aplicación
            //

            // Establecer el delegado de la aplicación (menú nativo)
            //NSApplication.SharedApplication.Delegate = new AppDelegate();

            // initialize SDL and set a few defaults for the OpenGL context
            if (Sdl.Init(InitSettings.InitEverything) != 0)
            {
                Logger.Info($@"Error of SDL2: {Sdl.GetError()}");
                return;
            }

            Gl.Initialize(Sdl.GetProcAddress);

            enginePath = AppDomain.CurrentDomain.BaseDirectory;

            Environment.CurrentDirectory = spaceWork.Project.Path;
            spaceWork = new SpaceWork();
            spaceWork.Initialize();
            Environment.CurrentDirectory = enginePath;

            Sdl.SetHint(Hint.HintRenderDriver, "opengl");

            // CONFIG THE SDL2 AN OPENGL CONFIGURATION
            Sdl.SetAttributeByInt(Attr.SdlGlContextFlags, (int) Contexts.SdlGlContextForwardCompatibleFlag);
            Sdl.SetAttributeByProfile(Attr.SdlGlContextProfileMask, Profiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(Attr.SdlGlContextMajorVersion, 3);
            Sdl.SetAttributeByInt(Attr.SdlGlContextMinorVersion, 2);

            Sdl.SetAttributeByProfile(Attr.SdlGlContextProfileMask, Profiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(Attr.SdlGlDoubleBuffer, 1);
            Sdl.SetAttributeByInt(Attr.SdlGlDepthSize, 24);
            Sdl.SetAttributeByInt(Attr.SdlGlAlphaSize, 8);
            Sdl.SetAttributeByInt(Attr.SdlGlStencilSize, 8);

            // Enable vsync
            Sdl.SetSwapInterval(1);

            // create the window which should be able to have a valid OpenGL context and is resizable
            WindowSettings flags = WindowSettings.WindowOpengl | WindowSettings.WindowResizable;
            if (fullscreen)
            {
                flags |= WindowSettings.WindowFullscreen;
            }


            flags |= WindowSettings.WindowMaximized;

            if (highDpi)
            {
                flags |= WindowSettings.WindowAllowHighDpi;
            }

            spaceWork.Window = Sdl.CreateWindow(NameEngine,
                (int) WindowPos.WindowPosCentered,
                (int) WindowPos.WindowPosCentered,
                widthWindow, heightWindow, flags);
            _glContext = CreateGlContext(spaceWork.Window);

            // compile the shader program
            _shader = new GlShaderProgram(VertexShader.ShaderCode, FragmentShader.ShaderCode);

            spaceWork.ContextGui = ImGui.CreateContext();

            spaceWork.Io = ImGui.GetIo();
            spaceWork.Io.WantSaveIniSettings = false;

            spaceWork.Io.DisplaySize = new Vector2F(widthWindow, heightWindow);

            Logger.Info($@"IMGUI VERSION {ImGui.GetVersion()}");

            // active plot renders
            spaceWork.Io.BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset |
                                         ImGuiBackendFlags.PlatformHasViewports |
                                         ImGuiBackendFlags.HasGamepad |
                                         ImGuiBackendFlags.HasMouseHoveredViewport |
                                         ImGuiBackendFlags.HasMouseCursors;


            // Enable Keyboard Controls
            spaceWork.Io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard |
                                        ImGuiConfigFlags.NavEnableGamepad;

            // CONFIG DOCKSPACE 
            spaceWork.Io.ConfigFlags |= ImGuiConfigFlags.DockingEnable |
                                        ImGuiConfigFlags.ViewportsEnable;

            ImNodes.CreateContext();
            ImPlot.CreateContext();
            ImGuizMo.SetImGuiContext(spaceWork.ContextGui);
            ImGui.SetCurrentContext(spaceWork.ContextGui);

            // REBUILD ATLAS
            ImFontAtlasPtr fonts = ImGui.GetIo().Fonts;

            //fonts.AddFontDefault();

            float fontSize = 14;
            float fontSizeIcon = 13.5f;

            string fontFileSolid = AssetManager.Find("Engine_JetBrainsMono-Bold.ttf");
            spaceWork.FontLoaded16Solid = fonts.AddFontFromFileTtf(fontFileSolid, fontSize);
            try
            {
                ImFontConfigPtr iconsConfig = ImGui.ImFontConfig();
                iconsConfig.MergeMode = true;
                iconsConfig.SnapH = true;
                iconsConfig.GlyphMinAdvanceX = 18;

                ushort[] iconRanges = new ushort[3];
                iconRanges[0] = FontAwesome5.IconMin;
                iconRanges[1] = FontAwesome5.IconMax;
                iconRanges[2] = 0;

                // Allocate GCHandle to pin IconRanges in memory
                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                // Assuming 'io' is a valid ImGuiIO instance and 'dir' and 'dirIcon' are defined paths
                string fontAwesome = AssetManager.Find(FontAwesome5.NameSolid);
                fonts.AddFontFromFileTtf(fontAwesome, fontSizeIcon, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameSolid} {e.Message}");
                return;
            }

            string fontFileSolid10 = AssetManager.Find("Engine_JetBrainsMono-Bold.ttf");
            spaceWork.FontLoaded10Solid = fonts.AddFontFromFileTtf(fontFileSolid10, 12);
            try
            {
                ImFontConfigPtr iconsConfig = ImGui.ImFontConfig();
                iconsConfig.MergeMode = true;
                iconsConfig.SnapH = true;
                iconsConfig.GlyphMinAdvanceX = 18;

                ushort[] iconRanges = new ushort[3];
                iconRanges[0] = FontAwesome5.IconMin;
                iconRanges[1] = FontAwesome5.IconMax;
                iconRanges[2] = 0;

                // Allocate GCHandle to pin IconRanges in memory
                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                // Assuming 'io' is a valid ImGuiIO instance and 'dir' and 'dirIcon' are defined paths
                string fontAwesome = AssetManager.Find(FontAwesome5.NameSolid);
                fonts.AddFontFromFileTtf(fontAwesome, 12, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameSolid} {e.Message}");
                return;
            }

            string fontFileSolid45 = AssetManager.Find("Engine_JetBrainsMono-Bold.ttf");
            spaceWork.FontLoaded45Bold = fonts.AddFontFromFileTtf(fontFileSolid45, 40);
            try
            {
                ImFontConfigPtr iconsConfig = ImGui.ImFontConfig();
                iconsConfig.MergeMode = true;
                iconsConfig.SnapH = true;
                iconsConfig.GlyphMinAdvanceX = 18;

                ushort[] iconRanges = new ushort[3];
                iconRanges[0] = FontAwesome5.IconMin;
                iconRanges[1] = FontAwesome5.IconMax;
                iconRanges[2] = 0;

                // Allocate GCHandle to pin IconRanges in memory
                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                string fontAwesome = AssetManager.Find(FontAwesome5.NameSolid);
                fonts.AddFontFromFileTtf(fontAwesome, 40, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameSolid} {e.Message}");
                return;
            }

            string fontFileSolid30 = AssetManager.Find("Engine_JetBrainsMono-Bold.ttf");
            spaceWork.FontLoaded30Bold = fonts.AddFontFromFileTtf(fontFileSolid30, 28);
            try
            {
                ImFontConfigPtr iconsConfig = ImGui.ImFontConfig();
                iconsConfig.MergeMode = true;
                iconsConfig.SnapH = true;
                iconsConfig.GlyphMinAdvanceX = 18;

                ushort[] iconRanges = new ushort[3];
                iconRanges[0] = FontAwesome5.IconMin;
                iconRanges[1] = FontAwesome5.IconMax;
                iconRanges[2] = 0;

                // Allocate GCHandle to pin IconRanges in memory
                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                string fontAwesome = AssetManager.Find(FontAwesome5.NameSolid);
                fonts.AddFontFromFileTtf(fontAwesome, 28, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameSolid} {e.Message}");
                return;
            }

            string fontAwesomeLight = AssetManager.Find("Engine_JetBrainsMonoNL-Regular.ttf");
            spaceWork.FontLoaded16Light = fonts.AddFontFromFileTtf(fontAwesomeLight, fontSize);
            try
            {
                ImFontConfigPtr iconsConfig = ImGui.ImFontConfig();
                iconsConfig.MergeMode = true;
                iconsConfig.SnapH = true;
                iconsConfig.GlyphMinAdvanceX = 20;

                ushort[] iconRanges = new ushort[3];
                iconRanges[0] = FontAwesome5.IconMin;
                iconRanges[1] = FontAwesome5.IconMax;
                iconRanges[2] = 0;

                // Allocate GCHandle to pin IconRanges in memory
                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                // Assuming 'io' is a valid ImGuiIO instance and 'dir' and 'dirIcon' are defined paths
                fonts.AddFontFromFileTtf(fontAwesomeLight, fontSizeIcon, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameLight} {e.Message}");
                return;
            }

            fonts.GetTexDataAsRgba32(out IntPtr pixelData, out int width, out int height, out int _);
            _fontTextureId = LoadTexture(pixelData, width, height);
            fonts.TexId = (IntPtr) _fontTextureId;
            fonts.ClearTexData();

            // CONFIG DOCKSPACE
            spaceWork.Viewport = ImGui.GetMainViewport();
            ImGui.SetNextWindowPos(spaceWork.Viewport.WorkPos);
            ImGui.SetNextWindowSize(spaceWork.Viewport.WorkSize);
            ImGui.SetNextWindowViewport(spaceWork.Viewport.Id);
            //ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
            //ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);
            dockspaceflags |= ImGuiWindowFlags.MenuBar;
            dockspaceflags |= ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove;
            dockspaceflags |= ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus;

            // config spaceWork.Style
            spaceWork.Style = ImGui.GetStyle();

            SetStyle();

            // config input manager 

            spaceWork.Io.KeyMap[(int) ImGuiKey.Tab] = (int) SdlScancode.SdlScancodeTab;
            spaceWork.Io.KeyMap[(int) ImGuiKey.LeftArrow] = (int) SdlScancode.SdlScancodeLeft;
            spaceWork.Io.KeyMap[(int) ImGuiKey.RightArrow] = (int) SdlScancode.SdlScancodeRight;
            spaceWork.Io.KeyMap[(int) ImGuiKey.UpArrow] = (int) SdlScancode.SdlScancodeUp;
            spaceWork.Io.KeyMap[(int) ImGuiKey.DownArrow] = (int) SdlScancode.SdlScancodeDown;
            spaceWork.Io.KeyMap[(int) ImGuiKey.PageUp] = (int) SdlScancode.SdlScancodePageup;
            spaceWork.Io.KeyMap[(int) ImGuiKey.PageDown] = (int) SdlScancode.SdlScancodePagedown;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Home] = (int) SdlScancode.SdlScancodeHome;
            spaceWork.Io.KeyMap[(int) ImGuiKey.End] = (int) SdlScancode.SdlScancodeEnd;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Insert] = (int) SdlScancode.SdlScancodeInsert;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Delete] = (int) SdlScancode.SdlScancodeDelete;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Backspace] = (int) SdlScancode.SdlScancodeBackspace;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Space] = (int) SdlScancode.SdlScancodeSpace;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Enter] = (int) SdlScancode.SdlScancodeReturn;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Escape] = (int) SdlScancode.SdlScancodeEscape;
            spaceWork.Io.KeyMap[(int) ImGuiKey.KeypadEnter] = (int) SdlScancode.SdlScancodeReturn2;
            spaceWork.Io.KeyMap[(int) ImGuiKey.A] = (int) SdlScancode.SdlScancodeA;
            spaceWork.Io.KeyMap[(int) ImGuiKey.C] = (int) SdlScancode.SdlScancodeC;
            spaceWork.Io.KeyMap[(int) ImGuiKey.V] = (int) SdlScancode.SdlScancodeV;
            spaceWork.Io.KeyMap[(int) ImGuiKey.X] = (int) SdlScancode.SdlScancodeX;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Y] = (int) SdlScancode.SdlScancodeY;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Z] = (int) SdlScancode.SdlScancodeZ;

            _vboHandle = Gl.GenBuffer();
            _elementsHandle = Gl.GenBuffer();
            _vertexArrayObject = Gl.GenVertexArray();


            // Set icon app:
            string iconPath = AssetManager.Find("Engine_app.bmp");
            if (!string.IsNullOrEmpty(iconPath) && File.Exists(iconPath))
            {
                IntPtr icon = Sdl.LoadBmp(iconPath);
                Sdl.SetWindowIcon(spaceWork.Window, icon);
            }

            spaceWork.Start();

            ImGui.LoadIniSettingsFromDisk(AssetManager.Find("Engine_default_config.ini"));

            while (!spaceWork.Quit)
            {
                while (Sdl.PollEvent(out Event e) != 0)
                {
                    spaceWork.Event = e;
                    ProcessEvent(e);
                    switch (e.type)
                    {
                        case EventType.WindowEvent:
                        {
                            if (e.window.windowEvent == WindowEventId.SdlWindowEventClose)
                            {
                                spaceWork.Quit = true;
                            }

                            break;
                        }

                        case EventType.Keydown:
                        {
                            switch (e.key.KeySym.sym)
                            {
                                case KeyCodes.Escape:
                                    spaceWork.Quit = true;
                                    break;
                            }

                            break;
                        }
                    }
                }

                //Gl.GlClearColor(0.05f, 0.05f, 0.05f, 1.00f);
                ImGui.NewFrame();
                ImGuizMo.BeginFrame();

                Environment.CurrentDirectory = spaceWork.Project.Path;

                // Setup display size (every frame to accommodate for window resizing)
                Vector2F windowSize = Sdl.GetWindowSize(spaceWork.Window);
                Sdl.GetDrawableSize(spaceWork.Window, out int displayW, out int displayH);
                spaceWork.Io.DisplaySize = new Vector2F(windowSize.X, windowSize.Y);
                if ((windowSize.X > 0) && (windowSize.Y > 0))
                {
                    spaceWork.Io.DisplayFramebufferScale = new Vector2F(displayW / windowSize.X, displayH / windowSize.Y);
                }

                // Setup time step (we don't use SDL_GetTicks() because it is using millisecond resolution)
                ulong frequency = Sdl.GetPerformanceFrequency();
                ulong currentTime = Sdl.GetPerformanceCounter();
                spaceWork.Io.DeltaTime = _time > 0 ? (float) ((double) (currentTime - _time) / frequency) : 1.0f / 60.0f;
                if (spaceWork.Io.DeltaTime <= 0)
                {
                    spaceWork.Io.DeltaTime = 0.016f;
                }

                //Logger.Warning($"displayW: {displayW} displayH: {displayH} windowSize.X: {windowSize.X} windowSize.Y: {windowSize.Y}");

                _time = currentTime;

                UpdateMousePosAndButtons();


                RenderProject();


                Sdl.MakeCurrent(spaceWork.Window, _glContext);
                ImGui.Render();

                Gl.GlViewport(0, 0, (int) spaceWork.Io.DisplaySize.X, (int) spaceWork.Io.DisplaySize.Y);
                Gl.GlClear(ClearBufferMask.ColorBufferBit);

                RenderDrawData();

                Environment.CurrentDirectory = enginePath;

                IntPtr backupCurrentWindow = Sdl.GetCurrentWindow();
                IntPtr backupCurrentContext = Sdl.GetCurrentContext();
                ImGui.UpdatePlatformWindows();
                ImGui.RenderPlatformWindowsDefault();
                Sdl.MakeCurrent(backupCurrentWindow, backupCurrentContext);


                Gl.GlDisable(EnableCap.ScissorTest);
                Sdl.SwapWindow(spaceWork.Window);
            }

            if (_shader != null)
            {
                _shader.Dispose();
                _shader = null;
                Gl.DeleteBuffer(_vboHandle);
                Gl.DeleteBuffer(_elementsHandle);
                Gl.DeleteVertexArray(_vertexArrayObject);
                Gl.DeleteTexture(_fontTextureId);
            }

            Sdl.DeleteContext(_glContext);
            Sdl.DestroyWindow(spaceWork.Window);
            Sdl.Quit();
        }


        /// <summary>
        ///     Sets the style
        /// </summary>
        private void SetStyle()
        {
            ref ImGuiStyle style = ref ImGui.GetStyle();

            // Main text color:
            style[(int) ImGuiCol.Text] = new Vector4F(1.0f, 1.0f, 1.0f, 1.0f);

            // Disabled text color:
            style[(int) ImGuiCol.TextDisabled] = new Vector4F(0.5f, 0.5f, 0.5f, 1.0f);

            // Main background color for windows
            style[(int) ImGuiCol.WindowBg] = new Vector4F(0.13f, 0.14f, 0.15f, 1.0f);

            // Main background color for child windows
            style[(int) ImGuiCol.ChildBg] = new Vector4F(0.13f, 0.14f, 0.15f, 1.0f);

            // Background color for tooltips
            style[(int) ImGuiCol.PopupBg] = new Vector4F(0.13f, 0.14f, 0.15f, 1.0f);

            // Border colors
            style[(int) ImGuiCol.Border] = new Vector4F(0.25f, 0.25f, 0.25f, 1.0f);

            // Border shadow color
            style[(int) ImGuiCol.BorderShadow] = new Vector4F(0.0f, 0.0f, 0.0f, 0.0f);

            // Frame background color
            style[(int) ImGuiCol.FrameBg] = new Vector4F(0.2f, 0.2f, 0.2f, 1.0f);

            // Frame background color when hovered
            style[(int) ImGuiCol.FrameBgHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            // Frame background color when active
            style[(int) ImGuiCol.FrameBgActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            // Title bar background color
            style[(int) ImGuiCol.TitleBg] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            // Title bar background color when active
            style[(int) ImGuiCol.TitleBgActive] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            // Title bar background color when collapsed
            style[(int) ImGuiCol.TitleBgCollapsed] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            // Menu bar background color
            style[(int) ImGuiCol.MenuBarBg] = new Vector4F(0.15f, 0.15f, 0.15f, 1.0f);

            // Scrollbar background color
            style[(int) ImGuiCol.ScrollbarBg] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            // Scrollbar grab color
            style[(int) ImGuiCol.ScrollbarGrab] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            // Scrollbar grab color when hovered
            style[(int) ImGuiCol.ScrollbarGrabHovered] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            // Scrollbar grab color when active
            style[(int) ImGuiCol.ScrollbarGrabActive] = new Vector4F(0.5f, 0.5f, 0.5f, 1.0f);

            // Checkmark color
            style[(int) ImGuiCol.CheckMark] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            // Slider grab color
            style[(int) ImGuiCol.SliderGrab] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            // Slider grab color when active
            style[(int) ImGuiCol.SliderGrabActive] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            // Button color
            style[(int) ImGuiCol.Button] = new Vector4F(0.2f, 0.2f, 0.2f, 1.0f);

            // Button color when hovered
            style[(int) ImGuiCol.ButtonHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            // Button color when active
            style[(int) ImGuiCol.ButtonActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            // Header color
            style[(int) ImGuiCol.Header] = new Vector4F(0.2f, 0.2f, 0.2f, 1.0f);

            // Header color when hovered
            style[(int) ImGuiCol.HeaderHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            // Header color when active
            style[(int) ImGuiCol.HeaderActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            // Separator color
            style[(int) ImGuiCol.Separator] = new Vector4F(0.25f, 0.25f, 0.25f, 1.0f);

            // Separator color when hovered
            style[(int) ImGuiCol.SeparatorHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            // Separator color when active
            style[(int) ImGuiCol.SeparatorActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            // Resize grip color
            style[(int) ImGuiCol.ResizeGrip] = new Vector4F(0.2f, 0.2f, 0.2f, 1.0f);

            // Resize grip color when hovered
            style[(int) ImGuiCol.ResizeGripHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            // Resize grip color when active
            style[(int) ImGuiCol.ResizeGripActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            // Tab color
            style[(int) ImGuiCol.Tab] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            // Tab color when hovered
            style[(int) ImGuiCol.TabHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            // Tab color when active
            style[(int) ImGuiCol.TabActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            // Tab color when active
            style[(int) ImGuiCol.TabUnfocused] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            // Tab color when active
            style[(int) ImGuiCol.TabUnfocusedActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            // Plot lines color
            style[(int) ImGuiCol.PlotLines] = new Vector4F(0.61f, 0.61f, 0.61f, 1.0f);

            // Plot lines color when hovered
            style[(int) ImGuiCol.PlotLinesHovered] = new Vector4F(0.7f, 0.7f, 0.7f, 1.0f);

            // Plot histogram color
            style[(int) ImGuiCol.PlotHistogram] = new Vector4F(0.61f, 0.61f, 0.61f, 1.0f);

            // Plot histogram color when hovered
            style[(int) ImGuiCol.PlotHistogramHovered] = new Vector4F(0.7f, 0.7f, 0.7f, 1.0f);

            // Text selected color
            style[(int) ImGuiCol.TextSelectedBg] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            // Drag and drop target color
            style[(int) ImGuiCol.DragDropTarget] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            // Nav highlight color
            style[(int) ImGuiCol.NavHighlight] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            // Nav windowing highlight color
            style[(int) ImGuiCol.NavWindowingHighlight] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            // Nav windowing dim background color
            style[(int) ImGuiCol.NavWindowingDimBg] = new Vector4F(0.2f, 0.2f, 0.2f, 0.6f);

            // Modal window dim background color
            style[(int) ImGuiCol.ModalWindowDimBg] = new Vector4F(0.2f, 0.2f, 0.2f, 0.6f);

            // SETTING STYLE
            // WindowRounding
            style.WindowRounding = 0.0f;

            // ChildRounding
            style.ChildRounding = 3.0f;

            // FrameRounding
            style.FrameRounding = 3.0f;

            // PopupRounding
            style.PopupRounding = 1.0f;

            // ScrollbarRounding
            style.ScrollbarRounding = 2.0f;

            // GrabRounding
            style.GrabRounding = 1.0f;

            // logSliderDeadzone
            style.LogSliderDeadzone = 4.0f;

            // TabRounding
            style.TabRounding = 3.0f;

            // Window border size
            style.WindowBorderSize = 1.0f;

            // Child window border size
            style.ChildBorderSize = 1.0f;

            // Popup border size
            style.PopupBorderSize = 1.0f;

            // Frame border size
            style.FrameBorderSize = 1.0f;

            // Tab border size
            style.TabBorderSize = 0.0f;

            // Window padding
            style.WindowPadding = new Vector2F(4, 4);

            // Frame padding
            style.FramePadding = new Vector2F(7, 7);

            // Item spacing
            style.ItemSpacing = new Vector2F(6, 6);

            // Inner item spacing
            style.ItemInnerSpacing = new Vector2F(6, 6);

            // Cell padding
            style.CellPadding = new Vector2F(10, 10);

            // Touch extra padding
            style.TouchExtraPadding = new Vector2F(0, 0);

            // Indent spacing
            style.IndentSpacing = 21;

            // Scrollbar size
            style.ScrollbarSize = 12;

            // Minimum grab size
            style.GrabMinSize = 12;

            // Window title alignment
            style.WindowTitleAlign = new Vector2F(0.5f, 0.5f);

            // Window menu button position
            style.WindowMenuButtonPosition = ImGuiDir.None;

            // Color button position
            style.ColorButtonPosition = 0;

            // Button text alignment
            style.ButtonTextAlign = new Vector2F(0.5f, 0.5f);

            // Display window padding
            style.DisplayWindowPadding = new Vector2F(19, 19);

            // Display safe area padding
            style.DisplaySafeAreaPadding = new Vector2F(3, 3);

            // Enable anti-aliased lines
            style.AntiAliasedLines = 1;

            // Enable anti-aliased fill
            style.AntiAliasedFill = 1;

            // Curve tessellation tolerance
            style.CurveTessellationTol = 1.25f;

            // Circle tessellation max error
            style.CircleTessellationMaxError = 0.2f;

            // Circle tessellation max error
            style.Alpha = 1.0f;

            style.DisabledAlpha = 0.6f;
        }

        /// <summary>
        ///     Renders the project
        /// </summary>
        public void RenderProject()
        {
            // Configurar la ventana principal (DockSpace)
            ImGui.SetNextWindowPos(spaceWork.Viewport.WorkPos);
            ImGui.SetNextWindowSize(spaceWork.Viewport.Size);
            ImGui.Begin("DockSpace Demo", dockspaceflags);


            spaceWork.DockSpaceMenu.Update();

            Vector2F dockSize = spaceWork.Viewport.Size - new Vector2F(5, 85);

            // Calcular el tamaño del DockSpace restante
            if (spaceWork.IsMacOs)
            {
                dockSize = spaceWork.Viewport.Size - new Vector2F(5, 60);
            }

            uint dockSpaceId = ImGui.GetId("MyDockSpace");
            ImGui.DockSpace(dockSpaceId, dockSize);

            // Renderizar el contenido principal del espacio de trabajo
            spaceWork.Update();

            ImGui.End();
        }

        /// <summary>
        ///     Processes the event using the specified evt
        /// </summary>
        /// <param name="evt">The evt</param>
        private void ProcessEvent(Event evt)
        {
            ImGuiIoPtr imGuiIoPtr = ImGui.GetIo();
            switch (evt.type)
            {
                case EventType.Mousewheel:
                {
                    if (evt.wheel.x > 0)
                    {
                        imGuiIoPtr.MouseWheelH += 1;
                    }

                    if (evt.wheel.x < 0)
                    {
                        imGuiIoPtr.MouseWheelH -= 1;
                    }

                    if (evt.wheel.y > 0)
                    {
                        imGuiIoPtr.MouseWheel += 1;
                    }

                    if (evt.wheel.y < 0)
                    {
                        imGuiIoPtr.MouseWheel -= 1;
                    }

                    return;
                }
                case EventType.MouseButtonDown:
                {
                    if (evt.button.button == Sdl.ButtonLeft)
                    {
                        _mousePressed[0] = true;
                    }

                    if (evt.button.button == Sdl.ButtonRight)
                    {
                        _mousePressed[1] = true;
                    }

                    if (evt.button.button == Sdl.ButtonMiddle)
                    {
                        _mousePressed[2] = true;
                    }

                    return;
                }
                case EventType.TextInput:
                {
                    string str = Encoding.UTF8.GetString(evt.text.Text);
                    imGuiIoPtr.AddInputCharactersUtf8(str);
                    return;
                }
                case EventType.Keydown:
                {
                    SdlScancode key = evt.key.KeySym.scancode;
                    KeyCodes sym = evt.key.KeySym.sym;

                    // Modifiers
                    if (sym == KeyCodes.Lshift)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.LeftShift, true);
                    }

                    if (sym == KeyCodes.Rshift)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.RightShift, true);
                    }

                    if (sym == KeyCodes.Lalt)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.LeftAlt, true);
                    }

                    if (sym == KeyCodes.Ralt)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.RightAlt, true);
                    }

                    if (sym == KeyCodes.Lctrl)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.LeftCtrl, true);
                    }

                    if (sym == KeyCodes.Rctrl)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.RightCtrl, true);
                    }

                    // Keys
                    if (sym == KeyCodes.Escape)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Escape, true);
                    }

                    if (sym == KeyCodes.Tab)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Tab, true);
                    }

                    if (sym == KeyCodes.Left)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.LeftArrow, true);
                    }

                    if (sym == KeyCodes.Right)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.RightArrow, true);
                    }

                    if (sym == KeyCodes.Up)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.UpArrow, true);
                    }

                    if (sym == KeyCodes.Down)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.DownArrow, true);
                    }

                    if (sym == KeyCodes.Pageup)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.PageUp, true);
                    }

                    if (sym == KeyCodes.Pagedown)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.PageDown, true);
                    }

                    if (sym == KeyCodes.Home)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Home, true);
                    }

                    if (sym == KeyCodes.End)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.End, true);
                    }

                    if (sym == KeyCodes.Insert)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Insert, true);
                    }

                    if (sym == KeyCodes.Delete)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Delete, true);
                    }

                    if (sym == KeyCodes.Backspace)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Backspace, true);
                    }

                    if (sym == KeyCodes.Space)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Space, true);
                    }

                    if (sym == KeyCodes.Return)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Enter, true);
                    }

                    if (sym == KeyCodes.KpEnter)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.KeypadEnter, true);
                    }

                    if (sym == KeyCodes.A)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.A, true);
                    }

                    if (sym == KeyCodes.C)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.C, true);
                    }

                    if (sym == KeyCodes.V)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.V, true);
                    }

                    if (sym == KeyCodes.X)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.X, true);
                    }

                    if (sym == KeyCodes.Y)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Y, true);
                    }

                    if (sym == KeyCodes.Z)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Z, true);
                    }

                    break;
                }
                case EventType.Keyup:
                {
                    SdlScancode key = evt.key.KeySym.scancode;
                    KeyCodes sym = evt.key.KeySym.sym;

                    // Modifiers
                    if (sym == KeyCodes.Lshift)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.LeftShift, false);
                    }

                    if (sym == KeyCodes.Rshift)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.RightShift, false);
                    }

                    if (sym == KeyCodes.Lalt)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.LeftAlt, false);
                    }

                    if (sym == KeyCodes.Ralt)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.RightAlt, false);
                    }

                    if (sym == KeyCodes.Lctrl)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.LeftCtrl, false);
                    }

                    if (sym == KeyCodes.Rctrl)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.RightCtrl, false);
                    }

                    // Keys
                    if (sym == KeyCodes.Escape)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Escape, false);
                    }

                    if (sym == KeyCodes.Tab)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Tab, false);
                    }

                    if (sym == KeyCodes.Left)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.LeftArrow, false);
                    }

                    if (sym == KeyCodes.Right)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.RightArrow, false);
                    }

                    if (sym == KeyCodes.Up)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.UpArrow, false);
                    }

                    if (sym == KeyCodes.Down)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.DownArrow, false);
                    }

                    if (sym == KeyCodes.Pageup)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.PageUp, false);
                    }

                    if (sym == KeyCodes.Pagedown)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.PageDown, false);
                    }

                    if (sym == KeyCodes.Home)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Home, false);
                    }

                    if (sym == KeyCodes.End)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.End, false);
                    }

                    if (sym == KeyCodes.Insert)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Insert, false);
                    }

                    if (sym == KeyCodes.Delete)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Delete, false);
                    }

                    if (sym == KeyCodes.Backspace)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Backspace, false);
                    }

                    if (sym == KeyCodes.Space)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Space, false);
                    }

                    if (sym == KeyCodes.Return)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Enter, false);
                    }

                    if (sym == KeyCodes.KpEnter)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.KeypadEnter, false);
                    }

                    if (sym == KeyCodes.A)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.A, false);
                    }

                    if (sym == KeyCodes.C)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.C, false);
                    }

                    if (sym == KeyCodes.V)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.V, false);
                    }

                    if (sym == KeyCodes.X)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.X, false);
                    }

                    if (sym == KeyCodes.Y)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Y, false);
                    }

                    if (sym == KeyCodes.Z)
                    {
                        imGuiIoPtr.AddKeyEvent(ImGuiKey.Z, false);
                    }

                    break;
                }
            }
        }

        /// <summary>
        ///     Updates the mouse pos and buttons
        /// </summary>
        private void UpdateMousePosAndButtons()
        {
            ImGuiIoPtr imGuiIoPtr = ImGui.GetIo();

            // Set OS mouse position if requested (rarely used, only when ImGuiConfigFlags_NavEnableSetMousePos is enabled by user)
            if (imGuiIoPtr.WantSetMousePos)
            {
                Sdl.WarpMouseInWindow(spaceWork.Window, (int) imGuiIoPtr.MousePos.X, (int) imGuiIoPtr.MousePos.Y);
            }
            else
            {
                imGuiIoPtr.MousePos = new Vector2F(float.MinValue, float.MinValue);
            }

            uint mouseButtons = Sdl.GetMouseStateOutXAndY(out int mx, out int my);
            List<bool> rangeAccessor = imGuiIoPtr.MouseDown;
            rangeAccessor[0] =
                _mousePressed[0] ||
                (mouseButtons & Sdl.Button(Sdl.ButtonLeft)) !=
                0; // If a mouse press event came, always pass it as "mouse held this frame", so we don't miss click-release events that are shorter than 1 frame.
            rangeAccessor[1] = _mousePressed[1] || (mouseButtons & Sdl.Button(Sdl.ButtonRight)) != 0;
            rangeAccessor[2] = _mousePressed[2] || (mouseButtons & Sdl.Button(Sdl.ButtonMiddle)) != 0;
            _mousePressed[0] = _mousePressed[1] = _mousePressed[2] = false;

            imGuiIoPtr.MouseDown = rangeAccessor;

            IntPtr focusedWindow = Sdl.GetKeyboardFocus();
            if (spaceWork.Window == focusedWindow)
            {
                // SDL_GetMouseState() gives mouse position seemingly based on the last window entered/focused(?)
                // The creation of a new windows at runtime and SDL_CaptureMouse both seems to severely mess up with that, so we retrieve that position globally.
                Sdl.GetWindowPosition(focusedWindow, out int wx, out int wy);
                Sdl.GetGlobalMouseStateOutXAndOutY(out mx, out my);
                mx -= wx;
                my -= wy;
                imGuiIoPtr.MousePos = new Vector2F(mx, my);
            }

            // SDL_CaptureMouse() let the OS know e.g. that our imgui drag outside the SDL window boundaries shouldn't e.g. trigger the OS window resize cursor.
            bool anyMouseButtonDown = ImGui.IsAnyMouseDown();
            Sdl.CaptureMouse(anyMouseButtonDown);
        }

        /// <summary>
        ///     Setup the render state using the specified draw data
        /// </summary>
        /// <param name="drawData">The draw data</param>
        private void SetupRenderState(ImDrawData drawData)
        {
            Gl.GlEnable(EnableCap.Blend);
            Gl.GlBlendEquation(BlendEquationMode.FuncAdd);
            Gl.GlBlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            Gl.GlDisable(EnableCap.CullFace);
            Gl.GlDisable(EnableCap.DepthTest);
            Gl.GlEnable(EnableCap.ScissorTest);

            Gl.GlUseProgram(_shader.ProgramId);

            float left = drawData.DisplayPos.X;
            float right = drawData.DisplayPos.X + drawData.DisplaySize.X;
            float top = drawData.DisplayPos.Y;
            float bottom = drawData.DisplayPos.Y + drawData.DisplaySize.Y;


            _shader["Texture"].SetValue(0);
            _shader["ProjMtx"].SetValue(Matrix4X4.CreateOrthographicOffCenter(left, right, bottom, top, -1, 1));
            Gl.GlBindSampler(0, 0);

            Gl.GlBindVertexArray(_vertexArrayObject);

            // Bind vertex/index buffers and setup attributes for ImDrawVert
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, _vboHandle);
            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, _elementsHandle);

            Gl.EnableVertexAttribArray(_shader["Position"].Location);
            Gl.EnableVertexAttribArray(_shader["UV"].Location);
            Gl.EnableVertexAttribArray(_shader["Color"].Location);

            int drawVertSize = Marshal.SizeOf<ImDrawVert>();
            // Manual offset calculations
            int posOffset = 0; // Offset of Pos is 0 bytes from the start
            int uvOffset = 8; // Offset of Uv is 8 bytes from the start (after Pos)
            int colOffset = 16; // Offset of Col is 16 bytes from the start (after Pos and Uv)

            Gl.VertexAttribPointer(_shader["Position"].Location, 2, VertexAttribPointerType.Float, false, drawVertSize, posOffset);
            Gl.VertexAttribPointer(_shader["UV"].Location, 2, VertexAttribPointerType.Float, false, drawVertSize, uvOffset);
            Gl.VertexAttribPointer(_shader["Color"].Location, 4, VertexAttribPointerType.UnsignedByte, true, drawVertSize, colOffset);
        }


        /// <summary>
        ///     Creates the gl context using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <exception cref="Exception">CouldNotCreateContext</exception>
        /// <returns>The gl context</returns>
        private static IntPtr CreateGlContext(IntPtr window)
        {
            IntPtr glContext = Sdl.CreateContext(window);
            if (glContext == IntPtr.Zero)
            {
                throw new GeneralAlisException("CouldNotCreateContext");
            }

            Sdl.MakeCurrent(window, glContext);
            Sdl.SetSwapInterval(1);

            // initialize the screen to black as soon as possible
            Gl.GlClearColor(0f, 0f, 0f, 1f);
            Gl.GlClear(ClearBufferMask.ColorBufferBit);
            Sdl.SwapWindow(window);

            Logger.Info($"GL Version: {Gl.GlGetString(StringName.Version)}");
            return glContext;
        }

        /// <summary>
        ///     Loads the texture using the specified pixel data
        /// </summary>
        /// <param name="pixelData">The pixel data</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="format">The format</param>
        /// <param name="internalFormat">The internal format</param>
        /// <returns>The texture id</returns>
        private static uint LoadTexture(IntPtr pixelData, int width, int height, PixelFormat format = PixelFormat.Rgba, PixelInternalFormat internalFormat = PixelInternalFormat.Rgba)
        {
            uint textureId = Gl.GenTexture();
            Gl.GlPixelStorei(StoreParameter.UnpackAlignment, 1);
            Gl.GlBindTexture(TextureTarget.Texture2D, textureId);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, internalFormat, width, height, 0, format, PixelType.UnsignedByte, pixelData);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlBindTexture(TextureTarget.Texture2D, 0);
            return textureId;
        }

        /// <summary>
        ///     Renders the draw data
        /// </summary>
        private void RenderDrawData()
        {
            ImDrawData drawData = ImGui.GetDrawData();

            // Avoid rendering when minimized, scale coordinates for retina displays (screen coordinates != framebuffer coordinates)
            int fbWidth = (int) (drawData.DisplaySize.X * drawData.FramebufferScale.X);
            int fbHeight = (int) (drawData.DisplaySize.Y * drawData.FramebufferScale.Y);
            if (fbWidth <= 0 || fbHeight <= 0)
            {
                return;
            }

            SetupRenderState(drawData);

            Vector2F clipOffset = drawData.DisplayPos;
            Vector2F clipScale = drawData.FramebufferScale;

            drawData.ScaleClipRects(clipScale);

            IntPtr lastTexId = ImGui.GetIo().Fonts.TexId;
            Gl.GlBindTexture(TextureTarget.Texture2D, (uint) lastTexId);

            int drawVertSize = Marshal.SizeOf<ImDrawVert>();
            int drawIdxSize = sizeof(ushort);

            for (int n = 0; n < drawData.CmdListsCount; n++)
            {
                ImDrawListPtr cmdList = drawData.CmdListsRange[n];

                // Upload vertex/index buffers
                Gl.GlBufferData(BufferTarget.ArrayBuffer, cmdList.VtxBuffer.Size * drawVertSize, cmdList.VtxBuffer.Data, BufferUsageHint.StreamDraw);
                Gl.GlBufferData(BufferTarget.ElementArrayBuffer, cmdList.IdxBuffer.Size * drawIdxSize, cmdList.IdxBuffer.Data, BufferUsageHint.StreamDraw);

                for (int cmdI = 0; cmdI < cmdList.CmdBuffer.Size; cmdI++)
                {
                    ImDrawCmd pcmd = cmdList.CmdBuffer[cmdI];
                    if (pcmd.UserCallback != IntPtr.Zero)
                    {
                        Logger.Info("UserCallback not implemented");
                    }
                    else
                    {
                        // Project scissor/clipping rectangles into framebuffer space
                        Vector4F clipRect = pcmd.ClipRect;

                        clipRect.X = pcmd.ClipRect.X - clipOffset.X;
                        clipRect.Y = pcmd.ClipRect.Y - clipOffset.Y;
                        clipRect.Z = pcmd.ClipRect.Z - clipOffset.X;
                        clipRect.W = pcmd.ClipRect.W - clipOffset.Y;

                        Gl.GlScissor((int) clipRect.X, (int) (fbHeight - clipRect.W), (int) (clipRect.Z - clipRect.X), (int) (clipRect.W - clipRect.Y));

                        // Bind texture, Draw
                        if (pcmd.TextureId != IntPtr.Zero)
                        {
                            if (pcmd.TextureId != lastTexId)
                            {
                                lastTexId = pcmd.TextureId;
                                Gl.GlBindTexture(TextureTarget.Texture2D, (uint) pcmd.TextureId);
                            }
                        }

                        Gl.GlDrawElementsBaseVertex(BeginMode.Triangles, (int) pcmd.ElemCount, DrawElementsType.UnsignedShort, (IntPtr) (pcmd.IdxOffset * drawIdxSize), (int) pcmd.VtxOffset);
                    }
                }
            }
        }
    }
}