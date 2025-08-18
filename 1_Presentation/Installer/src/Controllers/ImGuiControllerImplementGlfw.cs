using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Extension.Graphic.Glfw;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Alis.Extension.Graphic.Ui.Extras.Node;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Installer.Controllers
{
    /// <summary>
    /// The im gui controller implement glfw class
    /// </summary>
    /// <seealso cref="IControllerUi"/>
    public class ImGuiControllerImplementGlfw(string titleMainWindow = "ImGui Window", int width = 800, int height = 600, int windowsDefault = 0, bool modeDebug = true) : IControllerUi
    {
        /// <summary>
        /// The dock space title
        /// </summary>
        private const string DockSpaceTitle = "DockSpace Demo";
        /// <summary>
        /// The dock space id
        /// </summary>
        private const string DockSpaceId = "MyDockSpace";

        /// <summary>
        /// The frame rate
        /// </summary>
        private const float FrameRate = 1.0f / 60.0f;
        
        /// <summary>
        /// The is open editor style window
        /// </summary>
        private bool IsOpenEditorStyleWindow = false;

        /// <summary>
        /// The menu bar
        /// </summary>
        private const ImGuiWindowFlags _windowDockSpaceFlags = ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize |
                                                               ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus |
                                                               ImGuiWindowFlags.MenuBar;

        /// <summary>
        /// The nav enable keyboard
        /// </summary>
        private const ImGuiConfigFlags _configFlags = ImGuiConfigFlags.DockingEnable | ImGuiConfigFlags.NavEnableKeyboard;


        /// <summary>
        /// The context
        /// </summary>
        private IntPtr _context;


        /// <summary>
        /// The viewport
        /// </summary>
        public ImGuiViewportPtr Viewport;


        // Variables globales para el estado del ratón y la rueda
        /// <summary>
        /// The mouse pressed
        /// </summary>
        public readonly bool[] _mousePressed = new bool[3];
        /// <summary>
        /// The mouse just pressed
        /// </summary>
        public readonly bool[] _mouseJustPressed = new bool[3];


        // FONTS:
        /// <summary>
        /// The font texture id
        /// </summary>
        public uint FontTextureId;
        /// <summary>
        /// The font loaded 16 solid
        /// </summary>
        public ImFontPtr FontLoaded16Solid;
        /// <summary>
        /// The font loaded 10 solid
        /// </summary>
        public ImFontPtr FontLoaded10Solid;
        /// <summary>
        /// The font loaded 45 bold
        /// </summary>
        public ImFontPtr FontLoaded45Bold;
        /// <summary>
        /// The font loaded 30 bold
        /// </summary>
        public ImFontPtr FontLoaded30Bold;
        /// <summary>
        /// The font loaded 16 light
        /// </summary>
        public ImFontPtr FontLoaded16Light;



        // Config for ImGui rendering
        /// <summary>
        /// The font texture
        /// </summary>
        public IntPtr _fontTexture;
        /// <summary>
        /// The vertex array
        /// </summary>
        public uint _vertexArray;
        /// <summary>
        /// The vertex buffer
        /// </summary>
        public uint _vertexBuffer;
        /// <summary>
        /// The index buffer
        /// </summary>
        public uint _indexBuffer;
        /// <summary>
        /// The shader program
        /// </summary>
        public uint _shaderProgram;
        /// <summary>
        /// The attrib location tex
        /// </summary>
        public int _attribLocationTex;
        /// <summary>
        /// The attrib location proj mtx
        /// </summary>
        public int _attribLocationProjMtx;
        /// <summary>
        /// The attrib location position
        /// </summary>
        public int _attribLocationPosition;
        /// <summary>
        /// The attrib location uv
        /// </summary>
        public int _attribLocationUv;
        /// <summary>
        /// The attrib location color
        /// </summary>
        public int _attribLocationColor;



        /// <summary>
        /// The vertex shader source
        /// </summary>
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

        /// <summary>
        /// The fragment shader source
        /// </summary>
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



        // IMGUIZNO SAMPLE: 
        /// <summary>
        /// The camera projection
        /// </summary>
        public float[] cameraProjection = new float[16]
        {
            2.0f / 800.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 2.0f / 600.0f, 0.0f, 0.0f,
            0.0f, 0.0f, -1.0f, 0.0f,
            -1.0f, -1.0f, 0.0f, 1.0f
        };

        /// <summary>
        /// The camera view
        /// </summary>
        public float[] cameraView = new float[16]
        {
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
        };

        /// <summary>
        /// The identity matrix
        /// </summary>
        public float[] identityMatrix = new float[16]
        {
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
        };

        /// <summary>
        /// The matrix
        /// </summary>
        public float[] matrix = new float[16]
        {
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 2.0f, 1.0f
        };

        /// <summary>
        /// The matrix rotation
        /// </summary>
        public float[] matrixRotation = new float[3];
        /// <summary>
        /// The matrix scale
        /// </summary>
        public float[] matrixScale = new float[3];
        /// <summary>
        /// The matrix translation
        /// </summary>
        public float[] matrixTranslation = new float[3];
        /// <summary>
        /// The rotation
        /// </summary>
        public Vector3F rotation;
        /// <summary>
        /// The scale
        /// </summary>
        public Vector3F scale;
        /// <summary>
        /// The translation
        /// </summary>
        public Vector3F translation;
        
        
        // PREVIEW WINDOWS:
        /// <summary>
        /// The shader program
        /// </summary>
        private  uint shaderProgram;
        /// <summary>
        /// The vao
        /// </summary>
        private  uint vao;
        /// <summary>
        /// The vbo
        /// </summary>
        private  uint vbo;
        /// <summary>
        /// The preview texture
        /// </summary>
        private  uint _previewTexture;
        /// <summary>
        /// The preview height
        /// </summary>
        private  int _previewWidth = 512, _previewHeight = 512;


        /// <summary>
        /// The windows default
        /// </summary>
        private GlfwController _glfwController = new GlfwController(titleMainWindow, width, height, windowsDefault);
        /// <summary>
        /// The mode debug
        /// </summary>
        private bool _modeDebug = modeDebug;

        /// <summary>
        /// The dpi scale
        /// </summary>
        private float dpiScale;

        /// <summary>
        /// Gets or sets the value of the is running
        /// </summary>
        public bool IsRunning { get; set; } = true;

        /// <summary>
        /// Ons the init
        /// </summary>
        public void OnInit()
        {
            _glfwController.OnInit();

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
            
            
            InitializePreviewResources();
            
            // 1. Obtener el factor de escala del monitor principal
            Monitor monitor = Glfw.GetWindowMonitor(_glfwController._window);
            if (monitor == Monitor.None)
            {
                monitor = Glfw.GetPrimaryMonitor();
            }
            
            dpiScale = Math.Max(monitor.ContentScale.X, monitor.ContentScale.Y);

            

            Logger.Info("ImGui initialized successfully");
        }

        /// <summary>
        /// Initializes the preview resources
        /// </summary>
        private void InitializePreviewResources()
        {
            // Define the vertices for the triangle
            float[] vertices =
            {
                0.0f, 0.5f, 0.0f, // Top
                -0.5f, -0.5f, 0.0f, // Bottom Left
                0.5f, -0.5f, 0.0f // Bottom Right
            };

            // Create a vertex buffer object (VBO) and a vertex array object (VAO)
            vbo = Gl.GenBuffer();
            vao = Gl.GenVertexArray();

            // Bind the VAO and VBO
            Gl.GlBindVertexArray(vao);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);

            GCHandle handle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                Gl.GlBufferData(BufferTarget.ArrayBuffer, new IntPtr(vertices.Length * sizeof(float)), pointer, BufferUsageHint.StaticDraw);
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }

            _previewTexture = Gl.GenTexture();
            Gl.GlBindTexture(TextureTarget.Texture2D, _previewTexture);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, _previewWidth, _previewHeight, 0, PixelFormat.Rgba, PixelType.UnsignedByte, IntPtr.Zero);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);

            // Update vertex shader source code
            string vertexShaderSource = @"
                #version 330 core
                layout (location = 0) in vec3 aPos;
                uniform mat4 transform;
                void main()
                {
                    gl_Position = transform * vec4(aPos.x, aPos.y, aPos.z, 1.0);
                }
                ";

            string fragmentShaderSource = @"
                #version 330 core
                out vec4 FragColor;
                void main()
                {
                    FragColor = vec4(1.0f, 1.0f, 1.0f, 1.0f); // white color
                }
            ";

            uint vertexShader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(vertexShader, vertexShaderSource);
            Gl.GlCompileShader(vertexShader);

            uint fragmentShader = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(fragmentShader, fragmentShaderSource);
            Gl.GlCompileShader(fragmentShader);

            shaderProgram = Gl.GlCreateProgram();
            Gl.GlAttachShader(shaderProgram, vertexShader);
            Gl.GlAttachShader(shaderProgram, fragmentShader);
            Gl.GlLinkProgram(shaderProgram);

            // Bind the VAO and shader program
            Gl.GlBindVertexArray(vao);
            Gl.GlUseProgram(shaderProgram);

            // Enable the vertex attribute array
            Gl.EnableVertexAttribArray(0);
            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), IntPtr.Zero);

            // Print the OpenGL version
            Logger.Log(@$"OpenGL VERSION {Gl.GlGetString(StringName.Version)}");

            // Print the OpenGL vendor
            Logger.Log(@$"OpenGL VENDOR {Gl.GlGetString(StringName.Vendor)}");

            // Print the OpenGL renderer
            Logger.Log(@$"OpenGL RENDERER {Gl.GlGetString(StringName.Renderer)}");

            // Print the OpenGL shading language version
            Logger.Log(@$"OpenGL SHADING LANGUAGE VERSION {Gl.GlGetString(StringName.ShadingLanguageVersion)}");
        }
        
        /// <summary>
        /// Loads the fonts
        /// </summary>
        public void LoadFonts()
        {
            // REBUILD ATLAS
            ImFontAtlasPtr fonts = ImGui.GetIo().Fonts;

            float fontSize = 14;
            float fontSizeIcon = 13.5f;

            string fontFileSolid = AssetManager.Find(JetBrains.NameSolid);
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

            string fontFileSolid10 = AssetManager.Find(JetBrains.NameSolid);
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

            string fontFileSolid45 = AssetManager.Find(JetBrains.NameSolid);
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

            string fontFileSolid30 = AssetManager.Find(JetBrains.NameSolid);
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

            string fontAwesomeLight = AssetManager.Find(JetBrains.NameRegular);
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

        /// <summary>
        /// Loads the texture using the specified pixel data
        /// </summary>
        /// <param name="pixelData">The pixel data</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="format">The format</param>
        /// <param name="internalFormat">The internal format</param>
        /// <returns>The texture id</returns>
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

        /// <summary>
        /// Configs the dock space
        /// </summary>
        public void ConfigDockSpace()
        {
            Viewport = ImGui.GetMainViewport();
            ImGui.SetNextWindowPos(Viewport.WorkPos);
            ImGui.SetNextWindowSize(Viewport.WorkSize);
            ImGui.SetNextWindowViewport(Viewport.Id);
        }

        /// <summary>
        /// Sets the style
        /// </summary>
        public void SetStyle()
        {
            Logger.Info("Setting ImGui style...");
            ImGui.StyleColorsDark();
            

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

            Logger.Info("ImGui style set to dark");
        }




        /// <summary>
        /// Setup the renderer
        /// </summary>
        public void SetupRenderer()
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
            Gl.GlEnableVertexAttribArray((uint) _attribLocationPosition);
            Gl.GlVertexAttribPointer((uint) _attribLocationPosition, 2, VertexAttribPointerType.Float, false, stride, (IntPtr) 0);
            Gl.GlEnableVertexAttribArray((uint) _attribLocationUv);
            Gl.GlVertexAttribPointer((uint) _attribLocationUv, 2, VertexAttribPointerType.Float, false, stride, (IntPtr) 8);
            Gl.GlEnableVertexAttribArray((uint) _attribLocationColor);
            Gl.GlVertexAttribPointer((uint) _attribLocationColor, 4, VertexAttribPointerType.UnsignedByte, true, stride, (IntPtr) 16);

            CreateFontTexture();
        }

        /// <summary>
        /// Creates the font texture
        /// </summary>
        public void CreateFontTexture()
        {
            ImGuiIoPtr io = ImGui.GetIo();
            io.Fonts.GetTexDataAsRgba32(out IntPtr pixels, out int width, out int height, out _);

            uint fontTex = Gl.GenTexture();
            Gl.GlBindTexture(TextureTarget.Texture2D, fontTex);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixels);

            io.Fonts.SetTexId((IntPtr) fontTex);
            io.Fonts.ClearTexData();
            _fontTexture = (IntPtr) fontTex;
        }

        /// <summary>
        /// Checks the shader compile status using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        public void CheckShaderCompileStatus(uint shader)
        {
            if (!Gl.GetShaderCompileStatus(shader))
            {
                Logger.Exception($"Shader compilation failed: {Gl.GetShaderInfoLog(shader)}");
            }
        }

        /// <summary>
        /// Checks the program link status using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        public void CheckProgramLinkStatus(uint program)
        {
            if (!Gl.GetProgramLinkStatus(program))
            {
                Logger.Exception($"Program linking failed: {Gl.GetProgramInfoLog(program)}");
            }
        }


        /// <summary>
        /// Sets the per frame im gui data using the specified delta seconds
        /// </summary>
        /// <param name="deltaSeconds">The delta seconds</param>
        public void SetPerFrameImGuiData(float deltaSeconds)
        {
            ImGuiIoPtr io = ImGui.GetIo();
            io.DeltaTime = deltaSeconds;
            io.DisplayFramebufferScale = new Vector2F(dpiScale, dpiScale);
            io.FontGlobalScale = dpiScale;
        }

        /// <summary>
        /// Ons the start
        /// </summary>
        public void OnStart()
        {
            _glfwController.OnStart();
        }

        /// <summary>
        /// Ons the poll events
        /// </summary>
        public void OnPollEvents()
        {
            _glfwController.OnPollEvents();

            if (_glfwController.CheckIfWindowShouldClose())
            {
                IsRunning = false;
            }

            ImGuiIoPtr io = ImGui.GetIo();

            // Actualiza la posición del mouse solo si la ventana está enfocada
            if (Glfw.GetWindowAttribute(_glfwController._window, WindowAttribute.Focused))
            {
                Glfw.GetCursorPosition(_glfwController._window, out double mouseX, out double mouseY);
                io.MousePos = new Vector2F((float)mouseX, (float)mouseY);
            }
            else
            {
                io.MousePos = new Vector2F(float.MinValue, float.MinValue);
            }

            // Actualiza el estado de los botones del mouse
            var mouseDown = io.MouseDown;
            mouseDown[0] = _mousePressed[0] || Glfw.GetMouseButton(_glfwController._window, MouseButton.Left) == InputState.Press;
            mouseDown[1] = _mousePressed[1] || Glfw.GetMouseButton(_glfwController._window, MouseButton.Right) == InputState.Press;
            mouseDown[2] = _mousePressed[2] || Glfw.GetMouseButton(_glfwController._window, MouseButton.Middle) == InputState.Press;
            _mousePressed[0] = _mousePressed[1] = _mousePressed[2] = false;
            io.MouseDown = mouseDown;

            MapKeys(io);
        }
        
        /// <summary>
        /// Processes the key event using the specified io
        /// </summary>
        /// <param name="io">The io</param>
        /// <param name="imguikey">The imguikey</param>
        /// <param name="key">The key</param>
        public void ProcessKeyEvent(ImGuiIoPtr io, ImGuiKey imguikey, Keys key)
        {
            io.KeyMap[(int)imguikey] = Glfw.GetKey(_glfwController._window, key) == InputState.Press ? 1 : 0;
            io.AddKeyEvent(imguikey, Glfw.GetKey(_glfwController._window, key) == InputState.Press);
        }

        /// <summary>
        /// Maps the keys using the specified io
        /// </summary>
        /// <param name="io">The io</param>
        public void MapKeys(ImGuiIoPtr io)
        {
            ProcessKeyEvent(io, ImGuiKey.Tab, Keys.Tab);
            ProcessKeyEvent(io, ImGuiKey.LeftCtrl, Keys.LeftControl);
            ProcessKeyEvent(io, ImGuiKey.RightCtrl, Keys.RightControl);
            ProcessKeyEvent(io, ImGuiKey.LeftArrow, Keys.Left);
            ProcessKeyEvent(io, ImGuiKey.RightArrow, Keys.Right);
            ProcessKeyEvent(io, ImGuiKey.UpArrow, Keys.Up);
            ProcessKeyEvent(io, ImGuiKey.DownArrow, Keys.Down);
            ProcessKeyEvent(io, ImGuiKey.PageUp, Keys.PageUp);
            ProcessKeyEvent(io, ImGuiKey.PageDown, Keys.PageDown);
            ProcessKeyEvent(io, ImGuiKey.Home, Keys.Home);
            ProcessKeyEvent(io, ImGuiKey.End, Keys.End);
            ProcessKeyEvent(io, ImGuiKey.Insert, Keys.Insert);
            ProcessKeyEvent(io, ImGuiKey.Delete, Keys.Delete);
            ProcessKeyEvent(io, ImGuiKey.Backspace, Keys.Backspace);
            ProcessKeyEvent(io, ImGuiKey.Space, Keys.Space);
            ProcessKeyEvent(io, ImGuiKey.Enter, Keys.Enter);
            ProcessKeyEvent(io, ImGuiKey.Escape, Keys.Escape);
            ProcessKeyEvent(io, ImGuiKey.KeypadEnter, Keys.Enter);
            ProcessKeyEvent(io, ImGuiKey.A, Keys.A);
            ProcessKeyEvent(io, ImGuiKey.C, Keys.C);
            ProcessKeyEvent(io, ImGuiKey.V, Keys.V);
            ProcessKeyEvent(io, ImGuiKey.X, Keys.X);
            ProcessKeyEvent(io, ImGuiKey.Y, Keys.Y);
            ProcessKeyEvent(io, ImGuiKey.Z, Keys.Z);
        }


        /// <summary>
        /// Ons the start frame
        /// </summary>
        public void OnStartFrame()
        {
            _glfwController.OnStartFrame();
        
            // Usa el tamaño real de la ventana GLFW
            ImGui.SetNextWindowPos(new Vector2F(0, 0));
            ImGui.SetNextWindowSize(new Vector2F(_glfwController._widthMainWindow, _glfwController._heightMainWindow));
            ImGui.SetNextWindowViewport(Viewport.Id);
        
            Glfw.GetWindowSize(_glfwController._window, out int w, out int h);
            if (w != _glfwController._widthMainWindow || h != _glfwController._heightMainWindow)
            {
                _glfwController._widthMainWindow = w;
                _glfwController._heightMainWindow = h;
                SetPerFrameImGuiData(FrameRate);
            }
        
            ImGui.NewFrame();
            ImGuizMo.BeginFrame();
        
            ImGui.SetNextWindowPos(Viewport.WorkPos);
            ImGui.SetNextWindowSize(Viewport.Size);
            ImGui.Begin(DockSpaceTitle, _windowDockSpaceFlags);
        
            #if OSX
                Vector2F dockSize = Viewport.Size - new Vector2F(5, 60);
            #else
                Vector2F dockSize = Viewport.Size - new Vector2F(5, 180);
            #endif
            uint dockSpaceId = ImGui.GetId(DockSpaceId);
            ImGui.DockSpace(dockSpaceId, dockSize);
        }

        /// <summary>
        /// Ons the render frame
        /// </summary>
        public void OnRenderFrame()
        {
            _glfwController.OnRenderFrame();
            
            var io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(_glfwController._widthMainWindow, _glfwController._heightMainWindow);
            io.DisplayFramebufferScale = new Vector2F(1f, 1f);

            if (_modeDebug)
            {
                ImGui.ShowDemoWindow();
                ImPlot.ShowDemoWindow();
                ShowDemoImGuizMo();
                ShowDemoImNode();
                ShowDemoIcon();
            
                RenderTriangleDirectly();
                ShowPreviewImage();
            }

            if (IsOpenEditorStyleWindow)
            {
                ref ImGuiStyle style = ref ImGui.GetStyle();
                ImGui.Begin($"{FontAwesome5.Cogs} Style Editor", ref IsOpenEditorStyleWindow, ImGuiWindowFlags.AlwaysAutoResize);
                ImGui.ShowStyleEditor(style);
                ImGui.End();
            }
        }
        
         /// <summary>
         /// Renders the triangle directly
         /// </summary>
         private  void RenderTriangleDirectly()
        {
            // Configura el viewport para la ventana principal
            Gl.GlViewport(0, 0, _previewWidth, _previewHeight);

            // Limpia el color de fondo
            Gl.GlClearColor(0.8f, 0.1f, 0.1f, 1.0f); // Fondo rojo
            Gl.GlClear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Usa el programa de shaders y el VAO
            Gl.GlUseProgram(shaderProgram);
            Gl.GlBindVertexArray(vao);

            // Aplica la transformación al triángulo
            Matrix4X4 transform = Matrix4X4.CreateRotationZ((float) DateTime.Now.TimeOfDay.TotalSeconds);
            int transformLocation = Gl.GlGetUniformLocation(shaderProgram, "transform");
            Gl.UniformMatrix4Fv(transformLocation, transform);

            // Dibuja el triángulo
            Gl.GlDrawArrays(PrimitiveType.Triangles, 0, 3);

            // Desactiva el VAO y el programa de shaders
            Gl.GlBindVertexArray(0);
            Gl.GlUseProgram(0);
        }

        /// <summary>
        /// Shows the preview image
        /// </summary>
        private  void ShowPreviewImage()
        {

            // Copia el framebuffer a una textura para ImGui
            byte[] pixelBuffer = new byte[_previewWidth * _previewHeight * 4];

            GCHandle handle2 = GCHandle.Alloc(pixelBuffer, GCHandleType.Pinned);
            try
            {
                Gl.GlReadPixels(0, 0, _previewWidth, _previewHeight, PixelFormat.Rgba, PixelType.UnsignedByte, handle2.AddrOfPinnedObject());
            }
            finally
            {
                handle2.Free();
            }

            Gl.GlBindTexture(TextureTarget.Texture2D, _previewTexture);
            GCHandle handle = GCHandle.Alloc(pixelBuffer, GCHandleType.Pinned);
            try
            {
                Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, _previewWidth, _previewHeight, 0, PixelFormat.Rgba, PixelType.UnsignedByte, handle.AddrOfPinnedObject());
            }
            finally
            {
                handle.Free();
            }

            Gl.GlBindTexture(TextureTarget.Texture2D, 0);

            ImGui.Begin("OpenGL Preview");
            ImGui.Image((IntPtr) _previewTexture, ImGui.GetContentRegionAvail());
            ImGui.End();
        }

        /// <summary>
        /// Shows the demo icon
        /// </summary>
        private void ShowDemoIcon()
        {
            if (ImGui.Begin("Icon Demo"))
            {
                ImGui.Separator();
                ImGui.Text("Font Awesome 5");
                ImGui.Text($" {FontAwesome5.Bug} {FontAwesome5.Bullhorn} {FontAwesome5.Bullseye} {FontAwesome5.Calendar}");
            }

            ImGui.End();
        }

        /// <summary>
        /// Shows the demo im node
        /// </summary>
        private void ShowDemoImNode()
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

        /// <summary>
        /// Shows the demo im guiz mo
        /// </summary>
        private void ShowDemoImGuizMo()
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


        /// <summary>
        /// Ons the end frame
        /// </summary>
        public void OnEndFrame()
        {
            ImGui.End();

            ImGui.Render();

            ImGuiIoPtr io = ImGui.GetIo();
            Gl.GlViewport(0, 0, (int) io.DisplaySize.X, (int) io.DisplaySize.Y);
            Gl.GlClear(ClearBufferMask.ColorBufferBit);

            RenderImDrawData(ImGui.GetDrawData());

            _glfwController.OnEndFrame();
        }

        /// <summary>
        /// Ons the exit
        /// </summary>
        public void OnExit()
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
                Gl.DeleteTexture((uint) _fontTexture);
                Logger.Info("Font texture deleted");
            }


            Logger.Info("ImGui terminated successfully");

            _glfwController.OnExit();
        }


        /// <summary>
        /// Renders the im draw data using the specified draw data
        /// </summary>
        /// <param name="drawData">The draw data</param>
        /// <exception cref="NotImplementedException">User callbacks not implemented</exception>
        private void RenderImDrawData(ImDrawData drawData)
        {
            int fbWidth = (int) (drawData.DisplaySize.X * drawData.FramebufferScale.X);
            int fbHeight = (int) (drawData.DisplaySize.Y * drawData.FramebufferScale.Y);
            if (fbWidth == 0 || fbHeight == 0) return;

            Gl.GlViewport(0, 0, fbWidth, fbHeight);
            Gl.GlEnable(EnableCap.Blend);
            Gl.GlBlendEquation(BlendEquationMode.FuncAdd);
            Gl.GlBlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            Gl.GlDisable(EnableCap.CullFace);
            Gl.GlDisable(EnableCap.DepthTest);
            Gl.GlEnable(EnableCap.ScissorTest);
            
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
                Gl.GlBufferData(BufferTarget.ArrayBuffer, new IntPtr(vertexSize), cmdList.VtxBuffer.Data, BufferUsageHint.StreamDraw);

                Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, _indexBuffer);
                Gl.GlBufferData(BufferTarget.ElementArrayBuffer, new IntPtr(indexSize), cmdList.IdxBuffer.Data, BufferUsageHint.StreamDraw);

                int idxOffset = 0;
                for (int cmdi = 0; cmdi < cmdList.CmdBuffer.Size; cmdi++)
                {
                    ImDrawCmd pcmd = cmdList.CmdBuffer[cmdi];

                    if (pcmd.UserCallback != IntPtr.Zero)
                        throw new NotImplementedException("User callbacks not implemented");

                    Gl.GlBindTexture(TextureTarget.Texture2D, (uint) pcmd.TextureId);
                    Gl.GlScissor(
                        (int) pcmd.ClipRect.X,
                        fbHeight - (int) pcmd.ClipRect.W,
                        (int) (pcmd.ClipRect.Z - pcmd.ClipRect.X),
                        (int) (pcmd.ClipRect.W - pcmd.ClipRect.Y));

                    Gl.GlDrawElementsBaseVertex(BeginMode.Triangles, (int) pcmd.ElemCount,
                        DrawElementsType.UnsignedShort, (IntPtr) (idxOffset * sizeof(ushort)), 0);

                    idxOffset += (int) pcmd.ElemCount;
                }
            }

            Gl.GlDisable(EnableCap.ScissorTest);
            Gl.GlBindVertexArray(0);
            Gl.GlBindTexture(TextureTarget.Texture2D, 0);
            Gl.GlDisable(EnableCap.Blend);
        }

        /// <summary>
        /// Matrixes the to array using the specified m
        /// </summary>
        /// <param name="m">The </param>
        /// <returns>The float array</returns>
        private float[] MatrixToArray(Matrix4x4 m) => new[]
        {
            m.M11, m.M12, m.M13, m.M14,
            m.M21, m.M22, m.M23, m.M24,
            m.M31, m.M32, m.M33, m.M34,
            m.M41, m.M42, m.M43, m.M44
        };

        /// <summary>
        /// Opens the editor style window
        /// </summary>
        public void OpenEditorStyleWindow()
        {
            IsOpenEditorStyleWindow = true;
        }
    }
}

