// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Main.cs
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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Platforms.Web;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Web
{
    public static class Program
    {
        /// <summary>
        /// Gets or sets the value of the base address
        /// </summary>
        public static Uri BaseAddress { get; internal set; }
        
        
        private static VideoGame Game { get; set; }
        
        /// <summary>
        /// Frames the time
        /// </summary>
        /// <param name="time">The time</param>
        /// <param name="userData">The user data</param>
        /// <returns>The int</returns>
        [UnmanagedCallersOnly]
        public static int Frame(double time, nint userData)
        {
           
            
            //Demo.Render();

            Game.Preview();
            
            return 1;
        }

        /// <summary>
        /// Gets or sets the value of the canvas width
        /// </summary>
        private static int CanvasWidth { get; set; }
        /// <summary>
        /// Gets or sets the value of the canvas height
        /// </summary>
        private static int CanvasHeight { get; set; }
        /// <summary>
        /// Canvases the resized using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public static void CanvasResized(int width, int height)
        {
            CanvasWidth = width;
            CanvasHeight = height;
            
            Gl.GlViewport(0, 0, CanvasWidth, CanvasHeight);
        }

        /// <summary>
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
        /// <exception cref="Exception">BindApi() failed</exception>
        /// <exception cref="Exception">ChoseConfig() failed</exception>
        /// <exception cref="Exception">ChoseConfig() returned no configs</exception>
        /// <exception cref="Exception">CreateContext() failed</exception>
        /// <exception cref="Exception">CreateWindowSurface() failed</exception>
        /// <exception cref="Exception">Display was null</exception>
        /// <exception cref="Exception">Initialize() returned false.</exception>
        /// <exception cref="Exception">MakeCurrent() failed</exception>
        public async static Task Main(string[] args)
        {
            Console.WriteLine($"Hello from dotnet!");

            IntPtr display = EGL.GetDisplay(IntPtr.Zero);
            if (display == IntPtr.Zero)
            {
                throw new Exception("Display was null");
            }

            if (!EGL.Initialize(display, out int major, out int minor))
            {
                throw new Exception("Initialize() returned false.");
            }

            int[] attributeList = new int[]
            {
                EGL.EGL_RED_SIZE  , 8,
                EGL.EGL_GREEN_SIZE, 8,
                EGL.EGL_BLUE_SIZE , 8,
                EGL.EGL_DEPTH_SIZE, 24,
                EGL.EGL_STENCIL_SIZE, 8,
                EGL.EGL_SURFACE_TYPE, EGL.EGL_WINDOW_BIT,
                EGL.EGL_RENDERABLE_TYPE, EGL.EGL_OPENGL_ES3_BIT,
                EGL.EGL_SAMPLES, 16, //MSAA, 16 samples
                EGL.EGL_NONE
            };

            IntPtr config = IntPtr.Zero;
            IntPtr numConfig = IntPtr.Zero;
            if (!EGL.ChooseConfig(display, attributeList, ref config, 1, ref numConfig))
            {
                throw new Exception("ChoseConfig() failed");
            }

            if (numConfig == IntPtr.Zero)
            {
                throw new Exception("ChoseConfig() returned no configs");
            }

            if (!EGL.BindApi(EGL.EGL_OPENGL_ES_API))
            {
                throw new Exception("BindApi() failed");
            }

            int[] ctxAttribs = new int[] { EGL.EGL_CONTEXT_CLIENT_VERSION, 3, EGL.EGL_NONE };
            IntPtr context = EGL.CreateContext(display, config, EGL.EGL_NO_CONTEXT, ctxAttribs);
            if (context == IntPtr.Zero)
            {
                throw new Exception("CreateContext() failed");
            }

            // now create the surface
            IntPtr surface = EGL.CreateWindowSurface(display, config, IntPtr.Zero, IntPtr.Zero);
            if (surface == IntPtr.Zero)
            {
                throw new Exception("CreateWindowSurface() failed");
            }

            if (!EGL.MakeCurrent(display, surface, surface, context))
            {
                throw new Exception("MakeCurrent() failed");
            }
            
            Gl.Initialize(EGL.GetProcAddress);

            Interop.Initialize();

            //Demo = new MeshDemo();
            //Demo.CanvasResized(CanvasWidth, CanvasHeight);

            
            Game = VideoGame.Create()
                .Settings(setting => setting
                    .General(general => general
                        .Name("King Game")
                        .Author("Pablo Perdomo Falcón")
                        .Description("King platform 2d game.")
                        .Debug(false)
                        .License("GNU General Public License v3.0")
                        .Icon("app.bmp")
                        .Build())
                    .Audio(audio => audio
                        .Build())
                    .Graphic(graphic => graphic
                        .Resolution(640, 480)
                        .BackgroundColor(Color.Cyan)
                        .Build())
                    .Physic(physic => physic
                        .Gravity(0.0f, -9.8f)
                        .Debug(true)
                        .Build())
                    .Build())
                .World(sceneManager => sceneManager
                    .Add<Scene>(gameScene => gameScene

                        // PLAYER
                        .Add<GameObject>(player => player
                            .Transform(transform => transform
                                .Position(0, 2)
                                .Scale(2, 2)
                                .Rotation(0)
                                .Build())
                            .WithComponent<Sprite>(sprite => sprite
                                .Depth(1)
                                .SetTexture("tile023.bmp")
                                .Build())
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                .IsActive(true)
                                .BodyType(BodyType.Dynamic)
                                .IsTrigger(false)
                                .AutoTilling(true)
                                .Rotation(0.0f)
                                .Size(1, 1)
                                .Mass(1.0f)
                                .Restitution(0.0f)
                                .Friction(0f)
                                .FixedRotation(true)
                                .IgnoreGravity(false)
                                .Build())
                            .WithComponent<Camera>(camera => camera
                                .Resolution(640, 480))
                            .Build())

                        // FLOOR
                        .Add<GameObject>(gameObject => gameObject
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Scale(1, 1)
                                .Rotation(0)
                                .Build())
                            .WithComponent<BoxCollider>(boxCollider => boxCollider
                                .IsActive(true)
                                .BodyType(BodyType.Static)
                                .IsTrigger(false)
                                .AutoTilling(false)
                                .Size(20, 1)
                                .Rotation(0.0f)
                                .RelativePosition(0, 0)
                                .Mass(10.0f)
                                .Restitution(0.0f)
                                .Friction(0.1f)
                                .FixedRotation(true)
                                .IgnoreGravity(false)
                                .Build())
                            .Build())
                        .Build())
                    .Build())
                .Build();

            Game.InitPreview();
            
            Gl.GlViewport(0, 0, CanvasWidth, CanvasHeight);
            
            unsafe
            {
                Emscripten.RequestAnimationFrameLoop((IntPtr)(delegate* unmanaged<double, nint, int>)&Frame, nint.Zero);
            }
        }
    }
}