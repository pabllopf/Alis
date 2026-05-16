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
using Alis.App.Hub.Windows;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Extension.Graphic.Ui;

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
        ///     Gets or sets the value of the font loaded 45 bold
        /// </summary>
        public ImFontPtr FontLoaded45Bold;

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
        ///     Gets the value of the height main window
        /// </summary>
        public int HeightMainWindow;

        /// <summary>
        ///     The io
        /// </summary>
        public ImGuiIoPtr io;

        /// <summary>
        ///     The quit
        /// </summary>
        public bool IsRunning;

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
        ///     Gets the value of the width main window
        /// </summary>
        public int WidthMainWindow;

        /// <summary>
        ///     The window
        /// </summary>
        public IntPtr WindowHub;

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
            HubWindow = new HubWindow(this);
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public void OnInit() => HubWindow.OnInit();

        /// <summary>
        ///     Ons the start
        /// </summary>
        public void OnStart() => HubWindow.OnStart();

        /// <summary>
        ///     Ons the render
        /// </summary>
        /// <param name="scaleFactor"></param>
        public void OnRender(float scaleFactor) => HubWindow.OnRender(scaleFactor);
    }
}