// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: GraphicManager.cs
// 
//  Author: Pablo Perdomo Falcón
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
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.System.Setting.Graphic;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Alis.Core.Graphic.Sdl2Image;
using Alis.Core.Graphic.Sdl2Ttf;

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
            Sprites = Sprites.OrderBy(o => o.Depth).ToList();

            // Draws sprites:
            foreach (Sprite sprite in Sprites.Where(sprite => sprite.Image != null))
            {
                // get position of the sprite
                int x = (int) sprite.GameObject.Transform.Position.X;
                int y = (int) sprite.GameObject.Transform.Position.Y;

                // get the size of sprite.Image.Texture
                Sdl.QueryTexture(sprite.Image.Texture, out _, out _, out int w, out int h);

                // create a destination intPtr dstRect
                RectangleI dstRect = new RectangleI(x - w / 2, y - h / 2,
                    (int) (w * sprite.GameObject.Transform.Scale.X),
                    (int) (h * sprite.GameObject.Transform.Scale.Y));

                // render the texture to the screen
                Sdl.RenderCopyEx(Renderer, sprite.Image.Texture, IntPtr.Zero, ref dstRect, sprite.GameObject.Transform.Rotation.angle, IntPtr.Zero, SdlRendererFlip.None);
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
            SdlImage.ImgQuit();
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

            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.Windows)
            {
                Sdl.SetHint(Sdl.HintRenderDriver, "direct3d");
            }

            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.OSX)
            {
                Sdl.SetHint(Sdl.HintRenderDriver, "opengl");
            }

            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.Linux)
            {
                Sdl.SetHint(Sdl.HintRenderDriver, "opengl");
            }


            // Create the window
            // create the window which should be able to have a valid OpenGL context and is resizable
            SdlWindowFlags flags = SdlWindowFlags.SdlWindowShown;

            if (VideoGame.Instance.Settings.Graphic.Window.IsWindowResizable)
            {
                flags |= SdlWindowFlags.SdlWindowResizable;
            }

            // Creates a new SDL window at the center of the screen with the given width and height.
            _window = Sdl.CreateWindow(VideoGame.Instance.Settings.General.Name, Sdl.WindowPosCentered, Sdl.WindowPosCentered, (int) defaultSize.X, (int) defaultSize.Y, flags);

            // Check if the window was created successfully.
            Console.WriteLine(_window == IntPtr.Zero ? $"There was an issue creating the renderer. {Sdl.GetError()}" : "Window created");

            // Create the renderer
            Renderer = Sdl.CreateRenderer(
                _window,
                -1,
                SdlRendererFlags.SdlRendererAccelerated);


            // Check if the renderer was created successfully.
            Console.WriteLine(Renderer == IntPtr.Zero ? $"There was an issue creating the renderer. {Sdl.GetError()}" : "Renderer created");

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
            Sdl.GetRendererInfo(Renderer, out SdlRendererInfo rendererInfo);
            Console.WriteLine($"Renderer Name: {rendererInfo.GetName()} \n" +
                              $"Renderer Flags: {rendererInfo.flags} \n" +
                              $"Max Texture Width: {rendererInfo.max_texture_width} \n" +
                              $"Max Texture Height: {rendererInfo.max_texture_height} + \n" +
                              $"Max Texture Width: {rendererInfo.max_texture_width} \n" +
                              $"Max Texture Height: {rendererInfo.max_texture_height}");

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
                Sdl.GetDisplayMode(displayIndex, i, out SdlDisplayMode displayMode);
                Console.WriteLine($"Display {displayIndex} Mode [{i}]: {displayMode.format}, {displayMode.w}, {displayMode.h}, {displayMode.refresh_rate}");
            }

            // SET DISPLAY MODE
            Sdl.GetDisplayMode(displayIndex, 0, out SdlDisplayMode displayMode2);
            Console.WriteLine($"Display {displayIndex} SELECTED Mode: {displayMode2.format}, {displayMode2.w}, {displayMode2.h}, {displayMode2.refresh_rate}");
            Sdl.SetWindowDisplayMode(_window, ref displayMode2);

            if ((string.IsNullOrEmpty(VideoGame.Instance.Settings.General.Icon) == false) && File.Exists(VideoGame.Instance.Settings.General.Icon))
            {
                IntPtr icon = SdlImage.ImgLoad(VideoGame.Instance.Settings.General.Icon);
                Sdl.SetWindowIcon(_window, icon);
            }
            
            // INIT SDL_IMAGE FLAGS
            ImgInitFlags flagImage = ImgInitFlags.ImgInitPng | ImgInitFlags.ImgInitJpg | ImgInitFlags.ImgInitTif | ImgInitFlags.ImgInitWebp;

            // INIT SDL_IMAGE
            Console.WriteLine(SdlImage.ImgInit(flagImage) < 0 ? $"There was an issue initializing SDL_Image. {Sdl.GetError()}" : "SDL_Image Initialized");

            // GET VERSION SDL_IMAGE
            Console.WriteLine($"SDL_Image Version: {SdlImage.GetVersion().major}.{SdlImage.GetVersion().minor}.{SdlImage.GetVersion().patch}");

            // INIT SDL_TTF
            Console.WriteLine(SdlTtf.TtfInit() < 0 ? $"There was an issue initializing SDL_TTF. {Sdl.GetError()}" : "SDL_TTF Initialized");

            // GET VERSION SDL_TTF
            Console.WriteLine($"SDL_TTF Version: {SdlTtf.GetTtfVersion().major}.{SdlTtf.GetTtfVersion().minor}.{SdlTtf.GetTtfVersion().patch}");

            /*

            int outlineSize = 1;

            // Load the font
            IntPtr font = SdlTtf.TtfOpenFont(AssetManager.Find("Crackman Front.otf"), 55);

            // Load the font
            IntPtr font_outline = SdlTtf.TtfOpenFont(AssetManager.Find("Crackman Front.otf"), 55);

            // define outline font
            SdlTtf.TtfSetFontOutline(font, outlineSize);

            // define style font
            SdlTtf.TtfSetFontStyle(font, SdlTtf.TtfStyleNormal);

            // Pixels to render the text
            IntPtr bg_surface = SdlTtf.TtfRenderTextBlended(
                font_outline,
                "0123456789",
                new SdlColor(255, 255, 255, 255));

            IntPtr fg_surface = SdlTtf.TtfRenderTextBlended(
                font,
                "0123456789",
                new SdlColor(84, 52, 68, 255));

            // get size fg_surface
            //SDL_QueryTexture(fg_surface, NULL, NULL, &w, &h); :
            Sdl.QueryTexture(fg_surface, out _, out _, out int wOut, out int hOut);

            //SDL_Rect rect = {OUTLINE_SIZE, OUTLINE_SIZE, fg_surface->w, fg_surface->h};
            RectangleI rect = new RectangleI(0, 0, wOut, hOut);

            //SDL_SetSurfaceBlendMode(fg_surface, SDL_BLENDMODE_BLEND); :
            Sdl.SetSurfaceBlendMode(fg_surface, SdlBlendMode.SdlBlendModeBlend);

            //SDL_BlitSurface(fg_surface, NULL, bg_surface, &rect);
            Sdl.BlitSurface(fg_surface, IntPtr.Zero, bg_surface, ref rect);

            //SDL_FreeSurface(fg_surface);
            Sdl.FreeSurface(fg_surface);


            // surface without alpha
            //Sdl.SetSurfaceBlendMode(surface, SdlBlendMode.SdlBlendModeBlend);

            // Create a texture from the surface
            textureFont1 = Sdl.CreateTextureFromSurface(Renderer, bg_surface);

            // define alpha of the texture
            //Sdl.SetTextureAlphaMod(textureFont1, 255);

            // Get the width and height of the texture
            Sdl.QueryTexture(textureFont1, out _, out _, out int textureWidth, out int textureHeight);

            // Create a destination intPtr dstRect
            dstRectFont1 = new RectangleI(0, 0, textureWidth, textureHeight);

            */

            /*
            Console.WriteLine(Sdl.Init(Sdl.InitAudio) < 0 ? $@"There was an issue initializing SDL AUDIO. {Sdl.GetError()}" : "SDL2 AUDIO INIT OK");


            SdlAudioSpec spec;
            IntPtr audiobuf;
            uint audioLen;

            IntPtr audio_loaded = Sdl.LoadWav(
                AssetManager.Find("main_theme.wav"),
                out spec,
                out audiobuf,
                out audioLen);

            // open audio device



            string audioDevice = "";

            int count = Sdl.GetNumAudioDevices(0);
            for (int i = 0; i < count; i++)
            {
                audioDevice = Sdl.GetAudioDeviceName(0, 0);
                Console.WriteLine($"Device id={i} name={audioDevice}");
            }

            uint device = Sdl.SdlOpenAudioDevice(audioDevice, 0, ref spec, out SdlAudioSpec specOut ,0);

            int success = Sdl.SdlQueueAudio(device, audiobuf, audioLen);
            Sdl.SdlPauseAudioDevice(device, 0);

            Sdl.Delay(4000);

            Sdl.CloseAudioDevice(device);
            Sdl.FreeWav(audiobuf);*/

            /*
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