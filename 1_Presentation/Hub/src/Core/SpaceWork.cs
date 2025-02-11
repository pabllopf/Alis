// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SpaceWork.cs
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
using Alis.App.Hub.Controllers;
using Alis.App.Hub.Windows;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.Sdl2;
using Alis.Extension.Graphic.Sdl2.Enums;


using Alis.Extension.Graphic.Sdl2.Structs;


namespace Alis.App.Hub.Core
{
    /// <summary>
    ///     The space work class
    /// </summary>
    public class SpaceWork
    {
        /// <summary>
        ///     The hub window
        /// </summary>
        public readonly HubWindow HubWindow;

        /// <summary>
        ///     The name engine
        /// </summary>
        public readonly string NameEngine;

        /// <summary>
        ///     The context
        /// </summary>
        public IntPtr ContextImGui;

        /// <summary>
        ///     The dockspaceflags
        /// </summary>
        public ImGuiWindowFlags Dockspaceflags;

        /// <summary>
        ///     The elements handle
        /// </summary>
        public uint ElementsHandle;

        /// <summary>
        ///     The font loaded 10 solid
        /// </summary>
        public ImFontPtr FontLoaded10Solid;

        /// <summary>
        ///     The font loaded 16 light
        /// </summary>
        public ImFontPtr FontLoaded16Light;

        /// <summary>
        ///     The font loaded 16 solid
        /// </summary>
        public ImFontPtr FontLoaded16Solid;

        /// <summary>
        ///     The font loaded 30 bold
        /// </summary>
        public ImFontPtr FontLoaded30Bold;

        /// <summary>
        ///     The font texture id
        /// </summary>
        public uint FontTextureId;

        /// <summary>
        ///     The gl context
        /// </summary>
        public IntPtr GlContext;

        /// <summary>
        ///     The gl shader
        /// </summary>
        public GlShaderProgram GlShader;

        /// <summary>
        ///     The im gui controller
        /// </summary>
        public ImGuiController ImGuiController;

        /// <summary>
        ///     The io
        /// </summary>
        public ImGuiIoPtr Io;

        /// <summary>
        ///     The open gl controller
        /// </summary>
        public OpenGlController OpenGlController;

        /// <summary>
        ///     The sdl controller
        /// </summary>
        public SdlController SdlController;

        /// <summary>
        ///     The style
        /// </summary>
        public ImGuiStyle Style;

        /// <summary>
        ///     The time
        /// </summary>
        public float Time;

        /// <summary>
        ///     The vbo handle
        /// </summary>
        public uint VboHandle;

        /// <summary>
        ///     The vertex array object
        /// </summary>
        public uint VertexArrayObject;

        /// <summary>
        ///     Gets or sets the value of the viewport
        /// </summary>
        public ImGuiViewportPtr ViewportHub;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SpaceWork" /> class
        /// </summary>
        public SpaceWork()
        {
            NameEngine = "Welcome to Alis by @pabllopf";
            HeightMainWindow = 575;
            WidthMainWindow = 1025;
            Time = 0;
            IsRunning = true;

            Event = new Event();

            SdlController = new SdlController(this);
            OpenGlController = new OpenGlController(this);
            ImGuiController = new ImGuiController(this);

            HubWindow = new HubWindow(this);
        }

        /// <summary>
        ///     Gets the value of the height main window
        /// </summary>
        public int HeightMainWindow { get; }

        /// <summary>
        ///     Gets the value of the width main window
        /// </summary>
        public int WidthMainWindow { get; }

        /// <summary>
        ///     The window
        /// </summary>
        public IntPtr WindowHub { get; set; }

        /// <summary>
        ///     The quit
        /// </summary>
        public bool IsRunning { get; set; }

        /// <summary>
        ///     Gets or sets the value of the font loaded 45 bold
        /// </summary>
        public ImFontPtr FontLoaded45Bold { get; set; }

        /// <summary>
        ///     Gets or sets the value of the event
        /// </summary>
        public Event Event { get; set; }

        /// <summary>
        ///     Ons the event using the specified input event
        /// </summary>
        /// <param name="inputEvent">The input event</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void OnEvent(Event inputEvent)
        {
            Event = inputEvent;
            ImGuiController.ProcessEvent(inputEvent);

            switch (inputEvent.type)
            {
                case EventType.WindowEvent:
                {
                    if (inputEvent.window.windowEvent == WindowEventId.SdlWindowEventClose)
                    {
                        IsRunning = false;
                    }

                    break;
                }

                case EventType.Keydown:
                {
                    switch (inputEvent.key.KeySym.sym)
                    {
                        case KeyCodes.Escape:
                            IsRunning = false;
                            break;
                    }

                    break;
                }

                case EventType.FirstEvent:
                    break;
                case EventType.Quit:
                    break;
                case EventType.AppTerminating:
                    break;
                case EventType.AppLowMemory:
                    break;
                case EventType.AppWillEnterBackground:
                    break;
                case EventType.AppDidEnterBackground:
                    break;
                case EventType.AppWillEnterForeground:
                    break;
                case EventType.AppDidEnterForeground:
                    break;
                case EventType.LocaleChanged:
                    break;
                case EventType.DisplayEvent:
                    break;
                case EventType.SysWmEvent:
                    break;
                case EventType.Keyup:
                    break;
                case EventType.TextEditing:
                    break;
                case EventType.TextInput:
                    break;
                case EventType.KeymapChanged:
                    break;
                case EventType.MouseMotion:
                    break;
                case EventType.MouseButtonDown:
                    break;
                case EventType.MouseButtonUp:
                    break;
                case EventType.Mousewheel:
                    break;
                case EventType.JoyAxisMotion:
                    break;
                case EventType.JoyBallMotion:
                    break;
                case EventType.JoyHatMotion:
                    break;
                case EventType.JoyButtonDown:
                    break;
                case EventType.JoyButtonUp:
                    break;
                case EventType.JoyDeviceAdded:
                    break;
                case EventType.JoyDeviceRemoved:
                    break;
                case EventType.ControllerAxisMotion:
                    break;
                case EventType.ControllerButtonDown:
                    break;
                case EventType.ControllerButtonUp:
                    break;
                case EventType.ControllerDeviceAdded:
                    break;
                case EventType.ControllerDeviceRemoved:
                    break;
                case EventType.ControllerDeviceRemapped:
                    break;
                case EventType.ControllerTouchpadDown:
                    break;
                case EventType.ControllerTouchpadMotion:
                    break;
                case EventType.ControllerTouchpadUp:
                    break;
                case EventType.ControllerSensorUpdate:
                    break;
                case EventType.FingerDown:
                    break;
                case EventType.FingerUp:
                    break;
                case EventType.FingerMotion:
                    break;
                case EventType.DollarGesture:
                    break;
                case EventType.DollarRecord:
                    break;
                case EventType.MultiGesture:
                    break;
                case EventType.ClipBoardUpdate:
                    break;
                case EventType.DropFile:
                    break;
                case EventType.DropText:
                    break;
                case EventType.DropBegin:
                    break;
                case EventType.DropComplete:
                    break;
                case EventType.AudioDeviceAdded:
                    break;
                case EventType.AudioDeviceRemoved:
                    break;
                case EventType.SensorUpdate:
                    break;
                case EventType.RenderTargetsReset:
                    break;
                case EventType.RenderDeviceReset:
                    break;
                case EventType.PollSentinel:
                    break;
                case EventType.UserEvent:
                    break;
                case EventType.LastEvent:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        ///     Ons the start render
        /// </summary>
        public void OnStartRender()
        {
            SdlController.OnStartRender();
            OpenGlController.OnStartRender();
            ImGuiController.OnStartRender();
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public void OnUpdate()
        {
            SdlController.OnUpdate();
            OpenGlController.OnUpdate();
            ImGuiController.OnUpdate();

            HubWindow.OnRender();
        }

        /// <summary>
        ///     Ons the end render
        /// </summary>
        public void OnEndRender()
        {
            SdlController.OnEndRender();
            OpenGlController.OnEndRender();
            ImGuiController.OnEndRender();
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public void OnDestroy()
        {
            SdlController.OnDestroy();
            OpenGlController.OnDestroy();
            ImGuiController.OnDestroy();

            HubWindow.OnDestroy();


            if (GlShader != null)
            {
                GlShader.Dispose();
                GlShader = null;
                Gl.DeleteBuffer(VboHandle);
                Gl.DeleteBuffer(ElementsHandle);
                Gl.DeleteVertexArray(VertexArrayObject);
                Gl.DeleteTexture(FontTextureId);
            }

            Sdl.DeleteContext(GlContext);
            Sdl.DestroyWindow(WindowHub);
            Sdl.Quit();
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public void OnInit()
        {
            SdlController.OnInit();
            OpenGlController.OnInit();
            ImGuiController.OnInit();

            HubWindow.OnInit();
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public void OnStart()
        {
            SdlController.OnStart();
            OpenGlController.OnStart();
            ImGuiController.OnStart();

            HubWindow.OnStart();
        }
    }
}