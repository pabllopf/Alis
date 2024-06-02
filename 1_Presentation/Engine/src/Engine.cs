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
using Alis.App.Engine.Windows;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Extras.GuizMo;
using Alis.Extension.Graphic.ImGui.Extras.Node;
using Alis.Extension.Graphic.ImGui.Extras.Plot;
using Alis.Extension.Graphic.ImGui.Extras.Plot.Native;
using Alis.Extension.Graphic.ImGui.Native;
using Alis.Extension.Graphic.OpenGL;
using Alis.Extension.Graphic.OpenGL.Constructs;
using Alis.Extension.Graphic.OpenGL.Enums;
using Type = Alis.Extension.Graphic.OpenGL.Enums.Type;
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
        private static readonly string VertexShader = @"
			#version 330
			
			precision mediump float;
			layout (location = 0) in vec2 Position;
			layout (location = 1) in vec2 UV;
			layout (location = 2) in vec4 Color;
			uniform mat4 ProjMtx;
			out vec2 Frag_UV;
			out vec4 Frag_Color;
			void main()
			{
			    Frag_UV = UV;
			    Frag_Color = Color;
			    gl_Position = ProjMtx * vec4(Position.xy, 0, 1);
			}";
        
        
        /// <summary>
        ///     The fragment shader
        /// </summary>
        private static readonly string FragmentShader = @"
			#version 330
			
			precision mediump float;
			uniform sampler2D Texture;
			in vec2 Frag_UV;
			in vec4 Frag_Color;
			layout (location = 0) out vec4 Out_Color;
			
			void main()
			{
			    Out_Color = Frag_Color * texture(Texture, Frag_UV.st);
			}";
        
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
        ///     The windows
        /// </summary>
        private readonly List<IWindow> windows;
        
        /// <summary>
        ///     The context
        /// </summary>
        private IntPtr _context;
        
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
        ///     The window
        /// </summary>
        private IntPtr _window;
        
        /// <summary>
        ///     The dockspaceflags
        /// </summary>
        private ImGuiWindowFlags dockspaceflags;
        
        /// <summary>
        ///     The io
        /// </summary>
        private ImGuiIoPtr io = null;
        
        /// <summary>
        ///     The menu down state
        /// </summary>
        private bool menuDownState = true;
        
        /// <summary>
        ///     The style
        /// </summary>
        private ImGuiStyle style;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Engine" /> class
        /// </summary>
        public Engine() => windows = new List<IWindow>
        {
            new ConsoleWindow(),
            new GameWindow(),
            new InspectorWindow(),
            new SolutionWindow(),
            new SceneWindow(),
            new ProjectWindow()
        };
        
        /// <summary>
        ///     Starts this instance
        /// </summary>
        /// <returns>The int</returns>
        public unsafe void Start()
        {
            // initialize SDL and set a few defaults for the OpenGL context
            if (Sdl.Init(InitSettings.InitVideo) != 0)
            {
                Logger.Info($@"Error of SDL2: {Sdl.GetError()}");
                return;
            }
            
            // GET VERSION SDL2
            Version version = Sdl.GetVersion();
            Logger.Info(@$"SDL2 VERSION {version.major}.{version.minor}.{version.patch}");
            
            // CONFIG THE SDL2 AN OPENGL CONFIGURATION
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextFlags, (int) GlContexts.SdlGlContextForwardCompatibleFlag);
            Sdl.SetAttributeByProfile(GlAttr.SdlGlContextProfileMask, GlProfiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextMajorVersion, 3);
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextMinorVersion, 2);
            
            Sdl.SetAttributeByProfile(GlAttr.SdlGlContextProfileMask, GlProfiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(GlAttr.SdlGlDoubleBuffer, 1);
            Sdl.SetAttributeByInt(GlAttr.SdlGlDepthSize, 24);
            Sdl.SetAttributeByInt(GlAttr.SdlGlAlphaSize, 8);
            Sdl.SetAttributeByInt(GlAttr.SdlGlStencilSize, 8);
            
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
            
            _window = Sdl.CreateWindow(NameEngine, (int) WindowPos.WindowPosCentered, (int) WindowPos.WindowPosCentered, widthWindow, heightWindow, flags);
            _glContext = CreateGlContext(_window);
            
            // compile the shader program
            _shader = new GlShaderProgram(VertexShader, FragmentShader);
            
            _context = ImGui.CreateContext();
            
            io = ImGui.GetIo();
            
            io.DisplaySize = new Vector2(800, 600);
            
            Logger.Info($@"IMGUI VERSION {ImGui.GetVersion()}");
            
            // active plot renders
            io.BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset | ImGuiBackendFlags.PlatformHasViewports | ImGuiBackendFlags.HasGamepad | ImGuiBackendFlags.HasMouseHoveredViewport | ImGuiBackendFlags.HasMouseCursors;
            
            
            // Enable Keyboard Controls
            io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
            io.ConfigFlags |= ImGuiConfigFlags.NavEnableGamepad;
            
            // CONFIG DOCKSPACE 
            
            io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
            io.ConfigFlags |= ImGuiConfigFlags.ViewportsEnable;
            
            ImNodes.CreateContext();
            ImPlot.CreateContext();
            ImGuizMo.SetImGuiContext(_context);
            ImGui.SetCurrentContext(_context);
            
            // REBUILD ATLAS
            ImFontAtlasPtr fonts = ImGui.GetIo().Fonts;
            
            string dirFonts = Environment.CurrentDirectory + "/Assets/Fonts/Jetbrains/";
            string fontToLoad = "JetBrainsMono-Bold.ttf";
            
            if (!Directory.Exists(dirFonts))
            {
                Logger.Info(@$"ERROR, DIR NOT FOUND: {dirFonts}");
                return;
            }
            
            if (!File.Exists(dirFonts + fontToLoad))
            {
                Logger.Info(@$"ERROR, FONT NOT FOUND: {dirFonts + fontToLoad}");
                return;
            }
            
            fonts.AddFontDefault();
            ImFontPtr fontLoaded = fonts.AddFontFromFileTtf(@$"{dirFonts}{fontToLoad}", 14);
            
            fonts.GetTexDataAsRgba32(out byte* pixelData, out int width, out int height, out int _);
            _fontTextureId = LoadTexture((IntPtr) pixelData, width, height);
            
            fonts.TexId = (IntPtr) _fontTextureId;
            fonts.ClearTexData();
            
            // CONFIG DOCKSPACE
            ImGuiViewportPtr viewport = ImGui.GetMainViewport();
            ImGui.SetNextWindowPos(viewport.WorkPos);
            ImGui.SetNextWindowSize(viewport.WorkSize);
            ImGui.SetNextWindowViewport(viewport.Id);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);
            dockspaceflags |= ImGuiWindowFlags.MenuBar;
            dockspaceflags |= ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove;
            //dockspaceflags |= ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus;
            
            // config style
            style = ImGui.GetStyle();
            ImGui.StyleColorsDark();
            style.WindowRounding = 0.0f;
            style.Colors2.W = 1.0f;
            
            // config input manager 
            
            io.KeyMap[(int) ImGuiKey.Tab] = (int) SdlScancode.SdlScancodeTab;
            io.KeyMap[(int) ImGuiKey.LeftArrow] = (int) SdlScancode.SdlScancodeLeft;
            io.KeyMap[(int) ImGuiKey.RightArrow] = (int) SdlScancode.SdlScancodeRight;
            io.KeyMap[(int) ImGuiKey.UpArrow] = (int) SdlScancode.SdlScancodeUp;
            io.KeyMap[(int) ImGuiKey.DownArrow] = (int) SdlScancode.SdlScancodeDown;
            io.KeyMap[(int) ImGuiKey.PageUp] = (int) SdlScancode.SdlScancodePageup;
            io.KeyMap[(int) ImGuiKey.PageDown] = (int) SdlScancode.SdlScancodePagedown;
            io.KeyMap[(int) ImGuiKey.Home] = (int) SdlScancode.SdlScancodeHome;
            io.KeyMap[(int) ImGuiKey.End] = (int) SdlScancode.SdlScancodeEnd;
            io.KeyMap[(int) ImGuiKey.Insert] = (int) SdlScancode.SdlScancodeInsert;
            io.KeyMap[(int) ImGuiKey.Delete] = (int) SdlScancode.SdlScancodeDelete;
            io.KeyMap[(int) ImGuiKey.Backspace] = (int) SdlScancode.SdlScancodeBackspace;
            io.KeyMap[(int) ImGuiKey.Space] = (int) SdlScancode.SdlScancodeSpace;
            io.KeyMap[(int) ImGuiKey.Enter] = (int) SdlScancode.SdlScancodeReturn;
            io.KeyMap[(int) ImGuiKey.Escape] = (int) SdlScancode.SdlScancodeEscape;
            io.KeyMap[(int) ImGuiKey.KeypadEnter] = (int) SdlScancode.SdlScancodeReturn2;
            io.KeyMap[(int) ImGuiKey.A] = (int) SdlScancode.SdlScancodeA;
            io.KeyMap[(int) ImGuiKey.C] = (int) SdlScancode.SdlScancodeC;
            io.KeyMap[(int) ImGuiKey.V] = (int) SdlScancode.SdlScancodeV;
            io.KeyMap[(int) ImGuiKey.X] = (int) SdlScancode.SdlScancodeX;
            io.KeyMap[(int) ImGuiKey.Y] = (int) SdlScancode.SdlScancodeY;
            io.KeyMap[(int) ImGuiKey.Z] = (int) SdlScancode.SdlScancodeZ;
            
            _vboHandle = Gl.GenBuffer();
            _elementsHandle = Gl.GenBuffer();
            _vertexArrayObject = Gl.GenVertexArray();
            
            while (!_quit)
            {
                while (Sdl.PollEvent(out Event e) != 0)
                {
                    ProcessEvent(e);
                    switch (e.type)
                    {
                        case EventType.Quit:
                        {
                            _quit = true;
                            break;
                        }
                        case EventType.Keydown:
                        {
                            switch (e.key.keySym.sym)
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
                
                
                Gl.GlClearColor(0.05f, 0.05f, 0.05f, 1.00f);
                
                ImGui.NewFrame();
                
                // Setup display size (every frame to accommodate for window resizing)
                Vector2 windowSize = Sdl.GetWindowSize(_window);
                Sdl.GetDrawableSize(_window, out int displayW, out int displayH);
                io.DisplaySize = new Vector2(windowSize.X, windowSize.Y);
                if ((windowSize.X > 0) && (windowSize.Y > 0))
                {
                    io.DisplayFramebufferScale = new Vector2(displayW / windowSize.X, displayH / windowSize.Y);
                }
                
                // Setup time step (we don't use SDL_GetTicks() because it is using millisecond resolution)
                ulong frequency = Sdl.GetPerformanceFrequency();
                ulong currentTime = Sdl.GetPerformanceCounter();
                io.DeltaTime = _time > 0 ? (float) ((double) (currentTime - _time) / frequency) : 1.0f / 60.0f;
                if (io.DeltaTime <= 0)
                {
                    io.DeltaTime = 0.016f;
                }
                
                _time = currentTime;
                
                UpdateMousePosAndButtons();
                
                ImGui.PushFont(fontLoaded);
                
                ImGui.BeginMainMenuBar();
                if (ImGui.BeginMenu("Sample main menu"))
                {
                    ImGui.Separator();
                    ImGui.Text("Sample text");
                    ImGui.EndMenu();
                }
                
                ImGui.EndMainMenuBar();
                
                
                int sizeMenuDown = 25;
                Vector2 sizeDock = viewport.Size - new Vector2(0, sizeMenuDown * 2);
                
                
                ImGui.SetNextWindowPos(viewport.WorkPos);
                ImGui.SetNextWindowSize(sizeDock);
                //ImGui.SetNextWindowViewport(viewport.ID);
                ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
                ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);
                ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2(0.0f, 0.0f));
                
                
                ImGui.Begin("DockSpace Demo", dockspaceflags);
                // Submit the DockSpace
                
                ImGui.PopStyleVar(3);
                
                uint dockSpaceId = ImGui.GetId("MyDockSpace");
                ImGui.DockSpace(dockSpaceId, sizeDock);
                
                if (ImGui.BeginMenuBar())
                {
                    if (ImGui.BeginMenu("Options"))
                    {
                        ImGui.Separator();
                        ImGui.Text("Sample text");
                        ImGui.EndMenu();
                    }
                    
                    ImGui.EndMenuBar();
                }
                
                windows.ForEach(i => i.Render());
                ShowDemos();
                
                // Add menu bar flag and disable everything else
                ImGuiWindowFlags styleGlagsMenuDown =
                    ImGuiWindowFlags.NoDecoration | ImGuiWindowFlags.NoInputs |
                    ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoScrollWithMouse |
                    ImGuiWindowFlags.NoSavedSettings |
                    ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoBackground |
                    ImGuiWindowFlags.MenuBar;
                
                ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 0.0f);
                ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0.0f);
                ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2(0.0f, 0.0f));
                
                ImGui.SetNextWindowPos(new Vector2(viewport.Pos.X, viewport.Pos.Y + (viewport.Size.Y - sizeMenuDown)));
                ImGui.SetNextWindowSize(new Vector2(viewport.Size.X, sizeMenuDown));
                if (ImGui.Begin("##MenuDown", ref menuDownState, styleGlagsMenuDown))
                {
                    ImGui.PopStyleVar(3);
                    if (ImGui.BeginMenuBar())
                    {
                        ImGui.Text("Hello world from menu down");
                        
                        ImGui.Button("sample");
                        
                        ImGui.EndMenuBar();
                    }
                    
                    
                    ImGui.End();
                }
                
                
                ImGui.End();
                ImGui.PopFont();
                
                
                Sdl.MakeCurrent(_window, _glContext);
                ImGui.Render();
                
                Gl.GlViewport(0, 0, (int) io.DisplaySize.X, (int) io.DisplaySize.Y);
                Gl.GlClear(ClearBufferMask.ColorBufferBit);
                
                RenderDrawData();
                
                IntPtr backupCurrentWindow = Sdl.GetCurrentWindow();
                IntPtr backupCurrentContext = Sdl.GetCurrentContext();
                ImGui.UpdatePlatformWindows();
                ImGui.RenderPlatformWindowsDefault();
                Sdl.MakeCurrent(backupCurrentWindow, backupCurrentContext);
                
                
                Gl.GlDisable(EnableCap.ScissorTest);
                Sdl.SwapWindow(_window);
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
            Sdl.DestroyWindow(_window);
            Sdl.Quit();
        }
        
        /// <summary>
        ///     Shows the demos
        /// </summary>
        private void ShowDemos()
        {
            ImGui.ShowDemoWindow();
            
            ImGui.Begin("simple node editor");
            
            ImNodes.BeginNodeEditor();
            ImNodes.BeginNode(1);
            
            ImNodes.BeginNodeTitleBar();
            ImGui.TextUnformatted("simple node :)");
            ImNodes.EndNodeTitleBar();
            
            ImNodes.BeginInputAttribute(2);
            ImGui.Text("input");
            ImNodes.EndInputAttribute();
            
            ImNodes.BeginOutputAttribute(3);
            ImGui.Indent(40);
            ImGui.Text("output");
            ImNodes.EndOutputAttribute();
            
            ImNodes.EndNode();
            ImNodes.EndNodeEditor();
            
            ImGui.End();
            
            ImPlot.ShowDemoWindow();
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
                    SdlScancode key = evt.key.keySym.scancode;
                    imGuiIoPtr.KeysDown[(int) key] = evt.type == EventType.Keydown;
                    Logger.Info("io.KeysDown[" + key + "] = " + evt.type + imGuiIoPtr.KeysDown[(int) key]);
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
                Sdl.WarpMouseInWindow(_window, (int) imGuiIoPtr.MousePos.X, (int) imGuiIoPtr.MousePos.Y);
            }
            else
            {
                imGuiIoPtr.MousePos = new Vector2(float.MinValue, float.MinValue);
            }
            
            uint mouseButtons = Sdl.GetMouseStateOutXAndY(out int mx, out int my);
            imGuiIoPtr.MouseDown[0] =
                _mousePressed[0] ||
                (mouseButtons & Sdl.Button(Sdl.ButtonLeft)) !=
                0; // If a mouse press event came, always pass it as "mouse held this frame", so we don't miss click-release events that are shorter than 1 frame.
            imGuiIoPtr.MouseDown[1] = _mousePressed[1] || (mouseButtons & Sdl.Button(Sdl.ButtonRight)) != 0;
            imGuiIoPtr.MouseDown[2] = _mousePressed[2] || (mouseButtons & Sdl.Button(Sdl.ButtonMiddle)) != 0;
            _mousePressed[0] = _mousePressed[1] = _mousePressed[2] = false;
            
            IntPtr focusedWindow = Sdl.GetKeyboardFocus();
            if (_window == focusedWindow)
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
            Gl.VertexAttribPointer(_shader["Position"].Location, 2, VertexAttribPointerType.Float, false, drawVertSize, Marshal.OffsetOf<ImDrawVert>("Pos"));
            Gl.VertexAttribPointer(_shader["UV"].Location, 2, VertexAttribPointerType.Float, false, drawVertSize, Marshal.OffsetOf<ImDrawVert>("Uv"));
            Gl.VertexAttribPointer(_shader["Color"].Location, 4, VertexAttribPointerType.UnsignedByte, true, drawVertSize, Marshal.OffsetOf<ImDrawVert>("Col"));
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
        private static uint LoadTexture(IntPtr pixelData, int width, int height, Format format = Format.Rgba, InternalFormat internalFormat = InternalFormat.Rgba)
        {
            uint textureId = Gl.GenTexture();
            Gl.GlPixelStorei(StoreParameter.UnpackAlignment, 1);
            Gl.GlBindTexture(TextureTarget.Texture2D, textureId);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, internalFormat, width, height, 0, format, Type.UnsignedByte, pixelData);
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