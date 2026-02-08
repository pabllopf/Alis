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
using System.IO;
using System.Runtime.InteropServices;
using Alis.App.Engine.Demos;
using Alis.App.Engine.Entity;
using Alis.App.Engine.Menus;
using Alis.App.Engine.Windows;
using Alis.App.Engine.Windows.Settings;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Graphic.Ui;

namespace Alis.App.Engine.Core
{
    /// <summary>
    ///     The space work class
    /// </summary>
    public class SpaceWork
    {
        /// <summary>
        ///     The icon demo
        /// </summary>
        public readonly IconDemo IconDemo = new IconDemo();

        /// <summary>
        ///     The im gui demo
        /// </summary>
        public readonly ImGuiDemo ImGuiDemo = new ImGuiDemo();

        /// <summary>
        ///     The im guizmo demo
        /// </summary>
        public readonly ImGuizmoDemo ImGuizmoDemo = new ImGuizmoDemo();

        /// <summary>
        ///     The im node demo
        /// </summary>
        public readonly ImNodeDemo ImNodeDemo = new ImNodeDemo();

        /// <summary>
        ///     The im plot demo
        /// </summary>
        public readonly ImPlotDemo ImPlotDemo = new ImPlotDemo();

        /// <summary>
        ///     The settings window
        /// </summary>
        public readonly SettingsWindow SettingsWindow;

        /// <summary>
        ///     The context
        /// </summary>
        public IntPtr ContextGui;

        /// <summary>
        ///     The font loaded 10 solid
        /// </summary>
        public ImFontPtr FontLoaded10Solid;

        /// <summary>
        ///     The font loaded 16 light
        /// </summary>
        public ImFontPtr FontLoaded16Light;

        /// <summary>
        ///     The font loaded 16 solid
        /// </summary>
        public ImFontPtr FontLoaded16Solid;

        /// <summary>
        ///     The font loaded 30 bold
        /// </summary>
        public ImFontPtr FontLoaded30Bold;

        /// <summary>
        ///     The font loaded 30 bold
        /// </summary>
        public ImFontPtr FontLoaded45Bold;

        /// <summary>
        ///     The io
        /// </summary>
        public ImGuiIoPtr io;

        /// <summary>
        ///     The quit
        /// </summary>
        public bool IsRunning = true;

        /// <summary>
        ///     The renderer game
        /// </summary>
        public IntPtr RendererGame;

        /// <summary>
        ///     The style
        /// </summary>
        public ImGuiStyle Style;

        /// <summary>
        ///     Gets or sets the value of the viewport
        /// </summary>
        public ImGuiViewportPtr Viewport;

        /// <summary>
        ///     The window
        /// </summary>
        public IntPtr Window;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SpaceWork" /> class
        /// </summary>
        public SpaceWork()
        {
            DockSpaceMenu = new DockSpaceMenu(this);
            ConsoleWindow = new ConsoleWindow(this);
            GameWindow = new GameWindow(this);
            SettingsWindow = new SettingsWindow(this);
            InspectorWindow = new InspectorWindow(this);
            SolutionWindow = new SolutionWindow(this);
            SceneWindow = new SceneWindow(this);
            ProjectWindow = new ProjectWindow(this);
            AudioPlayerWindow = new AudioPlayerWindow(this);
            AssetsWindow = new AssetsWindow(this);

            BottomMenu = new BottomMenu(this);

            string filetoread = Path.Combine(Path.GetTempPath(), "projectConfig.json");
            if (!File.Exists(filetoread))
            {
                Project =  new Project("MacOS Project (latest)", "/Users/pabllopf/Repositorios/Alis/1_Presentation/Engine/sample/alis.app.engine.sample", "NOT CONNECTED", "3 days ago", "v0.8.6");
                string jsonDefaultValue = JsonNativeAot.Serialize(Project);
                File.WriteAllText(filetoread, jsonDefaultValue);
            }
            
            string projectPath = File.ReadAllText(filetoread);
            Project projectToLoad = JsonNativeAot.Deserialize<Project>(projectPath);
            Project = projectToLoad;
        }

        /// <summary>
        ///     Gets the value of the is mac os
        /// </summary>
        public bool IsMacOs => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);


        /// <summary>
        ///     Gets the value of the console window
        /// </summary>
        internal ConsoleWindow ConsoleWindow { get; }

        /// <summary>
        ///     Gets the value of the game window
        /// </summary>
        internal GameWindow GameWindow { get; }

        /// <summary>
        ///     Gets the value of the inspector window
        /// </summary>
        internal InspectorWindow InspectorWindow { get; }

        /// <summary>
        ///     Gets the value of the solution window
        /// </summary>
        internal SolutionWindow SolutionWindow { get; }

        /// <summary>
        ///     Gets the value of the scene window
        /// </summary>
        internal SceneWindow SceneWindow { get; }

        /// <summary>
        ///     Gets the value of the project window
        /// </summary>
        internal ProjectWindow ProjectWindow { get; }



        /// <summary>
        ///     Gets the value of the dock space menu
        /// </summary>
        internal DockSpaceMenu DockSpaceMenu { get; }

        /// <summary>
        ///     Gets the value of the bottom menu
        /// </summary>
        internal BottomMenu BottomMenu { get; }

        /// <summary>
        ///     Gets the value of the audio player window
        /// </summary>
        internal AudioPlayerWindow AudioPlayerWindow { get; }

        /// <summary>
        ///     Gets the value of the assets window
        /// </summary>
        internal AssetsWindow AssetsWindow { get; }

        /// <summary>
        ///     Gets or sets the value of the fps
        /// </summary>
        public int Fps { get; set; } = 60;

        /// <summary>
        ///     Gets or sets the value of the project
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// Gets or sets the value of the font texture id
        /// </summary>
        public uint FontTextureId { get; set; }

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void OnInit()
        {
            ImGuiDemo.Initialize();
            ImPlotDemo.Initialize();
            ImGuizmoDemo.Initialize();
            ImNodeDemo.Initialize();
            IconDemo.Initialize();
            


            BottomMenu.Initialize();
            ConsoleWindow.Initialize();
            GameWindow.Initialize();
            InspectorWindow.Initialize();
            SolutionWindow.Initialize();
            SceneWindow.Initialize();
            ProjectWindow.Initialize();
            AudioPlayerWindow.Initialize();
            AssetsWindow.Initialize();
            SettingsWindow.Initialize();
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void OnStart()
        {
            ImGuiDemo.Start();
            ImPlotDemo.Start();
            ImGuizmoDemo.Start();
            ImNodeDemo.Start();
            IconDemo.Start();
            
            BottomMenu.Start();
            ConsoleWindow.Start();
            GameWindow.Start();
            InspectorWindow.Start();
            SolutionWindow.Start();
            SceneWindow.Start();
            ProjectWindow.Start();
            AudioPlayerWindow.Start();
            AssetsWindow.Start();
            SettingsWindow.Start();
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void OnRender()
        {
            ImGuiDemo.Run();
            ImPlotDemo.Run();
            ImGuizmoDemo.Run();
            ImNodeDemo.Run();
            IconDemo.Run();
            
            SettingsWindow.Render();
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