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
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.System.Setting;
using Alis.Core.Ecs.System.Setting.Physic;
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
    /// <seealso cref="AManager" />
    public class GraphicManager : AManager
    {
        /// <summary>
        ///     The pixels per meter
        /// </summary>
        private const float PixelsPerMeter = 32.0f;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GraphicManager" /> class
        /// </summary>
        public GraphicManager()
        {
            ColliderBases = new List<BoxCollider>();
            Sprites = new List<Sprite>();
            Cameras = new List<Camera>();
            Window = IntPtr.Zero;
            Renderer = IntPtr.Zero;
            DefaultSize = new Vector2(640, 480);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GraphicManager" /> class
        /// </summary>
        /// <param name="colliderBases">The collider bases</param>
        /// <param name="window">The window</param>
        /// <param name="defaultSize">The default size</param>
        /// <param name="renderer">The renderer</param>
        /// <param name="sprites">The sprites</param>
        /// <param name="cameras">The cameras</param>
        [JsonConstructor]
        public GraphicManager(List<BoxCollider> colliderBases, IntPtr window, Vector2 defaultSize, IntPtr renderer, List<Sprite> sprites, List<Camera> cameras)
        {
            ColliderBases = colliderBases;
            Window = window;
            DefaultSize = defaultSize;
            Renderer = renderer;
            Sprites = sprites;
            Cameras = cameras;
        }

        /// <summary>
        ///     The box collider
        /// </summary>
        [JsonPropertyName("_ColliderBases_")]
        public List<BoxCollider> ColliderBases { get; set; }

        /// <summary>
        ///     The window
        /// </summary>
        [JsonPropertyName("_Window_", true, true)]
        public IntPtr Window { get; set; }

        /// <summary>
        ///     The default size
        /// </summary>
        [JsonPropertyName("_DefaultSize_")]
        public Vector2 DefaultSize { get; set; }

        /// <summary>
        ///     The renderWindow
        /// </summary>
        [JsonPropertyName("_Renderer_", true, true)]
        public IntPtr Renderer { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sprites
        /// </summary>
        [JsonPropertyName("_Sprites_")]
        public List<Sprite> Sprites { get; set; }

        /// <summary>
        ///     Gets or sets the value of the cameras
        /// </summary>
        [JsonPropertyName("_Cameras_")]
        public List<Camera> Cameras { get; }

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
            if (Context is null)
            {
                return;
            }

            Logger.Log("init::graphic:new");

            DefaultSize = new Vector2(Context.Settings.Graphic.Window.Resolution.X, Context.Settings.Graphic.Window.Resolution.Y);

            if (Sdl.Init(InitSettings.InitEverything) < 0)
            {
                Logger.Info($@"There was an issue initializing SDL. {Sdl.GetError()}");
            }

            // GET VERSION SDL2
            Version version = Sdl.GetVersion();
            Logger.Info(@$"SDL2 VERSION {version.major}.{version.minor}.{version.patch}");

            // Enable vsync
            Sdl.SetSwapInterval(1);
            Sdl.SetHint(Hint.HintRenderDriver, "opengl");

            // Create the window
            // create the window which should be able to have a valid OpenGL context and is resizable
            WindowSettings flags = WindowSettings.WindowShown;

            if (Context.Settings.Graphic.Window.IsWindowResizable)
            {
                flags |= WindowSettings.WindowResizable;
            }

            // Creates a new SDL window at the center of the screen with the given width and height.
            Window = Sdl.CreateWindow(Context.Settings.General.Name, (int) WindowPos.WindowPosCentered, (int) WindowPos.WindowPosCentered, (int) DefaultSize.X, (int) DefaultSize.Y, flags);

            // Check if the window was created successfully.
            Logger.Info(Window == IntPtr.Zero ? $"There was an issue creating the renderer. {Sdl.GetError()}" : "Window created");

            // Create the renderer
            Renderer = Sdl.CreateRenderer(
                Window,
                -1,
                Renderers.SdlRendererAccelerated);

            // Check if the renderer was created successfully.
            Logger.Info(Renderer == IntPtr.Zero ? $"There was an issue creating the renderer. {Sdl.GetError()}" : "Renderer created");

            int totalDisplays = Sdl.GetNumVideoDisplays();
            Logger.Info($"Total Displays: {totalDisplays}");

            for (int i = 0; i < totalDisplays; ++i)
            {
                string displayName = Sdl.GetDisplayName(i + 1);
                Logger.Info($"Display {i}: {displayName}");

                // GET DISPLAY BOUNDS
                Sdl.GetDisplayBounds(i, out RectangleI displayBounds);
                Logger.Info($"Display [{i}] Bounds: {displayBounds.X}, {displayBounds.Y}, {displayBounds.W}, {displayBounds.H}");
            }

            int totalDrivers = Sdl.GetNumRenderDrivers();
            Logger.Info($"Total Render Drivers: {totalDrivers}");

            for (int i = 0; i < totalDrivers; ++i)
            {
                Logger.Info($"Driver {i}: {Sdl.GetVideoDriver(i)}");
            }

            // GET RENDERER INFO
            Sdl.GetRendererInfo(Renderer, out RendererInfo rendererInfo);
            Logger.Info($"Renderer Name: {rendererInfo.GetName()} \n" +
                        $"Renderer Flags: {rendererInfo.flags} \n" +
                        $"Max Texture Width: {rendererInfo.maxTextureWidth} \n" +
                        $"Max Texture Height: {rendererInfo.maxTextureHeight} + \n" +
                        $"Max Texture Width: {rendererInfo.maxTextureWidth} \n" +
                        $"Max Texture Height: {rendererInfo.maxTextureHeight}");

            // GET RENDERER OUTPUT SIZE
            Sdl.GetRendererOutputSize(Renderer, out int w, out int h);
            Logger.Info($"Renderer Output Size: {w}, {h}");

            // GET RENDERER LOGICAL SIZE
            Sdl.RenderGetLogicalSize(Renderer, out int w2, out int h2);
            Logger.Info($"Renderer Logical Size: {w2}, {h2}");

            // GET RENDERER SCALE
            Sdl.RenderGetScale(Renderer, out float scaleX, out float scaleY);
            Logger.Info($"Renderer Scale: {scaleX}, {scaleY}");


            uint windowHandle = Sdl.GetWindowId(Window);
            Logger.Info($"Window Handle: {windowHandle}");

            int numberOfDisplays = Sdl.GetNumVideoDisplays();
            Logger.Info($"Number of Displays: {numberOfDisplays}");

            int displayIndex = Sdl.GetWindowDisplayIndex(Window);
            Logger.Info($"Display Index: {displayIndex}");

            int numOfTypeDisplaysModes = Sdl.GetNumDisplayModes(displayIndex);
            Logger.Info($"Number of Type Displays Modes: {numOfTypeDisplaysModes}");

            for (int i = 0; i < numOfTypeDisplaysModes; ++i)
            {
                Sdl.GetDisplayMode(displayIndex, i, out DisplayMode displayMode);
                Logger.Info($"Display {displayIndex} Mode [{i}]: {displayMode.format}, {displayMode.w}, {displayMode.h}, {displayMode.refresh_rate}");
            }

            // SET DISPLAY MODE
            Sdl.GetDisplayMode(displayIndex, 0, out DisplayMode displayMode2);
            Logger.Info($"Display {displayIndex} SELECTED Mode: {displayMode2.format}, {displayMode2.w}, {displayMode2.h}, {displayMode2.refresh_rate}");
            Sdl.SetWindowDisplayMode(Window, ref displayMode2);


            if (!string.IsNullOrEmpty(Context.Settings.General.Icon))
            {
                IntPtr icon = Sdl.LoadBmp(Context.Settings.General.Icon);
                Sdl.SetWindowIcon(Window, icon);
            }

            // INIT SDL_TTF
            Logger.Info(SdlTtf.Init() < 0 ? $"There was an issue initializing SDL_TTF. {Sdl.GetError()}" : "SDL_TTF Initialized");

            // GET VERSION SDL_TTF
            Logger.Info($"SDL_TTF Version: {SdlTtf.GetVersion().major}.{SdlTtf.GetVersion().minor}.{SdlTtf.GetVersion().patch}");

            Logger.Info("End config SDL2");
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
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            if (Context is null)
            {
                return;
            }

            float pixelsPerMeter = PixelsPerMeter;
            IntPtr renderer = Renderer;
            Settings contextSettings = Context.Settings;
            PhysicSetting physicSettings = contextSettings.Physic;
            Color debugColor = physicSettings.DebugColor;

            foreach (Camera camera in Cameras)
            {
                if (!camera.IsEnable) continue;

                IntPtr cameraTexture = camera.TextureTarget;
                Color bgColor = camera.BackgroundColor;
                Vector2 cameraPosition = camera.Position;
                Vector2 cameraResolution = camera.Resolution;

                Sdl.SetRenderTarget(renderer, cameraTexture);
                Sdl.SetRenderDrawColor(renderer, bgColor.R, bgColor.G, bgColor.B, bgColor.A);
                Sdl.RenderClear(renderer);

                // Render sprites
                foreach (Sprite sprite in Sprites)
                {
                    if (sprite.IsEnable && sprite.GameObject.IsEnable && sprite.IsVisible(cameraPosition, cameraResolution, pixelsPerMeter))
                    {
                        sprite.Render(renderer, cameraPosition, cameraResolution, pixelsPerMeter);
                    }
                }

                // Render colliders
                Sdl.SetRenderDrawColor(renderer, debugColor.R, debugColor.G, debugColor.B, debugColor.A);

                foreach (BoxCollider collider in ColliderBases)
                {
                    if (collider.IsEnable && collider.GameObject.IsEnable && collider.IsVisible(cameraPosition, cameraResolution, pixelsPerMeter))
                    {
                        collider.Render(renderer, cameraPosition, cameraResolution, pixelsPerMeter, debugColor);
                    }
                }

                Sdl.SetRenderTarget(renderer, IntPtr.Zero);

                // Copy the custom backbuffer to the SDL backbuffer with vertical flip
                Sdl.RenderCopyEx(renderer, cameraTexture, IntPtr.Zero, IntPtr.Zero, 0, IntPtr.Zero, RendererFlips.FlipVertical);
            }

            Sdl.RenderPresent(renderer);
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
        ///     Attaches the camera
        /// </summary>
        /// <param name="camera">The camera</param>
        public void Attach(Camera camera)
        {
            Cameras.Add(camera);
        }

        /// <summary>
        ///     Uns the attach using the specified collider
        /// </summary>
        /// <param name="collider">The collider</param>
        public void UnAttach(BoxCollider collider)
        {
            ColliderBases.Remove(collider);
        }

        /// <summary>
        ///     Uns the attach using the specified camera
        /// </summary>
        /// <param name="camera">The camera</param>
        public void UnAttach(Camera camera)
        {
            Cameras.Remove(camera);
        }
    }
}