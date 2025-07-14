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
using Alis.App.Engine.Entity;
using Alis.App.Engine.Menus;
using Alis.App.Engine.Windows;
using Alis.App.Engine.Windows.Settings;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Controllers;

namespace Alis.App.Engine.Core
{
    /// <summary>
    ///     The space work class
    /// </summary>
    public class SpaceWork
    {
        /// <summary>
        ///     The settings window
        /// </summary>
        public readonly SettingsWindow SettingsWindow;

        public ImGuiControllerImplementGlfw ImGuiController;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SpaceWork" /> class
        /// </summary>
        public SpaceWork(ImGuiControllerImplementGlfw imGuiController)
        {
            ImGuiController = imGuiController;
            
            DockSpaceMenu = new DockSpaceMenu(this);
            ConsoleWindow = new ConsoleWindow(this);
            GameWindow = new GameWindow(this);
            SettingsWindow = new SettingsWindow(this);
            InspectorWindow = new InspectorWindow(this);
            SolutionWindow = new SolutionWindow(this);
            //SceneWindow = new SceneWindow(this);
            ProjectWindow = new ProjectWindow(this);
            AudioPlayerWindow = new AudioPlayerWindow(this);
            AssetsWindow = new AssetsWindow(this);

            TopMenu = new TopMenu(this);
            TopMenuMac = new TopMenuMac(this);
            BottomMenu = new BottomMenu(this);

            Project = JsonSerializer.Deserialize<Project>(File.ReadAllText(Path.Combine(Path.GetTempPath(), "projectConfig.json")));
        }

        /// <summary>
        ///     Gets the value of the is mac os
        /// </summary>
        public bool IsMacOs => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        /// <summary>
        ///     Gets or sets the value of the top menu mac
        /// </summary>
        public TopMenuMac TopMenuMac { get; set; }

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
        ///     Gets the value of the top menu
        /// </summary>
        internal TopMenu TopMenu { get; }

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
        ///     Gets or sets the value of the project
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
            // if is macos system:
            if (!IsMacOs)
            {
                TopMenu.Initialize();
            }
            else
            {
                TopMenuMac.Initialize();
            }


            BottomMenu.Initialize();
            ConsoleWindow.Initialize();
            GameWindow.Initialize();
            InspectorWindow.Initialize();
            //SolutionWindow.Initialize();
            //SceneWindow.Initialize();
            ProjectWindow.Initialize();
            AudioPlayerWindow.Initialize();
            AssetsWindow.Initialize();
            SettingsWindow.Initialize();
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {

            // if is macos system:
            if (!IsMacOs)
            {
                TopMenu.Start();
            }
            else
            {
                TopMenuMac.Start();
            }


            BottomMenu.Start();
            ConsoleWindow.Start();
            GameWindow.Start();
            InspectorWindow.Start();
            //SolutionWindow.Start();
            //SceneWindow.Start();
            ProjectWindow.Start();
            AudioPlayerWindow.Start();
            AssetsWindow.Start();
            SettingsWindow.Start();
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void Update()
        {
            // if is macos system:
            if (!IsMacOs)
            {
                TopMenu.Render();
            }
            else
            {
                TopMenuMac.Render();
            }

            SettingsWindow.Render();
            BottomMenu.Render();
            ConsoleWindow.Render();
            //GameWindow.Render();
            //InspectorWindow.Render();
            //SolutionWindow.Render();
            //SceneWindow.Render();
            //ProjectWindow.Render();
            AudioPlayerWindow.Render();
            AssetsWindow.Render();
        }
    }
}