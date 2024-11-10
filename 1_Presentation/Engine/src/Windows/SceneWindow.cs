// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneWindow.cs
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
using Alis.App.Engine.Core;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Ecs.System;
using Alis.Core.Graphic.Sdl2;
using Alis.Extension.Graphic.ImGui.Native;
using Alis.Extension.Graphic.OpenGL;
using Alis.Extension.Graphic.OpenGL.Enums;
using PixelFormat = Alis.Extension.Graphic.OpenGL.Enums.PixelFormat;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The scene window class
    /// </summary>
    public class SceneWindow : IWindow
    {
        /// <summary>
        /// The name window
        /// </summary>
        private const string NameWindow = "Scene";
        /// <summary>
        /// The pixel ptr
        /// </summary>
        private IntPtr pixelPtr;
        /// <summary>
        /// The textureopen gl id
        /// </summary>
        private uint textureopenGlId;

        private VideoGame videoGame;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SceneWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public SceneWindow(SpaceWork spaceWork) => SpaceWork = spaceWork;

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }

        /// <summary>
        /// Initializes this instance
        /// </summary>
        public void Initialize()
        {
             videoGame = VideoGame
                 .Create()
                 .Settings(setting => setting
                     .General(general => general
                         .Name("Rogue Legacy")
                         .Author("Pablo Perdomo Falcón")
                         .Description("Sample of a rogue legacy game")
                         .Debug(true)
                         .License("GNU General Public License v3.0")
                         .Icon("app.bmp")
                         .Build())
                     .Audio(audio => audio
                         .Build())
                     .Graphic(graphic => graphic
                         .Window(window => window
                             .Resolution(1024, 640)
                             .Background(Color.Black)
                             .Build())
                         .Build())
                     .Physic(physic => physic
                         .Gravity(0.0f, -9.8f)
                         .Debug(true)
                         .DebugColor(Color.Green)
                         .Build())
                     .Build())
                 .World(sceneManager => sceneManager
                     .Add<Scene>(gameScene => gameScene
                         .Add<GameObject>(gameObject => gameObject
                             .Name("Player")
                             .WithTag("Player")
                             .Transform(transform => transform
                                 .Position(0, 0)
                                 .Scale(2, 2)
                                 .Rotation(0)
                                 .Build())
                             .AddComponent<Sprite>(sprite => sprite.Builder()
                                 .SetTexture("tile000.bmp")
                                 .Build())
                             .AddComponent<Animator>(animator => animator.Builder()
                                 .AddAnimation(animation => animation
                                     .Name("Idle")
                                     .Order(0)
                                     .Speed(0.2f)
                                     .AddFrame(frame => frame
                                         .FilePath("tile000.bmp")
                                         .Build())
                                     .AddFrame(frame => frame
                                         .FilePath("tile001.bmp")
                                         .Build())
                                     .AddFrame(frame => frame
                                         .FilePath("tile002.bmp")
                                         .Build())
                                     .AddFrame(frame => frame
                                         .FilePath("tile003.bmp")
                                         .Build())
                                     .Build())
                                 .Build())
                             .AddComponent<Camera>(camera => camera.Builder()
                                 .Resolution(1024, 640)
                                 .BackgroundColor(Color.DarkGreen)
                                 .Build())
                             .Build())

                         // Decoration tree-001
                         .Add<GameObject>(gameObject => gameObject
                             .Name("tree-001")
                             .Transform(transform => transform
                                 .Position(100, 100)
                                 .Scale(2, 2)
                                 .Rotation(0)
                                 .Build())
                             .AddComponent<Sprite>(sprite => sprite.Builder()
                                 .SetTexture("tree-001.bmp")
                                 .Build())
                             .Build())

                         // Decoration tree-001
                         .Add<GameObject>(gameObject => gameObject
                             .Name("tree-002")
                             .Transform(transform => transform
                                 .Position(400, 400)
                                 .Scale(2, 2)
                                 .Rotation(0)
                                 .Build())
                             .AddComponent<Sprite>(sprite => sprite.Builder()
                                 .SetTexture("tree-001.bmp")
                                 .Build())
                             .Build())
                         .Add<GameObject>(gameObject => gameObject
                             .Name("tree-001")
                             .Transform(transform => transform
                                 .Position(-100, -100)
                                 .Scale(2, 2)
                                 .Rotation(0)
                                 .Build())
                             .AddComponent<Sprite>(sprite => sprite.Builder()
                                 .SetTexture("tree-001.bmp")
                                 .Build())
                             .Build())
                         .Add<GameObject>(gameObject => gameObject
                             .Name("tree-001")
                             .Transform(transform => transform
                                 .Position(-200, -200)
                                 .Scale(2, 2)
                                 .Rotation(0)
                                 .Build())
                             .AddComponent<Sprite>(sprite => sprite.Builder()
                                 .SetTexture("tree-001.bmp")
                                 .Build())
                             .Build())
                         .Build())
                     .Build())
                 .Build();
             
            videoGame.StartPreview();
            
            SpaceWork.rendererGame = videoGame.Context.GraphicManager.Renderer;
        }

        /// <summary>
        /// Starts this instance
        /// </summary>
        public void Start()
        {
            pixelPtr = Marshal.AllocHGlobal(800 * 600 * 4);
            uint[] textures = new uint[1];
            Gl.GlGenTextures(1, textures);
            textureopenGlId = textures[0];
            Gl.GlBindTexture(TextureTarget.Texture2D, textureopenGlId);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba8, 800, 600, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixelPtr);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);

            Console.WriteLine($"Gl Version: {Gl.GlGetString(StringName.Version)}");
            Console.WriteLine($"Vendor: {Gl.GlGetString(StringName.Vendor)}");
            Console.WriteLine($"Renderer: {Gl.GlGetString(StringName.Renderer)}");
            Console.WriteLine($"Extensions: {Gl.GlGetString(StringName.Extensions)}");
            Console.WriteLine($"SDL2 Version: {Sdl.GetVersion().major}.{Sdl.GetVersion().minor}.{Sdl.GetVersion().patch}");
            Console.WriteLine($"Imgui Version: {ImGui.GetVersion()}");
        }

        /// <summary>
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            videoGame.RunPreview();

            RectangleI rect = new RectangleI(0, 0, 800, 600);
            Sdl.RenderReadPixels(SpaceWork.rendererGame, ref rect, Sdl.PixelFormatABgr8888, pixelPtr, 800 * 4);

            Gl.GlBindTexture(TextureTarget.Texture2D, textureopenGlId);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba8, 800, 600, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixelPtr);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            Gl.GlBindTexture(TextureTarget.Texture2D, 0);

            if (ImGui.Begin("Scene Sample"))
            {
                ImGui.Image(
                    (IntPtr) textureopenGlId,
                    new Vector2(800, 600),
                    new Vector2(0, 0),
                    new Vector2(1, 1),
                    new Vector4(1, 1, 1, 1),
                    new Vector4(255, 0, 0, 255));
            }

            ImGui.End();
        }
    }
}