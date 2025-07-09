using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.GlfwLib;
using Alis.Core.Graphic.GlfwLib.Enums;
using Alis.Core.Graphic.GlfwLib.Structs;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Exception = System.Exception;

namespace Alis.Extension.Graphic.Ui.Controllers
{
    public class ImGuiControllerOfGlfw : IDisposable
    {
        private readonly Window _window;
        private IntPtr _fontTexture;
        private uint _vertexArray;
        private uint _vertexBuffer;
        private uint _indexBuffer;
        private uint _shaderProgram;
        private int _attribLocationTex;
        private int _attribLocationProjMtx;
        private int _attribLocationPosition;
        private int _attribLocationUV;
        private int _attribLocationColor;
        private bool _frameBegun;

        private int _windowWidth;
        private int _windowHeight;

        public IntPtr Context { get; private set; }

        public ImGuiControllerOfGlfw(Window window, int width, int height)
        {
            _window = window;
            _windowWidth = width;
            _windowHeight = height;

            Context = ImGui.CreateContext();
            ImGui.SetCurrentContext(Context);

            ImGuiIoPtr io = ImGui.GetIo();
            io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
            io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;

            ImGui.StyleColorsDark();
            SetupRenderer();
            SetPerFrameImGuiData(1f / 60f);
            ImGui.NewFrame();
            _frameBegun = true;
        }

        public void NewFrame()
        {
            if (_frameBegun)
                ImGui.Render();

            Glfw.GetWindowSize(_window, out int w, out int h);
            if (w != _windowWidth || h != _windowHeight)
            {
                _windowWidth = w;
                _windowHeight = h;
            }

            SetPerFrameImGuiData(1f / 60f);
            UpdateInput();
            ImGui.NewFrame();
            _frameBegun = true;
        }

        public void Render()
        {
            if (!_frameBegun)
                return;

            ImGui.Render();
            RenderImDrawData(ImGui.GetDrawData());
            _frameBegun = false;
        }

        private void SetPerFrameImGuiData(float deltaSeconds)
        {
            ImGuiIoPtr io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(_windowWidth, _windowHeight);
            io.DisplayFramebufferScale = new Vector2F(1f, 1f);
            io.DeltaTime = deltaSeconds;
        }

        private void UpdateInput()
        {
            ImGuiIoPtr io = ImGui.GetIo();

            io.MouseDown[0] = Glfw.GetMouseButton(_window, MouseButton.Left) == InputState.Press;
            io.MouseDown[1] = Glfw.GetMouseButton(_window, MouseButton.Right) == InputState.Press;
            io.MouseDown[2] = Glfw.GetMouseButton(_window, MouseButton.Middle) == InputState.Press;

            Glfw.GetCursorPosition(_window, out double mouseX, out double mouseY);
            io.MousePos = new Vector2F((float)mouseX, (float)mouseY);
        }

        private void SetupRenderer()
        {
            _vertexArray = Gl.GenVertexArray();
            Gl.GlBindVertexArray(_vertexArray);

            _vertexBuffer = Gl.GenBuffer();
            _indexBuffer = Gl.GenBuffer();

            const string vertexShaderSource = """
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

            const string fragmentShaderSource = """
                                                    #version 330 core
                                                    in vec2 Frag_UV;
                                                    in vec4 Frag_Color;
                                                    uniform sampler2D Texture;
                                                    out vec4 Out_Color;
                                                    void main() {
                                                        Out_Color = Frag_Color * texture(Texture, Frag_UV.st);
                                                    }
                                                """;

            uint vertexShader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(vertexShader, vertexShaderSource);
            Gl.GlCompileShader(vertexShader);
            CheckShaderCompileStatus(vertexShader);

            uint fragmentShader = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(fragmentShader, fragmentShaderSource);
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
            _attribLocationUV = 1;
            _attribLocationColor = 2;

            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, _vertexBuffer);
            int stride = Marshal.SizeOf<ImDrawVert>();
            Gl.GlEnableVertexAttribArray((uint)_attribLocationPosition);
            Gl.GlVertexAttribPointer((uint)_attribLocationPosition, 2, VertexAttribPointerType.Float, false, stride, (IntPtr)0);
            Gl.GlEnableVertexAttribArray((uint)_attribLocationUV);
            Gl.GlVertexAttribPointer((uint)_attribLocationUV, 2, VertexAttribPointerType.Float, false, stride, (IntPtr)8);
            Gl.GlEnableVertexAttribArray((uint)_attribLocationColor);
            Gl.GlVertexAttribPointer((uint)_attribLocationColor, 4, VertexAttribPointerType.UnsignedByte, true, stride, (IntPtr)16);

            CreateFontTexture();
        }

        private void CreateFontTexture()
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

        private float[] MatrixToArray(Matrix4x4 m) => new[]
        {
            m.M11, m.M12, m.M13, m.M14,
            m.M21, m.M22, m.M23, m.M24,
            m.M31, m.M32, m.M33, m.M34,
            m.M41, m.M42, m.M43, m.M44
        };

        private void RenderImDrawData(ImDrawData drawData)
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

            var io = ImGui.GetIo();
            float L = drawData.DisplayPos.X;
            float R = drawData.DisplayPos.X + drawData.DisplaySize.X;
            float T = drawData.DisplayPos.Y;
            float B = drawData.DisplayPos.Y + drawData.DisplaySize.Y;

            var orthoProjection = new Matrix4x4(
                2.0f / (R - L), 0, 0, 0,
                0, -2.0f / (B - T), 0, 0,
                0, 0, -1.0f, 0,
                (R + L) / (L - R), (T + B) / (B - T), 0, 1.0f
            );

            Gl.GlUseProgram(_shaderProgram);
            Gl.GlUniform1I(_attribLocationTex, 0);
            Gl.GlUniformMatrix4Fv(_attribLocationProjMtx, 1, false, MatrixToArray(orthoProjection));
            Gl.GlBindVertexArray(_vertexArray);

            for (int n = 0; n < drawData.CmdListsCount; n++)
            {
                var cmdList = drawData.CmdListsRange[n];
                int vertexSize = cmdList.VtxBuffer.Size * Marshal.SizeOf<ImDrawVert>();
                int indexSize = cmdList.IdxBuffer.Size * sizeof(ushort);

                Gl.GlBindBuffer(BufferTarget.ArrayBuffer, _vertexBuffer);
                Gl.GlBufferData(BufferTarget.ArrayBuffer, vertexSize, cmdList.VtxBuffer.Data, BufferUsageHint.StreamDraw);

                Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, _indexBuffer);
                Gl.GlBufferData(BufferTarget.ElementArrayBuffer, indexSize, cmdList.IdxBuffer.Data, BufferUsageHint.StreamDraw);

                int idxOffset = 0;
                for (int cmdi = 0; cmdi < cmdList.CmdBuffer.Size; cmdi++)
                {
                    var pcmd = cmdList.CmdBuffer[cmdi];

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

        private static void CheckShaderCompileStatus(uint shader)
        {
            if (!Gl.GetShaderCompileStatus(shader))
                throw new Exception($"Shader compilation failed: {Gl.GetShaderInfoLog(shader)}");
        }

        private static void CheckProgramLinkStatus(uint program)
        {
            if (!Gl.GetProgramLinkStatus(program))
                throw new Exception($"Program linking failed: {Gl.GetProgramInfoLog(program)}");
        }

        public void Dispose()
        {
            if (_vertexBuffer != 0) Gl.DeleteBuffer(_vertexBuffer);
            if (_indexBuffer != 0) Gl.DeleteBuffer(_indexBuffer);
            if (_vertexArray != 0) Gl.DeleteVertexArray(_vertexArray);
            if (_shaderProgram != 0) Gl.GlDeleteProgram(_shaderProgram);
            if (_fontTexture != IntPtr.Zero) Gl.DeleteTexture((uint)_fontTexture);
        }
    }
}