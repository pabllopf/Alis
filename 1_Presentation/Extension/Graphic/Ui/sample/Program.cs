using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.GlfwLib;
using Alis.Core.Graphic.GlfwLib.Enums;
using Alis.Core.Graphic.GlfwLib.Structs;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Extension.Graphic.Ui.Controllers;
using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Alis.Extension.Graphic.Ui.Extras.Node;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Extension.Graphic.Ui.Sample.Fonts;
using Exception = System.Exception;

namespace Alis.Extension.Graphic.Ui.Sample
{
    class Program
    {
        private const string TitleMainWindow = "ImGui.NET + GLFW + OpenGL Sample";
        private const string DockSpaceTitle = "DockSpace Demo";
        private const string DockSpaceId = "MyDockSpace";
        private const int ContextVersionMajor = 3;
        private const int ContextVersionMinor = 2;
        private const Profile OpenglProfile = Profile.Core;
        private const bool OpenglForwardCompatible = true;
        private const int VSync = 1; 
        
        private const float FrameRate = 1.0f / 60.0f; 
        
        private const float RedClearColor = 0.45f, GreenClearColor = 0.55f, BlueClearColor = 0.60f, AlphaClearColor = 1.00f;

        private const string VertexShaderSource = """
                                                      #version 330 core
                                                      layout (location = 0) in vec2 Position;
                                                      layout (location = 1) in vec2 UV;
                                                      layout (location = 2) in vec4 Color;
                                                      uniform mat4 projection_matrix;
                                                      out vec2 Frag_UV;
                                                      out vec4 Frag_Color;
                                                      void main() {
                                                          Frag_UV = UV;
                                                          Frag_Color = Color;
                                                          gl_Position = projection_matrix * vec4(Position.xy, 0, 1);
                                                      }
                                                  """;

        private const string FragmentShaderSource = """
                                                        #version 330 core
                                                        in vec2 Frag_UV;
                                                        in vec4 Frag_Color;
                                                        uniform sampler2D Texture;
                                                        out vec4 Out_Color;
                                                        void main() {
                                                            Out_Color = Frag_Color * texture(Texture, Frag_UV.st);
                                                        }
                                                    """;


        private static Window _window;
        private static ImGuiWindowFlags _windowDockSpaceFlags = ImGuiWindowFlags.NoDocking | ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus;
        private static ImGuiConfigFlags _configFlags = ImGuiConfigFlags.DockingEnable | ImGuiConfigFlags.NavEnableKeyboard;
        
        
        private static bool _running = true;
        private static int _widthMainWindow = 1025;
        private static int _heightMainWindow = 575;
        
        
        private static IntPtr _context;
        
        
        public static ImGuiViewportPtr ViewportHub;
        
        
        // FONTS:
        public static uint FontTextureId;
        public static ImFontPtr FontLoaded16Solid;
        public static ImFontPtr FontLoaded10Solid;
        public static ImFontPtr FontLoaded45Bold;
        public static ImFontPtr FontLoaded30Bold;
        public static ImFontPtr FontLoaded16Light;
        public static ImFontPtr FontLoaded45Light;
        public static ImFontPtr FontLoaded30Light;
        
        
        
        // Config for ImGui rendering
        private static IntPtr _fontTexture;
        private static uint _vertexArray;
        private static uint _vertexBuffer;
        private static uint _indexBuffer;
        private static uint _shaderProgram;
        private static int _attribLocationTex;
        private static int _attribLocationProjMtx;
        private static int _attribLocationPosition;
        private static int _attribLocationUv;
        private static int _attribLocationColor;
        
        
        // IMGUIZNO SAMPLE: 
        private static float[] cameraProjection = new float[16]
        {
            2.0f / 800.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 2.0f / 600.0f, 0.0f, 0.0f,
            0.0f, 0.0f, -1.0f, 0.0f,
            -1.0f, -1.0f, 0.0f, 1.0f
        };
        private static float[] cameraView = new float[16]
        {
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
        };
        private static float[] identityMatrix = new float[16]
        {
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
        };
        private static float[] matrix = new float[16]
        {
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 2.0f, 1.0f
        };
        private static float[] matrixRotation = new float[3];
        private static float[] matrixScale = new float[3];
        private static float[] matrixTranslation = new float[3];
        private static Vector3F rotation;
        private static Vector3F scale;
        private static Vector3F translation;
        

        public static void Main(string[] args)
        {
            OnInit();
            OnStart();
            
            while (_running)
            {
                OnPollEvents();
                
                OnStartFrame();
                OnRenderFrame();
                OnEndFrame();
            }
            
            OnExit();
        }

        private static void OnInit()
        {
            OnInitGlfw();
            OnInitImGui();
        }

        private static void OnInitGlfw()
        {
            Logger.Info($"Initializing GLFW with OpenGL");
            if (!Glfw.Init())
            {
                ErrorCode errorCode = Glfw.GetError(out string description);
                 Logger.Exception($"GLFW init failed: ErrorCode: {errorCode} - Description: {description}");
            }

            Glfw.WindowHint(Hint.ContextVersionMajor, ContextVersionMajor);
            Glfw.WindowHint(Hint.ContextVersionMinor, ContextVersionMinor);
            Logger.Info($"Setting GLFW context version to {ContextVersionMajor}.{ContextVersionMinor}");
            
            Glfw.WindowHint(Hint.OpenglProfile, OpenglProfile);
            Logger.Info($"Setting GLFW OpenGL profile to {OpenglProfile}");
            
            Glfw.WindowHint(Hint.OpenglForwardCompatible, OpenglForwardCompatible);
            Logger.Info($"Setting GLFW OpenGL forward compatible to {OpenglForwardCompatible}");

            _window = Glfw.CreateWindow(_widthMainWindow, _heightMainWindow, TitleMainWindow, Monitor.None, Window.None);
            if (_window == Window.None)
            {
                ErrorCode errorCode = Glfw.GetError(out string description);
                Logger.Exception($"GLFW window creation failed: ErrorCode: {errorCode} - Description: {description}");
            }

            Glfw.MakeContextCurrent(_window);
            Logger.Info($"Created GLFW window with title '{TitleMainWindow}' and size {_widthMainWindow}x{_heightMainWindow}");
            
            Glfw.SwapInterval(VSync);
            Logger.Info($"V-Sync is active = {(VSync == 1 ? "Yes" : "No")}");
            
            Logger.Log("GLFW initialized successfully");
        }
        
        private static void OnInitImGui()
        {
            Logger.Info("Initializing ImGui...");
            
            Logger.Info("Creating ImGui context...");
            _context = ImGui.CreateContext();
            ImGui.SetCurrentContext(_context);
            Logger.Info("ImGui context created successfully");

            Logger.Info("Setting ImGui configuration flags...");
            ImGuiIoPtr io = ImGui.GetIo();
            io.ConfigFlags |= _configFlags;
            Logger.Info($"ImGui configuration flags set: {_configFlags}");
            
            
            ImNodes.CreateContext();
            ImPlot.CreateContext();
            ImGuizMo.SetImGuiContext(_context);
            ImGui.SetCurrentContext(_context);

            LoadFonts();

            ConfigDockSpace();

            SetStyle();
            
            SetupRenderer();

            SetPerFrameImGuiData(FrameRate);
            
            ImGui.NewFrame();
            Logger.Info("ImGui new frame started");
            
            Logger.Info("ImGui initialized successfully");
        }

        private static void LoadFonts()
        {
            // REBUILD ATLAS
            ImFontAtlasPtr fonts = ImGui.GetIo().Fonts;
            
            float fontSize = 14;
            float fontSizeIcon = 13.5f;

            string fontFileSolid = AssetManager.Find("Hub_JetBrainsMono-Bold.ttf");
            FontLoaded16Solid = fonts.AddFontFromFileTtf(fontFileSolid, fontSize);
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

            string fontFileSolid10 = AssetManager.Find("Hub_JetBrainsMono-Bold.ttf");
            FontLoaded10Solid = fonts.AddFontFromFileTtf(fontFileSolid10, 12);
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

            string fontFileSolid45 = AssetManager.Find("Hub_JetBrainsMono-Bold.ttf");
            FontLoaded45Bold = fonts.AddFontFromFileTtf(fontFileSolid45, 40);
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

            string fontFileSolid30 = AssetManager.Find("Hub_JetBrainsMono-Bold.ttf");
            FontLoaded30Bold = fonts.AddFontFromFileTtf(fontFileSolid30, 28);
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

            string fontAwesomeLight = AssetManager.Find("Hub_JetBrainsMonoNL-Regular.ttf");
            FontLoaded16Light = fonts.AddFontFromFileTtf(fontAwesomeLight, fontSize);
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
            FontTextureId = LoadTexture(pixelData, width, height);
            fonts.TexId = (IntPtr) FontTextureId;
            fonts.ClearTexData();
        }
        
        public static uint LoadTexture(IntPtr pixelData, int width, int height, PixelFormat format = PixelFormat.Rgba, PixelInternalFormat internalFormat = PixelInternalFormat.Rgba)
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

        private static void ConfigDockSpace()
        {
            ViewportHub = ImGui.GetMainViewport();
            ImGui.SetNextWindowPos(ViewportHub.WorkPos);
            ImGui.SetNextWindowSize(ViewportHub.WorkSize);
            ImGui.SetNextWindowViewport(ViewportHub.Id);
        }

        private static void SetStyle()
        {
            Logger.Info("Setting ImGui style...");
            ImGui.StyleColorsDark();
            Logger.Info("ImGui style set to dark");
        }


        private static void SetupRenderer()
        {
            _vertexArray = Gl.GenVertexArray();
            Gl.GlBindVertexArray(_vertexArray);

            _vertexBuffer = Gl.GenBuffer();
            _indexBuffer = Gl.GenBuffer();

            uint vertexShader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(vertexShader, VertexShaderSource);
            Gl.GlCompileShader(vertexShader);
            CheckShaderCompileStatus(vertexShader);

            uint fragmentShader = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(fragmentShader, FragmentShaderSource);
            Gl.GlCompileShader(fragmentShader);
            CheckShaderCompileStatus(fragmentShader);

            _shaderProgram = Gl.GlCreateProgram();
            Gl.GlAttachShader(_shaderProgram, vertexShader);
            Gl.GlAttachShader(_shaderProgram, fragmentShader);
            Gl.GlLinkProgram(_shaderProgram);
            CheckProgramLinkStatus(_shaderProgram);

            Gl.GlDetachShader(_shaderProgram, vertexShader);
            Gl.GlDetachShader(_shaderProgram, fragmentShader);
            Gl.GlDeleteShader(vertexShader);
            Gl.GlDeleteShader(fragmentShader);

            _attribLocationTex = Gl.GlGetUniformLocation(_shaderProgram, "Texture");
            _attribLocationProjMtx = Gl.GlGetUniformLocation(_shaderProgram, "projection_matrix");
            _attribLocationPosition = 0;
            _attribLocationUv = 1;
            _attribLocationColor = 2;

            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, _vertexBuffer);
            int stride = Marshal.SizeOf<ImDrawVert>();
            Gl.GlEnableVertexAttribArray((uint)_attribLocationPosition);
            Gl.GlVertexAttribPointer((uint)_attribLocationPosition, 2, VertexAttribPointerType.Float, false, stride, (IntPtr)0);
            Gl.GlEnableVertexAttribArray((uint)_attribLocationUv);
            Gl.GlVertexAttribPointer((uint)_attribLocationUv, 2, VertexAttribPointerType.Float, false, stride, (IntPtr)8);
            Gl.GlEnableVertexAttribArray((uint)_attribLocationColor);
            Gl.GlVertexAttribPointer((uint)_attribLocationColor, 4, VertexAttribPointerType.UnsignedByte, true, stride, (IntPtr)16);

            CreateFontTexture();
        }

        private static void CreateFontTexture()
        {
            ImGuiIoPtr io = ImGui.GetIo();
            io.Fonts.GetTexDataAsRgba32(out IntPtr pixels, out int width, out int height, out _);

            uint fontTex = Gl.GenTexture();
            Gl.GlBindTexture(TextureTarget.Texture2D, fontTex);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixels);

            io.Fonts.SetTexId((IntPtr)fontTex);
            io.Fonts.ClearTexData();
            _fontTexture = (IntPtr)fontTex;
        }
        
        private static void CheckShaderCompileStatus(uint shader)
        {
            if (!Gl.GetShaderCompileStatus(shader))
            {
                 Logger.Exception($"Shader compilation failed: {Gl.GetShaderInfoLog(shader)}");
            }
        }

        private static void CheckProgramLinkStatus(uint program)
        {
            if (!Gl.GetProgramLinkStatus(program))
            {
                 Logger.Exception($"Program linking failed: {Gl.GetProgramInfoLog(program)}");
            }
        }

        
        private static void SetPerFrameImGuiData(float deltaSeconds)
        {
            ImGuiIoPtr io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(_widthMainWindow, _heightMainWindow);
            io.DisplayFramebufferScale = new Vector2F(1f, 1f);
            io.DeltaTime = deltaSeconds;
        }
        
        private static void OnStart()
        {
           OnStartOpengl();
        }

        private static void OnStartOpengl()
        {
            Gl.GlClearColor(RedClearColor, GreenClearColor, BlueClearColor, AlphaClearColor);
        }


        public static void OnPollEvents()
        {
            OnPollEventsGlfw();
            OnPollEventsImGui();
        }
        
        private static void OnPollEventsGlfw()
        {
            Glfw.PollEvents();
            if (Glfw.WindowShouldClose(_window))
            {
                _running = false;
            }
        }
        
        private static void OnPollEventsImGui()
        {
            ImGuiIoPtr io = ImGui.GetIo();

            io.MouseDown[0] = Glfw.GetMouseButton(_window, MouseButton.Left) == InputState.Press;
            io.MouseDown[1] = Glfw.GetMouseButton(_window, MouseButton.Right) == InputState.Press;
            io.MouseDown[2] = Glfw.GetMouseButton(_window, MouseButton.Middle) == InputState.Press;

            Glfw.GetCursorPosition(_window, out double mouseX, out double mouseY);
            io.MousePos = new Vector2F((float)mouseX, (float)mouseY);
        }


        public static void OnStartFrame()
        {
            Gl.GlClear(ClearBufferMask.ColorBufferBit); 
            
            Glfw.GetWindowSize(_window, out int w, out int h);
            if (w != _widthMainWindow || h != _heightMainWindow)
            {
                _widthMainWindow = w;
                _heightMainWindow = h;
                SetPerFrameImGuiData(FrameRate);
            }

            ImGui.NewFrame();

            ImGui.SetNextWindowPos(ViewportHub.WorkPos);
            ImGui.SetNextWindowSize(ViewportHub.Size);
            ImGui.Begin(DockSpaceTitle, _windowDockSpaceFlags);

            Vector2F dockSize = ViewportHub.Size - new Vector2F(5, 85);
            uint dockSpaceId = ImGui.GetId(DockSpaceId);
            ImGui.DockSpace(dockSpaceId, dockSize);
        }

        private static void OnRenderFrame()
        {
            ImGui.ShowDemoWindow();
            ImPlot.ShowDemoWindow();
            ShowDemoImGuizMo();
            ShowDemoImNode();
            ShowDemoIcon();
        }

        private static void ShowDemoIcon()
        {
            if (ImGui.Begin("Icon Demo"))
            {
                ImGui.Separator();
                ImGui.Text("Font Awesome 5");
                ImGui.Text($" {FontAwesome5.Bug} {FontAwesome5.Bullhorn} {FontAwesome5.Bullseye} {FontAwesome5.Calendar}");
            }

            ImGui.End();
        }

        private static void ShowDemoImNode()
        {
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
        }

        private static void ShowDemoImGuizMo()
        {
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4F(0.35f, 0.3f, 0.3f, 1.0f));

            bool isOpen = true;
            if (ImGui.Begin("Gizmo", ref isOpen))
            {
                ImGuizMo.Enable(true);
                ImGuizMo.SetDrawList();

                ImGui.Text("ImGuizmo is a small library that allows you to manipulate 3D objects in the scene.");
                ImGui.Text("You can use it to move, rotate and scale objects in the scene.");

                ImGuizMo.DecomposeMatrixToComponents(ref matrix, ref matrixTranslation, ref matrixRotation, ref matrixScale);

                translation.X = matrixTranslation[0];
                translation.Y = matrixTranslation[1];
                translation.Z = matrixTranslation[2];

                rotation.X = matrixRotation[0];
                rotation.Y = matrixRotation[1];
                rotation.Z = matrixRotation[2];

                scale.X = matrixScale[0];
                scale.Y = matrixScale[1];
                scale.Z = matrixScale[2];

                ImGui.SliderFloat3("Translation", ref translation, -10.0f, 10.0f);
                ImGui.SliderFloat3("Rotation", ref rotation, -180.0f, 180.0f);
                ImGui.SliderFloat3("Scale", ref scale, 0.1f, 10.0f);

                matrixTranslation[0] = translation.X;
                matrixTranslation[1] = translation.Y;
                matrixTranslation[2] = translation.Z;

                matrixRotation[0] = rotation.X;
                matrixRotation[1] = rotation.Y;
                matrixRotation[2] = rotation.Z;

                matrixScale[0] = scale.X;
                matrixScale[1] = scale.Y;
                matrixScale[2] = scale.Z;

                ImGuizMo.RecomposeMatrixFromComponents(ref matrixTranslation, ref matrixRotation, ref matrixScale, ref matrix);

                ImGui.Text($"Translation: {translation}");
                ImGui.Text($"Rotation: {rotation}");
                ImGui.Text($"Scale: {scale}");

                ImGuizMo.SetOrthographic(false);
                ImGuizMo.SetRect(0, 0, ImGui.GetIo().DisplaySize.X, ImGui.GetIo().DisplaySize.Y);

                ImGuizMo.DrawGrid(ref cameraView, ref cameraProjection, ref identityMatrix, 10.0f);
                ImGuizMo.Manipulate(cameraView, cameraProjection, Operation.Translate | Operation.Rotate | Operation.Scale, Mode.Local, matrix);

                ImGuizMo.ViewManipulate(ref cameraView, 2.5f, new Vector2F(ImGui.GetWindowPos().X, ImGui.GetWindowPos().Y), new Vector2F(ImGui.GetWindowWidth(), ImGui.GetWindowHeight()), 0x10101010);
            }


            ImGui.End();
            ImGui.PopStyleColor();
        }

        private static void OnEndFrame()
        {
            ImGui.End();

            ImGui.Render();
            RenderImDrawData(ImGui.GetDrawData());
            Glfw.SwapBuffers(_window);
        }
        
        private static void RenderImDrawData(ImDrawData drawData)
        {
            int fbWidth = (int)(drawData.DisplaySize.X * drawData.FramebufferScale.X);
            int fbHeight = (int)(drawData.DisplaySize.Y * drawData.FramebufferScale.Y);
            if (fbWidth == 0 || fbHeight == 0) return;

            Gl.GlViewport(0, 0, fbWidth, fbHeight);
            Gl.GlEnable(EnableCap.Blend);
            Gl.GlBlendEquation(BlendEquationMode.FuncAdd);
            Gl.GlBlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            Gl.GlDisable(EnableCap.CullFace);
            Gl.GlDisable(EnableCap.DepthTest);
            Gl.GlEnable(EnableCap.ScissorTest);

            ImGuiIoPtr io = ImGui.GetIo();
            float l = drawData.DisplayPos.X;
            float r = drawData.DisplayPos.X + drawData.DisplaySize.X;
            float t = drawData.DisplayPos.Y;
            float b = drawData.DisplayPos.Y + drawData.DisplaySize.Y;

            Matrix4x4 orthoProjection = new Matrix4x4(
                2.0f / (r - l), 0, 0, 0,
                0, -2.0f / (b - t), 0, 0,
                0, 0, -1.0f, 0,
                (r + l) / (l - r), (t + b) / (b - t), 0, 1.0f
            );

            Gl.GlUseProgram(_shaderProgram);
            Gl.GlUniform1I(_attribLocationTex, 0);
            Gl.GlUniformMatrix4Fv(_attribLocationProjMtx, 1, false, MatrixToArray(orthoProjection));
            Gl.GlBindVertexArray(_vertexArray);

            for (int n = 0; n < drawData.CmdListsCount; n++)
            {
                ImDrawListPtr cmdList = drawData.CmdListsRange[n];
                int vertexSize = cmdList.VtxBuffer.Size * Marshal.SizeOf<ImDrawVert>();
                int indexSize = cmdList.IdxBuffer.Size * sizeof(ushort);

                Gl.GlBindBuffer(BufferTarget.ArrayBuffer, _vertexBuffer);
                Gl.GlBufferData(BufferTarget.ArrayBuffer, vertexSize, cmdList.VtxBuffer.Data, BufferUsageHint.StreamDraw);

                Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, _indexBuffer);
                Gl.GlBufferData(BufferTarget.ElementArrayBuffer, indexSize, cmdList.IdxBuffer.Data, BufferUsageHint.StreamDraw);

                int idxOffset = 0;
                for (int cmdi = 0; cmdi < cmdList.CmdBuffer.Size; cmdi++)
                {
                    ImDrawCmd pcmd = cmdList.CmdBuffer[cmdi];

                    if (pcmd.UserCallback != IntPtr.Zero)
                        throw new NotImplementedException("User callbacks not implemented");

                    Gl.GlBindTexture(TextureTarget.Texture2D, (uint)pcmd.TextureId);
                    Gl.GlScissor(
                        (int)pcmd.ClipRect.X,
                        fbHeight - (int)pcmd.ClipRect.W,
                        (int)(pcmd.ClipRect.Z - pcmd.ClipRect.X),
                        (int)(pcmd.ClipRect.W - pcmd.ClipRect.Y));

                    Gl.GlDrawElementsBaseVertex(BeginMode.Triangles, (int)pcmd.ElemCount,
                        DrawElementsType.UnsignedShort, (IntPtr)(idxOffset * sizeof(ushort)), 0);

                    idxOffset += (int)pcmd.ElemCount;
                }
            }

            Gl.GlDisable(EnableCap.ScissorTest);
            Gl.GlBindVertexArray(0);
            Gl.GlBindTexture(TextureTarget.Texture2D, 0);
            Gl.GlDisable(EnableCap.Blend);
        }

        private static float[] MatrixToArray(Matrix4x4 m) => new[]
        {
            m.M11, m.M12, m.M13, m.M14,
            m.M21, m.M22, m.M23, m.M24,
            m.M31, m.M32, m.M33, m.M34,
            m.M41, m.M42, m.M43, m.M44
        };
        
        private static void OnExit()
        {
            Logger.Info("Exiting application...");
            OnExitImGui();
            OnExitGlfw();
            Logger.Info("End exiting application");
        }

        private static void OnExitImGui()
        {
            Logger.Info("Shutting down ImGui...");
            
            if (_vertexBuffer != 0)
            {
                Gl.DeleteBuffer(_vertexBuffer);
                Logger.Info("Vertex buffer deleted");
            }

            if (_indexBuffer != 0)
            {
                Gl.DeleteBuffer(_indexBuffer);
                Logger.Info("Index buffer deleted");
            }

            if (_vertexArray != 0)
            {
                Gl.DeleteVertexArray(_vertexArray);
                Logger.Info("Vertex array deleted");
            }

            if (_shaderProgram != 0)
            {
                Gl.GlDeleteProgram(_shaderProgram);
                Logger.Info("Shader program deleted");
            }

            if (_fontTexture != IntPtr.Zero)
            {
                Gl.DeleteTexture((uint)_fontTexture);
                Logger.Info("Font texture deleted");
            }


            Logger.Info("ImGui terminated successfully");
        }

        private static void OnExitGlfw()
        {
            Logger.Info("Shutting down GLFW...");
            
            Glfw.Terminate();
            
            if(Glfw.GetError(out string errorDescription) != ErrorCode.None)
            {
                Logger.Exception($"GLFW error during shutdown: {errorDescription}");
            }
            
            Logger.Info("GLFW terminated successfully");
        }
    }
}
