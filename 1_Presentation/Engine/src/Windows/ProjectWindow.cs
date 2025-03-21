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
using Alis.App.Engine.Core;
using Alis.App.Engine.Fonts;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.EcsOld.Entity;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Engine.Windows
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
        ///     The group by
        /// </summary>
        private string _groupBy = "None";

        /// <summary>
        ///     The command ptr
        /// </summary>
        private IntPtr commandPtr;

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
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            if (ImGui.Begin(NameWindow, ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoCollapse))
            {
                ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4F(0, 0, 0, 0)); // Set background to transparent
                ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0); // Remove border

                if (ImGui.BeginMenuBar())
                {
                    ImGui.Text($"{FontAwesome5.Cube}");

                    ImGui.SameLine();

                    commandPtr = Marshal.StringToHGlobalAnsi(SpaceWork.VideoGame.Context.SceneManager.CurrentScene.Name);
                    if (ImGui.InputText("##SceneName", commandPtr, 125, ImGuiInputTextFlags.AlwaysOverwrite))
                    {
                        SpaceWork.VideoGame.Context.SceneManager.CurrentScene.Name = Marshal.PtrToStringAnsi(commandPtr);
                        SpaceWork.VideoGame.Save();
                    }

                    ImGui.SameLine();
                    // move to the right:
                    ImGui.SetCursorPosX(ImGui.GetWindowWidth() - 25);

                    if (ImGui.BeginMenu($"{FontAwesome5.Cog}## Options {NameWindow}"))
                    {
                        if (ImGui.MenuItem("Add GameObject"))
                        {
                            SpaceWork.VideoGame.Context.SceneManager.CurrentScene.Add(new GameObject().Builder()
                                .Name($"New GameObject ({SpaceWork.VideoGame.Context.SceneManager.CurrentScene.GameObjects.Count})")
                                .Build());
                        }

                        ImGui.Separator();

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

                Scene scene = SpaceWork.VideoGame.Context.SceneManager.CurrentScene;
                List<GameObject> gameObjects = scene.GameObjects;

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
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }

        /// <summary>
        ///     Renders the grouped by tag using the specified game objects
        /// </summary>
        /// <param name="gameObjects">The game objects</param>
        private void RenderGroupedByTag(List<GameObject> gameObjects)
        {
            Dictionary<string, List<GameObject>> groupedByTag = new Dictionary<string, List<GameObject>>();

            foreach (GameObject gameObject in gameObjects)
            {
                if (!groupedByTag.ContainsKey(gameObject.Tag))
                {
                    groupedByTag[gameObject.Tag] = new List<GameObject>();
                }

                groupedByTag[gameObject.Tag].Add(gameObject);
            }

            foreach (string tag in groupedByTag.Keys)
            {
                if (ImGui.CollapsingHeader(tag))
                {
                    int height = groupedByTag[tag].Count * 35;
                    ImGui.BeginChild(tag, new Vector2F(0, height), true);
                    foreach (GameObject gameObject in groupedByTag[tag])
                    {
                        RenderGameObjectHierarchy(gameObject);
                    }

                    ImGui.EndChild();
                }
            }
        }

        /// <summary>
        ///     Renders the grouped by layer using the specified game objects
        /// </summary>
        /// <param name="gameObjects">The game objects</param>
        private void RenderGroupedByLayer(List<GameObject> gameObjects)
        {
            Dictionary<string, List<GameObject>> groupedByLayer = new Dictionary<string, List<GameObject>>();

            foreach (GameObject gameObject in gameObjects)
            {
                if (!groupedByLayer.ContainsKey(gameObject.Layer))
                {
                    groupedByLayer[gameObject.Layer] = new List<GameObject>();
                }

                groupedByLayer[gameObject.Layer].Add(gameObject);
            }

            foreach (string layer in groupedByLayer.Keys)
            {
                if (ImGui.CollapsingHeader($"Layer {layer}"))
                {
                    int height = groupedByLayer[layer].Count * 35;
                    ImGui.BeginChild($"Layer {layer}", new Vector2F(0, height), true);

                    foreach (GameObject gameObject in groupedByLayer[layer])
                    {
                        RenderGameObjectHierarchy(gameObject);
                    }

                    ImGui.EndChild();
                }
            }
        }

        /// <summary>
        ///     Renders the game objects using the specified game objects
        /// </summary>
        /// <param name="gameObjects">The game objects</param>
        private void RenderGameObjects(List<GameObject> gameObjects)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                RenderGameObjectHierarchy(gameObject);
            }
        }

        /// <summary>
        ///     Renders the game object hierarchy using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        private void RenderGameObjectHierarchy(GameObject gameObject)
        {
            ImGui.Selectable($"{FontAwesome5.Cube} {gameObject.Name} ##{gameObject.Id}", false);

            if (ImGui.IsItemClicked(ImGuiMouseButton.Left))
            {
                SpaceWork.InspectorWindow.SelectGameObject(gameObject);
            }

            if (ImGui.IsItemClicked(ImGuiMouseButton.Right))
            {
                ImGui.OpenPopup($"context_menu_{gameObject.Id}");
            }

            if (ImGui.BeginPopup($"context_menu_{gameObject.Id}"))
            {
                if (ImGui.Selectable($"{FontAwesome5.Clone} Duplicate"))
                {
                    DuplicateGameObject(gameObject);
                }

                if (ImGui.Selectable($"{FontAwesome5.Trash} Delete"))
                {
                    DeleteGameObject(gameObject);
                }

                ImGui.EndPopup();
            }
        }

        /// <summary>
        ///     Duplicates the game object using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        private void DuplicateGameObject(GameObject gameObject)
        {
            GameObject newGameObject = (GameObject) gameObject.Clone();
            newGameObject.Name = $"Copy of {gameObject.Name}";

            SpaceWork.VideoGame.Context.SceneManager.CurrentScene.Add(newGameObject);
        }

        /// <summary>
        ///     Deletes the game object using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        private void DeleteGameObject(GameObject gameObject)
        {
            SpaceWork.VideoGame.Context.SceneManager.CurrentScene.Remove(gameObject);
        }

        /// <summary>
        ///     Renames the game object using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        private void RenameGameObject(GameObject gameObject)
        {
            // Logic to rename the game object
        }
    }
}