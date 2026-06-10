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
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Alis.App.Engine.Core;
using Alis.App.Engine.Demos;
using Alis.App.Engine.Windows;
using Alis.App.Engine.Windows.Settings;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Memory;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Platforms;
using Alis.Core.Graphic.Platforms.Osx;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Alis.Extension.Graphic.Ui.Extras.Node;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine
{
    /// <summary>
    ///     Sample host application that creates a native window, initializes OpenGL and ImGui,
    ///     and runs the selected example. Code is organized for clarity and maintainability.
    /// </summary>
    public class Engine
    {
        /// <summary>
        ///     The show project
        /// </summary>
        private bool showProject;

        /// <summary>
        ///     The show inspector
        /// </summary>
        private bool showInspector;

        /// <summary>
        ///     The show console
        /// </summary>
        private bool showConsole;

        /// <summary>
        /// The imgui context
        /// </summary>
        private IntPtr imguiContext;
        
        /// <summary>
        ///     The vector
        /// </summary>
        private readonly Vector2F[] _lastClickPos = new Vector2F[5];

        /// <summary>
        ///     The last click time
        /// </summary>
        private readonly double[] _lastClickTime = new double[5];

        /// <summary>
        ///     The mouse clicked
        /// </summary>
        private readonly bool[] _mouseClicked = new bool[5];

        /// <summary>
        ///     The mouse clicked count
        /// </summary>
        private readonly ushort[] _mouseClickedCount = new ushort[5];

        /// <summary>
        ///     The mouse clicked time
        /// </summary>
        private readonly double[] _mouseClickedTime = new double[5];

        /// <summary>
        ///     The mouse double clicked
        /// </summary>
        private readonly bool[] _mouseDoubleClicked = new bool[5];

        /// <summary>
        ///     The prev mouse down
        /// </summary>
        private readonly bool[] _prevMouseDown = new bool[5];

        /// <summary>
        ///     The space work
        /// </summary>
        private readonly SpaceWork _spaceWork = new SpaceWork();

        /// <summary>
        ///     The resolution program
        /// </summary>
        private readonly float resolutionProgramX = 1920;

        /// <summary>
        ///     The resolution program
        /// </summary>
        private readonly float resolutionProgramY = 1080;

        /// <summary>
        ///     The ebo
        /// </summary>
        private uint _ebo;

        /// <summary>
        ///     The font texture
        /// </summary>
        private uint _fontTexture;

        /// <summary>
        ///     The shader program
        /// </summary>
        private uint _shaderProgram;

        /// <summary>
        ///     The vao
        /// </summary>
        private uint _vao;

        /// <summary>
        ///     The vbo
        /// </summary>
        private uint _vbo;

        /// <summary>
        ///     The dockspaceflags
        /// </summary>
        private ImGuiWindowFlags dockspaceflags;

        /// <summary>
        ///     The first time scale
        /// </summary>
        private bool firstTimeScale = true;

        /// <summary>
        ///     The frame counter
        /// </summary>
        private int FrameCounter;

        /// <summary>
        ///     The is first time
        /// </summary>
        private bool isFirstTime = true;

        /// <summary>
        ///     The is init
        /// </summary>
        private bool IsInit;

        /// <summary>
        ///     The platform
        /// </summary>
#pragma warning disable CS0649
        private INativePlatform platform = null!;
#pragma warning restore CS0649

        /// <summary>
        ///     The scale factor
        /// </summary>
        private float scaleFactor = 1.0f;

        /// <summary>
        ///     Application entry point.
        /// </summary>
        public void Run()
        {
            const double targetFrameTime = 1.0 / 60.0;
            Stopwatch frameTimer = Stopwatch.StartNew();
            double lastTime = frameTimer.Elapsed.TotalSeconds;


            InitializeEngine();

            RunGameLoop(frameTimer, ref lastTime, targetFrameTime);

            if (_vbo != 0)
            {
                Gl.DeleteBuffer(_vbo);
            }

            if (_ebo != 0)
            {
                Gl.DeleteBuffer(_ebo);
            }

            if (_vao != 0)
            {
                Gl.DeleteVertexArray(_vao);
            }

            if (_shaderProgram != 0)
            {
                Gl.GlDeleteProgram(_shaderProgram);
            }

            if (_fontTexture != 0)
            {
                Gl.DeleteTexture(_fontTexture);
            }

            ImGui.SetCurrentContext(new IntPtr());

            CleanupEngine();

            platform.Cleanup();
        }

        /// <summary>
        ///     Runs the game loop
        /// </summary>
        private void RunGameLoop(Stopwatch frameTimer, ref double lastTime, double targetFrameTime)
        {
            while (_spaceWork.IsRunning)
            {
                double now = frameTimer.Elapsed.TotalSeconds;
                double delta = now - lastTime;
                lastTime = now;
                if (delta <= 0.0)
                {
                    delta = targetFrameTime;
                }

                if (delta > 0.25)
                {
                    delta = 0.25; // avoid huge dt values
                }

                _spaceWork.io.DeltaTime = (float) delta;

                _spaceWork.IsRunning = platform.PollEvents();

                ProcessKeyWithImgui();
                UpdateMousePosAndButtons();

                if (platform.TryGetLastInputCharacters(out string pendingChars) && !string.IsNullOrEmpty(pendingChars))
                {
                    _spaceWork.io.AddInputCharactersUtf8(pendingChars);
                }

                Draw();

                platform.SwapBuffers();

                int glError = Gl.GlGetError();
                if (glError != 0)
                {
                    Logger.Info($"OpenGL error after SwapBuffers: 0x{glError:X}");
                }

                double frameEnd = frameTimer.Elapsed.TotalSeconds;
                double frameElapsed = frameEnd - now;
                double sleepTime = targetFrameTime - frameElapsed;
                if (sleepTime > 0.0)
                {
                    int sleepMs = (int) (sleepTime * 1000.0);
                    if (sleepMs > 0)
                    {
                        Thread.Sleep(sleepMs);
                    }

                    while (frameTimer.Elapsed.TotalSeconds - now < targetFrameTime)
                    {
                        Thread.SpinWait(10);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes the engine
        /// </summary>
        private void InitializeEngine()
        {
            if (!InitializePlatform(platform, (int) resolutionProgramX, (int) resolutionProgramY, "Alis Hub - by @pabllopf"))
            {
                Logger.Info("Failed to initialize platform or OpenGL context. Exiting.");
                platform?.Cleanup();
                return;
            }

            SetupOpenGLContext();
            SetupImGuiBackend();
            SetupShaders();
            SetupBuffers();
            SetupWindow();
            SetupImGuiContext();
            LoadFonts();
            SetStyle();
            _spaceWork.OnInit();
            _spaceWork.OnStart();

            for (int i = 0; i < 5; i++)
            {
                _mouseClicked[i] = false;
                _mouseDoubleClicked[i] = false;
                _mouseClickedCount[i] = 0;
                _mouseClickedTime[i] = 1e6;
                _prevMouseDown[i] = false;
                _lastClickTime[i] = 0.0;
                _lastClickPos[i] = new Vector2F(0, 0);
            }

            dockspaceflags |= ImGuiWindowFlags.MenuBar;
            dockspaceflags |= ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove;
            dockspaceflags |= ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus;
        }

        /// <summary>
        /// Setup the open gl context
        /// </summary>
        private void SetupOpenGLContext()
        {
            platform.MakeContextCurrent();
            Gl.Initialize(platform.GetProcAddress);
            Gl.GlViewport(0, 0, platform.GetWindowWidth(), platform.GetWindowHeight());
            Gl.GlEnable(EnableCap.DepthTest);
        }

        /// <summary>
        /// Setup the im gui backend
        /// </summary>
        private void SetupImGuiBackend()
        {
            imguiContext= ImGui.CreateContext();
            ImGui.SetCurrentContext(imguiContext);

            Debug.Assert(platform != null, "Platform must be provided before Initialize is called.");
            platform.MakeContextCurrent();

            IntPtr currentCtx = ImGui.GetCurrentContext();
            IntPtr context;
            if (currentCtx == IntPtr.Zero)
            {
                context = ImGui.CreateContext();
                ImGui.SetCurrentContext(context);
            }
            else
            {
                context = currentCtx;
                ImGui.SetCurrentContext(context);
            }

            _spaceWork.io = ImGui.GetIo();
            Debug.Assert(_spaceWork.io.NativePtr != IntPtr.Zero, "ImGui _spaceWork.io must be valid after creating or setting context.");

            _spaceWork.io.BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset |
                                          ImGuiBackendFlags.PlatformHasViewports |
                                          ImGuiBackendFlags.HasGamepad |
                                          ImGuiBackendFlags.HasMouseHoveredViewport |
                                          ImGuiBackendFlags.HasMouseCursors;

            _spaceWork.io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard |
                                         ImGuiConfigFlags.NavEnableGamepad;

            _spaceWork.io.ConfigFlags |= ImGuiConfigFlags.DockingEnable |
                                         ImGuiConfigFlags.ViewportsEnable;

            _spaceWork.io = ImGui.GetIo();
            _spaceWork.io.WantSaveIniSettings = false;
        }

        /// <summary>
        /// Setup the shaders
        /// </summary>
        private void SetupShaders()
        {
            const string vertexShaderSource = "#version 330 core\n" +
                                              "layout (location = 0) in vec2 Position;\n" +
                                              "layout (location = 1) in vec2 UV;\n" +
                                              "layout (location = 2) in vec4 Color;\n" +
                                              "out vec2 Frag_UV;\n" +
                                              "out vec4 Frag_Color;\n" +
                                              "uniform mat4 ProjMtx;\n" +
                                              "void main() { Frag_UV = UV; Frag_Color = Color; gl_Position = ProjMtx * vec4(Position.xy, 0, 1); }\n";

            const string fragmentShaderSource = "#version 330 core\n" +
                                                "in vec2 Frag_UV;\n" +
                                                "in vec4 Frag_Color;\n" +
                                                "uniform sampler2D Texture;\n" +
                                                "out vec4 Out_Color;\n" +
                                                "void main() { Out_Color = Frag_Color * texture(Texture, Frag_UV.st); }\n";

            uint vert = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(vert, vertexShaderSource);
            Gl.GlCompileShader(vert);
            if (!Gl.GetShaderCompileStatus(vert))
            {
                Logger.Info("Vertex shader compile error: " + Gl.GetShaderInfoLog(vert));
            }

            uint frag = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(frag, fragmentShaderSource);
            Gl.GlCompileShader(frag);
            if (!Gl.GetShaderCompileStatus(frag))
            {
                Logger.Info("Fragment shader compile error: " + Gl.GetShaderInfoLog(frag));
            }

            _shaderProgram = Gl.GlCreateProgram();
            Gl.GlAttachShader(_shaderProgram, vert);
            Gl.GlAttachShader(_shaderProgram, frag);
            Gl.GlLinkProgram(_shaderProgram);
            if (!Gl.GetProgramLinkStatus(_shaderProgram))
            {
                Logger.Info("Shader link error: " + Gl.GetProgramInfoLog(_shaderProgram));
            }

            Gl.GlDeleteShader(vert);
            Gl.GlDeleteShader(frag);
        }

        /// <summary>
        /// Setup the buffers
        /// </summary>
        private void SetupBuffers()
        {
            _vao = Gl.GenVertexArray();
            _vbo = Gl.GenBuffer();
            _ebo = Gl.GenBuffer();

            Gl.GlBindVertexArray(_vao);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, _vbo);
            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, _ebo);

            int stride = Marshal.SizeOf<ImDrawVert>();
            Gl.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, stride, IntPtr.Zero);
            Gl.EnableVertexAttribArray(0);
            Gl.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, stride, new IntPtr(8));
            Gl.EnableVertexAttribArray(1);
            Gl.VertexAttribPointer(2, 4, VertexAttribPointerType.UnsignedByte, true, stride, new IntPtr(16));
            Gl.EnableVertexAttribArray(2);

            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, 0);
            Gl.GlBindVertexArray(0);
        }

        /// <summary>
        /// Setup the window
        /// </summary>
        private void SetupWindow()
        {
            Debug.Assert(platform != null, nameof(platform) + " != null");
            platform.ShowWindow();
            platform.SetTitle("Alis Hub - by @pabllopf");

            _spaceWork.io = ImGui.GetIo();
            _spaceWork.io.DisplaySize = new Vector2F(platform.GetWindowWidth(), platform.GetWindowHeight());

            Logger.Info($"IMGUI VERSION {ImGui.GetVersion()}");

            _spaceWork.io.BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset
                                          | ImGuiBackendFlags.PlatformHasViewports
                                          | ImGuiBackendFlags.HasGamepad
                                          | ImGuiBackendFlags.HasMouseHoveredViewport
                                          | ImGuiBackendFlags.HasMouseCursors;

            _spaceWork.io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard
                                         | ImGuiConfigFlags.NavEnableGamepad
                                         | ImGuiConfigFlags.DockingEnable
                                         | ImGuiConfigFlags.ViewportsEnable;

            ImNodes.CreateContext();
            ImPlot.CreateContext();
            ImGuizMo.SetImGuiContext(imguiContext);
            ImGui.SetCurrentContext(imguiContext);

            _spaceWork.Viewport = ImGui.GetMainViewport();
        }

        /// <summary>
        /// Setup the im gui context
        /// </summary>
        private void SetupImGuiContext()
        {
            imguiContext = ImGui.CreateContext();
            ImGui.SetCurrentContext(imguiContext);
        }

        /// <summary>
        /// Cleanups the engine
        /// </summary>
        private void CleanupEngine()
        {
            if (_vbo != 0)
            {
                Gl.DeleteBuffer(_vbo);
            }

            if (_ebo != 0)
            {
                Gl.DeleteBuffer(_ebo);
            }

            if (_vao != 0)
            {
                Gl.DeleteVertexArray(_vao);
            }

            if (_shaderProgram != 0)
            {
                Gl.GlDeleteProgram(_shaderProgram);
            }

            if (_fontTexture != 0)
            {
                Gl.DeleteTexture(_fontTexture);
            }

            ImGui.SetCurrentContext(new IntPtr());
        }

        /// <summary>
        ///     Updates the mouse pos and buttons
        /// </summary>
        private void UpdateMousePosAndButtons()
        {
            ImGuiIoPtr io = ImGui.GetIo();
            Debug.Assert(io.NativePtr != IntPtr.Zero, "ImGui IO no inicializado");

            platform.GetMouseState(out _, out _, out bool[] mouseButtons);
            Debug.Assert((mouseButtons != null) && (mouseButtons.Length >= 3), "mouseButtons debe tener al menos 3 elementos");

            platform.GetWindowMetrics(out _, out _, out _, out _, out _, out int fbH);

            platform.GetMousePositionInView(out float mx, out float my);


            my = fbH - my; // Invertir coordenada Y para ImGui

            if (isFirstTime)
            {
                int[] viewport = new int[4];
                Gl.GlGetIntegerv(0x0BA2, viewport);
                int glViewportWidth = viewport[2];
                int glViewportHeight = viewport[3];

                float scaleX = glViewportWidth / resolutionProgramX;
                float scaleY = glViewportHeight / resolutionProgramY;
                scaleFactor = Math.Min(scaleX, scaleY);
                isFirstTime = false;
            }


            mx *= scaleFactor;
            my *= scaleFactor;

            io.AddMousePosEvent(mx, my);

            for (int i = 0; i < 5; i++)
            {
                bool isDown = i < mouseButtons.Length && mouseButtons[i];
                io.AddMouseButtonEvent(i, isDown);

                if (isDown)
                {
                    Logger.Trace($"Botón ratón {i}: {"PRESIONADO"}");
                }
            }

            float wheel = platform.GetMouseWheel();
            if (Math.Abs(wheel) > float.Epsilon)
            {
                io.AddMouseWheelEvent(0.0f, wheel);
                Logger.Trace($"Rueda ratón: {wheel}");
            }

            if (ImGui.IsAnyMouseDown())
            {
                Logger.Trace("Algún botón de ratón está presionado.");
            }
        }

        /// <summary>
        ///     Renders the project
        /// </summary>
        public void RenderProject()
        {
            DrawLeftSidebar();
            DrawRightSidebar();
        }


        /// <summary>
        ///     Draws the left sidebar
        /// </summary>
        private void DrawLeftSidebar()
        {
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0);
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));

            Vector2F dockSize = _spaceWork.Viewport.Size - new Vector2F(5, 85);

            if (_spaceWork.IsMacOs)
            {
                dockSize = _spaceWork.Viewport.Size - new Vector2F(5, 55);
            }

            ImGui.Begin("Sidebar1", ImGuiWindowFlags.NoTitleBar |
                                    ImGuiWindowFlags.NoResize |
                                    ImGuiWindowFlags.NoMove |
                                    ImGuiWindowFlags.NoScrollbar |
                                    ImGuiWindowFlags.NoScrollWithMouse);

            if (_spaceWork.IsMacOs)
            {
                ImGui.SetWindowPos(new Vector2F(0, 30));
                ImGui.SetWindowSize(new Vector2F(40, dockSize.Y));
            }
            else
            {
                ImGui.SetWindowPos(new Vector2F(0, 56));
                ImGui.SetWindowSize(new Vector2F(40, dockSize.Y));
            }

            ImGui.PushFont(_spaceWork.FontLoaded16Solid);

            if (ImGui.Button($"{FontAwesome5.Folder}"))
            {
                showProject = !showProject;
            }

            if (ImGui.Button($"{FontAwesome5.Tools}"))
            {
                showInspector = !showInspector;
            }

            if (ImGui.Button($"{FontAwesome5.Terminal}"))
            {
                showConsole = !showConsole;
            }

            ImGui.PopFont();

            ImGui.End();

            ImGui.PopStyleVar();
            ImGui.PopStyleColor();
        }

        /// <summary>
        ///     Draws the right sidebar
        /// </summary>
        private void DrawRightSidebar()
        {
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0);
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4F(0.098f, 0.102f, 0.114f, 1.0f));

            Vector2F dockSize = _spaceWork.Viewport.Size - new Vector2F(5, 85);

            if (_spaceWork.IsMacOs)
            {
                dockSize = _spaceWork.Viewport.Size - new Vector2F(5, 55);
            }

            ImGui.Begin("Sidebar2", ImGuiWindowFlags.NoTitleBar |
                                    ImGuiWindowFlags.NoResize |
                                    ImGuiWindowFlags.NoMove |
                                    ImGuiWindowFlags.NoScrollbar |
                                    ImGuiWindowFlags.NoScrollWithMouse);

            if (_spaceWork.IsMacOs)
            {
                ImGui.SetWindowPos(new Vector2F(dockSize.X - 35, 30));
                ImGui.SetWindowSize(new Vector2F(40, dockSize.Y));
            }
            else
            {
                ImGui.SetWindowPos(new Vector2F(dockSize.X - 35, 56));
                ImGui.SetWindowSize(new Vector2F(40, dockSize.Y));
            }

            ImGui.PushFont(_spaceWork.FontLoaded16Solid);

            if (ImGui.Button($"{FontAwesome5.Folder}"))
            {
                showProject = !showProject;
            }

            if (ImGui.Button($"{FontAwesome5.Tools}"))
            {
                showInspector = !showInspector;
            }

            if (ImGui.Button($"{FontAwesome5.Terminal}"))
            {
                showConsole = !showConsole;
            }

            ImGui.PopFont();

            ImGui.End();

            ImGui.PopStyleVar();
            ImGui.PopStyleColor();
        }

      /// <summary>
        ///     Processes the key with imgui
        /// </summary>
        private void ProcessKeyWithImgui()
        {
            ImGuiIoPtr io = ImGui.GetIo();

            ProcessKey(io, ConsoleKey.Backspace, ImGuiKey.Backspace);
            ProcessKey(io, ConsoleKey.Tab, ImGuiKey.Tab);
            ProcessKey(io, ConsoleKey.Enter, ImGuiKey.Enter);
            ProcessKey(io, ConsoleKey.Pause, ImGuiKey.Pause);
            ProcessKey(io, ConsoleKey.PrintScreen, ImGuiKey.PrintScreen);
            ProcessKey(io, ConsoleKey.Escape, ImGuiKey.Escape);
            ProcessKey(io, ConsoleKey.Spacebar, ImGuiKey.Space);
            ProcessKey(io, ConsoleKey.PageUp, ImGuiKey.PageUp);
            ProcessKey(io, ConsoleKey.PageDown, ImGuiKey.PageDown);
            ProcessKey(io, ConsoleKey.End, ImGuiKey.End);
            ProcessKey(io, ConsoleKey.Home, ImGuiKey.Home);
            ProcessKey(io, ConsoleKey.Insert, ImGuiKey.Insert);
            ProcessKey(io, ConsoleKey.Delete, ImGuiKey.Delete);
            ProcessKey(io, ConsoleKey.LeftArrow, ImGuiKey.LeftArrow);
            ProcessKey(io, ConsoleKey.UpArrow, ImGuiKey.UpArrow);
            ProcessKey(io, ConsoleKey.RightArrow, ImGuiKey.RightArrow);
            ProcessKey(io, ConsoleKey.DownArrow, ImGuiKey.DownArrow);
            ProcessKey(io, ConsoleKey.D0, ImGuiKey._0);
            ProcessKey(io, ConsoleKey.D1, ImGuiKey._1);
            ProcessKey(io, ConsoleKey.D2, ImGuiKey._2);
            ProcessKey(io, ConsoleKey.D3, ImGuiKey._3);
            ProcessKey(io, ConsoleKey.D4, ImGuiKey._4);
            ProcessKey(io, ConsoleKey.D5, ImGuiKey._5);
            ProcessKey(io, ConsoleKey.D6, ImGuiKey._6);
            ProcessKey(io, ConsoleKey.D7, ImGuiKey._7);
            ProcessKey(io, ConsoleKey.D8, ImGuiKey._8);
            ProcessKey(io, ConsoleKey.D9, ImGuiKey._9);
            ProcessKey(io, ConsoleKey.A, ImGuiKey.A);
            ProcessKey(io, ConsoleKey.B, ImGuiKey.B);
            ProcessKey(io, ConsoleKey.C, ImGuiKey.C);
            ProcessKey(io, ConsoleKey.D, ImGuiKey.D);
            ProcessKey(io, ConsoleKey.E, ImGuiKey.E);
            ProcessKey(io, ConsoleKey.F, ImGuiKey.F);
            ProcessKey(io, ConsoleKey.G, ImGuiKey.G);
            ProcessKey(io, ConsoleKey.H, ImGuiKey.H);
            ProcessKey(io, ConsoleKey.I, ImGuiKey.I);
            ProcessKey(io, ConsoleKey.J, ImGuiKey.J);
            ProcessKey(io, ConsoleKey.K, ImGuiKey.K);
            ProcessKey(io, ConsoleKey.L, ImGuiKey.L);
            ProcessKey(io, ConsoleKey.M, ImGuiKey.M);
            ProcessKey(io, ConsoleKey.N, ImGuiKey.N);
            ProcessKey(io, ConsoleKey.O, ImGuiKey.O);
            ProcessKey(io, ConsoleKey.P, ImGuiKey.P);
            ProcessKey(io, ConsoleKey.Q, ImGuiKey.Q);
            ProcessKey(io, ConsoleKey.R, ImGuiKey.R);
            ProcessKey(io, ConsoleKey.S, ImGuiKey.S);
            ProcessKey(io, ConsoleKey.T, ImGuiKey.T);
            ProcessKey(io, ConsoleKey.U, ImGuiKey.U);
            ProcessKey(io, ConsoleKey.V, ImGuiKey.V);
            ProcessKey(io, ConsoleKey.W, ImGuiKey.W);
            ProcessKey(io, ConsoleKey.X, ImGuiKey.X);
            ProcessKey(io, ConsoleKey.Y, ImGuiKey.Y);
            ProcessKey(io, ConsoleKey.Z, ImGuiKey.Z);
            ProcessKey(io, ConsoleKey.F1, ImGuiKey.F1);
            ProcessKey(io, ConsoleKey.F2, ImGuiKey.F2);
            ProcessKey(io, ConsoleKey.F3, ImGuiKey.F3);
            ProcessKey(io, ConsoleKey.F4, ImGuiKey.F4);
            ProcessKey(io, ConsoleKey.F5, ImGuiKey.F5);
            ProcessKey(io, ConsoleKey.F6, ImGuiKey.F6);
            ProcessKey(io, ConsoleKey.F7, ImGuiKey.F7);
            ProcessKey(io, ConsoleKey.F8, ImGuiKey.F8);
            ProcessKey(io, ConsoleKey.F9, ImGuiKey.F9);
            ProcessKey(io, ConsoleKey.F10, ImGuiKey.F10);
            ProcessKey(io, ConsoleKey.F11, ImGuiKey.F11);
            ProcessKey(io, ConsoleKey.F12, ImGuiKey.F12);
            ProcessKey(io, ConsoleKey.NumPad0, ImGuiKey.Keypad0);
            ProcessKey(io, ConsoleKey.NumPad1, ImGuiKey.Keypad1);
            ProcessKey(io, ConsoleKey.NumPad2, ImGuiKey.Keypad2);
            ProcessKey(io, ConsoleKey.NumPad3, ImGuiKey.Keypad3);
            ProcessKey(io, ConsoleKey.NumPad4, ImGuiKey.Keypad4);
            ProcessKey(io, ConsoleKey.NumPad5, ImGuiKey.Keypad5);
            ProcessKey(io, ConsoleKey.NumPad6, ImGuiKey.Keypad6);
            ProcessKey(io, ConsoleKey.NumPad7, ImGuiKey.Keypad7);
            ProcessKey(io, ConsoleKey.NumPad8, ImGuiKey.Keypad8);
            ProcessKey(io, ConsoleKey.NumPad9, ImGuiKey.Keypad9);
            ProcessKey(io, ConsoleKey.Multiply, ImGuiKey.KeypadMultiply);
            ProcessKey(io, ConsoleKey.Add, ImGuiKey.KeypadAdd);
            ProcessKey(io, ConsoleKey.Subtract, ImGuiKey.KeypadSubtract);
            ProcessKey(io, ConsoleKey.Divide, ImGuiKey.KeypadDecimal);
            ProcessKey(io, ConsoleKey.Decimal, ImGuiKey.Period);
            ProcessKey(io, ConsoleKey.OemPeriod, ImGuiKey.Period);
            ProcessKey(io, ConsoleKey.OemPlus, ImGuiKey.Equal);
        }

        /// <summary>
        ///     Processes a single key mapping
        /// </summary>
    private void ProcessKey(ImGuiIoPtr io, ConsoleKey consoleKey, ImGuiKey imguiKey)
        {
            io.AddKeyEvent(imguiKey, platform.IsKeyDown(consoleKey));
        }

        /// <summary>
        ///     Loads the fonts
        /// </summary>
        private void LoadFonts()
        {
            ImFontAtlasPtr fonts = ImGui.GetIo().Fonts;

            int fontSize = 14;
            int fontSizeIcon = 13;

            MemoryStream fontFileSolid = AssetRegistry.GetResourceMemoryStreamByName("Engine_JetBrainsMono-Bold.ttf");
            IntPtr fontData = Marshal.AllocHGlobal((int) fontFileSolid.Length);
            byte[] fontDataBytes = new byte[fontFileSolid.Length];
            fontFileSolid.ReadExactly(fontDataBytes, 0, (int) fontFileSolid.Length);
            Marshal.Copy(fontDataBytes, 0, fontData, (int) fontFileSolid.Length);
            _spaceWork.FontLoaded16Solid = fonts.AddFontFromMemoryTtf(fontData, fontSize, fontSize);

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

                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();


                MemoryStream fontAwesome = AssetRegistry.GetResourceMemoryStreamByName(FontAwesome5.NameSolid);
                IntPtr fontAwesomeData = Marshal.AllocHGlobal((int) fontAwesome.Length);
                byte[] fontAwesomeDataBytes = new byte[fontAwesome.Length];
                fontAwesome.ReadExactly(fontAwesomeDataBytes, 0, (int) fontAwesome.Length);
                Marshal.Copy(fontAwesomeDataBytes, 0, fontAwesomeData, (int) fontAwesome.Length);
                fonts.AddFontFromMemoryTtf(fontAwesomeData, fontSizeIcon, fontSizeIcon, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameSolid} {e.Message}");
                return;
            }

            MemoryStream fontFileSolid12 = AssetRegistry.GetResourceMemoryStreamByName("Engine_JetBrainsMono-Bold.ttf");
            IntPtr fontData12 = Marshal.AllocHGlobal((int) fontFileSolid12.Length);
            byte[] fontDataBytes12 = new byte[fontFileSolid12.Length];
            fontFileSolid12.ReadExactly(fontDataBytes12, 0, (int) fontFileSolid12.Length);
            Marshal.Copy(fontDataBytes12, 0, fontData12, (int) fontFileSolid12.Length);
            _spaceWork.FontLoaded10Solid = fonts.AddFontFromMemoryTtf(fontData12, 12, 12);

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

                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                MemoryStream fontAwesome12 = AssetRegistry.GetResourceMemoryStreamByName(FontAwesome5.NameSolid);
                IntPtr fontAwesomeData12 = Marshal.AllocHGlobal((int) fontAwesome12.Length);
                byte[] fontAwesomeDataBytes12 = new byte[fontAwesome12.Length];
                fontAwesome12.ReadExactly(fontAwesomeDataBytes12, 0, (int) fontAwesome12.Length);
                Marshal.Copy(fontAwesomeDataBytes12, 0, fontAwesomeData12, (int) fontAwesome12.Length);
                fonts.AddFontFromMemoryTtf(fontAwesomeData12, 12, 12, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameSolid} {e.Message}");
                return;
            }

            MemoryStream fontFileSolid40 = AssetRegistry.GetResourceMemoryStreamByName("Engine_JetBrainsMono-Bold.ttf");
            IntPtr fontData40 = Marshal.AllocHGlobal((int) fontFileSolid40.Length);
            byte[] fontDataBytes40 = new byte[fontFileSolid40.Length];
            fontFileSolid40.ReadExactly(fontDataBytes40, 0, (int) fontFileSolid40.Length);
            Marshal.Copy(fontDataBytes40, 0, fontData40, (int) fontFileSolid40.Length);
            _spaceWork.FontLoaded45Bold = fonts.AddFontFromMemoryTtf(fontData40, 40, 40);

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

                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                MemoryStream fontAwesome40 = AssetRegistry.GetResourceMemoryStreamByName(FontAwesome5.NameSolid);
                IntPtr fontAwesomeData40 = Marshal.AllocHGlobal((int) fontAwesome40.Length);
                byte[] fontAwesomeDataBytes40 = new byte[fontAwesome40.Length];
                fontAwesome40.ReadExactly(fontAwesomeDataBytes40, 0, (int) fontAwesome40.Length);
                Marshal.Copy(fontAwesomeDataBytes40, 0, fontAwesomeData40, (int) fontAwesome40.Length);
                fonts.AddFontFromMemoryTtf(fontAwesomeData40, 40, 40, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameSolid} {e.Message}");
                return;
            }

            MemoryStream fontFileSolid28 = AssetRegistry.GetResourceMemoryStreamByName("Engine_JetBrainsMono-Bold.ttf");
            IntPtr fontData28 = Marshal.AllocHGlobal((int) fontFileSolid28.Length);
            byte[] fontDataBytes28 = new byte[fontFileSolid28.Length];
            fontFileSolid28.ReadExactly(fontDataBytes28, 0, (int) fontFileSolid28.Length);
            Marshal.Copy(fontDataBytes28, 0, fontData28, (int) fontFileSolid28.Length);
            _spaceWork.FontLoaded30Bold = fonts.AddFontFromMemoryTtf(fontData28, 28, 28);
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

                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                MemoryStream fontAwesome28 = AssetRegistry.GetResourceMemoryStreamByName(FontAwesome5.NameSolid);
                IntPtr fontAwesomeData28 = Marshal.AllocHGlobal((int) fontAwesome28.Length);
                byte[] fontAwesomeDataBytes28 = new byte[fontAwesome28.Length];
                fontAwesome28.ReadExactly(fontAwesomeDataBytes28, 0, (int) fontAwesome28.Length);
                Marshal.Copy(fontAwesomeDataBytes28, 0, fontAwesomeData28, (int) fontAwesome28.Length);
                fonts.AddFontFromMemoryTtf(fontAwesomeData28, 28, 28, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameSolid} {e.Message}");
                return;
            }

            MemoryStream fontFileSolidLight = AssetRegistry.GetResourceMemoryStreamByName("Engine_JetBrainsMono-Bold.ttf");
            IntPtr fontDataLight = Marshal.AllocHGlobal((int) fontFileSolidLight.Length);
            byte[] fontDataBytesLight = new byte[fontFileSolidLight.Length];
            fontFileSolidLight.ReadExactly(fontDataBytesLight, 0, (int) fontFileSolidLight.Length);
            Marshal.Copy(fontDataBytesLight, 0, fontDataLight, (int) fontFileSolidLight.Length);
            _spaceWork.FontLoaded16Light = fonts.AddFontFromMemoryTtf(fontDataLight, fontSize, fontSize);

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

                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();


                MemoryStream fontAwesome = AssetRegistry.GetResourceMemoryStreamByName(FontAwesome5.NameLight);
                IntPtr fontAwesomeData = Marshal.AllocHGlobal((int) fontAwesome.Length);
                byte[] fontAwesomeDataBytes = new byte[fontAwesome.Length];
                fontAwesome.ReadExactly(fontAwesomeDataBytes, 0, (int) fontAwesome.Length);
                Marshal.Copy(fontAwesomeDataBytes, 0, fontAwesomeData, (int) fontAwesome.Length);
                fonts.AddFontFromMemoryTtf(fontAwesomeData, fontSizeIcon, fontSizeIcon, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {FontAwesome5.NameLight} {e.Message}");
                return;
            }

            fonts.GetTexDataAsRgba32(out IntPtr pixelData, out int texWidth, out int texHeight, out int _);
            _fontTexture = LoadTexture(pixelData, texWidth, texHeight);
            _spaceWork.FontTextureId = _fontTexture;
            fonts.TexId = (IntPtr) _spaceWork.FontTextureId;
            fonts.ClearTexData();
        }

        /// <summary>
        ///     Sets the style
        /// </summary>
        private void SetStyle()
        {
            ref ImGuiStyle style = ref ImGui.GetStyle();

            style[(int) ImGuiCol.Text] = new Vector4F(1.0f, 1.0f, 1.0f, 1.0f);

            style[(int) ImGuiCol.TextDisabled] = new Vector4F(0.5f, 0.5f, 0.5f, 1.0f);

            style[(int) ImGuiCol.WindowBg] = new Vector4F(0.13f, 0.14f, 0.15f, 1.0f);

            style[(int) ImGuiCol.ChildBg] = new Vector4F(0.13f, 0.14f, 0.15f, 1.0f);

            style[(int) ImGuiCol.PopupBg] = new Vector4F(0.13f, 0.14f, 0.15f, 1.0f);

            style[(int) ImGuiCol.Border] = new Vector4F(0.25f, 0.25f, 0.25f, 1.0f);

            style[(int) ImGuiCol.BorderShadow] = new Vector4F(0.0f, 0.0f, 0.0f, 0.0f);

            style[(int) ImGuiCol.FrameBg] = new Vector4F(0.2f, 0.2f, 0.2f, 1.0f);

            style[(int) ImGuiCol.FrameBgHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            style[(int) ImGuiCol.FrameBgActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            style[(int) ImGuiCol.TitleBg] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            style[(int) ImGuiCol.TitleBgActive] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            style[(int) ImGuiCol.TitleBgCollapsed] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            style[(int) ImGuiCol.MenuBarBg] = new Vector4F(0.15f, 0.15f, 0.15f, 1.0f);

            style[(int) ImGuiCol.ScrollbarBg] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            style[(int) ImGuiCol.ScrollbarGrab] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            style[(int) ImGuiCol.ScrollbarGrabHovered] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            style[(int) ImGuiCol.ScrollbarGrabActive] = new Vector4F(0.5f, 0.5f, 0.5f, 1.0f);

            style[(int) ImGuiCol.CheckMark] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            style[(int) ImGuiCol.SliderGrab] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            style[(int) ImGuiCol.SliderGrabActive] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            style[(int) ImGuiCol.Button] = new Vector4F(0.2f, 0.2f, 0.2f, 1.0f);

            style[(int) ImGuiCol.ButtonHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            style[(int) ImGuiCol.ButtonActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            style[(int) ImGuiCol.Header] = new Vector4F(0.2f, 0.2f, 0.2f, 1.0f);

            style[(int) ImGuiCol.HeaderHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            style[(int) ImGuiCol.HeaderActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            style[(int) ImGuiCol.Separator] = new Vector4F(0.25f, 0.25f, 0.25f, 1.0f);

            style[(int) ImGuiCol.SeparatorHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            style[(int) ImGuiCol.SeparatorActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            style[(int) ImGuiCol.ResizeGrip] = new Vector4F(0.2f, 0.2f, 0.2f, 1.0f);

            style[(int) ImGuiCol.ResizeGripHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            style[(int) ImGuiCol.ResizeGripActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            style[(int) ImGuiCol.Tab] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            style[(int) ImGuiCol.TabHovered] = new Vector4F(0.3f, 0.3f, 0.3f, 1.0f);

            style[(int) ImGuiCol.TabActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            style[(int) ImGuiCol.TabUnfocused] = new Vector4F(0.1f, 0.1f, 0.1f, 1.0f);

            style[(int) ImGuiCol.TabUnfocusedActive] = new Vector4F(0.4f, 0.4f, 0.4f, 1.0f);

            style[(int) ImGuiCol.PlotLines] = new Vector4F(0.61f, 0.61f, 0.61f, 1.0f);

            style[(int) ImGuiCol.PlotLinesHovered] = new Vector4F(0.7f, 0.7f, 0.7f, 1.0f);

            style[(int) ImGuiCol.PlotHistogram] = new Vector4F(0.61f, 0.61f, 0.61f, 1.0f);

            style[(int) ImGuiCol.PlotHistogramHovered] = new Vector4F(0.7f, 0.7f, 0.7f, 1.0f);

            style[(int) ImGuiCol.TextSelectedBg] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            style[(int) ImGuiCol.DragDropTarget] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            style[(int) ImGuiCol.NavHighlight] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            style[(int) ImGuiCol.NavWindowingHighlight] = new Vector4F(0.26f, 0.59f, 0.98f, 1.0f);

            style[(int) ImGuiCol.NavWindowingDimBg] = new Vector4F(0.2f, 0.2f, 0.2f, 0.6f);

            style[(int) ImGuiCol.ModalWindowDimBg] = new Vector4F(0.2f, 0.2f, 0.2f, 0.6f);

            style.WindowRounding = 0.0f;

            style.ChildRounding = 3.0f;

            style.FrameRounding = 3.0f;

            style.PopupRounding = 1.0f;

            style.ScrollbarRounding = 2.0f;

            style.GrabRounding = 1.0f;

            style.LogSliderDeadzone = 4.0f;

            style.TabRounding = 3.0f;

            style.WindowBorderSize = 1.0f;

            style.ChildBorderSize = 1.0f;

            style.PopupBorderSize = 1.0f;

            style.FrameBorderSize = 0.0f;

            style.TabBorderSize = 0.0f;

            style.WindowPadding = new Vector2F(4, 4);

            style.FramePadding = new Vector2F(7, 7);

            style.ItemSpacing = new Vector2F(6, 6);

            style.ItemInnerSpacing = new Vector2F(6, 6);

            style.CellPadding = new Vector2F(10, 10);

            style.TouchExtraPadding = new Vector2F(0, 0);

            style.IndentSpacing = 21;

            style.ScrollbarSize = 13;

            style.GrabMinSize = 13;

            style.WindowTitleAlign = new Vector2F(0.5f, 0.5f);

            style.WindowMenuButtonPosition = ImGuiDir.None;

            style.ColorButtonPosition = 0;

            style.ButtonTextAlign = new Vector2F(0.5f, 0.5f);

            style.DisplayWindowPadding = new Vector2F(19, 19);

            style.DisplaySafeAreaPadding = new Vector2F(3, 3);

            style.AntiAliasedLines = 1;

            style.AntiAliasedFill = 1;

            style.CurveTessellationTol = 1.25f;

            style.CircleTessellationMaxError = 0.2f;

            style.Alpha = 1.0f;

            style.DisabledAlpha = 0.6f;

            _spaceWork.Style = style;
        }

        /// <summary>
        ///     Main per-frame draw. Updates ImGui _spaceWork.io from the platform and renders.
        ///     Avoids exception handling for common control flow.
        /// </summary>
        public void Draw()
        {
            _spaceWork.io = ImGui.GetIo();

            ImGui.NewFrame();

            ImGui.SetNextWindowPos(_spaceWork.Viewport.WorkPos);
            ImGui.SetNextWindowSize(_spaceWork.Viewport.Size);
            ImGui.Begin("DockSpace Demo", dockspaceflags);

            _spaceWork.DockSpaceMenu.Update();

            Vector2F dockSize = _spaceWork.Viewport.Size - new Vector2F(5, 85);

            if (_spaceWork.IsMacOs)
            {
                dockSize = _spaceWork.Viewport.Size - new Vector2F(5, 60);
            }

            dockSize = dockSize - new Vector2F(80, 0);

            if (_spaceWork.IsMacOs)
            {
                ImGui.SetWindowPos(new Vector2F(40, 0));
            }
            else
            {
                ImGui.SetWindowPos(new Vector2F(40, 25));
            }

            uint dockSpaceId = ImGui.GetId("MyDockSpace");
            ImGui.DockSpace(dockSpaceId, dockSize);


            _spaceWork.OnRender();
            RenderProject();

            if (!IsInit && (FrameCounter >= 2))
            {
                BuildDefaultLayout();
                IsInit = true;
            }

            ImGui.End();

            ImGui.Render();
            ImDrawData drawData = ImGui.GetDrawData();
            RenderDrawData(drawData);

            FrameCounter++;
        }

        /// <summary>
        ///     Builds the default layout
        /// </summary>
        private void BuildDefaultLayout()
        {
            ImGuiViewportPtr viewport = ImGui.GetMainViewport();
            uint dockspaceId = ImGui.GetId("MyDockSpace");

            Vector2F fullSize = viewport.Size;

            ImGui.DockBuilderRemoveNode(dockspaceId);
            ImGui.DockBuilderAddNode(dockspaceId, ImGuiDockNodeFlags.NoWindowMenuButton);

            ImGui.DockBuilderSetNodeSize(dockspaceId, fullSize);

            float leftRatio = 0.20f; // ancho de la columna izquierda (20%)
            float rightRatio = 0.25f; // ancho de la columna derecha (20%)
            float bottomRatio = 0.30f; // altura común para todas las zonas inferiores (20%)

            uint dockMainId = dockspaceId;

            uint dockIdLeft = ImGui.DockBuilderSplitNode(dockMainId, ImGuiDir.Left, leftRatio, null, out uint dockRemaining);

            uint dockIdLeftTop = ImGui.DockBuilderSplitNode(dockIdLeft, ImGuiDir.Up, 1.0f - bottomRatio, null, out uint dockIdLeftBottom);

            uint dockIdRight = ImGui.DockBuilderSplitNode(dockRemaining, ImGuiDir.Right, rightRatio, null, out uint dockIdCenter);

            uint dockIdRightTop = ImGui.DockBuilderSplitNode(dockIdRight, ImGuiDir.Up, 1.0f - bottomRatio, null, out uint dockIdRightBottom);

            uint dockIdCenterTop = ImGui.DockBuilderSplitNode(dockIdCenter, ImGuiDir.Up, 1.0f - bottomRatio, null, out uint dockIdCenterBottom);

            uint dockIdCenterBottomLeft = ImGui.DockBuilderSplitNode(dockIdCenterBottom, ImGuiDir.Left, 0.50f, null, out uint dockIdCenterBottomRight);

            ImGui.DockBuilderDockWindow(InspectorWindow.NameWindow, dockIdLeftTop);
            ImGui.DockBuilderDockWindow(ProjectWindow.NameWindow, dockIdLeftTop);
            ImGui.DockBuilderDockWindow(SolutionWindow.NameWindow, dockIdLeftTop);

            ImGui.DockBuilderDockWindow(IconDemo.Name, dockIdLeftBottom);

            ImGui.DockBuilderDockWindow(SettingsWindow.WindowName, dockIdRightTop);

            ImGui.DockBuilderDockWindow(AudioPlayerWindow.WindowName, dockIdRightBottom);

            ImGui.DockBuilderDockWindow(SceneWindow.NameWindow, dockIdCenterTop);
            ImGui.DockBuilderDockWindow(GameWindow.NameWindow, dockIdCenterTop);

            ImGui.DockBuilderDockWindow("Gizmo", dockIdCenterTop);
            ImGui.DockBuilderDockWindow("Simple plot", dockIdCenterTop);
            ImGui.DockBuilderDockWindow("ImPlot Demo", dockIdCenterTop);
            ImGui.DockBuilderDockWindow("Dear ImGui Demo", dockIdCenterTop);
            ImGui.DockBuilderDockWindow("simple node editor", dockIdCenterTop);

            ImGui.DockBuilderDockWindow(AssetsWindow.WindowName, dockIdCenterBottomLeft);
            ImGui.DockBuilderDockWindow(ConsoleWindow.NameWindow, dockIdCenterBottomLeft);


            ImGui.DockBuilderFinish(dockspaceId);
        }

        /// <summary>
        ///     Renders the draw data using the specified draw data
        /// </summary>
        /// <param name="drawData">The draw data</param>
        private void RenderDrawData(ImDrawData drawData)
        {
            if (drawData.CmdListsCount == 0)
            {
                return;
            }

            Gl.GlEnable(EnableCap.Blend);
            Gl.GlBlendEquation(BlendEquationMode.FuncAdd);
            Gl.GlBlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            Gl.GlDisable(EnableCap.CullFace);
            Gl.GlDisable(EnableCap.DepthTest);
            Gl.GlEnable(EnableCap.ScissorTest);

            if (firstTimeScale)
            {
                int[] viewport = new int[4];
                Gl.GlGetIntegerv(0x0BA2, viewport); // 0x0BA2 = GL_VIEWPORT
                int fbWidth = viewport[2];
                int fbHeight = viewport[3];
                ImGuiIoPtr imGuiIoPtr = ImGui.GetIo();
                imGuiIoPtr.DisplaySize = new Vector2F(fbWidth, fbHeight);


                float scaleX = fbWidth / resolutionProgramX;
                float scaleY = fbHeight / resolutionProgramY;
                scaleFactor = Math.Min(scaleX, scaleY);

                Console.WriteLine($"Setting style scale factor: {scaleFactor}");

                _spaceWork.Style.ScaleAllSizes(scaleFactor);
                _spaceWork.io.FontGlobalScale = scaleFactor;


                Console.WriteLine($"Framebuffer Size: {fbWidth}x{fbHeight} | Display Size: {imGuiIoPtr.DisplaySize.X}x{imGuiIoPtr.DisplaySize.Y} | Scale: {imGuiIoPtr.DisplayFramebufferScale.X}x{imGuiIoPtr.DisplayFramebufferScale.Y}");

                firstTimeScale = false;
            }


            float l = 0.0f;
            float r = ImGui.GetIo().DisplaySize.X;
            float t = 0.0f;
            float b = ImGui.GetIo().DisplaySize.Y;

            Matrix4X4 ortho = new Matrix4X4(
                2.0f / (r - l), 0, 0, 0,
                0, 2.0f / (t - b), 0, 0,
                0, 0, -1.0f, 0,
                (r + l) / (l - r), (t + b) / (b - t), 0, 1.0f);

            Gl.GlUseProgram(_shaderProgram);
            int projLocation = Gl.GlGetUniformLocation(_shaderProgram, "ProjMtx");
            Gl.UniformMatrix4Fv(projLocation, ortho);
            int texLocation = Gl.GlGetUniformLocation(_shaderProgram, "Texture");
            Gl.GlUniform1I(texLocation, 0);

            Gl.GlBindVertexArray(_vao);

            for (int n = 0; n < drawData.CmdListsCount; n++)
            {
                ImDrawListPtr cmdList = drawData.CmdListsRange[n];

                int vtxBufferSize = cmdList.VtxBuffer.Size * Marshal.SizeOf<ImDrawVert>();
                int idxBufferSize = cmdList.IdxBuffer.Size * sizeof(ushort);

                Gl.GlBindBuffer(BufferTarget.ArrayBuffer, _vbo);
                Gl.GlBufferData(BufferTarget.ArrayBuffer, new IntPtr(vtxBufferSize), cmdList.VtxBuffer.Data, BufferUsageHint.StreamDraw);

                Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, _ebo);
                Gl.GlBufferData(BufferTarget.ElementArrayBuffer, new IntPtr(idxBufferSize), cmdList.IdxBuffer.Data, BufferUsageHint.StreamDraw);

                long idxOffset = 0;
                for (int cmdi = 0; cmdi < cmdList.CmdBuffer.Size; cmdi++)
                {
                    ImDrawCmd pcmd = cmdList.CmdBuffer[cmdi];
                    if (pcmd.UserCallback == IntPtr.Zero)
                    {
                        IntPtr texIdPtr = pcmd.GetTexId();
                        uint texId = texIdPtr == IntPtr.Zero ? _fontTexture : (uint) texIdPtr.ToInt64();

                        Gl.GlActiveTexture(TextureUnit.Texture0);
                        Gl.GlBindTexture(TextureTarget.Texture2D, texId);

                        int x = (int) pcmd.ClipRect.X;
                        int y = (int) (ImGui.GetIo().DisplaySize.Y - pcmd.ClipRect.W);
                        int width = (int) (pcmd.ClipRect.Z - pcmd.ClipRect.X);
                        int height = (int) (pcmd.ClipRect.W - pcmd.ClipRect.Y);
                        Gl.GlScissor(x, y, width, height);

                        Gl.GlDrawElements(PrimitiveType.Triangles, (int) pcmd.ElemCount, DrawElementsType.UnsignedShort, new IntPtr(idxOffset * sizeof(ushort)));
                    }

                    idxOffset += pcmd.ElemCount;
                }
            }

            Gl.GlDisable(EnableCap.ScissorTest);
            Gl.GlEnable(EnableCap.DepthTest);
            Gl.GlDisable(EnableCap.Blend);
            Gl.GlBindVertexArray(0);
            Gl.GlUseProgram(0);
        }

        /// <summary>
        ///     Initializes the platform using the specified platform
        /// </summary>
        /// <param name="platform">The platform</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="title">The title</param>
        /// <returns>The bool</returns>
        private static bool InitializePlatform(INativePlatform platform, int width, int height, string title)
        {
            if (platform == null)
            {
                return false;
            }

            bool ok = platform.Initialize(width, height, title);
            if (!ok)
            {
                Logger.Info("Failed to create native window / OpenGL context.");
                return false;
            }

            return true;
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
        private uint LoadTexture(IntPtr pixelData, int width, int height, PixelFormat format = PixelFormat.Rgba, PixelInternalFormat internalFormat = PixelInternalFormat.Rgba)
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
    }
}