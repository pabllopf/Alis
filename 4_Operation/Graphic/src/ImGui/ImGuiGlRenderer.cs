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
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.ImGui.Enums;
using Alis.Core.Graphic.ImGui.Structs;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.SDL;
using static Alis.Core.Graphic.OpenGL.Gl;
using static Alis.Core.Graphic.SDL.Sdl;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im gui gl renderer class
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class ImGuiGlRenderer : IDisposable
    {
        /// <summary>
        ///     The mouse pressed
        /// </summary>
        private readonly bool[] _mousePressed = {false, false, false};

        /// <summary>
        ///     The time
        /// </summary>
        private float _time;

        /// <summary>
        ///     Inits the key map
        /// </summary>
        private void InitKeyMap()
        {
            ImGuiIoPtr io = ImGui.GetIo();

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
        }

        /// <summary>
        ///     News the frame
        /// </summary>
        public void NewFrame()
        {
            ImGui.NewFrame();
            ImGuiIoPtr io = ImGui.GetIo();

            // Setup display size (every frame to accommodate for window resizing)
            SDL_GetWindowSize(_window, out int w, out int h);
            SDL_GL_GetDrawableSize(_window, out int displayW, out int displayH);
            io.DisplaySize = new Vector2F(w, h);
            if ((w > 0) && (h > 0))
            {
                io.DisplayFramebufferScale = new Vector2F((float) displayW / w, (float) displayH / h);
            }

            // Setup time step (we don't use SDL_GetTicks() because it is using millisecond resolution)
            ulong frequency = SDL_GetPerformanceFrequency();
            ulong currentTime = SDL_GetPerformanceCounter();
            io.DeltaTime = _time > 0 ? (float) ((double) (currentTime - _time) / frequency) : 1.0f / 60.0f;
            if (io.DeltaTime <= 0)
            {
                io.DeltaTime = 0.016f;
            }

            _time = currentTime;

            UpdateMousePosAndButtons();
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
                    if (evt.button.button == SdlButtonLeft)
                    {
                        _mousePressed[0] = true;
                    }

                    if (evt.button.button == SdlButtonRight)
                    {
                        _mousePressed[1] = true;
                    }

                    if (evt.button.button == SdlButtonMiddle)
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
                    SdlScancode key = evt.key.keysym.scancode;
                    io.KeysDown[(int) key] = evt.type == SdlEventType.SdlKeydown;
                    Console.WriteLine("io.KeysDown[" + key + "] = " + evt.type + io.KeysDown[(int) key]);
                    io.KeyShift = (SDL_GetModState() & SdlKeymod.KmodShift) != 0;
                    io.KeyCtrl = (SDL_GetModState() & SdlKeymod.KmodCtrl) != 0;
                    io.KeyAlt = (SDL_GetModState() & SdlKeymod.KmodAlt) != 0;
                    io.KeySuper = (SDL_GetModState() & SdlKeymod.KmodGui) != 0;
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
                SDL_WarpMouseInWindow(_window, (int) io.MousePos.X, (int) io.MousePos.Y);
            }
            else
            {
                io.MousePos = new Vector2F(float.MinValue, float.MinValue);
            }

            uint mouseButtons = SDL_GetMouseState(out int mx, out int my);
            io.MouseDown[0] =
                _mousePressed[0] ||
                (mouseButtons & SDL_BUTTON(SdlButtonLeft)) !=
                0; // If a mouse press event came, always pass it as "mouse held this frame", so we don't miss click-release events that are shorter than 1 frame.
            io.MouseDown[1] = _mousePressed[1] || (mouseButtons & SDL_BUTTON(SdlButtonRight)) != 0;
            io.MouseDown[2] = _mousePressed[2] || (mouseButtons & SDL_BUTTON(SdlButtonMiddle)) != 0;
            _mousePressed[0] = _mousePressed[1] = _mousePressed[2] = false;

            IntPtr focusedWindow = SDL_GetKeyboardFocus();
            if (_window == focusedWindow)
            {
                // SDL_GetMouseState() gives mouse position seemingly based on the last window entered/focused(?)
                // The creation of a new windows at runtime and SDL_CaptureMouse both seems to severely mess up with that, so we retrieve that position globally.
                SDL_GetWindowPosition(focusedWindow, out int wx, out int wy);
                SDL_GetGlobalMouseState(out mx, out my);
                mx -= wx;
                my -= wy;
                io.MousePos = new Vector2F(mx, my);
            }

            // SDL_CaptureMouse() let the OS know e.g. that our imgui drag outside the SDL window boundaries shouldn't e.g. trigger the OS window resize cursor.
            bool anyMouseButtonDown = ImGui.IsAnyMouseDown();
            SDL_CaptureMouse(anyMouseButtonDown ? SdlBool.SdlTrue : SdlBool.SdlFalse);
        }

        /// <summary>
        ///     Prepares the gl context
        /// </summary>
        private void PrepareGlContext() => SDL_GL_MakeCurrent(_window, _glContext);
        
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
        private readonly uint _vboHandle;

        /// <summary>
        ///     The font texture id
        /// </summary>
        private readonly uint _elementsHandle;

        /// <summary>
        ///     The font texture id
        /// </summary>
        private readonly uint _vertexArrayObject;

        /// <summary>
        ///     The font texture id
        /// </summary>
        private uint _fontTextureId;

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
            GlViewport(0, 0, (int) io.DisplaySize.X, (int) io.DisplaySize.Y);
            GlClear(ClearBufferMask.ColorBufferBit);

            RenderDrawData();

            GlDisable(EnableCap.ScissorTest);
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
            GlClearColor(r, g, b, a);
        }

        /// <summary>
        ///     Setup the render state using the specified draw data
        /// </summary>
        /// <param name="drawData">The draw data</param>
        /// <param name="fbWidth">The fb width</param>
        /// <param name="fbHeight">The fb height</param>
        private void SetupRenderState(ImDrawDataPtr drawData, int fbWidth, int fbHeight)
        {
            GlEnable(EnableCap.Blend);
            GlBlendEquation(BlendEquationMode.FuncAdd);
            GlBlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GlDisable(EnableCap.CullFace);
            GlDisable(EnableCap.DepthTest);
            GlEnable(EnableCap.ScissorTest);

            GlUseProgram(_shader.ProgramId);

            float left = drawData.DisplayPos.X;
            float right = drawData.DisplayPos.X + drawData.DisplaySize.X;
            float top = drawData.DisplayPos.Y;
            float bottom = drawData.DisplayPos.Y + drawData.DisplaySize.Y;

            _shader["Texture"].SetValue(0);
            _shader["ProjMtx"].SetValue(Matrix4X4F.CreateOrthographicOffCenter(left, right, bottom, top, -1, 1));
            GlBindSampler(0, 0);

            GlBindVertexArray(_vertexArrayObject);

            // Bind vertex/index buffers and setup attributes for ImDrawVert
            GlBindBuffer(BufferTarget.ArrayBuffer, _vboHandle);
            GlBindBuffer(BufferTarget.ElementArrayBuffer, _elementsHandle);

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

            Vector2F clipOffset = drawData.DisplayPos;
            Vector2F clipScale = drawData.FramebufferScale;

            drawData.ScaleClipRects(clipScale);

            IntPtr lastTexId = ImGui.GetIo().Fonts.TexId;
            GlBindTexture(TextureTarget.Texture2D, (uint) lastTexId);

            int drawVertSize = Marshal.SizeOf<ImDrawVert>();
            int drawIdxSize = sizeof(ushort);

            for (int n = 0; n < drawData.CmdListsCount; n++)
            {
                ImDrawListPtr cmdList = drawData.CmdListsRange[n];

                // Upload vertex/index buffers
                GlBufferData(BufferTarget.ArrayBuffer, (IntPtr) (cmdList.VtxBuffer.Size * drawVertSize), cmdList.VtxBuffer.Data, BufferUsageHint.StreamDraw);
                GlBufferData(BufferTarget.ElementArrayBuffer, (IntPtr) (cmdList.IdxBuffer.Size * drawIdxSize), cmdList.IdxBuffer.Data, BufferUsageHint.StreamDraw);

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
                        Vector4F clipRect = pcmd.ClipRect;

                        clipRect.X = pcmd.ClipRect.X - clipOffset.X;
                        clipRect.Y = pcmd.ClipRect.Y - clipOffset.Y;
                        clipRect.Z = pcmd.ClipRect.Z - clipOffset.X;
                        clipRect.W = pcmd.ClipRect.W - clipOffset.Y;

                        GlScissor((int) clipRect.X, (int) (fbHeight - clipRect.W), (int) (clipRect.Z - clipRect.X), (int) (clipRect.W - clipRect.Y));

                        // Bind texture, Draw
                        if (pcmd.TextureId != IntPtr.Zero)
                        {
                            if (pcmd.TextureId != lastTexId)
                            {
                                lastTexId = pcmd.TextureId;
                                GlBindTexture(TextureTarget.Texture2D, (uint) pcmd.TextureId);
                            }
                        }

                        GlDrawElementsBaseVertex(BeginMode.Triangles, (int) pcmd.ElemCount, drawIdxSize == 2 ? DrawElementsType.UnsignedShort : DrawElementsType.UnsignedInt, (IntPtr) (pcmd.IdxOffset * drawIdxSize), (int) pcmd.VtxOffset);
                    }
                }
            }
        }
    }
}