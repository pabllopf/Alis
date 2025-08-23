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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;

using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Configuration.Physic;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Graphic;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Platforms;
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
        ///     Initializes a new instance of the <see cref="GraphicManager" /> class
        /// </summary>
        public GraphicManager(Context context) : base(context)
        {
            
        }
        
        /// <summary>
        /// Gets or sets the value of the renderer
        /// </summary>
        public IntPtr Renderer { get; set; }
        
        /// <summary>
        /// The platform
        /// </summary>
        private  INativePlatform platform;

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            
#if OSX
            platform = new Alis.Core.Graphic.Platforms.Osx.MacNativePlatform();
#elif WIN
            platform = new Alis.Core.Graphic.Platforms.Win.WinNativePlatform();
#elif LINUX
            platform = new Alis.Core.Graphic.Platforms.Linux.LinuxNativePlatform();
#else
            throw new Exception("Sistema operativo no soportado");
#endif
            
            
            platform.Initialize(800, 600, "C# + OpenGL Platform");
            platform.MakeContextCurrent();
            Gl.Initialize(platform.GetProcAddress);
            //Gl.GlViewport(0, 0, platform.GetWindowWidth(), platform.GetWindowHeight());
            //Gl.GlEnable(EnableCap.DepthTest);
            
            platform.ShowWindow();
           
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
            bool running = platform.PollEvents();
            if (platform.TryGetLastKeyPressed(out ConsoleKey key))
            {
                Console.WriteLine($"Tecla pulsada: {key}");
            }
            
            float pixelsPerMeter = PixelsPerMeter;
            Setting contextSetting = Context.Setting;
            PhysicSetting physicSettings = contextSetting.Physic;
            Color backgrounColor = contextSetting.Graphic.BackgroundColor;

            //Glfw.PollEvents();

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
                   if (spriteGameobject.Has<Animator>() && spriteGameobject.Has<Sprite>())
                   {
                       ref Animator animator = ref spriteGameobject.Get<Animator>();
                       ref Sprite sprite = ref spriteGameobject.Get<Sprite>();
                       animator.DrawAnimation(ref sprite);
                   }
                   
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
            //Glfw.SwapBuffers(Window);
            
            platform.SwapBuffers();
            int glError = Gl.GlGetError();
            if (glError != 0)
            {
                Console.WriteLine($"OpenGL error tras flushBuffer: 0x{glError:X}");
            }
        }
    }
}