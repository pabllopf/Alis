// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicManagerBase.cs
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
using System.Linq;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.System.Setting.Graphic;
using Alis.Core.Graphic.SDL;
using Alis.Core.Graphic.SDL.Enums;
using Alis.Core.Graphic.SDL.Structs;

namespace Alis.Core.Ecs.System.Manager.Graphic
{
    /// <summary>
    ///     The graphic manager base class
    /// </summary>
    /// <seealso cref="Manager" />
    public class GraphicManager : Manager, IGraphicManager
    {
        /// <summary>
        /// The window
        /// </summary>
        private static IntPtr _window;
        
        /// <summary>
        ///     The renderWindow
        /// </summary>
        private static IntPtr _renderer;
        
        /// <summary>
        /// The default size
        /// </summary>
        private Vector2 defaultSize; 
        
        /// <summary>
        /// The box collider
        /// </summary>
        private static readonly BoxCollider[] ColliderBases = new BoxCollider[128];
        
        /// <summary>
        /// The length
        /// </summary>
        private readonly RectangleF[] rectangles = new RectangleF[ColliderBases.Length];
        
        /// <summary>
        ///     Gets or sets the value of the sprites
        /// </summary>
        private static List<Sprite> Sprites { get; set; } = new List<Sprite>();
        
        /// <summary>
        /// Ons the enable
        /// </summary>
        public override void OnEnable()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the init
        /// </summary>
        public override void OnInit()
        {
            Logger.Log("init::graphic:new");

            defaultSize = new Vector2(1024, 640);
            
            InitRenderWindow();
        }
        
        /// <summary>
        ///     Inits the render window
        /// </summary>
        private void InitRenderWindow()
        { 
            if (Sdl.Init(Sdl.InitEverything) < 0)
            {
                Console.WriteLine($@"There was an issue initializing SDL. {Sdl.GetError()}");
            }

            // GET VERSION SDL2
            Sdl.GetVersion(out SdlVersion version);
            Console.WriteLine(@$"SDL2 VERSION {version.major}.{version.minor}.{version.patch}");
            
            /*
            // CONFIG THE SDL2 AN OPENGL CONFIGURATION
            Sdl.GlSetAttributeByInt(SdlGlAttr.SdlGlContextFlags, (int) SdlGlContext.SdlGlContextForwardCompatibleFlag);
            Sdl.GlSetAttributeByProfile(SdlGlAttr.SdlGlContextProfileMask, SdlGlProfile.SdlGlContextProfileCore);
            Sdl.GlSetAttributeByInt(SdlGlAttr.SdlGlContextMajorVersion, 3);
            Sdl.GlSetAttributeByInt(SdlGlAttr.SdlGlContextMinorVersion, 2);

            Sdl.GlSetAttributeByProfile(SdlGlAttr.SdlGlContextProfileMask, SdlGlProfile.SdlGlContextProfileCore);
            Sdl.GlSetAttributeByInt(SdlGlAttr.SdlGlDoubleBuffer, 1);
            Sdl.GlSetAttributeByInt(SdlGlAttr.SdlGlDepthSize, 24);
            Sdl.GlSetAttributeByInt(SdlGlAttr.SdlGlAlphaSize, 8);
            Sdl.GlSetAttributeByInt(SdlGlAttr.SdlGlStencilSize, 8);

            // Enable vsync
            Sdl.GlSetSwapInterval(1);*/

            if(EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.Windows)
            {
                Sdl.SetHint(Sdl.HintRenderDriver, "direct3d");
            }
            if(EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.OSX)
            {
                Sdl.SetHint(Sdl.HintRenderDriver, "opengl");
            }
            if(EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.Linux)
            {
                Sdl.SetHint(Sdl.HintRenderDriver, "opengl");
            }
            
            // Create the window
            // create the window which should be able to have a valid OpenGL context and is resizable
            SdlWindowFlags flags = SdlWindowFlags.SdlWindowResizable | SdlWindowFlags.SdlWindowShown;
            
            // Creates a new SDL window at the center of the screen with the given width and height.
            _window = Sdl.CreateWindow("Sample", Sdl.WindowPosCentered, Sdl.WindowPosCentered, (int) defaultSize.X, (int) defaultSize.Y, flags);
            
            // Check if the window was created successfully.
            Console.WriteLine(_window == IntPtr.Zero ? $"There was an issue creating the renderer. {Sdl.GetError()}" : $"Window created");
            
            // Create the renderer
            _renderer = Sdl.CreateRenderer(
                _window,
                -1,
                SdlRendererFlags.SdlRendererAccelerated  );
            
            
            // Check if the renderer was created successfully.
            Console.WriteLine(_renderer == IntPtr.Zero ? $"There was an issue creating the renderer. {Sdl.GetError()}" : $"Renderer created");
            
            int totalDisplays = Sdl.GetNumVideoDisplays();
            Console.WriteLine($"Total Displays: {totalDisplays}");
            
            for (int i = 0; i < totalDisplays; ++i)
            {
                Console.WriteLine($"Display {i}: {Sdl.GetDisplayName(i)}");
                
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
            Sdl.GetRendererInfo(_renderer, out SdlRendererInfo rendererInfo);
            Console.WriteLine($"Renderer Name: {rendererInfo.name} \n" +
                              $"Renderer Flags: {rendererInfo.flags} \n" +
                              $"Max Texture Width: {rendererInfo.max_texture_width} \n" +
                              $"Max Texture Height: {rendererInfo.max_texture_height} + \n" +
                              $"Max Texture Width: {rendererInfo.max_texture_width} \n" +
                              $"Max Texture Height: {rendererInfo.max_texture_height}");
            
            // GET RENDERER OUTPUT SIZE
            Sdl.GetRendererOutputSize(_renderer, out int w, out int h);
            Console.WriteLine($"Renderer Output Size: {w}, {h}");
            
            // GET RENDERER LOGICAL SIZE
            Sdl.RenderGetLogicalSize(_renderer, out int w2, out int h2);
            Console.WriteLine($"Renderer Logical Size: {w2}, {h2}");
            
            // GET RENDERER SCALE
            Sdl.RenderGetScale(_renderer, out float scaleX, out float scaleY);
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
                Sdl.GetDisplayMode(displayIndex, i, out SdlDisplayMode displayMode);
                Console.WriteLine($"Display {displayIndex} Mode [{i}]: {displayMode.format}, {displayMode.w}, {displayMode.h}, {displayMode.refresh_rate}");
            }
            
            // SET DISPLAY MODE
            Sdl.GetDisplayMode(displayIndex, 0, out SdlDisplayMode displayMode2);
            Console.WriteLine($"Display {displayIndex} SELECTED Mode: {displayMode2.format}, {displayMode2.w}, {displayMode2.h}, {displayMode2.refresh_rate}");
            Sdl.SetWindowDisplayMode(_window, ref displayMode2);
            
            
            
            /*
            // INIT SDL_IMAGE FLAGS
            ImgInitFlags flagImage = ImgInitFlags.ImgInitPng | ImgInitFlags.ImgInitJpg | ImgInitFlags.ImgInitTif | ImgInitFlags.ImgInitWebp;
            
            // INIT SDL_IMAGE
            Console.WriteLine(SdlImage.ImgInit(flagImage) < 0 ? $"There was an issue initializing SDL_Image. {Sdl.GetError()}" : $"SDL_Image Initialized");
            
            // GET VERSION SDL_IMAGE
            Console.WriteLine($"SDL_Image Version: {SdlImage.SdlImageVersion().major}.{SdlImage.SdlImageVersion().minor}.{SdlImage.SdlImageVersion().patch}");
            
            Sdl.SetHint(Sdl.HintXInputEnabled, "0");
            Sdl.SetHint(Sdl.SdlHintJoystickThread, "1");
            Sdl.Init(Sdl.InitEverything);
            
            for (int i = 0; i < Sdl.NumJoysticks(); i++)
            {
                IntPtr myJoystick = Sdl.JoystickOpen(i);
                if (myJoystick == IntPtr.Zero)
                { 
                    Console.WriteLine($" Error opening SDL_JoystickName_id = '{i}'");
                }
                else
                {
                    Console.WriteLine($"[SDL_JoystickName_id = '{i}'] \n" +
                                      $"SDL_JoystickName={Sdl.JoystickName(myJoystick)} \n" +
                                      $"SDL_JoystickNumAxes={Sdl.JoystickNumAxes(myJoystick)} \n" +
                                      $"SDL_JoystickNumButtons={Sdl.JoystickNumButtons(myJoystick)}");
                }
            }*/
        }

        /// <summary>
        /// Ons the awake
        /// </summary>
        public override void OnAwake()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the start
        /// </summary>
        public override void OnStart()
        {
            Logger.Trace();
            Sprites = Sprites.OrderBy(o => o.Depth).ToList();
        }

        /// <summary>
        /// Ons the before update
        /// </summary>
        public override void OnBeforeUpdate()
        {
            Logger.Trace();
            
            // Sets color to black (0, 0, 0, 255).
            Sdl.SetRenderDrawColor(_renderer, 0, 0, 0, 255);
            
            // Clears the current render surface.
            Sdl.RenderClear(_renderer);
        }

        /// <summary>
        /// Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            Logger.Trace();
            
            // Sets color to green (0, 255, 0, 255).
            Sdl.SetRenderDrawColor(_renderer, 0, 255, 0, 255);
            
            // Draws a rectangle outline
            
            for (int i=0;i < ColliderBases.Length; i++) 
            {
                if (ColliderBases[i] != null)
                {
                    rectangles[i] = ColliderBases[i].RectangleF;
                }
            }

            Sdl.RenderDrawRectsF(_renderer, rectangles, rectangles.Length);
            
            Sdl.RenderPresent(_renderer);
        }

        /// <summary>
        /// Ons the after update
        /// </summary>
        public override void OnAfterUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the before fixed update
        /// </summary>
        public override void OnBeforeFixedUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the fixed update
        /// </summary>
        public override void OnFixedUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the after fixed update
        /// </summary>
        public override void OnAfterFixedUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the dispatch events
        /// </summary>
        public override void OnDispatchEvents()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the calculate
        /// </summary>
        public override void OnCalculate()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the draw
        /// </summary>
        public override void OnDraw()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the gui
        /// </summary>
        public override void OnGui()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the disable
        /// </summary>
        public override void OnDisable()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the reset
        /// </summary>
        public override void OnReset()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the stop
        /// </summary>
        public override void OnStop()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Ons the exit
        /// </summary>
        public override void OnExit()
        {
            Logger.Trace();
            
            Sdl.DestroyRenderer(_renderer);
            Sdl.DestroyWindow(_window);
            SdlImage.ImgQuit();
            Sdl.Quit();
        }

        /// <summary>
        /// Ons the destroy
        /// </summary>
        public override void OnDestroy()
        {
            Logger.Trace();
        }

        /// <summary>
        /// Gets or sets the value of the setting
        /// </summary>
        public IGraphicSetting Setting { get; set; }
        
        /// <summary>
        ///     Attaches the sprite
        /// </summary>
        /// <param name="sprite">The sprite</param>
        public static void Attach(Sprite sprite)
        {
            Sprites.Add(sprite);
            Sprites = Sprites.OrderBy(o => o.Depth).ToList();
        }

        /// <summary>
        ///     Uns the attach using the specified sprite
        /// </summary>
        /// <param name="sprite">The sprite</param>
        public static void UnAttach(Sprite sprite)
        {
            Sprites.Remove(sprite);
            Sprites = Sprites.OrderBy(o => o.Depth).ToList();
        }
        
        /// <summary>
        /// Attaches the collider
        /// </summary>
        /// <param name="collider">The collider</param>
        public void Attach(BoxCollider collider)
        {
            for (int i = 0; i < ColliderBases.Length; i++)
            {
                if(ColliderBases[i] == null)
                {
                    ColliderBases[i] = collider;
                    return;
                }
            }
        }

        /// <summary>
        /// Uns the attach using the specified collider
        /// </summary>
        /// <param name="collider">The collider</param>
        public static void UnAttach(Collider collider)
        {
            
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="GraphicManager" /> class
        /// </summary>
        public GraphicManager()
        {
        }
    }
}