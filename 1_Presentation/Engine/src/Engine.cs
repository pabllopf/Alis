// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Engine.cs
// 
//  Author: Pablo Perdomo Falcón
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
using Alis.App.Engine.OpenGL;
using Alis.App.Engine.OpenGL.Constructs;
using Alis.App.Engine.OpenGL.Enums;
using Alis.App.Engine.UI;
using Alis.App.Engine.UI.Extras.Guizmo;
using Alis.App.Engine.UI.Extras.Node;
using Alis.App.Engine.UI.Extras.Plot;
using Alis.App.Engine.Windows;
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Type = Alis.App.Engine.OpenGL.Enums.Type;

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
        public static readonly string VertexShader = @"
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
        public static readonly string FragmentShader = @"
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
        private ImGuiStylePtr style;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Engine" /> class
        /// </summary>
        /// <param name="args">The args</param>
        public Engine(string[] args) => windows = new List<IWindow>
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
            if (Sdl.Init(SdlInit.InitVideo) != 0)
            {
                Console.WriteLine($@"Error of SDL2: {Sdl.GetError()}");
                return;
            }

            // GET VERSION SDL2
            SdlVersion version = Sdl.GetVersion();
            Console.WriteLine(@$"SDL2 VERSION {version.major}.{version.minor}.{version.patch}");

            // CONFIG THE SDL2 AN OPENGL CONFIGURATION
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlContextFlags, (int) SdlGlContext.SdlGlContextForwardCompatibleFlag);
            Sdl.SetAttributeByProfile(SdlGlAttr.SdlGlContextProfileMask, SdlGlProfile.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlContextMajorVersion, 3);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlContextMinorVersion, 2);

            Sdl.SetAttributeByProfile(SdlGlAttr.SdlGlContextProfileMask, SdlGlProfile.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlDoubleBuffer, 1);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlDepthSize, 24);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlAlphaSize, 8);
            Sdl.SetAttributeByInt(SdlGlAttr.SdlGlStencilSize, 8);

            // Enable vsync
            Sdl.SetSwapInterval(1);

            // create the window which should be able to have a valid OpenGL context and is resizable
            SdlWindowFlags flags = SdlWindowFlags.WindowOpengl | SdlWindowFlags.WindowResizable | SdlWindowFlags.WindowMaximized;
            if (fullscreen)
            {
                flags |= SdlWindowFlags.WindowFullscreen;
            }

            if (highDpi)
            {
                flags |= SdlWindowFlags.WindowAllowHighDpi;
            }

            _window = Sdl.CreateWindow(NameEngine, (int) WindowPos.WindowPosCentered, (int) WindowPos.WindowPosCentered, widthWindow, heightWindow, flags);
            _glContext = CreateGlContext(_window);

            // compile the shader program
            _shader = new GlShaderProgram(VertexShader, FragmentShader);

            _context = ImGui.CreateContext();

            io = ImGui.GetIo();

            io.DisplaySize = new Vector2(800, 600);

            Console.WriteLine($@"IMGUI VERSION {ImGui.GetVersion()}");

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
            ImGuizmo.SetImGuiContext(_context);
            ImGui.SetCurrentContext(_context);

            // REBUILD ATLAS
            ImFontAtlasPtr fonts = ImGui.GetIo().Fonts;

            string dirFonts = Environment.CurrentDirectory + "/Assets/Fonts/Jetbrains/";
            string fontToLoad = "JetBrainsMono-Bold.ttf";

            if (!Directory.Exists(dirFonts))
            {
                Console.WriteLine(@$"ERROR, DIR NOT FOUND: {dirFonts}");
                return;
            }

            if (!File.Exists(dirFonts + fontToLoad))
            {
                Console.WriteLine(@$"ERROR, FONT NOT FOUND: {dirFonts + fontToLoad}");
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
            style.Colors[(int) ImGuiCol.WindowBg].W = 1.0f;

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
                while (Sdl.PollEvent(out SdlEvent e) != 0)
                {
                    ProcessEvent(e);
                    switch (e.type)
                    {
                        case SdlEventType.SdlQuit:
                        {
                            _quit = true;
                            break;
                        }
                        case SdlEventType.SdlKeydown:
                        {
                            switch (e.key.keySym.sym)
                            {
                                case SdlKeycode.SdlkEscape:
                                case SdlKeycode.SdlkQ:
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
                Sdl.GetWindowSize(_window, out int w, out int h);
                Sdl.GetDrawableSize(_window, out int displayW, out int displayH);
                io.DisplaySize = new Vector2(w, h);
                if ((w > 0) && (h > 0))
                {
                    io.DisplayFramebufferScale = new Vector2((float) displayW / w, (float) displayH / h);
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

                uint dockspaceId = ImGui.GetId("MyDockSpace");
                ImGui.DockSpace(dockspaceId, sizeDock);

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
        public void ShowDemos()
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
        public void ProcessEvent(SdlEvent evt)
        {
            ImGuiIoPtr io = ImGui.GetIo();
            switch (evt.type)
            {
                case SdlEventType.SdlMousewheel:
                {
                    if (evt.wheel.x > 0)
                    {
                        io.MouseWheelH += 1;
                    }

                    if (evt.wheel.x < 0)
                    {
                        io.MouseWheelH -= 1;
                    }

                    if (evt.wheel.y > 0)
                    {
                        io.MouseWheel += 1;
                    }

                    if (evt.wheel.y < 0)
                    {
                        io.MouseWheel -= 1;
                    }

                    return;
                }
                case SdlEventType.SdlMouseButtonDown:
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
                case SdlEventType.SdlTextInput:
                {
                    string str = Encoding.UTF8.GetString(evt.text.Text);
                    io.AddInputCharactersUtf8(str);
                    return;
                }
                case SdlEventType.SdlKeydown:
                case SdlEventType.SdlKeyup:
                {
                    SdlScancode key = evt.key.keySym.scancode;
                    io.KeysDown[(int) key] = evt.type == SdlEventType.SdlKeydown;
                    Console.WriteLine("io.KeysDown[" + key + "] = " + evt.type + io.KeysDown[(int) key]);
                    io.KeyShift = (Sdl.GetModState() & SdlKeyMod.KModShift) != 0;
                    io.KeyCtrl = (Sdl.GetModState() & SdlKeyMod.KModCtrl) != 0;
                    io.KeyAlt = (Sdl.GetModState() & SdlKeyMod.KModAlt) != 0;
                    io.KeySuper = (Sdl.GetModState() & SdlKeyMod.KModGui) != 0;
                    break;
                }
            }
        }

        /// <summary>
        ///     Updates the mouse pos and buttons
        /// </summary>
        private void UpdateMousePosAndButtons()
        {
            ImGuiIoPtr io = ImGui.GetIo();

            // Set OS mouse position if requested (rarely used, only when ImGuiConfigFlags_NavEnableSetMousePos is enabled by user)
            if (io.WantSetMousePos)
            {
                Sdl.WarpMouseInWindow(_window, (int) io.MousePos.X, (int) io.MousePos.Y);
            }
            else
            {
                io.MousePos = new Vector2(float.MinValue, float.MinValue);
            }

            uint mouseButtons = Sdl.GetMouseStateOutXAndY(out int mx, out int my);
            io.MouseDown[0] =
                _mousePressed[0] ||
                (mouseButtons & Sdl.Button(Sdl.ButtonLeft)) !=
                0; // If a mouse press event came, always pass it as "mouse held this frame", so we don't miss click-release events that are shorter than 1 frame.
            io.MouseDown[1] = _mousePressed[1] || (mouseButtons & Sdl.Button(Sdl.ButtonRight)) != 0;
            io.MouseDown[2] = _mousePressed[2] || (mouseButtons & Sdl.Button(Sdl.ButtonMiddle)) != 0;
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
                io.MousePos = new Vector2(mx, my);
            }

            // SDL_CaptureMouse() let the OS know e.g. that our imgui drag outside the SDL window boundaries shouldn't e.g. trigger the OS window resize cursor.
            bool anyMouseButtonDown = ImGui.IsAnyMouseDown();
            Sdl.CaptureMouse(anyMouseButtonDown ? SdlBool.True : SdlBool.False);
        }

        /// <summary>
        ///     Setup the render state using the specified draw data
        /// </summary>
        /// <param name="drawData">The draw data</param>
        /// <param name="fbWidth">The fb width</param>
        /// <param name="fbHeight">The fb height</param>
        private void SetupRenderState(ImDrawDataPtr drawData, int fbWidth, int fbHeight)
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

            Console.WriteLine($"GL Version: {Gl.GlGetString(StringName.Version)}");
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
        public static uint LoadTexture(IntPtr pixelData, int width, int height, Format format = Format.Rgba, InternalFormat internalFormat = InternalFormat.Rgba)
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
            ImDrawDataPtr drawData = ImGui.GetDrawData();

            // Avoid rendering when minimized, scale coordinates for retina displays (screen coordinates != framebuffer coordinates)
            int fbWidth = (int) (drawData.DisplaySize.X * drawData.FramebufferScale.X);
            int fbHeight = (int) (drawData.DisplaySize.Y * drawData.FramebufferScale.Y);
            if (fbWidth <= 0 || fbHeight <= 0)
            {
                return;
            }

            SetupRenderState(drawData, fbWidth, fbHeight);

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
                    ImDrawCmdPtr pcmd = cmdList.CmdBuffer[cmdI];
                    if (pcmd.UserCallback != IntPtr.Zero)
                    {
                        Console.WriteLine("UserCallback not implemented");
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