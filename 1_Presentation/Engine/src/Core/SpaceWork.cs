// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SpaceWork.cs
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
using Alis.App.Engine.Demos;
using Alis.App.Engine.Menus;
using Alis.App.Engine.Windows;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Ecs.System.Manager.Scene;
using Alis.Extension.Graphic.ImGui;

namespace Alis.App.Engine.Core
{
    /// <summary>
    /// The space work class
    /// </summary>
    public class SpaceWork
    {
        /// <summary>
        /// Gets the value of the console window
        /// </summary>
        internal ConsoleWindow ConsoleWindow { get; }
        
        /// <summary>
        /// Gets the value of the game window
        /// </summary>
        internal GameWindow GameWindow { get; }
        
        /// <summary>
        /// Gets the value of the inspector window
        /// </summary>
        internal InspectorWindow InspectorWindow { get; }
        
        /// <summary>
        /// Gets the value of the solution window
        /// </summary>
        internal SolutionWindow SolutionWindow { get; }
        
        /// <summary>
        /// Gets the value of the scene window
        /// </summary>
        internal SceneWindow SceneWindow { get; }
        
        /// <summary>
        /// Gets the value of the project window
        /// </summary>
        internal ProjectWindow ProjectWindow { get; }
        
        /// <summary>
        /// Gets the value of the top menu
        /// </summary>
        internal TopMenu TopMenu { get; }
        
        /// <summary>
        /// Gets the value of the bottom menu
        /// </summary>
        internal BottomMenu BottomMenu { get; }
        
        internal AudioPlayerWindow AudioPlayerWindow { get; }
        
        internal AssetsWindow AssetsWindow { get; }
        public int Fps { get; set; } = 60;

        /// <summary>
        ///     The window
        /// </summary>
        public IntPtr Window;

        /// <summary>
        /// Gets or sets the value of the viewport
        /// </summary>
        public ImGuiViewportPtr Viewport;

        /// <summary>
        ///     The io
        /// </summary>
        public ImGuiIoPtr Io;

        /// <summary>
        ///     The style
        /// </summary>
        public ImGuiStyle Style;
        
        /// <summary>
        ///     The context
        /// </summary>
        public IntPtr ContextGui;

        /// <summary>
        /// The im gui demo
        /// </summary>
        public readonly ImGuiDemo imGuiDemo = new ImGuiDemo();

        /// <summary>
        /// The im plot demo
        /// </summary>
        public readonly ImPlotDemo imPlotDemo = new ImPlotDemo();

        /// <summary>
        /// The im guizmo demo
        /// </summary>
        public readonly ImGuizmoDemo imGuizmoDemo = new ImGuizmoDemo();

        /// <summary>
        /// The im node demo
        /// </summary>
        public readonly ImNodeDemo imNodeDemo = new ImNodeDemo();
        
        /// <summary>
        /// The icon demo
        /// </summary>
        public readonly IconDemo iconDemo = new IconDemo();

        public IntPtr windowGame;
        
        public IntPtr rendererGame;
        
        public VideoGame VideoGame { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpaceWork"/> class
        /// </summary>
        public SpaceWork()
        {
            ConsoleWindow = new ConsoleWindow(this);
            GameWindow = new GameWindow(this);
            InspectorWindow = new InspectorWindow(this);
            SolutionWindow = new SolutionWindow(this);
            SceneWindow = new SceneWindow(this);
            ProjectWindow = new ProjectWindow(this);
            AudioPlayerWindow = new AudioPlayerWindow(this);
            AssetsWindow = new AssetsWindow(this);
            TopMenu = new TopMenu(this);
            BottomMenu = new BottomMenu(this);
            
            VideoGame = VideoGame
                .Builder()
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
                .BuildPreview();
        }

        public void Initialize()
        {
            VideoGame.InitPreview();
            
            imGuiDemo.Initialize();
            imPlotDemo.Initialize();
            imGuizmoDemo.Initialize();
            imNodeDemo.Initialize();
            iconDemo.Initialize();
            
            TopMenu.Initialize();
            BottomMenu.Initialize();
            ConsoleWindow.Initialize();
            GameWindow.Initialize();
            InspectorWindow.Initialize();
            SolutionWindow.Initialize();
            SceneWindow.Initialize();
            ProjectWindow.Initialize();
            AudioPlayerWindow.Initialize();
            AssetsWindow.Initialize();
        }
        
        public void Start()
        {
            imGuiDemo.Start();
            imPlotDemo.Start();
            imGuizmoDemo.Start();
            imNodeDemo.Start();
            iconDemo.Start();
            
            TopMenu.Start();
            BottomMenu.Start();
            ConsoleWindow.Start();
            GameWindow.Start();
            InspectorWindow.Start();
            SolutionWindow.Start();
            SceneWindow.Start();
            ProjectWindow.Start();
            AudioPlayerWindow.Start();
            AssetsWindow.Start();
        }
        
        /// <summary>
        /// Updates this instance
        /// </summary>
        public void Update()
        {
            imGuiDemo.Run();
            imPlotDemo.Run();
            imGuizmoDemo.Run();
            imNodeDemo.Run();
            iconDemo.Run();
            
            TopMenu.Render();
            BottomMenu.Render();
            ConsoleWindow.Render();
            GameWindow.Render();
            InspectorWindow.Render();
            SolutionWindow.Render();
            SceneWindow.Render();
            ProjectWindow.Render();
            AudioPlayerWindow.Render();
            AssetsWindow.Render();
        }

       
    }
}