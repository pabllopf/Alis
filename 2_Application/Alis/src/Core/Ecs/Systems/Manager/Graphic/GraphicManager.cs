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
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;

using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Configuration.Physic;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Graphic.GlfwLib;
using Alis.Core.Graphic.GlfwLib.Enums;
using Alis.Core.Graphic.GlfwLib.Structs;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Color = Alis.Core.Aspect.Math.Definition.Color;

namespace Alis.Core.Ecs.Systems.Manager.Graphic
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
        ///     The framebuffer size callback
        /// </summary>
        private SizeCallback framebufferSizeCallback;

        /// <summary>
        ///     The world position
        /// </summary>
        public Vector2F WorldPosition;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GraphicManager" /> class
        /// </summary>
        public GraphicManager(Context context) : base(context) => Renderer = IntPtr.Zero;

        /// <summary>
        /// Gets or sets the value of the window
        /// </summary>
        public Window Window { get; set; }

        /// <summary>
        /// Gets or sets the value of the renderer
        /// </summary>
        public IntPtr Renderer { get; set; }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            // Initialize GLFW
            Glfw.Init();

            // Set GLFW window hints for OpenGL context
            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 2);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);
            Glfw.WindowHint(Hint.OpenglForwardCompatible, true);
            Glfw.WindowHint(Hint.Doublebuffer, true);
            Glfw.WindowHint(Hint.DepthBits, 24);
            Glfw.WindowHint(Hint.AlphaBits, 8);
            Glfw.WindowHint(Hint.StencilBits, 8);

            if (Context.Setting.Graphic.IsResizable)
            {
                Glfw.WindowHint(Hint.Resizable, true);
            }
            else
            {
                Glfw.WindowHint(Hint.Resizable, false);
            }

            // Create a GLFW window
            if (Context.Setting.Graphic.WindowSize == new Vector2F(0, 0))
            {
                Context.Setting.Graphic = Context.Setting.Graphic with {WindowSize = new Vector2F(1280, 720)};
            }

            Window = Glfw.CreateWindow((int) Context.Setting.Graphic.WindowSize.X, (int) Context.Setting.Graphic.WindowSize.Y, Context.Setting.General.Name, Monitor.None, Window.None);
            if (Window == Window.None)
            {
                throw new Exception("Failed to create GLFW window");
            }

            // Make the OpenGL context current
            Glfw.MakeContextCurrent(Window);

            // Enable v-sync
            Glfw.SwapInterval(1);

            // Log GLFW version
            Logger.Log($"GLFW VERSION {Glfw.GetVersionString()}");

            // Set window icon (skip on macOS)
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Logger.Log("Skipping window icon setting on macOS");
            }
            else
            {
                string iconPath = Context.Setting.General.Icon;
                if (!string.IsNullOrEmpty(iconPath))
                {
                    //Image icon = LoadIcon(AssetManager.Find(iconPath));
                    //Glfw.SetWindowIcon(Window, 1, new[] {icon});
                }
            }

            framebufferSizeCallback = FramebufferSizeCallback;
            Glfw.SetFramebufferSizeCallback(Window, framebufferSizeCallback);
            
            Glfw.SetCloseCallback(Window, CloseWindowCallback);
        }

        /// <summary>
        /// Closes the window callback using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        private void CloseWindowCallback(Window window)
        {
            Context.Exit();
        }

        /// <summary>
        ///     Loads the icon using the specified icon path
        /// </summary>
        /// <param name="iconPath">The icon path</param>
        /// <exception cref="FileNotFoundException">Icon file not found </exception>
        /// <returns>The image</returns>
        private Image LoadIcon(string iconPath)
        {
            if (!File.Exists(iconPath))
            {
                throw new FileNotFoundException("Icon file not found", iconPath);
            }

            /*
            using (FileStream stream = File.OpenRead(iconPath))
            {
                ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);

                GCHandle handle = GCHandle.Alloc(image.Data, GCHandleType.Pinned);
                IntPtr dataPtr = handle.AddrOfPinnedObject();

                Image icon = new Image(image.Width, image.Height, dataPtr);

                handle.Free();

                return icon;
            }*/
            
            return Image.Load(iconPath);
        }


        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
        }

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
            Setting contextSetting = Context.Setting;
            PhysicSetting physicSettings = contextSetting.Physic;
            Color backgrounColor = contextSetting.Graphic.BackgroundColor;

            Glfw.PollEvents();

            // Set the clear color (convert from 0-255 range to 0.0-1.0 range)
            Gl.GlClearColor(backgrounColor.R / 255.0f, backgrounColor.G / 255.0f, backgrounColor.B / 255.0f, backgrounColor.A / 255.0f);

            // Clear the screen
            Gl.GlClear(ClearBufferMask.ColorBufferBit);
            
           GameObjectQueryEnumerator.QueryEnumerable spriteGameObjects = Context.SceneManager.World
               .Query<With<Sprite>>()
               .EnumerateWithEntities();
           
           GameObjectQueryEnumerator.QueryEnumerable boxColliderGameObjects = Context.SceneManager.World
               .Query<With<BoxCollider>>()
               .EnumerateWithEntities();
           
           foreach (RefTuple<Camera> camera in Context.SceneManager.World
                       .Query<With<Camera>>()
                       .Enumerate<Camera>())
           {
               foreach (GameObject spriteGameobject in spriteGameObjects)
               {
                   if (spriteGameobject.Has<Sprite>())
                   {
                       ref Sprite sprite = ref spriteGameobject.Get<Sprite>();
                       sprite.Render(spriteGameobject, camera.Item1.Value.Position, camera.Item1.Value.Resolution, pixelsPerMeter);
                   }
               }
               
               foreach (GameObject boxColliderGameobject in boxColliderGameObjects)
               {
                   if (boxColliderGameobject.Has<BoxCollider>())
                   {
                       ref BoxCollider boxCollider = ref boxColliderGameobject.Get<BoxCollider>();
                       boxCollider.Render(boxColliderGameobject,  camera.Item1.Value.Position, camera.Item1.Value.Resolution, pixelsPerMeter);
                   }
               }
           }
            
            // Swap the buffers to display the triangle
            Glfw.SwapBuffers(Window);
        }
        
        /// <summary>
        ///     Framebuffers the size callback using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        private void FramebufferSizeCallback(Window window, int width, int height)
        {
            Logger.Log($"Framebuffer Size: {width}, {height}");
            Gl.GlViewport(0, 0, width, height);
            Context.Setting.Graphic = Context.Setting.Graphic with {WindowSize = new Vector2F(width, height)};
        }
    }
}