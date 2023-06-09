// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiGLRenderer.SDL.cs
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
using System.Text;
using Alis.Core.Graphic.SDL;
using static Alis.Core.Graphic.SDL.Sdl;


namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    ///     The im gui gl renderer class
    /// </summary>
    public partial class ImGuiGlRenderer
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
            io.DisplaySize = new Vector2(w, h);
            if ((w > 0) && (h > 0))
            {
                io.DisplayFramebufferScale = new Vector2((float) displayW / w, (float) displayH / h);
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
        public unsafe void ProcessEvent(SdlEvent evt)
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
                case SdlEventType.SdlMousebuttondown:
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
                case SdlEventType.SdlTextinput:
                {
                    string str = new string(Encoding.UTF8.GetString(bytes: evt.text.text));
                    io.AddInputCharactersUtf8(str);
                    return;
                }
                case SdlEventType.SdlKeydown:
                    if (evt.key.keysym.scancode == SdlScancode.SdlScancodeW)
                    {
                        io.KeysDown[(int)ImGuiKey.W] = true;
                    }
                    return;
                case SdlEventType.SdlKeyup:
                {
                    if (evt.key.keysym.scancode == SdlScancode.SdlScancodeW)
                    {
                        io.KeysDown[(int)ImGuiKey.W] = false;
                    }

                    //SdlScancode key = evt.key.keysym.scancode;
                    //io.KeysDown[(int) key] = evt.type == SdlEventType.SdlKeydown;
                    //io.KeyShift = (SDL_GetModState() & SdlKeymod.KmodShift) != 0;
                    //io.KeyCtrl = (SDL_GetModState() & SdlKeymod.KmodCtrl) != 0;
                    //io.KeyAlt = (SDL_GetModState() & SdlKeymod.KmodAlt) != 0;
                    //io.KeySuper = (SDL_GetModState() & SdlKeymod.KmodGui) != 0;
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
                io.MousePos = new Vector2(float.MinValue, float.MinValue);
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
                io.MousePos = new Vector2(mx, my);
            }

            // SDL_CaptureMouse() let the OS know e.g. that our imgui drag outside the SDL window boundaries shouldn't e.g. trigger the OS window resize cursor.
            bool anyMouseButtonDown = ImGui.IsAnyMouseDown();
            SDL_CaptureMouse(anyMouseButtonDown ? SdlBool.SdlTrue : SdlBool.SdlFalse);
        }

        /// <summary>
        ///     Prepares the gl context
        /// </summary>
        private void PrepareGlContext() => SDL_GL_MakeCurrent(_window, _glContext);
    }
}