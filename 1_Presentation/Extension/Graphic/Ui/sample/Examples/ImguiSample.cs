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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Platforms;
using Alis.Extension.Graphic.Ui;

namespace Alis.Extension.Graphic.Ui.Sample.Examples
{
    public class ImguiSample : IExample
    {
        private readonly INativePlatform _platform;
        private IntPtr _context;

        private uint _fontTexture;
        private uint _vao;
        private uint _vbo;
        private uint _ebo;
        private uint _shaderProgram;

        private bool _showDemo = true;
        private int _counter;

        public ImguiSample(INativePlatform platform)
        {
            _platform = platform;
        }

        public void Initialize()
        {
            // Ensure native context is current before creating GL resources
            _platform?.MakeContextCurrent();

            // Do not create ImGui context here if it was already created by the application entry point.
            // Just ensure ImGui current context is set and IO is available.
            IntPtr currentCtx = ImGui.GetCurrentContext();
            if (currentCtx == IntPtr.Zero)
            {
                // Create context if not previously created by the host
                _context = ImGui.CreateContext();
                ImGui.SetCurrentContext(_context);
            }
            else
            {
                _context = currentCtx;
                ImGui.SetCurrentContext(_context);
            }

            var io = ImGui.GetIo();
            if (io.NativePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("ImGui IO is null. Ensure ImGui.CreateContext() was called after an active OpenGL context is current.");
            }
            // Create ImGui context (uses local wrapper)
            //            _context = ImGui.CreateContext();
            //            ImGui.SetCurrentContext(_context);
            //            var io = ImGui.GetIo();
            //io already obtained above
            io.BackendFlags |= ImGuiBackendFlags.HasMouseCursors | ImGuiBackendFlags.HasSetMousePos;
            io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
            ImGui.StyleColorsDark();

            // Build font atlas using safe API and upload to GL
            var fonts = io.Fonts;
            // Preferred: get pointer to font pixels (avoids copying and GCHandle)
            fonts.GetTexDataAsRgba32(out IntPtr pixelPtr, out int widthPtr, out int heightPtr);

            if (pixelPtr != IntPtr.Zero && widthPtr > 0 && heightPtr > 0)
            {
                if (_platform == null)
                {
                    Console.WriteLine("No hay plataforma asociada. No se puede subir la textura de fuentes.");
                    return;
                }

                try
                {
                    _platform.MakeContextCurrent();
                    Console.WriteLine("MakeContextCurrent() called before font upload (IntPtr path)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al activar el contexto OpenGL antes de subir la textura: {ex}");
                    return;
                }

                _fontTexture = Gl.GenTexture();
                Gl.GlBindTexture(TextureTarget.Texture2D, _fontTexture);
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Nearest);
                Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Nearest);
                Gl.GlPixelStorei(StoreParameter.UnpackAlignment, 1);

                Console.WriteLine($"Uploading font texture (IntPtr): width={widthPtr}, height={heightPtr}, ptr=0x{pixelPtr.ToInt64():X}");
                Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, widthPtr, heightPtr, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixelPtr);
                int errPtr = Gl.GlGetError();
                if (errPtr != 0)
                {
                    Console.WriteLine($"GL error after TexImage2D (IntPtr): 0x{errPtr:X}");
                }

                // Tell ImGui about our texture id (store as IntPtr)
                fonts.SetTexId((IntPtr)_fontTexture);
                // Free CPU side (cimgui provides ClearTexData)
                try
                {
                    // Some bindings call this ClearTexData / ClearTexData
                    fonts.ClearTexData();
                }
                catch (Exception)
                {
                    // Ignore if not implemented
                }
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

            // Create VAO/VBO/EBO
            _vao = Gl.GenVertexArray();
            _vbo = Gl.GenBuffer();
            _ebo = Gl.GenBuffer();

            Gl.GlBindVertexArray(_vao);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, _vbo);
            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, _ebo);

            // ImDrawVert layout: pos(2 floats), uv(2 floats), col(uint) => stride
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

        public void Draw()
        {
            var io = ImGui.GetIo();
            // Update display size each frame (handles window resize)
            io.DisplaySize = new Alis.Core.Aspect.Math.Vector.Vector2F(_platform.GetWindowWidth(), _platform.GetWindowHeight());

            // Feed mouse state from platform
            try
            {
                _platform.GetMouseState(out int mx, out int my, out bool[] mButtons);
                io.MousePos = new Alis.Core.Aspect.Math.Vector.Vector2F(mx, my);
                // Build MouseDown list expected by ImGui wrapper
                var mouseDownList = new System.Collections.Generic.List<bool>();
                for (int i = 0; i < 5; i++) mouseDownList.Add(i < mButtons.Length ? mButtons[i] : false);
                io.MouseDown = mouseDownList;
                io.MouseWheel = _platform.GetMouseWheel();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading mouse state from platform: {ex}");
            }

            ImGui.NewFrame();

            // Create a full-screen DockSpace so other windows can dock into it
            try
            {
                // Ensure docking is enabled in io.ConfigFlags
                ImGui.DockSpaceOverViewport();
            }
            catch (Exception ex)
            {
                // If Docking isn't compiled in cimgui, ignore
                Console.WriteLine($"DockSpaceOverViewport error (may be unsupported): {ex}");
            }

            if (_showDemo)
            {
                ImGui.ShowDemoWindow(ref _showDemo);
            }

            ImGui.Begin("Ejemplo Alis ImGui");
            ImGui.Text($"Contador: {_counter}");
            if (ImGui.Button("Incrementar")) _counter++;
            ImGui.End();

            ImGui.Render();
            var drawData = ImGui.GetDrawData();
            RenderDrawData(drawData);

            // After rendering, reset mouse wheel in case platform returns an accumulated value
            try
            {
                // If platform provides mutable mouse wheel, try to clear it via GetMouseState side-effect; otherwise ignore
                // For MacNativePlatform we reset mouseWheel inside GetMouseWheel implementation.
            }
            catch { }
        }

        private void RenderDrawData(ImDrawData drawData)
        {
            if (drawData.CmdListsCount == 0)
                return;

            Gl.GlEnable(EnableCap.Blend);
            Gl.GlBlendEquation(BlendEquationMode.FuncAdd);
            Gl.GlBlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            Gl.GlDisable(EnableCap.CullFace);
            Gl.GlDisable(EnableCap.DepthTest);
            Gl.GlEnable(EnableCap.ScissorTest);

            Gl.GlViewport(0, 0, _platform.GetWindowWidth(), _platform.GetWindowHeight());

            float l = 0.0f;
            float r = ImGui.GetIo().DisplaySize.X;
            float t = 0.0f;
            float b = ImGui.GetIo().DisplaySize.Y;

            var ortho = new Matrix4X4(
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
                var cmdList = drawData.CmdListsRange[n];

                int vtxBufferSize = cmdList.VtxBuffer.Size * Marshal.SizeOf<ImDrawVert>();
                int idxBufferSize = cmdList.IdxBuffer.Size * sizeof(ushort);

                Gl.GlBindBuffer(BufferTarget.ArrayBuffer, _vbo);
                // copy vertex data
                // Marshal.Copy from unmanaged ptr to GC pinned buffer via GlBufferData expects IntPtr source
                Gl.GlBufferData(BufferTarget.ArrayBuffer, new IntPtr(vtxBufferSize), cmdList.VtxBuffer.Data, BufferUsageHint.StreamDraw);

                Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, _ebo);
                Gl.GlBufferData(BufferTarget.ElementArrayBuffer, new IntPtr(idxBufferSize), cmdList.IdxBuffer.Data, BufferUsageHint.StreamDraw);

                long idxOffset = 0;
                for (int cmdi = 0; cmdi < cmdList.CmdBuffer.Size; cmdi++)
                {
                    ImDrawCmd pcmd = cmdList.CmdBuffer[cmdi];
                    if (pcmd.UserCallback != IntPtr.Zero)
                    {
                        // user callback (not handled)
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

        public void Cleanup()
        {
            if (_vbo != 0) Gl.DeleteBuffer(_vbo);
            if (_ebo != 0) Gl.DeleteBuffer(_ebo);
            if (_vao != 0) Gl.DeleteVertexArray(_vao);
            if (_shaderProgram != 0) Gl.GlDeleteProgram(_shaderProgram);
            if (_fontTexture != 0) Gl.DeleteTexture(_fontTexture);

            ImGui.SetCurrentContext(new IntPtr());
            // No DestroyContext wrapper; if exists use ImGui.DestroyContext
        }

        // Parameterless constructor: provided to avoid mismatches in some build contexts.
        public ImguiSample()
        {
            _platform = null;
        }
    }
}