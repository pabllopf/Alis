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
using Alis.App.Engine.Fonts;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Ecs.System;
using Alis.Core.Graphic.Sdl2;
using Alis.Extension.Graphic.ImGui;
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
        private static readonly string NameWindow = $"{FontAwesome5.Hashtag} Scene";

        /// <summary>
        ///     The pixel ptr
        /// </summary>
        private IntPtr pixelPtr;

        /// <summary>
        ///     The textureopen gl id
        /// </summary>
        private uint textureopenGlId;
        
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
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
            SpaceWork.VideoGame = VideoGame
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
                        .Name("Main Scene")
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
                    
                    
                    // OTHER SCENE
                     .Add<Scene>(gameScene => gameScene
                        .Name("Other Scene")
                        
                        .Add<GameObject>(gameObject => gameObject
                            .Name("Camera")
                            .WithTag("Camera")
                            .Transform(transform => transform
                                .Position(0, 0)
                                .Scale(2, 2)
                                .Rotation(0)
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

            SpaceWork.VideoGame.StartPreview();

            SpaceWork.rendererGame = SpaceWork.VideoGame.Context.GraphicManager.Renderer;
        }

        /// <summary>
        ///     Starts this instance
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

        public void Render()
        {
            // Ejecutar el método de vista previa del videojuego
            SpaceWork.VideoGame.RunPreview();

            // Leer los píxeles del renderer de SDL
            RectangleI rect = new RectangleI(0, 0, 800, 600);
            Sdl.RenderReadPixels(SpaceWork.rendererGame, ref rect, Sdl.PixelFormatABgr8888, pixelPtr, 800 * 4);

            // Actualizar la textura de OpenGL con los píxeles renderizados
            Gl.GlBindTexture(TextureTarget.Texture2D, textureopenGlId);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba8, 800, 600, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixelPtr);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            Gl.GlBindTexture(TextureTarget.Texture2D, 0);

            // Iniciar la ventana de ImGui
            if (ImGui.Begin(NameWindow, ImGuiWindowFlags.MenuBar))
            {
               // Renderizar el menú principal
                if (ImGui.BeginMenuBar())
                {
                    if (ImGui.Button($"{FontAwesome5.HandSpock}"))
                    {
                        // Acción del botón HandSpock
                    }

                    if (ImGui.Button($"{FontAwesome5.ArrowsAlt}"))
                    {
                        // Acción del botón ArrowsAlt
                    }
                    
                    if (ImGui.Button($"{FontAwesome5.Cogs}"))
                    {
                        // Acción del botón Cogs
                    }
                    
                    if (ImGui.Button($"{FontAwesome5.InfoCircle}"))
                    {
                        // Acción del botón InfoCircle
                    }
                    
                    if (ImGui.Button($"{FontAwesome5.Tools}"))
                    {
                        // Acción del botón Tools
                    }
                    
                    if (ImGui.Button($"{FontAwesome5.User}"))
                    {
                        // Acción del botón User
                    }

                    ImGui.EndMenuBar();
                }
                
                
                // Obtener el tamaño disponible en el contenedor de ImGui
                Vector2 availableSize = ImGui.GetContentRegionAvail();

                // Aspect ratio del juego
                float gameAspectRatio = 800f / 600f;

                // Tamaño final ajustado manteniendo el aspect ratio
                float width = availableSize.X;
                float height = availableSize.X / gameAspectRatio;

                // Si el alto ajustado es mayor al espacio disponible, recalcular usando el alto
                if (height > availableSize.Y)
                {
                    height = availableSize.Y;
                    width = availableSize.Y * gameAspectRatio;
                }

                // Calcular la posición centrada dentro del área disponible
                Vector2 offset = new Vector2(
                    (availableSize.X - width) * 0.5f,
                    (availableSize.Y - height) * 0.5f);

                // Ajustar el cursor de ImGui para centrar la imagen
                ImGui.SetCursorPos(ImGui.GetCursorPos() + offset);

                // Dibujar la textura ajustada al tamaño calculado
                ImGui.Image(
                    (IntPtr) textureopenGlId,
                    new Vector2(width, height), // Tamaño ajustado
                    new Vector2(0, 0), // Coordenada de inicio (UV)
                    new Vector2(1, 1), // Coordenada final (UV)
                    new Vector4(1, 1, 1, 1), // Color del multiplicador de la textura
                    new Vector4(0, 0, 0, 0)); // Sin borde
            }

            // Terminar la ventana de ImGui
            ImGui.End();
        }
    }
}