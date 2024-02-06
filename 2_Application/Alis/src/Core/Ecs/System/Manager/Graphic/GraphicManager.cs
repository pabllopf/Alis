// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicManager.cs
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.System.Setting.Graphic;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Extensions.Sdl2Ttf;
using Alis.Core.Graphic.Sdl2.Structs;
using Color = Alis.Core.Aspect.Math.Definition.Color;
using Version = Alis.Core.Graphic.Sdl2.Structs.Version;

namespace Alis.Core.Ecs.System.Manager.Graphic
{
    /// <summary>
    ///     The graphic manager base class
    /// </summary>
    /// <seealso cref="Manager" />
    public class GraphicManager : Manager, IGraphicManager
    {
        /// <summary>
        ///     The window
        /// </summary>
        private static IntPtr _window;

        /// <summary>
        ///     The box collider
        /// </summary>
        private static readonly List<BoxCollider> ColliderBases = new List<BoxCollider>();

        /// <summary>
        ///     The default size
        /// </summary>
        private Vector2 defaultSize;

        /// <summary>
        ///     The renderWindow
        /// </summary>
        public IntPtr Renderer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GraphicManager" /> class
        /// </summary>
        public GraphicManager()
        {
        }

        /// <summary>
        ///     Gets or sets the value of the sprites
        /// </summary>
        private static List<Sprite> Sprites { get; set; } = new List<Sprite>();

        /// <summary>
        ///     Gets or sets the value of the setting
        /// </summary>
        public IGraphicSetting Setting { get; set; }

        /// <summary>
        ///     Ons the enable
        /// </summary>
        public override void OnEnable()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            Logger.Log("init::graphic:new");

            defaultSize = new Vector2(VideoGame.Instance.Settings.Graphic.Window.Resolution.X, VideoGame.Instance.Settings.Graphic.Window.Resolution.Y);

            InitRenderWindow();
        }

        /// <summary>
        ///     Ons the awake
        /// </summary>
        public override void OnAwake()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
            Logger.Trace();
            Sprites = Sprites.OrderBy(o => o.Depth).ToList();
        }

        /// <summary>
        ///     Ons the before update
        /// </summary>
        public override void OnBeforeUpdate()
        {
            Logger.Trace();

            // Sets color to black (0, 0, 0, 255).
            Sdl.SetRenderDrawColor(Renderer, 0, 0, 0, 255);

            // Clears the current render surface.
            Sdl.RenderClear(Renderer);
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            if (VideoGame.Instance.Settings.General.Debug)
            {
                //Show fps on tittle window
                Sdl.SetWindowTitle(_window, $"{VideoGame.Instance.Settings.General.Name} - FPS: {Game.TimeManager.AverageFrames}");
            }
            
            Sprites = Sprites.OrderBy(o => o.Depth).ToList();

            // Draws sprites:
            foreach (Sprite sprite in Sprites.Where(sprite => sprite.Image != null))
            {
                sprite.Render(Renderer);
            }

            if (VideoGame.Instance.Settings.Physic.DebugMode)
            {
                // Sets color
                Color color = VideoGame.Instance.Settings.Physic.DebugColor;

                // render color
                Sdl.SetRenderDrawColor(Renderer, color.R, color.G, color.B, color.A);

                RectangleF[] rectangles = new RectangleF[ColliderBases.Count];

                // Draws rectangles:
                for (int i = 0; i < ColliderBases.Count; i++)
                {
                    if (ColliderBases[i] != null)
                    {
                        rectangles[i] = ColliderBases[i].RectangleF;
                    }
                }

                // Render the font to the screen
                //Sdl.RenderCopy(Renderer, textureFont1, IntPtr.Zero, ref dstRectFont1);

                Sdl.RenderDrawRectsF(Renderer, rectangles, rectangles.Length);
            }

            Sdl.RenderPresent(Renderer);
        }

        /// <summary>
        ///     Ons the after update
        /// </summary>
        public override void OnAfterUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        public override void OnBeforeFixedUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the fixed update
        /// </summary>
        public override void OnFixedUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        public override void OnAfterFixedUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public override void OnDispatchEvents()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the calculate
        /// </summary>
        public override void OnCalculate()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the draw
        /// </summary>
        public override void OnDraw()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the gui
        /// </summary>
        public override void OnGui()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the disable
        /// </summary>
        public override void OnDisable()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the reset
        /// </summary>
        public override void OnReset()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the stop
        /// </summary>
        public override void OnStop()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the exit
        /// </summary>
        public override void OnExit()
        {
            Logger.Trace();

            Sdl.DestroyRenderer(Renderer);
            Sdl.DestroyWindow(_window);
            Sdl.Quit();
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public override void OnDestroy()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Inits the render window
        /// </summary>
        private void InitRenderWindow()
        {
            if (Sdl.Init(Init.InitEverything) < 0)
            {
                Console.WriteLine($@"There was an issue initializing SDL. {Sdl.GetError()}");
            }

            // GET VERSION SDL2
            Version version = Sdl.GetVersion();
            Console.WriteLine(@$"SDL2 VERSION {version.major}.{version.minor}.{version.patch}");

            
            // CONFIG THE SDL2 AN OPENGL CONFIGURATION
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextFlags, (int) GlContext.SdlGlContextForwardCompatibleFlag);
            Sdl.SetAttributeByProfile(GlAttr.SdlGlContextProfileMask, GlProfile.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextMajorVersion, 3);
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextMinorVersion, 2);

            Sdl.SetAttributeByProfile(GlAttr.SdlGlContextProfileMask, GlProfile.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(GlAttr.SdlGlDoubleBuffer, 1);
            Sdl.SetAttributeByInt(GlAttr.SdlGlDepthSize, 24);
            Sdl.SetAttributeByInt(GlAttr.SdlGlAlphaSize, 8);
            Sdl.SetAttributeByInt(GlAttr.SdlGlStencilSize, 8);

            // Enable vsync
            Sdl.SetSwapInterval(1);

            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.Windows)
            {
                Sdl.SetHint(Hint.HintRenderDriver, "direct3d");
            }

            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.OSX)
            {
                Sdl.SetHint(Hint.HintRenderDriver, "opengl");
            }

            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.Linux)
            {
                Sdl.SetHint(Hint.HintRenderDriver, "opengl");
            }


            // Create the window
            // create the window which should be able to have a valid OpenGL context and is resizable
            WindowFlags flags = WindowFlags.WindowShown;

            if (VideoGame.Instance.Settings.Graphic.Window.IsWindowResizable)
            {
                flags |= WindowFlags.WindowResizable;
            }

            // Creates a new SDL window at the center of the screen with the given width and height.
            _window = Sdl.CreateWindow(VideoGame.Instance.Settings.General.Name, (int) WindowPos.WindowPosCentered, (int) WindowPos.WindowPosCentered, (int) defaultSize.X, (int) defaultSize.Y, flags);

            // Check if the window was created successfully.
            Console.WriteLine(_window == IntPtr.Zero ? $"There was an issue creating the renderer. {Sdl.GetError()}" : "Window created");

            // Create the renderer
            Renderer = Sdl.CreateRenderer(
                _window,
                -1,
                RendererFlags.SdlRendererAccelerated);


            // Check if the renderer was created successfully.
            Console.WriteLine(Renderer == IntPtr.Zero ? $"There was an issue creating the renderer. {Sdl.GetError()}" : "Renderer created");

            int totalDisplays = Sdl.GetNumVideoDisplays();
            Console.WriteLine($"Total Displays: {totalDisplays}");

            for (int i = 0; i < totalDisplays; ++i)
            {
                string displayName = Sdl.GetDisplayName(i + 1);
                Console.WriteLine($"Display {i}: {displayName}");

                // GET DISPLAY BOUNDS
                Sdl.GetDisplayBounds(i, out RectangleI displayBounds);
                Console.WriteLine($"Display [{i}] Bounds: {displayBounds.x}, {displayBounds.y}, {displayBounds.w}, {displayBounds.h}");
            }

            int totalDrivers = Sdl.GetNumRenderDrivers();
            Console.WriteLine($"Total Render Drivers: {totalDrivers}");

            for (int i = 0; i < totalDrivers; ++i)
            {
                Console.WriteLine($"Driver {i}: {Sdl.GetVideoDriver(i)}");
            }

            // GET RENDERER INFO
            Sdl.GetRendererInfo(Renderer, out RendererInfo rendererInfo);
            Console.WriteLine($"Renderer Name: {rendererInfo.GetName()} \n" +
                              $"Renderer Flags: {rendererInfo.flags} \n" +
                              $"Max Texture Width: {rendererInfo.maxTextureWidth} \n" +
                              $"Max Texture Height: {rendererInfo.maxTextureHeight} + \n" +
                              $"Max Texture Width: {rendererInfo.maxTextureWidth} \n" +
                              $"Max Texture Height: {rendererInfo.maxTextureHeight}");

            // GET RENDERER OUTPUT SIZE
            Sdl.GetRendererOutputSize(Renderer, out int w, out int h);
            Console.WriteLine($"Renderer Output Size: {w}, {h}");

            // GET RENDERER LOGICAL SIZE
            Sdl.RenderGetLogicalSize(Renderer, out int w2, out int h2);
            Console.WriteLine($"Renderer Logical Size: {w2}, {h2}");

            // GET RENDERER SCALE
            Sdl.RenderGetScale(Renderer, out float scaleX, out float scaleY);
            Console.WriteLine($"Renderer Scale: {scaleX}, {scaleY}");


            uint windowHandle = Sdl.GetWindowId(_window);
            Console.WriteLine($"Window Handle: {windowHandle}");

            int numberOfDisplays = Sdl.GetNumVideoDisplays();
            Console.WriteLine($"Number of Displays: {numberOfDisplays}");

            int displayIndex = Sdl.GetWindowDisplayIndex(_window);
            Console.WriteLine($"Display Index: {displayIndex}");

            int numOfTypeDisplaysModes = Sdl.GetNumDisplayModes(displayIndex);
            Console.WriteLine($"Number of Type Displays Modes: {numOfTypeDisplaysModes}");

            for (int i = 0; i < numOfTypeDisplaysModes; ++i)
            {
                Sdl.GetDisplayMode(displayIndex, i, out DisplayMode displayMode);
                Console.WriteLine($"Display {displayIndex} Mode [{i}]: {displayMode.format}, {displayMode.w}, {displayMode.h}, {displayMode.refresh_rate}");
            }

            // SET DISPLAY MODE
            Sdl.GetDisplayMode(displayIndex, 0, out DisplayMode displayMode2);
            Console.WriteLine($"Display {displayIndex} SELECTED Mode: {displayMode2.format}, {displayMode2.w}, {displayMode2.h}, {displayMode2.refresh_rate}");
            Sdl.SetWindowDisplayMode(_window, ref displayMode2);

            if ((string.IsNullOrEmpty(VideoGame.Instance.Settings.General.Icon) == false) && File.Exists(VideoGame.Instance.Settings.General.Icon))
            {
                IntPtr icon = Sdl.LoadBmp(VideoGame.Instance.Settings.General.Icon);
                Sdl.SetWindowIcon(_window, icon);
            }

            // INIT SDL_TTF
            Console.WriteLine(SdlTtf.Init() < 0 ? $"There was an issue initializing SDL_TTF. {Sdl.GetError()}" : "SDL_TTF Initialized");

            // GET VERSION SDL_TTF
            Console.WriteLine($"SDL_TTF Version: {SdlTtf.GetVersion().major}.{SdlTtf.GetVersion().minor}.{SdlTtf.GetVersion().patch}");
            
            Console.WriteLine("End config SDL2");
        }

        /// <summary>
        ///     Attaches the sprite
        /// </summary>
        /// <param name="sprite">The sprite</param>
        public void Attach(Sprite sprite)
        {
            Sprites.Add(sprite);
            Sprites = Sprites.OrderBy(o => o.Depth).ToList();
        }

        /// <summary>
        ///     Uns the attach using the specified sprite
        /// </summary>
        /// <param name="sprite">The sprite</param>
        public void UnAttach(Sprite sprite)
        {
            Sprites.Remove(sprite);
            Sprites = Sprites.OrderBy(o => o.Depth).ToList();
        }

        /// <summary>
        ///     Attaches the collider
        /// </summary>
        /// <param name="collider">The collider</param>
        public void Attach(BoxCollider collider)
        {
            ColliderBases.Add(collider);
        }

        /// <summary>
        ///     Uns the attach using the specified collider
        /// </summary>
        /// <param name="collider">The collider</param>
        public void UnAttach(BoxCollider collider)
        {
            ColliderBases.Remove(collider);
        }
    }
}