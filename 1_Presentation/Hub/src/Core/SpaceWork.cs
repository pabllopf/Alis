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
using System.Runtime.InteropServices;
using Alis.App.Hub.Entity;
using Alis.Core.Ecs.System;
using Alis.Core.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.ImGui;

namespace Alis.App.Hub.Core
{
    /// <summary>
    ///     The space work class
    /// </summary>
    public class SpaceWork
    {
        /// <summary>
        ///     The context
        /// </summary>
        public IntPtr ContextGui;

        /// <summary>
        ///     The font loaded 16 light
        /// </summary>
        public ImFontPtr fontLoaded16Light;

        /// <summary>
        ///     The font loaded 16 solid
        /// </summary>
        public ImFontPtr fontLoaded16Solid;

        /// <summary>
        ///     The font loaded 30 bold
        /// </summary>
        public ImFontPtr fontLoaded45Bold;

        /// <summary>
        ///     The io
        /// </summary>
        public ImGuiIoPtr Io;

        /// <summary>
        ///     The renderer game
        /// </summary>
        public IntPtr rendererGame;

        /// <summary>
        ///     The style
        /// </summary>
        public ImGuiStyle Style;

        /// <summary>
        ///     The video game
        /// </summary>
        public VideoGame VideoGame;

        /// <summary>
        ///     Gets or sets the value of the viewport
        /// </summary>
        public ImGuiViewportPtr Viewport;

        /// <summary>
        ///     The window
        /// </summary>
        public IntPtr Window;

        /// <summary>
        /// The font loaded 10 solid
        /// </summary>
        public ImFontPtr fontLoaded10Solid;
        /// <summary>
        /// The font loaded 30 bold
        /// </summary>
        public ImFontPtr fontLoaded30Bold;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SpaceWork" /> class
        /// </summary>
        public SpaceWork()
        {
        }

        /// <summary>
        /// Gets the value of the is mac os
        /// </summary>
        public bool IsMacOs => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        /// <summary>
        ///     Gets or sets the value of the fps
        /// </summary>
        public int Fps { get; set; } = 60;

        /// <summary>
        ///     Gets or sets the value of the project selected
        /// </summary>
        public bool ProjectSelected { get; set; } = false;
        
        /// <summary>
        /// Gets or sets the value of the project
        /// </summary>
        public Project Project { get; set; } = new Project("", "" , "", "Never", "2021.1.0");
        
        /// <summary>
        /// Gets or sets the value of the event
        /// </summary>
        public Event Event { get; set; }

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {

        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void Update()
        {
        }
    }
}