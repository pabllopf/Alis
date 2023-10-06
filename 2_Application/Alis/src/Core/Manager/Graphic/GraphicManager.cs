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
using System.Linq;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Component.Render;
using Alis.Core.Graphic.SDL;
using Alis.Core.Graphic.SDL.Enums;
using Alis.Core.Graphic.SDL.Structs;
using Alis.Core.Aspect.Math.Figure.Rectangle;
using Alis.Core.Component.Collider;


namespace Alis.Core.Manager.Graphic
{
    /// <summary>
    ///     The graphic manager class
    /// </summary>
    /// <seealso cref="ManagerBase" />
    public class GraphicManager : GraphicManagerBase
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
        
        private static readonly BoxCollider[] colliderBases = new BoxCollider[128];
        
        private RectangleF[] rectangles = new RectangleF[colliderBases.Length];
        
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
        ///     Gets or sets the value of the colliders
        /// </summary>
        private static List<RectangleI> Colliders { get; } = new List<RectangleI>();
        
        /// <summary>
        ///     The blue
        /// </summary>
        private byte blue;

        /// <summary>
        ///     The blue
        /// </summary>
        private byte green;

        /// <summary>
        ///     The blue
        /// </summary>
        private byte red;
        
        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void Init()
        {
            Logger.Log("init::graphic:new");

            defaultSize = new Vector2(VideoGame.Setting.Graphic.Window.Resolution.X, VideoGame.Setting.Graphic.Window.Resolution.Y);
            
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
            Sdl.GlSetSwapInterval(1);
            
            // Create the window
            // create the window which should be able to have a valid OpenGL context and is resizable
            SdlWindowFlags flags = SdlWindowFlags.SdlWindowOpengl | SdlWindowFlags.SdlWindowResizable | SdlWindowFlags.SdlWindowShown;
            
            // Creates a new SDL window at the center of the screen with the given width and height.
            _window = Sdl.CreateWindow("Sample", Sdl.WindowPosCentered, Sdl.WindowPosCentered, (int) defaultSize.X, (int) defaultSize.Y, flags);
            
            // Check if the window was created successfully.
            Console.WriteLine(_window == IntPtr.Zero ? $"There was an issue creating the renderer. {Sdl.GetError()}" : $"Window created");
            
            // Create the renderer
            _renderer = Sdl.CreateRenderer(
                _window,
                -1,
                SdlRendererFlags.SdlRendererAccelerated |
                SdlRendererFlags.SdlRendererPresentvsync);
            
            // Check if the renderer was created successfully.
            Console.WriteLine(_renderer == IntPtr.Zero ? $"There was an issue creating the renderer. {Sdl.GetError()}" : $"Renderer created");
            
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
            }
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start() => Sprites = Sprites.OrderBy(o => o.Depth).ToList();

        /// <summary>
        /// Before the update
        /// </summary>
        public override void BeforeUpdate()
        {
            // Sets color to black (0, 0, 0, 255).
            Sdl.SetRenderDrawColor(_renderer, 0, 0, 0, 255);
            
            // Clears the current render surface.
            Sdl.RenderClear(_renderer);
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
            /*if (Sprites.Count <= 0 && Colliders.Count <= 0)
            {
                RenderSampleColor();
            }*/
            
            // Sets color to green (0, 255, 0, 255).
            Sdl.SetRenderDrawColor(_renderer, 0, 255, 0, 255);
            
            // Draws a rectangle outline
            
            for (int i=0;i < colliderBases.Length; i++) 
            {
                if (colliderBases[i] != null)
                {
                    rectangles[i] = colliderBases[i].RectangleF;
                }
            }

            Sdl.RenderDrawRectsF(_renderer, rectangles, rectangles.Length);
            
            Sdl.RenderPresent(_renderer);
        }

        /// <summary>
        /// Renders the sample color
        /// </summary>
        private void RenderSampleColor()
        {
            red += 1;
            if (red >= 255)
            {
                red -= 0;
            }

            green += 2;
            if (green >= 255)
            {
                green -= 1;
            }

            blue += 3;
            if (blue >= 255)
            {
                blue -= 1;
            }
            
            // Renders the current render surface to the screen.
            Sdl.SetRenderDrawColor(_renderer, red, green, blue, 255);
            
            // Clears the current render surface.
            Sdl.RenderClear(_renderer);
        }

        /// <summary>
        ///     Afters the update
        /// </summary>
        public override void AfterUpdate()
        {
            
            //Sdl.RenderPresent(_renderer);
        }

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public override void DispatchEvents()
        {
           
            
            
            
            /*if (Keyboard.IsKeyPressed(Key.LAlt) && Keyboard.IsKeyPressed(Key.Enter) && (Math.Abs(_renderWindow.Size.X - defaultSize.X) > 0.1) && (Math.Abs(_renderWindow.Size.Y - defaultSize.Y) > 0.1))
            {
                styles = Styles.Default;
                Logger.Log("Change style to default");
                InitRenderWindow();
                Task.Delay(100).Wait();
                return;
            }

            if (Keyboard.IsKeyPressed(Key.LAlt) && Keyboard.IsKeyPressed(Key.Enter) && (Math.Abs(_renderWindow.Size.X - defaultSize.X) < 0.1) && (Math.Abs(_renderWindow.Size.Y - defaultSize.Y) < 0.1))
            {
                styles = Styles.Fullscreen;
                Logger.Log("Change style to Fullscreen");
                InitRenderWindow();
                Task.Delay(100).Wait();
            }*/
        }

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void Exit()
        {
            Sdl.DestroyRenderer(_renderer);
            Sdl.DestroyWindow(_window);
            SdlImage.ImgQuit();
            Sdl.Quit();
        }
        
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
        ///     Attaches the collider using the specified shape
        /// </summary>
        /// <param name="colliderBase">The shape</param>
        public static void AttachCollider(BoxCollider colliderBase)
        {
            for (int i = 0; i < colliderBases.Length; i++)
            {
                if(colliderBases[i] == null)
                {
                    colliderBases[i] = colliderBase;
                    return;
                }
            }
        }
    }
}