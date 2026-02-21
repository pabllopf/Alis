// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImguiSample.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Platforms;
using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Alis.Extension.Graphic.Ui.Extras.Node;
using Alis.Extension.Graphic.Ui.Extras.Plot;

namespace Alis.Extension.Graphic.Ui.Sample.Examples
{
    /// <summary>
    ///     Simple ImGui example using the native platform and OpenGL.
    ///     The code is structured to avoid exception-heavy control flow and uses
    ///     Debug assertions / conditional checks instead of try/catch for validation.
    /// </summary>
    public class ImguiSample : IExample
    {
        /// <summary>
        ///     The platform
        /// </summary>
        private readonly INativePlatform _platform;

        /// <summary>
        ///     The context
        /// </summary>
        private IntPtr _context;

        /// <summary>
        ///     The counter
        /// </summary>
        private int _counter;

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
        ///     The show demo
        /// </summary>
        private bool _showDemo = true;

        /// <summary>
        ///     The vao
        /// </summary>
        private uint _vao;

        /// <summary>
        ///     The vbo
        /// </summary>
        private uint _vbo;

        /// <summary>
        ///     The firsttime
        /// </summary>
        private bool firsttime = true;

        /// <summary>
        ///     The style
        /// </summary>
        private ImGuiStyle style;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImguiSample" /> class
        /// </summary>
        /// <param name="platform">The platform</param>
        public ImguiSample(INativePlatform platform) => _platform = platform;

        // Parameterless constructor to allow alternate build contexts
        /// <summary>
        ///     Initializes a new instance of the <see cref="ImguiSample" /> class
        /// </summary>
        public ImguiSample() => _platform = null;

        /// <summary>
        ///     Initialize GL resources and ImGui context. Uses assertions and guards
        ///     instead of exception handling for faster execution paths.
        /// </summary>
        public void Initialize()
        {
            // Ensure the native GL context is current before creating GL resources.
            Debug.Assert(_platform != null, "Platform must be provided before Initialize is called.");
            _platform?.MakeContextCurrent();

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

            ImGuiIoPtr io = ImGui.GetIo();
            Debug.Assert(io.NativePtr != IntPtr.Zero, "ImGui IO must be valid after creating or setting context.");

            // Backend capabilities
            io.BackendFlags |= ImGuiBackendFlags.HasMouseCursors | ImGuiBackendFlags.HasSetMousePos;
            io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
            ImGui.StyleColorsDark();

            style = ImGui.GetStyle();

            // Build and upload font atlas to GL
            ImFontAtlasPtr fonts = io.Fonts;
            fonts.GetTexDataAsRgba32(out IntPtr pixelPtr, out int widthPtr, out int heightPtr);

            if ((pixelPtr != IntPtr.Zero) && (widthPtr > 0) && (heightPtr > 0))
            {
                Debug.Assert(_platform != null, "Platform required to upload font texture.");
                // Ensure context is current (best-effort). MakeContextCurrent is void; assume host handles errors.
                _platform.MakeContextCurrent();

                _fontTexture = Gl.GenTexture();
                Gl.GlBindTexture(TextureTarget.Texture2D, _fontTexture);
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Nearest);
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Nearest);
                Gl.GlPixelStorei(StoreParameter.UnpackAlignment, 1);

                Logger.Info($"Uploading font texture: width={widthPtr}, height={heightPtr}, ptr=0x{pixelPtr.ToInt64():X}");
                Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, widthPtr, heightPtr, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixelPtr);
                int errPtr = Gl.GlGetError();
                if (errPtr != 0)
                {
                    Logger.Info($"GL error after TexImage2D: 0x{errPtr:X}");
                }

                // Inform ImGui about the texture id
                fonts.SetTexId((IntPtr) _fontTexture);
            }

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
        }

        /// <summary>
        ///     Main per-frame draw. Updates ImGui IO from the platform and renders.
        ///     Avoids exception handling for common control flow.
        /// </summary>
        public void Draw()
        {
            ImGuiIoPtr io = ImGui.GetIo();

            ImGui.NewFrame();

            // Only call DockSpaceOverViewport if docking is enabled in ImGui config flags
            if ((io.ConfigFlags & ImGuiConfigFlags.DockingEnable) != 0)
            {
                ImGui.DockSpaceOverViewport();
            }

            if (_showDemo)
            {
                ImGui.ShowDemoWindow(ref _showDemo);
            }

            ImPlot.ShowDemoWindow();
            ImGuizMo.ShowDemoWindow();
            ImNodes.ShowDemoWindow();

            ImGui.Begin("Alis ImGui Sample");
            ImGui.Text($"Counter: {_counter}");
            if (ImGui.Button("Increment"))
            {
                _counter++;
            }

            ImGui.End();

            ImGui.Render();
            ImDrawData drawData = ImGui.GetDrawData();
            RenderDrawData(drawData);

            // No exception-handling here; platform may reset wheel internally if needed.
        }

        /// <summary>
        ///     Cleanups this instance
        /// </summary>
        public void Cleanup()
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

            // Obtener el viewport real del framebuffer
            int[] viewport = new int[4];
            Gl.GlGetIntegerv(0x0BA2, viewport); // 0x0BA2 = GL_VIEWPORT
            int fbWidth = viewport[2];
            int fbHeight = viewport[3];
            ImGuiIoPtr imGuiIoPtr = ImGui.GetIo();
            imGuiIoPtr.DisplaySize = new Vector2F(fbWidth, fbHeight);
            //imGuiIoPtr.DisplayFramebufferScale = new Alis.Core.Aspect.Math.Vector.Vector2F(
            //    fbWidth / imGuiIoPtr.DisplaySize.X,
            //    fbHeight / imGuiIoPtr.DisplaySize.Y);

            if (firsttime)
            {
                float resolutionProgramX = 800.0f;
                float resolutionProgramY = 600.0f;

                float scaleX = fbWidth / resolutionProgramX;
                float scaleY = fbHeight / resolutionProgramY;
                float scaleFactor = Math.Min(scaleX, scaleY);

                Console.WriteLine($"Setting style scale factor: {scaleFactor}");

                style.ScaleAllSizes(scaleFactor);
                imGuiIoPtr.FontGlobalScale = scaleFactor;
                firsttime = false;
            }


            float l = 0.0f;
            float r = imGuiIoPtr.DisplaySize.X;
            float t = 0.0f;
            float b = imGuiIoPtr.DisplaySize.Y;

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
                        uint texId = texIdPtr == IntPtr.Zero ? _fontTexture : (uint) texIdPtr.ToInt64();

                        Gl.GlActiveTexture(TextureUnit.Texture0);
                        Gl.GlBindTexture(TextureTarget.Texture2D, texId);

                        int x = (int) pcmd.ClipRect.X;
                        int y = (int) (imGuiIoPtr.DisplaySize.Y - pcmd.ClipRect.W);
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
    }
}