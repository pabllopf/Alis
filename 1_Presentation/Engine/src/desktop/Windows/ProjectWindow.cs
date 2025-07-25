// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProjectWindow.cs
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
using System.Runtime.InteropServices;
using Alis.App.Engine.Desktop.Core;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Desktop.Windows
{
    /// <summary>
    ///     The project window class
    /// </summary>
    /// <seealso cref="IWindow" />
    public class ProjectWindow : IWindow
    {
        /// <summary>
        ///     The stream
        /// </summary>
        private static readonly string NameWindow = $"{FontAwesome5.Stream} Project";

        /// <summary>
        /// The is open
        /// </summary>
        private bool _isOpen = true;

        /// <summary>
        /// The command ptr
        /// </summary>
        private IntPtr commandPtr;

        /// <summary>
        /// The group by
        /// </summary>
        private string _groupBy;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProjectWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public ProjectWindow(SpaceWork spaceWork) => SpaceWork = spaceWork;

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
        }

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }

        /// <summary>
        /// Renders this instance
        /// </summary>
        public void Render()
        {
            if (!_isOpen)
            {
                return;
            }

            if (ImGui.Begin(NameWindow, ref _isOpen, ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.MenuBar))
            {
                ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0, 0, 0, 0)); // Set background to transparent
                ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0); // Remove border

                if (ImGui.BeginMenuBar())
                {
                    ImGui.Text($"{FontAwesome5.Cube}");

                    ImGui.SameLine();

                    commandPtr = Marshal.StringToHGlobalAnsi(SpaceWork.VideoGame.Context.SceneManager.Name);
                    if (ImGui.InputText("##SceneName", commandPtr, 125, ImGuiInputTextFlags.AlwaysOverwrite))
                    {
                        SpaceWork.VideoGame.Context.SceneManager.Name = Marshal.PtrToStringAnsi(commandPtr);
                        //SpaceWork.VideoGame.Save();
                    }

                    ImGui.SameLine();
                    // move to the right:
                    ImGui.SetCursorPosX(ImGui.GetWindowWidth() - 55);

                    if (ImGui.BeginMenu($"{FontAwesome5.Plus}## Add {NameWindow}"))
                    {
                        if (ImGui.MenuItem("Add GameObject"))
                        {
                            //SpaceWork.VideoGame.Context.SceneManager.CurrentScene.Add(new GameObject().Builder()
                            //    .Name($"New GameObject ({SpaceWork.VideoGame.Context.SceneManager.CurrentScene.GameObjects.Count})")
                            //    .Build());
                        }
                        
                        ImGui.EndMenu();
                    }
                    
                    
                    if (ImGui.BeginMenu($"{FontAwesome5.Eye}## Options {NameWindow}"))
                    {
                        if (ImGui.MenuItem("Filter by Name"))
                        {
                            _groupBy = "Name";
                        }

                        if (ImGui.MenuItem("Group by Tag"))
                        {
                            _groupBy = "Tag";
                        }

                        if (ImGui.MenuItem("Group by Layer"))
                        {
                            _groupBy = "Layer";
                        }

                        ImGui.EndMenu();
                    }

                    

                    ImGui.EndMenuBar();
                }

                ImGui.PopStyleVar();
                ImGui.PopStyleColor();

                List<GameObject> gameObjects = new List<GameObject>();

                switch (_groupBy)
                {
                    case "Tag":
                        RenderGroupedByTag(gameObjects);
                        break;
                    case "Layer":
                        RenderGroupedByLayer(gameObjects);
                        break;
                    default:
                        RenderGameObjects(gameObjects);
                        break;
                }
            }
            
            ImGui.End();
        }

        /// <summary>
        /// Renders the game objects using the specified game objects
        /// </summary>
        /// <param name="gameObjects">The game objects</param>
        private void RenderGameObjects(List<GameObject> gameObjects)
        {
            
        }

        /// <summary>
        /// Renders the grouped by layer using the specified game objects
        /// </summary>
        /// <param name="gameObjects">The game objects</param>
        private void RenderGroupedByLayer(List<GameObject> gameObjects)
        {
          
        }

        /// <summary>
        /// Renders the grouped by tag using the specified game objects
        /// </summary>
        /// <param name="gameObjects">The game objects</param>
        private void RenderGroupedByTag(List<GameObject> gameObjects)
        {
            
        }
    }
}