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
using System.Diagnostics;
using System.Linq;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Ecs.System.Configuration;
using Alis.Core.Ecs.System.Configuration.Physic;
using Alis.Core.Ecs.System.Scope;
using Alis.Core.Graphic.Fonts;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
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
        /// The world position
        /// </summary>
        public Vector2F worldPosition;

        /// <summary>
        ///     The pixels per meter
        /// </summary>
        private const float PixelsPerMeter = 32.0f;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GraphicManager" /> class
        /// </summary>
        public GraphicManager(Context context) : base(context)
        {
            ColliderBases = new List<BoxCollider>();
            Sprites = new List<Sprite>();
            Cameras = new List<Camera>();
            Window = IntPtr.Zero;
            Renderer = IntPtr.Zero;
            DefaultSize = new Vector2F(640, 480);
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
        /// <param name="context"></param>
        [JsonConstructor]
        public GraphicManager(List<BoxCollider> colliderBases, IntPtr window, Vector2F defaultSize, IntPtr renderer, List<Sprite> sprites, List<Camera> cameras, Context context) : base(context)
        {
            ColliderBases = colliderBases;
            Window = window;
            DefaultSize = defaultSize;
            Renderer = renderer;
            Sprites = sprites;
            Cameras = cameras;
        }

        /// <summary>
        ///     Gets or sets the value of the font manager
        /// </summary>
        public FontManager FontManager { get; set; }

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
        public Vector2F DefaultSize { get; set; }

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
            /*
            _context.GraphicManager.Window = Sdl.CreateWindow("Game Preview",
                0, 0,
                800, 600,
                WindowSettings.WindowResizable | WindowSettings.WindowHidden );
            _context.GraphicManager.Renderer = Sdl.CreateRenderer(_context.GraphicManager.Window, -1,
                Renderers.SdlRendererAccelerated | Renderers.SdlRendererTargetTexture);*/

            if (Context is null)
            {
                return;
            }

            Logger.Log("init::graphic:new");

            DefaultSize = new Vector2F(Context.Setting.Graphic.Window.Resolution.X, Context.Setting.Graphic.Window.Resolution.Y);

            if (Sdl.Init(InitSettings.InitEverything) < 0)
            {
                Logger.Info($@"There was an issue initializing SDL. {Sdl.GetError()}");
            }

            // GET VERSION SDL2
            Version version = Sdl.GetVersion();
            Logger.Info(@$"SDL2 VERSION {version.major}.{version.minor}.{version.patch}");

            // Enable vsync
            //Sdl.SetSwapInterval(1);
            //Sdl.SetHint(Hint.HintRenderDriver, "opengl");

            // Create the window
            // create the window which should be able to have a valid OpenGL context and is resizable
            WindowSettings flags = WindowSettings.WindowShown;

            if (Context.Setting.Graphic.Window.IsWindowResizable)
            {
                flags |= WindowSettings.WindowResizable;
            }

            if (Context.Setting.Graphic.PreviewMode)
            {
                flags = WindowSettings.WindowHidden;
            }

            // Creates a new SDL window at the center of the screen with the given width and height.
            Window = Sdl.CreateWindow(Context.Setting.General.Name, (int) WindowPos.WindowPosCentered, (int) WindowPos.WindowPosCentered, (int) DefaultSize.X, (int) DefaultSize.Y, flags);

            // Check if the window was created successfully.
            Logger.Info(Window == IntPtr.Zero ? $"There was an issue creating the renderer. {Sdl.GetError()}" : "Window created");

            Renderers renderFlags = Renderers.SdlRendererAccelerated;

            if (Context.Setting.Graphic.PreviewMode)
            {
                renderFlags |= Renderers.SdlRendererTargetTexture;
            }

            // Create the renderer
            Renderer = Sdl.CreateRenderer(
                Window,
                -1,
                renderFlags);

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


            if (!string.IsNullOrEmpty(Context.Setting.General.Icon))
            {
                
                IntPtr icon = Sdl.LoadBmp(AssetManager.Find(Context.Setting.General.Icon));
                Sdl.SetWindowIcon(Window, icon);
            }

            Logger.Info("End config SDL2");

            FontManager = new FontManager(Renderer, RendererFlips.None);
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart() => Sprites = Sprites.OrderBy(o => o.Depth).ToList();

        /// <summary>
        ///     Ons the before draw
        /// </summary>
        public override void OnBeforeDraw()
        {
        }

        /// <summary>
        ///     Ons the draw
        /// </summary>
        public override void OnDraw()
        {
            float pixelsPerMeter = PixelsPerMeter;
            IntPtr renderer = Renderer;
            Setting contextSetting = Context.Setting;
            PhysicSetting physicSettings = contextSetting.Physic;
            Color debugColor = physicSettings.DebugColor;

            if (Cameras.Count == 0)
            {
                Logger.Warning($"There are no cameras to render on the screen in the graphic manager for scene {Context.SceneManager.CurrentScene.Name}");
                return;
            }

            foreach (Camera camera in Cameras)
            {
                if (!camera.IsEnable)
                {
                    continue;
                }

                IntPtr cameraTexture = camera.TextureTarget;
                Color bgColor = camera.BackgroundColor;
                Vector2F cameraPosition = camera.Position;
                Vector2F cameraResolution = camera.Resolution;

                Sdl.SetRenderTarget(renderer, cameraTexture);
                Sdl.SetRenderDrawColor(renderer, bgColor.R, bgColor.G, bgColor.B, bgColor.A);
                Sdl.RenderClear(renderer);

                // Render sprites
                foreach (Sprite sprite in Sprites.OrderBy(o => o.Depth))
                {
                    if (sprite.IsEnable && sprite.GameObject.IsEnable && sprite.IsVisible(cameraPosition, cameraResolution, pixelsPerMeter))
                    {
                        sprite.Render(renderer, cameraPosition, cameraResolution, pixelsPerMeter);
                    }
                }

                if (contextSetting.Physic.DebugMode)
                {
                    // Render colliders
                    Sdl.SetRenderDrawColor(renderer, debugColor.R, debugColor.G, debugColor.B, debugColor.A);

                    foreach (BoxCollider collider in ColliderBases)
                    {
                        if (collider.IsEnable && collider.GameObject.IsEnable && collider.IsVisible(cameraPosition, cameraResolution, pixelsPerMeter))
                        {
                            collider.Render(renderer, cameraPosition, cameraResolution, pixelsPerMeter, debugColor);
                        }
                    }

                    // draw a circle of radius 2 at the mouse position:
                    RenderCircleAtWorldPosition(worldPosition, 2);
                }

                Sdl.SetRenderTarget(renderer, IntPtr.Zero);

                // Copy the custom backbuffer to the SDL backbuffer with vertical flip
                Sdl.RenderCopyEx(renderer, cameraTexture, IntPtr.Zero, IntPtr.Zero, 0, IntPtr.Zero, RendererFlips.FlipVertical);
            }
        }

        /// <summary>
        /// Renders the circle at world position using the specified world position
        /// </summary>
        /// <param name="worldPosition">The world position</param>
        /// <param name="radius">The radius</param>
        /// <exception cref="InvalidOperationException">No cameras available to perform the rendering.</exception>
        [Conditional("DEBUG")]
        public void RenderCircleAtWorldPosition(Vector2F worldPosition, float radius)
        {
            if (Cameras.Count == 0)
            {
                throw new InvalidOperationException("No cameras available to perform the rendering.");
            }

            Camera camera = Cameras[0]; // Assuming the first camera is the main camera
            Vector2F cameraPosition = camera.Position;
            Vector2F cameraResolution = camera.Resolution;

            // Convert world position to screen position
            Vector2F screenPosition = new Vector2F(
                (worldPosition.X + (cameraResolution.X / 2 / PixelsPerMeter) - cameraPosition.X) * PixelsPerMeter,
                (worldPosition.Y + (cameraResolution.Y / 2 / PixelsPerMeter) - cameraPosition.Y) * PixelsPerMeter
            );

            // Set the color for the circle
            Sdl.SetRenderDrawColor(Renderer, 255, 0, 0, 255); // Red color

            // Draw the circle
            for (int w = 0; w < radius * 2; w++)
            {
                for (int h = 0; h < radius * 2; h++)
                {
                    int dx = (int) radius - w; // horizontal offset
                    int dy = (int) radius - h; // vertical offset
                    if ((dx * dx + dy * dy) <= (radius * radius))
                    {
                        Sdl.RenderDrawPoint(Renderer, (int) screenPosition.X + dx, (int) screenPosition.Y + dy);
                    }
                }
            }
        }

        /// <summary>
        ///     Ons the render present
        /// </summary>
        public override void OnRenderPresent()
        {
            Sdl.RenderPresent(Renderer);
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




        /// <summary>
        /// Screens the to world using the specified mouse position relative to texture centered
        /// </summary>
        /// <param name="mousePositionRelativeToTextureCentered">The mouse position relative to texture centered</param>
        /// <param name="textureSize">The texture size</param>
        /// <exception cref="InvalidOperationException">No cameras available to perform the conversion.</exception>
        /// <returns>The world position</returns>
        public Vector2F ScreenToWorld(Vector2F mousePositionRelativeToTextureCentered, Vector2F textureSize)
        {
            if (Cameras.Count == 0)
            {
                throw new InvalidOperationException("No cameras available to perform the conversion.");
            }

            Camera camera = Cameras[0]; // Assuming the first camera is the main camera
            Console.WriteLine($"Camera GameObject: {camera.GameObject.Name}");

            Vector2F cameraPosition = camera.Position;
            Console.WriteLine($"Camera Position: {cameraPosition.X}, {cameraPosition.Y}");

            Vector2F cameraResolution = camera.Resolution;
            Console.WriteLine($"Camera Resolution: {cameraResolution.X}, {cameraResolution.Y}");

            // Calculate factor conversion textureSize to cameraResolution
            float factorX = cameraResolution.X / textureSize.X;
            float factorY = cameraResolution.Y / textureSize.Y;
            Console.WriteLine($"Factor X: {factorX}, Factor Y: {factorY}");

            // Convert coordinates mouse position to unit coordinates
            Vector2F mousePositionOnGameUnits = new Vector2F(mousePositionRelativeToTextureCentered.X / PixelsPerMeter, -mousePositionRelativeToTextureCentered.Y / PixelsPerMeter);
            Console.WriteLine($"Mouse Position on Game Units: {mousePositionOnGameUnits.X}, {mousePositionOnGameUnits.Y}");

            // Adjust the mouse position based on the camera position
            float adjustedX = mousePositionOnGameUnits.X;
            float adjustedY = mousePositionOnGameUnits.Y;

            // Convert the mouse position to world coordinates
            float x = (adjustedX * factorX) + cameraPosition.X;
            float y = (adjustedY * factorY) + cameraPosition.Y;
            Console.WriteLine($"Mouse Position on World: {x}, {y}");

            worldPosition = new Vector2F(x, y);

            return worldPosition;
        }
    }
}