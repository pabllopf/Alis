// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlController.cs
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
using System.IO;
using Alis.App.Hub.Core;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Memory.Exceptions;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Extension.Graphic.Sdl2;
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Structs;
using Gl = Alis.Extension.Graphic.Sdl2.Gl;


namespace Alis.App.Hub.Controllers
{
    /// <summary>
    ///     The sdl controller class
    /// </summary>
    /// <seealso cref="AController" />
    public class SdlController : AController
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SdlController" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public SdlController(SpaceWork spaceWork) : base(spaceWork)
        {
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            if (Sdl.Init(InitSettings.InitEverything) != 0)
            {
                Logger.Exception($@"Error of SDL2: {Sdl.GetError()}");
            }
            
            Sdl.SetHint(Hint.HintRenderDriver, "opengl");

            // CONFIG THE SDL2 AN OPENGL CONFIGURATION
            Sdl.SetAttributeByInt(Attr.SdlGlContextFlags, (int) Contexts.SdlGlContextForwardCompatibleFlag);
            Sdl.SetAttributeByProfile(Attr.SdlGlContextProfileMask, Profiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(Attr.SdlGlContextMajorVersion, 3);
            Sdl.SetAttributeByInt(Attr.SdlGlContextMinorVersion, 2);

            Sdl.SetAttributeByProfile(Attr.SdlGlContextProfileMask, Profiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(Attr.SdlGlDoubleBuffer, 1);
            Sdl.SetAttributeByInt(Attr.SdlGlDepthSize, 24);
            Sdl.SetAttributeByInt(Attr.SdlGlAlphaSize, 8);
            Sdl.SetAttributeByInt(Attr.SdlGlStencilSize, 8);

            // Enable vsync
            Sdl.SetSwapInterval(1);

            // create the window which should be able to have a valid OpenGL context and is resizable
            WindowSettings flags = WindowSettings.WindowOpengl | WindowSettings.WindowResizable;

            SpaceWork.WindowHub = Sdl.CreateWindow(SpaceWork.NameEngine,
                (int) WindowPos.WindowPosCentered,
                (int) WindowPos.WindowPosCentered,
                SpaceWork.WidthMainWindow, SpaceWork.HeightMainWindow, flags);
        }

        /// <summary>
        ///     Creates the gl context using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The gl context</returns>
        public IntPtr CreateGlContext(IntPtr window)
        {
            IntPtr glContext = Sdl.CreateContext(window);
            if (glContext == IntPtr.Zero)
            {
                throw new GeneralAlisException("Could Not Create GL Context.");
            }

            Sdl.MakeCurrent(window, glContext);
            Sdl.SetSwapInterval(1);

            Gl.GlClearColor(0f, 0f, 0f, 1f);
            Gl.GlClear(ClearBufferMask.ColorBufferBit);
            Sdl.SwapWindow(window);

            Logger.Info($"GL Version: {Gl.GlGetString(StringName.Version)}");
            return glContext;
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
            string iconPath = AssetManager.Find("Hub_app.bmp");
            if (!string.IsNullOrEmpty(iconPath) && File.Exists(iconPath))
            {
                IntPtr icon = Sdl.LoadBmp(iconPath);
                Sdl.SetWindowIcon(SpaceWork.WindowHub, icon);
            }
        }

        /// <summary>
        ///     Ons the start render
        /// </summary>
        public override void OnStartRender()
        {
            // Setup display size (every frame to accommodate for window resizing)
            Vector2F windowSize = Sdl.GetWindowSize(SpaceWork.WindowHub);
            Sdl.GetDrawableSize(SpaceWork.WindowHub, out int displayW, out int displayH);
            SpaceWork.Io.DisplaySize = new Vector2F(windowSize.X, windowSize.Y);
            if ((windowSize.X > 0) && (windowSize.Y > 0))
            {
                SpaceWork.Io.DisplayFramebufferScale = new Vector2F(displayW / windowSize.X, displayH / windowSize.Y);
            }

            // Setup time step (we don't use SDL_GetTicks() because it is using millisecond resolution)
            ulong frequency = Sdl.GetPerformanceFrequency();
            ulong currentTime = Sdl.GetPerformanceCounter();
            SpaceWork.Io.DeltaTime = SpaceWork.Time > 0 ? (float) ((double) (currentTime - SpaceWork.Time) / frequency) : 1.0f / 60.0f;
            if (SpaceWork.Io.DeltaTime <= 0)
            {
                SpaceWork.Io.DeltaTime = 0.016f;
            }

            SpaceWork.Time = currentTime;
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
        }

        /// <summary>
        ///     Ons the end render
        /// </summary>
        public override void OnEndRender()
        {
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public override void OnDestroy()
        {
        }
    }
}