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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.System.Configuration;
using Alis.Core.Ecs.System.Configuration.Physic;
using Alis.Core.Ecs.System.Manager.Fonts;
using Alis.Core.Ecs.System.Scope;
using Alis.Core.Graphic.GlfwLib;
using Alis.Core.Graphic.GlfwLib.Enums;
using Alis.Core.Graphic.GlfwLib.Structs;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Stb;
using Color = Alis.Core.Aspect.Math.Definition.Color;
using Exception = System.Exception;

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
        ///     The world position
        /// </summary>
        public Vector2F WorldPosition;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GraphicManager" /> class
        /// </summary>
        public GraphicManager(Context context) : base(context)
        {
            ColliderBases = new List<BoxCollider>();
            Sprites = new List<Sprite>();
            Cameras = new List<Camera>();
            Renderer = IntPtr.Zero;
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
        public GraphicManager(List<BoxCollider> colliderBases, Window window, Vector2F defaultSize, IntPtr renderer, List<Sprite> sprites, List<Camera> cameras, Context context) : base(context)
        {
            ColliderBases = colliderBases;
            Window = window;
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
        public Window Window { get; set; }
        
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
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            // Initialize GLFW
            if (!Glfw.Init())
            {
                throw new Exception("Failed to initialize GLFW");
            }
            
            // Set GLFW window hints for OpenGL context
            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 2);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);
            Glfw.WindowHint(Hint.OpenglForwardCompatible, true);
            Glfw.WindowHint(Hint.Doublebuffer, true);
            Glfw.WindowHint(Hint.DepthBits, 24);
            Glfw.WindowHint(Hint.AlphaBits, 8);
            Glfw.WindowHint(Hint.StencilBits, 8);
            
            // Create a GLFW window
            if (this.Context.Setting.Graphic.WindowSize == new Vector2F(0,0))
            {
                this.Context.Setting.Graphic.WindowSize = new Vector2F(1024, 640);
            }
           
            Window = Glfw.CreateWindow((int)Context.Setting.Graphic.WindowSize.X, (int)Context.Setting.Graphic.WindowSize.Y, Context.Setting.General.Name, Monitor.None, Window.None);
            if (Window == Window.None)
            {
                throw new Exception("Failed to create GLFW window");
            }
            
            // Make the OpenGL context current
            Glfw.MakeContextCurrent(Window);
            
            // Enable v-sync
            Glfw.SwapInterval(1);
            
            // Log GLFW version
            Console.WriteLine($"GLFW VERSION {Glfw.GetVersionString()}");
        
           // Set window icon (skip on macOS)
           if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
           {
               Console.WriteLine("Skipping window icon setting on macOS");
           }
           else
           {
               string iconPath = Context.Setting.General.Icon;
               if (!string.IsNullOrEmpty(iconPath))
               {
                   Image icon = LoadIcon(AssetManager.Find(iconPath));
                   Glfw.SetWindowIcon(Window, 1, new Image[] { icon });
               }
           }
            
            Glfw.SetFramebufferSizeCallback(Window, FramebufferSizeCallback);
        }
        
        private static Image LoadIcon2(string iconPath)
        {
            if (!File.Exists(iconPath))
            {
                throw new FileNotFoundException("Icon file not found", iconPath);
            }

            using (FileStream stream = File.OpenRead(iconPath))
            {
                ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);

                GCHandle handle = GCHandle.Alloc(image.Data, GCHandleType.Pinned);
                IntPtr dataPtr = handle.AddrOfPinnedObject();

                Image icon = new Image
                {
                    Width = image.Width,
                    Height = image.Height,
                    Pixels = dataPtr
                };

                handle.Free();

                return icon;
            }
        }
        
       private Image LoadIcon(string iconPath)
       {
           if (!File.Exists(iconPath))
           {
               throw new FileNotFoundException("Icon file not found", iconPath);
           }
       
           using (FileStream stream = File.OpenRead(iconPath))
           {
               ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);
       
               GCHandle handle = GCHandle.Alloc(image.Data, GCHandleType.Pinned);
               IntPtr dataPtr = handle.AddrOfPinnedObject();
       
               Image icon = new Image(image.Width, image.Height, dataPtr);
       
               handle.Free();
       
               return icon;
           }
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
            Color backgrounColor = contextSetting.Graphic.BackgroundColor;
            
           
            // Clear the screen
            Gl.GlClear(ClearBufferMask.ColorBufferBit);
            
            // Draw the sprites:

            foreach (Camera camera in Cameras)
            {
                foreach (Sprite sprite in Sprites.OrderBy(o => o.Depth))
                {
                    // Render sprite with opengl:
                    sprite.Render(camera.Position, camera.Resolution, pixelsPerMeter);
                }

                foreach (BoxCollider collider in ColliderBases)
                {
                    collider.Render(camera.Position, camera.Resolution, pixelsPerMeter, debugColor);
                }

            }
            
            Gl.GlClearColor(backgrounColor.R, backgrounColor.G, backgrounColor.B, backgrounColor.A);
            
            // Swap the buffers to display the triangle
            Glfw.SwapBuffers(Window);
           
        }

        /// <summary>
        /// Framebuffers the size callback using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        private void FramebufferSizeCallback(Window window, int width, int height)
        {
            Console.WriteLine($"Framebuffer Size: {width}, {height}");
            Gl.GlViewport(0, 0, width, height);
            Context.Setting.Graphic.WindowSize = new Vector2F(width, height);
        }
        
        /// <summary>
        ///     Renders the grid using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="cameraPosition">The camera position</param>
        /// <param name="cameraResolution">The camera resolution</param>
        /// <param name="pixelsPerMeter">The pixels per meter</param>
        private void RenderGrid(IntPtr renderer, Vector2F cameraPosition, Vector2F cameraResolution, float pixelsPerMeter)
        {
            // Set the color for the grid lines
            //Sdl.SetRenderDrawColor(renderer, Context.Setting.Graphic.GridColor.R, Context.Setting.Graphic.GridColor.G, Context.Setting.Graphic.GridColor.B, Context.Setting.Graphic.GridColor.A);

            // Define the grid size in meters
            float gridSize = 1000.0f;

            // Calculate the number of lines to draw based on the grid size and pixels per meter
            int numVerticalLines = (int) gridSize;
            int numHorizontalLines = (int) gridSize;

            // Draw vertical lines
            for (int i = 0; i <= numVerticalLines; i++)
            {
                float x = -gridSize / 2 + i;
                int screenX = (int) (x * pixelsPerMeter - cameraPosition.X * pixelsPerMeter + cameraResolution.X / 2);
                //Sdl.RenderDrawLine(renderer, screenX, 0, screenX, (int) cameraResolution.Y);
            }

            // Draw horizontal lines
            for (int i = 0; i <= numHorizontalLines; i++)
            {
                float y = -gridSize / 2 + i;
                int screenY = (int) (y * pixelsPerMeter - cameraPosition.Y * pixelsPerMeter + cameraResolution.Y / 2);
                //Sdl.RenderDrawLine(renderer, 0, screenY, (int) cameraResolution.X, screenY);
            }
        }

        /// <summary>
        ///     Renders the circle at world position using the specified world position
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
                (worldPosition.X + cameraResolution.X / 2 / PixelsPerMeter - cameraPosition.X) * PixelsPerMeter,
                (worldPosition.Y + cameraResolution.Y / 2 / PixelsPerMeter - cameraPosition.Y) * PixelsPerMeter
            );

            // Set the color for the circle
            //Sdl.SetRenderDrawColor(Renderer, 255, 0, 0, 255); // Red color

            // Draw the circle
            for (int w = 0; w < radius * 2; w++)
            {
                for (int h = 0; h < radius * 2; h++)
                {
                    int dx = (int) radius - w; // horizontal offset
                    int dy = (int) radius - h; // vertical offset
                    if (dx * dx + dy * dy <= radius * radius)
                    {
                        //Sdl.RenderDrawPoint(Renderer, (int) screenPosition.X + dx, (int) screenPosition.Y + dy);
                    }
                }
            }
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
        ///     Screens the to world using the specified mouse position relative to texture centered
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
            Logger.Info($"Camera GameObject: {camera.GameObject.Name}");

            Vector2F cameraPosition = camera.Position;
            Logger.Info($"Camera Position: {cameraPosition.X}, {cameraPosition.Y}");

            Vector2F cameraResolution = camera.Resolution;
            Logger.Info($"Camera Resolution: {cameraResolution.X}, {cameraResolution.Y}");

            // Calculate factor conversion textureSize to cameraResolution
            float factorX = cameraResolution.X / textureSize.X;
            float factorY = cameraResolution.Y / textureSize.Y;
            Logger.Info($"Factor X: {factorX}, Factor Y: {factorY}");

            // Convert coordinates mouse position to unit coordinates
            Vector2F mousePositionOnGameUnits = new Vector2F(mousePositionRelativeToTextureCentered.X / PixelsPerMeter, -mousePositionRelativeToTextureCentered.Y / PixelsPerMeter);
            Logger.Info($"Mouse Position on Game Units: {mousePositionOnGameUnits.X}, {mousePositionOnGameUnits.Y}");

            // Adjust the mouse position based on the camera position
            float adjustedX = mousePositionOnGameUnits.X;
            float adjustedY = mousePositionOnGameUnits.Y;

            // Convert the mouse position to world coordinates
            float x = adjustedX * factorX + cameraPosition.X;
            float y = adjustedY * factorY + cameraPosition.Y;
            Logger.Info($"Mouse Position on World: {x}, {y}");

            WorldPosition = new Vector2F(x, y);

            return WorldPosition;
        }
    }
}