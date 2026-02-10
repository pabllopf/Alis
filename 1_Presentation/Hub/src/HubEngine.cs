// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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
using Alis.App.Hub.Core;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Memory;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Platforms;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Alis.Extension.Graphic.Ui.Extras.Node;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Hub
{
    /// <summary>
    /// Sample host application that creates a native window, initializes OpenGL and ImGui,
    /// and runs the selected example. Code is organized for clarity and maintainability.
    /// </summary>
    public class HubEngine
    {
        /// <summary>
        /// The space work
        /// </summary>
        private SpaceWork _spaceWork = new SpaceWork();
        
        /// <summary>
        /// The platform
        /// </summary>
        private INativePlatform platform;
        /// <summary>
        /// The context
        /// </summary>
        private IntPtr _context;
        
        /// <summary>
        /// The fonts
        /// </summary>
        private ImFontAtlasPtr fonts;

        /// <summary>
        /// The font texture
        /// </summary>
        private uint _fontTexture;
        /// <summary>
        /// The vao
        /// </summary>
        private uint _vao;
        /// <summary>
        /// The vbo
        /// </summary>
        private uint _vbo;
        /// <summary>
        /// The ebo
        /// </summary>
        private uint _ebo;
        /// <summary>
        /// The shader program
        /// </summary>
        private uint _shaderProgram;

        // State to handle mouse click/double-click detection
        /// <summary>
        /// The prev mouse down
        /// </summary>
        private readonly bool[] _prevMouseDown = new bool[5];
        /// <summary>
        /// The last click time
        /// </summary>
        private readonly double[] _lastClickTime = new double[5];
        /// <summary>
        /// The vector
        /// </summary>
        private readonly Alis.Core.Aspect.Math.Vector.Vector2F[] _lastClickPos = new Alis.Core.Aspect.Math.Vector.Vector2F[5];

        // --- Añadir campos en la clase HubEngine (junto a _prevMouseDown, _lastClickTime, _lastClickPos) ---
        /// <summary>
        /// The mouse clicked
        /// </summary>
        private readonly bool[] _mouseClicked = new bool[5];
        /// <summary>
        /// The mouse double clicked
        /// </summary>
        private readonly bool[] _mouseDoubleClicked = new bool[5];
        /// <summary>
        /// The mouse clicked time
        /// </summary>
        private readonly double[] _mouseClickedTime = new double[5];
        /// <summary>
        /// The mouse clicked count
        /// </summary>
        private readonly ushort[] _mouseClickedCount = new ushort[5];

        /// <summary>
        /// The resolution program
        /// </summary>
        private float resolutionProgramX = 1025;
        /// <summary>
        /// The resolution program
        /// </summary>
        private float resolutionProgramY = 575;
        /// <summary>
        /// The scale factor
        /// </summary>
        private float scaleFactor;


        /// <summary>
        /// Application entry point.
        /// </summary>
        public void Run()
        {
            // Frame limiter: 60 FPS target
            const double targetFrameTime = 1.0 / 60.0;
            Stopwatch frameTimer = Stopwatch.StartNew();
            double lastTime = frameTimer.Elapsed.TotalSeconds;
            
            
            platform = GetPlatform();
            Debug.Assert(platform != null, "Platform implementation must be provided for the current OS.");

            // Initialize native window and GL context
            if (!InitializePlatform(platform, (int)resolutionProgramX, (int)resolutionProgramY, "Alis Hub - by @pabllopf"))
            {
                Logger.Info("Failed to initialize platform or OpenGL context. Exiting.");
                platform?.Cleanup();
                return;
            }

            // Ensure GL API is loaded and viewport configured
            platform.MakeContextCurrent();
            Gl.Initialize(platform.GetProcAddress);
            Gl.GlViewport(0, 0, platform.GetWindowWidth(), platform.GetWindowHeight());
            Gl.GlEnable(EnableCap.DepthTest);

            // Create ImGui context and configure backends
            IntPtr imguiContext = ImGui.CreateContext();
            ImGui.SetCurrentContext(imguiContext);
            
             // Ensure the native GL context is current before creating GL resources.
            Debug.Assert(this.platform != null, "Platform must be provided before Initialize is called.");
            this.platform?.MakeContextCurrent();

            // Create or reuse ImGui context
            IntPtr currentCtx = ImGui.GetCurrentContext();
            if (currentCtx == IntPtr.Zero)
            {
                _context = ImGui.CreateContext();
                ImGui.SetCurrentContext(_context);
            }
            else
            {
                _context = currentCtx;
                ImGui.SetCurrentContext(_context);
            }
            
            _spaceWork.io = ImGui.GetIo();
            Debug.Assert(_spaceWork.io.NativePtr != IntPtr.Zero, "ImGui _spaceWork.io must be valid after creating or setting context.");

            // Backend capabilities
            
            // active plot renders
             _spaceWork.io.BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset |
                                         ImGuiBackendFlags.PlatformHasViewports |
                                         ImGuiBackendFlags.HasGamepad |
                                         ImGuiBackendFlags.HasMouseHoveredViewport |
                                         ImGuiBackendFlags.HasMouseCursors;


            // Enable Keyboard Controls
             _spaceWork.io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard |
                                        ImGuiConfigFlags.NavEnableGamepad;

            // CONFIG DOCKSPACE 
             _spaceWork.io.ConfigFlags |= ImGuiConfigFlags.DockingEnable |
                                        ImGuiConfigFlags.ViewportsEnable;
             
             
             _spaceWork.io = ImGui.GetIo();
             _spaceWork.io.WantSaveIniSettings = false;
            
            // Create simple shader program
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

            // Create VAO/VBO/EBO and configure vertex attributes
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

            Debug.Assert(platform != null, nameof(platform) + " != null");
            platform.ShowWindow();
            platform.SetTitle("Alis Hub - by @pabllopf");

            // Configure _spaceWork.io and features
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

            // Initialize optional ImGui extensions
            ImNodes.CreateContext();
            ImPlot.CreateContext();
            ImGuizMo.SetImGuiContext(imguiContext);
            ImGui.SetCurrentContext(imguiContext);
            
            // Load fonts:
            LoadFonts();
            
            // Configure style
            SetStyle();

            _spaceWork.OnInit();
            _spaceWork.OnStart();
            
            // Inicializar estado del ratón para evitar tiempos a 0 que ImGui interpretaría como clicks recientes
            for (int i = 0; i < 5; i++)
            {
                _mouseClicked[i] = false;
                _mouseDoubleClicked[i] = false;
                _mouseClickedCount[i] = 0;
                _mouseClickedTime[i] = 1e6; // valor grande = "no activo"
                _prevMouseDown[i] = false;
                _lastClickTime[i] = 0.0;
                _lastClickPos[i] = new Alis.Core.Aspect.Math.Vector.Vector2F(0, 0);
            }
           
            ImGuiIoPtr io = ImGui.GetIo();
            
            while (_spaceWork.IsRunning)
            {
                // Update delta time for ImGui using high-resolution timer
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

                io.DeltaTime = (float)delta;
                
                _spaceWork.IsRunning = platform.PollEvents();

                ProcessKeyWithImgui();
                
                UpdateMousePosAndButtons();
                
                // Forward text input characters from the native platform to ImGui (e.g. WM_CHAR on Windows)
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
                
                // Frame pacing: sleep / spin until target frame time reached
                double frameEnd = frameTimer.Elapsed.TotalSeconds;
                double frameElapsed = frameEnd - now;
                double sleepTime = targetFrameTime - frameElapsed;
                if (sleepTime > 0.0)
                {
                    int sleepMs = (int)(sleepTime * 1000.0);
                    if (sleepMs > 0)
                    {
                        // Sleep most of the remaining time (leave small margin for precision)
                        Thread.Sleep(sleepMs);
                    }
                    // Busy-wait the rest for better precision
                    while (frameTimer.Elapsed.TotalSeconds - now < targetFrameTime)
                    {
                        Thread.SpinWait(10);
                    }
                }
            }

            // Cleanup
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
            
            platform.Cleanup();
        }


        /// <summary>
        /// The is first time
        /// </summary>
        private static bool isFirstTime = true;
        /// <summary>
        /// The gl viewport width
        /// </summary>
        private static int glViewportWidth;
        /// <summary>
        /// The gl viewport height
        /// </summary>
        private static int glViewportHeight;

        /// <summary>
        /// Updates the mouse pos and buttons
        /// </summary>
        private void UpdateMousePosAndButtons()
        {
            ImGuiIoPtr io = ImGui.GetIo();
            Debug.Assert(io.NativePtr != IntPtr.Zero, "ImGui IO no inicializado");

            // Obtener estado del mouse desde la plataforma
            platform.GetMouseState(out int mouseX, out int mouseY, out bool[] mouseButtons);
            Debug.Assert(mouseButtons != null && mouseButtons.Length >= 3, "mouseButtons debe tener al menos 3 elementos");

            platform.GetWindowMetrics(out int winX, out int winY,
                out int winW, out int winH,
                out int fbW, out int fbH);
            
            platform.GetMousePositionInView(out float mx, out float my);
            
            
            //my = fbH - my; // Invertir coordenada Y para ImGui

            // GL_VIEWPORT
            int[] viewport = new int[4];
            Gl.GlGetIntegerv(0x0BA2, viewport);
            glViewportWidth = viewport[2];
            glViewportHeight = viewport[3];
            
            float scaleX = glViewportWidth / resolutionProgramX;
            float scaleY = glViewportHeight / resolutionProgramY;
           
            my = fbH - my;

            mx *= scaleX;
            my *= scaleY; 
            
            //Console.WriteLine($"Mouse Pos in windows: X={mx}, Y={my} | Display Framebuffer Size: W={glViewportWidth}, H={glViewportHeight} | Window Size: W={winW}, H={winH} | Window Pos: X={winX}, Y={winY} | Windows Space Windows {fbW}, {fbH} | Scale Factor: {scaleFactor} | Resolution Program: W={resolutionProgramX}, H={resolutionProgramY} ");
            io.AddMousePosEvent(mx, my);

            // Actualizar estado de los botones (máximo 5 botones)
            for (int i = 0; i < 5; i++)
            {
                bool isDown = (mouseButtons != null && i < mouseButtons.Length) ? mouseButtons[i] : false;
                io.AddMouseButtonEvent(i, isDown);

                if (isDown)
                {
                    Logger.Trace($"Botón ratón {i}: {("PRESIONADO")}");
                }
            }

            // Actualizar la rueda del mouse (vertical)
            float wheel = platform.GetMouseWheel();
            if (Math.Abs(wheel) > float.Epsilon)
            {
                io.AddMouseWheelEvent(0.0f, wheel);
                Logger.Trace($"Rueda ratón: {wheel}");
            }

            // Validación extra: ¿algún botón presionado?
            if (ImGui.IsAnyMouseDown())
            {
                Logger.Trace("Algún botón de ratón está presionado.");
            }
        }

        /// <summary>
          /// Processes the key with imgui
          /// </summary>
          private void ProcessKeyWithImgui()
        {
            // Control y edición
            if (platform.IsKeyDown(ConsoleKey.Backspace))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Backspace, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Backspace, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Tab))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Tab, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Tab, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Enter))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Enter, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Enter, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Pause))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Pause, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Pause, false);
            }

            if (platform.IsKeyDown(ConsoleKey.PrintScreen))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.PrintScreen, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.PrintScreen, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Escape))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Escape, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Escape, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Spacebar))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Space, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Space, false);
            }

            if (platform.IsKeyDown(ConsoleKey.PageUp))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.PageUp, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.PageUp, false);
            }

            if (platform.IsKeyDown(ConsoleKey.PageDown))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.PageDown, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.PageDown, false);
            }

            if (platform.IsKeyDown(ConsoleKey.End))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.End, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.End, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Home))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Home, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Home, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Insert))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Insert, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Insert, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Delete))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Delete, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Delete, false);
            }

            // Flechas
            if (platform.IsKeyDown(ConsoleKey.LeftArrow))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.LeftArrow, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.LeftArrow, false);
            }

            if (platform.IsKeyDown(ConsoleKey.UpArrow))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.UpArrow, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.UpArrow, false);
            }

            if (platform.IsKeyDown(ConsoleKey.RightArrow))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.RightArrow, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.RightArrow, false);
            }

            if (platform.IsKeyDown(ConsoleKey.DownArrow))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.DownArrow, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.DownArrow, false);
            }

            // Números fila superior
            if (platform.IsKeyDown(ConsoleKey.D0))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._0, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._0, false);
            }

            if (platform.IsKeyDown(ConsoleKey.D1))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._1, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._1, false);
            }

            if (platform.IsKeyDown(ConsoleKey.D2))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._2, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._2, false);
            }

            if (platform.IsKeyDown(ConsoleKey.D3))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._3, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._3, false);
            }

            if (platform.IsKeyDown(ConsoleKey.D4))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._4, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._4, false);
            }

            if (platform.IsKeyDown(ConsoleKey.D5))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._5, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._5, false);
            }

            if (platform.IsKeyDown(ConsoleKey.D6))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._6, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._6, false);
            }

            if (platform.IsKeyDown(ConsoleKey.D7))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._7, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._7, false);
            }

            if (platform.IsKeyDown(ConsoleKey.D8))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._8, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._8, false);
            }

            if (platform.IsKeyDown(ConsoleKey.D9))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._9, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey._9, false);
            }

            // Letras A-Z
            if (platform.IsKeyDown(ConsoleKey.A))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.A, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.A, false);
            }

            if (platform.IsKeyDown(ConsoleKey.B))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.B, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.B, false);
            }

            if (platform.IsKeyDown(ConsoleKey.C))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.C, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.C, false);
            }

            if (platform.IsKeyDown(ConsoleKey.D))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.D, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.D, false);
            }

            if (platform.IsKeyDown(ConsoleKey.E))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.E, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.E, false);
            }

            if (platform.IsKeyDown(ConsoleKey.F))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F, false);
            }

            if (platform.IsKeyDown(ConsoleKey.G))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.G, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.G, false);
            }

            if (platform.IsKeyDown(ConsoleKey.H))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.H, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.H, false);
            }

            if (platform.IsKeyDown(ConsoleKey.I))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.I, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.I, false);
            }

            if (platform.IsKeyDown(ConsoleKey.J))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.J, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.J, false);
            }

            if (platform.IsKeyDown(ConsoleKey.K))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.K, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.K, false);
            }

            if (platform.IsKeyDown(ConsoleKey.L))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.L, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.L, false);
            }

            if (platform.IsKeyDown(ConsoleKey.M))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.M, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.M, false);
            }

            if (platform.IsKeyDown(ConsoleKey.N))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.N, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.N, false);
            }

            if (platform.IsKeyDown(ConsoleKey.O))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.O, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.O, false);
            }

            if (platform.IsKeyDown(ConsoleKey.P))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.P, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.P, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Q))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Q, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Q, false);
            }

            if (platform.IsKeyDown(ConsoleKey.R))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.R, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.R, false);
            }

            if (platform.IsKeyDown(ConsoleKey.S))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.S, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.S, false);
            }

            if (platform.IsKeyDown(ConsoleKey.T))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.T, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.T, false);
            }

            if (platform.IsKeyDown(ConsoleKey.U))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.U, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.U, false);
            }

            if (platform.IsKeyDown(ConsoleKey.V))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.V, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.V, false);
            }

            if (platform.IsKeyDown(ConsoleKey.W))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.W, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.W, false);
            }

            if (platform.IsKeyDown(ConsoleKey.X))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.X, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.X, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Y))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Y, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Y, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Z))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Z, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Z, false);
            }

            // Teclas de función
            if (platform.IsKeyDown(ConsoleKey.F1))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F1, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F1, false);
            }

            if (platform.IsKeyDown(ConsoleKey.F2))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F2, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F2, false);
            }

            if (platform.IsKeyDown(ConsoleKey.F3))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F3, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F3, false);
            }

            if (platform.IsKeyDown(ConsoleKey.F4))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F4, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F4, false);
            }

            if (platform.IsKeyDown(ConsoleKey.F5))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F5, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F5, false);
            }

            if (platform.IsKeyDown(ConsoleKey.F6))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F6, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F6, false);
            }

            if (platform.IsKeyDown(ConsoleKey.F7))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F7, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F7, false);
            }

            if (platform.IsKeyDown(ConsoleKey.F8))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F8, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F8, false);
            }

            if (platform.IsKeyDown(ConsoleKey.F9))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F9, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F9, false);
            }

            if (platform.IsKeyDown(ConsoleKey.F10))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F10, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F10, false);
            }

            if (platform.IsKeyDown(ConsoleKey.F11))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F11, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F11, false);
            }

            if (platform.IsKeyDown(ConsoleKey.F12))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F12, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.F12, false);
            }

            // Teclado numérico
            if (platform.IsKeyDown(ConsoleKey.NumPad0))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad0, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad0, false);
            }

            if (platform.IsKeyDown(ConsoleKey.NumPad1))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad1, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad1, false);
            }

            if (platform.IsKeyDown(ConsoleKey.NumPad2))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad2, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad2, false);
            }

            if (platform.IsKeyDown(ConsoleKey.NumPad3))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad3, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad3, false);
            }

            if (platform.IsKeyDown(ConsoleKey.NumPad4))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad4, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad4, false);
            }

            if (platform.IsKeyDown(ConsoleKey.NumPad5))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad5, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad5, false);
            }

            if (platform.IsKeyDown(ConsoleKey.NumPad6))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad6, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad6, false);
            }

            if (platform.IsKeyDown(ConsoleKey.NumPad7))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad7, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad7, false);
            }

            if (platform.IsKeyDown(ConsoleKey.NumPad8))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad8, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad8, false);
            }

            if (platform.IsKeyDown(ConsoleKey.NumPad9))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad9, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Keypad9, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Multiply))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.KeypadMultiply, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.KeypadMultiply, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Add))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.KeypadAdd, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.KeypadAdd, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Subtract))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.KeypadSubtract, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.KeypadSubtract, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Decimal))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.KeypadDecimal, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.KeypadDecimal, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Divide))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.KeypadDivide, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.KeypadDivide, false);
            }

            // Puntuación / OEM
            if (platform.IsKeyDown(ConsoleKey.Oem1))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Semicolon, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Semicolon, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Oem2))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Slash, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Slash, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Oem3))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.GraveAccent, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.GraveAccent, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Oem4))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.LeftBracket, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.LeftBracket, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Oem5))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Backslash, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Backslash, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Oem6))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.RightBracket, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.RightBracket, false);
            }

            if (platform.IsKeyDown(ConsoleKey.Oem7))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Apostrophe, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Apostrophe, false);
            }

            if (platform.IsKeyDown(ConsoleKey.OemComma))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Comma, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Comma, false);
            }

            if (platform.IsKeyDown(ConsoleKey.OemMinus))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Minus, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Minus, false);
            }

            if (platform.IsKeyDown(ConsoleKey.OemPeriod))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Period, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Period, false);
            }

            if (platform.IsKeyDown(ConsoleKey.OemPlus))
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Equal, true);
            }
            else
            {
                _spaceWork.io.AddKeyEvent(ImGuiKey.Equal, false);
            }
        }


        /// <summary>
        ///     Loads the fonts
        /// </summary>
        private void LoadFonts()
        {
            fonts = ImGui.GetIo().Fonts;
            
            int fontSize = 14;
            int fontSizeIcon = 13;

            MemoryStream fontFileSolid = AssetRegistry.GetResourceMemoryStreamByName("Hub_JetBrainsMono-Bold.ttf");
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

                // Allocate GCHandle to pin IconRanges in memory
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

            MemoryStream fontFileSolid12 = AssetRegistry.GetResourceMemoryStreamByName("Hub_JetBrainsMono-Bold.ttf");
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

                // Allocate GCHandle to pin IconRanges in memory
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

            MemoryStream fontFileSolid40 = AssetRegistry.GetResourceMemoryStreamByName("Hub_JetBrainsMono-Bold.ttf");
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

                // Allocate GCHandle to pin IconRanges in memory
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

            MemoryStream fontFileSolid28 = AssetRegistry.GetResourceMemoryStreamByName("Hub_JetBrainsMono-Bold.ttf");
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

                // Allocate GCHandle to pin IconRanges in memory
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

            MemoryStream fontFileSolidLight = AssetRegistry.GetResourceMemoryStreamByName("Hub_JetBrainsMono-Bold.ttf");
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

                // Allocate GCHandle to pin IconRanges in memory
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

            // Build font atlas and upload to GL
            fonts.GetTexDataAsRgba32(out IntPtr pixelData, out int texWidth, out int texHeight, out int _);
            _spaceWork.FontTextureId = LoadTexture(pixelData, texWidth, texHeight);
            fonts.TexId = (IntPtr)_spaceWork.FontTextureId;
            fonts.ClearTexData();
            
            
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
            
            // Background color for child windows
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
            style.FrameBorderSize = 0.0f;

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
            style.ScrollbarSize = 13;

            // Minimum grab size
            style.GrabMinSize = 13;

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
            
            _spaceWork.Style = style;
           
        }

        /// <summary>
        /// Main per-frame draw. Updates ImGui _spaceWork.io from the platform and renders.
        /// Avoids exception handling for common control flow.
        /// </summary>
        public void Draw()
        {
            _spaceWork.io = ImGui.GetIo();
            
           

            ImGui.NewFrame();

            // Only call DockSpaceOverViewport if docking is enabled in ImGui config flags
            if ((_spaceWork.io.ConfigFlags & ImGuiConfigFlags.DockingEnable) != 0)
            {
                ImGui.DockSpaceOverViewport();
            }

            // Show all render:
            
            
            _spaceWork.OnRender(scaleFactor);



            ImGui.Render();
            ImDrawData drawData = ImGui.GetDrawData();
            RenderDrawData(drawData);

            // No exception-handling here; platform may reset wheel internally if needed.
        }

        /// <summary>
        /// The first time scale
        /// </summary>
        private bool firstTimeScale = true;

        /// <summary>
        /// Renders the draw data using the specified draw data
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

            // Obtener el viewport real del framebuffer
            int[] viewport = new int[4];
            Gl.GlGetIntegerv(0x0BA2, viewport); // 0x0BA2 = GL_VIEWPORT
            int fbWidth = viewport[2];
            int fbHeight = viewport[3];
            ImGuiIoPtr imGuiIoPtr = ImGui.GetIo();
            imGuiIoPtr.DisplaySize = new Alis.Core.Aspect.Math.Vector.Vector2F(fbWidth, fbHeight);
            
            
            float scaleX = fbWidth / resolutionProgramX;
            float scaleY = fbHeight / resolutionProgramY;
            scaleFactor = Math.Min(scaleX, scaleY);

            Console.WriteLine($"Setting style scale factor: {scaleFactor}");
            
            _spaceWork.Style.ScaleAllSizes(scaleFactor);
            _spaceWork.io.FontGlobalScale = scaleFactor;
            
            
            
            Console.WriteLine($"Framebuffer Size: {fbWidth}x{fbHeight} | Display Size: {imGuiIoPtr.DisplaySize.X}x{imGuiIoPtr.DisplaySize.Y} | Scale: {imGuiIoPtr.DisplayFramebufferScale.X}x{imGuiIoPtr.DisplayFramebufferScale.Y}");

            
            
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
                    if (pcmd.UserCallback != IntPtr.Zero)
                    {
                        // User callbacks are not handled in this sample
                    }
                    else
                    {
                        IntPtr texIdPtr = pcmd.GetTexId();
                        uint texId = texIdPtr == IntPtr.Zero ? _fontTexture : (uint)texIdPtr.ToInt64();

                        Gl.GlActiveTexture(TextureUnit.Texture0);
                        Gl.GlBindTexture(TextureTarget.Texture2D, texId);

                        int x = (int)pcmd.ClipRect.X;
                        int y = (int)(ImGui.GetIo().DisplaySize.Y - pcmd.ClipRect.W);
                        int width = (int)(pcmd.ClipRect.Z - pcmd.ClipRect.X);
                        int height = (int)(pcmd.ClipRect.W - pcmd.ClipRect.Y);
                        Gl.GlScissor(x, y, width, height);

                        Gl.GlDrawElements(PrimitiveType.Triangles, (int)pcmd.ElemCount, DrawElementsType.UnsignedShort, new IntPtr(idxOffset * sizeof(ushort)));
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

        // Returns the appropriate platform implementation for the current OS.
        /// <summary>
        /// Gets the platform
        /// </summary>
        /// <returns>The native platform</returns>
        private INativePlatform GetPlatform()
        {
#if osxarm64 || osxarm || osxx64 || osx || osxarm || osxx64 || osx
            return new Alis.Core.Graphic.Platforms.Osx.MacNativePlatform();
#elif winx64 || winx86 || winarm64 || winarm || win
            return new Alis.Core.Graphic.Platforms.Win.WinNativePlatform();
#elif linuxx64 || linuxx86 || linuxarm64 || linuxarm || linux
            return new Alis.Core.Graphic.Platforms.Linux.LinuxNativePlatform();
#else
            return null;
#endif
        }

        // Initializes the native platform and OpenGL context. Returns true on success.
        /// <summary>
        /// Initializes the platform using the specified platform
        /// </summary>
        /// <param name="platform">The platform</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="title">The title</param>
        /// <returns>The bool</returns>
        private bool InitializePlatform(INativePlatform platform, int width, int height, string title)
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

        // Loads a font from an input stream into unmanaged memory and returns the IntPtr to the data buffer.
        // Note: The caller is responsible for memory lifetime if the native API expects it to remain valid.
        /// <summary>
        /// Loads the font from resource using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="size">The size</param>
        /// <returns>The native ptr</returns>
        private  IntPtr LoadFontFromResource(Stream stream, int size)
        {
            Debug.Assert(stream != null && stream.Length > 0, "Font stream must be valid.");

            byte[] data = new byte[stream.Length];
            stream.ReadExactly(data, 0, (int)stream.Length);
            IntPtr nativePtr = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, nativePtr, data.Length);
            return nativePtr;
        }

        // Loads the texture using the specified pixel data (RGBA8) and returns the GL texture id.
        /// <summary>
        /// Loads the texture using the specified pixel data
        /// </summary>
        /// <param name="pixelData">The pixel data</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="format">The format</param>
        /// <param name="internalFormat">The internal format</param>
        /// <returns>The texture id</returns>
        private  uint LoadTexture(IntPtr pixelData, int width, int height, PixelFormat format = PixelFormat.Rgba, PixelInternalFormat internalFormat = PixelInternalFormat.Rgba)
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

