// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiGLRenderer.cs
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
using System.Numerics;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.OpenGL.Constructs;
using static Alis.Core.Graphic.OpenGL.Gl;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im gui gl renderer class
    /// </summary>
    /// <seealso cref="IDisposable" />
    public partial class ImGuiGlRenderer : IDisposable
    {
        /// <summary>
        ///     The gl context
        /// </summary>
        private readonly IntPtr _glContext;

        /// <summary>
        ///     The window
        /// </summary>
        private readonly IntPtr _window;

        /// <summary>
        ///     The shader
        /// </summary>
        private GlShaderProgram _shader;

        /// <summary>
        ///     The font texture id
        /// </summary>
        private uint _vboHandle, _elementsHandle, _vertexArrayObject, _fontTextureId;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiGlRenderer" /> class
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="glContext">The gl context</param>
        public ImGuiGlRenderer(IntPtr window, IntPtr glContext)
        {
            _window = window;
            _glContext = glContext;

            // compile the shader program
            _shader = new GlShaderProgram(VertexShader, FragmentShader);

            ImGui.SetCurrentContext(ImGui.CreateContext());
            RebuildFontAtlas();
            InitKeyMap();

            _vboHandle = GenBuffer();
            _elementsHandle = GenBuffer();
            _vertexArrayObject = GenVertexArray();
        }

        /// <summary>
        ///     The vertex shader
        /// </summary>
        public static string VertexShader = @"
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
        public static string FragmentShader = @"
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
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (_shader != null)
            {
                _shader.Dispose();
                _shader = null;
                DeleteBuffer(_vboHandle);
                DeleteBuffer(_elementsHandle);
                DeleteVertexArray(_vertexArrayObject);
                DeleteTexture(_fontTextureId);
            }
        }

        /// <summary>
        ///     Rebuilds the font atlas
        /// </summary>
        private unsafe void RebuildFontAtlas()
        {
            ImFontAtlasPtr fonts = ImGui.GetIo().Fonts;

            fonts.AddFontDefault();
            fonts.GetTexDataAsRgba32(out byte* pixelData, out int width, out int height, out int _);

            _fontTextureId = ImGuiGl.LoadTexture((IntPtr) pixelData, width, height);

            fonts.TexId = (IntPtr) _fontTextureId;
            fonts.ClearTexData();
        }

        /// <summary>
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            PrepareGlContext();
            ImGui.Render();

            ImGuiIoPtr io = ImGui.GetIo();
            glViewport(0, 0, (int) io.DisplaySize.X, (int) io.DisplaySize.Y);
            glClear(ClearBufferMask.ColorBufferBit);

            RenderDrawData();

            glDisable(EnableCap.ScissorTest);
        }

        /// <summary>
        ///     Clears the color using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        public void ClearColor(float r, float g, float b, float a)
        {
            glClearColor(r, g, b, a);
        }

        /// <summary>
        ///     Setup the render state using the specified draw data
        /// </summary>
        /// <param name="drawData">The draw data</param>
        /// <param name="fbWidth">The fb width</param>
        /// <param name="fbHeight">The fb height</param>
        private void SetupRenderState(ImDrawDataPtr drawData, int fbWidth, int fbHeight)
        {
            glEnable(EnableCap.Blend);
            glBlendEquation(BlendEquationMode.FuncAdd);
            glBlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            glDisable(EnableCap.CullFace);
            glDisable(EnableCap.DepthTest);
            glEnable(EnableCap.ScissorTest);

            glUseProgram(_shader.ProgramId);

            float left = drawData.DisplayPos.X;
            float right = drawData.DisplayPos.X + drawData.DisplaySize.X;
            float top = drawData.DisplayPos.Y;
            float bottom = drawData.DisplayPos.Y + drawData.DisplaySize.Y;

            _shader["Texture"].SetValue(0);
            _shader["ProjMtx"].SetValue(Matrix4x4.CreateOrthographicOffCenter(left, right, bottom, top, -1, 1));
            glBindSampler(0, 0);

            glBindVertexArray(_vertexArrayObject);

            // Bind vertex/index buffers and setup attributes for ImDrawVert
            glBindBuffer(BufferTarget.ArrayBuffer, _vboHandle);
            glBindBuffer(BufferTarget.ElementArrayBuffer, _elementsHandle);

            EnableVertexAttribArray(_shader["Position"].Location);
            EnableVertexAttribArray(_shader["UV"].Location);
            EnableVertexAttribArray(_shader["Color"].Location);

            int drawVertSize = Marshal.SizeOf<ImDrawVert>();
            VertexAttribPointer(_shader["Position"].Location, 2, VertexAttribPointerType.Float, false, drawVertSize, Marshal.OffsetOf<ImDrawVert>("Pos"));
            VertexAttribPointer(_shader["UV"].Location, 2, VertexAttribPointerType.Float, false, drawVertSize, Marshal.OffsetOf<ImDrawVert>("Uv"));
            VertexAttribPointer(_shader["Color"].Location, 4, VertexAttribPointerType.UnsignedByte, true, drawVertSize, Marshal.OffsetOf<ImDrawVert>("Col"));
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
            glBindTexture(TextureTarget.Texture2D, (uint) lastTexId);

            int drawVertSize = Marshal.SizeOf<ImDrawVert>();
            int drawIdxSize = sizeof(ushort);

            for (int n = 0; n < drawData.CmdListsCount; n++)
            {
                ImDrawListPtr cmdList = drawData.CmdListsRange[n];

                // Upload vertex/index buffers
                glBufferData(BufferTarget.ArrayBuffer, (IntPtr) (cmdList.VtxBuffer.Size * drawVertSize), cmdList.VtxBuffer.Data, BufferUsageHint.StreamDraw);
                glBufferData(BufferTarget.ElementArrayBuffer, (IntPtr) (cmdList.IdxBuffer.Size * drawIdxSize), cmdList.IdxBuffer.Data, BufferUsageHint.StreamDraw);

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

                        glScissor((int) clipRect.X, (int) (fbHeight - clipRect.W), (int) (clipRect.Z - clipRect.X), (int) (clipRect.W - clipRect.Y));

                        // Bind texture, Draw
                        if (pcmd.TextureId != IntPtr.Zero)
                        {
                            if (pcmd.TextureId != lastTexId)
                            {
                                lastTexId = pcmd.TextureId;
                                glBindTexture(TextureTarget.Texture2D, (uint) pcmd.TextureId);
                            }
                        }

                        glDrawElementsBaseVertex(BeginMode.Triangles, (int) pcmd.ElemCount, drawIdxSize == 2 ? DrawElementsType.UnsignedShort : DrawElementsType.UnsignedInt, (IntPtr) (pcmd.IdxOffset * drawIdxSize), (int) pcmd.VtxOffset);
                    }
                }
            }
        }
    }
}