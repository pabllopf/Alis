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

using System.Collections.Generic;
using Alis.App.Engine.Core;
using Alis.App.Engine.Fonts;
using Alis.Core.Ecs.Entity;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The project window class
    /// </summary>
    public class ProjectWindow : IWindow
    {
        /// <summary>
        /// The stream
        /// </summary>
        private static readonly string NameWindow = $"{FontAwesome5.Stream} Project";

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
        /// Renders this instance
        /// </summary>
        public void Render()
        {
            ImGui.Begin(NameWindow);

            Scene scene = SpaceWork.VideoGame.Context.SceneManager.CurrentScene;

            List<GameObject> gameObjects = scene.GameObjects;

            foreach (GameObject gameObject in gameObjects)
            {
                RenderGameObjectHierarchy(gameObject);

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

                    if (ImGui.Selectable($"{FontAwesome5.Pen} Rename"))
                    {
                        RenameGameObject(gameObject);
                    }

                    ImGui.EndPopup();
                }
            }

            ImGui.End();
        }


        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }

        /// <summary>
        /// Renders the game object hierarchy using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        private void RenderGameObjectHierarchy(GameObject gameObject)
        {
            // Render leaf GameObject without children
            ImGui.Selectable($"{FontAwesome5.Cube} {gameObject.Name} ##{gameObject.Id}", false);

            if (ImGui.IsItemClicked(ImGuiMouseButton.Left))
            {
                SpaceWork.InspectorWindow.SelectGameObject(gameObject);
            }
        }

        /// <summary>
        /// Duplicates the game object using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        private void DuplicateGameObject(GameObject gameObject)
        {
            // Logic to duplicate the game object
        }

        /// <summary>
        /// Deletes the game object using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        private void DeleteGameObject(GameObject gameObject)
        {
            // Logic to delete the game object
        }

        /// <summary>
        /// Renames the game object using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        private void RenameGameObject(GameObject gameObject)
        {
            // Logic to rename the game object
        }
    }
}