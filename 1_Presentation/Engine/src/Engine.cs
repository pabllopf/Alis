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
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Extras.GuizMo;
using Alis.Extension.Graphic.ImGui.Extras.Node;
using Alis.Extension.Graphic.ImGui.Extras.Plot.Native;
using Alis.Extension.Graphic.ImGui.Native;
using Alis.Extension.Graphic.OpenGL;
using Alis.Extension.Graphic.OpenGL.Constructs;
using Alis.Extension.Graphic.OpenGL.Enums;
using PixelFormat = Alis.Extension.Graphic.OpenGL.Enums.PixelFormat;
using Version = Alis.Core.Graphic.Sdl2.Structs.Version;

namespace Alis.App.Engine
{
    /// <summary>
    ///     The engine class
    /// </summary>
    public class Engine
    {
        /// <summary>
        ///     The name engine
        /// </summary>
        private const string NameEngine = "Alis";

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
        private readonly int heightWindow = 1920;

        /// <summary>
        ///     The high dpi
        /// </summary>
        private readonly bool highDpi = false;

        /// <summary>
        ///     The width window
        /// </summary>
        private readonly int widthWindow = 1080;

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
        ///     The quit
        /// </summary>
        private bool _quit;

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
        ///     The windows
        /// </summary>
        private SpaceWork spaceWork = new SpaceWork();

        /// <summary>
        ///     Starts this instance
        /// </summary>
        /// <returns>The int</returns>
        public void Start()
        {
            // initialize SDL and set a few defaults for the OpenGL context
            if (Sdl.Init(InitSettings.InitEverything) != 0)
            {
                Logger.Info($@"Error of SDL2: {Sdl.GetError()}");
                return;
            }

            spaceWork = new SpaceWork();

            spaceWork.Initialize();

            // GET VERSION SDL2
            Version version = Sdl.GetVersion();
            Logger.Info(@$"SDL2 VERSION {version.major}.{version.minor}.{version.patch}");

            Sdl.SetHint(Hint.HintRenderDriver, "opengl");

            // CONFIG THE SDL2 AN OPENGL CONFIGURATION
            Sdl.SetAttributeByInt(Attr.SdlGlContextFlags, (int) Contexts.SdlGlContextForwardCompatibleFlag);
            Sdl.SetAttributeByProfile(Attr.SdlGlContextProfileMask, Profiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(Attr.SdlGlContextMajorVersion, 4);
            Sdl.SetAttributeByInt(Attr.SdlGlContextMinorVersion, 1);

            Sdl.SetAttributeByProfile(Attr.SdlGlContextProfileMask, Profiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(Attr.SdlGlDoubleBuffer, 1);
            Sdl.SetAttributeByInt(Attr.SdlGlDepthSize, 24);
            Sdl.SetAttributeByInt(Attr.SdlGlAlphaSize, 8);
            Sdl.SetAttributeByInt(Attr.SdlGlStencilSize, 8);

            // Enable vsync
            Sdl.SetSwapInterval(1);

            // create the window which should be able to have a valid OpenGL context and is resizable
            WindowSettings flags = WindowSettings.WindowOpengl | WindowSettings.WindowResizable | WindowSettings.WindowMaximized;
            if (fullscreen)
            {
                flags |= WindowSettings.WindowFullscreen;
            }

            if (highDpi)
            {
                flags |= WindowSettings.WindowAllowHighDpi;
            }
            
            spaceWork.Window = Sdl.CreateWindow(NameEngine, (int) WindowPos.WindowPosCentered, (int) WindowPos.WindowPosCentered, widthWindow, heightWindow, flags);
            _glContext = CreateGlContext(spaceWork.Window);

            // compile the shader program
            _shader = new GlShaderProgram(VertexShader.ShaderCode, FragmentShader.ShaderCode);

            spaceWork.ContextGui = ImGui.CreateContext();

            spaceWork.Io = ImGui.GetIo();

            spaceWork.Io.DisplaySize = new Vector2(800, 600);

            Logger.Info($@"IMGUI VERSION {ImGui.GetVersion()}");

            // active plot renders
            spaceWork.Io.BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset | ImGuiBackendFlags.PlatformHasViewports | ImGuiBackendFlags.HasGamepad | ImGuiBackendFlags.HasMouseHoveredViewport | ImGuiBackendFlags.HasMouseCursors;


            // Enable Keyboard Controls
            spaceWork.Io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
            spaceWork.Io.ConfigFlags |= ImGuiConfigFlags.NavEnableGamepad;

            // CONFIG DOCKSPACE 

            spaceWork.Io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
            spaceWork.Io.ConfigFlags |= ImGuiConfigFlags.ViewportsEnable;

            ImNodes.CreateContext();
            ImPlot.CreateContext();
            ImGuizMo.SetImGuiContext(spaceWork.ContextGui);
            ImGui.SetCurrentContext(spaceWork.ContextGui);

            // REBUILD ATLAS
            ImFontAtlasPtr fonts = ImGui.GetIo().Fonts;

            //fonts.AddFontDefault();

            float fontSize = 14;
            float fontSizeIcon = 18;

            string fontFileSolid = AssetManager.Find("JetBrainsMono-Bold.ttf");
            ImFontPtr fontLoaded16Solid = fonts.AddFontFromFileTtf(fontFileSolid, fontSize);
            try
            {
                ImFontConfigPtr icons_config = ImGui.ImFontConfig();
                icons_config.MergeMode = true;
                icons_config.SnapH = true;
                icons_config.GlyphMinAdvanceX = 18;

                ushort[] IconRanges = new ushort[3];
                IconRanges[0] = FontAwesome5.IconMin;
                IconRanges[1] = FontAwesome5.IconMax;
                IconRanges[2] = 0;

                // Allocate GCHandle to pin IconRanges in memory
                GCHandle iconRangesHandle = GCHandle.Alloc(IconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                // Assuming 'io' is a valid ImGuiIO instance and 'dir' and 'dirIcon' are defined paths
                string fontAwesome = AssetManager.Find(FontAwesome5.NameSolid);
                fonts.AddFontFromFileTtf(fontAwesome, fontSizeIcon, icons_config, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameSolid} {e.Message}");
                return;
            }

            string fontAwesomeRegular = AssetManager.Find("JetBrainsMonoNL-Regular.ttf");
            ImFontPtr fontLoaded16Regular = fonts.AddFontFromFileTtf(fontAwesomeRegular, fontSize);
            try
            {
                ImFontConfigPtr icons_config = ImGui.ImFontConfig();
                icons_config.MergeMode = true;
                icons_config.SnapH = true;
                icons_config.GlyphMinAdvanceX = 20;

                ushort[] IconRanges = new ushort[3];
                IconRanges[0] = FontAwesome5.IconMin;
                IconRanges[1] = FontAwesome5.IconMax;
                IconRanges[2] = 0;

                // Allocate GCHandle to pin IconRanges in memory
                GCHandle iconRangesHandle = GCHandle.Alloc(IconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                // Assuming 'io' is a valid ImGuiIO instance and 'dir' and 'dirIcon' are defined paths
                fonts.AddFontFromFileTtf(fontAwesomeRegular, fontSizeIcon, icons_config, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameRegular} {e.Message}");
                return;
            }

            string fontAwesomeLight = AssetManager.Find("JetBrainsMonoNL-Regular.ttf");
            ImFontPtr fontLoaded16Light = fonts.AddFontFromFileTtf(fontAwesomeLight, fontSize);
            try
            {
                ImFontConfigPtr icons_config = ImGui.ImFontConfig();
                icons_config.MergeMode = true;
                icons_config.SnapH = true;
                icons_config.GlyphMinAdvanceX = 20;

                ushort[] IconRanges = new ushort[3];
                IconRanges[0] = FontAwesome5.IconMin;
                IconRanges[1] = FontAwesome5.IconMax;
                IconRanges[2] = 0;

                // Allocate GCHandle to pin IconRanges in memory
                GCHandle iconRangesHandle = GCHandle.Alloc(IconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                // Assuming 'io' is a valid ImGuiIO instance and 'dir' and 'dirIcon' are defined paths
                fonts.AddFontFromFileTtf(fontAwesomeLight, fontSizeIcon, icons_config, rangePtr);
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
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);
            dockspaceflags |= ImGuiWindowFlags.MenuBar;
            dockspaceflags |= ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove;
            dockspaceflags |= ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus;

            // config spaceWork.Style
            spaceWork.Style = ImGui.GetStyle();
            ImGui.StyleColorsDark();
            spaceWork.Style.WindowRounding = 0.0f;
            spaceWork.Style.Colors2 = new Vector4(0.00f, 0.00f, 0.00f, 1.00f);

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
            string iconPath = AssetManager.Find("app.bmp");
            if (!string.IsNullOrEmpty(iconPath) && File.Exists(iconPath))
            {
                IntPtr icon = Sdl.LoadBmp(iconPath);
                Sdl.SetWindowIcon(spaceWork.Window, icon);
            }
            
            spaceWork.Start();
            while (!_quit)
            {
                while (Sdl.PollEvent(out Event e) != 0)
                {
                    ProcessEvent(e);
                    switch (e.type)
                    {
                        case EventType.WindowEvent:
                        {
                            if (e.window.windowEvent == WindowEventId.SdlWindowEventClose)
                            {
                                _quit = true;
                            }

                            break;
                        }

                        case EventType.Keydown:
                        {
                            switch (e.key.KeySym.sym)
                            {
                                case KeyCodes.Escape:
                                case KeyCodes.Q:
                                    _quit = true;
                                    break;
                            }

                            break;
                        }
                    }
                }

                //Gl.GlClearColor(0.05f, 0.05f, 0.05f, 1.00f);
                ImGui.NewFrame();
                ImGuizMo.BeginFrame();

                // Setup display size (every frame to accommodate for window resizing)
                Vector2 windowSize = Sdl.GetWindowSize(spaceWork.Window);
                Sdl.GetDrawableSize(spaceWork.Window, out int displayW, out int displayH);
                spaceWork.Io.DisplaySize = new Vector2(windowSize.X, windowSize.Y);
                if ((windowSize.X > 0) && (windowSize.Y > 0))
                {
                    spaceWork.Io.DisplayFramebufferScale = new Vector2(displayW / windowSize.X, displayH / windowSize.Y);
                }

                // Setup time step (we don't use SDL_GetTicks() because it is using millisecond resolution)
                ulong frequency = Sdl.GetPerformanceFrequency();
                ulong currentTime = Sdl.GetPerformanceCounter();
                spaceWork.Io.DeltaTime = _time > 0 ? (float) ((double) (currentTime - _time) / frequency) : 1.0f / 60.0f;
                if (spaceWork.Io.DeltaTime <= 0)
                {
                    spaceWork.Io.DeltaTime = 0.016f;
                }

                _time = currentTime;

                UpdateMousePosAndButtons();

                //ImGui.PushFont(fontLoaded);

                int sizeMenuDown = 25;
                Vector2 sizeDock = spaceWork.Viewport.Size - new Vector2(0, sizeMenuDown * 2);


                ImGui.SetNextWindowPos(spaceWork.Viewport.WorkPos);
                ImGui.SetNextWindowSize(sizeDock);
                //ImGui.SetNextWindowViewport(spaceWork.Viewport .ID);
                ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
                ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);
                ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2(0.0f, 0.0f));


                ImGui.Begin("DockSpace Demo", dockspaceflags);
                // Submit the DockSpace

                ImGui.PopStyleVar(3);

                uint dockSpaceId = ImGui.GetId("MyDockSpace");
                ImGui.DockSpace(dockSpaceId, sizeDock);


                // RENDER SAMPLES AND CODE
                spaceWork.Update();

                ImGui.End();
                //ImGui.PopFont();

                Sdl.MakeCurrent(spaceWork.Window, _glContext);
                ImGui.Render();

                Gl.GlViewport(0, 0, (int) spaceWork.Io.DisplaySize.X, (int) spaceWork.Io.DisplaySize.Y);
                Gl.GlClear(ClearBufferMask.ColorBufferBit);

                RenderDrawData();

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
                case EventType.Keyup:
                {
                    SdlScancode key = evt.key.KeySym.scancode;
                    imGuiIoPtr.KeysDown[(int) key] = evt.type == EventType.Keydown;
                    Logger.Info("spaceWork.Io.KeysDown[" + key + "] = " + evt.type + imGuiIoPtr.KeysDown[(int) key]);
                    imGuiIoPtr.KeyShift = (Sdl.GetModState() & KeyMods.KModShift) != 0;
                    imGuiIoPtr.KeyCtrl = (Sdl.GetModState() & KeyMods.KModCtrl) != 0;
                    imGuiIoPtr.KeyAlt = (Sdl.GetModState() & KeyMods.KModAlt) != 0;
                    imGuiIoPtr.KeySuper = (Sdl.GetModState() & KeyMods.KModGui) != 0;
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
                imGuiIoPtr.MousePos = new Vector2(float.MinValue, float.MinValue);
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
                imGuiIoPtr.MousePos = new Vector2(mx, my);
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

            Gl.VertexAttribPointer(_shader["Position"].Location, 2, VertexAttribPointerType.Float, false, drawVertSize, (IntPtr) posOffset);
            Gl.VertexAttribPointer(_shader["UV"].Location, 2, VertexAttribPointerType.Float, false, drawVertSize, (IntPtr) uvOffset);
            Gl.VertexAttribPointer(_shader["Color"].Location, 4, VertexAttribPointerType.UnsignedByte, true, drawVertSize, (IntPtr) colOffset);
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
                throw new Exception("CouldNotCreateContext");
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

            Vector2 clipOffset = drawData.DisplayPos;
            Vector2 clipScale = drawData.FramebufferScale;

            drawData.ScaleClipRects(clipScale);

            IntPtr lastTexId = ImGui.GetIo().Fonts.TexId;
            Gl.GlBindTexture(TextureTarget.Texture2D, (uint) lastTexId);

            int drawVertSize = Marshal.SizeOf<ImDrawVert>();
            int drawIdxSize = sizeof(ushort);

            for (int n = 0; n < drawData.CmdListsCount; n++)
            {
                ImDrawListPtr cmdList = drawData.CmdListsRange[n];

                // Upload vertex/index buffers
                Gl.GlBufferData(BufferTarget.ArrayBuffer, (IntPtr) (cmdList.VtxBuffer.Size * drawVertSize), cmdList.VtxBuffer.Data, BufferUsageHint.StreamDraw);
                Gl.GlBufferData(BufferTarget.ElementArrayBuffer, (IntPtr) (cmdList.IdxBuffer.Size * drawIdxSize), cmdList.IdxBuffer.Data, BufferUsageHint.StreamDraw);

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
                        Vector4 clipRect = pcmd.ClipRect;

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